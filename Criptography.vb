Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text

Module Criptography

    Private Const Base32AllowedCharacters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"

    Public Function AES_Decrypt(input As String, pass As String) As String
        Dim str As String = Nothing
        Dim managed As New RijndaelManaged
        Dim provider As New MD5CryptoServiceProvider
        Try
            Dim destinationArray As Byte() = New Byte(&H20 - 1) {}
            Dim sourceArray As Byte() = provider.ComputeHash(Encoding.ASCII.GetBytes(pass))
            Array.Copy(sourceArray, 0, destinationArray, 0, &H10)
            Array.Copy(sourceArray, 0, destinationArray, 15, &H10)
            managed.Key = destinationArray
            managed.Mode = CipherMode.ECB
            Dim transform As ICryptoTransform = managed.CreateDecryptor
            Dim inputBuffer As Byte() = Convert.FromBase64String(input)
            str = Encoding.ASCII.GetString(transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length))
        Catch exception1 As Exception
            MsgBox(exception1.ToString)
        End Try
        Return str
    End Function

    Public Function AES_Encrypt(input As String, pass As String) As String
        Dim str As String = Nothing
        Dim managed As New RijndaelManaged
        Dim provider As New MD5CryptoServiceProvider
        Try
            Dim destinationArray As Byte() = New Byte(&H20 - 1) {}
            Dim sourceArray As Byte() = provider.ComputeHash(Encoding.ASCII.GetBytes(pass))
            Array.Copy(sourceArray, 0, destinationArray, 0, &H10)
            Array.Copy(sourceArray, 0, destinationArray, 15, &H10)
            managed.Key = destinationArray
            managed.Mode = CipherMode.ECB
            Dim transform As ICryptoTransform = managed.CreateEncryptor
            Dim bytes As Byte() = Encoding.ASCII.GetBytes(input)
            str = Convert.ToBase64String(transform.TransformFinalBlock(bytes, 0, bytes.Length))
        Catch exception1 As Exception
            MsgBox(exception1.ToString)
        End Try
        Return str
    End Function


    <Extension()>
    Function ToBase32String(input As Byte(), Optional addPadding As Boolean = True) As String
        If input Is Nothing OrElse input.Length = 0 Then
            Return String.Empty
        End If

        Dim bits = input.[Select](Function(b) Convert.ToString(b, 2).PadLeft(8, "0"c)).Aggregate(Function(a, b) a & b).PadRight((Math.Ceiling((input.Length * 8) / 5.0R) * 5), "0"c)
        Dim result = Enumerable.Range(0, bits.Length / 5).[Select](Function(i) Base32AllowedCharacters.Substring(Convert.ToInt32(bits.Substring(i * 5, 5), 2), 1)).Aggregate(Function(a, b) a & b)

        If addPadding Then
            result = result.PadRight((Math.Ceiling(result.Length / 8.0R) * 8), "="c)
        End If

        Return result
    End Function

    <Extension()>
    Function EncodeAsBase32String(input As String, Optional addPadding As Boolean = True) As String
        If String.IsNullOrEmpty(input) Then Return String.Empty

        Dim bytes = Encoding.UTF8.GetBytes(input)
        Return bytes.ToBase32String(addPadding)
    End Function

    <Extension()>
    Function DecodeFromBase32String(input As String) As String
        If String.IsNullOrEmpty(input) Then Return String.Empty

        Dim bytes = input.ToByteArray()
        Return Encoding.UTF8.GetString(bytes)
    End Function

    <Extension()>
    Function ToByteArray(input As String) As Byte()
        If String.IsNullOrEmpty(input) Then Return New Byte(-1) {}

        Dim bits = input.TrimEnd("="c).ToUpper().ToCharArray().[Select](Function(c) Convert.ToString(Base32AllowedCharacters.IndexOf(c), 2).PadLeft(5, "0"c)).Aggregate(Function(a, b) a & b)
        Return Enumerable.Range(0, bits.Length / 8).[Select](Function(i) Convert.ToByte(bits.Substring(i * 8, 8), 2)).ToArray()
    End Function

End Module

Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text

Module Criptography

    Private Const Base32AllowedCharacters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"

    Private Const PassCode As String = "!S0Me-P455w*r6//+"

    Public Function AESDecrypt(input As String) As String
        Dim managed As New RijndaelManaged
        Dim provider As New MD5CryptoServiceProvider
        Try
            Dim destinationArray As Byte() = New Byte(&H20 - 1) {}
            Dim sourceArray As Byte() = provider.ComputeHash(Encoding.ASCII.GetBytes(PassCode))
            Array.Copy(sourceArray, 0, destinationArray, 0, &H10)
            Array.Copy(sourceArray, 0, destinationArray, 15, &H10)
            managed.Key = destinationArray
            managed.Mode = CipherMode.ECB
            Dim transform As ICryptoTransform = managed.CreateDecryptor
            Dim inputBuffer As Byte() = Convert.FromBase64String(input)
            Return Encoding.ASCII.GetString(transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length))
        Catch e As Exception
            MsgBox(e.ToString)
        End Try
        Return Nothing
    End Function

    Public Function AESEncrypt(input As String) As String
        Dim managed As New RijndaelManaged
        Dim provider As New MD5CryptoServiceProvider
        Try
            Dim destinationArray As Byte() = New Byte(&H20 - 1) {}
            Dim sourceArray As Byte() = provider.ComputeHash(Encoding.ASCII.GetBytes(PassCode))
            Array.Copy(sourceArray, 0, destinationArray, 0, &H10)
            Array.Copy(sourceArray, 0, destinationArray, 15, &H10)
            managed.Key = destinationArray
            managed.Mode = CipherMode.ECB
            Dim transform As ICryptoTransform = managed.CreateEncryptor
            Dim bytes As Byte() = Encoding.ASCII.GetBytes(input)
            Return Convert.ToBase64String(transform.TransformFinalBlock(bytes, 0, bytes.Length))
        Catch e As Exception
            MsgBox(e.ToString)
        End Try
        Return Nothing
    End Function

    <Extension()>
    Function ToByteArray(input As String) As Byte()
        If String.IsNullOrEmpty(input) Then Return New Byte(-1) {}

        Dim bits = input.TrimEnd("="c).ToUpper().ToCharArray().[Select](Function(c) Convert.ToString(Base32AllowedCharacters.IndexOf(c), 2).PadLeft(5, "0"c)).Aggregate(Function(a, b) a & b)
        Return Enumerable.Range(0, bits.Length / 8).[Select](Function(i) Convert.ToByte(bits.Substring(i * 8, 8), 2)).ToArray()
    End Function

End Module

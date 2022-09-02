Imports System.IO
Imports System.Security.Cryptography

Module EncrypterFile

    Private Const SECRET_KEY As String = "Rmt2G43_-m2tBF@"
    Private Const SALT As String = "ju$F03L/t-@cUa5"

    Private Function CreateKey() As Byte()
        Dim bytSalt As Byte() = Text.Encoding.ASCII.GetBytes(SALT)
        Dim pdb As New Rfc2898DeriveBytes(SECRET_KEY, bytSalt)
        Return pdb.GetBytes(32)
    End Function

    Private Function CreateIV() As Byte()
        Dim bytSalt As Byte() = Text.Encoding.ASCII.GetBytes(SALT)
        Dim pdb As New Rfc2898DeriveBytes(SECRET_KEY, bytSalt)
        Return pdb.GetBytes(16)
    End Function

    Public Sub EncryptFile(strInputFile As String, strOutputFile As String)
        EncryptOrDecrptFile(strInputFile, strOutputFile, True)
    End Sub

    Public Sub DecrptFile(strInputFile As String, strOutputFile As String)
        EncryptOrDecrptFile(strInputFile, strOutputFile, False)
    End Sub

    Private Sub EncryptOrDecrptFile(strInputFile As String, strOutputFile As String, encript As Boolean)
        Try
            Dim fsInput As New FileStream(strInputFile, FileMode.Open, FileAccess.Read)
            Dim fsOutput As New FileStream(strOutputFile, FileMode.OpenOrCreate, FileAccess.Write)

            Dim bytBuffer(4096) As Byte
            Dim lngBytesProcessed As Long = 0
            Dim lngFileLength As Long = fsInput.Length
            Dim intBytesInCurrentBlock As Integer
            Dim cspRijndael As New RijndaelManaged
            Dim iCryptoTransform As ICryptoTransform

            fsOutput.SetLength(0)

            If encript Then
                iCryptoTransform = cspRijndael.CreateEncryptor(CreateKey, CreateIV)
            Else
                iCryptoTransform = cspRijndael.CreateDecryptor(CreateKey, CreateIV)
            End If

            Dim csCryptoStream As New CryptoStream(fsOutput, iCryptoTransform, CryptoStreamMode.Write)

            While lngBytesProcessed < lngFileLength
                intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                lngBytesProcessed += intBytesInCurrentBlock
            End While

            csCryptoStream.Close()
            fsInput.Close()
            fsOutput.Close()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            MsgBox(ex.Message & vbCrLf & ex.StackTrace, MsgBoxStyle.Critical, "EncryptOrDecryptFile")
        End Try
    End Sub

End Module

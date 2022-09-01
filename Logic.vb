Imports System.Security.Cryptography

Module Logic

    Sub MSG(message As String, Optional type As Byte = Nothing)
        Dim alertStyle As MsgBoxStyle

        Select Case type
            Case 1
                alertStyle = MsgBoxStyle.Information
            Case 2
                alertStyle = MsgBoxStyle.Critical
            Case Else
                alertStyle = MsgBoxStyle.Exclamation
        End Select

        MsgBox(message, alertStyle)
    End Sub

    Sub DW(text As String)
        Debug.WriteLine(text)
    End Sub

    Function GetUnixTimestamp() As Long
        Return Math.Round((Date.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds)
    End Function

    Function CalculateOTP(secretKey As String) As String
        Dim timestamp As Long = GetUnixTimestamp() / 30
        Dim data As Byte() = BitConverter.GetBytes(timestamp).Reverse.ToArray
        Dim hmac As Byte() = New HMACSHA1(secretKey.ToByteArray).ComputeHash(data)
        Dim offset As Integer = hmac.Last And &HF
        Dim otp As Integer = (
            ((hmac(offset + 0) And &H7F) << 24) Or
            ((hmac(offset + 1) And &HFF) << 16) Or
            ((hmac(offset + 2) And &HFF) << 8) Or
            (hmac(offset + 3) And &HFF)
        ) Mod 1000000

        Return otp.ToString("000000")
    End Function


End Module

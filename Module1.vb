Imports System.Security.Cryptography

Module Module1

    Sub DW(text As String)
        Debug.WriteLine(text)
    End Sub

    Sub Init()

        Dim sk As String = "test"
        sk = sk.ToUpper

        DW(CalculateOTP(sk))
    End Sub

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

    Function GetUnixTimestamp() As Long
        Return Math.Round((DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds)
    End Function

End Module
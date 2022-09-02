Imports System.Security.Cryptography

Public Class NumCodes

    Property Name As String
    Property SecretKey As String
    Property Period As Integer
    Property Active As Integer

    Public Sub New(name As String, secret As String, period As Integer, active As Integer)
        Me.Name = name
        SecretKey = secret
        Me.Period = period
        Me.Active = active
    End Sub

    Public ReadOnly Property OTP As String
        Get
            Return CalculateOTP(AESDecrypt(SecretKey))
        End Get
    End Property

    Private Function CalculateOTP(secretKey As String) As String
        Dim timestamp As Long = GetUnixTimestamp() / 30
        Dim data As Byte() = BitConverter.GetBytes(timestamp).Reverse.ToArray
        Dim hmac As Byte() = New HMACSHA1(secretKey.ToByteArray).ComputeHash(data)
        Dim offset As Integer = hmac.Last And &HF
        Dim otp As Integer = (((hmac(offset + 0) And &H7F) << 24) Or ((hmac(offset + 1) And &HFF) << 16) Or ((hmac(offset + 2) And &HFF) << 8) Or (hmac(offset + 3) And &HFF)) Mod 1000000

        Return otp.ToString("000000")
    End Function

    Public Overrides Function ToString() As String
        Return Name & "*" & SecretKey & "*" & Period & "*" & Active
    End Function

End Class

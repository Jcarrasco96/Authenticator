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

    ' For DEBUGGING
    Sub DW(text As String)
        Debug.WriteLine(text)
    End Sub

    Function GetUnixTimestamp() As Long
        Return Math.Round((Date.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds)
    End Function

    Function RemainingSeconds() As Integer
        Dim secondsNow = GetUnixTimestamp()
        Dim intervals = secondsNow \ 30
        Return 30 - (secondsNow - (intervals * 30))
    End Function

End Module

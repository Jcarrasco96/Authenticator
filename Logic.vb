Module Logic

    Sub MSG(Message As String, Optional Number As Byte = Nothing)
        Dim Notic As New FormNotice

        If Number = 1 Then
            Notic.ForeColor = Color.LimeGreen
        ElseIf Number = 2 Then
            Notic.ForeColor = Color.Red
        End If

        Notic.Notice_lbl.Text = Message
        Notic.ShowDialog()
    End Sub

End Module

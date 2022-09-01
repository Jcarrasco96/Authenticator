Public Class FormManualCode

    Public _Result As String
    ReadOnly Property ResultCaptcha() As String
        Get
            Return _Result
        End Get
    End Property

    Private Sub VisualStudioButton1_Click(sender As Object, e As EventArgs) Handles VisualStudioButton1.Click
        If TextBox1.Text = "" And TextBox2.Text = "" Then
        Else
            Insert(TextBox1.Text, TextBox2.Text)
        End If
    End Sub

    Private Sub Insert(Code As String, Name As String)
        _Result = "<code>" & Code & "</code><name>" & Name & "</name>"
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        Close()
    End Sub

End Class
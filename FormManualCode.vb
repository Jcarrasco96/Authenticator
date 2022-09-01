Public Class FormManualCode

    Public _Result As String
    ReadOnly Property ResultCaptcha() As String
        Get
            Return _Result
        End Get
    End Property

    Private Sub Insert(Name As String, Code As String)
        _Result = "<code>" & Code & "</code><name>" & Name & "</name>"
        txtName.Text = Nothing
        txtCode.Text = Nothing
        Dispose()
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        If txtName.Text = "" And txtCode.Text = "" Then
        Else
            Insert(txtName.Text, txtCode.Text)
        End If
    End Sub

    Private Sub MysticClose1_Click(sender As Object, e As EventArgs) Handles MysticClose1.Click
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        _Result = ""
        Dispose()
    End Sub

End Class
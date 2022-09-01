Public Class FormRenameCode

    Public Property Names As String

    Private Sub MysticClose1_Click(sender As Object, e As EventArgs) Handles MysticClose1.Click
        Close()
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        If txtName.Text = "" Then
            MSG("Introduzca un nombre valido")
            Return
        End If

        If txtName.Text = Names Then
            Me.Close()
            Return
        End If

        If CheckName(txtName.Text) Then
            MSG("Este nombre esta en uso, escoge otro")
        Else
            UpdateName(Names, txtName.Text)
            LoadCode()
            Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Public Sub SetName()
        txtName.Text = Names
    End Sub

End Class
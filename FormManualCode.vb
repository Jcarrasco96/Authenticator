Public Class FormManualCode

    Private Sub MysticClose1_Click(sender As Object, e As EventArgs) Handles MysticClose1.Click
        Dispose()
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim name As String = txtName.Text

        If name = "" Then
            MSG("Nombre no puede estar vacio", 2)
            Return
        End If

        If txtCode.Text = "" Then
            MSG("Codigo no puede estar vacio", 2)
            Return
        End If

        Dim I As Integer = 1
        Dim Rep As String = name

        While CheckName(name)
            name = Rep + " (" & I & ")"
            I += 1
        End While

        If Not InsertCode(name, txtCode.Text) Then
            MSG("Unable to insert into database, check database integrity.", 2)
        End If

        DialogResult = DialogResult.OK
        Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Dispose()
    End Sub

End Class
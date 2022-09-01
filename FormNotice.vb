Public Class FormNotice

    Dim LOCAT As Point

    Sub VisualStudioButton1_Click(sender As Object, e As EventArgs) Handles VisualStudioButton1.Click
        Close()
    End Sub

    Private Sub form_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            LOCAT = e.Location
        End If
    End Sub

    Private Sub form_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Location += e.Location - LOCAT
        End If
    End Sub

    Private Sub Notice_lbl_MouseDown(sender As Object, e As MouseEventArgs) Handles Notice_lbl.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            LOCAT = e.Location
        End If
    End Sub

    Private Sub Notice_lbl_MouseMove(sender As Object, e As MouseEventArgs) Handles Notice_lbl.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Location += e.Location - LOCAT
        End If
    End Sub
    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            LOCAT = e.Location
        End If
    End Sub

    Private Sub v_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Location += e.Location - LOCAT
        End If
    End Sub

End Class
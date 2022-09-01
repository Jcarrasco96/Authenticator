Imports System.Text.RegularExpressions

Public Class FormMain

    ReadOnly ProgressMaxValue As Integer = 30
    Public ContainerControlQuant As Integer = 0
    Dim CountAdd As Integer = 0
    ReadOnly TIM As String = Date.Now.Second

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If CreateDB() Then

        'Else
        '    MSG("Database create error, correct them!", 2)
        '    End
        'End If

        If Not LoadCode() Then
            MSG("Database error, correct them!", 2)
        End If

        progressTime.Value = ProgressMaxValue
        progressTime.Maximum = ProgressMaxValue

        If TIM < ProgressMaxValue Then
            Dim CONT As Integer = ProgressMaxValue - TIM
            progressTime.Value = CONT
            Timer_Count.Start()
        ElseIf TIM > ProgressMaxValue Then
            Dim CONT As Integer = (TIM - ProgressMaxValue)
            progressTime.Value = ProgressMaxValue - CONT
            Timer_Count.Start()
        End If

        If Panel1.Controls.Count = 0 Then
            Timer_Count.Stop()
            progressTime.Value = ProgressMaxValue
        End If
    End Sub

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub Add_BTN_Click(sender As Object, e As EventArgs) Handles Add_BTN.Click
        If Application.OpenForms.OfType(Of FormManualCode)().Count() > 0 Then
            FormManualCode.WindowState = FormWindowState.Normal
        Else
            FormManualCode.ShowDialog()

            Show()

            If FormManualCode.ResultCaptcha <> "" Then
                Dim Nom As New Regex("(?<=<name>).+(?=</name>)")
                Dim Nome As String = Nom.Match(FormManualCode.ResultCaptcha).Value

                Dim Cod As New Regex("(?<=<code>).+(?=</code>)")
                Dim Codigo As String = Cod.Match(FormManualCode.ResultCaptcha).Value

                If Nome = "" Then
                    MSG("Null Name!", 2)
                    FormManualCode._Result = Nothing
                    Return
                End If

                If Codigo = "" Then
                    MSG("Null Code!", 2)
                    FormManualCode._Result = Nothing
                    Return
                End If

                Dim I As Integer = 1
                Dim Rep As String = Nome

                While CheckName(Nome)
                    Nome = Rep + " (" & I & ")"
                    I += 1
                End While

                If InsertCode(Nome, Codigo) Then
                    FormManualCode._Result = Nothing
                Else
                    MSG("Unable to insert into database, check database integrity.", 2)
                End If

                LoadCode()
            Else

            End If
        End If
    End Sub

    Private Sub Timer_Count_Tick(sender As Object, e As EventArgs) Handles Timer_Count.Tick
        If progressTime.Value = 0 Then
            progressTime.Value = ProgressMaxValue
            Panel1.Controls.Clear()
            LoadCode()
        Else
            progressTime.Value -= 1
        End If
    End Sub

    Private Sub Timer_Copied_Tick(sender As Object, e As EventArgs) Handles Timer_Copied.Tick
        Copied_lbl.Visible = False
        Timer_Copied.Stop()
    End Sub

    Public Sub Add(Name As String, CODIGO As String)
        Dim newPanel As New Test With {
            .Dock = DockStyle.Top
        }

        newPanel.lblName.Text = Name
        newPanel.lblName.Name = "_Name" & CountAdd

        newPanel.lblCode.Text = CODIGO
        newPanel.lblCode.Name = "_Code" & CountAdd

        AddHandler newPanel.lblCode.Click, AddressOf CodeCopied
        AddHandler newPanel.picEdit.Click, AddressOf EditName
        AddHandler newPanel.picQR.Click, AddressOf QRCode
        AddHandler newPanel.picDelete.Click, Sub(sender, e) DeleteItem(CODIGO)

        'newPanel.picQR.Image = Imagem.Image

        Panel1.Controls.Add(newPanel)

        Panel1.Select()

        Timer_Count.Start()
        CountAdd += 1
    End Sub

    Private Sub EditName(sender As Object, e As EventArgs)
        Dim selectedBtn As PictureBox = sender

        'If Application.OpenForms.OfType(Of Rename)().Count() > 0 Then
        '    Informe_Code.WindowState = FormWindowState.Normal
        'Else
        '    Dim Renam As New Rename
        '    Renam.Names = selectedBtn.Name
        '    Renam.Senha = Senha
        '    Renam.Show()
        'End If
    End Sub

    Private Sub QRCode(sender As Object, e As EventArgs)
        Dim selectedBtn As PictureBox = sender
        'Dim wc As WebClient = New WebClient()
        'Dim ms As MemoryStream = New MemoryStream(wc.DownloadData(SetupCode.QrCodeSetupImageUrl))
        'selectedBtn.Image = Image.FromStream(ms)
    End Sub

    Private Sub CodeCopied(sender As Object, e As EventArgs)
        Dim selectedBtn As Label = sender
        Clipboard.SetText(selectedBtn.Text)
        Copied_lbl.Visible = True
        Timer_Copied.Start()
    End Sub

    Private Sub DeleteItem(code As String)
        MSG(code)
    End Sub

    Private Sub Configuracao_BTN_Click(sender As Object, e As EventArgs) Handles Configuracao_BTN.Click
        Init()

    End Sub

End Class

﻿Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions

Public Class FormMain

    ReadOnly Period As Integer = 30

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        CreateDB()

        If Not LoadCode() Then
            MSG("Database error, correct them!", 2)
        End If

        LoadCounter()
    End Sub

    Private Sub Timer_Count_Tick(sender As Object, e As EventArgs) Handles timerCount.Tick
        progressTime.Value -= 1

        If progressTime.Value = 0 Then
            progressTime.Value = Period
            panelCodes.Controls.Clear()
            LoadCode()
        End If
    End Sub

    Private Sub Timer_Copied_Tick(sender As Object, e As EventArgs) Handles timerCopied.Tick
        lblCopied.Visible = False
        timerCopied.Stop()
    End Sub

    Public Sub Add(Name As String, CODIGO As String)
        Dim newPanel As New LayoutCode With {
            .Dock = DockStyle.Top
        }

        newPanel.lblName.Text = Name
        newPanel.lblCode.Text = CODIGO

        AddHandler newPanel.lblCode.Click, Sub(sender, e) CodeCopied(CODIGO)
        AddHandler newPanel.btnEdit.Click, Sub(sender, e) EditName(Name)
        'AddHandler newPanel.btnQr.Click, Sub(sender, e) QRCode(Name, CODIGO)
        AddHandler newPanel.btnDelete.Click, Sub(sender, e) Delete(Name)

        panelCodes.Controls.Add(newPanel)
        panelCodes.Select()

        timerCount.Start()
    End Sub

    Private Sub EditName(name As String)
        If Application.OpenForms.OfType(Of FormRenameCode)().Count() > 0 Then
            FormRenameCode.WindowState = FormWindowState.Normal
        Else
            Dim Renam As New FormRenameCode With {
                .Names = name
            }
            Renam.SetName()
            Renam.Show()
        End If
    End Sub

    Private Sub QRCode(name As String, code As String)
        Dim uri = "otpauth://totp/" & name & "?secret=" & code
        Dim url = "https://chart.googleapis.com/chart?chs=300x300&chld=M|0&cht=qr&chl=" & uri

        Try
            Dim wc As New WebClient()
            Dim ms As New MemoryStream(wc.DownloadData(url))

            btnAdd.BackgroundImage = Image.FromStream(ms)
        Catch ex As Exception
            DW(ex.ToString)
        End Try
    End Sub

    Private Sub CodeCopied(code As String)
        Clipboard.SetText(code)
        lblCopied.Visible = True
        timerCopied.Start()
    End Sub

    Private Sub Delete(name As String)
        Dim result = MsgBox("Esta seguro que desea eliminar el factor de autentificacion """ & name & """?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

        If result = MsgBoxResult.Yes Then
            If CheckName(name) Then
                If DeleteItem(name) Then
                    LoadCode()
                    LoadCounter()
                Else
                    MSG("No se pudo eliminar.", 2)
                End If
            Else
                MSG("Este factor de autentificacion no existe.", 2)
            End If
        End If
    End Sub

    Private Sub MysticClose1_Click(sender As Object, e As EventArgs) Handles MysticClose1.Click
        Dispose()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
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
                    MSG("Nombre no puede estar vacio", 2)
                    FormManualCode._Result = Nothing
                    Return
                End If

                If Codigo = "" Then
                    MSG("Codigo no puede estar vacio", 2)
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
                LoadCounter()
            End If
        End If
    End Sub

    Private Sub LoadCounter()
        progressTime.Maximum = Period
        progressTime.Value = RemainingSeconds()

        timerCount.Start()

        If panelCodes.Controls.Count = 0 Then
            timerCount.Stop()
            progressTime.Value = Period
        End If
    End Sub

    Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        MSG("Desarrollado por Jesus Carrasco", 1)
    End Sub

End Class

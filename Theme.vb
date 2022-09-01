Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Text

Enum MouseStateMe
    None = 0
    Over = 1
    Down = 2
End Enum

Class MysticTheme : Inherits ContainerControl

#Region " Declarations "
    Private _Down As Boolean = False
    Private ReadOnly _Header As Integer = 36
    Private _Point As Point
    Public Property Movible As Boolean = False
#End Region

#Region " Mouse States "
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If Movible Then _Down = False
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Movible Then
            If e.Y < _Header AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
                _Point = e.Location
                _Down = True
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Movible Then
            If _Down = True Then
                ParentForm.Location = MousePosition - _Point
            End If
        End If
    End Sub
#End Region

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        ParentForm.FormBorderStyle = FormBorderStyle.None
        ParentForm.TransparencyKey = Color.Fuchsia
        Dock = DockStyle.Fill
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(44, 51, 62))
        G.FillRectangle(New SolidBrush(Color.FromArgb(29, 36, 44)), New Rectangle(0, 0, Width, _Header))

        G.FillRectangle(Brushes.Fuchsia, New Rectangle(0, 0, 1, 1))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(1, 0, 1, 1))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(0, 1, 1, 1))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(Width - 1, 0, 1, 1))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(Width - 1, 1, 1, 1))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(Width - 2, 0, 1, 1))

        Dim _StringF As New StringFormat With {
            .Alignment = StringAlignment.Near,
            .LineAlignment = StringAlignment.Center
        }
        G.DrawString(Text, New Font("Segoe UI", 12), New SolidBrush(Color.FromArgb(33, 189, 255)), New RectangleF(5, 0, Width, _Header), _StringF)
    End Sub

End Class

Class MysticButton : Inherits MyControl

    Sub New()
        Size = New Size(85, 85)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(66, 219, 183))
        G.FillRectangle(New SolidBrush(Color.FromArgb(8, 161, 248)), New Rectangle(0, 0, Width, Height))

        Select Case _State
            Case MouseStateMe.Over
                G.FillRectangle(New SolidBrush(Color.FromArgb(40, Color.White)), New Rectangle(0, 0, Width, Height))
            Case MouseStateMe.Down
                G.FillRectangle(New SolidBrush(Color.FromArgb(80, Color.Black)), New Rectangle(0, 0, Width, Height))
        End Select

        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(0, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(1, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(0, 1, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(Width - 1, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(Width - 1, 1, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(Width - 2, 0, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(0, Height - 1, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(1, Height - 1, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(0, Height - 2, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(Width - 1, Height - 1, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(Width - 1, Height - 2, 1, 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 51, 62)), New Rectangle(Width - 2, Height - 1, 1, 1))

        If Text = vbNullString Then
            G.DrawImage(BackgroundImage, New Rectangle(5, 5, Width - 10, Height - 10))
        Else
            Dim _StringF As New StringFormat With {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
            }
            G.DrawString(Text, Me.Font, Brushes.White, New RectangleF(0, 0, Width - 1, Height - 1), _StringF)
        End If
    End Sub

End Class

<DefaultEvent("CheckedChanged")>
Class MysticRadioButton : Inherits MyControl

#Region " Variables "
    Private _Checked As Boolean
#End Region

#Region " Properties "
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property
    Event CheckedChanged(sender As Object)
    Protected Overrides Sub OnClick(e As EventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnClick(e)
    End Sub
    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return
        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is MysticRadioButton Then
                DirectCast(C, MysticRadioButton).Checked = False
                Invalidate()
            End If
        Next
    End Sub
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        InvalidateControls()
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 16
    End Sub
#End Region

#Region " Mouse States "
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _State = MouseStateMe.Down
        If Not _Checked Then Checked = True
        Invalidate()
    End Sub
#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.SmoothingMode = 2
        G.TextRenderingHint = 5
        G.Clear(Color.FromArgb(44, 51, 62))
        G.FillEllipse(New SolidBrush(Color.FromArgb(36, 39, 46)), New Rectangle(0, 0, 15, 15))
        G.DrawEllipse(New Pen(Color.FromArgb(26, 29, 33)), New Rectangle(0, 0, 15, 15))
        If Checked Then
            G.FillEllipse(New LinearGradientBrush(New Point(3, 3), New Point(3, 12), Color.FromArgb(123, 255, 201), Color.FromArgb(41, 131, 113)), New Rectangle(3, 3, 9, 9))
            G.FillEllipse(New LinearGradientBrush(New Point(4, 4), New Point(4, 11), Color.FromArgb(9, 204, 157), Color.FromArgb(41, 131, 113)), New Rectangle(4, 4, 7, 7))
            G.DrawString(Text, New Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, New Point(18, -1))
        Else
            Select Case _State
                Case MouseStateMe.None
                    G.DrawString(Text, New Font("Segoe UI", 9, FontStyle.Bold), New SolidBrush(Color.FromArgb(121, 131, 141)), New Point(18, -1))
                Case MouseStateMe.Over
                    G.DrawEllipse(New Pen(Color.FromArgb(0, 205, 155), 2), New Rectangle(1, 1, 13, 13))
                    G.DrawString(Text, New Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, New Point(18, -1))
                Case MouseStateMe.Down
                    G.DrawString(Text, New Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, New Point(18, -1))
            End Select
        End If
    End Sub
End Class

<DefaultEvent("CheckedChanged")>
Class MysticCheckBox : Inherits MyControl

#Region " Variables "
    Private _Checked As Boolean
#End Region

#Region " Properties "
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property
    Event CheckedChanged(sender As Object)
    Protected Overrides Sub OnClick(e As EventArgs)
        _Checked = Not _Checked
        RaiseEvent CheckedChanged(Me)
        MyBase.OnClick(e)
    End Sub
    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 16
    End Sub
#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(35, 35, 35))
        G.DrawLine(New Pen(Color.FromArgb(26, 29, 33)), New Point(0, 0), New Point(0, 14))
        G.DrawLine(New Pen(Color.FromArgb(26, 29, 33)), New Point(0, 0), New Point(14, 0))

        If Checked Then
            G.FillRectangle(New LinearGradientBrush(New Point(3, 3), New Point(3, 13), Color.FromArgb(33, 189, 255), Color.FromArgb(33, 189, 255)), New Rectangle(3, 3, 9, 9))
            G.FillRectangle(New LinearGradientBrush(New Point(4, 4), New Point(4, 11), Color.FromArgb(33, 189, 255), Color.FromArgb(21, 30, 73)), New Rectangle(4, 4, 7, 7))
            'G.DrawString(Text, New Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, New Point(18, -1))
        End If

        Select Case _State
            Case MouseStateMe.None
                G.DrawString(Text, New Font("Segoe UI", 9, FontStyle.Bold), New SolidBrush(Color.FromArgb(121, 131, 141)), New Point(18, -1))
            Case MouseStateMe.Over
                G.DrawRectangle(New Pen(Color.FromArgb(33, 189, 255), 2), New Rectangle(1, 1, 13, 13))
                G.DrawString(Text, New Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, New Point(18, -1))
            Case MouseStateMe.Down
                G.DrawString(Text, New Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, New Point(18, -1))
        End Select
    End Sub
End Class

<DefaultEvent("TextChanged")>
Class MysticTextBox : Inherits Control

#Region " Variables "
    Private WithEvents TextBox As TextBox
#End Region

#Region " TextBox Properties "
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    <Category("Options")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(value As HorizontalAlignment)
            _TextAlign = value
            If TextBox IsNot Nothing Then
                TextBox.TextAlign = value
            End If
        End Set
    End Property
    Private _MaxLength As Integer = 32767
    <Category("Options")>
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(value As Integer)
            _MaxLength = value
            If TextBox IsNot Nothing Then
                TextBox.MaxLength = value
            End If
        End Set
    End Property
    Private _ReadOnly As Boolean
    <Category("Options")>
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(value As Boolean)
            _ReadOnly = value
            If TextBox IsNot Nothing Then
                TextBox.ReadOnly = value
            End If
        End Set
    End Property
    Private _UseSystemPasswordChar As Boolean
    <Category("Options")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(value As Boolean)
            _UseSystemPasswordChar = value
            If TextBox IsNot Nothing Then
                TextBox.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    Private _Multiline As Boolean
    <Category("Options")>
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(value As Boolean)
            _Multiline = value
            If TextBox IsNot Nothing Then
                TextBox.Multiline = value

                If value Then
                    TextBox.Height = Height - 11
                Else
                    Height = TextBox.Height + 11
                End If
            End If
        End Set
    End Property
    <Category("Options")>
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
            If TextBox IsNot Nothing Then
                TextBox.Text = value
            End If
        End Set
    End Property
    <Category("Options")>
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(value As Font)
            MyBase.Font = value
            If TextBox IsNot Nothing Then
                TextBox.Font = value
                TextBox.Location = New Point(3, 5)
                TextBox.Width = Width - 6

                If Not _Multiline Then
                    Height = TextBox.Height + 11
                End If
            End If
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TextBox) Then
            Controls.Add(TextBox)
        End If
    End Sub
    Private Sub OnBaseTextChanged(s As Object, e As EventArgs)
        Text = TextBox.Text
    End Sub
    Private Sub OnBaseKeyDown(s As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TextBox.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            TextBox.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub
    Protected Overrides Sub OnResize(e As EventArgs)
        TextBox.Location = New Point(5, 5)
        TextBox.Width = Width - 10

        If _Multiline Then
            TextBox.Height = Height - 11
        Else
            Height = TextBox.Height + 11
        End If

        MyBase.OnResize(e)
    End Sub
#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True

        BackColor = Color.Transparent

        TextBox = New TextBox With {
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .Text = Text,
            .BackColor = Color.FromArgb(34, 37, 44),
            .ForeColor = Color.White,
            .MaxLength = _MaxLength,
            .Multiline = _Multiline,
            .ReadOnly = _ReadOnly,
            .UseSystemPasswordChar = _UseSystemPasswordChar,
            .BorderStyle = BorderStyle.None,
            .Location = New Point(5, 5),
            .Width = Width - 10,
            .Cursor = Cursors.IBeam
        }

        If _Multiline Then
            TextBox.Height = Height - 11
        Else
            Height = TextBox.Height + 11
        End If

        AddHandler TextBox.TextChanged, AddressOf OnBaseTextChanged
        AddHandler TextBox.KeyDown, AddressOf OnBaseKeyDown
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        G.Clear(Color.FromArgb(34, 37, 44))
        G.DrawRectangle(New Pen(Color.FromArgb(33, 189, 255), 2), New Rectangle(1, 1, Width - 2, Height - 2))
    End Sub

End Class

Class MysticClose : Inherits MyControl

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(24, 24)
    End Sub

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(24, 24)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G = e.Graphics
        BackColor = Color.Transparent

        Dim _StringF As New StringFormat With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Center
        }

        G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(8, 161, 248)), 2), 5, 5, Width - 5, Height - 5)
        G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(8, 161, 248)), 2), 5, Height - 5, Width - 5, 5)

        Select Case _State
            Case MouseStateMe.Over
                G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(40, Color.DarkBlue)), 2), 5, 5, Width - 5, Height - 5)
                G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(40, Color.DarkBlue)), 2), 5, Height - 5, Width - 5, 5)
            Case MouseStateMe.Down
                G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(80, Color.DarkBlue)), 2), 5, 5, Width - 5, Height - 5)
                G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(80, Color.DarkBlue)), 2), 5, Height - 5, Width - 5, 5)
        End Select

    End Sub

End Class

Class ProgressB : Inherits ProgressBar

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim G = e.Graphics
        G.SmoothingMode = SmoothingMode.HighQuality
        G.PixelOffsetMode = PixelOffsetMode.HighQuality
        G.Clear(Color.FromArgb(32, 37, 41))
        Dim _Progress As Integer = 0

        Try
            _Progress = CInt(Value / Maximum * Width)
        Catch ex As Exception

        End Try

        G.FillRectangle(New SolidBrush(Color.FromArgb(33, 189, 255)), New Rectangle(0, 0, _Progress - 1, Height))
        G.FillRectangle(New SolidBrush(Color.FromArgb(32, 37, 41)), New Rectangle(_Progress - 1, 0, Width - _Progress, Height))

        G.InterpolationMode = InterpolationMode.HighQualityBicubic
    End Sub

End Class

Public Class ThirteenTabControl : Inherits TabControl

    Private ReadOnly AccentColor As Color = Color.FromArgb(33, 189, 255)
    Private ReadOnly MainColor As Color = Color.FromArgb(35, 35, 35)

    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True

        BackColor = Color.FromArgb(250, 50, 50)
        ForeColor = Color.Black
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        MyBase.OnPaint(e)

        Try : SelectedTab.BackColor = MainColor : Catch : End Try
        G.Clear(Color.FromArgb(44, 51, 62))

        Dim sf As New StringFormat With {
            .LineAlignment = StringAlignment.Center,
            .Alignment = StringAlignment.Center
        }

        For i As Integer = 0 To TabPages.Count - 1
            If Not i = SelectedIndex Then
                Dim TabRect As New Rectangle(GetTabRect(i).X, GetTabRect(i).Y, GetTabRect(i).Width, GetTabRect(i).Height)
                G.FillRectangle(New SolidBrush(MainColor), TabRect)
                G.DrawString(TabPages(i).Text, New Font("Segoe UI", 9.75F), New SolidBrush(ForeColor), TabRect, sf)
            End If
        Next

        G.FillRectangle(New SolidBrush(MainColor), 0, ItemSize.Height, Width, Height)

        If Not SelectedIndex = -1 Then
            Dim TabRect As New Rectangle(GetTabRect(SelectedIndex).X - 2, GetTabRect(SelectedIndex).Y, GetTabRect(SelectedIndex).Width + 4, GetTabRect(SelectedIndex).Height)
            G.FillRectangle(New SolidBrush(AccentColor), TabRect)
            G.DrawString(TabPages(SelectedIndex).Text, New Font("Segoe UI", 9.75F), New SolidBrush(ForeColor), TabRect, sf)
        End If

        e.Graphics.DrawImage(B, New Point(0, 0))
        G.Dispose() : B.Dispose()
    End Sub
End Class

Public Class ThirteenComboBox : Inherits ComboBox
#Region " Control Help - Properties & Flicker Control "
    Private _AccentColor As Color
    Public Property AccentColor() As Color
        Get
            Return _AccentColor
        End Get
        Set(value As Color)
            _AccentColor = value
            Invalidate()
        End Set
    End Property

    Private _StartIndex As Integer = 0
    Private Property StartIndex As Integer
        Get
            Return _StartIndex
        End Get
        Set(value As Integer)
            _StartIndex = value
            Try
                SelectedIndex = value
            Catch
            End Try
            Invalidate()
        End Set
    End Property
    Sub ReplaceItem(sender As Object, e As DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()
        Try
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(_AccentColor), e.Bounds)
            Else
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), e.Bounds)
            End If
            e.Graphics.DrawString(GetItemText(Items(e.Index)), e.Font, Brushes.White, e.Bounds)
        Catch
        End Try
    End Sub
    Protected Sub DrawTriangle(Clr As Color, FirstPoint As Point, SecondPoint As Point, ThirdPoint As Point, G As Graphics)
        Dim points As New List(Of Point) From {
            FirstPoint,
            SecondPoint,
            ThirdPoint
        }
        G.FillPolygon(New SolidBrush(Clr), points.ToArray())
    End Sub

#End Region

    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        DrawMode = DrawMode.OwnerDrawFixed
        BackColor = Color.FromArgb(50, 50, 50)
        ForeColor = Color.White
        AccentColor = Color.DodgerBlue
        DropDownStyle = ComboBoxStyle.DropDownList
        Font = New Font("Segoe UI Semilight", 9.75F)
        StartIndex = 0
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)

        G.SmoothingMode = SmoothingMode.HighQuality

        G.Clear(Color.FromArgb(50, 50, 50))
        G.DrawLine(New Pen(Color.White, 2), New Point(Width - 18, 10), New Point(Width - 14, 14))
        G.DrawLine(New Pen(Color.White, 2), New Point(Width - 14, 14), New Point(Width - 10, 10))
        G.DrawLine(New Pen(Color.White), New Point(Width - 14, 15), New Point(Width - 14, 14))
        G.DrawRectangle(New Pen(Color.FromArgb(100, 100, 100)), New Rectangle(0, 0, Width - 1, Height - 1))

        Try
            G.DrawString(Text, Font, Brushes.White, New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
        Catch
        End Try

        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class

Public Class MyControl : Inherits Control

#Region " Declarations "
    Friend _State As MouseStateMe = MouseStateMe.None
#End Region

#Region " Mouse States "
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        _State = MouseStateMe.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _State = MouseStateMe.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        _State = MouseStateMe.Down
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        _State = MouseStateMe.Over
        Invalidate()
    End Sub
#End Region

End Class


Public Class VisualStudioRadialProgressBar
    Inherits Control

#Region "Declarations"
    Private _BorderColour As Color = Color.FromArgb(28, 28, 28)
    Private _BaseColour As Color = Color.FromArgb(45, 45, 48)
    Private _ProgressColour As Color = Color.FromArgb(62, 62, 66)
    Private _TextColour As Color = Color.FromArgb(153, 153, 153)
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100
    Private _StartingAngle As Integer = 110
    Private _RotationAngle As Integer = 255
    Private ReadOnly _Font As New Font("Segoe UI", 12)
#End Region

#Region "Properties"

    <Category("Control")>
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                    Invalidate()
                Case Else
                    Return _Value
                    Invalidate()
            End Select
        End Get

        Set(V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Invalidate()
        End Set
    End Property

    Public Sub Increment(Amount As Integer)
        Value += Amount
    End Sub

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property TextColour As Color
        Get
            Return _TextColour
        End Get
        Set(value As Color)
            _TextColour = value
            Invalidate()

        End Set
    End Property

    <Category("Colours")>
    Public Property ProgressColour As Color
        Get
            Return _ProgressColour
        End Get
        Set(value As Color)
            _ProgressColour = value
            Invalidate()

        End Set
    End Property

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
            Invalidate()

        End Set
    End Property

    <Category("Control")>
    Public Property StartingAngle As Integer
        Get
            Return _StartingAngle
        End Get
        Set(value As Integer)
            _StartingAngle = value
        End Set
    End Property

    <Category("Control")>
    Public Property RotationAngle As Integer
        Get
            Return _RotationAngle
        End Get
        Set(value As Integer)
            _RotationAngle = value
        End Set
    End Property

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(78, 78)
        BackColor = Color.Transparent
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        With G
            .TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            Select Case _Value
                Case 0
                    .DrawArc(New Pen(New SolidBrush(_BorderColour), 1 + 6), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5)
                    .DrawArc(New Pen(New SolidBrush(_BaseColour), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawString(_Value, _Font, New SolidBrush(_TextColour), New Point(CInt(Width / 2), CInt(Height / 2)), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case _Maximum
                    .DrawArc(New Pen(New SolidBrush(_BorderColour), 1 + 6), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5)
                    .DrawArc(New Pen(New SolidBrush(_BaseColour), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawArc(New Pen(New SolidBrush(_ProgressColour), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawString(_Value, _Font, New SolidBrush(_TextColour), New Point(CInt(Width / 2), CInt(Height / 2)), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case Else
                    .DrawArc(New Pen(New SolidBrush(_BorderColour), 1 + 6), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5)
                    .DrawArc(New Pen(New SolidBrush(_BaseColour), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawArc(New Pen(New SolidBrush(_ProgressColour), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, CInt((_RotationAngle / _Maximum) * _Value))
                    .DrawString(_Value, _Font, New SolidBrush(_TextColour), New Point(CInt(Width / 2), CInt(Height / 2)), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End Select
        End With
        MyBase.OnPaint(e)
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
#End Region

End Class

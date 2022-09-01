<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormManualCode
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormManualCode))
        Me.MysticTheme1 = New Authenticator.MysticTheme()
        Me.btnCancel = New Authenticator.MysticButton()
        Me.btnInsert = New Authenticator.MysticButton()
        Me.MysticClose1 = New Authenticator.MysticClose()
        Me.txtCode = New Authenticator.MysticTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New Authenticator.MysticTextBox()
        Me.MysticTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MysticTheme1
        '
        Me.MysticTheme1.Controls.Add(Me.btnCancel)
        Me.MysticTheme1.Controls.Add(Me.btnInsert)
        Me.MysticTheme1.Controls.Add(Me.MysticClose1)
        Me.MysticTheme1.Controls.Add(Me.txtCode)
        Me.MysticTheme1.Controls.Add(Me.Label2)
        Me.MysticTheme1.Controls.Add(Me.Label3)
        Me.MysticTheme1.Controls.Add(Me.txtName)
        Me.MysticTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MysticTheme1.Location = New System.Drawing.Point(0, 0)
        Me.MysticTheme1.Movible = True
        Me.MysticTheme1.Name = "MysticTheme1"
        Me.MysticTheme1.Size = New System.Drawing.Size(350, 220)
        Me.MysticTheme1.TabIndex = 6
        Me.MysticTheme1.Text = "Insertar nuevo codigo"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(162, 175)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 33)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancelar"
        '
        'btnInsert
        '
        Me.btnInsert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsert.Location = New System.Drawing.Point(253, 175)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(85, 33)
        Me.btnInsert.TabIndex = 10
        Me.btnInsert.Text = "Insertar"
        '
        'MysticClose1
        '
        Me.MysticClose1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MysticClose1.BackColor = System.Drawing.Color.Transparent
        Me.MysticClose1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MysticClose1.Location = New System.Drawing.Point(320, 6)
        Me.MysticClose1.Margin = New System.Windows.Forms.Padding(6)
        Me.MysticClose1.Name = "MysticClose1"
        Me.MysticClose1.Size = New System.Drawing.Size(24, 24)
        Me.MysticClose1.TabIndex = 9
        Me.MysticClose1.Text = "MysticClose1"
        '
        'txtCode
        '
        Me.txtCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCode.BackColor = System.Drawing.Color.Transparent
        Me.txtCode.Location = New System.Drawing.Point(12, 117)
        Me.txtCode.MaxLength = 32767
        Me.txtCode.Multiline = False
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = False
        Me.txtCode.Size = New System.Drawing.Size(326, 27)
        Me.txtCode.TabIndex = 8
        Me.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCode.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Codigo privado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Nombre"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.BackColor = System.Drawing.Color.Transparent
        Me.txtName.Location = New System.Drawing.Point(12, 61)
        Me.txtName.MaxLength = 32767
        Me.txtName.Multiline = False
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = False
        Me.txtName.Size = New System.Drawing.Size(326, 27)
        Me.txtName.TabIndex = 5
        Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtName.UseSystemPasswordChar = False
        '
        'FormManualCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 220)
        Me.Controls.Add(Me.MysticTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormManualCode"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manual Private Code."
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.MysticTheme1.ResumeLayout(False)
        Me.MysticTheme1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MysticTheme1 As MysticTheme
    Friend WithEvents txtName As MysticTextBox
    Friend WithEvents txtCode As MysticTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents MysticClose1 As MysticClose
    Friend WithEvents btnCancel As MysticButton
    Friend WithEvents btnInsert As MysticButton
End Class

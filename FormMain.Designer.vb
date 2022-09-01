<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.progressTime = New Authenticator.VisualStudioRadialProgressBar()
        Me.timerCopied = New System.Windows.Forms.Timer(Me.components)
        Me.timerCount = New System.Windows.Forms.Timer(Me.components)
        Me.MysticTheme1 = New Authenticator.MysticTheme()
        Me.btnAdd = New Authenticator.MysticButton()
        Me.btnInfo = New Authenticator.MysticButton()
        Me.btnSave = New Authenticator.MysticButton()
        Me.btnRestore = New Authenticator.MysticButton()
        Me.panelCodes = New System.Windows.Forms.Panel()
        Me.lblCopied = New System.Windows.Forms.Label()
        Me.btnSettings = New Authenticator.MysticButton()
        Me.MysticClose1 = New Authenticator.MysticClose()
        Me.MysticTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'progressTime
        '
        Me.progressTime.BackColor = System.Drawing.Color.Transparent
        Me.progressTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.progressTime.BaseColour = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.progressTime.BorderColour = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.progressTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.progressTime.Location = New System.Drawing.Point(236, 83)
        Me.progressTime.Maximum = 30
        Me.progressTime.Name = "progressTime"
        Me.progressTime.ProgressColour = System.Drawing.Color.Turquoise
        Me.progressTime.RotationAngle = 360
        Me.progressTime.Size = New System.Drawing.Size(32, 32)
        Me.progressTime.StartingAngle = 360
        Me.progressTime.TabIndex = 19
        Me.progressTime.Text = "ProgressBar1"
        Me.progressTime.TextColour = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.tt.SetToolTip(Me.progressTime, "Time to restart the code")
        Me.progressTime.Value = 30
        '
        'timerCopied
        '
        Me.timerCopied.Interval = 3000
        '
        'timerCount
        '
        Me.timerCount.Interval = 1000
        '
        'MysticTheme1
        '
        Me.MysticTheme1.Controls.Add(Me.btnAdd)
        Me.MysticTheme1.Controls.Add(Me.btnInfo)
        Me.MysticTheme1.Controls.Add(Me.btnSave)
        Me.MysticTheme1.Controls.Add(Me.btnRestore)
        Me.MysticTheme1.Controls.Add(Me.panelCodes)
        Me.MysticTheme1.Controls.Add(Me.lblCopied)
        Me.MysticTheme1.Controls.Add(Me.btnSettings)
        Me.MysticTheme1.Controls.Add(Me.progressTime)
        Me.MysticTheme1.Controls.Add(Me.MysticClose1)
        Me.MysticTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MysticTheme1.Location = New System.Drawing.Point(0, 0)
        Me.MysticTheme1.Movible = True
        Me.MysticTheme1.Name = "MysticTheme1"
        Me.MysticTheme1.Size = New System.Drawing.Size(280, 650)
        Me.MysticTheme1.TabIndex = 1
        Me.MysticTheme1.Text = "Authenticator"
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = Global.Authenticator.My.Resources.Resources.add
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.Location = New System.Drawing.Point(12, 45)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(32, 32)
        Me.btnAdd.TabIndex = 17
        '
        'btnInfo
        '
        Me.btnInfo.BackgroundImage = Global.Authenticator.My.Resources.Resources.info
        Me.btnInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInfo.Location = New System.Drawing.Point(236, 45)
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.Size = New System.Drawing.Size(32, 32)
        Me.btnInfo.TabIndex = 25
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.Authenticator.My.Resources.Resources.save
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Location = New System.Drawing.Point(160, 45)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(32, 32)
        Me.btnSave.TabIndex = 24
        '
        'btnRestore
        '
        Me.btnRestore.BackgroundImage = Global.Authenticator.My.Resources.Resources.restore
        Me.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRestore.Location = New System.Drawing.Point(198, 45)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(32, 32)
        Me.btnRestore.TabIndex = 23
        '
        'panelCodes
        '
        Me.panelCodes.AllowDrop = True
        Me.panelCodes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelCodes.AutoScroll = True
        Me.panelCodes.BackColor = System.Drawing.Color.Transparent
        Me.panelCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelCodes.Location = New System.Drawing.Point(12, 121)
        Me.panelCodes.Name = "panelCodes"
        Me.panelCodes.Size = New System.Drawing.Size(256, 517)
        Me.panelCodes.TabIndex = 0
        '
        'lblCopied
        '
        Me.lblCopied.AutoSize = True
        Me.lblCopied.BackColor = System.Drawing.Color.Transparent
        Me.lblCopied.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCopied.ForeColor = System.Drawing.Color.Chartreuse
        Me.lblCopied.Location = New System.Drawing.Point(12, 96)
        Me.lblCopied.Name = "lblCopied"
        Me.lblCopied.Size = New System.Drawing.Size(56, 19)
        Me.lblCopied.TabIndex = 9
        Me.lblCopied.Text = "Copied!"
        Me.lblCopied.Visible = False
        '
        'btnSettings
        '
        Me.btnSettings.BackgroundImage = Global.Authenticator.My.Resources.Resources.settings
        Me.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettings.Location = New System.Drawing.Point(122, 45)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(32, 32)
        Me.btnSettings.TabIndex = 18
        '
        'MysticClose1
        '
        Me.MysticClose1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MysticClose1.BackColor = System.Drawing.Color.Transparent
        Me.MysticClose1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MysticClose1.Location = New System.Drawing.Point(250, 6)
        Me.MysticClose1.Margin = New System.Windows.Forms.Padding(6)
        Me.MysticClose1.Name = "MysticClose1"
        Me.MysticClose1.Size = New System.Drawing.Size(24, 24)
        Me.MysticClose1.TabIndex = 1
        Me.MysticClose1.Text = "MysticClose1"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 650)
        Me.Controls.Add(Me.MysticTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Authenticator"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.MysticTheme1.ResumeLayout(False)
        Me.MysticTheme1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents progressTime As Authenticator.VisualStudioRadialProgressBar
    Friend WithEvents lblCopied As System.Windows.Forms.Label
    Friend WithEvents panelCodes As System.Windows.Forms.Panel
    Friend WithEvents timerCopied As System.Windows.Forms.Timer
    Friend WithEvents timerCount As System.Windows.Forms.Timer
    Friend WithEvents MysticTheme1 As MysticTheme
    Friend WithEvents MysticClose1 As MysticClose
    Friend WithEvents btnAdd As MysticButton
    Friend WithEvents btnSave As MysticButton
    Friend WithEvents btnRestore As MysticButton
    Friend WithEvents btnSettings As MysticButton
    Friend WithEvents btnInfo As MysticButton
End Class

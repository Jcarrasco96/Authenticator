<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Test
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Test))
        Me.picEdit = New System.Windows.Forms.PictureBox()
        Me.picQR = New System.Windows.Forms.PictureBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picDelete = New System.Windows.Forms.PictureBox()
        CType(Me.picEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picQR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picEdit
        '
        resources.ApplyResources(Me.picEdit, "picEdit")
        Me.picEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picEdit.Image = Global.Authenticator.My.Resources.Resources.Edit_32x32
        Me.picEdit.Name = "picEdit"
        Me.picEdit.TabStop = False
        '
        'picQR
        '
        resources.ApplyResources(Me.picQR, "picQR")
        Me.picQR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picQR.Image = Global.Authenticator.My.Resources.Resources.QRCODE_48x48
        Me.picQR.Name = "picQR"
        Me.picQR.TabStop = False
        '
        'lblCode
        '
        resources.ApplyResources(Me.lblCode, "lblCode")
        Me.lblCode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCode.ForeColor = System.Drawing.Color.White
        Me.lblCode.Name = "lblCode"
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.ForeColor = System.Drawing.Color.Turquoise
        Me.lblName.Name = "lblName"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'picDelete
        '
        resources.ApplyResources(Me.picDelete, "picDelete")
        Me.picDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picDelete.Image = Global.Authenticator.My.Resources.Resources.Exclude_32x32
        Me.picDelete.Name = "picDelete"
        Me.picDelete.TabStop = False
        '
        'Test
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Controls.Add(Me.picDelete)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.picQR)
        Me.Controls.Add(Me.picEdit)
        Me.Name = "Test"
        CType(Me.picEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picQR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picQR As System.Windows.Forms.PictureBox
    Friend WithEvents picEdit As System.Windows.Forms.PictureBox
    Friend WithEvents lblCode As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents picDelete As PictureBox
End Class

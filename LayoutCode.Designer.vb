<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LayoutCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LayoutCode))
        Me.lblCode = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDelete = New Authenticator.MysticButton()
        Me.btnQr = New Authenticator.MysticButton()
        Me.btnEdit = New Authenticator.MysticButton()
        Me.SuspendLayout()
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
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.BackgroundImage = Global.Authenticator.My.Resources.Resources.Exclude_32x32
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Name = "btnDelete"
        '
        'btnQr
        '
        resources.ApplyResources(Me.btnQr, "btnQr")
        Me.btnQr.BackgroundImage = Global.Authenticator.My.Resources.Resources.QRCODE_48x48
        Me.btnQr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQr.Name = "btnQr"
        '
        'btnEdit
        '
        resources.ApplyResources(Me.btnEdit, "btnEdit")
        Me.btnEdit.BackgroundImage = Global.Authenticator.My.Resources.Resources.Edit_32x32
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.Name = "btnEdit"
        '
        'LayoutCode
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnQr)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "LayoutCode"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCode As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDelete As MysticButton
    Friend WithEvents btnQr As MysticButton
    Friend WithEvents btnEdit As MysticButton
End Class

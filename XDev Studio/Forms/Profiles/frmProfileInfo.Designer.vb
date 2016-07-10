<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProfileInfo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProfileInfo))
        Me.pbProfilePicture = New System.Windows.Forms.PictureBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblFolderLocation = New System.Windows.Forms.LinkLabel()
        Me.btnClose = New MetroFramework.Controls.MetroButton()
        Me.btnSwitchUser = New MetroFramework.Controls.MetroButton()
        Me.btnLogout = New MetroFramework.Controls.MetroButton()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.pbProfilePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbProfilePicture
        '
        Me.pbProfilePicture.BackgroundImage = CType(resources.GetObject("pbProfilePicture.BackgroundImage"), System.Drawing.Image)
        Me.pbProfilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbProfilePicture.Location = New System.Drawing.Point(0, 0)
        Me.pbProfilePicture.Name = "pbProfilePicture"
        Me.pbProfilePicture.Size = New System.Drawing.Size(96, 96)
        Me.pbProfilePicture.TabIndex = 0
        Me.pbProfilePicture.TabStop = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(102, 4)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(55, 20)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name"
        '
        'lblFolderLocation
        '
        Me.lblFolderLocation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFolderLocation.Location = New System.Drawing.Point(0, 0)
        Me.lblFolderLocation.Name = "lblFolderLocation"
        Me.lblFolderLocation.Size = New System.Drawing.Size(284, 33)
        Me.lblFolderLocation.TabIndex = 2
        Me.lblFolderLocation.TabStop = True
        Me.lblFolderLocation.Text = "Folder Location"
        '
        'btnClose
        '
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnClose.Location = New System.Drawing.Point(0, 209)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(284, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseSelectable = True
        '
        'btnSwitchUser
        '
        Me.btnSwitchUser.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSwitchUser.Location = New System.Drawing.Point(0, 140)
        Me.btnSwitchUser.Name = "btnSwitchUser"
        Me.btnSwitchUser.Size = New System.Drawing.Size(284, 23)
        Me.btnSwitchUser.TabIndex = 4
        Me.btnSwitchUser.Text = "Switch User"
        Me.btnSwitchUser.UseSelectable = True
        '
        'btnLogout
        '
        Me.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnLogout.Location = New System.Drawing.Point(0, 186)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(284, 23)
        Me.btnLogout.TabIndex = 6
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseSelectable = True
        '
        'MetroButton1
        '
        Me.MetroButton1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroButton1.Location = New System.Drawing.Point(0, 163)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(284, 23)
        Me.MetroButton1.TabIndex = 7
        Me.MetroButton1.Text = "Delete Profile"
        Me.MetroButton1.UseSelectable = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblFolderLocation)
        Me.Panel1.Location = New System.Drawing.Point(0, 99)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 33)
        Me.Panel1.TabIndex = 8
        '
        'frmProfileInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 232)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSwitchUser)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.pbProfilePicture)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProfileInfo"
        CType(Me.pbProfilePicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbProfilePicture As System.Windows.Forms.PictureBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblFolderLocation As System.Windows.Forms.LinkLabel
    Friend WithEvents btnClose As MetroFramework.Controls.MetroButton
    Friend WithEvents btnSwitchUser As MetroFramework.Controls.MetroButton
    Friend WithEvents btnLogout As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class

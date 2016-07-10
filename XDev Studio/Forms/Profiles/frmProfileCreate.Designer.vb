<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProfileCreate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProfileCreate))
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton4 = New MetroFramework.Controls.MetroButton()
        Me.txt_name = New MetroFramework.Controls.MetroTextBox()
        Me.txt_folder = New MetroFramework.Controls.MetroTextBox()
        Me.txt_password = New MetroFramework.Controls.MetroTextBox()
        Me.MetroButton5 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton3 = New MetroFramework.Controls.MetroButton()
        Me.SuspendLayout()
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(204, 90)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton1.TabIndex = 0
        Me.MetroButton1.Text = "Create"
        Me.MetroButton1.UseSelectable = True
        '
        'MetroButton2
        '
        Me.MetroButton2.Location = New System.Drawing.Point(0, 90)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton2.TabIndex = 1
        Me.MetroButton2.Text = "Cancel"
        Me.MetroButton2.UseSelectable = True
        '
        'MetroButton4
        '
        Me.MetroButton4.Location = New System.Drawing.Point(230, 61)
        Me.MetroButton4.Name = "MetroButton4"
        Me.MetroButton4.Size = New System.Drawing.Size(49, 23)
        Me.MetroButton4.TabIndex = 4
        Me.MetroButton4.Text = "Browse"
        Me.MetroButton4.UseSelectable = True
        '
        'txt_name
        '
        Me.txt_name.Lines = New String(-1) {}
        Me.txt_name.Location = New System.Drawing.Point(0, 3)
        Me.txt_name.MaxLength = 32767
        Me.txt_name.Name = "txt_name"
        Me.txt_name.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_name.PromptText = "Name/Username"
        Me.txt_name.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_name.SelectedText = ""
        Me.txt_name.Size = New System.Drawing.Size(198, 23)
        Me.txt_name.TabIndex = 5
        Me.txt_name.UseSelectable = True
        '
        'txt_folder
        '
        Me.txt_folder.Lines = New String(-1) {}
        Me.txt_folder.Location = New System.Drawing.Point(0, 61)
        Me.txt_folder.MaxLength = 32767
        Me.txt_folder.Name = "txt_folder"
        Me.txt_folder.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_folder.PromptText = "Profile Workspace"
        Me.txt_folder.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_folder.SelectedText = ""
        Me.txt_folder.Size = New System.Drawing.Size(198, 23)
        Me.txt_folder.TabIndex = 6
        Me.txt_folder.UseSelectable = True
        '
        'txt_password
        '
        Me.txt_password.Lines = New String(-1) {}
        Me.txt_password.Location = New System.Drawing.Point(0, 32)
        Me.txt_password.MaxLength = 32767
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_password.PromptText = "Password (leave blank for none)"
        Me.txt_password.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_password.SelectedText = ""
        Me.txt_password.Size = New System.Drawing.Size(198, 23)
        Me.txt_password.TabIndex = 7
        Me.txt_password.UseSelectable = True
        '
        'MetroButton5
        '
        Me.MetroButton5.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.MetroButton5.Location = New System.Drawing.Point(204, 61)
        Me.MetroButton5.Name = "MetroButton5"
        Me.MetroButton5.Size = New System.Drawing.Size(22, 23)
        Me.MetroButton5.TabIndex = 8
        Me.MetroButton5.Text = "?"
        Me.MetroButton5.UseSelectable = True
        '
        'MetroButton3
        '
        Me.MetroButton3.Location = New System.Drawing.Point(285, 61)
        Me.MetroButton3.Name = "MetroButton3"
        Me.MetroButton3.Size = New System.Drawing.Size(86, 23)
        Me.MetroButton3.TabIndex = 9
        Me.MetroButton3.Text = "Set to Default"
        Me.MetroButton3.UseSelectable = True
        '
        'frmProfileCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 118)
        Me.Controls.Add(Me.MetroButton3)
        Me.Controls.Add(Me.MetroButton5)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.txt_folder)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.MetroButton4)
        Me.Controls.Add(Me.MetroButton2)
        Me.Controls.Add(Me.MetroButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProfileCreate"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton4 As MetroFramework.Controls.MetroButton
    Friend WithEvents txt_name As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_folder As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_password As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroButton5 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton3 As MetroFramework.Controls.MetroButton
End Class

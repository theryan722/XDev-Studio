<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_AppManager
    Inherits XDockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_AppManager))
        Me.lb_apps = New System.Windows.Forms.ListBox()
        Me.txt_name = New MetroFramework.Controls.MetroTextBox()
        Me.txt_command = New MetroFramework.Controls.MetroTextBox()
        Me.btn_add = New MetroFramework.Controls.MetroButton()
        Me.MetroContextMenu1 = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_remove = New MetroFramework.Controls.MetroButton()
        Me.btn_apply = New MetroFramework.Controls.MetroButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_save = New MetroFramework.Controls.MetroButton()
        Me.txt_arguments = New MetroFramework.Controls.MetroTextBox()
        Me.SuspendLayout()
        '
        'lb_apps
        '
        Me.lb_apps.FormattingEnabled = True
        Me.lb_apps.Location = New System.Drawing.Point(3, 1)
        Me.lb_apps.Name = "lb_apps"
        Me.lb_apps.ScrollAlwaysVisible = True
        Me.lb_apps.Size = New System.Drawing.Size(244, 147)
        Me.lb_apps.TabIndex = 0
        '
        'txt_name
        '
        Me.txt_name.Lines = New String(-1) {}
        Me.txt_name.Location = New System.Drawing.Point(65, 157)
        Me.txt_name.MaxLength = 32767
        Me.txt_name.Name = "txt_name"
        Me.txt_name.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_name.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_name.SelectedText = ""
        Me.txt_name.Size = New System.Drawing.Size(182, 23)
        Me.txt_name.TabIndex = 1
        Me.txt_name.UseSelectable = True
        '
        'txt_command
        '
        Me.txt_command.Lines = New String(-1) {}
        Me.txt_command.Location = New System.Drawing.Point(65, 186)
        Me.txt_command.MaxLength = 32767
        Me.txt_command.Name = "txt_command"
        Me.txt_command.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_command.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_command.SelectedText = ""
        Me.txt_command.Size = New System.Drawing.Size(182, 23)
        Me.txt_command.TabIndex = 2
        Me.txt_command.UseSelectable = True
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(253, 1)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 23)
        Me.btn_add.TabIndex = 6
        Me.btn_add.Text = "Add"
        Me.btn_add.UseSelectable = True
        '
        'MetroContextMenu1
        '
        Me.MetroContextMenu1.Name = "MetroContextMenu1"
        Me.MetroContextMenu1.Size = New System.Drawing.Size(61, 4)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Command:"
        '
        'btn_remove
        '
        Me.btn_remove.Location = New System.Drawing.Point(253, 30)
        Me.btn_remove.Name = "btn_remove"
        Me.btn_remove.Size = New System.Drawing.Size(75, 23)
        Me.btn_remove.TabIndex = 7
        Me.btn_remove.Text = "Remove"
        Me.btn_remove.UseSelectable = True
        '
        'btn_apply
        '
        Me.btn_apply.Location = New System.Drawing.Point(149, 242)
        Me.btn_apply.Name = "btn_apply"
        Me.btn_apply.Size = New System.Drawing.Size(98, 23)
        Me.btn_apply.TabIndex = 4
        Me.btn_apply.Text = "Apply"
        Me.btn_apply.UseSelectable = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-1, 215)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Arguments:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(253, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Argument Variables:"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(253, 116)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(176, 93)
        Me.TextBox1.TabIndex = 15
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(253, 215)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 26)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Note: Arguments with spaces " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "should be enclosed with quotes."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(2, 268)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(321, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "XDev Studio has to be restarted in order for changes to take effect."
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(3, 242)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 23)
        Me.btn_save.TabIndex = 5
        Me.btn_save.Text = "Save"
        Me.btn_save.UseSelectable = True
        '
        'txt_arguments
        '
        Me.txt_arguments.Lines = New String(-1) {}
        Me.txt_arguments.Location = New System.Drawing.Point(65, 213)
        Me.txt_arguments.MaxLength = 32767
        Me.txt_arguments.Name = "txt_arguments"
        Me.txt_arguments.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_arguments.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_arguments.SelectedText = ""
        Me.txt_arguments.Size = New System.Drawing.Size(182, 23)
        Me.txt_arguments.TabIndex = 3
        Me.txt_arguments.UseSelectable = True
        '
        'Tab_AppManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 282)
        Me.Controls.Add(Me.txt_arguments)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_apply)
        Me.Controls.Add(Me.btn_remove)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.txt_command)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.lb_apps)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_AppManager"
        Me.Text = "App Manager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_apps As System.Windows.Forms.ListBox
    Friend WithEvents txt_name As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_command As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btn_add As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroContextMenu1 As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_remove As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_apply As MetroFramework.Controls.MetroButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_save As MetroFramework.Controls.MetroButton
    Friend WithEvents txt_arguments As MetroFramework.Controls.MetroTextBox
End Class

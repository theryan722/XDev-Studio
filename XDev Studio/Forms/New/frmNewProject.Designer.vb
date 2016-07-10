<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewProject
    Inherits MetroFramework.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewProject))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_projname = New MetroFramework.Controls.MetroTextBox()
        Me.combo_projlang = New MetroFramework.Controls.MetroComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_projdev = New MetroFramework.Controls.MetroTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_devwebsite = New MetroFramework.Controls.MetroTextBox()
        Me.btn_cancel = New MetroFramework.Controls.MetroButton()
        Me.btn_create = New MetroFramework.Controls.MetroButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_devcontact = New MetroFramework.Controls.MetroTextBox()
        Me.txt_projlicense = New MetroFramework.Controls.MetroTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_projlocation = New MetroFramework.Controls.MetroTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_browse = New MetroFramework.Controls.MetroButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txt_projversion = New MetroFramework.Controls.MetroTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "*Project Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 292)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "*Project Language:"
        '
        'txt_projname
        '
        Me.txt_projname.Lines = New String(-1) {}
        Me.txt_projname.Location = New System.Drawing.Point(83, 63)
        Me.txt_projname.MaxLength = 32767
        Me.txt_projname.Name = "txt_projname"
        Me.txt_projname.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_projname.PromptText = "New Project"
        Me.txt_projname.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_projname.SelectedText = ""
        Me.txt_projname.Size = New System.Drawing.Size(203, 23)
        Me.txt_projname.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txt_projname, "The name of the project. Also the folder name where the project is stored.")
        Me.txt_projname.UseSelectable = True
        '
        'combo_projlang
        '
        Me.combo_projlang.FormattingEnabled = True
        Me.combo_projlang.ItemHeight = 23
        Me.combo_projlang.Items.AddRange(New Object() {"Ada", "Assembly", "Batch", "csharp", "cplusplus", "CSS", "Fortran", "HTML", "Java", "JavaScript", "Lisp", "Lua", "Markdown", "Pascal", "Perl", "PHP", "PostgreSQL", "Python", "Ruby", "SmallTalk", "SQL", "VB", "XML", "YAML", "CustomLanguage", "PlainText"})
        Me.combo_projlang.Location = New System.Drawing.Point(103, 289)
        Me.combo_projlang.Name = "combo_projlang"
        Me.combo_projlang.Size = New System.Drawing.Size(113, 29)
        Me.combo_projlang.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.combo_projlang, "The language of the project.")
        Me.combo_projlang.UseSelectable = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Project Developer:"
        '
        'txt_projdev
        '
        Me.txt_projdev.Lines = New String(-1) {}
        Me.txt_projdev.Location = New System.Drawing.Point(103, 98)
        Me.txt_projdev.MaxLength = 32767
        Me.txt_projdev.Name = "txt_projdev"
        Me.txt_projdev.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_projdev.PromptText = "Developer Name"
        Me.txt_projdev.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_projdev.SelectedText = ""
        Me.txt_projdev.Size = New System.Drawing.Size(183, 23)
        Me.txt_projdev.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txt_projdev, "The name of the developer of the project.")
        Me.txt_projdev.UseSelectable = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Developer Website:"
        '
        'txt_devwebsite
        '
        Me.txt_devwebsite.Lines = New String(-1) {}
        Me.txt_devwebsite.Location = New System.Drawing.Point(103, 133)
        Me.txt_devwebsite.MaxLength = 32767
        Me.txt_devwebsite.Name = "txt_devwebsite"
        Me.txt_devwebsite.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_devwebsite.PromptText = "http://www.website.com"
        Me.txt_devwebsite.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_devwebsite.SelectedText = ""
        Me.txt_devwebsite.Size = New System.Drawing.Size(183, 23)
        Me.txt_devwebsite.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txt_devwebsite, "The website of the developer or project.")
        Me.txt_devwebsite.UseSelectable = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(3, 378)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(91, 34)
        Me.btn_cancel.TabIndex = 11
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseSelectable = True
        '
        'btn_create
        '
        Me.btn_create.Location = New System.Drawing.Point(316, 378)
        Me.btn_create.Name = "btn_create"
        Me.btn_create.Size = New System.Drawing.Size(91, 34)
        Me.btn_create.TabIndex = 10
        Me.btn_create.Text = "Create"
        Me.btn_create.UseSelectable = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Developer Contact:"
        '
        'txt_devcontact
        '
        Me.txt_devcontact.Lines = New String(-1) {}
        Me.txt_devcontact.Location = New System.Drawing.Point(104, 172)
        Me.txt_devcontact.MaxLength = 32767
        Me.txt_devcontact.Name = "txt_devcontact"
        Me.txt_devcontact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_devcontact.PromptText = "developer@website.com"
        Me.txt_devcontact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_devcontact.SelectedText = ""
        Me.txt_devcontact.Size = New System.Drawing.Size(182, 23)
        Me.txt_devcontact.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txt_devcontact, "The email of the developer.")
        Me.txt_devcontact.UseSelectable = True
        '
        'txt_projlicense
        '
        Me.txt_projlicense.Lines = New String(-1) {}
        Me.txt_projlicense.Location = New System.Drawing.Point(103, 212)
        Me.txt_projlicense.MaxLength = 32767
        Me.txt_projlicense.Name = "txt_projlicense"
        Me.txt_projlicense.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_projlicense.PromptText = "License Name"
        Me.txt_projlicense.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_projlicense.SelectedText = ""
        Me.txt_projlicense.Size = New System.Drawing.Size(183, 23)
        Me.txt_projlicense.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txt_projlicense, "The type of license the project will have.")
        Me.txt_projlicense.UseSelectable = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Project License:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 338)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "*Location:"
        '
        'txt_projlocation
        '
        Me.txt_projlocation.Lines = New String(-1) {}
        Me.txt_projlocation.Location = New System.Drawing.Point(62, 338)
        Me.txt_projlocation.MaxLength = 32767
        Me.txt_projlocation.Name = "txt_projlocation"
        Me.txt_projlocation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_projlocation.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_projlocation.SelectedText = ""
        Me.txt_projlocation.Size = New System.Drawing.Size(264, 23)
        Me.txt_projlocation.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.txt_projlocation, "Location must end with a backslash (\)")
        Me.txt_projlocation.UseSelectable = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 417)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(256, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "*Items marked with an asterisk are required."
        '
        'btn_browse
        '
        Me.btn_browse.Location = New System.Drawing.Point(332, 338)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(75, 23)
        Me.btn_browse.TabIndex = 9
        Me.btn_browse.Text = "Browse"
        Me.btn_browse.UseSelectable = True
        '
        'txt_projversion
        '
        Me.txt_projversion.Lines = New String(-1) {}
        Me.txt_projversion.Location = New System.Drawing.Point(104, 249)
        Me.txt_projversion.MaxLength = 32767
        Me.txt_projversion.Name = "txt_projversion"
        Me.txt_projversion.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_projversion.PromptText = "1.0.0.0"
        Me.txt_projversion.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_projversion.SelectedText = ""
        Me.txt_projversion.Size = New System.Drawing.Size(182, 23)
        Me.txt_projversion.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txt_projversion, "The version of the project.")
        Me.txt_projversion.UseSelectable = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 249)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Project Version:"
        '
        'frmNewProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 443)
        Me.Controls.Add(Me.txt_projversion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btn_browse)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_projlocation)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_projlicense)
        Me.Controls.Add(Me.txt_devcontact)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_create)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.txt_devwebsite)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_projdev)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.combo_projlang)
        Me.Controls.Add(Me.txt_projname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewProject"
        Me.Padding = New System.Windows.Forms.Padding(0, 60, 0, 20)
        Me.Resizable = False
        Me.ShowInTaskbar = False
        Me.Text = "New Project"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_projname As MetroFramework.Controls.MetroTextBox
    Friend WithEvents combo_projlang As MetroFramework.Controls.MetroComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_projdev As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_devwebsite As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btn_cancel As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_create As MetroFramework.Controls.MetroButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_devcontact As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_projlicense As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_projlocation As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_browse As MetroFramework.Controls.MetroButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_projversion As MetroFramework.Controls.MetroTextBox
End Class

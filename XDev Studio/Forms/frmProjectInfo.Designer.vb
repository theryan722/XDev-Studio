<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectInfo
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
        Me.MetroTabControl1 = New MetroFramework.Controls.MetroTabControl()
        Me.Tab_View = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Text_view = New System.Windows.Forms.TextBox()
        Me.ViewContextMenu = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tab_Edit = New System.Windows.Forms.TabPage()
        Me.txt_projlocation = New MetroFramework.Controls.MetroTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_save = New MetroFramework.Controls.MetroButton()
        Me.btn_cancel = New MetroFramework.Controls.MetroButton()
        Me.combo_projlang = New MetroFramework.Controls.MetroComboBox()
        Me.txt_website = New MetroFramework.Controls.MetroTextBox()
        Me.txt_contact = New MetroFramework.Controls.MetroTextBox()
        Me.txt_developer = New MetroFramework.Controls.MetroTextBox()
        Me.txt_projlicense = New MetroFramework.Controls.MetroTextBox()
        Me.txt_projver = New MetroFramework.Controls.MetroTextBox()
        Me.txt_projname = New MetroFramework.Controls.MetroTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.check_topmost = New System.Windows.Forms.CheckBox()
        Me.MetroTabControl1.SuspendLayout()
        Me.Tab_View.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ViewContextMenu.SuspendLayout()
        Me.Tab_Edit.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroTabControl1
        '
        Me.MetroTabControl1.Controls.Add(Me.Tab_View)
        Me.MetroTabControl1.Controls.Add(Me.Tab_Edit)
        Me.MetroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroTabControl1.Location = New System.Drawing.Point(0, 60)
        Me.MetroTabControl1.Name = "MetroTabControl1"
        Me.MetroTabControl1.SelectedIndex = 0
        Me.MetroTabControl1.Size = New System.Drawing.Size(382, 335)
        Me.MetroTabControl1.TabIndex = 0
        Me.MetroTabControl1.UseSelectable = True
        '
        'Tab_View
        '
        Me.Tab_View.Controls.Add(Me.Panel1)
        Me.Tab_View.Location = New System.Drawing.Point(4, 38)
        Me.Tab_View.Name = "Tab_View"
        Me.Tab_View.Size = New System.Drawing.Size(374, 293)
        Me.Tab_View.TabIndex = 0
        Me.Tab_View.Text = "View"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Text_view)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(374, 293)
        Me.Panel1.TabIndex = 1
        '
        'Text_view
        '
        Me.Text_view.ContextMenuStrip = Me.ViewContextMenu
        Me.Text_view.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Text_view.Location = New System.Drawing.Point(0, 0)
        Me.Text_view.Multiline = True
        Me.Text_view.Name = "Text_view"
        Me.Text_view.ReadOnly = True
        Me.Text_view.Size = New System.Drawing.Size(374, 293)
        Me.Text_view.TabIndex = 0
        '
        'ViewContextMenu
        '
        Me.ViewContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.ToolStripSeparator1, Me.RefreshToolStripMenuItem})
        Me.ViewContextMenu.Name = "ViewContextMenu"
        Me.ViewContextMenu.Size = New System.Drawing.Size(114, 54)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(110, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'Tab_Edit
        '
        Me.Tab_Edit.Controls.Add(Me.txt_projlocation)
        Me.Tab_Edit.Controls.Add(Me.Label8)
        Me.Tab_Edit.Controls.Add(Me.btn_save)
        Me.Tab_Edit.Controls.Add(Me.btn_cancel)
        Me.Tab_Edit.Controls.Add(Me.combo_projlang)
        Me.Tab_Edit.Controls.Add(Me.txt_website)
        Me.Tab_Edit.Controls.Add(Me.txt_contact)
        Me.Tab_Edit.Controls.Add(Me.txt_developer)
        Me.Tab_Edit.Controls.Add(Me.txt_projlicense)
        Me.Tab_Edit.Controls.Add(Me.txt_projver)
        Me.Tab_Edit.Controls.Add(Me.txt_projname)
        Me.Tab_Edit.Controls.Add(Me.Label7)
        Me.Tab_Edit.Controls.Add(Me.Label6)
        Me.Tab_Edit.Controls.Add(Me.Label5)
        Me.Tab_Edit.Controls.Add(Me.Label4)
        Me.Tab_Edit.Controls.Add(Me.Label3)
        Me.Tab_Edit.Controls.Add(Me.Label2)
        Me.Tab_Edit.Controls.Add(Me.Label1)
        Me.Tab_Edit.Location = New System.Drawing.Point(4, 38)
        Me.Tab_Edit.Name = "Tab_Edit"
        Me.Tab_Edit.Size = New System.Drawing.Size(374, 293)
        Me.Tab_Edit.TabIndex = 1
        Me.Tab_Edit.Text = "Edit"
        '
        'txt_projlocation
        '
        Me.txt_projlocation.Lines = New String(-1) {}
        Me.txt_projlocation.Location = New System.Drawing.Point(107, 215)
        Me.txt_projlocation.MaxLength = 32767
        Me.txt_projlocation.Name = "txt_projlocation"
        Me.txt_projlocation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_projlocation.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_projlocation.SelectedText = ""
        Me.txt_projlocation.Size = New System.Drawing.Size(147, 23)
        Me.txt_projlocation.TabIndex = 7
        Me.txt_projlocation.UseSelectable = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Project Location:"
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(296, 257)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 23)
        Me.btn_save.TabIndex = 8
        Me.btn_save.Text = "Save"
        Me.btn_save.UseSelectable = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(3, 257)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancel.TabIndex = 9
        Me.btn_cancel.Text = "Reset"
        Me.btn_cancel.UseSelectable = True
        '
        'combo_projlang
        '
        Me.combo_projlang.FormattingEnabled = True
        Me.combo_projlang.ItemHeight = 23
        Me.combo_projlang.Items.AddRange(New Object() {"Ada", "Assembly", "Batch", "csharp", "cplusplus", "CSS", "Fortran", "HTML", "Java", "JavaScript", "Lisp", "Lua", "Pascal", "Perl", "PHP", "PostgreSQL", "Python", "Ruby", "SmallTalk", "SQL", "VBScript", "XML", "YAML", "CustomLanguage", "PlainText"})
        Me.combo_projlang.Location = New System.Drawing.Point(107, 98)
        Me.combo_projlang.Name = "combo_projlang"
        Me.combo_projlang.Size = New System.Drawing.Size(147, 29)
        Me.combo_projlang.TabIndex = 3
        Me.combo_projlang.UseSelectable = True
        '
        'txt_website
        '
        Me.txt_website.Lines = New String(-1) {}
        Me.txt_website.Location = New System.Drawing.Point(107, 186)
        Me.txt_website.MaxLength = 32767
        Me.txt_website.Name = "txt_website"
        Me.txt_website.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_website.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_website.SelectedText = ""
        Me.txt_website.Size = New System.Drawing.Size(147, 23)
        Me.txt_website.TabIndex = 6
        Me.txt_website.UseSelectable = True
        '
        'txt_contact
        '
        Me.txt_contact.Lines = New String(-1) {}
        Me.txt_contact.Location = New System.Drawing.Point(107, 159)
        Me.txt_contact.MaxLength = 32767
        Me.txt_contact.Name = "txt_contact"
        Me.txt_contact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_contact.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_contact.SelectedText = ""
        Me.txt_contact.Size = New System.Drawing.Size(147, 23)
        Me.txt_contact.TabIndex = 5
        Me.txt_contact.UseSelectable = True
        '
        'txt_developer
        '
        Me.txt_developer.Lines = New String(-1) {}
        Me.txt_developer.Location = New System.Drawing.Point(107, 130)
        Me.txt_developer.MaxLength = 32767
        Me.txt_developer.Name = "txt_developer"
        Me.txt_developer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_developer.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_developer.SelectedText = ""
        Me.txt_developer.Size = New System.Drawing.Size(147, 23)
        Me.txt_developer.TabIndex = 4
        Me.txt_developer.UseSelectable = True
        '
        'txt_projlicense
        '
        Me.txt_projlicense.Lines = New String(-1) {}
        Me.txt_projlicense.Location = New System.Drawing.Point(107, 72)
        Me.txt_projlicense.MaxLength = 32767
        Me.txt_projlicense.Name = "txt_projlicense"
        Me.txt_projlicense.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_projlicense.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_projlicense.SelectedText = ""
        Me.txt_projlicense.Size = New System.Drawing.Size(147, 23)
        Me.txt_projlicense.TabIndex = 2
        Me.txt_projlicense.UseSelectable = True
        '
        'txt_projver
        '
        Me.txt_projver.Lines = New String(-1) {}
        Me.txt_projver.Location = New System.Drawing.Point(107, 43)
        Me.txt_projver.MaxLength = 32767
        Me.txt_projver.Name = "txt_projver"
        Me.txt_projver.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_projver.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_projver.SelectedText = ""
        Me.txt_projver.Size = New System.Drawing.Size(147, 23)
        Me.txt_projver.TabIndex = 1
        Me.txt_projver.UseSelectable = True
        '
        'txt_projname
        '
        Me.txt_projname.Lines = New String(-1) {}
        Me.txt_projname.Location = New System.Drawing.Point(107, 14)
        Me.txt_projname.MaxLength = 32767
        Me.txt_projname.Name = "txt_projname"
        Me.txt_projname.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_projname.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_projname.SelectedText = ""
        Me.txt_projname.Size = New System.Drawing.Size(147, 23)
        Me.txt_projname.TabIndex = 0
        Me.txt_projname.UseSelectable = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 186)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Developer Website:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Developer Contact:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Developer:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Project Language:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Project License:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Project Version:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Project Name:"
        '
        'check_topmost
        '
        Me.check_topmost.AutoSize = True
        Me.check_topmost.Location = New System.Drawing.Point(311, 37)
        Me.check_topmost.Name = "check_topmost"
        Me.check_topmost.Size = New System.Drawing.Size(67, 17)
        Me.check_topmost.TabIndex = 1
        Me.check_topmost.Text = "Topmost"
        Me.check_topmost.UseVisualStyleBackColor = True
        '
        'frmProjectInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 415)
        Me.Controls.Add(Me.check_topmost)
        Me.Controls.Add(Me.MetroTabControl1)
        Me.MaximizeBox = False
        Me.Name = "frmProjectInfo"
        Me.Padding = New System.Windows.Forms.Padding(0, 60, 0, 20)
        Me.Resizable = False
        Me.Text = "Project Information"
        Me.MetroTabControl1.ResumeLayout(False)
        Me.Tab_View.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ViewContextMenu.ResumeLayout(False)
        Me.Tab_Edit.ResumeLayout(False)
        Me.Tab_Edit.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MetroTabControl1 As MetroFramework.Controls.MetroTabControl
    Friend WithEvents Tab_View As System.Windows.Forms.TabPage
    Friend WithEvents Tab_Edit As System.Windows.Forms.TabPage
    Friend WithEvents check_topmost As System.Windows.Forms.CheckBox
    Friend WithEvents Text_view As System.Windows.Forms.TextBox
    Friend WithEvents ViewContextMenu As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_website As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_contact As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_developer As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_projlicense As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_projver As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_projname As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents combo_projlang As MetroFramework.Controls.MetroComboBox
    Friend WithEvents btn_save As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_cancel As MetroFramework.Controls.MetroButton
    Friend WithEvents txt_projlocation As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class

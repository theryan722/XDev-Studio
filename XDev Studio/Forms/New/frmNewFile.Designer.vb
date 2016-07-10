<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewFile))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_create = New MetroFramework.Controls.MetroButton()
        Me.btn_cancel = New MetroFramework.Controls.MetroButton()
        Me.combo_filelang = New MetroFramework.Controls.MetroComboBox()
        Me.txt_filename = New MetroFramework.Controls.MetroTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_fileloc = New MetroFramework.Controls.MetroTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "*File Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "*Language:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 214)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(256, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "*Items marked with an asterisk are required."
        '
        'btn_create
        '
        Me.btn_create.Location = New System.Drawing.Point(320, 175)
        Me.btn_create.Name = "btn_create"
        Me.btn_create.Size = New System.Drawing.Size(91, 34)
        Me.btn_create.TabIndex = 3
        Me.btn_create.Text = "Create"
        Me.btn_create.UseSelectable = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(7, 175)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(91, 34)
        Me.btn_cancel.TabIndex = 4
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseSelectable = True
        '
        'combo_filelang
        '
        Me.combo_filelang.FormattingEnabled = True
        Me.combo_filelang.ItemHeight = 23
        Me.combo_filelang.Items.AddRange(New Object() {"Ada", "Assembly", "Batch", "csharp", "cplusplus", "CSS", "Fortran", "HTML", "Java", "JavaScript", "Lisp", "Lua", "Markdown", "Pascal", "Perl", "PHP", "PostgreSQL", "Python", "Ruby", "SmallTalk", "SQL", "VB", "XML", "YAML", "CustomLanguage", "PlainText"})
        Me.combo_filelang.Location = New System.Drawing.Point(80, 113)
        Me.combo_filelang.Name = "combo_filelang"
        Me.combo_filelang.Size = New System.Drawing.Size(113, 29)
        Me.combo_filelang.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.combo_filelang, "The language of the file.")
        Me.combo_filelang.UseSelectable = True
        '
        'txt_filename
        '
        Me.txt_filename.Lines = New String() {"Class"}
        Me.txt_filename.Location = New System.Drawing.Point(79, 84)
        Me.txt_filename.MaxLength = 32767
        Me.txt_filename.Name = "txt_filename"
        Me.txt_filename.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_filename.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_filename.SelectedText = ""
        Me.txt_filename.Size = New System.Drawing.Size(145, 23)
        Me.txt_filename.TabIndex = 1
        Me.txt_filename.Text = "Class"
        Me.ToolTip1.SetToolTip(Me.txt_filename, "The name of the file.")
        Me.txt_filename.UseSelectable = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(265, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "The file will be added to the project folder and data file."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(230, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 26)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "*If using custom language, please " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "add file extension to file name."
        '
        'txt_fileloc
        '
        Me.txt_fileloc.Lines = New String() {"\Files"}
        Me.txt_fileloc.Location = New System.Drawing.Point(80, 146)
        Me.txt_fileloc.MaxLength = 32767
        Me.txt_fileloc.Name = "txt_fileloc"
        Me.txt_fileloc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_fileloc.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_fileloc.SelectedText = ""
        Me.txt_fileloc.Size = New System.Drawing.Size(144, 23)
        Me.txt_fileloc.TabIndex = 25
        Me.txt_fileloc.Text = "\Files"
        Me.txt_fileloc.UseSelectable = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "*Location:"
        '
        'frmNewFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 259)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_fileloc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_filename)
        Me.Controls.Add(Me.combo_filelang)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btn_create)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewFile"
        Me.Padding = New System.Windows.Forms.Padding(0, 60, 0, 20)
        Me.Resizable = False
        Me.ShowInTaskbar = False
        Me.Text = "New File"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_create As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_cancel As MetroFramework.Controls.MetroButton
    Friend WithEvents combo_filelang As MetroFramework.Controls.MetroComboBox
    Friend WithEvents txt_filename As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_fileloc As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class

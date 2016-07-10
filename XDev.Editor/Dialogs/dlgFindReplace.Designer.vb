<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgFindReplace
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgFindReplace))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ConstrainSearchOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabFind = New System.Windows.Forms.TabPage()
        Me.btn_find_clrfind = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_find_all = New System.Windows.Forms.Button()
        Me.btn_find_clearhighlighting = New System.Windows.Forms.Button()
        Me.btn_find_highlightmatches = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk_find_searchselection = New System.Windows.Forms.CheckBox()
        Me.check_find_wordstart = New System.Windows.Forms.CheckBox()
        Me.check_find_wholeword = New System.Windows.Forms.CheckBox()
        Me.check_find_matchcase = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radio_find_regex = New System.Windows.Forms.RadioButton()
        Me.radio_find_normal = New System.Windows.Forms.RadioButton()
        Me.btn_find_previous = New System.Windows.Forms.Button()
        Me.btn_find_next = New System.Windows.Forms.Button()
        Me.txt_find_find = New System.Windows.Forms.ComboBox()
        Me.tabReplace = New System.Windows.Forms.TabPage()
        Me.btn_replace_clrreplace = New System.Windows.Forms.PictureBox()
        Me.btn_replace_clrfind = New System.Windows.Forms.PictureBox()
        Me.btn_replace_all = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_replace_replace = New System.Windows.Forms.ComboBox()
        Me.btn_replace_previous = New System.Windows.Forms.Button()
        Me.btn_replace_next = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chk_replace_searchselection = New System.Windows.Forms.CheckBox()
        Me.check_replace_wordstart = New System.Windows.Forms.CheckBox()
        Me.check_replace_wholeword = New System.Windows.Forms.CheckBox()
        Me.check_replace_matchcase = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.radio_replace_regex = New System.Windows.Forms.RadioButton()
        Me.radio_replace_normal = New System.Windows.Forms.RadioButton()
        Me.txt_replace_find = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabFind.SuspendLayout()
        CType(Me.btn_find_clrfind, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabReplace.SuspendLayout()
        CType(Me.btn_replace_clrreplace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_replace_clrfind, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton2, Me.ToolStripDropDownButton1, Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 276)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(460, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConstrainSearchOptionsToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(29, 20)
        Me.ToolStripDropDownButton2.Text = "ToolStripDropDownButton2"
        '
        'ConstrainSearchOptionsToolStripMenuItem
        '
        Me.ConstrainSearchOptionsToolStripMenuItem.Checked = True
        Me.ConstrainSearchOptionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ConstrainSearchOptionsToolStripMenuItem.Name = "ConstrainSearchOptionsToolStripMenuItem"
        Me.ConstrainSearchOptionsToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.ConstrainSearchOptionsToolStripMenuItem.Text = "Constrain Search Options"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem11, Me.ToolStripMenuItem10, Me.ToolStripMenuItem9, Me.ToolStripMenuItem8, Me.ToolStripMenuItem7, Me.ToolStripMenuItem6, Me.ToolStripMenuItem5, Me.ToolStripMenuItem4, Me.ToolStripMenuItem3, Me.ToolStripMenuItem2})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(61, 20)
        Me.ToolStripDropDownButton1.Text = "Opacity"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem11.Text = "10%"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem10.Text = "20%"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem9.Text = "30%"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem8.Text = "40%"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem7.Text = "50%"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem6.Text = "60%"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem5.Text = "70%"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem4.Text = "80%"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem3.Text = "90%"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem2.Text = "100%"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(15, 17)
        Me.lblStatus.Text = "[]"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabFind)
        Me.TabControl1.Controls.Add(Me.tabReplace)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(460, 276)
        Me.TabControl1.TabIndex = 3
        '
        'tabFind
        '
        Me.tabFind.Controls.Add(Me.btn_find_clrfind)
        Me.tabFind.Controls.Add(Me.GroupBox3)
        Me.tabFind.Controls.Add(Me.GroupBox2)
        Me.tabFind.Controls.Add(Me.Label1)
        Me.tabFind.Controls.Add(Me.GroupBox1)
        Me.tabFind.Controls.Add(Me.btn_find_previous)
        Me.tabFind.Controls.Add(Me.btn_find_next)
        Me.tabFind.Controls.Add(Me.txt_find_find)
        Me.tabFind.Location = New System.Drawing.Point(4, 22)
        Me.tabFind.Name = "tabFind"
        Me.tabFind.Size = New System.Drawing.Size(452, 250)
        Me.tabFind.TabIndex = 0
        Me.tabFind.Text = "Find"
        Me.tabFind.UseVisualStyleBackColor = True
        '
        'btn_find_clrfind
        '
        Me.btn_find_clrfind.Image = CType(resources.GetObject("btn_find_clrfind.Image"), System.Drawing.Image)
        Me.btn_find_clrfind.Location = New System.Drawing.Point(433, 8)
        Me.btn_find_clrfind.Name = "btn_find_clrfind"
        Me.btn_find_clrfind.Size = New System.Drawing.Size(16, 16)
        Me.btn_find_clrfind.TabIndex = 19
        Me.btn_find_clrfind.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_find_all)
        Me.GroupBox3.Controls.Add(Me.btn_find_clearhighlighting)
        Me.GroupBox3.Controls.Add(Me.btn_find_highlightmatches)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 166)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(318, 81)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Find All"
        '
        'btn_find_all
        '
        Me.btn_find_all.Location = New System.Drawing.Point(214, 52)
        Me.btn_find_all.Name = "btn_find_all"
        Me.btn_find_all.Size = New System.Drawing.Size(98, 23)
        Me.btn_find_all.TabIndex = 3
        Me.btn_find_all.Text = "Find All"
        Me.btn_find_all.UseVisualStyleBackColor = True
        '
        'btn_find_clearhighlighting
        '
        Me.btn_find_clearhighlighting.Location = New System.Drawing.Point(6, 48)
        Me.btn_find_clearhighlighting.Name = "btn_find_clearhighlighting"
        Me.btn_find_clearhighlighting.Size = New System.Drawing.Size(102, 23)
        Me.btn_find_clearhighlighting.TabIndex = 5
        Me.btn_find_clearhighlighting.Text = "Clear Highlighting"
        Me.btn_find_clearhighlighting.UseVisualStyleBackColor = True
        '
        'btn_find_highlightmatches
        '
        Me.btn_find_highlightmatches.Location = New System.Drawing.Point(6, 19)
        Me.btn_find_highlightmatches.Name = "btn_find_highlightmatches"
        Me.btn_find_highlightmatches.Size = New System.Drawing.Size(102, 23)
        Me.btn_find_highlightmatches.TabIndex = 4
        Me.btn_find_highlightmatches.Text = "Highlight Matches"
        Me.btn_find_highlightmatches.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk_find_searchselection)
        Me.GroupBox2.Controls.Add(Me.check_find_wordstart)
        Me.GroupBox2.Controls.Add(Me.check_find_wholeword)
        Me.GroupBox2.Controls.Add(Me.check_find_matchcase)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(439, 62)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options"
        '
        'chk_find_searchselection
        '
        Me.chk_find_searchselection.AutoSize = True
        Me.chk_find_searchselection.Enabled = False
        Me.chk_find_searchselection.Location = New System.Drawing.Point(326, 19)
        Me.chk_find_searchselection.Name = "chk_find_searchselection"
        Me.chk_find_searchselection.Size = New System.Drawing.Size(107, 17)
        Me.chk_find_searchselection.TabIndex = 3
        Me.chk_find_searchselection.Text = "Search Selection"
        Me.chk_find_searchselection.UseVisualStyleBackColor = True
        '
        'check_find_wordstart
        '
        Me.check_find_wordstart.AutoSize = True
        Me.check_find_wordstart.Location = New System.Drawing.Point(95, 19)
        Me.check_find_wordstart.Name = "check_find_wordstart"
        Me.check_find_wordstart.Size = New System.Drawing.Size(77, 17)
        Me.check_find_wordstart.TabIndex = 2
        Me.check_find_wordstart.Text = "Word Start"
        Me.check_find_wordstart.UseVisualStyleBackColor = True
        '
        'check_find_wholeword
        '
        Me.check_find_wholeword.AutoSize = True
        Me.check_find_wholeword.Location = New System.Drawing.Point(6, 42)
        Me.check_find_wholeword.Name = "check_find_wholeword"
        Me.check_find_wholeword.Size = New System.Drawing.Size(86, 17)
        Me.check_find_wholeword.TabIndex = 1
        Me.check_find_wholeword.Text = "Whole Word"
        Me.check_find_wholeword.UseVisualStyleBackColor = True
        '
        'check_find_matchcase
        '
        Me.check_find_matchcase.AutoSize = True
        Me.check_find_matchcase.Location = New System.Drawing.Point(6, 19)
        Me.check_find_matchcase.Name = "check_find_matchcase"
        Me.check_find_matchcase.Size = New System.Drawing.Size(83, 17)
        Me.check_find_matchcase.TabIndex = 0
        Me.check_find_matchcase.Text = "Match Case"
        Me.check_find_matchcase.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Find:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radio_find_regex)
        Me.GroupBox1.Controls.Add(Me.radio_find_normal)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(439, 62)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Type"
        '
        'radio_find_regex
        '
        Me.radio_find_regex.AutoSize = True
        Me.radio_find_regex.Location = New System.Drawing.Point(6, 41)
        Me.radio_find_regex.Name = "radio_find_regex"
        Me.radio_find_regex.Size = New System.Drawing.Size(56, 17)
        Me.radio_find_regex.TabIndex = 1
        Me.radio_find_regex.Text = "Regex"
        Me.radio_find_regex.UseVisualStyleBackColor = True
        '
        'radio_find_normal
        '
        Me.radio_find_normal.AutoSize = True
        Me.radio_find_normal.Checked = True
        Me.radio_find_normal.Location = New System.Drawing.Point(6, 18)
        Me.radio_find_normal.Name = "radio_find_normal"
        Me.radio_find_normal.Size = New System.Drawing.Size(58, 17)
        Me.radio_find_normal.TabIndex = 0
        Me.radio_find_normal.TabStop = True
        Me.radio_find_normal.Text = "Normal"
        Me.radio_find_normal.UseVisualStyleBackColor = True
        '
        'btn_find_previous
        '
        Me.btn_find_previous.Location = New System.Drawing.Point(334, 185)
        Me.btn_find_previous.Name = "btn_find_previous"
        Me.btn_find_previous.Size = New System.Drawing.Size(98, 23)
        Me.btn_find_previous.TabIndex = 2
        Me.btn_find_previous.Text = "Find Previous"
        Me.btn_find_previous.UseVisualStyleBackColor = True
        '
        'btn_find_next
        '
        Me.btn_find_next.Location = New System.Drawing.Point(334, 214)
        Me.btn_find_next.Name = "btn_find_next"
        Me.btn_find_next.Size = New System.Drawing.Size(98, 23)
        Me.btn_find_next.TabIndex = 1
        Me.btn_find_next.Text = "Find Next"
        Me.btn_find_next.UseVisualStyleBackColor = True
        '
        'txt_find_find
        '
        Me.txt_find_find.FormattingEnabled = True
        Me.txt_find_find.Location = New System.Drawing.Point(57, 6)
        Me.txt_find_find.Name = "txt_find_find"
        Me.txt_find_find.Size = New System.Drawing.Size(375, 21)
        Me.txt_find_find.TabIndex = 0
        '
        'tabReplace
        '
        Me.tabReplace.Controls.Add(Me.btn_replace_clrreplace)
        Me.tabReplace.Controls.Add(Me.btn_replace_clrfind)
        Me.tabReplace.Controls.Add(Me.btn_replace_all)
        Me.tabReplace.Controls.Add(Me.Label3)
        Me.tabReplace.Controls.Add(Me.txt_replace_replace)
        Me.tabReplace.Controls.Add(Me.btn_replace_previous)
        Me.tabReplace.Controls.Add(Me.btn_replace_next)
        Me.tabReplace.Controls.Add(Me.GroupBox4)
        Me.tabReplace.Controls.Add(Me.Label2)
        Me.tabReplace.Controls.Add(Me.GroupBox5)
        Me.tabReplace.Controls.Add(Me.txt_replace_find)
        Me.tabReplace.Location = New System.Drawing.Point(4, 22)
        Me.tabReplace.Name = "tabReplace"
        Me.tabReplace.Size = New System.Drawing.Size(452, 250)
        Me.tabReplace.TabIndex = 1
        Me.tabReplace.Text = "Replace"
        Me.tabReplace.UseVisualStyleBackColor = True
        '
        'btn_replace_clrreplace
        '
        Me.btn_replace_clrreplace.Image = CType(resources.GetObject("btn_replace_clrreplace.Image"), System.Drawing.Image)
        Me.btn_replace_clrreplace.Location = New System.Drawing.Point(434, 35)
        Me.btn_replace_clrreplace.Name = "btn_replace_clrreplace"
        Me.btn_replace_clrreplace.Size = New System.Drawing.Size(16, 16)
        Me.btn_replace_clrreplace.TabIndex = 18
        Me.btn_replace_clrreplace.TabStop = False
        '
        'btn_replace_clrfind
        '
        Me.btn_replace_clrfind.Image = CType(resources.GetObject("btn_replace_clrfind.Image"), System.Drawing.Image)
        Me.btn_replace_clrfind.Location = New System.Drawing.Point(434, 8)
        Me.btn_replace_clrfind.Name = "btn_replace_clrfind"
        Me.btn_replace_clrfind.Size = New System.Drawing.Size(16, 16)
        Me.btn_replace_clrfind.TabIndex = 17
        Me.btn_replace_clrfind.TabStop = False
        '
        'btn_replace_all
        '
        Me.btn_replace_all.Location = New System.Drawing.Point(9, 222)
        Me.btn_replace_all.Name = "btn_replace_all"
        Me.btn_replace_all.Size = New System.Drawing.Size(98, 23)
        Me.btn_replace_all.TabIndex = 4
        Me.btn_replace_all.Text = "Replace All"
        Me.btn_replace_all.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Replace:"
        '
        'txt_replace_replace
        '
        Me.txt_replace_replace.FormattingEnabled = True
        Me.txt_replace_replace.Location = New System.Drawing.Point(57, 33)
        Me.txt_replace_replace.Name = "txt_replace_replace"
        Me.txt_replace_replace.Size = New System.Drawing.Size(376, 21)
        Me.txt_replace_replace.TabIndex = 1
        '
        'btn_replace_previous
        '
        Me.btn_replace_previous.Location = New System.Drawing.Point(326, 193)
        Me.btn_replace_previous.Name = "btn_replace_previous"
        Me.btn_replace_previous.Size = New System.Drawing.Size(111, 23)
        Me.btn_replace_previous.TabIndex = 3
        Me.btn_replace_previous.Text = "Replace Previous"
        Me.btn_replace_previous.UseVisualStyleBackColor = True
        '
        'btn_replace_next
        '
        Me.btn_replace_next.Location = New System.Drawing.Point(326, 222)
        Me.btn_replace_next.Name = "btn_replace_next"
        Me.btn_replace_next.Size = New System.Drawing.Size(111, 23)
        Me.btn_replace_next.TabIndex = 2
        Me.btn_replace_next.Text = "Replace Next"
        Me.btn_replace_next.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chk_replace_searchselection)
        Me.GroupBox4.Controls.Add(Me.check_replace_wordstart)
        Me.GroupBox4.Controls.Add(Me.check_replace_wholeword)
        Me.GroupBox4.Controls.Add(Me.check_replace_matchcase)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 128)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(440, 62)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Options"
        '
        'chk_replace_searchselection
        '
        Me.chk_replace_searchselection.AutoSize = True
        Me.chk_replace_searchselection.Enabled = False
        Me.chk_replace_searchselection.Location = New System.Drawing.Point(321, 19)
        Me.chk_replace_searchselection.Name = "chk_replace_searchselection"
        Me.chk_replace_searchselection.Size = New System.Drawing.Size(107, 17)
        Me.chk_replace_searchselection.TabIndex = 4
        Me.chk_replace_searchselection.Text = "Search Selection"
        Me.chk_replace_searchselection.UseVisualStyleBackColor = True
        '
        'check_replace_wordstart
        '
        Me.check_replace_wordstart.AutoSize = True
        Me.check_replace_wordstart.Location = New System.Drawing.Point(95, 19)
        Me.check_replace_wordstart.Name = "check_replace_wordstart"
        Me.check_replace_wordstart.Size = New System.Drawing.Size(77, 17)
        Me.check_replace_wordstart.TabIndex = 3
        Me.check_replace_wordstart.Text = "Word Start"
        Me.check_replace_wordstart.UseVisualStyleBackColor = True
        '
        'check_replace_wholeword
        '
        Me.check_replace_wholeword.AutoSize = True
        Me.check_replace_wholeword.Location = New System.Drawing.Point(6, 42)
        Me.check_replace_wholeword.Name = "check_replace_wholeword"
        Me.check_replace_wholeword.Size = New System.Drawing.Size(86, 17)
        Me.check_replace_wholeword.TabIndex = 1
        Me.check_replace_wholeword.Text = "Whole Word"
        Me.check_replace_wholeword.UseVisualStyleBackColor = True
        '
        'check_replace_matchcase
        '
        Me.check_replace_matchcase.AutoSize = True
        Me.check_replace_matchcase.Location = New System.Drawing.Point(6, 19)
        Me.check_replace_matchcase.Name = "check_replace_matchcase"
        Me.check_replace_matchcase.Size = New System.Drawing.Size(83, 17)
        Me.check_replace_matchcase.TabIndex = 0
        Me.check_replace_matchcase.Text = "Match Case"
        Me.check_replace_matchcase.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Find:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.radio_replace_regex)
        Me.GroupBox5.Controls.Add(Me.radio_replace_normal)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 60)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(440, 62)
        Me.GroupBox5.TabIndex = 9
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Search Type"
        '
        'radio_replace_regex
        '
        Me.radio_replace_regex.AutoSize = True
        Me.radio_replace_regex.Location = New System.Drawing.Point(6, 41)
        Me.radio_replace_regex.Name = "radio_replace_regex"
        Me.radio_replace_regex.Size = New System.Drawing.Size(56, 17)
        Me.radio_replace_regex.TabIndex = 4
        Me.radio_replace_regex.Text = "Regex"
        Me.radio_replace_regex.UseVisualStyleBackColor = True
        '
        'radio_replace_normal
        '
        Me.radio_replace_normal.AutoSize = True
        Me.radio_replace_normal.Checked = True
        Me.radio_replace_normal.Location = New System.Drawing.Point(6, 18)
        Me.radio_replace_normal.Name = "radio_replace_normal"
        Me.radio_replace_normal.Size = New System.Drawing.Size(58, 17)
        Me.radio_replace_normal.TabIndex = 0
        Me.radio_replace_normal.TabStop = True
        Me.radio_replace_normal.Text = "Normal"
        Me.radio_replace_normal.UseVisualStyleBackColor = True
        '
        'txt_replace_find
        '
        Me.txt_replace_find.FormattingEnabled = True
        Me.txt_replace_find.Location = New System.Drawing.Point(57, 6)
        Me.txt_replace_find.Name = "txt_replace_find"
        Me.txt_replace_find.Size = New System.Drawing.Size(376, 21)
        Me.txt_replace_find.TabIndex = 0
        '
        'dlgFindReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 298)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgFindReplace"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Find & Replace"
        Me.TopMost = True
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabFind.ResumeLayout(False)
        Me.tabFind.PerformLayout()
        CType(Me.btn_find_clrfind, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabReplace.ResumeLayout(False)
        Me.tabReplace.PerformLayout()
        CType(Me.btn_replace_clrreplace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_replace_clrfind, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabFind As System.Windows.Forms.TabPage
    Friend WithEvents tabReplace As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radio_find_regex As System.Windows.Forms.RadioButton
    Friend WithEvents radio_find_normal As System.Windows.Forms.RadioButton
    Friend WithEvents btn_find_previous As System.Windows.Forms.Button
    Friend WithEvents btn_find_next As System.Windows.Forms.Button
    Friend WithEvents txt_find_find As System.Windows.Forms.ComboBox
    Friend WithEvents btn_find_highlightmatches As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_find_clearhighlighting As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents check_find_wholeword As System.Windows.Forms.CheckBox
    Friend WithEvents check_find_matchcase As System.Windows.Forms.CheckBox
    Friend WithEvents btn_find_all As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_replace_replace As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents check_replace_wholeword As System.Windows.Forms.CheckBox
    Friend WithEvents check_replace_matchcase As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents radio_replace_regex As System.Windows.Forms.RadioButton
    Friend WithEvents radio_replace_normal As System.Windows.Forms.RadioButton
    Friend WithEvents txt_replace_find As System.Windows.Forms.ComboBox
    Friend WithEvents btn_replace_all As System.Windows.Forms.Button
    Friend WithEvents btn_replace_previous As System.Windows.Forms.Button
    Friend WithEvents btn_replace_next As System.Windows.Forms.Button
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ConstrainSearchOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents check_find_wordstart As System.Windows.Forms.CheckBox
    Friend WithEvents check_replace_wordstart As System.Windows.Forms.CheckBox
    Friend WithEvents btn_find_clrfind As System.Windows.Forms.PictureBox
    Friend WithEvents btn_replace_clrreplace As System.Windows.Forms.PictureBox
    Friend WithEvents btn_replace_clrfind As System.Windows.Forms.PictureBox
    Friend WithEvents chk_find_searchselection As System.Windows.Forms.CheckBox
    Friend WithEvents chk_replace_searchselection As System.Windows.Forms.CheckBox
End Class

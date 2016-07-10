<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_DifferenceViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_DifferenceViewer))
        Me.MetroTabControl1 = New MetroFramework.Controls.MetroTabControl()
        Me.Tab_Compare = New System.Windows.Forms.TabPage()
        Me.Tab_Results = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_browse_file1 = New MetroFramework.Controls.MetroButton()
        Me.btn_browse_file2 = New MetroFramework.Controls.MetroButton()
        Me.btn_compare = New MetroFramework.Controls.MetroButton()
        Me.txt_file1 = New MetroFramework.Controls.MetroTextBox()
        Me.txt_file2 = New MetroFramework.Controls.MetroTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.radio_fast = New MetroFramework.Controls.MetroRadioButton()
        Me.radio_medium = New MetroFramework.Controls.MetroRadioButton()
        Me.radio_slow = New MetroFramework.Controls.MetroRadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lvDestination = New System.Windows.Forms.ListView()
        Me.columnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvSource = New System.Windows.Forms.ListView()
        Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cm_file1 = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.cm_file2 = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.OpenFileInExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileInEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileInNotepadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_clear = New MetroFramework.Controls.MetroButton()
        Me.MetroTabControl1.SuspendLayout()
        Me.Tab_Compare.SuspendLayout()
        Me.Tab_Results.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.cm_file1.SuspendLayout()
        Me.cm_file2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroTabControl1
        '
        Me.MetroTabControl1.Controls.Add(Me.Tab_Compare)
        Me.MetroTabControl1.Controls.Add(Me.Tab_Results)
        Me.MetroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.MetroTabControl1.Name = "MetroTabControl1"
        Me.MetroTabControl1.SelectedIndex = 0
        Me.MetroTabControl1.Size = New System.Drawing.Size(486, 374)
        Me.MetroTabControl1.TabIndex = 0
        Me.MetroTabControl1.UseSelectable = True
        '
        'Tab_Compare
        '
        Me.Tab_Compare.Controls.Add(Me.Panel1)
        Me.Tab_Compare.Location = New System.Drawing.Point(4, 38)
        Me.Tab_Compare.Name = "Tab_Compare"
        Me.Tab_Compare.Size = New System.Drawing.Size(478, 332)
        Me.Tab_Compare.TabIndex = 0
        Me.Tab_Compare.Text = "Compare"
        '
        'Tab_Results
        '
        Me.Tab_Results.Controls.Add(Me.Panel2)
        Me.Tab_Results.Location = New System.Drawing.Point(4, 38)
        Me.Tab_Results.Name = "Tab_Results"
        Me.Tab_Results.Size = New System.Drawing.Size(478, 332)
        Me.Tab_Results.TabIndex = 1
        Me.Tab_Results.Text = "Results"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_clear)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txt_file2)
        Me.Panel1.Controls.Add(Me.txt_file1)
        Me.Panel1.Controls.Add(Me.btn_compare)
        Me.Panel1.Controls.Add(Me.btn_browse_file2)
        Me.Panel1.Controls.Add(Me.btn_browse_file1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(478, 332)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(478, 332)
        Me.Panel2.TabIndex = 0
        '
        'btn_browse_file1
        '
        Me.btn_browse_file1.Location = New System.Drawing.Point(276, 9)
        Me.btn_browse_file1.Name = "btn_browse_file1"
        Me.btn_browse_file1.Size = New System.Drawing.Size(54, 23)
        Me.btn_browse_file1.TabIndex = 0
        Me.btn_browse_file1.Text = "Browse"
        Me.btn_browse_file1.UseSelectable = True
        '
        'btn_browse_file2
        '
        Me.btn_browse_file2.Location = New System.Drawing.Point(276, 38)
        Me.btn_browse_file2.Name = "btn_browse_file2"
        Me.btn_browse_file2.Size = New System.Drawing.Size(54, 23)
        Me.btn_browse_file2.TabIndex = 1
        Me.btn_browse_file2.Text = "Browse"
        Me.btn_browse_file2.UseSelectable = True
        '
        'btn_compare
        '
        Me.btn_compare.Location = New System.Drawing.Point(186, 67)
        Me.btn_compare.Name = "btn_compare"
        Me.btn_compare.Size = New System.Drawing.Size(144, 23)
        Me.btn_compare.TabIndex = 2
        Me.btn_compare.Text = "Compare"
        Me.btn_compare.UseSelectable = True
        '
        'txt_file1
        '
        Me.txt_file1.Lines = New String(-1) {}
        Me.txt_file1.Location = New System.Drawing.Point(49, 9)
        Me.txt_file1.MaxLength = 32767
        Me.txt_file1.Name = "txt_file1"
        Me.txt_file1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_file1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_file1.SelectedText = ""
        Me.txt_file1.Size = New System.Drawing.Size(212, 23)
        Me.txt_file1.TabIndex = 3
        Me.txt_file1.UseSelectable = True
        '
        'txt_file2
        '
        Me.txt_file2.Lines = New String(-1) {}
        Me.txt_file2.Location = New System.Drawing.Point(49, 38)
        Me.txt_file2.MaxLength = 32767
        Me.txt_file2.Name = "txt_file2"
        Me.txt_file2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_file2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_file2.SelectedText = ""
        Me.txt_file2.Size = New System.Drawing.Size(212, 23)
        Me.txt_file2.TabIndex = 4
        Me.txt_file2.UseSelectable = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "File 1:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "File 2:"
        '
        'radio_fast
        '
        Me.radio_fast.AutoSize = True
        Me.radio_fast.Checked = True
        Me.radio_fast.Location = New System.Drawing.Point(6, 19)
        Me.radio_fast.Name = "radio_fast"
        Me.radio_fast.Size = New System.Drawing.Size(44, 15)
        Me.radio_fast.TabIndex = 7
        Me.radio_fast.TabStop = True
        Me.radio_fast.Text = "Fast"
        Me.radio_fast.UseSelectable = True
        '
        'radio_medium
        '
        Me.radio_medium.AutoSize = True
        Me.radio_medium.Location = New System.Drawing.Point(6, 40)
        Me.radio_medium.Name = "radio_medium"
        Me.radio_medium.Size = New System.Drawing.Size(68, 15)
        Me.radio_medium.TabIndex = 8
        Me.radio_medium.Text = "Medium"
        Me.radio_medium.UseSelectable = True
        '
        'radio_slow
        '
        Me.radio_slow.AutoSize = True
        Me.radio_slow.Location = New System.Drawing.Point(6, 61)
        Me.radio_slow.Name = "radio_slow"
        Me.radio_slow.Size = New System.Drawing.Size(48, 15)
        Me.radio_slow.TabIndex = 9
        Me.radio_slow.Text = "Slow"
        Me.radio_slow.UseSelectable = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radio_fast)
        Me.GroupBox1.Controls.Add(Me.radio_slow)
        Me.GroupBox1.Controls.Add(Me.radio_medium)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(105, 88)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Accuracy/Speed"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvSource)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvDestination)
        Me.SplitContainer1.Size = New System.Drawing.Size(478, 332)
        Me.SplitContainer1.SplitterDistance = 239
        Me.SplitContainer1.TabIndex = 0
        '
        'lvDestination
        '
        Me.lvDestination.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader3, Me.columnHeader4})
        Me.lvDestination.ContextMenuStrip = Me.cm_file2
        Me.lvDestination.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvDestination.FullRowSelect = True
        Me.lvDestination.HideSelection = False
        Me.lvDestination.Location = New System.Drawing.Point(0, 0)
        Me.lvDestination.MultiSelect = False
        Me.lvDestination.Name = "lvDestination"
        Me.lvDestination.Size = New System.Drawing.Size(235, 332)
        Me.lvDestination.TabIndex = 4
        Me.lvDestination.UseCompatibleStateImageBehavior = False
        Me.lvDestination.View = System.Windows.Forms.View.Details
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Line"
        Me.columnHeader3.Width = 50
        '
        'columnHeader4
        '
        Me.columnHeader4.Text = "Text (File 2)"
        Me.columnHeader4.Width = 198
        '
        'lvSource
        '
        Me.lvSource.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2})
        Me.lvSource.ContextMenuStrip = Me.cm_file1
        Me.lvSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvSource.FullRowSelect = True
        Me.lvSource.HideSelection = False
        Me.lvSource.Location = New System.Drawing.Point(0, 0)
        Me.lvSource.MultiSelect = False
        Me.lvSource.Name = "lvSource"
        Me.lvSource.Size = New System.Drawing.Size(239, 332)
        Me.lvSource.TabIndex = 3
        Me.lvSource.UseCompatibleStateImageBehavior = False
        Me.lvSource.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Line"
        Me.columnHeader1.Width = 50
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Text (File 1)"
        Me.columnHeader2.Width = 147
        '
        'cm_file1
        '
        Me.cm_file1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFileInEditorToolStripMenuItem, Me.OpenFileInExplorerToolStripMenuItem, Me.OpenFileInNotepadToolStripMenuItem})
        Me.cm_file1.Name = "cm_file1"
        Me.cm_file1.Size = New System.Drawing.Size(185, 70)
        '
        'cm_file2
        '
        Me.cm_file2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.cm_file2.Name = "cm_file2"
        Me.cm_file2.Size = New System.Drawing.Size(185, 70)
        '
        'OpenFileInExplorerToolStripMenuItem
        '
        Me.OpenFileInExplorerToolStripMenuItem.Name = "OpenFileInExplorerToolStripMenuItem"
        Me.OpenFileInExplorerToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.OpenFileInExplorerToolStripMenuItem.Text = "Open file in Explorer"
        '
        'OpenFileInEditorToolStripMenuItem
        '
        Me.OpenFileInEditorToolStripMenuItem.Name = "OpenFileInEditorToolStripMenuItem"
        Me.OpenFileInEditorToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.OpenFileInEditorToolStripMenuItem.Text = "Open file in Editor"
        '
        'OpenFileInNotepadToolStripMenuItem
        '
        Me.OpenFileInNotepadToolStripMenuItem.Name = "OpenFileInNotepadToolStripMenuItem"
        Me.OpenFileInNotepadToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.OpenFileInNotepadToolStripMenuItem.Text = "Open file in Notepad"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem1.Text = "Open file in Editor"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem2.Text = "Open file in Explorer"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem3.Text = "Open file in Notepad"
        '
        'btn_clear
        '
        Me.btn_clear.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.btn_clear.Location = New System.Drawing.Point(336, 9)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(75, 52)
        Me.btn_clear.TabIndex = 11
        Me.btn_clear.Text = "Clear"
        Me.btn_clear.UseSelectable = True
        '
        'Tab_DifferenceViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 374)
        Me.Controls.Add(Me.MetroTabControl1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_DifferenceViewer"
        Me.Text = "Tab_DifferenceViewer"
        Me.MetroTabControl1.ResumeLayout(False)
        Me.Tab_Compare.ResumeLayout(False)
        Me.Tab_Results.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.cm_file1.ResumeLayout(False)
        Me.cm_file2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroTabControl1 As MetroFramework.Controls.MetroTabControl
    Friend WithEvents Tab_Compare As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Tab_Results As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radio_fast As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents radio_slow As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents radio_medium As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_file2 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_file1 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btn_compare As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_browse_file2 As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_browse_file1 As MetroFramework.Controls.MetroButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents lvSource As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents lvDestination As System.Windows.Forms.ListView
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cm_file1 As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents OpenFileInEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileInExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileInNotepadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cm_file2 As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_clear As MetroFramework.Controls.MetroButton
End Class

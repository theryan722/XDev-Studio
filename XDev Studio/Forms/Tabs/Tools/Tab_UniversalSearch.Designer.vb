<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_UniversalSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_UniversalSearch))
        Me.lb_results = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.GoToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RemoveFromSearchResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_search = New MetroFramework.Controls.MetroButton()
        Me.txt_search = New MetroFramework.Controls.MetroTextBox()
        Me.btn_reset = New MetroFramework.Controls.MetroButton()
        Me.radio_searchopendocuments = New MetroFramework.Controls.MetroRadioButton()
        Me.radio_searchdocumentsinproject = New MetroFramework.Controls.MetroRadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.check_incrementalsearch = New MetroFramework.Controls.MetroCheckBox()
        Me.check_casesensitive = New MetroFramework.Controls.MetroCheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_results
        '
        Me.lb_results.BackColor = System.Drawing.SystemColors.Window
        Me.lb_results.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lb_results.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_results.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_results.FormattingEnabled = True
        Me.lb_results.ItemHeight = 16
        Me.lb_results.Location = New System.Drawing.Point(0, 0)
        Me.lb_results.Name = "lb_results"
        Me.lb_results.ScrollAlwaysVisible = True
        Me.lb_results.Size = New System.Drawing.Size(681, 410)
        Me.lb_results.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GoToToolStripMenuItem, Me.ToolStripSeparator1, Me.RemoveFromSearchResultsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(227, 54)
        '
        'GoToToolStripMenuItem
        '
        Me.GoToToolStripMenuItem.Name = "GoToToolStripMenuItem"
        Me.GoToToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.GoToToolStripMenuItem.Text = "Go to"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(223, 6)
        '
        'RemoveFromSearchResultsToolStripMenuItem
        '
        Me.RemoveFromSearchResultsToolStripMenuItem.Name = "RemoveFromSearchResultsToolStripMenuItem"
        Me.RemoveFromSearchResultsToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.RemoveFromSearchResultsToolStripMenuItem.Text = "Remove From Search Results"
        '
        'btn_search
        '
        Me.btn_search.Location = New System.Drawing.Point(496, 11)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 23)
        Me.btn_search.TabIndex = 4
        Me.btn_search.Text = "Search"
        Me.btn_search.UseSelectable = True
        '
        'txt_search
        '
        Me.txt_search.Lines = New String(-1) {}
        Me.txt_search.Location = New System.Drawing.Point(3, 11)
        Me.txt_search.MaxLength = 32767
        Me.txt_search.Name = "txt_search"
        Me.txt_search.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_search.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_search.SelectedText = ""
        Me.txt_search.Size = New System.Drawing.Size(487, 23)
        Me.txt_search.TabIndex = 0
        Me.txt_search.UseSelectable = True
        '
        'btn_reset
        '
        Me.btn_reset.Location = New System.Drawing.Point(3, 61)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(75, 23)
        Me.btn_reset.TabIndex = 5
        Me.btn_reset.Text = "Reset"
        Me.btn_reset.UseSelectable = True
        '
        'radio_searchopendocuments
        '
        Me.radio_searchopendocuments.AutoSize = True
        Me.radio_searchopendocuments.Checked = True
        Me.radio_searchopendocuments.Location = New System.Drawing.Point(3, 40)
        Me.radio_searchopendocuments.Name = "radio_searchopendocuments"
        Me.radio_searchopendocuments.Size = New System.Drawing.Size(166, 15)
        Me.radio_searchopendocuments.TabIndex = 1
        Me.radio_searchopendocuments.TabStop = True
        Me.radio_searchopendocuments.Text = "Search all open documents"
        Me.radio_searchopendocuments.UseSelectable = True
        '
        'radio_searchdocumentsinproject
        '
        Me.radio_searchdocumentsinproject.AutoSize = True
        Me.radio_searchdocumentsinproject.BackColor = System.Drawing.SystemColors.Control
        Me.radio_searchdocumentsinproject.Location = New System.Drawing.Point(175, 40)
        Me.radio_searchdocumentsinproject.Name = "radio_searchdocumentsinproject"
        Me.radio_searchdocumentsinproject.Size = New System.Drawing.Size(189, 15)
        Me.radio_searchdocumentsinproject.TabIndex = 2
        Me.radio_searchdocumentsinproject.Text = "Search all documents in project"
        Me.radio_searchdocumentsinproject.UseSelectable = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.check_incrementalsearch)
        Me.Panel1.Controls.Add(Me.check_casesensitive)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txt_search)
        Me.Panel1.Controls.Add(Me.radio_searchdocumentsinproject)
        Me.Panel1.Controls.Add(Me.btn_reset)
        Me.Panel1.Controls.Add(Me.btn_search)
        Me.Panel1.Controls.Add(Me.radio_searchopendocuments)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(681, 114)
        Me.Panel1.TabIndex = 7
        '
        'check_incrementalsearch
        '
        Me.check_incrementalsearch.AutoSize = True
        Me.check_incrementalsearch.Checked = True
        Me.check_incrementalsearch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.check_incrementalsearch.Location = New System.Drawing.Point(472, 61)
        Me.check_incrementalsearch.Name = "check_incrementalsearch"
        Me.check_incrementalsearch.Size = New System.Drawing.Size(124, 15)
        Me.check_incrementalsearch.TabIndex = 9
        Me.check_incrementalsearch.Text = "Incremental Search"
        Me.check_incrementalsearch.UseSelectable = True
        '
        'check_casesensitive
        '
        Me.check_casesensitive.AutoSize = True
        Me.check_casesensitive.Location = New System.Drawing.Point(472, 40)
        Me.check_casesensitive.Name = "check_casesensitive"
        Me.check_casesensitive.Size = New System.Drawing.Size(97, 15)
        Me.check_casesensitive.TabIndex = 3
        Me.check_casesensitive.Text = "Case Sensitive"
        Me.check_casesensitive.UseSelectable = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Search Results:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lb_results)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 114)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(681, 410)
        Me.Panel2.TabIndex = 8
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Nothing
        '
        'Tab_UniversalSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 524)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_UniversalSearch"
        Me.ShowInTaskbar = False
        Me.Text = "Universal Search"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lb_results As System.Windows.Forms.ListBox
    Friend WithEvents ContextMenuStrip1 As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents btn_search As MetroFramework.Controls.MetroButton
    Friend WithEvents txt_search As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btn_reset As MetroFramework.Controls.MetroButton
    Friend WithEvents radio_searchopendocuments As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents radio_searchdocumentsinproject As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GoToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents check_casesensitive As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemoveFromSearchResultsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents check_incrementalsearch As MetroFramework.Controls.MetroCheckBox
End Class

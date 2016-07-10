<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_FileHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_FileHistory))
        Me.lbHistory = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenInEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClearHistory = New MetroFramework.Controls.MetroButton()
        Me.btnOpenInEditor = New MetroFramework.Controls.MetroButton()
        Me.btnRemoveSelected = New MetroFramework.Controls.MetroButton()
        Me.txtSearch = New MetroFramework.Controls.MetroTextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbHistory
        '
        Me.lbHistory.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lbHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHistory.FormattingEnabled = True
        Me.lbHistory.ItemHeight = 16
        Me.lbHistory.Location = New System.Drawing.Point(0, 23)
        Me.lbHistory.Name = "lbHistory"
        Me.lbHistory.Size = New System.Drawing.Size(489, 371)
        Me.lbHistory.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem, Me.ToolStripSeparator2, Me.OpenInEditorToolStripMenuItem, Me.ToolStripSeparator1, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(151, 82)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(147, 6)
        '
        'OpenInEditorToolStripMenuItem
        '
        Me.OpenInEditorToolStripMenuItem.Name = "OpenInEditorToolStripMenuItem"
        Me.OpenInEditorToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.OpenInEditorToolStripMenuItem.Text = "Open in Editor"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(147, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.btnClearHistory)
        Me.Panel1.Controls.Add(Me.btnOpenInEditor)
        Me.Panel1.Controls.Add(Me.btnRemoveSelected)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(489, 23)
        Me.Panel1.TabIndex = 4
        '
        'btnClearHistory
        '
        Me.btnClearHistory.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnClearHistory.Location = New System.Drawing.Point(247, 0)
        Me.btnClearHistory.Name = "btnClearHistory"
        Me.btnClearHistory.Size = New System.Drawing.Size(91, 23)
        Me.btnClearHistory.TabIndex = 7
        Me.btnClearHistory.Text = "Clear History"
        Me.btnClearHistory.UseSelectable = True
        '
        'btnOpenInEditor
        '
        Me.btnOpenInEditor.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnOpenInEditor.Location = New System.Drawing.Point(109, 0)
        Me.btnOpenInEditor.Name = "btnOpenInEditor"
        Me.btnOpenInEditor.Size = New System.Drawing.Size(138, 23)
        Me.btnOpenInEditor.TabIndex = 5
        Me.btnOpenInEditor.Text = "Open Selected in Editor"
        Me.btnOpenInEditor.UseSelectable = True
        '
        'btnRemoveSelected
        '
        Me.btnRemoveSelected.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnRemoveSelected.Location = New System.Drawing.Point(0, 0)
        Me.btnRemoveSelected.Name = "btnRemoveSelected"
        Me.btnRemoveSelected.Size = New System.Drawing.Size(109, 23)
        Me.btnRemoveSelected.TabIndex = 8
        Me.btnRemoveSelected.Text = "Remove Selected"
        Me.btnRemoveSelected.UseSelectable = True
        '
        'txtSearch
        '
        Me.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearch.Lines = New String(-1) {}
        Me.txtSearch.Location = New System.Drawing.Point(338, 0)
        Me.txtSearch.MaxLength = 32767
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSearch.PromptText = "Search"
        Me.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSearch.SelectedText = ""
        Me.txtSearch.Size = New System.Drawing.Size(151, 23)
        Me.txtSearch.TabIndex = 9
        Me.txtSearch.UseSelectable = True
        '
        'Tab_FileHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 394)
        Me.Controls.Add(Me.lbHistory)
        Me.Controls.Add(Me.Panel1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_FileHistory"
        Me.Text = "File History"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbHistory As System.Windows.Forms.ListBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnRemoveSelected As MetroFramework.Controls.MetroButton
    Friend WithEvents btnClearHistory As MetroFramework.Controls.MetroButton
    Friend WithEvents btnOpenInEditor As MetroFramework.Controls.MetroButton
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenInEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSearch As MetroFramework.Controls.MetroTextBox
End Class

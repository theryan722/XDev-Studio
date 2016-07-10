<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_CodeBank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_CodeBank))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip_Listbox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenInNewEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenInNewNotepadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip_Textbox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveChangesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenInNewEditorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenInNewNotepadToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenSelectionInNewEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSelectionInNewNotepadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_newfile = New MetroFramework.Controls.MetroTextBox()
        Me.btn_addnewfile = New MetroFramework.Controls.MetroButton()
        Me.btn_savechanges = New MetroFramework.Controls.MetroButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip_Listbox.SuspendLayout()
        Me.ContextMenuStrip_Textbox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListBox1)
        Me.SplitContainer1.Panel1MinSize = 10
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(490, 445)
        Me.SplitContainer1.SplitterDistance = 120
        Me.SplitContainer1.TabIndex = 0
        '
        'ListBox1
        '
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip_Listbox
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 445)
        Me.ListBox1.TabIndex = 0
        '
        'ContextMenuStrip_Listbox
        '
        Me.ContextMenuStrip_Listbox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.ToolStripSeparator1, Me.CopyToolStripMenuItem, Me.ToolStripSeparator2, Me.OpenInNewEditorToolStripMenuItem, Me.OpenInNewNotepadToolStripMenuItem})
        Me.ContextMenuStrip_Listbox.Name = "ContextMenuStrip_Listbox"
        Me.ContextMenuStrip_Listbox.Size = New System.Drawing.Size(191, 104)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(187, 6)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(187, 6)
        '
        'OpenInNewEditorToolStripMenuItem
        '
        Me.OpenInNewEditorToolStripMenuItem.Name = "OpenInNewEditorToolStripMenuItem"
        Me.OpenInNewEditorToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.OpenInNewEditorToolStripMenuItem.Text = "Open in new Editor"
        '
        'OpenInNewNotepadToolStripMenuItem
        '
        Me.OpenInNewNotepadToolStripMenuItem.Name = "OpenInNewNotepadToolStripMenuItem"
        Me.OpenInNewNotepadToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.OpenInNewNotepadToolStripMenuItem.Text = "Open in new Notepad"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TextBox1.ContextMenuStrip = Me.ContextMenuStrip_Textbox
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(0, 62)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(366, 383)
        Me.TextBox1.TabIndex = 1
        '
        'ContextMenuStrip_Textbox
        '
        Me.ContextMenuStrip_Textbox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveChangesToolStripMenuItem, Me.ToolStripSeparator6, Me.CopyToolStripMenuItem1, Me.CopyAllToolStripMenuItem, Me.SelectAllToolStripMenuItem, Me.CutToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator3, Me.UndoToolStripMenuItem, Me.FontToolStripMenuItem, Me.ToolStripSeparator4, Me.OpenInNewEditorToolStripMenuItem1, Me.OpenInNewNotepadToolStripMenuItem1, Me.ToolStripSeparator5, Me.OpenSelectionInNewEditorToolStripMenuItem, Me.OpenSelectionInNewNotepadToolStripMenuItem})
        Me.ContextMenuStrip_Textbox.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip_Textbox.Size = New System.Drawing.Size(241, 292)
        '
        'SaveChangesToolStripMenuItem
        '
        Me.SaveChangesToolStripMenuItem.Name = "SaveChangesToolStripMenuItem"
        Me.SaveChangesToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.SaveChangesToolStripMenuItem.Text = "Save Changes"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(237, 6)
        '
        'CopyToolStripMenuItem1
        '
        Me.CopyToolStripMenuItem1.Name = "CopyToolStripMenuItem1"
        Me.CopyToolStripMenuItem1.Size = New System.Drawing.Size(240, 22)
        Me.CopyToolStripMenuItem1.Text = "Copy"
        '
        'CopyAllToolStripMenuItem
        '
        Me.CopyAllToolStripMenuItem.Name = "CopyAllToolStripMenuItem"
        Me.CopyAllToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.CopyAllToolStripMenuItem.Text = "Copy All"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(237, 6)
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.FontToolStripMenuItem.Text = "Font"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(237, 6)
        '
        'OpenInNewEditorToolStripMenuItem1
        '
        Me.OpenInNewEditorToolStripMenuItem1.Name = "OpenInNewEditorToolStripMenuItem1"
        Me.OpenInNewEditorToolStripMenuItem1.Size = New System.Drawing.Size(240, 22)
        Me.OpenInNewEditorToolStripMenuItem1.Text = "Open in new Editor"
        '
        'OpenInNewNotepadToolStripMenuItem1
        '
        Me.OpenInNewNotepadToolStripMenuItem1.Name = "OpenInNewNotepadToolStripMenuItem1"
        Me.OpenInNewNotepadToolStripMenuItem1.Size = New System.Drawing.Size(240, 22)
        Me.OpenInNewNotepadToolStripMenuItem1.Text = "Open in new Notepad"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(237, 6)
        '
        'OpenSelectionInNewEditorToolStripMenuItem
        '
        Me.OpenSelectionInNewEditorToolStripMenuItem.Name = "OpenSelectionInNewEditorToolStripMenuItem"
        Me.OpenSelectionInNewEditorToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.OpenSelectionInNewEditorToolStripMenuItem.Text = "Open selection in new Editor"
        '
        'OpenSelectionInNewNotepadToolStripMenuItem
        '
        Me.OpenSelectionInNewNotepadToolStripMenuItem.Name = "OpenSelectionInNewNotepadToolStripMenuItem"
        Me.OpenSelectionInNewNotepadToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.OpenSelectionInNewNotepadToolStripMenuItem.Text = "Open selection in new Notepad"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btn_savechanges)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(366, 62)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txt_newfile)
        Me.Panel2.Controls.Add(Me.btn_addnewfile)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(366, 24)
        Me.Panel2.TabIndex = 4
        '
        'txt_newfile
        '
        Me.txt_newfile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_newfile.Lines = New String(-1) {}
        Me.txt_newfile.Location = New System.Drawing.Point(0, 0)
        Me.txt_newfile.MaxLength = 32767
        Me.txt_newfile.Name = "txt_newfile"
        Me.txt_newfile.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_newfile.PromptText = "File Name"
        Me.txt_newfile.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_newfile.SelectedText = ""
        Me.txt_newfile.Size = New System.Drawing.Size(272, 24)
        Me.txt_newfile.TabIndex = 2
        Me.txt_newfile.UseSelectable = True
        '
        'btn_addnewfile
        '
        Me.btn_addnewfile.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_addnewfile.Location = New System.Drawing.Point(272, 0)
        Me.btn_addnewfile.Name = "btn_addnewfile"
        Me.btn_addnewfile.Size = New System.Drawing.Size(94, 24)
        Me.btn_addnewfile.TabIndex = 1
        Me.btn_addnewfile.Text = "Add New File"
        Me.btn_addnewfile.UseSelectable = True
        '
        'btn_savechanges
        '
        Me.btn_savechanges.Location = New System.Drawing.Point(3, 36)
        Me.btn_savechanges.Name = "btn_savechanges"
        Me.btn_savechanges.Size = New System.Drawing.Size(132, 23)
        Me.btn_savechanges.TabIndex = 3
        Me.btn_savechanges.Text = "Save changes to file"
        Me.btn_savechanges.UseSelectable = True
        '
        'Tab_CodeBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 445)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_CodeBank"
        Me.Text = "CodeBank"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip_Listbox.ResumeLayout(False)
        Me.ContextMenuStrip_Textbox.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip_Listbox As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuStrip_Textbox As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btn_savechanges As MetroFramework.Controls.MetroButton
    Friend WithEvents txt_newfile As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btn_addnewfile As MetroFramework.Controls.MetroButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenInNewEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenInNewNotepadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenInNewEditorToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenInNewNotepadToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenSelectionInNewEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenSelectionInNewNotepadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveChangesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_NetConverter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_NetConverter))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConvertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CToVBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromClipboardToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VBToCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromFileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XEditor1 = New XDev.Editor.XEditor()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenInEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConvertToolStripMenuItem, Me.ClearToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(617, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConvertToolStripMenuItem
        '
        Me.ConvertToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CToVBToolStripMenuItem, Me.VBToCToolStripMenuItem})
        Me.ConvertToolStripMenuItem.Name = "ConvertToolStripMenuItem"
        Me.ConvertToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ConvertToolStripMenuItem.Text = "Convert"
        '
        'CToVBToolStripMenuItem
        '
        Me.CToVBToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromFileToolStripMenuItem, Me.FromClipboardToolStripMenuItem1})
        Me.CToVBToolStripMenuItem.Name = "CToVBToolStripMenuItem"
        Me.CToVBToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CToVBToolStripMenuItem.Text = "C# to VB"
        '
        'FromFileToolStripMenuItem
        '
        Me.FromFileToolStripMenuItem.Name = "FromFileToolStripMenuItem"
        Me.FromFileToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.FromFileToolStripMenuItem.Text = "From File"
        '
        'FromClipboardToolStripMenuItem1
        '
        Me.FromClipboardToolStripMenuItem1.Name = "FromClipboardToolStripMenuItem1"
        Me.FromClipboardToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.FromClipboardToolStripMenuItem1.Text = "From Clipboard"
        '
        'VBToCToolStripMenuItem
        '
        Me.VBToCToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromFileToolStripMenuItem1, Me.FromClipboardToolStripMenuItem})
        Me.VBToCToolStripMenuItem.Name = "VBToCToolStripMenuItem"
        Me.VBToCToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.VBToCToolStripMenuItem.Text = "VB to C#"
        '
        'FromFileToolStripMenuItem1
        '
        Me.FromFileToolStripMenuItem1.Name = "FromFileToolStripMenuItem1"
        Me.FromFileToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.FromFileToolStripMenuItem1.Text = "From File"
        '
        'FromClipboardToolStripMenuItem
        '
        Me.FromClipboardToolStripMenuItem.Name = "FromClipboardToolStripMenuItem"
        Me.FromClipboardToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.FromClipboardToolStripMenuItem.Text = "From Clipboard"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'XEditor1
        '
        Me.XEditor1.AutoComplete = False
        Me.XEditor1.CaretStyle = ScintillaNET.CaretStyle.Line
        Me.XEditor1.ClipboardHistory = CType(resources.GetObject("XEditor1.ClipboardHistory"), System.Collections.Generic.List(Of String))
        Me.XEditor1.CodeTemplates = Nothing
        Me.XEditor1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.XEditor1.CurrentPosition = 0
        Me.XEditor1.CustomLanguageEnabled = False
        Me.XEditor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XEditor1.EditorAllowDrop = True
        Me.XEditor1.EditorMode = XDev.Editor.XEditor.Mode.Editor
        Me.XEditor1.EndAtLastLine = True
        Me.XEditor1.EolMode = ScintillaNET.Eol.CrLf
        Me.XEditor1.FontQuality = ScintillaNET.FontQuality.[Default]
        Me.XEditor1.Font = New Font("Consolas", 10)
        Me.XEditor1.HighlightCurrentBlock = False
        Me.XEditor1.HighlightCurrentLine = False
        Me.XEditor1.HighlightMatchingSelection = False
        Me.XEditor1.HighlightMatchingWords = False
        Me.XEditor1.HomeEndKeysNavigateWrappedLines = False
        Me.XEditor1.HScrollBar = True
        Me.XEditor1.IndentationGuides = ScintillaNET.IndentView.None
        Me.XEditor1.IndentWidth = 0
        Me.XEditor1.IsReadOnly = False
        Me.XEditor1.Language = XDev.Editor.Language.EditorLanguage.PlainText
        Me.XEditor1.Lexer = ScintillaNET.Lexer.Container
        Me.XEditor1.Location = New System.Drawing.Point(0, 37)
        Me.XEditor1.MatchBraces = True
        Me.XEditor1.MouseDwellTime = 10000000
        Me.XEditor1.MouseSelectionRectangularSwitch = False
        Me.XEditor1.MultiPaste = ScintillaNET.MultiPaste.Once
        Me.XEditor1.MultipleSelection = False
        Me.XEditor1.MultiSelectionTyping = False
        Me.XEditor1.Name = "XEditor1"
        Me.XEditor1.OverType = False
        Me.XEditor1.PasteConvertEndings = True
        Me.XEditor1.PerformanceMode = False
        Me.XEditor1.RecordClipboardHistory = True
        Me.XEditor1.Saved = False
        Me.XEditor1.SelectedText = ""
        Me.XEditor1.Size = New System.Drawing.Size(617, 406)
        Me.XEditor1.SmartCompletion = False
        Me.XEditor1.SmartCopy = False
        Me.XEditor1.SmartIndentation = False
        Me.XEditor1.SmartPaste = False
        Me.XEditor1.TabIndex = 1
        Me.XEditor1.TabTriggers = Nothing
        Me.XEditor1.TabTriggersEnabled = False
        Me.XEditor1.TabTriggersReplacePhrase = True
        Me.XEditor1.TabWidth = 4
        Me.XEditor1.Technology = ScintillaNET.Technology.[Default]
        Me.XEditor1.UseTabs = False
        Me.XEditor1.ViewEol = False
        Me.XEditor1.ViewWhitespace = ScintillaNET.WhitespaceMode.Invisible
        Me.XEditor1.VScrollBar = True
        Me.XEditor1.WrapIndentMode = ScintillaNET.WrapIndentMode.Fixed
        Me.XEditor1.WrapMode = ScintillaNET.WrapMode.None
        Me.XEditor1.Zoom = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.CopyAllToolStripMenuItem, Me.OpenInEditorToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(151, 70)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'CopyAllToolStripMenuItem
        '
        Me.CopyAllToolStripMenuItem.Name = "CopyAllToolStripMenuItem"
        Me.CopyAllToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CopyAllToolStripMenuItem.Text = "Copy All"
        '
        'OpenInEditorToolStripMenuItem
        '
        Me.OpenInEditorToolStripMenuItem.Name = "OpenInEditorToolStripMenuItem"
        Me.OpenInEditorToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.OpenInEditorToolStripMenuItem.Text = "Open in Editor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Converted Code:"
        '
        'Tab_NetConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 443)
        Me.Controls.Add(Me.XEditor1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Tab_NetConverter"
        Me.ShowInTaskbar = False
        Me.Text = ".Net Converter"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ConvertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CToVBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FromFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FromClipboardToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VBToCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FromFileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FromClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XEditor1 As XDev.Editor.XEditor
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenInEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class

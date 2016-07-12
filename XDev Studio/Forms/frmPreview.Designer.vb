<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreview))
        Me.ContextMenuStrip1 = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.ClosePreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.TextBox1 = New XDev.Editor.XEditor()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClosePreviewToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(148, 26)
        '
        'ClosePreviewToolStripMenuItem
        '
        Me.ClosePreviewToolStripMenuItem.Name = "ClosePreviewToolStripMenuItem"
        Me.ClosePreviewToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ClosePreviewToolStripMenuItem.Text = "Close Preview"
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Nothing
        '
        'TextBox1
        '
        Me.TextBox1.AutoComplete = False
        Me.TextBox1.Font = New Font("Consolas", 10)
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Text = ""
        Me.TextBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TextBox1.EditorMode = XDev.Editor.XEditor.Mode.Editor
        Me.TextBox1.UseWaitCursor = False
        Me.TextBox1.EndAtLastLine = True
        Me.TextBox1.EolMode = ScintillaNET.Eol.CrLf
        Me.TextBox1.FontQuality = ScintillaNET.FontQuality.[Default]
        Me.TextBox1.HScrollBar = True
        Me.TextBox1.IndentationGuides = ScintillaNET.IndentView.None
        Me.TextBox1.IndentWidth = 0
        Me.TextBox1.IsReadOnly = True
        Me.TextBox1.RightToLeft = False
        Me.TextBox1.Language = XDev.Editor.Language.EditorLanguage.PlainText
        Me.TextBox1.Lexer = ScintillaNET.Lexer.Null
        Me.TextBox1.Location = New System.Drawing.Point(0, 60)
        Me.TextBox1.MatchBraces = True
        Me.TextBox1.MouseDwellTime = 10000000
        Me.TextBox1.MouseSelectionRectangularSwitch = False
        Me.TextBox1.MultiPaste = ScintillaNET.MultiPaste.Once
        Me.TextBox1.MultipleSelection = False
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OverType = False
        Me.TextBox1.PasteConvertEndings = True
        Me.TextBox1.Saved = False
        Me.TextBox1.Size = New System.Drawing.Size(621, 312)
        Me.TextBox1.SmartCompletion = False
        Me.TextBox1.SmartIndentation = False
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.TabWidth = 4
        Me.TextBox1.Technology = ScintillaNET.Technology.[Default]
        Me.TextBox1.UseTabs = True
        Me.TextBox1.ViewEol = False
        Me.TextBox1.ViewWhitespace = ScintillaNET.WhitespaceMode.Invisible
        Me.TextBox1.VScrollBar = True
        Me.TextBox1.WrapIndentMode = ScintillaNET.WrapIndentMode.Fixed
        Me.TextBox1.WrapMode = ScintillaNET.WrapMode.None
        Me.TextBox1.Zoom = 0
        '
        'frmPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 372)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.TextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPreview"
        Me.Padding = New System.Windows.Forms.Padding(0, 60, 0, 0)
        Me.ShowInTaskbar = False
        Me.Text = "Preview"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    'Friend WithEvents TextBox1 As ScintillaNET.Scintilla
    Friend WithEvents ContextMenuStrip1 As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents ClosePreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
    Friend WithEvents TextBox1 As XDev.Editor.XEditor
End Class

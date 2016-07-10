<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_CodeRecovery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_CodeRecovery))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_clearallrecoveryfiles = New MetroFramework.Controls.MetroButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip_TextBox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenInNewEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenInNewNotepadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip_ListBox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip_TextBox.SuspendLayout()
        Me.ContextMenuStrip_ListBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btn_clearallrecoveryfiles)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(499, 68)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(337, 26)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Recovery files are snapshots of code/text that are stored in the event " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "somethin" & _
    "g goes wrong or there is dataloss."
        '
        'btn_clearallrecoveryfiles
        '
        Me.btn_clearallrecoveryfiles.Location = New System.Drawing.Point(3, 38)
        Me.btn_clearallrecoveryfiles.Name = "btn_clearallrecoveryfiles"
        Me.btn_clearallrecoveryfiles.Size = New System.Drawing.Size(134, 23)
        Me.btn_clearallrecoveryfiles.TabIndex = 3
        Me.btn_clearallrecoveryfiles.Text = "Clear All Recovery Files"
        Me.btn_clearallrecoveryfiles.UseSelectable = True
        '
        'TextBox1
        '
        Me.TextBox1.ContextMenuStrip = Me.ContextMenuStrip_TextBox
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(0, 152)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(499, 250)
        Me.TextBox1.TabIndex = 1
        '
        'ContextMenuStrip_TextBox
        '
        Me.ContextMenuStrip_TextBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyAllToolStripMenuItem, Me.OpenInNewEditorToolStripMenuItem, Me.OpenInNewNotepadToolStripMenuItem})
        Me.ContextMenuStrip_TextBox.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip_TextBox.Size = New System.Drawing.Size(191, 70)
        '
        'CopyAllToolStripMenuItem
        '
        Me.CopyAllToolStripMenuItem.Name = "CopyAllToolStripMenuItem"
        Me.CopyAllToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.CopyAllToolStripMenuItem.Text = "Copy All"
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
        'ListBox1
        '
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip_ListBox
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(0, 68)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(499, 84)
        Me.ListBox1.TabIndex = 2
        '
        'ContextMenuStrip_ListBox
        '
        Me.ContextMenuStrip_ListBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.ToolStripSeparator1, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip_ListBox.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip_ListBox.Size = New System.Drawing.Size(114, 54)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
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
        'Tab_CodeRecovery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 402)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_CodeRecovery"
        Me.Text = "Code Recovery"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip_TextBox.ResumeLayout(False)
        Me.ContextMenuStrip_ListBox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btn_clearallrecoveryfiles As MetroFramework.Controls.MetroButton
    Friend WithEvents ContextMenuStrip_ListBox As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip_TextBox As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenInNewEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenInNewNotepadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class

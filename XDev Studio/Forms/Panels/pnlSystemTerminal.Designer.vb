<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pnlSystemTerminal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pnlSystemTerminal))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_command = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip_Command = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearRecentCommandsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt_output = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip_Output = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip_Command.SuspendLayout()
        Me.ContextMenuStrip_Output.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_command)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(559, 23)
        Me.Panel1.TabIndex = 0
        '
        'txt_command
        '
        Me.txt_command.BackColor = System.Drawing.SystemColors.Control
        Me.txt_command.ContextMenuStrip = Me.ContextMenuStrip_Command
        Me.txt_command.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_command.FormattingEnabled = True
        Me.txt_command.Location = New System.Drawing.Point(0, 0)
        Me.txt_command.Name = "txt_command"
        Me.txt_command.Size = New System.Drawing.Size(559, 21)
        Me.txt_command.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txt_command, "Enter commands here")
        '
        'ContextMenuStrip_Command
        '
        Me.ContextMenuStrip_Command.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InsertToolStripMenuItem, Me.CopyToolStripMenuItem1, Me.ClearRecentCommandsToolStripMenuItem})
        Me.ContextMenuStrip_Command.Name = "ContextMenuStrip_Command"
        Me.ContextMenuStrip_Command.Size = New System.Drawing.Size(206, 70)
        '
        'InsertToolStripMenuItem
        '
        Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.InsertToolStripMenuItem.Text = "Insert"
        '
        'CopyToolStripMenuItem1
        '
        Me.CopyToolStripMenuItem1.Name = "CopyToolStripMenuItem1"
        Me.CopyToolStripMenuItem1.Size = New System.Drawing.Size(205, 22)
        Me.CopyToolStripMenuItem1.Text = "Copy"
        '
        'ClearRecentCommandsToolStripMenuItem
        '
        Me.ClearRecentCommandsToolStripMenuItem.Name = "ClearRecentCommandsToolStripMenuItem"
        Me.ClearRecentCommandsToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ClearRecentCommandsToolStripMenuItem.Text = "Clear Recent Commands"
        '
        'txt_output
        '
        Me.txt_output.BackColor = System.Drawing.SystemColors.InfoText
        Me.txt_output.ContextMenuStrip = Me.ContextMenuStrip_Output
        Me.txt_output.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_output.ForeColor = System.Drawing.SystemColors.Window
        Me.txt_output.Location = New System.Drawing.Point(0, 23)
        Me.txt_output.Multiline = True
        Me.txt_output.Name = "txt_output"
        Me.txt_output.ReadOnly = True
        Me.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_output.Size = New System.Drawing.Size(559, 208)
        Me.txt_output.TabIndex = 1
        '
        'ContextMenuStrip_Output
        '
        Me.ContextMenuStrip_Output.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.CopyAllToolStripMenuItem})
        Me.ContextMenuStrip_Output.Name = "ContextMenuStrip_Output"
        Me.ContextMenuStrip_Output.Size = New System.Drawing.Size(120, 48)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'CopyAllToolStripMenuItem
        '
        Me.CopyAllToolStripMenuItem.Name = "CopyAllToolStripMenuItem"
        Me.CopyAllToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.CopyAllToolStripMenuItem.Text = "Copy All"
        '
        'pnlSystemTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 231)
        Me.Controls.Add(Me.txt_output)
        Me.Controls.Add(Me.Panel1)
        Me.DockAreas = CType(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "pnlSystemTerminal"
        Me.Text = "System Terminal"
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip_Command.ResumeLayout(False)
        Me.ContextMenuStrip_Output.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_output As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip_Command As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuStrip_Output As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents txt_command As System.Windows.Forms.ComboBox
    Friend WithEvents ClearRecentCommandsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class

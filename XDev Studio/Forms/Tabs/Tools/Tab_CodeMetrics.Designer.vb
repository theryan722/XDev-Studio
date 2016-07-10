<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_CodeMetrics
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_CodeMetrics))
        Me.txt_docloc = New MetroFramework.Controls.MetroTextBox()
        Me.btn_reset = New MetroFramework.Controls.MetroButton()
        Me.btn_browse = New MetroFramework.Controls.MetroButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnl_controls = New System.Windows.Forms.Panel()
        Me.btn_calculateproject = New MetroFramework.Controls.MetroButton()
        Me.btn_calculatedocument = New MetroFramework.Controls.MetroButton()
        Me.btn_copyclipboard = New MetroFramework.Controls.MetroButton()
        Me.btn_openinnotepad = New MetroFramework.Controls.MetroButton()
        Me.txt_output = New MetroFramework.Controls.MetroTextBox()
        Me.pnl_controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_docloc
        '
        Me.txt_docloc.Lines = New String(-1) {}
        Me.txt_docloc.Location = New System.Drawing.Point(6, 25)
        Me.txt_docloc.MaxLength = 32767
        Me.txt_docloc.Name = "txt_docloc"
        Me.txt_docloc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_docloc.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_docloc.SelectedText = ""
        Me.txt_docloc.Size = New System.Drawing.Size(251, 23)
        Me.txt_docloc.TabIndex = 0
        Me.txt_docloc.UseSelectable = True
        '
        'btn_reset
        '
        Me.btn_reset.Location = New System.Drawing.Point(6, 54)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(75, 23)
        Me.btn_reset.TabIndex = 3
        Me.btn_reset.Text = "Reset"
        Me.btn_reset.UseSelectable = True
        '
        'btn_browse
        '
        Me.btn_browse.Location = New System.Drawing.Point(263, 25)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(49, 23)
        Me.btn_browse.TabIndex = 1
        Me.btn_browse.Text = "Browse"
        Me.btn_browse.UseSelectable = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Document Location:"
        '
        'pnl_controls
        '
        Me.pnl_controls.Controls.Add(Me.btn_calculateproject)
        Me.pnl_controls.Controls.Add(Me.btn_calculatedocument)
        Me.pnl_controls.Controls.Add(Me.btn_copyclipboard)
        Me.pnl_controls.Controls.Add(Me.btn_openinnotepad)
        Me.pnl_controls.Controls.Add(Me.Label1)
        Me.pnl_controls.Controls.Add(Me.btn_reset)
        Me.pnl_controls.Controls.Add(Me.btn_browse)
        Me.pnl_controls.Controls.Add(Me.txt_docloc)
        Me.pnl_controls.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_controls.Location = New System.Drawing.Point(0, 359)
        Me.pnl_controls.Name = "pnl_controls"
        Me.pnl_controls.Size = New System.Drawing.Size(559, 87)
        Me.pnl_controls.TabIndex = 4
        '
        'btn_calculateproject
        '
        Me.btn_calculateproject.Location = New System.Drawing.Point(329, 54)
        Me.btn_calculateproject.Name = "btn_calculateproject"
        Me.btn_calculateproject.Size = New System.Drawing.Size(210, 23)
        Me.btn_calculateproject.TabIndex = 6
        Me.btn_calculateproject.Text = "Calculate Code Metrics for Project"
        Me.btn_calculateproject.UseSelectable = True
        Me.btn_calculateproject.Visible = False
        '
        'btn_calculatedocument
        '
        Me.btn_calculatedocument.Location = New System.Drawing.Point(329, 25)
        Me.btn_calculatedocument.Name = "btn_calculatedocument"
        Me.btn_calculatedocument.Size = New System.Drawing.Size(210, 23)
        Me.btn_calculatedocument.TabIndex = 2
        Me.btn_calculatedocument.Text = "Calculate Code Metrics for Document"
        Me.btn_calculatedocument.UseSelectable = True
        '
        'btn_copyclipboard
        '
        Me.btn_copyclipboard.Location = New System.Drawing.Point(196, 54)
        Me.btn_copyclipboard.Name = "btn_copyclipboard"
        Me.btn_copyclipboard.Size = New System.Drawing.Size(116, 23)
        Me.btn_copyclipboard.TabIndex = 5
        Me.btn_copyclipboard.Text = "Copy to Clipboard"
        Me.btn_copyclipboard.UseSelectable = True
        '
        'btn_openinnotepad
        '
        Me.btn_openinnotepad.Location = New System.Drawing.Point(87, 54)
        Me.btn_openinnotepad.Name = "btn_openinnotepad"
        Me.btn_openinnotepad.Size = New System.Drawing.Size(103, 23)
        Me.btn_openinnotepad.TabIndex = 4
        Me.btn_openinnotepad.Text = "Open in Notepad"
        Me.btn_openinnotepad.UseSelectable = True
        '
        'txt_output
        '
        Me.txt_output.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_output.Lines = New String(-1) {}
        Me.txt_output.Location = New System.Drawing.Point(0, 0)
        Me.txt_output.MaxLength = 32767
        Me.txt_output.Multiline = True
        Me.txt_output.Name = "txt_output"
        Me.txt_output.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_output.ReadOnly = True
        Me.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_output.SelectedText = ""
        Me.txt_output.Size = New System.Drawing.Size(559, 359)
        Me.txt_output.TabIndex = 5
        Me.txt_output.UseSelectable = True
        '
        'Tab_CodeMetrics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 446)
        Me.Controls.Add(Me.txt_output)
        Me.Controls.Add(Me.pnl_controls)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_CodeMetrics"
        Me.ShowInTaskbar = False
        Me.Text = "Code Metrics"
        Me.pnl_controls.ResumeLayout(False)
        Me.pnl_controls.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_docloc As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btn_reset As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_browse As MetroFramework.Controls.MetroButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnl_controls As System.Windows.Forms.Panel
    Friend WithEvents btn_calculatedocument As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_copyclipboard As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_openinnotepad As MetroFramework.Controls.MetroButton
    Friend WithEvents txt_output As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btn_calculateproject As MetroFramework.Controls.MetroButton
End Class

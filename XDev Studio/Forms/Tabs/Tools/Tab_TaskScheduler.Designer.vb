<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_TaskScheduler
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_TaskScheduler))
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.lstSchedules = New System.Windows.Forms.ListBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.lblLabels_7 = New System.Windows.Forms.Label()
        Me.lblInfo_5 = New System.Windows.Forms.TextBox()
        Me.lblInfo_4 = New System.Windows.Forms.TextBox()
        Me.lblInfo_3 = New System.Windows.Forms.TextBox()
        Me.lblInfo_2 = New System.Windows.Forms.TextBox()
        Me.lblInfo_1 = New System.Windows.Forms.TextBox()
        Me.lblInfo_0 = New System.Windows.Forms.TextBox()
        Me.lblLabels_6 = New System.Windows.Forms.Label()
        Me.lblLabels_5 = New System.Windows.Forms.Label()
        Me.lblLabels_4 = New System.Windows.Forms.Label()
        Me.lblLabels_3 = New System.Windows.Forms.Label()
        Me.lblLabels_2 = New System.Windows.Forms.Label()
        Me.lblLabels_1 = New System.Windows.Forms.Label()
        Me.lblLabels_0 = New System.Windows.Forms.Label()
        Me.lstTasks = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New MetroFramework.Controls.MetroButton()
        Me.btnRunNow = New MetroFramework.Controls.MetroButton()
        Me.btnDelete = New MetroFramework.Controls.MetroButton()
        Me.btnProperties = New MetroFramework.Controls.MetroButton()
        Me.btnAdd = New MetroFramework.Controls.MetroButton()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunNowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Frame1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.lstSchedules)
        Me.Frame1.Controls.Add(Me.txtComments)
        Me.Frame1.Controls.Add(Me.lblLabels_7)
        Me.Frame1.Controls.Add(Me.lblInfo_5)
        Me.Frame1.Controls.Add(Me.lblInfo_4)
        Me.Frame1.Controls.Add(Me.lblInfo_3)
        Me.Frame1.Controls.Add(Me.lblInfo_2)
        Me.Frame1.Controls.Add(Me.lblInfo_1)
        Me.Frame1.Controls.Add(Me.lblInfo_0)
        Me.Frame1.Controls.Add(Me.lblLabels_6)
        Me.Frame1.Controls.Add(Me.lblLabels_5)
        Me.Frame1.Controls.Add(Me.lblLabels_4)
        Me.Frame1.Controls.Add(Me.lblLabels_3)
        Me.Frame1.Controls.Add(Me.lblLabels_2)
        Me.Frame1.Controls.Add(Me.lblLabels_1)
        Me.Frame1.Controls.Add(Me.lblLabels_0)
        Me.Frame1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(0, 117)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(422, 279)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        '
        'lstSchedules
        '
        Me.lstSchedules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSchedules.IntegralHeight = False
        Me.lstSchedules.Location = New System.Drawing.Point(86, 204)
        Me.lstSchedules.Name = "lstSchedules"
        Me.lstSchedules.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstSchedules.Size = New System.Drawing.Size(329, 68)
        Me.lstSchedules.TabIndex = 17
        '
        'txtComments
        '
        Me.txtComments.AcceptsReturn = True
        Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.BackColor = System.Drawing.SystemColors.Control
        Me.txtComments.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtComments.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtComments.Location = New System.Drawing.Point(86, 62)
        Me.txtComments.MaxLength = 0
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ReadOnly = True
        Me.txtComments.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(329, 47)
        Me.txtComments.TabIndex = 7
        '
        'lblLabels_7
        '
        Me.lblLabels_7.BackColor = System.Drawing.Color.Transparent
        Me.lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels_7.Location = New System.Drawing.Point(0, 204)
        Me.lblLabels_7.Name = "lblLabels_7"
        Me.lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabels_7.Size = New System.Drawing.Size(86, 13)
        Me.lblLabels_7.TabIndex = 16
        Me.lblLabels_7.Text = "Schedule:"
        Me.lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblInfo_5
        '
        Me.lblInfo_5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInfo_5.BackColor = System.Drawing.SystemColors.Control
        Me.lblInfo_5.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInfo_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInfo_5.Location = New System.Drawing.Point(86, 181)
        Me.lblInfo_5.Name = "lblInfo_5"
        Me.lblInfo_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInfo_5.Size = New System.Drawing.Size(329, 20)
        Me.lblInfo_5.TabIndex = 15
        '
        'lblInfo_4
        '
        Me.lblInfo_4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInfo_4.BackColor = System.Drawing.SystemColors.Control
        Me.lblInfo_4.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInfo_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInfo_4.Location = New System.Drawing.Point(86, 158)
        Me.lblInfo_4.Name = "lblInfo_4"
        Me.lblInfo_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInfo_4.Size = New System.Drawing.Size(329, 20)
        Me.lblInfo_4.TabIndex = 14
        '
        'lblInfo_3
        '
        Me.lblInfo_3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInfo_3.BackColor = System.Drawing.SystemColors.Control
        Me.lblInfo_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInfo_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInfo_3.Location = New System.Drawing.Point(86, 135)
        Me.lblInfo_3.Name = "lblInfo_3"
        Me.lblInfo_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInfo_3.Size = New System.Drawing.Size(329, 20)
        Me.lblInfo_3.TabIndex = 13
        '
        'lblInfo_2
        '
        Me.lblInfo_2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInfo_2.BackColor = System.Drawing.SystemColors.Control
        Me.lblInfo_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInfo_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInfo_2.Location = New System.Drawing.Point(86, 112)
        Me.lblInfo_2.Name = "lblInfo_2"
        Me.lblInfo_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInfo_2.Size = New System.Drawing.Size(329, 20)
        Me.lblInfo_2.TabIndex = 12
        '
        'lblInfo_1
        '
        Me.lblInfo_1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInfo_1.BackColor = System.Drawing.SystemColors.Control
        Me.lblInfo_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInfo_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInfo_1.Location = New System.Drawing.Point(86, 39)
        Me.lblInfo_1.Name = "lblInfo_1"
        Me.lblInfo_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInfo_1.Size = New System.Drawing.Size(329, 20)
        Me.lblInfo_1.TabIndex = 11
        '
        'lblInfo_0
        '
        Me.lblInfo_0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInfo_0.BackColor = System.Drawing.SystemColors.Control
        Me.lblInfo_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInfo_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInfo_0.Location = New System.Drawing.Point(86, 16)
        Me.lblInfo_0.Name = "lblInfo_0"
        Me.lblInfo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInfo_0.Size = New System.Drawing.Size(329, 20)
        Me.lblInfo_0.TabIndex = 10
        '
        'lblLabels_6
        '
        Me.lblLabels_6.BackColor = System.Drawing.Color.Transparent
        Me.lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels_6.Location = New System.Drawing.Point(-2, 185)
        Me.lblLabels_6.Name = "lblLabels_6"
        Me.lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabels_6.Size = New System.Drawing.Size(88, 13)
        Me.lblLabels_6.TabIndex = 9
        Me.lblLabels_6.Text = "Creator:"
        Me.lblLabels_6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLabels_5
        '
        Me.lblLabels_5.BackColor = System.Drawing.Color.Transparent
        Me.lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels_5.Location = New System.Drawing.Point(-2, 162)
        Me.lblLabels_5.Name = "lblLabels_5"
        Me.lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabels_5.Size = New System.Drawing.Size(88, 13)
        Me.lblLabels_5.TabIndex = 8
        Me.lblLabels_5.Text = "Next Runtime:"
        Me.lblLabels_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLabels_4
        '
        Me.lblLabels_4.BackColor = System.Drawing.Color.Transparent
        Me.lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels_4.Location = New System.Drawing.Point(-2, 139)
        Me.lblLabels_4.Name = "lblLabels_4"
        Me.lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabels_4.Size = New System.Drawing.Size(88, 13)
        Me.lblLabels_4.TabIndex = 6
        Me.lblLabels_4.Text = "Last Runtime:"
        Me.lblLabels_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLabels_3
        '
        Me.lblLabels_3.BackColor = System.Drawing.Color.Transparent
        Me.lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels_3.Location = New System.Drawing.Point(-2, 116)
        Me.lblLabels_3.Name = "lblLabels_3"
        Me.lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabels_3.Size = New System.Drawing.Size(88, 13)
        Me.lblLabels_3.TabIndex = 5
        Me.lblLabels_3.Text = "Flags:"
        Me.lblLabels_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLabels_2
        '
        Me.lblLabels_2.BackColor = System.Drawing.Color.Transparent
        Me.lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels_2.Location = New System.Drawing.Point(-2, 62)
        Me.lblLabels_2.Name = "lblLabels_2"
        Me.lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabels_2.Size = New System.Drawing.Size(88, 13)
        Me.lblLabels_2.TabIndex = 4
        Me.lblLabels_2.Text = "Comments:"
        Me.lblLabels_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLabels_1
        '
        Me.lblLabels_1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels_1.Location = New System.Drawing.Point(-2, 43)
        Me.lblLabels_1.Name = "lblLabels_1"
        Me.lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabels_1.Size = New System.Drawing.Size(88, 13)
        Me.lblLabels_1.TabIndex = 3
        Me.lblLabels_1.Text = "Command Line:"
        Me.lblLabels_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLabels_0
        '
        Me.lblLabels_0.BackColor = System.Drawing.Color.Transparent
        Me.lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels_0.Location = New System.Drawing.Point(-2, 20)
        Me.lblLabels_0.Name = "lblLabels_0"
        Me.lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabels_0.Size = New System.Drawing.Size(88, 13)
        Me.lblLabels_0.TabIndex = 2
        Me.lblLabels_0.Text = "Program File:"
        Me.lblLabels_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstTasks
        '
        Me.lstTasks.BackColor = System.Drawing.SystemColors.Window
        Me.lstTasks.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lstTasks.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstTasks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstTasks.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstTasks.IntegralHeight = False
        Me.lstTasks.Location = New System.Drawing.Point(0, 0)
        Me.lstTasks.Name = "lstTasks"
        Me.lstTasks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstTasks.Size = New System.Drawing.Size(338, 117)
        Me.lstTasks.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lstTasks)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(338, 117)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Controls.Add(Me.btnRunNow)
        Me.Panel2.Controls.Add(Me.btnDelete)
        Me.Panel2.Controls.Add(Me.btnProperties)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(338, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(84, 117)
        Me.Panel2.TabIndex = 4
        '
        'btnRefresh
        '
        Me.btnRefresh.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRefresh.Location = New System.Drawing.Point(0, 92)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(84, 23)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseSelectable = True
        '
        'btnRunNow
        '
        Me.btnRunNow.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRunNow.Location = New System.Drawing.Point(0, 69)
        Me.btnRunNow.Name = "btnRunNow"
        Me.btnRunNow.Size = New System.Drawing.Size(84, 23)
        Me.btnRunNow.TabIndex = 3
        Me.btnRunNow.Text = "Run Now"
        Me.btnRunNow.UseSelectable = True
        '
        'btnDelete
        '
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDelete.Location = New System.Drawing.Point(0, 46)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseSelectable = True
        '
        'btnProperties
        '
        Me.btnProperties.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnProperties.Location = New System.Drawing.Point(0, 23)
        Me.btnProperties.Name = "btnProperties"
        Me.btnProperties.Size = New System.Drawing.Size(84, 23)
        Me.btnProperties.TabIndex = 1
        Me.btnProperties.Text = "Properties"
        Me.btnProperties.UseSelectable = True
        '
        'btnAdd
        '
        Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAdd.Location = New System.Drawing.Point(0, 0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 23)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseSelectable = True
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.DefaultExt = "exe"
        Me.dlgOpenFile.Filter = "Applications (*.exe)|*.exe"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.PropertiesToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.RunNowToolStripMenuItem, Me.ToolStripSeparator1, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 142)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PropertiesToolStripMenuItem.Text = "Properties"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'RunNowToolStripMenuItem
        '
        Me.RunNowToolStripMenuItem.Name = "RunNowToolStripMenuItem"
        Me.RunNowToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RunNowToolStripMenuItem.Text = "Run Now"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'Tab_TaskScheduler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 396)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Frame1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_TaskScheduler"
        Me.Text = "Task Scheduler"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstSchedules As System.Windows.Forms.ListBox
    Public WithEvents txtComments As System.Windows.Forms.TextBox
    Public WithEvents lblLabels_7 As System.Windows.Forms.Label
    Public WithEvents lblInfo_5 As System.Windows.Forms.TextBox
    Public WithEvents lblInfo_4 As System.Windows.Forms.TextBox
    Public WithEvents lblInfo_3 As System.Windows.Forms.TextBox
    Public WithEvents lblInfo_2 As System.Windows.Forms.TextBox
    Public WithEvents lblInfo_1 As System.Windows.Forms.TextBox
    Public WithEvents lblInfo_0 As System.Windows.Forms.TextBox
    Public WithEvents lblLabels_6 As System.Windows.Forms.Label
    Public WithEvents lblLabels_5 As System.Windows.Forms.Label
    Public WithEvents lblLabels_4 As System.Windows.Forms.Label
    Public WithEvents lblLabels_3 As System.Windows.Forms.Label
    Public WithEvents lblLabels_2 As System.Windows.Forms.Label
    Public WithEvents lblLabels_1 As System.Windows.Forms.Label
    Public WithEvents lblLabels_0 As System.Windows.Forms.Label
    Public WithEvents lstTasks As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As MetroFramework.Controls.MetroButton
    Friend WithEvents btnRefresh As MetroFramework.Controls.MetroButton
    Friend WithEvents btnRunNow As MetroFramework.Controls.MetroButton
    Friend WithEvents btnDelete As MetroFramework.Controls.MetroButton
    Friend WithEvents btnProperties As MetroFramework.Controls.MetroButton
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunNowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class

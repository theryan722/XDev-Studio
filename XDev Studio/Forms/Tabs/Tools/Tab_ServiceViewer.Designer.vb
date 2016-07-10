<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_ServiceViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_ServiceViewer))
        Me.lvwServices = New System.Windows.Forms.ListView()
        Me.lchCaptions = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lchNames = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lchState = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdRefresh = New MetroFramework.Controls.MetroButton()
        Me.cmdStart = New MetroFramework.Controls.MetroButton()
        Me.cmdStop = New MetroFramework.Controls.MetroButton()
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvwServices
        '
        Me.lvwServices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lchCaptions, Me.lchNames, Me.lchState})
        Me.lvwServices.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvwServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwServices.FullRowSelect = True
        Me.lvwServices.GridLines = True
        Me.lvwServices.Location = New System.Drawing.Point(0, 0)
        Me.lvwServices.Name = "lvwServices"
        Me.lvwServices.Size = New System.Drawing.Size(604, 335)
        Me.lvwServices.TabIndex = 1
        Me.lvwServices.UseCompatibleStateImageBehavior = False
        Me.lvwServices.View = System.Windows.Forms.View.Details
        '
        'lchCaptions
        '
        Me.lchCaptions.Text = "Service"
        Me.lchCaptions.Width = 276
        '
        'lchNames
        '
        Me.lchNames.Text = "Real Names"
        Me.lchNames.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lchNames.Width = 136
        '
        'lchState
        '
        Me.lchState.Text = "State"
        Me.lchState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lchState.Width = 109
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StopToolStripMenuItem, Me.StartToolStripMenuItem, Me.ToolStripSeparator1, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(114, 76)
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.StartToolStripMenuItem.Text = "Start"
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Controls.Add(Me.cmdStart)
        Me.Panel1.Controls.Add(Me.cmdStop)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 335)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(604, 28)
        Me.Panel1.TabIndex = 2
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdRefresh.Location = New System.Drawing.Point(150, 0)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(454, 28)
        Me.cmdRefresh.TabIndex = 2
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseSelectable = True
        '
        'cmdStart
        '
        Me.cmdStart.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdStart.Location = New System.Drawing.Point(75, 0)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(75, 28)
        Me.cmdStart.TabIndex = 1
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseSelectable = True
        '
        'cmdStop
        '
        Me.cmdStop.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdStop.Location = New System.Drawing.Point(0, 0)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(75, 28)
        Me.cmdStop.TabIndex = 0
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseSelectable = True
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Nothing
        '
        'Tab_ServiceViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 363)
        Me.Controls.Add(Me.lvwServices)
        Me.Controls.Add(Me.Panel1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_ServiceViewer"
        Me.Text = "Service Viewer"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwServices As System.Windows.Forms.ListView
    Friend WithEvents lchCaptions As System.Windows.Forms.ColumnHeader
    Friend WithEvents lchNames As System.Windows.Forms.ColumnHeader
    Friend WithEvents lchState As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdRefresh As MetroFramework.Controls.MetroButton
    Friend WithEvents cmdStart As MetroFramework.Controls.MetroButton
    Friend WithEvents cmdStop As MetroFramework.Controls.MetroButton
    Friend WithEvents ContextMenuStrip1 As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents StopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_ProcessViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_ProcessViewer))
        Me.lvwProcesses = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_refresh = New MetroFramework.Controls.MetroButton()
        Me.btn_pause = New MetroFramework.Controls.MetroButton()
        Me.btn_resume = New MetroFramework.Controls.MetroButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwProcesses
        '
        Me.lvwProcesses.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvwProcesses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwProcesses.FullRowSelect = True
        Me.lvwProcesses.GridLines = True
        Me.lvwProcesses.Location = New System.Drawing.Point(0, 0)
        Me.lvwProcesses.Name = "lvwProcesses"
        Me.lvwProcesses.Size = New System.Drawing.Size(475, 426)
        Me.lvwProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwProcesses.TabIndex = 0
        Me.lvwProcesses.UseCompatibleStateImageBehavior = False
        Me.lvwProcesses.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Process"
        Me.ColumnHeader1.Width = 108
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Caption"
        Me.ColumnHeader3.Width = 141
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Responding"
        Me.ColumnHeader4.Width = 71
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Session ID"
        Me.ColumnHeader5.Width = 75
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Memory (K)"
        Me.ColumnHeader6.Width = 76
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_refresh)
        Me.Panel1.Controls.Add(Me.btn_pause)
        Me.Panel1.Controls.Add(Me.btn_resume)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 403)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(475, 23)
        Me.Panel1.TabIndex = 2
        '
        'btn_refresh
        '
        Me.btn_refresh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_refresh.Location = New System.Drawing.Point(99, 0)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(275, 23)
        Me.btn_refresh.TabIndex = 1
        Me.btn_refresh.Text = "Refresh"
        Me.btn_refresh.UseSelectable = True
        '
        'btn_pause
        '
        Me.btn_pause.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_pause.Location = New System.Drawing.Point(374, 0)
        Me.btn_pause.Name = "btn_pause"
        Me.btn_pause.Size = New System.Drawing.Size(101, 23)
        Me.btn_pause.TabIndex = 2
        Me.btn_pause.Text = "Pause Refresh"
        Me.btn_pause.UseSelectable = True
        '
        'btn_resume
        '
        Me.btn_resume.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_resume.Location = New System.Drawing.Point(0, 0)
        Me.btn_resume.Name = "btn_resume"
        Me.btn_resume.Size = New System.Drawing.Size(99, 23)
        Me.btn_resume.TabIndex = 0
        Me.btn_resume.Text = "Resume Refresh"
        Me.btn_resume.UseSelectable = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lvwProcesses)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(475, 426)
        Me.Panel2.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 7000
        '
        'Tab_ProcessViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 426)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_ProcessViewer"
        Me.ShowInTaskbar = False
        Me.Text = "Process Viewer"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwProcesses As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_refresh As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_pause As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_resume As MetroFramework.Controls.MetroButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class

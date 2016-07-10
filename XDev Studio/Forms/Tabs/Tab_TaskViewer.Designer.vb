<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_TaskViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_TaskViewer))
        Me.MetroTabControl1 = New MetroFramework.Controls.MetroTabControl()
        Me.Tab_Tasks = New System.Windows.Forms.TabPage()
        Me.listbox_taskstodo = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_refreshtodo = New MetroFramework.Controls.MetroButton()
        Me.btn_copytodo = New MetroFramework.Controls.MetroButton()
        Me.btn_marktodo = New MetroFramework.Controls.MetroButton()
        Me.btn_removetodo = New MetroFramework.Controls.MetroButton()
        Me.btn_addtodo = New MetroFramework.Controls.MetroButton()
        Me.Tab_CompleteTasks = New System.Windows.Forms.TabPage()
        Me.listbox_taskscomplete = New System.Windows.Forms.ListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_refreshcomplete = New MetroFramework.Controls.MetroButton()
        Me.btn_copycomplete = New MetroFramework.Controls.MetroButton()
        Me.btn_markcomplete = New MetroFramework.Controls.MetroButton()
        Me.btn_removecomplete = New MetroFramework.Controls.MetroButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.complete_contextmenu = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.RemoveTaskToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyTaskToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkTaskAsIncompleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.todo_contextmenu = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.RemoveTaskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyTaskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkTaskAsCompleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.MetroTabControl1.SuspendLayout()
        Me.Tab_Tasks.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Tab_CompleteTasks.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.complete_contextmenu.SuspendLayout()
        Me.todo_contextmenu.SuspendLayout()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroTabControl1
        '
        Me.MetroTabControl1.Controls.Add(Me.Tab_Tasks)
        Me.MetroTabControl1.Controls.Add(Me.Tab_CompleteTasks)
        Me.MetroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.MetroTabControl1.Name = "MetroTabControl1"
        Me.MetroTabControl1.SelectedIndex = 1
        Me.MetroTabControl1.Size = New System.Drawing.Size(710, 554)
        Me.MetroTabControl1.TabIndex = 2
        Me.MetroTabControl1.UseSelectable = True
        '
        'Tab_Tasks
        '
        Me.Tab_Tasks.Controls.Add(Me.listbox_taskstodo)
        Me.Tab_Tasks.Controls.Add(Me.Panel1)
        Me.Tab_Tasks.Location = New System.Drawing.Point(4, 38)
        Me.Tab_Tasks.Name = "Tab_Tasks"
        Me.Tab_Tasks.Size = New System.Drawing.Size(702, 512)
        Me.Tab_Tasks.TabIndex = 0
        Me.Tab_Tasks.Text = "Tasks"
        '
        'listbox_taskstodo
        '
        Me.listbox_taskstodo.ContextMenuStrip = Me.todo_contextmenu
        Me.listbox_taskstodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listbox_taskstodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listbox_taskstodo.FormattingEnabled = True
        Me.listbox_taskstodo.ItemHeight = 16
        Me.listbox_taskstodo.Location = New System.Drawing.Point(0, 0)
        Me.listbox_taskstodo.Name = "listbox_taskstodo"
        Me.listbox_taskstodo.ScrollAlwaysVisible = True
        Me.listbox_taskstodo.Size = New System.Drawing.Size(702, 489)
        Me.listbox_taskstodo.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_refreshtodo)
        Me.Panel1.Controls.Add(Me.btn_copytodo)
        Me.Panel1.Controls.Add(Me.btn_marktodo)
        Me.Panel1.Controls.Add(Me.btn_removetodo)
        Me.Panel1.Controls.Add(Me.btn_addtodo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 489)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(702, 23)
        Me.Panel1.TabIndex = 1
        '
        'btn_refreshtodo
        '
        Me.btn_refreshtodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_refreshtodo.Location = New System.Drawing.Point(225, 0)
        Me.btn_refreshtodo.Name = "btn_refreshtodo"
        Me.btn_refreshtodo.Size = New System.Drawing.Size(247, 23)
        Me.btn_refreshtodo.TabIndex = 3
        Me.btn_refreshtodo.Text = "Refresh"
        Me.btn_refreshtodo.UseSelectable = True
        '
        'btn_copytodo
        '
        Me.btn_copytodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_copytodo.Location = New System.Drawing.Point(150, 0)
        Me.btn_copytodo.Name = "btn_copytodo"
        Me.btn_copytodo.Size = New System.Drawing.Size(75, 23)
        Me.btn_copytodo.TabIndex = 4
        Me.btn_copytodo.Text = "Copy Task"
        Me.btn_copytodo.UseSelectable = True
        '
        'btn_marktodo
        '
        Me.btn_marktodo.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_marktodo.Location = New System.Drawing.Point(472, 0)
        Me.btn_marktodo.Name = "btn_marktodo"
        Me.btn_marktodo.Size = New System.Drawing.Size(230, 23)
        Me.btn_marktodo.TabIndex = 2
        Me.btn_marktodo.Text = "Mark task as Complete"
        Me.btn_marktodo.UseSelectable = True
        '
        'btn_removetodo
        '
        Me.btn_removetodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_removetodo.Location = New System.Drawing.Point(75, 0)
        Me.btn_removetodo.Name = "btn_removetodo"
        Me.btn_removetodo.Size = New System.Drawing.Size(75, 23)
        Me.btn_removetodo.TabIndex = 1
        Me.btn_removetodo.Text = "Remove Task"
        Me.btn_removetodo.UseSelectable = True
        '
        'btn_addtodo
        '
        Me.btn_addtodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_addtodo.Location = New System.Drawing.Point(0, 0)
        Me.btn_addtodo.Name = "btn_addtodo"
        Me.btn_addtodo.Size = New System.Drawing.Size(75, 23)
        Me.btn_addtodo.TabIndex = 0
        Me.btn_addtodo.Text = "Add Task"
        Me.btn_addtodo.UseSelectable = True
        '
        'Tab_CompleteTasks
        '
        Me.Tab_CompleteTasks.Controls.Add(Me.listbox_taskscomplete)
        Me.Tab_CompleteTasks.Controls.Add(Me.Panel2)
        Me.Tab_CompleteTasks.Location = New System.Drawing.Point(4, 38)
        Me.Tab_CompleteTasks.Name = "Tab_CompleteTasks"
        Me.Tab_CompleteTasks.Size = New System.Drawing.Size(702, 512)
        Me.Tab_CompleteTasks.TabIndex = 1
        Me.Tab_CompleteTasks.Text = "Complete Tasks"
        '
        'listbox_taskscomplete
        '
        Me.listbox_taskscomplete.ContextMenuStrip = Me.complete_contextmenu
        Me.listbox_taskscomplete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listbox_taskscomplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listbox_taskscomplete.FormattingEnabled = True
        Me.listbox_taskscomplete.ItemHeight = 16
        Me.listbox_taskscomplete.Location = New System.Drawing.Point(0, 0)
        Me.listbox_taskscomplete.Name = "listbox_taskscomplete"
        Me.listbox_taskscomplete.ScrollAlwaysVisible = True
        Me.listbox_taskscomplete.Size = New System.Drawing.Size(702, 489)
        Me.listbox_taskscomplete.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btn_refreshcomplete)
        Me.Panel2.Controls.Add(Me.btn_copycomplete)
        Me.Panel2.Controls.Add(Me.btn_markcomplete)
        Me.Panel2.Controls.Add(Me.btn_removecomplete)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 489)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(702, 23)
        Me.Panel2.TabIndex = 2
        '
        'btn_refreshcomplete
        '
        Me.btn_refreshcomplete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_refreshcomplete.Location = New System.Drawing.Point(150, 0)
        Me.btn_refreshcomplete.Name = "btn_refreshcomplete"
        Me.btn_refreshcomplete.Size = New System.Drawing.Size(322, 23)
        Me.btn_refreshcomplete.TabIndex = 3
        Me.btn_refreshcomplete.Text = "Refresh"
        Me.btn_refreshcomplete.UseSelectable = True
        '
        'btn_copycomplete
        '
        Me.btn_copycomplete.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_copycomplete.Location = New System.Drawing.Point(75, 0)
        Me.btn_copycomplete.Name = "btn_copycomplete"
        Me.btn_copycomplete.Size = New System.Drawing.Size(75, 23)
        Me.btn_copycomplete.TabIndex = 4
        Me.btn_copycomplete.Text = "Copy Task"
        Me.btn_copycomplete.UseSelectable = True
        '
        'btn_markcomplete
        '
        Me.btn_markcomplete.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_markcomplete.Location = New System.Drawing.Point(472, 0)
        Me.btn_markcomplete.Name = "btn_markcomplete"
        Me.btn_markcomplete.Size = New System.Drawing.Size(230, 23)
        Me.btn_markcomplete.TabIndex = 2
        Me.btn_markcomplete.Text = "Mark task as incomplete"
        Me.btn_markcomplete.UseSelectable = True
        '
        'btn_removecomplete
        '
        Me.btn_removecomplete.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_removecomplete.Location = New System.Drawing.Point(0, 0)
        Me.btn_removecomplete.Name = "btn_removecomplete"
        Me.btn_removecomplete.Size = New System.Drawing.Size(75, 23)
        Me.btn_removecomplete.TabIndex = 1
        Me.btn_removecomplete.Text = "Remove Task"
        Me.btn_removecomplete.UseSelectable = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "16_todo.png")
        Me.ImageList1.Images.SetKeyName(1, "16_complete.png")
        '
        'complete_contextmenu
        '
        Me.complete_contextmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveTaskToolStripMenuItem1, Me.CopyTaskToolStripMenuItem1, Me.MarkTaskAsIncompleteToolStripMenuItem})
        Me.complete_contextmenu.Name = "complete_contextmenu"
        Me.complete_contextmenu.Size = New System.Drawing.Size(203, 70)
        '
        'RemoveTaskToolStripMenuItem1
        '
        Me.RemoveTaskToolStripMenuItem1.Name = "RemoveTaskToolStripMenuItem1"
        Me.RemoveTaskToolStripMenuItem1.Size = New System.Drawing.Size(202, 22)
        Me.RemoveTaskToolStripMenuItem1.Text = "Remove Task"
        '
        'CopyTaskToolStripMenuItem1
        '
        Me.CopyTaskToolStripMenuItem1.Name = "CopyTaskToolStripMenuItem1"
        Me.CopyTaskToolStripMenuItem1.Size = New System.Drawing.Size(202, 22)
        Me.CopyTaskToolStripMenuItem1.Text = "Copy Task"
        '
        'MarkTaskAsIncompleteToolStripMenuItem
        '
        Me.MarkTaskAsIncompleteToolStripMenuItem.Name = "MarkTaskAsIncompleteToolStripMenuItem"
        Me.MarkTaskAsIncompleteToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.MarkTaskAsIncompleteToolStripMenuItem.Text = "Mark task as Incomplete"
        '
        'todo_contextmenu
        '
        Me.todo_contextmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveTaskToolStripMenuItem, Me.CopyTaskToolStripMenuItem, Me.MarkTaskAsCompleteToolStripMenuItem})
        Me.todo_contextmenu.Name = "todo_contextmenu"
        Me.todo_contextmenu.Size = New System.Drawing.Size(195, 70)
        '
        'RemoveTaskToolStripMenuItem
        '
        Me.RemoveTaskToolStripMenuItem.Name = "RemoveTaskToolStripMenuItem"
        Me.RemoveTaskToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.RemoveTaskToolStripMenuItem.Text = "Remove Task"
        '
        'CopyTaskToolStripMenuItem
        '
        Me.CopyTaskToolStripMenuItem.Name = "CopyTaskToolStripMenuItem"
        Me.CopyTaskToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.CopyTaskToolStripMenuItem.Text = "Copy Task"
        '
        'MarkTaskAsCompleteToolStripMenuItem
        '
        Me.MarkTaskAsCompleteToolStripMenuItem.Name = "MarkTaskAsCompleteToolStripMenuItem"
        Me.MarkTaskAsCompleteToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.MarkTaskAsCompleteToolStripMenuItem.Text = "Mark task as Complete"
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Nothing
        '
        'Tab_TaskViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 554)
        Me.Controls.Add(Me.MetroTabControl1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_TaskViewer"
        Me.ShowInTaskbar = False
        Me.Text = "Task Viewer"
        Me.MetroTabControl1.ResumeLayout(False)
        Me.Tab_Tasks.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Tab_CompleteTasks.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.complete_contextmenu.ResumeLayout(False)
        Me.todo_contextmenu.ResumeLayout(False)
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroTabControl1 As MetroFramework.Controls.MetroTabControl
    Friend WithEvents Tab_Tasks As System.Windows.Forms.TabPage
    Friend WithEvents listbox_taskstodo As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_refreshtodo As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_copytodo As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_marktodo As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_removetodo As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_addtodo As MetroFramework.Controls.MetroButton
    Friend WithEvents Tab_CompleteTasks As System.Windows.Forms.TabPage
    Friend WithEvents listbox_taskscomplete As System.Windows.Forms.ListBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_refreshcomplete As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_copycomplete As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_markcomplete As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_removecomplete As MetroFramework.Controls.MetroButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents complete_contextmenu As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents RemoveTaskToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyTaskToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkTaskAsIncompleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents todo_contextmenu As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents RemoveTaskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyTaskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkTaskAsCompleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
End Class

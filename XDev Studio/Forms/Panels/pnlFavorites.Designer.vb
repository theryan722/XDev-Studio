<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pnlFavorites
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pnlFavorites))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddFavoriteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFavoriteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.pnl_addfavorite = New System.Windows.Forms.Panel()
        Me.btn_cancel = New MetroFramework.Controls.MetroButton()
        Me.btn_add = New MetroFramework.Controls.MetroButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_fileloc = New MetroFramework.Controls.MetroTextBox()
        Me.btn_browse = New MetroFramework.Controls.MetroButton()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnl_addfavorite.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ToolStripSeparator1, Me.AddFavoriteToolStripMenuItem, Me.RemoveFavoriteToolStripMenuItem, Me.ToolStripSeparator2, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(163, 104)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(159, 6)
        '
        'AddFavoriteToolStripMenuItem
        '
        Me.AddFavoriteToolStripMenuItem.Name = "AddFavoriteToolStripMenuItem"
        Me.AddFavoriteToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.AddFavoriteToolStripMenuItem.Text = "Add Favorite"
        '
        'RemoveFavoriteToolStripMenuItem
        '
        Me.RemoveFavoriteToolStripMenuItem.Name = "RemoveFavoriteToolStripMenuItem"
        Me.RemoveFavoriteToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.RemoveFavoriteToolStripMenuItem.Text = "Remove Favorite"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(159, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ListBox1
        '
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(0, 46)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(239, 374)
        Me.ListBox1.TabIndex = 1
        '
        'pnl_addfavorite
        '
        Me.pnl_addfavorite.Controls.Add(Me.btn_cancel)
        Me.pnl_addfavorite.Controls.Add(Me.btn_add)
        Me.pnl_addfavorite.Controls.Add(Me.Panel1)
        Me.pnl_addfavorite.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_addfavorite.Location = New System.Drawing.Point(0, 0)
        Me.pnl_addfavorite.Name = "pnl_addfavorite"
        Me.pnl_addfavorite.Size = New System.Drawing.Size(239, 46)
        Me.pnl_addfavorite.TabIndex = 2
        Me.pnl_addfavorite.Visible = False
        '
        'btn_cancel
        '
        Me.btn_cancel.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_cancel.Location = New System.Drawing.Point(0, 23)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancel.TabIndex = 2
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseSelectable = True
        '
        'btn_add
        '
        Me.btn_add.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_add.Location = New System.Drawing.Point(164, 23)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 23)
        Me.btn_add.TabIndex = 1
        Me.btn_add.Text = "Add"
        Me.btn_add.UseSelectable = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_fileloc)
        Me.Panel1.Controls.Add(Me.btn_browse)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(239, 23)
        Me.Panel1.TabIndex = 4
        '
        'txt_fileloc
        '
        Me.txt_fileloc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_fileloc.Lines = New String(-1) {}
        Me.txt_fileloc.Location = New System.Drawing.Point(0, 0)
        Me.txt_fileloc.MaxLength = 32767
        Me.txt_fileloc.Name = "txt_fileloc"
        Me.txt_fileloc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_fileloc.PromptText = "File Location"
        Me.txt_fileloc.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_fileloc.SelectedText = ""
        Me.txt_fileloc.Size = New System.Drawing.Size(186, 23)
        Me.txt_fileloc.TabIndex = 0
        Me.txt_fileloc.UseSelectable = True
        '
        'btn_browse
        '
        Me.btn_browse.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_browse.Location = New System.Drawing.Point(186, 0)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(53, 23)
        Me.btn_browse.TabIndex = 3
        Me.btn_browse.Text = "Browse"
        Me.btn_browse.UseSelectable = True
        '
        'pnlFavorites
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(239, 420)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.pnl_addfavorite)
        Me.DockAreas = CType((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "pnlFavorites"
        Me.Text = "Favorites"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnl_addfavorite.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AddFavoriteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveFavoriteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnl_addfavorite As System.Windows.Forms.Panel
    Friend WithEvents btn_cancel As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_add As MetroFramework.Controls.MetroButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_fileloc As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btn_browse As MetroFramework.Controls.MetroButton
End Class

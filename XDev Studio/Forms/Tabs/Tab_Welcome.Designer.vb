<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_Welcome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_Welcome))
        Me.check_showatstartup = New MetroFramework.Controls.MetroCheckBox()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.label_title = New MetroFramework.Controls.MetroLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_bionetworkssupport = New MetroFramework.Controls.MetroButton()
        Me.btn_bionetworkshome = New MetroFramework.Controls.MetroButton()
        Me.btn_openfile = New MetroFramework.Controls.MetroButton()
        Me.btn_openproject = New MetroFramework.Controls.MetroButton()
        Me.btn_newfile = New MetroFramework.Controls.MetroButton()
        Me.btn_newproject = New MetroFramework.Controls.MetroButton()
        Me.Panel_RecentProjects = New System.Windows.Forms.Panel()
        Me.btn_clearrecentprojects = New MetroFramework.Controls.MetroButton()
        Me.listbox_recentprojects = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MetroPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel_RecentProjects.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'check_showatstartup
        '
        Me.check_showatstartup.AutoSize = True
        Me.check_showatstartup.Checked = True
        Me.check_showatstartup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.check_showatstartup.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.check_showatstartup.Location = New System.Drawing.Point(0, 520)
        Me.check_showatstartup.Name = "check_showatstartup"
        Me.check_showatstartup.Size = New System.Drawing.Size(200, 15)
        Me.check_showatstartup.TabIndex = 4
        Me.check_showatstartup.Text = "Show at Startup"
        Me.check_showatstartup.UseSelectable = True
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.label_title)
        Me.MetroPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(200, 0)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(401, 33)
        Me.MetroPanel1.TabIndex = 4
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'label_title
        '
        Me.label_title.AutoSize = True
        Me.label_title.Dock = System.Windows.Forms.DockStyle.Top
        Me.label_title.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.label_title.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.label_title.ForeColor = System.Drawing.Color.DarkCyan
        Me.label_title.Location = New System.Drawing.Point(0, 0)
        Me.label_title.Name = "label_title"
        Me.label_title.Size = New System.Drawing.Size(224, 25)
        Me.label_title.TabIndex = 1
        Me.label_title.Text = "Welcome to XDev Studio"
        Me.label_title.UseCustomForeColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.check_showatstartup)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btn_openfile)
        Me.Panel1.Controls.Add(Me.btn_openproject)
        Me.Panel1.Controls.Add(Me.btn_newfile)
        Me.Panel1.Controls.Add(Me.btn_newproject)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 558)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btn_bionetworkssupport)
        Me.Panel2.Controls.Add(Me.btn_bionetworkshome)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 535)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 23)
        Me.Panel2.TabIndex = 5
        '
        'btn_bionetworkssupport
        '
        Me.btn_bionetworkssupport.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_bionetworkssupport.Location = New System.Drawing.Point(100, 0)
        Me.btn_bionetworkssupport.Name = "btn_bionetworkssupport"
        Me.btn_bionetworkssupport.Size = New System.Drawing.Size(100, 23)
        Me.btn_bionetworkssupport.TabIndex = 1
        Me.btn_bionetworkssupport.Text = "Support"
        Me.btn_bionetworkssupport.UseSelectable = True
        '
        'btn_bionetworkshome
        '
        Me.btn_bionetworkshome.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_bionetworkshome.Location = New System.Drawing.Point(0, 0)
        Me.btn_bionetworkshome.Name = "btn_bionetworkshome"
        Me.btn_bionetworkshome.Size = New System.Drawing.Size(100, 23)
        Me.btn_bionetworkshome.TabIndex = 0
        Me.btn_bionetworkshome.Text = "Home"
        Me.btn_bionetworkshome.UseSelectable = True
        '
        'btn_openfile
        '
        Me.btn_openfile.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_openfile.Location = New System.Drawing.Point(0, 99)
        Me.btn_openfile.Name = "btn_openfile"
        Me.btn_openfile.Size = New System.Drawing.Size(200, 33)
        Me.btn_openfile.TabIndex = 3
        Me.btn_openfile.Text = "Open File"
        Me.btn_openfile.UseSelectable = True
        '
        'btn_openproject
        '
        Me.btn_openproject.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_openproject.Location = New System.Drawing.Point(0, 66)
        Me.btn_openproject.Name = "btn_openproject"
        Me.btn_openproject.Size = New System.Drawing.Size(200, 33)
        Me.btn_openproject.TabIndex = 2
        Me.btn_openproject.Text = "Open Project"
        Me.btn_openproject.UseSelectable = True
        '
        'btn_newfile
        '
        Me.btn_newfile.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_newfile.Location = New System.Drawing.Point(0, 33)
        Me.btn_newfile.Name = "btn_newfile"
        Me.btn_newfile.Size = New System.Drawing.Size(200, 33)
        Me.btn_newfile.TabIndex = 1
        Me.btn_newfile.Text = "New File"
        Me.btn_newfile.UseSelectable = True
        '
        'btn_newproject
        '
        Me.btn_newproject.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_newproject.Location = New System.Drawing.Point(0, 0)
        Me.btn_newproject.Name = "btn_newproject"
        Me.btn_newproject.Size = New System.Drawing.Size(200, 33)
        Me.btn_newproject.TabIndex = 0
        Me.btn_newproject.Text = "New Project"
        Me.btn_newproject.UseSelectable = True
        '
        'Panel_RecentProjects
        '
        Me.Panel_RecentProjects.Controls.Add(Me.btn_clearrecentprojects)
        Me.Panel_RecentProjects.Controls.Add(Me.listbox_recentprojects)
        Me.Panel_RecentProjects.Controls.Add(Me.Label1)
        Me.Panel_RecentProjects.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_RecentProjects.Location = New System.Drawing.Point(200, 33)
        Me.Panel_RecentProjects.Name = "Panel_RecentProjects"
        Me.Panel_RecentProjects.Size = New System.Drawing.Size(401, 159)
        Me.Panel_RecentProjects.TabIndex = 6
        '
        'btn_clearrecentprojects
        '
        Me.btn_clearrecentprojects.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_clearrecentprojects.Location = New System.Drawing.Point(0, 136)
        Me.btn_clearrecentprojects.Name = "btn_clearrecentprojects"
        Me.btn_clearrecentprojects.Size = New System.Drawing.Size(401, 23)
        Me.btn_clearrecentprojects.TabIndex = 1
        Me.btn_clearrecentprojects.Text = "Clear"
        Me.btn_clearrecentprojects.UseSelectable = True
        '
        'listbox_recentprojects
        '
        Me.listbox_recentprojects.Dock = System.Windows.Forms.DockStyle.Top
        Me.listbox_recentprojects.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listbox_recentprojects.FormattingEnabled = True
        Me.listbox_recentprojects.ItemHeight = 16
        Me.listbox_recentprojects.Location = New System.Drawing.Point(0, 15)
        Me.listbox_recentprojects.Name = "listbox_recentprojects"
        Me.listbox_recentprojects.Size = New System.Drawing.Size(401, 116)
        Me.listbox_recentprojects.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Recent Projects:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(200, 192)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(401, 366)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Tab_Welcome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(601, 558)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel_RecentProjects)
        Me.Controls.Add(Me.MetroPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_Welcome"
        Me.ShowInTaskbar = False
        Me.Text = "Welcome"
        Me.MetroPanel1.ResumeLayout(False)
        Me.MetroPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel_RecentProjects.ResumeLayout(False)
        Me.Panel_RecentProjects.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents check_showatstartup As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
    Friend WithEvents label_title As MetroFramework.Controls.MetroLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_bionetworkssupport As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_bionetworkshome As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_openfile As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_openproject As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_newfile As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_newproject As MetroFramework.Controls.MetroButton
    Friend WithEvents Panel_RecentProjects As System.Windows.Forms.Panel
    Friend WithEvents btn_clearrecentprojects As MetroFramework.Controls.MetroButton
    Friend WithEvents listbox_recentprojects As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class

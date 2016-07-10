<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XEditor))
        Me.Scintilla1 = New ScintillaNET.Scintilla()
        Me.pnl_incrementalsearcher = New System.Windows.Forms.Panel()
        Me.pnl_incrementalsearcher_toppanel = New System.Windows.Forms.Panel()
        Me.txt_incrementalsearcher = New System.Windows.Forms.TextBox()
        Me.btn_incrementalsearcher_down = New System.Windows.Forms.PictureBox()
        Me.btn_incrementalsearcher_up = New System.Windows.Forms.PictureBox()
        Me.btn_incrementalsearcher_close = New System.Windows.Forms.PictureBox()
        Me.pnl_snippetlist = New System.Windows.Forms.Panel()
        Me.listbox_snippetlist = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_closesnippetlist = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnl_incrementalsearcher.SuspendLayout()
        Me.pnl_incrementalsearcher_toppanel.SuspendLayout()
        CType(Me.btn_incrementalsearcher_down, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_incrementalsearcher_up, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_incrementalsearcher_close, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_snippetlist.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.btn_closesnippetlist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Scintilla1
        '
        Me.Scintilla1.AllowDrop = True
        Me.Scintilla1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Scintilla1.Location = New System.Drawing.Point(0, 0)
        Me.Scintilla1.Name = "Scintilla1"
        Me.Scintilla1.Size = New System.Drawing.Size(594, 431)
        Me.Scintilla1.TabIndex = 0
        Me.Scintilla1.UseTabs = False
        '
        'pnl_incrementalsearcher
        '
        Me.pnl_incrementalsearcher.Controls.Add(Me.pnl_incrementalsearcher_toppanel)
        Me.pnl_incrementalsearcher.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_incrementalsearcher.Location = New System.Drawing.Point(0, 431)
        Me.pnl_incrementalsearcher.Name = "pnl_incrementalsearcher"
        Me.pnl_incrementalsearcher.Size = New System.Drawing.Size(594, 23)
        Me.pnl_incrementalsearcher.TabIndex = 2
        Me.pnl_incrementalsearcher.Visible = False
        '
        'pnl_incrementalsearcher_toppanel
        '
        Me.pnl_incrementalsearcher_toppanel.Controls.Add(Me.txt_incrementalsearcher)
        Me.pnl_incrementalsearcher_toppanel.Controls.Add(Me.btn_incrementalsearcher_down)
        Me.pnl_incrementalsearcher_toppanel.Controls.Add(Me.btn_incrementalsearcher_up)
        Me.pnl_incrementalsearcher_toppanel.Controls.Add(Me.btn_incrementalsearcher_close)
        Me.pnl_incrementalsearcher_toppanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_incrementalsearcher_toppanel.Location = New System.Drawing.Point(0, 0)
        Me.pnl_incrementalsearcher_toppanel.Name = "pnl_incrementalsearcher_toppanel"
        Me.pnl_incrementalsearcher_toppanel.Size = New System.Drawing.Size(594, 23)
        Me.pnl_incrementalsearcher_toppanel.TabIndex = 5
        '
        'txt_incrementalsearcher
        '
        Me.txt_incrementalsearcher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_incrementalsearcher.Location = New System.Drawing.Point(0, 0)
        Me.txt_incrementalsearcher.Name = "txt_incrementalsearcher"
        Me.txt_incrementalsearcher.Size = New System.Drawing.Size(525, 23)
        Me.txt_incrementalsearcher.TabIndex = 3
        '
        'btn_incrementalsearcher_down
        '
        Me.btn_incrementalsearcher_down.BackgroundImage = CType(resources.GetObject("btn_incrementalsearcher_down.BackgroundImage"), System.Drawing.Image)
        Me.btn_incrementalsearcher_down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_incrementalsearcher_down.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_incrementalsearcher_down.Location = New System.Drawing.Point(525, 0)
        Me.btn_incrementalsearcher_down.Name = "btn_incrementalsearcher_down"
        Me.btn_incrementalsearcher_down.Size = New System.Drawing.Size(23, 23)
        Me.btn_incrementalsearcher_down.TabIndex = 0
        Me.btn_incrementalsearcher_down.TabStop = False
        '
        'btn_incrementalsearcher_up
        '
        Me.btn_incrementalsearcher_up.BackgroundImage = CType(resources.GetObject("btn_incrementalsearcher_up.BackgroundImage"), System.Drawing.Image)
        Me.btn_incrementalsearcher_up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_incrementalsearcher_up.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_incrementalsearcher_up.Location = New System.Drawing.Point(548, 0)
        Me.btn_incrementalsearcher_up.Name = "btn_incrementalsearcher_up"
        Me.btn_incrementalsearcher_up.Size = New System.Drawing.Size(23, 23)
        Me.btn_incrementalsearcher_up.TabIndex = 1
        Me.btn_incrementalsearcher_up.TabStop = False
        '
        'btn_incrementalsearcher_close
        '
        Me.btn_incrementalsearcher_close.BackgroundImage = CType(resources.GetObject("btn_incrementalsearcher_close.BackgroundImage"), System.Drawing.Image)
        Me.btn_incrementalsearcher_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_incrementalsearcher_close.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_incrementalsearcher_close.Location = New System.Drawing.Point(571, 0)
        Me.btn_incrementalsearcher_close.Name = "btn_incrementalsearcher_close"
        Me.btn_incrementalsearcher_close.Size = New System.Drawing.Size(23, 23)
        Me.btn_incrementalsearcher_close.TabIndex = 2
        Me.btn_incrementalsearcher_close.TabStop = False
        '
        'pnl_snippetlist
        '
        Me.pnl_snippetlist.Controls.Add(Me.listbox_snippetlist)
        Me.pnl_snippetlist.Controls.Add(Me.Panel1)
        Me.pnl_snippetlist.Location = New System.Drawing.Point(399, 31)
        Me.pnl_snippetlist.Name = "pnl_snippetlist"
        Me.pnl_snippetlist.Size = New System.Drawing.Size(152, 127)
        Me.pnl_snippetlist.TabIndex = 1
        Me.pnl_snippetlist.Visible = False
        '
        'listbox_snippetlist
        '
        Me.listbox_snippetlist.BackColor = System.Drawing.SystemColors.Window
        Me.listbox_snippetlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listbox_snippetlist.FormattingEnabled = True
        Me.listbox_snippetlist.ItemHeight = 15
        Me.listbox_snippetlist.Location = New System.Drawing.Point(0, 18)
        Me.listbox_snippetlist.Name = "listbox_snippetlist"
        Me.listbox_snippetlist.ScrollAlwaysVisible = True
        Me.listbox_snippetlist.Size = New System.Drawing.Size(152, 109)
        Me.listbox_snippetlist.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_closesnippetlist)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(152, 18)
        Me.Panel1.TabIndex = 1
        '
        'btn_closesnippetlist
        '
        Me.btn_closesnippetlist.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_closesnippetlist.Image = CType(resources.GetObject("btn_closesnippetlist.Image"), System.Drawing.Image)
        Me.btn_closesnippetlist.Location = New System.Drawing.Point(133, 0)
        Me.btn_closesnippetlist.Name = "btn_closesnippetlist"
        Me.btn_closesnippetlist.Size = New System.Drawing.Size(19, 18)
        Me.btn_closesnippetlist.TabIndex = 1
        Me.btn_closesnippetlist.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Snippets"
        '
        'XEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnl_snippetlist)
        Me.Controls.Add(Me.Scintilla1)
        Me.Controls.Add(Me.pnl_incrementalsearcher)
        Me.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "XEditor"
        Me.Size = New System.Drawing.Size(594, 454)
        Me.pnl_incrementalsearcher.ResumeLayout(False)
        Me.pnl_incrementalsearcher_toppanel.ResumeLayout(False)
        Me.pnl_incrementalsearcher_toppanel.PerformLayout()
        CType(Me.btn_incrementalsearcher_down, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_incrementalsearcher_up, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_incrementalsearcher_close, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_snippetlist.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btn_closesnippetlist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Scintilla1 As ScintillaNET.Scintilla
    Friend WithEvents pnl_snippetlist As System.Windows.Forms.Panel
    Friend WithEvents listbox_snippetlist As System.Windows.Forms.ListBox
    Friend WithEvents btn_closesnippetlist As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnl_incrementalsearcher As System.Windows.Forms.Panel
    Friend WithEvents txt_incrementalsearcher As System.Windows.Forms.TextBox
    Friend WithEvents btn_incrementalsearcher_down As System.Windows.Forms.PictureBox
    Friend WithEvents btn_incrementalsearcher_up As System.Windows.Forms.PictureBox
    Friend WithEvents btn_incrementalsearcher_close As System.Windows.Forms.PictureBox
    Friend WithEvents pnl_incrementalsearcher_toppanel As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class

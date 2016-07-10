<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
    Inherits MetroFramework.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.CopyToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btn_pssversion = New MetroFramework.Controls.MetroButton()
        Me.MetroStyleManager1 = New MetroFramework.Components.MetroStyleManager(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TextBox1.Location = New System.Drawing.Point(105, 63)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(337, 96)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToClipboardToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(172, 26)
        '
        'CopyToClipboardToolStripMenuItem
        '
        Me.CopyToClipboardToolStripMenuItem.Name = "CopyToClipboardToolStripMenuItem"
        Me.CopyToClipboardToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CopyToClipboardToolStripMenuItem.Text = "Copy to Clipboard"
        '
        'MetroButton2
        '
        Me.MetroButton2.Location = New System.Drawing.Point(328, 165)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(114, 29)
        Me.MetroButton2.TabIndex = 0
        Me.MetroButton2.Text = "Close"
        Me.MetroButton2.UseSelectable = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(123, 175)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(93, 19)
        Me.MetroLabel1.TabIndex = 7
        Me.MetroLabel1.Text = "Version: 2.1.0.0"
        Me.ToolTip1.SetToolTip(Me.MetroLabel1, "The BioNetWorks Software Manager is required in order to check for updates.")
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(3, 165)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(114, 29)
        Me.MetroButton1.TabIndex = 1
        Me.MetroButton1.Text = "Visit Repository"
        Me.MetroButton1.UseSelectable = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 63)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(96, 96)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'btn_pssversion
        '
        Me.btn_pssversion.Location = New System.Drawing.Point(242, 168)
        Me.btn_pssversion.Name = "btn_pssversion"
        Me.btn_pssversion.Size = New System.Drawing.Size(75, 23)
        Me.btn_pssversion.TabIndex = 8
        Me.btn_pssversion.Text = "PSS Version"
        Me.btn_pssversion.UseSelectable = True
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Nothing
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 202)
        Me.Controls.Add(Me.btn_pssversion)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MetroButton2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.Padding = New System.Windows.Forms.Padding(0, 60, 0, 20)
        Me.Resizable = False
        Me.ShowInTaskbar = False
        Me.Text = "About"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents CopyToClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_pssversion As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroStyleManager1 As MetroFramework.Components.MetroStyleManager
End Class

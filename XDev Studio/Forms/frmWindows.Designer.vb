<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWindows
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWindows))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActivateWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_ok = New MetroFramework.Controls.MetroButton()
        Me.lst = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivateWindowToolStripMenuItem, Me.CloseWindowToolStripMenuItem, Me.ToolStripSeparator2, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 76)
        '
        'ActivateWindowToolStripMenuItem
        '
        Me.ActivateWindowToolStripMenuItem.Name = "ActivateWindowToolStripMenuItem"
        Me.ActivateWindowToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ActivateWindowToolStripMenuItem.Text = "Activate Window"
        '
        'CloseWindowToolStripMenuItem
        '
        Me.CloseWindowToolStripMenuItem.Name = "CloseWindowToolStripMenuItem"
        Me.CloseWindowToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CloseWindowToolStripMenuItem.Text = "Close Window"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(161, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_ok)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 202)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(417, 27)
        Me.Panel1.TabIndex = 1
        '
        'btn_ok
        '
        Me.btn_ok.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_ok.Location = New System.Drawing.Point(0, 0)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(417, 27)
        Me.btn_ok.TabIndex = 0
        Me.btn_ok.Text = "Ok"
        Me.btn_ok.UseSelectable = True
        '
        'lst
        '
        Me.lst.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst.Location = New System.Drawing.Point(0, 60)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(417, 142)
        Me.lst.SmallImageList = Me.ImageList1
        Me.lst.TabIndex = 6
        Me.lst.UseCompatibleStateImageBehavior = False
        Me.lst.View = System.Windows.Forms.View.Details
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "16_window.png")
        '
        'frmWindows
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 249)
        Me.Controls.Add(Me.lst)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWindows"
        Me.Padding = New System.Windows.Forms.Padding(0, 60, 0, 20)
        Me.Text = "Windows"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lst As System.Windows.Forms.ListView
    Friend WithEvents btn_ok As MetroFramework.Controls.MetroButton
    Friend WithEvents CloseWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ActivateWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class

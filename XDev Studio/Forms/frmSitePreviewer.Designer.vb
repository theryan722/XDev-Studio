<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSitePreviewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSitePreviewer))
        Me.check_topmost = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_preview = New MetroFramework.Controls.MetroButton()
        Me.txt_website = New MetroFramework.Controls.MetroTextBox()
        Me.Previewer1 = New HtmlSitePreviewer.HtmlSitePreviewer()
        Me.btn_exit = New MetroFramework.Controls.MetroButton()
        Me.SuspendLayout()
        '
        'check_topmost
        '
        Me.check_topmost.AutoSize = True
        Me.check_topmost.Location = New System.Drawing.Point(316, 28)
        Me.check_topmost.Name = "check_topmost"
        Me.check_topmost.Size = New System.Drawing.Size(67, 17)
        Me.check_topmost.TabIndex = 4
        Me.check_topmost.Text = "Topmost"
        Me.check_topmost.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Website to preview:"
        '
        'btn_preview
        '
        Me.btn_preview.Location = New System.Drawing.Point(322, 89)
        Me.btn_preview.Name = "btn_preview"
        Me.btn_preview.Size = New System.Drawing.Size(75, 23)
        Me.btn_preview.TabIndex = 1
        Me.btn_preview.Text = "Preview"
        Me.btn_preview.UseSelectable = True
        '
        'txt_website
        '
        Me.txt_website.Lines = New String(-1) {}
        Me.txt_website.Location = New System.Drawing.Point(110, 60)
        Me.txt_website.MaxLength = 32767
        Me.txt_website.Name = "txt_website"
        Me.txt_website.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_website.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_website.SelectedText = ""
        Me.txt_website.Size = New System.Drawing.Size(287, 23)
        Me.txt_website.TabIndex = 0
        Me.txt_website.UseSelectable = True
        '
        'Previewer1
        '
        Me.Previewer1.BackColor = System.Drawing.Color.White
        Me.Previewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Previewer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Previewer1.ImageIndex = 1
        Me.Previewer1.Location = New System.Drawing.Point(0, 118)
        Me.Previewer1.Name = "Previewer1"
        Me.Previewer1.ShowLoadingStatus = True
        Me.Previewer1.Size = New System.Drawing.Size(400, 120)
        Me.Previewer1.TabIndex = 3
        Me.Previewer1.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:6.0) Gecko/20100101 Firefox/6.0 FirePHP/0.6"
        '
        'btn_exit
        '
        Me.btn_exit.Location = New System.Drawing.Point(6, 88)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 23)
        Me.btn_exit.TabIndex = 2
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseSelectable = True
        '
        'frmSitePreviewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 238)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.Previewer1)
        Me.Controls.Add(Me.txt_website)
        Me.Controls.Add(Me.btn_preview)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.check_topmost)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSitePreviewer"
        Me.Padding = New System.Windows.Forms.Padding(0, 60, 0, 0)
        Me.Resizable = False
        Me.Text = "Site Previewer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents check_topmost As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_preview As MetroFramework.Controls.MetroButton
    Friend WithEvents txt_website As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Previewer1 As HtmlSitePreviewer.HtmlSitePreviewer
    Friend WithEvents btn_exit As MetroFramework.Controls.MetroButton
End Class

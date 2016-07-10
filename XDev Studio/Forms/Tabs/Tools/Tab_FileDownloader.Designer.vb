<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_FileDownloader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_FileDownloader))
        Me.ProgressBar1 = New MetroFramework.Controls.MetroProgressBar()
        Me.btn_cancel = New MetroFramework.Controls.MetroButton()
        Me.btn_downloadfile = New MetroFramework.Controls.MetroButton()
        Me.btn_browse = New MetroFramework.Controls.MetroButton()
        Me.btn_opendownloadlocation = New MetroFramework.Controls.MetroButton()
        Me.txt_filetodownload = New MetroFramework.Controls.MetroTextBox()
        Me.txt_downloadlocation = New MetroFramework.Controls.MetroTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 458)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(608, 34)
        Me.ProgressBar1.TabIndex = 0
        '
        'btn_cancel
        '
        Me.btn_cancel.Enabled = False
        Me.btn_cancel.Location = New System.Drawing.Point(15, 95)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancel.TabIndex = 5
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseSelectable = True
        '
        'btn_downloadfile
        '
        Me.btn_downloadfile.Location = New System.Drawing.Point(470, 95)
        Me.btn_downloadfile.Name = "btn_downloadfile"
        Me.btn_downloadfile.Size = New System.Drawing.Size(75, 23)
        Me.btn_downloadfile.TabIndex = 3
        Me.btn_downloadfile.Text = "Download"
        Me.btn_downloadfile.UseSelectable = True
        '
        'btn_browse
        '
        Me.btn_browse.Location = New System.Drawing.Point(470, 47)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(75, 23)
        Me.btn_browse.TabIndex = 2
        Me.btn_browse.Text = "Browse"
        Me.btn_browse.UseSelectable = True
        '
        'btn_opendownloadlocation
        '
        Me.btn_opendownloadlocation.Location = New System.Drawing.Point(96, 95)
        Me.btn_opendownloadlocation.Name = "btn_opendownloadlocation"
        Me.btn_opendownloadlocation.Size = New System.Drawing.Size(151, 23)
        Me.btn_opendownloadlocation.TabIndex = 4
        Me.btn_opendownloadlocation.Text = "Open Download Location"
        Me.btn_opendownloadlocation.UseSelectable = True
        '
        'txt_filetodownload
        '
        Me.txt_filetodownload.Lines = New String(-1) {}
        Me.txt_filetodownload.Location = New System.Drawing.Point(139, 18)
        Me.txt_filetodownload.MaxLength = 32767
        Me.txt_filetodownload.Name = "txt_filetodownload"
        Me.txt_filetodownload.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_filetodownload.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_filetodownload.SelectedText = ""
        Me.txt_filetodownload.Size = New System.Drawing.Size(306, 23)
        Me.txt_filetodownload.TabIndex = 0
        Me.txt_filetodownload.UseSelectable = True
        '
        'txt_downloadlocation
        '
        Me.txt_downloadlocation.Lines = New String(-1) {}
        Me.txt_downloadlocation.Location = New System.Drawing.Point(158, 47)
        Me.txt_downloadlocation.MaxLength = 32767
        Me.txt_downloadlocation.Name = "txt_downloadlocation"
        Me.txt_downloadlocation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_downloadlocation.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_downloadlocation.SelectedText = ""
        Me.txt_downloadlocation.Size = New System.Drawing.Size(306, 23)
        Me.txt_downloadlocation.TabIndex = 1
        Me.txt_downloadlocation.UseSelectable = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "URL of file to download:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Location to download file to:"
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(0, 442)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(18, 16)
        Me.lblInfo.TabIndex = 9
        Me.lblInfo.Text = "[]"
        '
        'Tab_FileDownloader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 492)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_downloadlocation)
        Me.Controls.Add(Me.txt_filetodownload)
        Me.Controls.Add(Me.btn_opendownloadlocation)
        Me.Controls.Add(Me.btn_browse)
        Me.Controls.Add(Me.btn_downloadfile)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_FileDownloader"
        Me.Text = "File Downloader"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As MetroFramework.Controls.MetroProgressBar
    Friend WithEvents btn_cancel As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_downloadfile As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_browse As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_opendownloadlocation As MetroFramework.Controls.MetroButton
    Friend WithEvents txt_filetodownload As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_downloadlocation As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblInfo As System.Windows.Forms.Label
End Class

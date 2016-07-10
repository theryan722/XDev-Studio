<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_LogManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_LogManager))
        Me.MetroTabControl1 = New MetroFramework.Controls.MetroTabControl()
        Me.Tab_Studio = New System.Windows.Forms.TabPage()
        Me.txt_studio = New MetroFramework.Controls.MetroTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_refreshstudio = New MetroFramework.Controls.MetroButton()
        Me.btn_copystudio = New MetroFramework.Controls.MetroButton()
        Me.btn_clearstudio = New MetroFramework.Controls.MetroButton()
        Me.Tab_Plugin = New System.Windows.Forms.TabPage()
        Me.txt_plugin = New MetroFramework.Controls.MetroTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_refreshplugin = New MetroFramework.Controls.MetroButton()
        Me.btn_copyplugin = New MetroFramework.Controls.MetroButton()
        Me.btn_clearplugin = New MetroFramework.Controls.MetroButton()
        Me.Tab_Code = New System.Windows.Forms.TabPage()
        Me.txt_code = New MetroFramework.Controls.MetroTextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_refreshcode = New MetroFramework.Controls.MetroButton()
        Me.btn_copycode = New MetroFramework.Controls.MetroButton()
        Me.btn_clearcode = New MetroFramework.Controls.MetroButton()
        Me.MetroTabControl1.SuspendLayout()
        Me.Tab_Studio.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Tab_Plugin.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Tab_Code.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroTabControl1
        '
        Me.MetroTabControl1.Controls.Add(Me.Tab_Studio)
        Me.MetroTabControl1.Controls.Add(Me.Tab_Plugin)
        Me.MetroTabControl1.Controls.Add(Me.Tab_Code)
        Me.MetroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.MetroTabControl1.Name = "MetroTabControl1"
        Me.MetroTabControl1.SelectedIndex = 0
        Me.MetroTabControl1.Size = New System.Drawing.Size(562, 417)
        Me.MetroTabControl1.TabIndex = 1
        Me.MetroTabControl1.UseSelectable = True
        '
        'Tab_Studio
        '
        Me.Tab_Studio.Controls.Add(Me.txt_studio)
        Me.Tab_Studio.Controls.Add(Me.Panel1)
        Me.Tab_Studio.Location = New System.Drawing.Point(4, 38)
        Me.Tab_Studio.Name = "Tab_Studio"
        Me.Tab_Studio.Size = New System.Drawing.Size(554, 375)
        Me.Tab_Studio.TabIndex = 0
        Me.Tab_Studio.Text = "Studio Log"
        '
        'txt_studio
        '
        Me.txt_studio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_studio.Lines = New String(-1) {}
        Me.txt_studio.Location = New System.Drawing.Point(0, 0)
        Me.txt_studio.MaxLength = 32767
        Me.txt_studio.Multiline = True
        Me.txt_studio.Name = "txt_studio"
        Me.txt_studio.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_studio.ReadOnly = True
        Me.txt_studio.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_studio.SelectedText = ""
        Me.txt_studio.Size = New System.Drawing.Size(554, 352)
        Me.txt_studio.TabIndex = 1
        Me.txt_studio.UseSelectable = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_refreshstudio)
        Me.Panel1.Controls.Add(Me.btn_copystudio)
        Me.Panel1.Controls.Add(Me.btn_clearstudio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 352)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(554, 23)
        Me.Panel1.TabIndex = 0
        '
        'btn_refreshstudio
        '
        Me.btn_refreshstudio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_refreshstudio.Location = New System.Drawing.Point(75, 0)
        Me.btn_refreshstudio.Name = "btn_refreshstudio"
        Me.btn_refreshstudio.Size = New System.Drawing.Size(373, 23)
        Me.btn_refreshstudio.TabIndex = 3
        Me.btn_refreshstudio.Text = "Refresh Log"
        Me.btn_refreshstudio.UseSelectable = True
        '
        'btn_copystudio
        '
        Me.btn_copystudio.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_copystudio.Location = New System.Drawing.Point(448, 0)
        Me.btn_copystudio.Name = "btn_copystudio"
        Me.btn_copystudio.Size = New System.Drawing.Size(106, 23)
        Me.btn_copystudio.TabIndex = 2
        Me.btn_copystudio.Text = "Copy to Clipboard"
        Me.btn_copystudio.UseSelectable = True
        '
        'btn_clearstudio
        '
        Me.btn_clearstudio.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_clearstudio.Location = New System.Drawing.Point(0, 0)
        Me.btn_clearstudio.Name = "btn_clearstudio"
        Me.btn_clearstudio.Size = New System.Drawing.Size(75, 23)
        Me.btn_clearstudio.TabIndex = 0
        Me.btn_clearstudio.Text = "Clear Log"
        Me.btn_clearstudio.UseSelectable = True
        '
        'Tab_Plugin
        '
        Me.Tab_Plugin.Controls.Add(Me.txt_plugin)
        Me.Tab_Plugin.Controls.Add(Me.Panel2)
        Me.Tab_Plugin.Location = New System.Drawing.Point(4, 38)
        Me.Tab_Plugin.Name = "Tab_Plugin"
        Me.Tab_Plugin.Size = New System.Drawing.Size(554, 375)
        Me.Tab_Plugin.TabIndex = 1
        Me.Tab_Plugin.Text = "Plugin Log"
        '
        'txt_plugin
        '
        Me.txt_plugin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_plugin.Lines = New String(-1) {}
        Me.txt_plugin.Location = New System.Drawing.Point(0, 0)
        Me.txt_plugin.MaxLength = 32767
        Me.txt_plugin.Multiline = True
        Me.txt_plugin.Name = "txt_plugin"
        Me.txt_plugin.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_plugin.ReadOnly = True
        Me.txt_plugin.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_plugin.SelectedText = ""
        Me.txt_plugin.Size = New System.Drawing.Size(554, 352)
        Me.txt_plugin.TabIndex = 2
        Me.txt_plugin.UseSelectable = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btn_refreshplugin)
        Me.Panel2.Controls.Add(Me.btn_copyplugin)
        Me.Panel2.Controls.Add(Me.btn_clearplugin)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 352)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(554, 23)
        Me.Panel2.TabIndex = 1
        '
        'btn_refreshplugin
        '
        Me.btn_refreshplugin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_refreshplugin.Location = New System.Drawing.Point(75, 0)
        Me.btn_refreshplugin.Name = "btn_refreshplugin"
        Me.btn_refreshplugin.Size = New System.Drawing.Size(373, 23)
        Me.btn_refreshplugin.TabIndex = 3
        Me.btn_refreshplugin.Text = "Refresh Log"
        Me.btn_refreshplugin.UseSelectable = True
        '
        'btn_copyplugin
        '
        Me.btn_copyplugin.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_copyplugin.Location = New System.Drawing.Point(448, 0)
        Me.btn_copyplugin.Name = "btn_copyplugin"
        Me.btn_copyplugin.Size = New System.Drawing.Size(106, 23)
        Me.btn_copyplugin.TabIndex = 2
        Me.btn_copyplugin.Text = "Copy to Clipboard"
        Me.btn_copyplugin.UseSelectable = True
        '
        'btn_clearplugin
        '
        Me.btn_clearplugin.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_clearplugin.Location = New System.Drawing.Point(0, 0)
        Me.btn_clearplugin.Name = "btn_clearplugin"
        Me.btn_clearplugin.Size = New System.Drawing.Size(75, 23)
        Me.btn_clearplugin.TabIndex = 0
        Me.btn_clearplugin.Text = "Clear Log"
        Me.btn_clearplugin.UseSelectable = True
        '
        'Tab_Code
        '
        Me.Tab_Code.Controls.Add(Me.txt_code)
        Me.Tab_Code.Controls.Add(Me.Panel3)
        Me.Tab_Code.Location = New System.Drawing.Point(4, 38)
        Me.Tab_Code.Name = "Tab_Code"
        Me.Tab_Code.Size = New System.Drawing.Size(554, 375)
        Me.Tab_Code.TabIndex = 2
        Me.Tab_Code.Text = "Code Log"
        '
        'txt_code
        '
        Me.txt_code.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_code.Lines = New String(-1) {}
        Me.txt_code.Location = New System.Drawing.Point(0, 0)
        Me.txt_code.MaxLength = 32767
        Me.txt_code.Multiline = True
        Me.txt_code.Name = "txt_code"
        Me.txt_code.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_code.ReadOnly = True
        Me.txt_code.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_code.SelectedText = ""
        Me.txt_code.Size = New System.Drawing.Size(554, 352)
        Me.txt_code.TabIndex = 2
        Me.txt_code.UseSelectable = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btn_refreshcode)
        Me.Panel3.Controls.Add(Me.btn_copycode)
        Me.Panel3.Controls.Add(Me.btn_clearcode)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 352)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(554, 23)
        Me.Panel3.TabIndex = 1
        '
        'btn_refreshcode
        '
        Me.btn_refreshcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_refreshcode.Location = New System.Drawing.Point(75, 0)
        Me.btn_refreshcode.Name = "btn_refreshcode"
        Me.btn_refreshcode.Size = New System.Drawing.Size(373, 23)
        Me.btn_refreshcode.TabIndex = 3
        Me.btn_refreshcode.Text = "Refresh Log"
        Me.btn_refreshcode.UseSelectable = True
        '
        'btn_copycode
        '
        Me.btn_copycode.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_copycode.Location = New System.Drawing.Point(448, 0)
        Me.btn_copycode.Name = "btn_copycode"
        Me.btn_copycode.Size = New System.Drawing.Size(106, 23)
        Me.btn_copycode.TabIndex = 2
        Me.btn_copycode.Text = "Copy to Clipboard"
        Me.btn_copycode.UseSelectable = True
        '
        'btn_clearcode
        '
        Me.btn_clearcode.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_clearcode.Location = New System.Drawing.Point(0, 0)
        Me.btn_clearcode.Name = "btn_clearcode"
        Me.btn_clearcode.Size = New System.Drawing.Size(75, 23)
        Me.btn_clearcode.TabIndex = 0
        Me.btn_clearcode.Text = "Clear Log"
        Me.btn_clearcode.UseSelectable = True
        '
        'Tab_LogManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 417)
        Me.Controls.Add(Me.MetroTabControl1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_LogManager"
        Me.ShowInTaskbar = False
        Me.Text = "Log Manager"
        Me.MetroTabControl1.ResumeLayout(False)
        Me.Tab_Studio.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Tab_Plugin.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Tab_Code.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroTabControl1 As MetroFramework.Controls.MetroTabControl
    Friend WithEvents Tab_Studio As System.Windows.Forms.TabPage
    Friend WithEvents txt_studio As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_refreshstudio As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_copystudio As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_clearstudio As MetroFramework.Controls.MetroButton
    Friend WithEvents Tab_Plugin As System.Windows.Forms.TabPage
    Friend WithEvents txt_plugin As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_refreshplugin As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_copyplugin As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_clearplugin As MetroFramework.Controls.MetroButton
    Friend WithEvents Tab_Code As System.Windows.Forms.TabPage
    Friend WithEvents txt_code As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btn_refreshcode As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_copycode As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_clearcode As MetroFramework.Controls.MetroButton
End Class

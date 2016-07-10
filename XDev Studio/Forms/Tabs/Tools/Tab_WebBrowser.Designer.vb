<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_WebBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_WebBrowser))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.ComboBox()
        Me.btn_openwebsiteinwebbrowser = New System.Windows.Forms.Button()
        Me.btn_Home = New System.Windows.Forms.Button()
        Me.btn_Refresh = New System.Windows.Forms.Button()
        Me.btn_Stop = New System.Windows.Forms.Button()
        Me.btn_Forward = New System.Windows.Forms.Button()
        Me.btn_Back = New System.Windows.Forms.Button()
        Me.btn_Navigate = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.btn_openwebsiteinwebbrowser)
        Me.Panel1.Controls.Add(Me.btn_Home)
        Me.Panel1.Controls.Add(Me.btn_Refresh)
        Me.Panel1.Controls.Add(Me.btn_Stop)
        Me.Panel1.Controls.Add(Me.btn_Forward)
        Me.Panel1.Controls.Add(Me.btn_Back)
        Me.Panel1.Controls.Add(Me.btn_Navigate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(814, 32)
        Me.Panel1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.FormattingEnabled = True
        Me.TextBox1.Location = New System.Drawing.Point(192, 0)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(590, 21)
        Me.TextBox1.TabIndex = 0
        '
        'btn_openwebsiteinwebbrowser
        '
        Me.btn_openwebsiteinwebbrowser.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_openwebsiteinwebbrowser.FlatAppearance.BorderSize = 0
        Me.btn_openwebsiteinwebbrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_openwebsiteinwebbrowser.Image = CType(resources.GetObject("btn_openwebsiteinwebbrowser.Image"), System.Drawing.Image)
        Me.btn_openwebsiteinwebbrowser.Location = New System.Drawing.Point(160, 0)
        Me.btn_openwebsiteinwebbrowser.Name = "btn_openwebsiteinwebbrowser"
        Me.btn_openwebsiteinwebbrowser.Size = New System.Drawing.Size(32, 32)
        Me.btn_openwebsiteinwebbrowser.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btn_openwebsiteinwebbrowser, "Open current website in default browser")
        Me.btn_openwebsiteinwebbrowser.UseVisualStyleBackColor = True
        '
        'btn_Home
        '
        Me.btn_Home.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Home.FlatAppearance.BorderSize = 0
        Me.btn_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Home.Image = CType(resources.GetObject("btn_Home.Image"), System.Drawing.Image)
        Me.btn_Home.Location = New System.Drawing.Point(128, 0)
        Me.btn_Home.Name = "btn_Home"
        Me.btn_Home.Size = New System.Drawing.Size(32, 32)
        Me.btn_Home.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.btn_Home, "Go home")
        Me.btn_Home.UseVisualStyleBackColor = True
        '
        'btn_Refresh
        '
        Me.btn_Refresh.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Refresh.FlatAppearance.BorderSize = 0
        Me.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Refresh.Image = CType(resources.GetObject("btn_Refresh.Image"), System.Drawing.Image)
        Me.btn_Refresh.Location = New System.Drawing.Point(96, 0)
        Me.btn_Refresh.Name = "btn_Refresh"
        Me.btn_Refresh.Size = New System.Drawing.Size(32, 32)
        Me.btn_Refresh.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btn_Refresh, "Refresh the page")
        Me.btn_Refresh.UseVisualStyleBackColor = True
        '
        'btn_Stop
        '
        Me.btn_Stop.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Stop.FlatAppearance.BorderSize = 0
        Me.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Stop.Image = CType(resources.GetObject("btn_Stop.Image"), System.Drawing.Image)
        Me.btn_Stop.Location = New System.Drawing.Point(64, 0)
        Me.btn_Stop.Name = "btn_Stop"
        Me.btn_Stop.Size = New System.Drawing.Size(32, 32)
        Me.btn_Stop.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btn_Stop, "Stop the page")
        Me.btn_Stop.UseVisualStyleBackColor = True
        '
        'btn_Forward
        '
        Me.btn_Forward.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Forward.FlatAppearance.BorderSize = 0
        Me.btn_Forward.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Forward.Image = CType(resources.GetObject("btn_Forward.Image"), System.Drawing.Image)
        Me.btn_Forward.Location = New System.Drawing.Point(32, 0)
        Me.btn_Forward.Name = "btn_Forward"
        Me.btn_Forward.Size = New System.Drawing.Size(32, 32)
        Me.btn_Forward.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btn_Forward, "Navigate forward")
        Me.btn_Forward.UseVisualStyleBackColor = True
        '
        'btn_Back
        '
        Me.btn_Back.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Back.FlatAppearance.BorderSize = 0
        Me.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Back.Image = CType(resources.GetObject("btn_Back.Image"), System.Drawing.Image)
        Me.btn_Back.Location = New System.Drawing.Point(0, 0)
        Me.btn_Back.Name = "btn_Back"
        Me.btn_Back.Size = New System.Drawing.Size(32, 32)
        Me.btn_Back.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btn_Back, "Navigate back")
        Me.btn_Back.UseVisualStyleBackColor = True
        '
        'btn_Navigate
        '
        Me.btn_Navigate.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Navigate.FlatAppearance.BorderSize = 0
        Me.btn_Navigate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Navigate.Image = CType(resources.GetObject("btn_Navigate.Image"), System.Drawing.Image)
        Me.btn_Navigate.Location = New System.Drawing.Point(782, 0)
        Me.btn_Navigate.Name = "btn_Navigate"
        Me.btn_Navigate.Size = New System.Drawing.Size(32, 32)
        Me.btn_Navigate.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.btn_Navigate, "Navigate to the specified website")
        Me.btn_Navigate.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 32)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.Size = New System.Drawing.Size(814, 587)
        Me.WebBrowser1.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 597)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(814, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(15, 17)
        Me.ToolStripStatusLabel1.Text = "[]"
        '
        'Tab_WebBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 619)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.Panel1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_WebBrowser"
        Me.ShowInTaskbar = False
        Me.Text = "Web Browser"
        Me.Panel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Home As System.Windows.Forms.Button
    Friend WithEvents btn_Refresh As System.Windows.Forms.Button
    Friend WithEvents btn_Stop As System.Windows.Forms.Button
    Friend WithEvents btn_Forward As System.Windows.Forms.Button
    Friend WithEvents btn_Back As System.Windows.Forms.Button
    Friend WithEvents btn_Navigate As System.Windows.Forms.Button
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents btn_openwebsiteinwebbrowser As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuickCommand
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuickCommand))
        Me.txt_search = New MetroFramework.Controls.MetroTextBox()
        Me.btn_execute = New MetroFramework.Controls.MetroButton()
        Me.btn_close = New MetroFramework.Controls.MetroButton()
        Me.lb_commands = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btn_clear = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.check_closeafterexecute = New MetroFramework.Controls.MetroCheckBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.btn_clear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_search
        '
        Me.txt_search.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_search.Lines = New String(-1) {}
        Me.txt_search.Location = New System.Drawing.Point(0, 0)
        Me.txt_search.MaxLength = 32767
        Me.txt_search.Name = "txt_search"
        Me.txt_search.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_search.PromptText = "Search Commands"
        Me.txt_search.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_search.SelectedText = ""
        Me.txt_search.Size = New System.Drawing.Size(268, 23)
        Me.txt_search.TabIndex = 0
        Me.txt_search.UseSelectable = True
        '
        'btn_execute
        '
        Me.btn_execute.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_execute.Location = New System.Drawing.Point(209, 0)
        Me.btn_execute.Name = "btn_execute"
        Me.btn_execute.Size = New System.Drawing.Size(75, 23)
        Me.btn_execute.TabIndex = 2
        Me.btn_execute.Text = "Execute"
        Me.btn_execute.UseSelectable = True
        '
        'btn_close
        '
        Me.btn_close.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_close.Location = New System.Drawing.Point(0, 0)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(75, 23)
        Me.btn_close.TabIndex = 3
        Me.btn_close.Text = "Close"
        Me.btn_close.UseSelectable = True
        '
        'lb_commands
        '
        Me.lb_commands.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_commands.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_commands.FormattingEnabled = True
        Me.lb_commands.ItemHeight = 15
        Me.lb_commands.Location = New System.Drawing.Point(0, 23)
        Me.lb_commands.Name = "lb_commands"
        Me.lb_commands.ScrollAlwaysVisible = True
        Me.lb_commands.Size = New System.Drawing.Size(284, 146)
        Me.lb_commands.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_search)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 23)
        Me.Panel1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.btn_clear)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(268, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(16, 23)
        Me.Panel2.TabIndex = 21
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 20)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(16, 3)
        Me.Panel4.TabIndex = 1
        '
        'btn_clear
        '
        Me.btn_clear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_clear.Image = CType(resources.GetObject("btn_clear.Image"), System.Drawing.Image)
        Me.btn_clear.Location = New System.Drawing.Point(0, 4)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(16, 19)
        Me.btn_clear.TabIndex = 20
        Me.btn_clear.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(16, 4)
        Me.Panel3.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.check_closeafterexecute)
        Me.Panel5.Controls.Add(Me.btn_execute)
        Me.Panel5.Controls.Add(Me.btn_close)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 169)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(284, 23)
        Me.Panel5.TabIndex = 5
        '
        'check_closeafterexecute
        '
        Me.check_closeafterexecute.AutoSize = True
        Me.check_closeafterexecute.Location = New System.Drawing.Point(81, 3)
        Me.check_closeafterexecute.Name = "check_closeafterexecute"
        Me.check_closeafterexecute.Size = New System.Drawing.Size(122, 15)
        Me.check_closeafterexecute.TabIndex = 4
        Me.check_closeafterexecute.Text = "Close after execute"
        Me.check_closeafterexecute.UseSelectable = True
        '
        'frmQuickCommand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 192)
        Me.ControlBox = False
        Me.Controls.Add(Me.lb_commands)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmQuickCommand"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.btn_clear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_search As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btn_execute As MetroFramework.Controls.MetroButton
    Friend WithEvents btn_close As MetroFramework.Controls.MetroButton
    Friend WithEvents lb_commands As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btn_clear As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents check_closeafterexecute As MetroFramework.Controls.MetroCheckBox
End Class

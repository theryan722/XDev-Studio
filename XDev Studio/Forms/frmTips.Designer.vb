<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTips
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTips))
        Me.check_topmost = New System.Windows.Forms.CheckBox()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.txt_tip = New MetroFramework.Controls.MetroTextBox()
        Me.check_showatstartup = New MetroFramework.Controls.MetroCheckBox()
        Me.SuspendLayout()
        '
        'check_topmost
        '
        Me.check_topmost.AutoSize = True
        Me.check_topmost.Location = New System.Drawing.Point(238, 36)
        Me.check_topmost.Name = "check_topmost"
        Me.check_topmost.Size = New System.Drawing.Size(67, 17)
        Me.check_topmost.TabIndex = 3
        Me.check_topmost.Text = "Topmost"
        Me.check_topmost.UseVisualStyleBackColor = True
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(237, 185)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton1.TabIndex = 0
        Me.MetroButton1.Text = "New Tip"
        Me.MetroButton1.UseSelectable = True
        '
        'MetroButton2
        '
        Me.MetroButton2.Location = New System.Drawing.Point(3, 185)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton2.TabIndex = 1
        Me.MetroButton2.Text = "Close"
        Me.MetroButton2.UseSelectable = True
        '
        'txt_tip
        '
        Me.txt_tip.Lines = New String(-1) {}
        Me.txt_tip.Location = New System.Drawing.Point(3, 63)
        Me.txt_tip.MaxLength = 32767
        Me.txt_tip.Multiline = True
        Me.txt_tip.Name = "txt_tip"
        Me.txt_tip.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_tip.ReadOnly = True
        Me.txt_tip.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_tip.SelectedText = ""
        Me.txt_tip.Size = New System.Drawing.Size(309, 116)
        Me.txt_tip.TabIndex = 2
        Me.txt_tip.UseSelectable = True
        '
        'check_showatstartup
        '
        Me.check_showatstartup.AutoSize = True
        Me.check_showatstartup.Location = New System.Drawing.Point(84, 193)
        Me.check_showatstartup.Name = "check_showatstartup"
        Me.check_showatstartup.Size = New System.Drawing.Size(106, 15)
        Me.check_showatstartup.TabIndex = 4
        Me.check_showatstartup.Text = "Show at Startup"
        Me.check_showatstartup.UseSelectable = True
        '
        'frmTips
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 213)
        Me.Controls.Add(Me.check_showatstartup)
        Me.Controls.Add(Me.txt_tip)
        Me.Controls.Add(Me.MetroButton2)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.check_topmost)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTips"
        Me.Padding = New System.Windows.Forms.Padding(0, 60, 0, 20)
        Me.Resizable = False
        Me.ShowInTaskbar = False
        Me.Text = "Tips"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents check_topmost As System.Windows.Forms.CheckBox
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents txt_tip As MetroFramework.Controls.MetroTextBox
    Friend WithEvents check_showatstartup As MetroFramework.Controls.MetroCheckBox
End Class

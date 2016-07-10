<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSurroundWith
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
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.txt_start = New MetroFramework.Controls.MetroTextBox()
        Me.txt_end = New MetroFramework.Controls.MetroTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(150, 92)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton1.TabIndex = 0
        Me.MetroButton1.Text = "Ok"
        Me.MetroButton1.UseSelectable = True
        '
        'MetroButton2
        '
        Me.MetroButton2.Location = New System.Drawing.Point(5, 92)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton2.TabIndex = 1
        Me.MetroButton2.Text = "Cancel"
        Me.MetroButton2.UseSelectable = True
        '
        'txt_start
        '
        Me.txt_start.Lines = New String(-1) {}
        Me.txt_start.Location = New System.Drawing.Point(5, 63)
        Me.txt_start.MaxLength = 32767
        Me.txt_start.Name = "txt_start"
        Me.txt_start.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_start.PromptText = "Start Text"
        Me.txt_start.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_start.SelectedText = ""
        Me.txt_start.Size = New System.Drawing.Size(75, 23)
        Me.txt_start.TabIndex = 2
        Me.txt_start.UseSelectable = True
        '
        'txt_end
        '
        Me.txt_end.Lines = New String(-1) {}
        Me.txt_end.Location = New System.Drawing.Point(150, 63)
        Me.txt_end.MaxLength = 32767
        Me.txt_end.Name = "txt_end"
        Me.txt_end.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_end.PromptText = "End Text"
        Me.txt_end.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_end.SelectedText = ""
        Me.txt_end.Size = New System.Drawing.Size(75, 23)
        Me.txt_end.TabIndex = 3
        Me.txt_end.UseSelectable = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(90, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "selection"
        '
        'frmSurroundWith
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(234, 131)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_end)
        Me.Controls.Add(Me.txt_start)
        Me.Controls.Add(Me.MetroButton2)
        Me.Controls.Add(Me.MetroButton1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurroundWith"
        Me.Resizable = False
        Me.Text = "Surround With"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents txt_start As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txt_end As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

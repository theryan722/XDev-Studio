<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMoveFile
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
        Me.txtFrom = New MetroFramework.Controls.MetroTextBox()
        Me.txtTo = New MetroFramework.Controls.MetroTextBox()
        Me.btnCancel = New MetroFramework.Controls.MetroButton()
        Me.btnMove = New MetroFramework.Controls.MetroButton()
        Me.btnToBrowse = New MetroFramework.Controls.MetroButton()
        Me.btnFromBrowse = New MetroFramework.Controls.MetroButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtFrom
        '
        Me.txtFrom.Lines = New String(-1) {}
        Me.txtFrom.Location = New System.Drawing.Point(62, 69)
        Me.txtFrom.MaxLength = 32767
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFrom.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtFrom.SelectedText = ""
        Me.txtFrom.Size = New System.Drawing.Size(259, 23)
        Me.txtFrom.TabIndex = 0
        Me.txtFrom.UseSelectable = True
        '
        'txtTo
        '
        Me.txtTo.Lines = New String(-1) {}
        Me.txtTo.Location = New System.Drawing.Point(62, 104)
        Me.txtTo.MaxLength = 32767
        Me.txtTo.Name = "txtTo"
        Me.txtTo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtTo.SelectedText = ""
        Me.txtTo.Size = New System.Drawing.Size(259, 23)
        Me.txtTo.TabIndex = 2
        Me.txtTo.UseSelectable = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(6, 133)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 34)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseSelectable = True
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(292, 133)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(91, 34)
        Me.btnMove.TabIndex = 4
        Me.btnMove.Text = "Move"
        Me.btnMove.UseSelectable = True
        '
        'btnToBrowse
        '
        Me.btnToBrowse.Location = New System.Drawing.Point(327, 104)
        Me.btnToBrowse.Name = "btnToBrowse"
        Me.btnToBrowse.Size = New System.Drawing.Size(56, 23)
        Me.btnToBrowse.TabIndex = 3
        Me.btnToBrowse.Text = "Browse"
        Me.btnToBrowse.UseSelectable = True
        '
        'btnFromBrowse
        '
        Me.btnFromBrowse.Location = New System.Drawing.Point(327, 69)
        Me.btnFromBrowse.Name = "btnFromBrowse"
        Me.btnFromBrowse.Size = New System.Drawing.Size(56, 23)
        Me.btnFromBrowse.TabIndex = 1
        Me.btnFromBrowse.Text = "Browse"
        Me.btnFromBrowse.UseSelectable = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Move file:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "To:"
        '
        'frmMoveFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 176)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFromBrowse)
        Me.Controls.Add(Me.btnToBrowse)
        Me.Controls.Add(Me.btnMove)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.txtFrom)
        Me.Name = "frmMoveFile"
        Me.Padding = New System.Windows.Forms.Padding(0, 60, 0, 0)
        Me.Resizable = False
        Me.ShowInTaskbar = False
        Me.Text = "Move File/Directory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFrom As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtTo As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btnCancel As MetroFramework.Controls.MetroButton
    Friend WithEvents btnMove As MetroFramework.Controls.MetroButton
    Friend WithEvents btnToBrowse As MetroFramework.Controls.MetroButton
    Friend WithEvents btnFromBrowse As MetroFramework.Controls.MetroButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class

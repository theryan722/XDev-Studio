<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCommandPalette
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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.check_closeaftercommandexecuted = New System.Windows.Forms.CheckBox()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 33)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(310, 134)
        Me.ListBox1.TabIndex = 1
        '
        'check_closeaftercommandexecuted
        '
        Me.check_closeaftercommandexecuted.AutoSize = True
        Me.check_closeaftercommandexecuted.Checked = True
        Me.check_closeaftercommandexecuted.CheckState = System.Windows.Forms.CheckState.Checked
        Me.check_closeaftercommandexecuted.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.check_closeaftercommandexecuted.Location = New System.Drawing.Point(0, 168)
        Me.check_closeaftercommandexecuted.Name = "check_closeaftercommandexecuted"
        Me.check_closeaftercommandexecuted.Size = New System.Drawing.Size(310, 17)
        Me.check_closeaftercommandexecuted.TabIndex = 2
        Me.check_closeaftercommandexecuted.Text = "Close after command executed"
        Me.check_closeaftercommandexecuted.UseVisualStyleBackColor = True
        '
        'txt_search
        '
        Me.txt_search.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_search.Location = New System.Drawing.Point(0, 13)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(310, 20)
        Me.txt_search.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search Command:"
        '
        'dlgCommandPalette
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 185)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.txt_search)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.check_closeaftercommandexecuted)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgCommandPalette"
        Me.ShowInTaskbar = False
        Me.Text = "Command Palette"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents check_closeaftercommandexecuted As System.Windows.Forms.CheckBox
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

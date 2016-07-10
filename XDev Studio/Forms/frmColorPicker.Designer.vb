<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColorPicker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmColorPicker))
        Me.ColorPicker1 = New ColorPickerLib.ColorPicker()
        Me.check_topmost = New System.Windows.Forms.CheckBox()
        CType(Me.ColorPicker1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColorPicker1
        '
        Me.ColorPicker1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ColorPicker1.FlyOut = ColorPickerLib.ColorPicker.eFlyOut.Click
        Me.ColorPicker1.HideRGB = False
        Me.ColorPicker1.Location = New System.Drawing.Point(0, 60)
        Me.ColorPicker1.Name = "ColorPicker1"
        Me.ColorPicker1.Size = New System.Drawing.Size(368, 155)
        Me.ColorPicker1.TabIndex = 0
        Me.ColorPicker1.Value = System.Drawing.Color.Red
        '
        'check_topmost
        '
        Me.check_topmost.AutoSize = True
        Me.check_topmost.Location = New System.Drawing.Point(287, 37)
        Me.check_topmost.Name = "check_topmost"
        Me.check_topmost.Size = New System.Drawing.Size(67, 17)
        Me.check_topmost.TabIndex = 4
        Me.check_topmost.Text = "Topmost"
        Me.check_topmost.UseVisualStyleBackColor = True
        '
        'frmColorPicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 235)
        Me.Controls.Add(Me.check_topmost)
        Me.Controls.Add(Me.ColorPicker1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmColorPicker"
        Me.Padding = New System.Windows.Forms.Padding(0, 60, 0, 20)
        Me.Resizable = False
        Me.Text = "Color Picker"
        CType(Me.ColorPicker1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColorPicker1 As ColorPickerLib.ColorPicker
    Friend WithEvents check_topmost As System.Windows.Forms.CheckBox
End Class

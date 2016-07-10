<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pnlToolPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pnlToolPanel))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_result = New MetroFramework.Controls.MetroTextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.combo_to = New MetroFramework.Controls.MetroComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txt_from = New MetroFramework.Controls.MetroTextBox()
        Me.combo_from = New MetroFramework.Controls.MetroComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CalculatorBox1 = New Calculator.CalculatorBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_notepad = New MetroFramework.Controls.MetroTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_stopwatch = New System.Windows.Forms.Label()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton3 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton4 = New MetroFramework.Controls.MetroButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lb_stopwatch = New System.Windows.Forms.ListBox()
        Me.Timer_Stopwatch = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txt_result)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 255)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(184, 87)
        Me.Panel2.TabIndex = 4
        '
        'txt_result
        '
        Me.txt_result.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_result.Lines = New String(-1) {}
        Me.txt_result.Location = New System.Drawing.Point(0, 60)
        Me.txt_result.MaxLength = 32767
        Me.txt_result.Name = "txt_result"
        Me.txt_result.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_result.ReadOnly = True
        Me.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_result.SelectedText = ""
        Me.txt_result.Size = New System.Drawing.Size(184, 23)
        Me.txt_result.TabIndex = 7
        Me.txt_result.UseSelectable = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.combo_to)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 30)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(184, 30)
        Me.Panel4.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "To:"
        '
        'combo_to
        '
        Me.combo_to.Dock = System.Windows.Forms.DockStyle.Right
        Me.combo_to.FormattingEnabled = True
        Me.combo_to.ItemHeight = 23
        Me.combo_to.Items.AddRange(New Object() {"Byte", "Kilobyte", "Megabyte", "Gigabyte", "Terabyte", "Petabyte"})
        Me.combo_to.Location = New System.Drawing.Point(84, 0)
        Me.combo_to.Name = "combo_to"
        Me.combo_to.Size = New System.Drawing.Size(100, 29)
        Me.combo_to.TabIndex = 3
        Me.combo_to.UseSelectable = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txt_from)
        Me.Panel3.Controls.Add(Me.combo_from)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(184, 30)
        Me.Panel3.TabIndex = 5
        '
        'txt_from
        '
        Me.txt_from.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_from.Lines = New String(-1) {}
        Me.txt_from.Location = New System.Drawing.Point(0, 0)
        Me.txt_from.MaxLength = 32767
        Me.txt_from.Name = "txt_from"
        Me.txt_from.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_from.PromptText = "From"
        Me.txt_from.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_from.SelectedText = ""
        Me.txt_from.Size = New System.Drawing.Size(84, 30)
        Me.txt_from.TabIndex = 1
        Me.txt_from.UseSelectable = True
        '
        'combo_from
        '
        Me.combo_from.Dock = System.Windows.Forms.DockStyle.Right
        Me.combo_from.FormattingEnabled = True
        Me.combo_from.ItemHeight = 23
        Me.combo_from.Items.AddRange(New Object() {"Byte", "Kilobyte", "Megabyte", "Gigabyte", "Terabyte", "Petabyte"})
        Me.combo_from.Location = New System.Drawing.Point(84, 0)
        Me.combo_from.Name = "combo_from"
        Me.combo_from.Size = New System.Drawing.Size(100, 29)
        Me.combo_from.TabIndex = 3
        Me.combo_from.UseSelectable = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 242)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Converter"
        '
        'CalculatorBox1
        '
        Me.CalculatorBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CalculatorBox1.Location = New System.Drawing.Point(0, 222)
        Me.CalculatorBox1.Name = "CalculatorBox1"
        Me.CalculatorBox1.Size = New System.Drawing.Size(184, 20)
        Me.CalculatorBox1.TabIndex = 1
        Me.CalculatorBox1.Value = 0.0R
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Calculator"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_notepad)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 209)
        Me.Panel1.TabIndex = 0
        '
        'txt_notepad
        '
        Me.txt_notepad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_notepad.Lines = New String(-1) {}
        Me.txt_notepad.Location = New System.Drawing.Point(0, 13)
        Me.txt_notepad.MaxLength = 32767
        Me.txt_notepad.Multiline = True
        Me.txt_notepad.Name = "txt_notepad"
        Me.txt_notepad.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_notepad.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txt_notepad.SelectedText = ""
        Me.txt_notepad.Size = New System.Drawing.Size(184, 196)
        Me.txt_notepad.TabIndex = 1
        Me.txt_notepad.UseSelectable = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Notepad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 342)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Stopwatch"
        '
        'lbl_stopwatch
        '
        Me.lbl_stopwatch.AutoSize = True
        Me.lbl_stopwatch.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_stopwatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stopwatch.Location = New System.Drawing.Point(0, 355)
        Me.lbl_stopwatch.Name = "lbl_stopwatch"
        Me.lbl_stopwatch.Size = New System.Drawing.Size(92, 17)
        Me.lbl_stopwatch.TabIndex = 6
        Me.lbl_stopwatch.Text = "00:00:00:000"
        '
        'MetroButton1
        '
        Me.MetroButton1.Dock = System.Windows.Forms.DockStyle.Left
        Me.MetroButton1.Location = New System.Drawing.Point(0, 0)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton1.TabIndex = 7
        Me.MetroButton1.Text = "Start"
        Me.MetroButton1.UseSelectable = True
        '
        'MetroButton2
        '
        Me.MetroButton2.Dock = System.Windows.Forms.DockStyle.Right
        Me.MetroButton2.Location = New System.Drawing.Point(109, 0)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton2.TabIndex = 8
        Me.MetroButton2.Text = "Stop"
        Me.MetroButton2.UseSelectable = True
        '
        'MetroButton3
        '
        Me.MetroButton3.Dock = System.Windows.Forms.DockStyle.Right
        Me.MetroButton3.Location = New System.Drawing.Point(109, 0)
        Me.MetroButton3.Name = "MetroButton3"
        Me.MetroButton3.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton3.TabIndex = 9
        Me.MetroButton3.Text = "Reset"
        Me.MetroButton3.UseSelectable = True
        '
        'MetroButton4
        '
        Me.MetroButton4.Dock = System.Windows.Forms.DockStyle.Left
        Me.MetroButton4.Location = New System.Drawing.Point(0, 0)
        Me.MetroButton4.Name = "MetroButton4"
        Me.MetroButton4.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton4.TabIndex = 10
        Me.MetroButton4.Text = "Mark"
        Me.MetroButton4.UseSelectable = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.MetroButton1)
        Me.Panel5.Controls.Add(Me.MetroButton2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 372)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(184, 23)
        Me.Panel5.TabIndex = 11
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.MetroButton3)
        Me.Panel6.Controls.Add(Me.MetroButton4)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 395)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(184, 23)
        Me.Panel6.TabIndex = 12
        '
        'lb_stopwatch
        '
        Me.lb_stopwatch.Dock = System.Windows.Forms.DockStyle.Top
        Me.lb_stopwatch.FormattingEnabled = True
        Me.lb_stopwatch.Location = New System.Drawing.Point(0, 418)
        Me.lb_stopwatch.Name = "lb_stopwatch"
        Me.lb_stopwatch.ScrollAlwaysVisible = True
        Me.lb_stopwatch.Size = New System.Drawing.Size(184, 82)
        Me.lb_stopwatch.TabIndex = 13
        '
        'Timer_Stopwatch
        '
        Me.Timer_Stopwatch.Interval = 1
        '
        'pnlToolPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(184, 542)
        Me.Controls.Add(Me.lb_stopwatch)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.lbl_stopwatch)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CalculatorBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.DockAreas = CType(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "pnlToolPanel"
        Me.Text = "Tool Panel"
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_notepad As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CalculatorBox1 As Calculator.CalculatorBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents combo_to As MetroFramework.Controls.MetroComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txt_from As MetroFramework.Controls.MetroTextBox
    Friend WithEvents combo_from As MetroFramework.Controls.MetroComboBox
    Friend WithEvents txt_result As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_stopwatch As System.Windows.Forms.Label
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton3 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton4 As MetroFramework.Controls.MetroButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lb_stopwatch As System.Windows.Forms.ListBox
    Friend WithEvents Timer_Stopwatch As System.Windows.Forms.Timer
End Class

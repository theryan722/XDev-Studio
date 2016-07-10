<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_Calendar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_Calendar))
        Me.Calendar1 = New Calendar.NET.Calendar()
        Me.SuspendLayout()
        '
        'Calendar1
        '
        Me.Calendar1.AllowEditingEvents = True
        Me.Calendar1.CalendarDate = New Date(2014, 12, 25, 18, 38, 20, 764)
        Me.Calendar1.CalendarView = Calendar.NET.CalendarViews.Month
        Me.Calendar1.DateHeaderFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Calendar1.DayOfWeekFont = New System.Drawing.Font("Arial", 10.0!)
        Me.Calendar1.DaysFont = New System.Drawing.Font("Arial", 10.0!)
        Me.Calendar1.DayViewTimeFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Calendar1.DimDisabledEvents = True
        Me.Calendar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Calendar1.HighlightCurrentDay = True
        Me.Calendar1.LoadPresetHolidays = True
        Me.Calendar1.Location = New System.Drawing.Point(0, 0)
        Me.Calendar1.Name = "Calendar1"
        Me.Calendar1.ShowArrowControls = True
        Me.Calendar1.ShowDashedBorderOnDisabledEvents = True
        Me.Calendar1.ShowDateInHeader = True
        Me.Calendar1.ShowDisabledEvents = False
        Me.Calendar1.ShowEventTooltips = True
        Me.Calendar1.ShowTodayButton = True
        Me.Calendar1.Size = New System.Drawing.Size(819, 560)
        Me.Calendar1.TabIndex = 0
        Me.Calendar1.TodayFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        '
        'Tab_Calendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(819, 560)
        Me.Controls.Add(Me.Calendar1)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.Document), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tab_Calendar"
        Me.Text = "Calendar"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Calendar1 As Calendar.NET.Calendar
End Class

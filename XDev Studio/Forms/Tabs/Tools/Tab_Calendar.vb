Friend Class Tab_Calendar

    Private Sub Tab_Calendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Calendar1.CalendarDate = DateTime.Now
        Calendar1.CalendarView = Calendar.NET.CalendarViews.Month
    End Sub
End Class
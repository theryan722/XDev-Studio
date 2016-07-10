Friend Class pnlToolPanel
    Dim StopWatch As New Diagnostics.Stopwatch
    
#Region "Converter"

    Private Sub txt_from_TextChanged(sender As Object, e As EventArgs) Handles txt_from.TextChanged
        If IsNumeric(txt_from.Text) Then
            PerformConvert()
        End If
    End Sub

    Private Sub combo_from_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_from.SelectedIndexChanged
        If IsNumeric(txt_from.Text) Then
            PerformConvert()
        End If
    End Sub

    Private Sub combo_to_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_to.SelectedIndexChanged
        If IsNumeric(txt_from.Text) Then
            PerformConvert()
        End If
    End Sub

    Private Sub PerformConvert()
        If combo_from.SelectedItem = "Byte" And combo_to.SelectedItem = "Byte" Then
            txt_result.Text = txt_from.Text * 1
        ElseIf combo_from.SelectedItem = "Byte" And combo_to.SelectedItem = "Kilobyte" Then
            txt_result.Text = txt_from.Text * 0.0009765625
        ElseIf combo_from.SelectedItem = "Byte" And combo_to.SelectedItem = "Megabyte" Then
            txt_result.Text = txt_from.Text * 0.000000954
        ElseIf combo_from.SelectedItem = "Byte" And combo_to.SelectedItem = "Gigabyte" Then
            txt_result.Text = txt_from.Text * 0.0000000009313225746
        ElseIf combo_from.SelectedItem = "Byte" And combo_to.SelectedItem = "Terabyte" Then
            txt_result.Text = txt_from.Text * 0.0000000000009094947018
        ElseIf combo_from.SelectedItem = "Byte" And combo_to.SelectedItem = "Petabyte" Then
            txt_result.Text = txt_from.Text * 0.0000000000000008881784197


        ElseIf combo_from.SelectedItem = "Kilobyte" And combo_to.SelectedItem = "Byte" Then
            txt_result.Text = txt_from.Text * 1024
        ElseIf combo_from.SelectedItem = "Kilobyte" And combo_to.SelectedItem = "Kilobyte" Then
            txt_result.Text = txt_from.Text * 1
        ElseIf combo_from.SelectedItem = "Kilobyte" And combo_to.SelectedItem = "Megabyte" Then
            txt_result.Text = txt_from.Text * 0.000976562
        ElseIf combo_from.SelectedItem = "Kilobyte" And combo_to.SelectedItem = "Gigabyte" Then
            txt_result.Text = txt_from.Text * 0.000000954
        ElseIf combo_from.SelectedItem = "Kilobyte" And combo_to.SelectedItem = "Terabyte" Then
            txt_result.Text = txt_from.Text * 0.0000000009313225746
        ElseIf combo_from.SelectedItem = "Kilobyte" And combo_to.SelectedItem = "Petabyte" Then
            txt_result.Text = txt_from.Text * 0.0000000000009094947018


        ElseIf combo_from.SelectedItem = "Megabyte" And combo_to.SelectedItem = "Byte" Then
            txt_result.Text = txt_from.Text * 1048576
        ElseIf combo_from.SelectedItem = "Megabyte" And combo_to.SelectedItem = "Kilobyte" Then
            txt_result.Text = txt_from.Text * 1024
        ElseIf combo_from.SelectedItem = "Megabyte" And combo_to.SelectedItem = "Megabyte" Then
            txt_result.Text = txt_from.Text * 1
        ElseIf combo_from.SelectedItem = "Megabyte" And combo_to.SelectedItem = "Gigabyte" Then
            txt_result.Text = txt_from.Text * 0.000976563
        ElseIf combo_from.SelectedItem = "Megabyte" And combo_to.SelectedItem = "Terabyte" Then
            txt_result.Text = txt_from.Text * 0.000000954
        ElseIf combo_from.SelectedItem = "Megabyte" And combo_to.SelectedItem = "Petabyte" Then
            txt_result.Text = txt_from.Text * 0.0000000009313225746


        ElseIf combo_from.SelectedItem = "Gigabyte" And combo_to.SelectedItem = "Byte" Then
            txt_result.Text = txt_from.Text * 1073741824
        ElseIf combo_from.SelectedItem = "Gigabyte" And combo_to.SelectedItem = "Kilobyte" Then
            txt_result.Text = txt_from.Text * 1048576
        ElseIf combo_from.SelectedItem = "Gigabyte" And combo_to.SelectedItem = "Megabyte" Then
            txt_result.Text = txt_from.Text * 1024
        ElseIf combo_from.SelectedItem = "Gigabyte" And combo_to.SelectedItem = "Gigabyte" Then
            txt_result.Text = txt_from.Text * 1
        ElseIf combo_from.SelectedItem = "Gigabyte" And combo_to.SelectedItem = "Terabyte" Then
            txt_result.Text = txt_from.Text * 0.000976562
        ElseIf combo_from.SelectedItem = "Gigabyte" And combo_to.SelectedItem = "Petabyte" Then
            txt_result.Text = txt_from.Text * 0.000000954


        ElseIf combo_from.SelectedItem = "Terabyte" And combo_to.SelectedItem = "Byte" Then
            txt_result.Text = txt_from.Text * 1099511628000.0
        ElseIf combo_from.SelectedItem = "Terabyte" And combo_to.SelectedItem = "Kilobyte" Then
            txt_result.Text = txt_from.Text * 1073741824
        ElseIf combo_from.SelectedItem = "Terabyte" And combo_to.SelectedItem = "Megabyte" Then
            txt_result.Text = txt_from.Text * 1048576
        ElseIf combo_from.SelectedItem = "Terabyte" And combo_to.SelectedItem = "Gigabyte" Then
            txt_result.Text = txt_from.Text * 1024
        ElseIf combo_from.SelectedItem = "Terabyte" And combo_to.SelectedItem = "Terabyte" Then
            txt_result.Text = txt_from.Text * 1
        ElseIf combo_from.SelectedItem = "Terabyte" And combo_to.SelectedItem = "Petabyte" Then
            txt_result.Text = txt_from.Text * 0.000976563


        ElseIf combo_from.SelectedItem = "Petabyte" And combo_to.SelectedItem = "Byte" Then
            txt_result.Text = txt_from.Text * 1.125899907E+15
        ElseIf combo_from.SelectedItem = "Petabyte" And combo_to.SelectedItem = "Kilobyte" Then
            txt_result.Text = txt_from.Text * 1099511628000.0
        ElseIf combo_from.SelectedItem = "Petabyte" And combo_to.SelectedItem = "Megabyte" Then
            txt_result.Text = txt_from.Text * 1073741824
        ElseIf combo_from.SelectedItem = "Petabyte" And combo_to.SelectedItem = "Gigabyte" Then
            txt_result.Text = txt_from.Text * 1048576
        ElseIf combo_from.SelectedItem = "Petabyte" And combo_to.SelectedItem = "Terabyte" Then
            txt_result.Text = txt_from.Text * 1024
        ElseIf combo_from.SelectedItem = "Petabyte" And combo_to.SelectedItem = "Petabyte" Then
            txt_result.Text = txt_from.Text * 1
        End If
    End Sub

#End Region

    Private Sub Timer_Stopwatch_Tick(sender As Object, e As EventArgs) Handles Timer_Stopwatch.Tick
        Dim elapsed As TimeSpan = Me.StopWatch.Elapsed
        lbl_stopwatch.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", Math.Floor(elapsed.TotalHours), elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds)
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Timer_Stopwatch.Start()
        Me.StopWatch.Start()
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Timer_Stopwatch.Stop()
        Me.StopWatch.Stop()
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Me.StopWatch.Reset()
        lbl_stopwatch.Text = "00:00:00:000"
        lb_stopwatch.Items.Clear()
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        lb_stopwatch.Items.Add(lbl_stopwatch.Text)
    End Sub
End Class
Imports DifferenceEngine

Friend Class Tab_DifferenceViewer
    Private _level As DiffEngineLevel = DiffEngineLevel.FastImperfect

#Region "Compare"

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        txt_file1.Text = ""
        txt_file2.Text = ""
    End Sub

    Private Sub btn_browse_file1_Click(sender As Object, e As EventArgs) Handles btn_browse_file1.Click
        Dim newb As New OpenFileDialog
        newb.Filter = frmManager.GetFileFilter()
        newb.Title = "Open File 1"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_file1.Text = newb.FileName
        End If
    End Sub

    Private Sub btn_browse_file2_Click(sender As Object, e As EventArgs) Handles btn_browse_file2.Click
        Dim newb As New OpenFileDialog
        newb.Filter = frmManager.GetFileFilter()
        newb.Title = "Open File 2"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_file2.Text = newb.FileName
        End If
    End Sub

    Private Function CheckIfFieldsValid() As Boolean
        Return txt_file1.Text <> "" And txt_file2.Text <> ""
    End Function

    Private Sub btn_compare_Click(sender As Object, e As EventArgs) Handles btn_compare.Click
        If CheckIfFieldsValid() Then
            If radio_fast.Checked Then
                _level = DiffEngineLevel.FastImperfect
            ElseIf radio_medium.Checked Then
                _level = DiffEngineLevel.Medium
            ElseIf radio_slow.Checked Then
                _level = DiffEngineLevel.SlowPerfect
            End If
            TextDiff(txt_file1.Text, txt_file2.Text)
        End If
    End Sub

#End Region

#Region "Results"

#Region "Context Menu Strips"

#Region "File 1"

    Private Sub OpenFileInEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileInEditorToolStripMenuItem.Click
        If txt_file1.Text <> "" Then
            Try
                Tabs.AddCode(txt_file1.Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub OpenFileInExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileInExplorerToolStripMenuItem.Click
        If txt_file1.Text <> "" Then
            Try
                System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(txt_file1.Text))
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub OpenFileInNotepadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileInNotepadToolStripMenuItem.Click
        If txt_file1.Text <> "" Then
            Try
                Tabs.AddNotepad(My.Computer.FileSystem.ReadAllText(txt_file1.Text), txt_file1.Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

#Region "File 2"

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If txt_file2.Text <> "" Then
            Try
                Tabs.AddCode(txt_file2.Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If txt_file2.Text <> "" Then
            Try
                System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(txt_file2.Text))
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If txt_file2.Text <> "" Then
            Try
                Tabs.AddNotepad(My.Computer.FileSystem.ReadAllText(txt_file2.Text), txt_file2.Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

#End Region

#End Region

#Region "Methods"

    Private Sub TextDiff(sFile As String, dFile As String)
        Dim sLF As DiffList_TextFile = Nothing
        Dim dLF As DiffList_TextFile = Nothing
        Try
            sLF = New DiffList_TextFile(sFile)
            dLF = New DiffList_TextFile(dFile)
        Catch ex As Exception
            Logger.WriteError(ex)
            Return
        End Try
        Try
            Dim time As Double = 0
            Dim de As New DiffEngine()
            time = de.ProcessDiff(sLF, dLF, _level)
            Dim rep As ArrayList = de.DiffReport()
            DisplayResults(sLF, dLF, rep, time)
        Catch ex As Exception
            Dim tmp As String = String.Format("{0}{1}{1}***STACK***{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace)
            MessageBox.Show(tmp, "Compare Error")
            Return
        End Try
    End Sub

    Private Sub DisplayResults(ByVal source As DiffList_TextFile, ByVal destination As DiffList_TextFile, ByVal DiffLines As ArrayList, ByVal seconds As Double)
        lvSource.Items.Clear()
        lvDestination.Items.Clear()
        Dim lviS As ListViewItem
        Dim lviD As ListViewItem
        Dim cnt As Integer = 1
        Dim i As Integer
        For Each drs As DiffResultSpan In DiffLines
            Select Case drs.Status
                Case DiffResultSpanStatus.DeleteSource
                    For i = 0 To drs.Length - 1
                        lviS = New ListViewItem(cnt.ToString("00000"))
                        lviD = New ListViewItem(cnt.ToString("00000"))
                        lviS.BackColor = Color.Red
                        lviS.SubItems.Add(DirectCast(source.GetByIndex(drs.SourceIndex + i), TextLine).Line)
                        lviD.BackColor = Color.LightGray
                        lviD.SubItems.Add("")

                        lvSource.Items.Add(lviS)
                        lvDestination.Items.Add(lviD)
                        cnt += 1
                    Next
                    Exit Select
                Case DiffResultSpanStatus.NoChange
                    For i = 0 To drs.Length - 1
                        lviS = New ListViewItem(cnt.ToString("00000"))
                        lviD = New ListViewItem(cnt.ToString("00000"))
                        lviS.BackColor = Color.White
                        lviS.SubItems.Add(DirectCast(source.GetByIndex(drs.SourceIndex + i), TextLine).Line)
                        lviD.BackColor = Color.White
                        lviD.SubItems.Add(DirectCast(destination.GetByIndex(drs.DestIndex + i), TextLine).Line)

                        lvSource.Items.Add(lviS)
                        lvDestination.Items.Add(lviD)
                        cnt += 1
                    Next
                    Exit Select
                Case DiffResultSpanStatus.AddDestination
                    For i = 0 To drs.Length - 1
                        lviS = New ListViewItem(cnt.ToString("00000"))
                        lviD = New ListViewItem(cnt.ToString("00000"))
                        lviS.BackColor = Color.LightGray
                        lviS.SubItems.Add("")
                        lviD.BackColor = Color.LightGreen
                        lviD.SubItems.Add(DirectCast(destination.GetByIndex(drs.DestIndex + i), TextLine).Line)

                        lvSource.Items.Add(lviS)
                        lvDestination.Items.Add(lviD)
                        cnt += 1
                    Next
                    Exit Select
                Case DiffResultSpanStatus.Replace
                    For i = 0 To drs.Length - 1
                        lviS = New ListViewItem(cnt.ToString("00000"))
                        lviD = New ListViewItem(cnt.ToString("00000"))
                        lviS.BackColor = Color.Red
                        lviS.SubItems.Add(DirectCast(source.GetByIndex(drs.SourceIndex + i), TextLine).Line)
                        lviD.BackColor = Color.LightGreen
                        lviD.SubItems.Add(DirectCast(destination.GetByIndex(drs.DestIndex + i), TextLine).Line)

                        lvSource.Items.Add(lviS)
                        lvDestination.Items.Add(lviD)
                        cnt += 1
                    Next
                    Exit Select
            End Select
        Next
        MetroTabControl1.SelectedTab = Tab_Results
    End Sub

#End Region

End Class
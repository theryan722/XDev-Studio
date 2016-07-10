Friend Class Tab_ImageMapper

    Private mRecord As Boolean
    Private mPoints As SortedList
    Private mPointCount As Integer

    Private Sub Tab_ImageMapper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mPointCount = 0
        Me.DoubleBuffered = True
    End Sub

    Public Sub LoadImage(ByVal imgloc As String)
        If System.IO.File.Exists(imgloc) Then
            Try
                Dim img As New Bitmap(imgloc)
                PictureBox1.Image = img
                PictureBox1.Refresh()
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click
        Try
            mRecord = False
            Dim strPoints As String = ""
            Dim fname As String = ""
            Dim de As DictionaryEntry
            For Each de In mPoints
                strPoints = strPoints + de.Value.ToString() + Environment.NewLine
            Next
            Tabs.AddNotepad(strPoints)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        If mRecord = True Then
            MetroFramework.MetroMessageBox.Show(frmManager, "Already recording.", "Recording", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        mRecord = True
        mPoints = New SortedList
        mPoints.Clear()
        mPointCount = 0
    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        If mRecord = True Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                'record
                mPoints.Add("Point " & mPointCount.ToString(), e.X & ", " & e.Y)
                mPointCount += 1
            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Try
            PictureBox1.Refresh()

            ToolTip1.SetToolTip(PictureBox1, e.X & ", " & e.Y)

        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub OpenImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenImageToolStripMenuItem.Click
        Dim openFile As New System.Windows.Forms.OpenFileDialog
        openFile.DefaultExt = "bmp"
        openFile.Filter = "PNG File (*.png)|*.png|Jpeg File (*.jpg)|*.jpg|Bitmap File (*.bmp)|*.bmp|Gif File (*.gif)|*.gif"
        openFile.ShowDialog()
        If openFile.FileNames.Length > 0 Then
            Dim img As New Bitmap(openFile.FileName.ToString())
            PictureBox1.Image = img
            PictureBox1.Refresh()
        End If
    End Sub

    Private Sub ClearImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearImageToolStripMenuItem.Click
        PictureBox1.Image = Nothing
        PictureBox1.Refresh()
        If mRecord = True Then
            Me.mRecord = False
            Me.mPoints.Clear()
        End If
    End Sub
End Class
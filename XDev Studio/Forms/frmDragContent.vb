Friend Class frmDragContent

    Private Sub frmDragContent_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Try
            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
            frmManager.OpenFile(files)
            Me.Close()
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Sub frmDragContent_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub frmDragContent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormPosition.CenterForm(Me, frmManager)
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmDragContent_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        Me.Close()
    End Sub
End Class
Imports System.IO
Imports System.Reflection

Friend Class AppLoader
    Private Shared applist As String()

    Public Shared Function InitializeApps() As ICollection(Of AppObject)
        Try
            If Directory.Exists(XDev.Path.Locator.GetDataPath + "\Apps") Then
                applist = Directory.GetFiles(XDev.Path.Locator.GetDataPath + "\Apps", "*.xaf")
                Dim newb As ICollection(Of AppObject) = New List(Of AppObject)(applist.Count)
                For Each item As String In applist
                    newb.Add(CreateAppObjectFromFile(item))
                Next
                Return newb
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmManager, "There was an error loading apps.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Logger.WriteError(ex)
            Return Nothing
        End Try
    End Function

    Private Shared Function CreateAppObjectFromFile(ByVal floc As String) As AppObject
        Try
            Dim b As New AppObject
            Dim xml = XDocument.Load(floc)
            b.Name = xml.<XDevApp>.<Name>.Value
            b.Command = xml.<XDevApp>.<Command>.Value
            b.Arguments = xml.<XDevApp>.<Arguments>.Value
            b.FileLoc = floc
            Return b
        Catch ex As Exception
            Logger.WriteError(ex)
            Return Nothing
        End Try
    End Function

End Class

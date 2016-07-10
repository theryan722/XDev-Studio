Friend Class AppManager

#Region "Apps"

    Private Shared _Apps As New Dictionary(Of String, AppObject)

    Public Shared Function GetAppsList() As List(Of AppObject)
        Dim bb As New List(Of AppObject)
        bb.AddRange(_Apps)
        Return bb
    End Function

    Public Shared Sub LoadApps()
        Dim apps As ICollection(Of AppObject) = AppLoader.InitializeApps()
        If apps Is Nothing Then
            Logger.Write(Logger.TypeOfLog.Studio, "No apps to load.")
            Return
        End If
        Dim totapps As Integer = 0
        For Each item In apps
            totapps += 1
            _Apps.Add(item.Name, item)
            Dim b = New ToolStripMenuItem With {.Text = item.Name}
            AddHandler b.Click, AddressOf b_Click
            frmManager.AppsToolStripMenuItem.DropDownItems.Add(b)
        Next
        Logger.Write(Logger.TypeOfLog.Studio, "Loaded " & totapps & " Apps")
    End Sub

    Private Shared Sub b_Click(sender As Object, e As EventArgs)
        Dim b As ToolStripMenuItem = sender
        If b IsNot Nothing Then
            Dim key As String = b.Text.ToString()
            If _Apps.ContainsKey(key) Then
                Dim app As AppObject = _Apps(key)
                app.RunApp()
            End If
        End If
    End Sub

#End Region

End Class

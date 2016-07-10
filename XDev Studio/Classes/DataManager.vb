Friend Class DataManager

    Private Shared ReadOnly folders_workspace() As String = {"Backups", "CustomLanguages", "Downloads", "Files", "Projects", "Sessions", "CodeRecovery", "CodeBank", "Scripts"}
    Private Shared ReadOnly folders_data() As String = {"Logs", "Apps", "Editor", "Profiles", "Profiles\Data"}

#Region "Folder Creation"

#Region "Workspace"

    Private Shared Sub CreateWorkspaceFolders()
        Dim workspacePath As String = XDev.Path.Locator.GetWorkspacePath
        Try
            For Each item As String In folders_workspace
                System.IO.Directory.CreateDirectory(workspacePath & "\" & item)
            Next
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Shared Sub CheckAndCreateIndividualWorkspaceFolders()
        Dim workspacePath As String = XDev.Path.Locator.GetWorkspacePath
        Try
            For Each item As String In folders_workspace
                If Not System.IO.Directory.Exists(workspacePath & "\" & item) Then
                    System.IO.Directory.CreateDirectory(workspacePath & "\" & item)
                End If
            Next
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

#End Region

#Region "Data"

    Private Shared Sub CreateDataFolders()
        Dim dataPath As String = XDev.Path.Locator.GetDataPath()
        Try
            For Each item As String In folders_data
                System.IO.Directory.CreateDirectory(dataPath & "\" & item)
            Next
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Shared Sub CheckAndCreateIndividualDataFolders()
        Dim dataPath As String = XDev.Path.Locator.GetDataPath()
        Try
            For Each item As String In folders_data
                If Not System.IO.Directory.Exists(dataPath & "\" & item) Then
                    System.IO.Directory.CreateDirectory(dataPath & "\" & item)
                End If
            Next
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

#End Region
    
    Private Shared Sub CheckAndCreateIndividualFolders()
        CheckAndCreateIndividualWorkspaceFolders()
        CheckAndCreateIndividualDataFolders()
    End Sub

#End Region

#Region "File Creation"

    Private Shared Sub CheckAndCreateFiles()
        Dim dataPath As String = XDev.Path.Locator.GetDataPath()
        Try
            If Not System.IO.File.Exists(dataPath & "\Logs\log_code.txt") Then
                System.IO.File.Create(dataPath & "\Logs\log_code.txt")
            End If
            If Not System.IO.File.Exists(dataPath & "\Logs\log_plugin.txt") Then
                System.IO.File.Create(dataPath & "\Logs\log_plugin.txt")
            End If
            If Not System.IO.File.Exists(dataPath & "\Logs\log_studio.txt") Then
                System.IO.File.Create(dataPath & "\Logs\log_studio.txt")
            End If
            If Not System.IO.File.Exists(dataPath & "\Editor\syntaxhighlighting.xml") Then
                System.IO.File.Copy(XDev.Path.Locator.GetAppPath & "\Engine\Editor\syntaxhighlighting_default.xml", dataPath & "\Editor\syntaxhighlighting.xml")
            End If
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

#End Region

#Region "Recreate"

    Public Shared Sub RecreateAllFolders()
        CreateWorkspaceFolders()
        CreateDataFolders()
    End Sub

    Public Shared Sub RecreateAllFiles()
        CheckAndCreateFiles()
    End Sub

    Public Shared Sub RecreateAll()
        RecreateAllFolders()
        RecreateAllFiles()
    End Sub

#End Region

    Public Shared Sub CheckAllData()
        Dim appPath As String = XDev.Path.Locator.GetAppPath
        Dim workspacePath As String = XDev.Path.Locator.GetWorkspacePath
        Dim dataPath As String = XDev.Path.Locator.GetDataPath()
        If Not System.IO.Directory.Exists(workspacePath) Then
            CreateWorkspaceFolders()
        End If
        If Not System.IO.Directory.Exists(dataPath) Then
            CreateDataFolders()
        End If
        'Check individual sub-folders
        CheckAndCreateIndividualFolders()
        CheckAndCreateFiles()
    End Sub

End Class

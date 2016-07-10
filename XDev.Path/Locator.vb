Public Class Locator

    ''' <summary>
    ''' The location used to store XDev Studio data
    ''' </summary>
    ''' <returns>String, the data path</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDataPath() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\XDev Studio"
    End Function

    ''' <summary>
    ''' The studio location
    ''' </summary>
    ''' <returns>String, the path where the studio is located</returns>
    ''' <remarks></remarks>
    Public Shared Function GetAppPath() As String
        Dim i As Integer
        Dim strAppPath As String
        strAppPath = System.Reflection.Assembly.GetExecutingAssembly.Location()
        i = strAppPath.Length - 1
        Do Until strAppPath.Substring(i, 1) = "\"
            i = i - 1
        Loop
        strAppPath = strAppPath.Substring(0, i)
        Return strAppPath
    End Function

    ''' <summary>
    ''' The workspace location
    ''' </summary>
    ''' <returns>String, the workspace path</returns>
    ''' <remarks></remarks>
    Public Shared Function GetWorkspacePath() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\XDev Studio\Workspace"
    End Function

End Class

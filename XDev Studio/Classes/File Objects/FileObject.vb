Friend Class FileObject
    Private filename As String
    Private filelanguage As XDev.Editor.Language.EditorLanguage
    Private filelocation As String

    'Constructor
    Public Sub New(ByVal fname As String, flang As XDev.Editor.Language.EditorLanguage, floc As String)
        SetFileName(fname)
        SetFileLanguage(flang)
        SetFileLocation(floc)
    End Sub

    'Return the filename
    Public Overrides Function ToString() As String
        Return GetFileName()
    End Function

#Region "Setters"

    'Set the filename
    Public Sub SetFileName(ByVal name As String)
        filename = name
    End Sub

    'Set the language of the file
    Public Sub SetFileLanguage(ByVal lang As XDev.Editor.Language.EditorLanguage)
        filelanguage = lang
    End Sub

    'Set the location of the file
    Public Sub SetFileLocation(ByVal loc As String)
        filelocation = loc
    End Sub

#End Region

#Region "Getters"

    'Get the filename
    Public Function GetFileName() As String
        Return filename
    End Function

    'Get the language of the file
    Public Function GetFileLanguage() As XDev.Editor.Language.EditorLanguage
        Return filelanguage
    End Function

    'Get the location of the file
    Public Function GetFileLocation() As String
        Return filelocation
    End Function

#End Region

End Class

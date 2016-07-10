
'Used by: Tab_Bookmarks
Friend Class SearchObject
    Private fsearchindex As Integer
    Private filelocation As String
    Private fsearchline As Integer
    Private filelanguage As XDev.Editor.Language.EditorLanguage

    'Constructor
    Public Sub New(ByVal fline As Integer, ByVal flocation As String, ByVal flang As XDev.Editor.Language.EditorLanguage)
        SetSearchLine(fline)
        SetFileLocation(flocation)
        SetFileLanguage(flang)
    End Sub

#Region "Setters"

    'Set the location of the file
    Public Sub SetFileLocation(ByVal loc As String)
        filelocation = loc
    End Sub

    'For possible future usage or extensibility
    Public Sub SetSearchIndex(ByVal index As Integer)
        fsearchindex = index
    End Sub

    'The line where the bookmark is
    Public Sub SetSearchLine(ByVal line As Integer)
        fsearchline = line
    End Sub

    'The language of the file
    Public Sub SetFileLanguage(ByVal lang As XDev.Editor.Language.EditorLanguage)
        filelanguage = lang
    End Sub
#End Region

#Region "Getters"

    'Get the location of the file
    Public Function GetFileLocation() As String
        Return filelocation
    End Function

    'For possible future usage or extensibility
    Public Function GetSearchIndex() As Integer
        Return fsearchindex
    End Function

    'Get the line where the bookmark is
    Public Function GetSearchLine() As Integer
        Return fsearchline
    End Function

    'Get the language of the file
    Public Function GetFileLanguage() As XDev.Editor.Language.EditorLanguage
        Return filelanguage
    End Function

#End Region

    'For possible future usage or extensibility
    Public Sub ResetSearchIndex()
        fsearchindex = Nothing
    End Sub

    Public Sub ResetSearchLine()
        fsearchline = Nothing
    End Sub
End Class

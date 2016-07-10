'Used by: Tab_UniversalSearch

Public Class USearchObject

    Private document As XDockContent
    Private fsearchline As Integer

    'Constructor
    Public Sub New(ByVal fline As Integer, ByVal doc As XDockContent)
        SetSearchLine(fline)
        SetDocument(doc)
    End Sub

#Region "Setters"

    'Set the doc
    Public Sub SetDocument(ByVal doc As XDockContent)
        document = doc
    End Sub

    'The line where the bookmark is
    Public Sub SetSearchLine(ByVal line As Integer)
        fsearchline = line
    End Sub

#End Region

#Region "Getters"

    'Get the document
    Public Function GetDocument() As XDockContent
        Return document
    End Function

    'Get the line where the bookmark is
    Public Function GetSearchLine() As Integer
        Return fsearchline
    End Function

#End Region

    Public Sub ResetSearchLine()
        fsearchline = Nothing
    End Sub

End Class

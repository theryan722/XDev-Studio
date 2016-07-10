'Speed Dial Object
Friend Class SDObject

    Private timage As String
    Private taction As String

    Public Sub New(ByVal image As String, ByVal action As String)
        SetImage(image)
        SetAction(action)
    End Sub

#Region "Setters"

    Public Sub SetImage(ByVal img As String)
        timage = img
    End Sub

    Public Sub SetAction(ByVal action As String)
        taction = action
    End Sub

#End Region

#Region "Getters"

    Public Function GetImage() As String
        Return timage
    End Function

    Public Function GetAction() As String
        Return taction
    End Function

#End Region

End Class

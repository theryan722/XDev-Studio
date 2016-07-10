Public Class QCObject

    Public Property Text As String
    Public Property MenuItem As ToolStripMenuItem

    Public Sub New(ByVal txt As String, mnuitem As ToolStripMenuItem)
        Text = txt
        MenuItem = mnuitem
    End Sub

End Class
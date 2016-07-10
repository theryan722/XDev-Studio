Imports System.Xml
Imports System.Text

Friend Class SessionManager

    Public Shared Sub SaveSessionFile(ByVal loc As String, ByVal files As List(Of String))
        If files.Count > 0 Then
            Try
                Dim writer As New XmlTextWriter(loc, System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("XDevStudio_Session")
                For Each item As String In files
                    writer.WriteStartElement("File")
                    writer.WriteString(item)
                    writer.WriteEndElement()
                Next
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Public Shared Function ReadSessionFile(ByVal loc As String) As List(Of String)
        Dim sessionlist As New List(Of String)
        If System.IO.File.Exists(loc) Then
            Try
                Dim doc As New XmlDocument()
                doc.Load(loc)
                Dim m_node = doc.SelectSingleNode("/XDevStudio_Session")

                For i = 0 To m_node.ChildNodes.Count - 1
                    sessionlist.Add(m_node.ChildNodes.Item(i).InnerText)
                Next i
                Return sessionlist
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
    End Function

End Class

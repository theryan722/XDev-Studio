Public Class QuickCommandLoader
    
    Public Shared Function GetQuickCommandList() As List(Of QCObject)
        Dim toadd As New List(Of ToolStripMenuItem)
        Dim QCList As New List(Of QCObject)
        For Each topmenu As ToolStripMenuItem In frmManager.MenuStrip1.Items
            If topmenu.HasDropDownItems Then
                For Each dmenu As Object In topmenu.DropDownItems 'menu items in main header
                    If Not TypeOf (dmenu) Is ToolStripSeparator Then
                        If CType(dmenu, ToolStripMenuItem).Tag <> "" Then
                            toadd.Add(CType(dmenu, ToolStripMenuItem))
                        Else
                            If dmenu.HasDropDownItems Then
                                For Each item As Object In AddFromDropDownItems(dmenu)
                                    toadd.Add(CType(item, ToolStripMenuItem))
                                Next
                            End If
                        End If
                    End If
                Next
            End If
        Next
        For Each item As ToolStripMenuItem In toadd
            QCList.Add(New QCObject(item.Tag, item))
        Next
        Return QCList
    End Function

    Private Shared Function AddFromDropDownItems(ByVal mnuitem As Object) As List(Of ToolStripMenuItem)
        Dim tadd As New List(Of ToolStripMenuItem)
        If Not TypeOf (mnuitem) Is ToolStripSeparator Then
            For Each dmenu As Object In CType(mnuitem, ToolStripMenuItem).DropDownItems
                If Not TypeOf (dmenu) Is ToolStripSeparator Then
                    If CType(dmenu, ToolStripMenuItem).Tag <> "" Then
                        tadd.Add(CType(dmenu, ToolStripMenuItem))
                    ElseIf CType(dmenu, ToolStripMenuItem).HasDropDownItems Then
                        For Each item As Object In AddFromDropDownItems(dmenu)
                            If Not TypeOf (item) Is ToolStripSeparator Then
                                tadd.Add(item)
                            End If
                        Next
                    End If
                End If
            Next
        End If
        
        Return tadd
    End Function

End Class

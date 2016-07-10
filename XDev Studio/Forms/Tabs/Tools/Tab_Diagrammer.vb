Imports System.IO
Imports Dalssoft.DiagramNet

Friend Class Tab_Diagrammer

    Private fileloc As String = ""
    Private changeDocumentProp As Boolean = True

#Region "Designer1"

    Private Sub Document_PropertyChanged()
        changeDocumentProp = False
        Action_None()
        Select Case Designer1.Document.Action
            Case DesignerAction.[Select]
                Action_Size()
                Exit Select
            Case DesignerAction.Delete
                Action_Delete()
                Exit Select
            Case DesignerAction.Connect
                Action_Connect()
                Exit Select
            Case DesignerAction.Add
                Action_Add(Designer1.Document.ElementType)
                Exit Select
        End Select
        Edit_UpdateUndoRedoEnable()
        changeDocumentProp = True
    End Sub

#End Region

#Region "Methods"

#Region "Functions"

    Private Sub Edit_UpdateUndoRedoEnable()
        mnuUndo.Enabled = Designer1.CanUndo
        mnuRedo.Enabled = Designer1.CanRedo
    End Sub

    Private Sub Edit_Undo()
        If Designer1.CanUndo Then
            Designer1.Undo()
        End If

        Edit_UpdateUndoRedoEnable()
    End Sub

    Private Sub Edit_Redo()
        If Designer1.CanRedo Then
            Designer1.Redo()
        End If

        Edit_UpdateUndoRedoEnable()
    End Sub

    Private Sub Action_None()
        mnuSize.Checked = False
        mnuAdd.Checked = False
        mnuDelete.Checked = False
        mnuConnect.Checked = False
        mnuRectangleNode.Checked = False
        mnuElipseNode.Checked = False
    End Sub

    Private Sub Action_Size()
        Action_None()
        mnuSize.Checked = True
        If changeDocumentProp Then
            Designer1.Document.Action = DesignerAction.[Select]
        End If
    End Sub

    Private Sub Action_Add(e As ElementType)
        Action_None()
        mnuAdd.Checked = True
        Select Case e
            Case ElementType.RectangleNode
                mnuRectangleNode.Checked = True
                Exit Select
            Case ElementType.ElipseNode
                mnuElipseNode.Checked = True
                Exit Select
        End Select

        If changeDocumentProp Then
            Designer1.Document.Action = DesignerAction.Add
            Designer1.Document.ElementType = e
        End If
    End Sub

    Private Sub Action_Delete()
        Action_None()
        mnuDelete.Checked = True
        If changeDocumentProp Then
            Designer1.Document.DeleteSelectedElements()
        End If
        Action_None()
    End Sub

    Private Sub Action_Connect()
        Action_None()
        mnuConnect.Checked = True
        If changeDocumentProp Then
            Designer1.Document.Action = DesignerAction.Connect
        End If
    End Sub

    Private Sub Action_Connector(lt As LinkType)
        Action_None()
        Select Case lt
            Case LinkType.Straight
                mnuStraight.Checked = True
                mnuRightAngle.Checked = False
                Exit Select
            Case LinkType.RightAngle
                mnuStraight.Checked = False
                mnuRightAngle.Checked = True
                Exit Select
        End Select
        Designer1.Document.LinkType = lt
        Action_Connect()
    End Sub

    Private Sub Action_Zoom(zoom As Single)
        Designer1.Document.Zoom = zoom
    End Sub

    Private Sub Order_BringToFront()
        If Designer1.Document.SelectedElements.Count = 1 Then
            Designer1.Document.BringToFrontElement(Designer1.Document.SelectedElements(0))
            Designer1.Refresh()
        End If
    End Sub

    Private Sub Order_SendToBack()
        If Designer1.Document.SelectedElements.Count = 1 Then
            Designer1.Document.SendToBackElement(Designer1.Document.SelectedElements(0))
            Designer1.Refresh()
        End If
    End Sub

    Private Sub Order_MoveUp()
        If Designer1.Document.SelectedElements.Count = 1 Then
            Designer1.Document.MoveUpElement(Designer1.Document.SelectedElements(0))
            Designer1.Refresh()
        End If
    End Sub

    Private Sub Order_MoveDown()
        If Designer1.Document.SelectedElements.Count = 1 Then
            Designer1.Document.MoveDownElement(Designer1.Document.SelectedElements(0))
            Designer1.Refresh()
        End If
    End Sub

#End Region

#End Region

#Region "Menu Strip"

#Region "File"

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim newb As New OpenFileDialog
        newb.Filter = "XDev Diagram Files (*.xddf)|*.xddf"
        newb.InitialDirectory = XDev.Path.Locator.GetWorkspacePath
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Designer1.Open(newb.FileName)
                fileloc = newb.FileName
                Me.Text = Path.GetFileName(newb.FileName)
            Catch
            End Try
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If fileloc = "" Then
            SaveAsToolStripMenuItem.PerformClick()
        Else
            Designer1.Save(fileloc)
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim newb As New SaveFileDialog
        newb.Filter = "XDev Diagram Files (*.xddf)|*.xddf"
        newb.InitialDirectory = XDev.Path.Locator.GetWorkspacePath
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Designer1.Save(newb.FileName)
                Me.Text = Path.GetFileName(newb.FileName)
            Catch
            End Try
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        For Each b As Dalssoft.DiagramNet.BaseElement In Designer1.Document.Elements
            Designer1.Document.DeleteElement(b)
        Next
        fileloc = ""
        Me.Text = "Untitled"
    End Sub

#End Region

#Region "Edit"

#Region "Add"

    Private Sub mnuRectangleNode_Click(sender As Object, e As EventArgs) Handles mnuRectangleNode.Click
        Action_Add(ElementType.RectangleNode)
    End Sub

    Private Sub mnuElipseNode_Click(sender As Object, e As EventArgs) Handles mnuElipseNode.Click
        Action_Add(ElementType.ElipseNode)
    End Sub

    Private Sub CommentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommentToolStripMenuItem.Click
        Action_Add(ElementType.CommentBox)
    End Sub

#End Region

#Region "Order"

    Private Sub mnuBringToFront_Click(sender As Object, e As EventArgs) Handles mnuBringToFront.Click
        Order_BringToFront()
    End Sub

    Private Sub mnuSendToBack_Click(sender As Object, e As EventArgs) Handles mnuSendToBack.Click
        Order_SendToBack()
    End Sub

    Private Sub mnuMoveUp_Click(sender As Object, e As EventArgs) Handles mnuMoveUp.Click
        Order_MoveUp()
    End Sub

    Private Sub mnuMoveDown_Click(sender As Object, e As EventArgs) Handles mnuMoveDown.Click
        Order_MoveDown()
    End Sub

#End Region

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuUndo.Click
        Edit_Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuRedo.Click
        Edit_Redo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuCut.Click
        Designer1.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        Designer1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuPaste.Click
        Designer1.Paste()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        Action_Delete()
    End Sub

    Private Sub mnuSize_Click(sender As Object, e As EventArgs) Handles mnuSize.Click
        Action_Size()
    End Sub

    Private Sub mnuStraight_Click(sender As Object, e As EventArgs) Handles mnuStraight.Click
        Action_Connect()
        Action_Connector(LinkType.Straight)
    End Sub

    Private Sub mnuRightAngle_Click(sender As Object, e As EventArgs) Handles mnuRightAngle.Click
        Action_Connect()
        Action_Connector(LinkType.RightAngle)
    End Sub

#End Region

#Region "Zoom"

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Action_Zoom(0.1F)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Action_Zoom(0.25F)
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Action_Zoom(0.5F)
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Action_Zoom(0.75F)
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        Action_Zoom(1.0F)
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        Action_Zoom(1.25F)
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        Action_Zoom(1.5F)
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        Action_Zoom(1.75F)
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        Action_Zoom(2.0F)
    End Sub

#End Region

#End Region

#Region "Tab_Diagrammer"

    Private Sub Tab_Diagrammer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Edit_UpdateUndoRedoEnable()
        AddHandler Designer1.Document.PropertyChanged, AddressOf Document_PropertyChanged
    End Sub

#End Region

#Region "Context Menu Strip"

    Private Sub CutToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        mnuCut.PerformClick()
    End Sub

    Private Sub CopyToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        mnuCopy.PerformClick()
    End Sub

    Private Sub PasteToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        mnuPaste.PerformClick()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        mnuDelete.PerformClick()
    End Sub

    Private Sub UndoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        mnuUndo.PerformClick()
    End Sub

    Private Sub RedoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        mnuRedo.PerformClick()
    End Sub

#End Region

End Class
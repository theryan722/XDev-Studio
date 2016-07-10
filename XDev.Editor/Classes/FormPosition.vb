Imports System.Drawing
Imports System.Windows.Forms

Public Class FormPosition

    ''' <summary>
    ''' Centers a form
    ''' </summary>
    ''' <param name="frm">The form to center</param>
    ''' <param name="parent">The form to center in</param>
    ''' <remarks>Call from form load event</remarks>
    Public Shared Sub CenterForm(ByVal frm As Form, Optional ByVal parent As Form = Nothing)
        Dim r As Rectangle
        If parent IsNot Nothing Then
            r = parent.RectangleToScreen(parent.ClientRectangle)
        Else
            r = Screen.FromPoint(frm.Location).WorkingArea
        End If

        Dim x = r.Left + (r.Width - frm.Width) \ 2
        Dim y = r.Top + (r.Height - frm.Height) \ 2
        frm.Location = New Point(x, y)
    End Sub

End Class

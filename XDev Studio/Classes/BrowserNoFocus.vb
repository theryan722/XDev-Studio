Friend Class BrowserNoFocus
    Inherits WebBrowser
    Public Const WM_NCACTIVATE As UInt32 = &H86
    Public Const WM_SETFOCUS As UInt32 = &H7

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_SETFOCUS Then
            m.Result = IntPtr.Zero
        Else
            MyBase.WndProc(m)
        End If
    End Sub
End Class

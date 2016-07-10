Public Class NotificationManager

    'Public Shared Sub AddNotification(ByVal txt As String, Optional ByVal displayalert As Boolean = True, Optional ByVal notimg As pnlNotificationCenter.IconType = pnlNotificationCenter.IconType.Info)
    '    pnlNotificationCenter.AddNotification(txt, notimg)
    '    If displayalert Then
    '        Dim bb As String = ""
    '        If txt.Length > 40 Then
    '            bb = txt.Substring(0, 40) & "..."
    '        Else
    '            bb = txt
    '        End If
    '        Dim newb As New BN.Toast.ToastForm(1500, bb)
    '        newb.Height = "30"
    '        newb.TopMost = True
    '        newb.Show()
    '    End If
    'End Sub

    Public Shared Sub DisplayNotification(ByVal txt As String, Optional addtonotificationcenter As Boolean = True, Optional ByVal notimg As pnlNotificationCenter.IconType = pnlNotificationCenter.IconType.Info, Optional suppresstoast As Boolean = False)
        If addtonotificationcenter Then
            pnlNotificationCenter.AddNotification(txt, notimg)
        End If
        If Not suppresstoast Then
            Dim bb As String = ""
            If txt.Length > 40 Then
                bb = txt.Substring(0, 40) & "..."
            Else
                bb = txt
            End If
            Dim newb As New BN.Toast.ToastForm(1500, bb)
            newb.Height = "30"
            newb.TopMost = True
            newb.Show()
        End If
    End Sub

End Class

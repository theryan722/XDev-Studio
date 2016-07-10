Imports System.Threading

Friend Class Tab_RSSReader
    Private feedItems As ArrayList

    Private Sub lbItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbItems.SelectedIndexChanged
        If lbItems.Items.Count > 0 Then
            Dim currentItem As RSSItem

            currentItem = feedItems(lbItems.SelectedIndex)
            WebBrowser1.DocumentText = currentItem.Description
            linkItemURL.Text = currentItem.Link
            linkItemURL.Links(0).Start = 0
            linkItemURL.Links(0).Length = currentItem.Link.Length
            linkItemURL.Links(0).LinkData = currentItem.Link
        End If
    End Sub

    Private Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        ThreadPool.QueueUserWorkItem(AddressOf RefreshChannel)
    End Sub

    Private Sub Tab_RSSReader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item As String In My.Settings.set_rsshistory
            tbChannel.Items.Add(item)
        Next
        tbChannel.Text = My.Settings.set_rssdefaultfeed
        lblTitle.Text = ""
        lblDescription.Text = ""
        linkChannel.Text = ""
        linkChannel.Links.Add(0, 1, "")
        linkItemURL.Text = ""
        linkItemURL.Links.Add(0, 1, "")

        RefreshChannel()
    End Sub

    Private Sub linkItemURL_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkItemURL.LinkClicked
        System.Diagnostics.Process.Start(linkItemURL.Links(0).LinkData)
    End Sub

    Private Sub linkChannel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkChannel.LinkClicked
        System.Diagnostics.Process.Start(linkChannel.Links(0).LinkData)
    End Sub

    Private Sub RefreshChannel()
        If tbChannel.Text <> "" Then
            Dim channel As New RSSChannel(tbChannel.Text)

            lblTitle.Text = channel.Title
            lblDescription.Text = channel.Description
            linkChannel.Text = channel.Link
            linkChannel.Links(0).Start = 0
            linkChannel.Links(0).Length = channel.Link.Length
            linkChannel.Links(0).LinkData = channel.Link

            feedItems = channel.GetChannelItems()
            lbItems.DisplayMember = "Title"
            lbItems.ValueMember = "Title"
            lbItems.DataSource = feedItems
            If My.Settings.set_rsshistory.Contains(tbChannel.Text) = False Then
                My.Settings.set_rsshistory.Add(tbChannel.Text)
            End If
        End If
    End Sub

    Private Sub tbChannel_KeyDown(sender As Object, e As KeyEventArgs) Handles tbChannel.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_load.PerformClick()
        End If
    End Sub
End Class
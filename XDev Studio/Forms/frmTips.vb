Friend Class frmTips
    Dim tiplist As New List(Of String)
    Private Sub frmTips_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner = Nothing
        frmManager.Focus()
    End Sub

    Private Sub LoadTips()
        tiplist.Add("The editor has a notepad in the infopanel.")
        tiplist.Add("The Infopanel in the editor provides useful tools and information. It is accessible through the green arrow in the bottom right of the editor.")
        tiplist.Add("Creating and using tasks are a good way to remember what to do, and can even be created from the tray icon.")
        tiplist.Add("XDev Studio has a tray icon which provides basic functions such as showing/closing the studio, and even creating tasks.")
        tiplist.Add("The intellisense keywords can be viewed and modified for each language. This can be done by going to Options > Languages.")
        tiplist.Add("You can backup your projects and documents with Backup++. Accessible through Tools > Backup++.")
        tiplist.Add("Backup++ can automatically backup your work, this can be configured in Options > Backup++.")
        tiplist.Add("Individual documents, and whole projects, as well as notepad documents are backed up by Backup++.")
        tiplist.Add("XDev Studio supports custom languages. You can set it for the editor in Language > Custom.")
        tiplist.Add("Many of XDev Studio's features and API are available for plugins to use. Plugins can even add support for new languages.")
        tiplist.Add("In a project folder, there are two main .xdpf files. The file 'xdevproject_files.xdf' stores information about documents in the project, whereas 'xdevproject_details.xdpf' stores information about the project and is also used to open the project.")
        tiplist.Add("Documents can be uploaded to an FTP server at the press of a button or keyboard shortcut, as well as live downloaded and updated from an FTP server at the press of a button.")
        tiplist.Add("XDev Studio has a variety of tools available, including a calendar, notepad, process viewer, web browser, and more. Available under Tools.")
        tiplist.Add("External commands and applications can be launched by going to Tools > Launch Process.")
        tiplist.Add("The welcome page displays recent projects that were open, allowing you to quickly and easily get to them.")
        tiplist.Add("If the welcome page is not displayed at startup, an editor tab is.")
        tiplist.Add("Code snippets can be easily stored and accessed from the context menu in the editor.")
        tiplist.Add("There are several code examples that can be inserted into the editor. Accessible from Insert > Examples.")
        tiplist.Add("A variety of information can be inserted into the editor. Accessible from the Insert menu.")
        tiplist.Add("XDev Studio can search a selected piece of text on the web. Simply right click on the selected text and select 'Search selection on web'.")
        tiplist.Add("The bottom separator on each menu is for plugins to add their own menu items after.")
        tiplist.Add("The project explorer lets you view the files in the project, and open and delete them.")
        tiplist.Add("The Toolpanel is extensible with plugins, but by default contains a notepad.")
        tiplist.Add("Documentation can be viewed locally or online. Accessible from About > Documentation.")
        tiplist.Add("Bugs and issues can be reported by going to About > Report a Bug.")
        tiplist.Add("Installed plugins are accessible from About > Plugins.")
        tiplist.Add("Java files, and C\C++ files can be compiled and run from the Run menu. As well as various other languages. There is even support for using a custom compiler.")
        tiplist.Add("Websites and HTML can be tested in the studio browser by going to Tools > HTML. Testing the code in the browser does not load the file in the browser, whereas testing the file in the browser loads the file as the destination.")
        tiplist.Add("XDev Studio has a lot of keyboard shortcuts. Not all are accessible by clicking on a menu. A complete list can be found in the documentation.")
        tiplist.Add("XDev Studio has a feature called 'QuickPaste'. This lets you copy and paste up to 18 things. These are even saved between sessions.")
        tiplist.Add("Selecting 'File' from the Run menu starts the document as if the user had tried to open it from the file explorer. It will open in its default editor.")
        tiplist.Add("XDev Studio features a web browser. This can be used for anything ranging from entertainment to looking something up.")
        tiplist.Add("The test browser used for testing HTML code, does not suppress script errors, unlike the regular studio browser.")
        tiplist.Add("XDev Studio's theme can be changed from Options > Studio.")
        tiplist.Add("The options tab lets you configure just about everything about XDev Studio.")
        tiplist.Add("In order to compile and run Java code, the classpath must be configured in the settings. Accessible through Options > Languages > Java.")
        tiplist.Add("The snippet list can be cleared through Options > Editor.")
        tiplist.Add("QuickPaste can also be configured from the options tab. Accessible through Options > QuickPaste.")
        tiplist.Add("XDev Studio logs its actions. The logs are accessible through View > Logs.")
        tiplist.Add("Several tools have keyboard shortcuts to access them.")
        tiplist.Add("The contents of the editor can be exported to HTML. Accessible through Tools > Export to HTML.")
        tiplist.Add("Many features and tools require that a document be saved to a file first.")
        tiplist.Add("Although Notepad documents are backed up by Backup++, they are not by default included in projects, unless manually entered into the project files file.")
        tiplist.Add("All updates for XDev Studio are free, for life. No catch. In order to check for updates update, simply use the BioNetWorks Software Manager.")
        tiplist.Add("To update and check for updates to XDev Studio, the BioNetWorks Software Manager is needed. Available on the BioNetWorks website.")
        tiplist.Add("When compiling a Java or C\C++ file, you will notice that all output is directed into the Output tab of the Infopanel, including errors. This is because when reading the output of the compiler, the normal output is also marked as errors, even if it isn't. This will hopefully be fixed in the future.")
        tiplist.Add("If XDev Studio doesn't recognize a file format, its language is set to Plain Text in the editor.")
        tiplist.Add("XDev Studio supports the use of a custom compiler. Configurable in the settings.")
        tiplist.Add("XDev Studio has a website preview tool that lets you preview a website before visiting it. Accessible from the Tools menu.")
        tiplist.Add("You can scrape web pages and insert view the source in an editor. Simply select Insert > Scraped HTML.")
        tiplist.Add("Encrypt++ can encrypt your documents so they can only be accessed by you.")
        tiplist.Add("Encrypt++ can automatically encrypt documents, or encrypt backups.")
        tiplist.Add("You can dictate to the editor using Voice++.")
        tiplist.Add("Voice++ lets you use voice commands to perform several actions.")
        tiplist.Add("You can search your entire project or all open documents with Universal Search.")
        tiplist.Add("If you know the direct link to a plugin, you can download it throug the Plugin Downloader. Accessible through About > Plugins > Download a Plugin.")
        tiplist.Add("You can set bookmarks to lines of code, where you can later find again, even if the document isn't open.")
        tiplist.Add("XDev Studio has a built in RSS Reader.")
        tiplist.Add("You can tweak the IntelliSense in the settings.")
        tiplist.Add("You can view Code Metrics for a document. Accessible from the Tools menu, or the View menu.")
        tiplist.Add("Press Ctrl+Shift+F to access the speed dial.")
        tiplist.Add("You can view code editors or other tabs side by side. Simply drag the tab to place it in a new location.")
        tiplist.Add("You can customize the colors for syntax highlighting in the settings.")
        tiplist.Add("Go into Distraction Free Mode (from the View menu) to focus on just your code.")
        tiplist.Add("XDev Studio stores copies of the text from open editors incase anything should go wrong, or you make a mistake in your code. These can be accessed from Tools > More > Code Recovery.")
        tiplist.Add("Press CTRL+Alt+F to access the Quick Command menu, which allows you to search for commands and run them on the spot.")
        tiplist.Add("You can open multiple files at once from the file open dialog.")
        tiplist.Add("XDev Studio can remember what files you had last open, and automatically re-open them the next time you launch XDev Studio.")
        tiplist.Add("You can drag files into the studio to open them.")
        tiplist.Add("The editor supports split-view editing of the same file. Accessible from the right click menu.")
        tiplist.Add("You can drag tabs next to each other, and display as many tabs as you want side by side. Useful for editing multiple files at once, or viewing multiple tools.")
        tiplist.Add("You can use the Live Browser (Tools > View Document in Live Browser) to render your HTML code in real time.")
    End Sub

    Private Sub frmTips_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Owner = frmManager
        LoadTips()
        DisplayNextTip()
        check_showatstartup.Checked = My.Settings.set_showtipsatstartup
    End Sub

    Public Sub AddTip(ByVal tip As String)
        tiplist.Add(tip)
    End Sub

    Private Sub check_topmost_CheckedChanged(sender As Object, e As EventArgs) Handles check_topmost.CheckedChanged
        If check_topmost.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Me.Close()
    End Sub

    Public Sub DisplayNextTip()
        txt_tip.Text = tiplist.Item(Int(Rnd() * (tiplist.Count - 1)))
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        DisplayNextTip()
    End Sub

    Private Sub check_showatstartup_CheckedChanged(sender As Object, e As EventArgs) Handles check_showatstartup.CheckedChanged
        If Me.check_showatstartup.Checked = True Then
            My.Settings.set_showtipsatstartup = True
        Else
            My.Settings.set_showtipsatstartup = False
        End If
    End Sub
End Class
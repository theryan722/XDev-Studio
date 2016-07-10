Imports System.Threading

Public Class XDevScriptRunner

    Public Shared Sub RunScript(ByVal sfile As String)
        Dim t As Task = Task.Factory.StartNew(Sub()
                                                  Dim txt As String
                                                  Dim ltxt As String
                                                  Dim objReader As New System.IO.StreamReader(sfile)
                                                  Logger.Write("Running script '" & IO.Path.GetFileName(sfile) & "'")
                                                  Do While objReader.Peek() <> -1
                                                      txt = objReader.ReadLine()
                                                      ltxt = txt.ToLower
                                                      '------
                                                      If ltxt.StartsWith("studio.") Then
                                                          If ltxt = "studio.exit()" Then
                                                              Application.Exit()
                                                          ElseIf ltxt = "studio.newinstance()" Then
                                                              frmManager.NewInstanceToolStripMenuItem.PerformClick()
                                                          ElseIf ltxt = "studio.maximize()" Then
                                                              frmManager.WindowState = FormWindowState.Maximized
                                                          ElseIf ltxt = "studio.minimize()" Then
                                                              frmManager.WindowState = FormWindowState.Minimized
                                                          ElseIf ltxt = "studio.normal()" Then
                                                              frmManager.WindowState = FormWindowState.Normal
                                                          ElseIf ltxt = "studio.hide()" Then
                                                              frmManager.Hide()
                                                          ElseIf ltxt = "studio.show()" Then
                                                              frmManager.Show()
                                                          ElseIf ltxt.StartsWith("studio.topmost=") Then
                                                              If ltxt.Contains("true") Then
                                                                  frmManager.TopMost = True
                                                              ElseIf ltxt.Contains("false") Then
                                                                  frmManager.TopMost = False
                                                              End If
                                                          ElseIf ltxt = "studio.fullscreen()" Then
                                                              frmManager.Fullscreen()
                                                          ElseIf ltxt = "studio.exitfullscreen()" Then
                                                              frmManager.ExitFullscreen()
                                                          ElseIf ltxt = "studio.distractionfreemode()" Then
                                                              frmManager.EnterDistractionFreeMode()
                                                          ElseIf ltxt = "studio.exitdistractionfreemode()" Then
                                                              frmManager.ExitDistractionFreeMode()
                                                          ElseIf ltxt.StartsWith("studio.opacity=") Then
                                                              Dim bb As Integer = CInt(ltxt.Substring(ltxt.IndexOf("="), 1))
                                                              Try
                                                                  frmManager.Opacity = bb / 100
                                                              Catch ex As Exception
                                                                  Logger.WriteError(ex)
                                                              End Try
                                                          End If
                                                      ElseIf ltxt.StartsWith("editor.") Then
                                                          If ltxt = "editor.add()" Then
                                                              Tabs.AddCode()
                                                          ElseIf ltxt.StartsWith("editor.add(""") Then
                                                              Dim bb As String = txt.Split({"(""", """)"}, StringSplitOptions.None)(1)
                                                              If IO.File.Exists(bb) Then
                                                                  Tabs.AddCode(bb)
                                                              Else
                                                                  Tabs.AddCodeWithoutFile(bb)
                                                              End If
                                                          End If
                                                      ElseIf ltxt.StartsWith("document.") Then
                                                          If ltxt.StartsWith("document.create(""") Then
                                                              Try
                                                                  System.IO.File.Create(txt.Split({"(""", """)"}, StringSplitOptions.None)(1))
                                                              Catch ex As Exception
                                                                  Logger.WriteError(ex)
                                                              End Try
                                                          ElseIf ltxt.StartsWith("document.delete(""") Then
                                                              Try
                                                                  System.IO.File.Delete(txt.Split({"(""", """)"}, StringSplitOptions.None)(1))
                                                              Catch ex As Exception
                                                                  Logger.WriteError(ex)
                                                              End Try
                                                          ElseIf ltxt.StartsWith("document.copy(""") Then
                                                              Try
                                                                  System.IO.File.Copy(txt.Split({"(""", ""","""}, StringSplitOptions.None)(1), txt.Split({""",""", """"}, StringSplitOptions.None)(2))
                                                              Catch ex As Exception
                                                                  Logger.WriteError(ex)
                                                              End Try
                                                          ElseIf ltxt.StartsWith("document.move(""") Then
                                                              Try
                                                                  System.IO.File.Move(txt.Split({"(""", ""","""}, StringSplitOptions.None)(1), txt.Split({""",""", """"}, StringSplitOptions.None)(2))
                                                              Catch ex As Exception
                                                                  Logger.WriteError(ex)
                                                              End Try
                                                          End If
                                                      ElseIf ltxt.StartsWith("directory.") Then
                                                          If ltxt.StartsWith("directory.create(""") Then
                                                              Try
                                                                  System.IO.Directory.CreateDirectory(txt.Split({"(""", """)"}, StringSplitOptions.None)(1))
                                                              Catch ex As Exception
                                                                  Logger.WriteError(ex)
                                                              End Try
                                                          ElseIf ltxt.StartsWith("directory.delete(""") Then
                                                              Try
                                                                  System.IO.Directory.Delete(txt.Split({"(""", """)"}, StringSplitOptions.None)(1), True)
                                                              Catch ex As Exception
                                                                  Logger.WriteError(ex)
                                                              End Try
                                                          ElseIf ltxt.StartsWith("directory.move(""") Then
                                                              Try
                                                                  System.IO.Directory.Move(txt.Split({"(""", ""","""}, StringSplitOptions.None)(1), txt.Split({""",""", """"}, StringSplitOptions.None)(2))
                                                              Catch ex As Exception
                                                                  Logger.WriteError(ex)
                                                              End Try
                                                          ElseIf ltxt.StartsWith("directory.copy(""") Then
                                                              Try
                                                                  My.Computer.FileSystem.CopyDirectory(txt.Split({"(""", ""","""}, StringSplitOptions.None)(1), txt.Split({""",""", """"}, StringSplitOptions.None)(2), True)
                                                              Catch ex As Exception
                                                                  Logger.WriteError(ex)
                                                              End Try
                                                          End If
                                                      ElseIf ltxt.StartsWith("script.") Then
                                                          If ltxt.StartsWith("script.run(""") Then
                                                              Try
                                                                  XDevScriptRunner.RunScript(txt.Split({"(""", """)"}, StringSplitOptions.None)(1))
                                                              Catch ex As Exception
                                                                  Logger.WriteError(ex)
                                                              End Try
                                                          End If
                                                      ElseIf ltxt.StartsWith("process.") Then
                                                          If ltxt.StartsWith("process.start(""") Then
                                                              Try
                                                                  System.Diagnostics.Process.Start(txt.Split({"(""", """)"}, StringSplitOptions.None)(1))
                                                              Catch ex As Exception
                                                                  Logger.WriteError(ex)
                                                              End Try
                                                          End If
                                                      ElseIf ltxt.StartsWith("log.") Then
                                                          If ltxt.StartsWith("log.write(""") Then
                                                              Logger.Write("SCRIPT '" & IO.Path.GetFileName(sfile) & "' : " & (txt.Split({"(""", """)"}, StringSplitOptions.None)(1)))
                                                          End If
                                                      ElseIf ltxt.StartsWith("alert.") Then
                                                          If ltxt.StartsWith("alert.messagebox.show(""") Then
                                                              MsgBox(txt.Split({"(""", """)"}, StringSplitOptions.None)(1), MsgBoxStyle.OkOnly, "XDev Script")
                                                          ElseIf ltxt.StartsWith("alert.toast.show(""") Then
                                                              Dim newb As New BN.Toast.ToastForm(3000, txt.Split({"(""", """)"}, StringSplitOptions.None)(1))
                                                              newb.Height = "100"
                                                              newb.TopMost = True
                                                              newb.Show()
                                                          End If
                                                      ElseIf ltxt.StartsWith("profile.") Then
                                                          If ltxt = "profile.logout()" Then
                                                              ProfileManager.LogoutCurrentProfile()
                                                          ElseIf ltxt.StartsWith("profile.load(""") Then
                                                              ProfileManager.LoadProfile(txt.Split({"(""", """)"}, StringSplitOptions.None)(1))
                                                          End If
                                                      ElseIf ltxt.StartsWith("universalsearch.") Then
                                                          If ltxt.StartsWith("universalsearch.search(""") Then
                                                              Tabs.AddUniversalSearch(txt.Split({"(""", """)"}, StringSplitOptions.None)(1), Tabs.UniversalSearchType.OpenDocuments)
                                                          End If
                                                      ElseIf ltxt.StartsWith("codemetrics.") Then
                                                          If ltxt.StartsWith("codemetrics.calculate(""") Then
                                                              Tabs.AddCodeMetrics(txt.Split({"(""", """)"}, StringSplitOptions.None)(1))
                                                          End If
                                                      ElseIf ltxt.StartsWith("script.") Then
                                                          If ltxt.StartsWith("script.wait(") Then
                                                              Thread.Sleep(txt.Split({"(", ")"}, StringSplitOptions.None)(1))
                                                          End If
                                                      ElseIf ltxt.StartsWith("tabs.") Then
                                                          If ltxt.StartsWith("tabs.add(") Then
                                                              If ltxt = "tabs.add(editor)" Then
                                                                  Tabs.AddCode()
                                                              ElseIf ltxt = "tabs.add(notepad)" Then
                                                                  Tabs.AddNotepad()
                                                              ElseIf ltxt = "tabs.add(calendar)" Then
                                                                  Tabs.AddCalendar()
                                                              ElseIf ltxt = "tabs.add(largefileeditor)" Then
                                                                  Tabs.AddLargeFileEditor()
                                                              ElseIf ltxt = "tabs.add(processviewer)" Then
                                                                  Tabs.AddProcessViewer()
                                                              ElseIf ltxt = "tabs.add(webbrowser)" Then
                                                                  Tabs.AddWebBrowser()
                                                              ElseIf ltxt = "tabs.add(filedownloader)" Then
                                                                  Tabs.AddFileDownloader()
                                                              ElseIf ltxt = "tabs.add(differenceviewer)" Then
                                                                  Tabs.AddDifferenceViewer()
                                                              ElseIf ltxt = "tabs.add(serviceviewer)" Then
                                                                  Tabs.AddServiceViewer()
                                                              ElseIf ltxt = "tabs.add(rssreader)" Then
                                                                  Tabs.AddRSSReader()
                                                              ElseIf ltxt = "tabs.add(coderecovery)" Then
                                                                  Tabs.AddCodeRecovery()
                                                              ElseIf ltxt = "tabs.add(diagrammer)" Then
                                                                  Tabs.AddDiagrammer()
                                                              ElseIf ltxt = "tabs.add(codebank)" Then
                                                                  Tabs.AddCodeBank()
                                                              ElseIf ltxt = "tabs.add(wysiwygeditor)" Then
                                                                  Tabs.AddWYSIWYGEditor()
                                                              ElseIf ltxt = "tabs.add(hexviewer)" Then
                                                                  Tabs.AddHexViewer()
                                                              ElseIf ltxt = "tabs.add(taskscheduler)" Then
                                                                  Tabs.AddTaskScheduler()
                                                              ElseIf ltxt = "tabs.add(imagemapper)" Then
                                                                  Tabs.AddImageMapper()
                                                              ElseIf ltxt = "tabs.add(codemetrics)" Then
                                                                  Tabs.AddCodeMetrics()
                                                              ElseIf ltxt = "tabs.add(universalsearch)" Then
                                                                  Tabs.AddUniversalSearch()
                                                              ElseIf ltxt = "tabs.add(bookmarks)" Then
                                                                  Tabs.AddBookmarks()
                                                              ElseIf ltxt = "tabs.add(tasks)" Then
                                                                  Tabs.AddTasks()
                                                              ElseIf ltxt = "tabs.add(logmanager)" Then
                                                                  Tabs.AddLogManager()
                                                              ElseIf ltxt = "tabs.add(studioterminal)" Then
                                                                  Tabs.AddStudioTerminal()
                                                              End If
                                                          End If
                                                      End If
                                                  Loop
                                              End Sub)
    End Sub

End Class

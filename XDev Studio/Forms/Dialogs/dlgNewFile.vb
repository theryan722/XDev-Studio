Public Class dlgNewFile

#Region "Methods"

    Private Sub AppendExtension(ByVal ext As String)
        If Not txt_name.Text.EndsWith(ext) Then
            txt_name.AppendText(ext)
        End If
    End Sub

    Private Sub ShowAllLanguages()
        For Each item As Control In pnlLanguages.Controls
            If TypeOf item Is MetroFramework.Controls.MetroButton Then
                CType(item, MetroFramework.Controls.MetroButton).Visible = True
            End If
        Next
    End Sub

    Private Sub HideAllLanguages()
        For Each item As Control In pnlLanguages.Controls
            If TypeOf item Is MetroFramework.Controls.MetroButton Then
                CType(item, MetroFramework.Controls.MetroButton).Visible = False
            End If
        Next
    End Sub

#End Region

#Region "Panel Left"

    Private Sub LangAll_Click(sender As Object, e As EventArgs) Handles LangAll.Click
        ShowAllLanguages()
    End Sub

    Private Sub LangA_Click(sender As Object, e As EventArgs) Handles LangA.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("a") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangB_Click(sender As Object, e As EventArgs) Handles LangB.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("b") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangC_Click(sender As Object, e As EventArgs) Handles LangC.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("c") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangD_Click(sender As Object, e As EventArgs) Handles LangD.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("d") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangE_Click(sender As Object, e As EventArgs) Handles LangE.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("e") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangF_Click(sender As Object, e As EventArgs) Handles LangF.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("f") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangG_Click(sender As Object, e As EventArgs) Handles LangG.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("g") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangH_Click(sender As Object, e As EventArgs) Handles LangH.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("h") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangI_Click(sender As Object, e As EventArgs) Handles LangI.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("i") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangJ_Click(sender As Object, e As EventArgs) Handles LangJ.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("j") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangK_Click(sender As Object, e As EventArgs) Handles LangK.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("k") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangL_Click(sender As Object, e As EventArgs) Handles LangL.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("l") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangM_Click(sender As Object, e As EventArgs) Handles LangM.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("m") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangN_Click(sender As Object, e As EventArgs) Handles LangN.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("n") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangO_Click(sender As Object, e As EventArgs) Handles LangO.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("o") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangP_Click(sender As Object, e As EventArgs) Handles LangP.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("p") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangQ_Click(sender As Object, e As EventArgs) Handles LangQ.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("q") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangR_Click(sender As Object, e As EventArgs) Handles LangR.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("r") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangS_Click(sender As Object, e As EventArgs) Handles LangS.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("s") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangT_Click(sender As Object, e As EventArgs) Handles LangT.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("t") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangU_Click(sender As Object, e As EventArgs) Handles LangU.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("u") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangV_Click(sender As Object, e As EventArgs) Handles LangV.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("v") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangW_Click(sender As Object, e As EventArgs) Handles LangW.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("w") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangX_Click(sender As Object, e As EventArgs) Handles LangX.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("x") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangY_Click(sender As Object, e As EventArgs) Handles LangY.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("y") Then
                item.Visible = True
            End If
        Next
    End Sub

    Private Sub LangZ_Click(sender As Object, e As EventArgs) Handles LangZ.Click
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.StartsWith("z") Then
                item.Visible = True
            End If
        Next
    End Sub

#End Region

#Region "Panel Languages"

    Private Sub btnLangPlainText_Click(sender As Object, e As EventArgs) Handles btnLangPlainText.Click
        AppendExtension(".txt")
    End Sub

    Private Sub btnLangRichText_Click(sender As Object, e As EventArgs) Handles btnLangRichText.Click
        AppendExtension(".rtf")
    End Sub

    Private Sub btnLangAda_Click(sender As Object, e As EventArgs) Handles btnLangAda.Click
        AppendExtension(".ada")
    End Sub

    Private Sub btnLangAssembly_Click(sender As Object, e As EventArgs) Handles btnLangAssembly.Click
        AppendExtension(".asm")
    End Sub

    Private Sub btnLangAspScript_Click(sender As Object, e As EventArgs) Handles btnLangAspScript.Click
        AppendExtension(".asp")
    End Sub

    Private Sub btnLangXDevLanguage_Click(sender As Object, e As EventArgs) Handles btnLangXDevLanguage.Click
        AppendExtension(".xdlf")
    End Sub

    Private Sub btnLangYAML_Click(sender As Object, e As EventArgs) Handles btnLangYAML.Click
        AppendExtension(".yaml")
    End Sub

    Private Sub btnLangUnixScript_Click(sender As Object, e As EventArgs) Handles btnLangUnixScript.Click
        AppendExtension(".sh")
    End Sub

    Private Sub btnLangVisualBasicScript_Click(sender As Object, e As EventArgs) Handles btnLangVisualBasicScript.Click
        AppendExtension(".vbs")
    End Sub

    Private Sub btnLangVisualBasic_Click(sender As Object, e As EventArgs) Handles btnLangVisualBasic.Click
        AppendExtension(".vb")
    End Sub

    Private Sub btnLangSQL_Click(sender As Object, e As EventArgs) Handles btnLangSQL.Click
        AppendExtension(".sql")
    End Sub

    Private Sub btnLangSmallTalk_Click(sender As Object, e As EventArgs) Handles btnLangSmallTalk.Click
        AppendExtension(".st")
    End Sub

    Private Sub btnLangRuby_Click(sender As Object, e As EventArgs) Handles btnLangRuby.Click
        AppendExtension(".rb")
    End Sub

    Private Sub btnLangR_Click(sender As Object, e As EventArgs) Handles btnLangR.Click
        AppendExtension(".r")
    End Sub

    Private Sub btnLangPython_Click(sender As Object, e As EventArgs) Handles btnLangPython.Click
        AppendExtension(".py")
    End Sub

    Private Sub btnLangPostscript_Click(sender As Object, e As EventArgs) Handles btnLangPostscript.Click
        AppendExtension(".ps")
    End Sub

    Private Sub btnLangPHP_Click(sender As Object, e As EventArgs) Handles btnLangPHP.Click
        AppendExtension(".php")
    End Sub

    Private Sub btnLangPerl_Click(sender As Object, e As EventArgs) Handles btnLangPerl.Click
        AppendExtension(".pl")
    End Sub

    Private Sub btnLangPascal_Click(sender As Object, e As EventArgs) Handles btnLangPascal.Click
        AppendExtension(".pas")
    End Sub

    Private Sub btnLangNFO_Click(sender As Object, e As EventArgs) Handles btnLangNFO.Click
        AppendExtension(".nfo")
    End Sub

    Private Sub btnLangMarkdown_Click(sender As Object, e As EventArgs) Handles btnLangMarkdown.Click
        AppendExtension(".md")
    End Sub

    Private Sub btnLangLua_Click(sender As Object, e As EventArgs) Handles btnLangLua.Click
        AppendExtension(".lua")
    End Sub

    Private Sub btnLangLisp_Click(sender As Object, e As EventArgs) Handles btnLangLisp.Click
        AppendExtension(".lisp")
    End Sub

    Private Sub btnLangJavaScript_Click(sender As Object, e As EventArgs) Handles btnLangJavaScript.Click
        AppendExtension(".js")
    End Sub

    Private Sub btnLangJava_Click(sender As Object, e As EventArgs) Handles btnLangJava.Click
        AppendExtension(".java")
    End Sub

    Private Sub btnLangHTML_Click(sender As Object, e As EventArgs) Handles btnLangHTML.Click
        AppendExtension(".html")
    End Sub

    Private Sub btnLangFortran_Click(sender As Object, e As EventArgs) Handles btnLangFortran.Click
        AppendExtension(".f")
    End Sub

    Private Sub btnLangD_Click(sender As Object, e As EventArgs) Handles btnLangD.Click
        AppendExtension(".d")
    End Sub

    Private Sub btnLangCSS_Click(sender As Object, e As EventArgs) Handles btnLangCSS.Click
        AppendExtension(".css")
    End Sub

    Private Sub btnLangCSharp_Click(sender As Object, e As EventArgs) Handles btnLangCSharp.Click
        AppendExtension(".cs")
    End Sub

    Private Sub btnLangCPP_Click(sender As Object, e As EventArgs) Handles btnLangCPP.Click
        AppendExtension(".cpp")
    End Sub

    Private Sub btnLangCobol_Click(sender As Object, e As EventArgs) Handles btnLangCobol.Click
        AppendExtension(".cbl")
    End Sub

    Private Sub btnLangC_Click(sender As Object, e As EventArgs) Handles btnLangC.Click
        AppendExtension(".c")
    End Sub

    Private Sub btnLangBatch_Click(sender As Object, e As EventArgs) Handles btnLangBatch.Click
        AppendExtension(".bat")
    End Sub

    Private Sub btnLangXML_Click(sender As Object, e As EventArgs) Handles btnLangXML.Click
        AppendExtension(".xml")
    End Sub

#End Region

#Region "Panel Bottom"

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim newb As New FolderBrowserDialog
        newb.ShowNewFolderButton = True
        If CurrentProfile.Name <> "" Then
            newb.SelectedPath = CurrentProfile.Folder
        ElseIf txt_location.Text <> "" AndAlso IO.Directory.Exists(txt_location.Text) Then
            newb.SelectedPath = txt_location.Text
        End If

        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_location.Text = newb.SelectedPath
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txt_location.Text <> "" AndAlso IO.Directory.Exists(txt_location.Text) AndAlso txt_name.Text <> "" Then
            If Not txt_location.Text.EndsWith("\") Then
                txt_location.Text = txt_location.Text & "\"
            End If
            If IO.File.Exists(txt_location.Text & txt_name.Text) Then
                If MsgBox("The file already exists! Do you want to open it?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Exclamation, "Existing File") = MsgBoxResult.Yes Then
                    Tabs.AddCode(txt_location.Text & txt_name.Text)
                    Me.Close()
                End If
            Else
                Try
                    IO.File.Create(txt_location.Text & txt_name.Text)
                    Tabs.AddCode(txt_location.Text & txt_name.Text)
                    Me.Close()
                Catch ex As Exception
                    Logger.WriteError(ex)
                End Try
            End If
        Else
            MsgBox("Please make sure the directory location exists and that all fields are filled out properly.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

#End Region

#Region "dlgNewFile"

    Private Sub dlgNewFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowAllLanguages()
        If CurrentProfile.Name <> "" Then
            txt_location.Text = CurrentProfile.Folder
        Else
            txt_location.Text = XDev.Path.Locator.GetWorkspacePath & "\Files"
        End If
        txt_name.Focus()
    End Sub

#End Region

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        HideAllLanguages()
        For Each item As MetroFramework.Controls.MetroButton In pnlLanguages.Controls
            If item.Text.ToLower.Contains(txt_search.Text.ToLower) Then
                item.Visible = True
            End If
        Next
    End Sub

End Class
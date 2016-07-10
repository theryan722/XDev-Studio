Imports System.IO
Imports System.Xml

Friend Class Tab_Options

#Region "Tabcontrol"

#Region "Studio"

#Region "Studio Tab Control"

#Region "Style"

    Private Sub btn_settoolpanelcolor_Click(sender As Object, e As EventArgs) Handles btn_settoolpanelcolor.Click
        Dim newb As New ColorDialog
        newb.Color = pnl_toolpanelcolor.BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            pnl_toolpanelcolor.BackColor = newb.Color
        End If
    End Sub

    Private Sub btn_setprojectexplorercolor_Click(sender As Object, e As EventArgs) Handles btn_setprojectexplorercolor.Click
        Dim newb As New ColorDialog
        newb.Color = pnl_projectexplorercolor.BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            pnl_projectexplorercolor.BackColor = newb.Color
        End If
    End Sub

    Private Sub btn_setmenustripcolor_Click(sender As Object, e As EventArgs) Handles btn_setmenustripcolor.Click
        Dim newb As New ColorDialog
        newb.Color = pnl_menustripcolor.BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            pnl_menustripcolor.BackColor = newb.Color
        End If
    End Sub

    Private Sub btn_customimagebrowse_Click(sender As Object, e As EventArgs) Handles btn_customimagebrowse.Click
        Dim newb As New OpenFileDialog
        newb.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|Bitmap Files (*.bmp)|*.bmp|All Files (*.*)|*.*"
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_customimage.Text = newb.FileName
        End If
    End Sub

#End Region

#Region "Security"

    Private Sub check_showapplockpassword_CheckedChanged(sender As Object, e As EventArgs) Handles check_showapplockpassword.CheckedChanged
        If check_showapplockpassword.Checked = True Then
            txt_applockpassword.PasswordChar = ""
        Else
            txt_applockpassword.PasswordChar = "•"
        End If
    End Sub

#End Region

#Region "Default Locations"

    Private Sub btn_browse1_Click(sender As Object, e As EventArgs) Handles btn_browse1.Click
        Dim newb As New FolderBrowserDialog
        newb.ShowNewFolderButton = True
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_defaultprojlocation.Text = newb.SelectedPath
        End If
    End Sub

    Private Sub btn_browse2_Click(sender As Object, e As EventArgs) Handles btn_browse2.Click
        Dim newb As New FolderBrowserDialog
        newb.ShowNewFolderButton = True
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_defaultdownloadlocation.Text = newb.SelectedPath
        End If
    End Sub

#End Region

#Region "Custom Compiler"
    Private Sub btn_customcompilerbrowse_Click(sender As Object, e As EventArgs) Handles btn_customcompilerlocbrowse.Click
        Dim newb As New OpenFileDialog
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_customcompilerloc.Text = newb.FileName
        End If
    End Sub

    Private Sub btn_customcompilerpathvarbrowse_Click(sender As Object, e As EventArgs) Handles btn_customcompilerpathvarbrowse.Click
        Dim newb As New OpenFileDialog
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_customcompilerpathvar.Text = newb.FileName
        End If
    End Sub
#End Region


#End Region

#Region "Style"

    Private Sub btnStudioBgBrowse_Click(sender As Object, e As EventArgs) Handles btnStudioBgBrowse.Click
        Dim newb As New OpenFileDialog
        newb.Filter = "Picture Files(*.bmp;*.gif;*jpg;*.png)|*.bmp;*.gif;*.jpg;*.png|BMP files (*.bmp)|*.bmp|GIF files (*.gif)|*.gif|JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_studiobg.Text = newb.FileName
        End If
    End Sub

#End Region

#Region "Toolbars"

    Private Sub pnl_toolbars_backcolor_MouseClick(sender As Object, e As MouseEventArgs) Handles pnl_toolbars_backcolor.MouseClick
        Dim newb As New ColorDialog
        newb.Color = pnl_toolbars_backcolor.BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            pnl_toolbars_backcolor.BackColor = newb.Color
        End If
    End Sub

#End Region

#Region "Speed Dial"

    Private Sub btn_setspeeddialbackcolor_Click(sender As Object, e As EventArgs) Handles btn_setspeeddialbackcolor.Click
        Dim newb As New ColorDialog
        newb.Color = pnl_sd_backcolor.BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            pnl_sd_backcolor.BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_sd_backcolor_MouseClick(sender As Object, e As MouseEventArgs) Handles pnl_sd_backcolor.MouseClick
        Dim newb As New ColorDialog
        newb.Color = pnl_sd_backcolor.BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            pnl_sd_backcolor.BackColor = newb.Color
        End If
    End Sub

#End Region

#Region "Other"

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Dim newb As New OpenFileDialog
        newb.Title = "Open XDev Script to run"
        newb.Filter = "XDev Script File (*.xds)|*.xds|All Files (*.*)|*.*"
        newb.InitialDirectory = XDev.Path.Locator.GetWorkspacePath & "\Scripts"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_scriptatstartup.Text = newb.FileName
        End If
    End Sub

#End Region

#End Region

#Region "Editor"

#Region "Syntax Highlighting"

    Private Sub pnl_highlighting_default_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_default.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_comment_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_comment.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_commentblock_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_commentblock.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_commentline_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_commentline.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_commentlinedoc_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_commentlinedoc.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_number_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_number.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_word_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_word.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_word2_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_word2.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_word3_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_word3.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_string_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_string.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_character_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_character.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_verbatim_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_verbatim.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_stringeol_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_stringeol.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_charactereol_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_charactereol.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_operator_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_operator.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_preprocessor_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_preprocessor.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_delimiter_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_delimiter.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_label_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_label.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_illegal_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_illegal.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_identifier_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_identifier.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_cpuinstruction_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_cpuinstruction.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_mathinstruction_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_mathinstruction.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_extinstruction_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_extinstruction.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_register_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_register.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_directive_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_directive.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_directiveoperand_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_directiveoperand.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_hide_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_hide.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_triple_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_triple.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_tripledouble_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_tripledouble.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_classname_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_classname.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_defname_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_defname.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_decorator_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_decorator.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_uuid_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_uuid.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_regex_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_regex.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_commentdockeyword_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_commentdockeyword.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_commentdockeyworderror_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_commentdockeyworderror.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_tag_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_tag.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_tagunknown_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_tagunknown.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_pseudoclass_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_pseudoclass.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_unknownpseudoclass_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_unknownpseudoclass.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_unknownidentifier_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_unknownidentifier.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_value_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_value.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_id_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_id.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_important_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_important.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_attribute_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_attribute.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_attributeunknown_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_attributeunknown.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_entity_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_entity.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_continuation_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_continuation.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_doublestring_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_doublestring.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_other_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_other.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_xmlstart_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_xmlstart.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_xmlend_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_xmlend.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_script_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_script.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_asp_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_asp.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_aspat_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_aspat.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_question_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_question.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_cdata_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_cdata.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_xccomment_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_xccomment.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_special_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_special.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_symbol_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_symbol.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_instructionword_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_instructionword.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_scalar_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_scalar.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_array_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_array.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_hash_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_hash.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_symboltable_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_symboltable.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_datasection_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_datasection.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_pod_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_pod.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_longquote_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_longquote.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_backticks_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_backticks.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_punctuation_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_punctuation.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_variable_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_variable.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_global_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_global.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_modulename_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_modulename.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_instancevar_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_instancevar.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_stdin_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_stdin.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_stdout_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_stdout.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_stderr_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_stderr.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_worddemoted_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_worddemoted.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_classvar_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_classvar.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_specsel_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_specsel.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_assign_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_assign.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_kwsend_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_kwsend.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_return_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_return.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_nil_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_nil.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_binary_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_binary.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_super_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_super.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

    Private Sub pnl_highlighting_self_Click(sender As Object, e As EventArgs) Handles pnl_highlighting_self.Click
        Dim newb As New ColorDialog
        newb.Color = DirectCast(sender, Button).BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirectCast(sender, Button).BackColor = newb.Color
        End If
    End Sub

#End Region

#Region "Tab Triggers"

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If lb_triggers.SelectedIndex <> -1 Then
            My.Settings.set_tabtriggers.RemoveAt(lb_triggers.SelectedIndex)
            RefreshTriggerList()
        End If
    End Sub

    Private Sub btn_triggeradd_Click(sender As Object, e As EventArgs) Handles btn_triggeradd.Click
        If txt_triggerphrase.Text <> "" And txt_triggertext.Text <> "" Then
            My.Settings.set_tabtriggers.Add(txt_triggerphrase.Text & "|" & txt_triggertext.Text)
            RefreshTriggerList()
        Else
            MetroFramework.MetroMessageBox.Show(frmManager, "Please properly fill out the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RefreshTriggerList()
        lb_triggers.Items.Clear()
        For Each item As String In My.Settings.set_tabtriggers
            Dim arr As String() = item.Split("|")
            lb_triggers.Items.Add(arr(0))
        Next
        txt_triggerphrase.Clear()
        txt_triggertext.Clear()
    End Sub

    Private Sub lb_triggers_KeyDown(sender As Object, e As KeyEventArgs) Handles lb_triggers.KeyDown
        If e.KeyCode = Keys.Delete Then
            If lb_triggers.SelectedIndex <> -1 Then
                My.Settings.set_tabtriggers.RemoveAt(lb_triggers.SelectedIndex)
                RefreshTriggerList()
            End If
        End If
    End Sub

    Private Sub lb_triggers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_triggers.SelectedIndexChanged
        If lb_triggers.SelectedIndex <> -1 Then
            Dim arr() As String = My.Settings.set_tabtriggers(lb_triggers.SelectedIndex).Split("|")
            txt_triggerphrase.Text = arr(0)
            txt_triggertext.Text = arr(1)
        End If
    End Sub

    Private Sub btn_triggerclear_Click(sender As Object, e As EventArgs) Handles btn_triggerclear.Click
        txt_triggerphrase.Clear()
        txt_triggertext.Clear()
    End Sub

    Private Sub btn_triggerdeleteselected_Click(sender As Object, e As EventArgs) Handles btn_triggerdeleteselected.Click
        If lb_triggers.SelectedIndex <> -1 Then
            My.Settings.set_tabtriggers.RemoveAt(lb_triggers.SelectedIndex)
            RefreshTriggerList()
        End If
    End Sub

#End Region

#Region "Code Templates"

    Private Sub lb_codetemplates_KeyDown(sender As Object, e As KeyEventArgs) Handles lb_codetemplates.KeyDown
        If e.KeyCode = Keys.Delete Then
            If lb_codetemplates.SelectedIndex <> -1 Then
                My.Settings.set_codetemplates.RemoveAt(lb_codetemplates.SelectedIndex)
                RefreshTemplateList()
            End If
        End If
    End Sub

    Private Sub lb_codetemplates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_codetemplates.SelectedIndexChanged
        If lb_codetemplates.SelectedIndex <> -1 Then
            Dim arr() As String = My.Settings.set_codetemplates(lb_codetemplates.SelectedIndex).Split("|")
            txt_templatename.Text = arr(0)
            txt_templatetext.Text = arr(1)
        End If
    End Sub

    Private Sub btn_templateadd_Click(sender As Object, e As EventArgs) Handles btn_templateadd.Click
        If txt_templatename.Text <> "" And txt_templatetext.Text <> "" Then
            My.Settings.set_codetemplates.Add(txt_templatename.Text & "|" & txt_templatetext.Text)
            RefreshTemplateList()
        Else
            MetroFramework.MetroMessageBox.Show(frmManager, "Please properly fill out the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btn_templateclear_Click(sender As Object, e As EventArgs) Handles btn_templateclear.Click
        txt_templatename.Clear()
        txt_templatetext.Clear()
    End Sub

    Private Sub btn_templatedelete_Click(sender As Object, e As EventArgs) Handles btn_templatedelete.Click
        If lb_codetemplates.SelectedIndex <> -1 Then
            My.Settings.set_codetemplates.RemoveAt(lb_codetemplates.SelectedIndex)
            RefreshTemplateList()
        End If
    End Sub

    Private Sub RefreshTemplateList()
        lb_codetemplates.Items.Clear()
        For Each item As String In My.Settings.set_codetemplates
            Dim arr As String() = item.Split("|")
            lb_codetemplates.Items.Add(arr(0))
        Next
        txt_templatename.Clear()
        txt_templatetext.Clear()
    End Sub

#End Region

#Region "Document"

#Region "Snippet List"

    Private Sub DeleteSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem.Click
        If lb_snippets.SelectedIndex <> -1 Then
            My.Settings.set_snippetlist.RemoveAt(lb_snippets.SelectedIndex)
            lb_snippets.Items.RemoveAt(lb_snippets.SelectedIndex)
        End If
    End Sub

    Private Sub btn_clearsnippetlist_Click(sender As Object, e As EventArgs) Handles btn_clearsnippetlist.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to clear the snippet list?", "Clear Snippet List", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            My.Settings.set_snippetlist.Clear()
            lb_snippets.Items.Clear()
        End If
    End Sub

#End Region

    Private Sub lbl_font_Click(sender As Object, e As EventArgs) Handles lbl_font.Click
        btn_setdefaultfont.PerformClick()
    End Sub

    Private Sub btn_setdefaultfont_Click(sender As Object, e As EventArgs) Handles btn_setdefaultfont.Click
        Dim newb As New FontDialog
        newb.Font = lbl_font.Font
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            lbl_font.Font = newb.Font
            lbl_font.Text = newb.Font.Name
            My.Settings.set_defaultfont = newb.Font
        End If
    End Sub

    Private Sub btn_clearstoredclipboardhistory_Click(sender As Object, e As EventArgs) Handles btn_clearstoredclipboardhistory.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to clear the stored Clipboard History? This is the data that is loaded into the clipboard history when a new editor is added.", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            My.Settings.set_clipboardhistory.Clear()
        End If
    End Sub

#End Region

#End Region

#Region "QuickPaste"

    Private Sub btn_resetallquickpastes_Click(sender As Object, e As EventArgs) Handles btn_resetallquickpastes.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to reset all saved QuickPastes?", "Reset QuickPaste", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            txt_quickpaste1.Text = "1"
            txt_quickpaste2.Text = "2"
            txt_quickpaste3.Text = "3"
            txt_quickpaste4.Text = "4"
            txt_quickpaste5.Text = "5"
            txt_quickpaste6.Text = "6"
            txt_quickpaste7.Text = "7"
            txt_quickpaste8.Text = "8"
            txt_quickpaste9.Text = "9"
            txt_quickpaste10.Text = "10"
            txt_quickpaste11.Text = "11"
            txt_quickpaste12.Text = "12"
            txt_quickpaste13.Text = "13"
            txt_quickpaste14.Text = "14"
            txt_quickpaste15.Text = "15"
            txt_quickpaste16.Text = "16"
            txt_quickpaste17.Text = "17"
            txt_quickpaste18.Text = "18"
        End If
    End Sub

#End Region

#Region "Languages"

#Region "Languages TabControl"

#Region "Custom"

    Private Sub btn_languages_custom_importfromfile_Click(sender As Object, e As EventArgs) Handles btn_languages_custom_importfromfile.Click
        Dim newb As New OpenFileDialog
        newb.Filter = "XDev Custom Language File (*.xdclf)|*.xdclf"
        newb.InitialDirectory = XDev.Path.Locator.GetWorkspacePath & "\CustomLanguages\"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim xml = XDocument.Load(newb.FileName)
                txt_customlang_autocomplete.Text = xml.<XDevCustomLang>.<autocomplete>.Value
                txt_customlang_keywords0.Text = xml.<XDevCustomLang>.<keywords0>.Value
                txt_customlang_keywords1.Text = xml.<XDevCustomLang>.<keywords1>.Value
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub btn_languages_custom_exporttofile_Click(sender As Object, e As EventArgs) Handles btn_languages_custom_exporttofile.Click
        Dim newb As New SaveFileDialog
        newb.InitialDirectory = XDev.Path.Locator.GetWorkspacePath & "\CustomLanguages\"
        newb.Filter = "XDev Custom Language File (*.xdclf)|*.xdclf"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim writer As New XmlTextWriter(newb.FileName, System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                '--------------------
                writer.WriteStartElement("XDevCustomLang")
                writer.WriteStartElement("autocomplete")
                writer.WriteString(txt_customlang_autocomplete.Text)
                writer.WriteEndElement()
                writer.WriteStartElement("keywords0")
                writer.WriteString(txt_customlang_keywords0.Text)
                writer.WriteEndElement()
                writer.WriteStartElement("keywords1")
                writer.WriteString(txt_customlang_keywords1.Text)
                writer.WriteEndElement()
                writer.WriteEndElement()
                writer.Close()
                MetroFramework.MetroMessageBox.Show(frmManager, "Exported Custom Language Settings to '" & newb.FileName & "'", "Export Settings", MessageBoxButtons.OK)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

#End Region

#Region "Java"

    Private Sub btn_classpathbrowse_Click(sender As Object, e As EventArgs) Handles btn_classpathbrowse.Click
        Dim newb As New FolderBrowserDialog
        newb.Description = "Select the Java Class Path Bin folder"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_javaclasspath.Text = newb.SelectedPath
        End If
    End Sub

#End Region

#End Region

#End Region

#Region "FTP"
    Private Sub btn_clearftppathhistory_Click(sender As Object, e As EventArgs) Handles btn_clearftppathhistory.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to reset the FTP path history?", "Reset FTP Path History", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            My.Settings.set_ftppathhistory.Clear()
        End If
    End Sub
    Private Sub check_ftpshowpassword_CheckedChanged(sender As Object, e As EventArgs) Handles check_ftpshowpassword.CheckedChanged
        If check_ftpshowpassword.Checked = True Then
            txt_ftpuserpass.PasswordChar = ""
        Else
            txt_ftpuserpass.PasswordChar = "•"
        End If
    End Sub

#End Region

#Region "Tools"

#Region "RSS"

    Private Sub btn_clearrsshistory_Click_1(sender As Object, e As EventArgs) Handles btn_clearrsshistory.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to reset the RSS feed history?", "Reset RSS feed history", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            My.Settings.set_rsshistory.Clear()
        End If
    End Sub

#End Region

#Region "Backup++"
    Private Sub btn_browsebackupdirectory_Click_1(sender As Object, e As EventArgs) Handles btn_browsebackupdirectory.Click
        Dim newb As New FolderBrowserDialog
        newb.Description = "Select the location to store backups."
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_backupdirectory.Text = newb.SelectedPath
        End If
    End Sub

#End Region

#End Region

#Region "Speed Dial"

    Private Sub InitializeSpeedDialComboBoxes()
        Dim speeddiallist As New List(Of String)
        speeddiallist.Add("Bookmarks")
        speeddiallist.Add("Calendar")
        speeddiallist.Add("Code Editor")
        speeddiallist.Add("Code Metrics")
        speeddiallist.Add("Color Picker")
        speeddiallist.Add("Documentation")
        speeddiallist.Add("Exit Studio")
        speeddiallist.Add("File Downloader")
        speeddiallist.Add("Image Mapper")
        speeddiallist.Add("Log")
        speeddiallist.Add("New Instance")
        speeddiallist.Add("Notepad")
        speeddiallist.Add("Options")
        speeddiallist.Add("Presentation Mode")
        speeddiallist.Add("Process Viewer")
        speeddiallist.Add("RSS Reader")
        speeddiallist.Add("Service Viewer")
        speeddiallist.Add("Site Previewer")
        speeddiallist.Add("Tasks")
        speeddiallist.Add("Tips")
        speeddiallist.Add("Universal Search")
        speeddiallist.Add("Web Browser")
        speeddiallist.Add("WYSIWYG Editor")
        speeddiallist.Add("Task Scheduler")
        speeddiallist.Add("System Terminal")
        speeddiallist.Add("Picture Viewer")
        speeddiallist.Add("Large File Editor")
        speeddiallist.Add("File Recovery")
        speeddiallist.Add("File History")
        speeddiallist.Add("Difference Viewer")
        speeddiallist.Add("Diagrammer")
        speeddiallist.Add("CodeBank")
        speeddiallist.Add("App Manager")
        speeddiallist.Add(".Net Code Converter")
        '----------------------
        For Each item As String In speeddiallist
            combo_sd_0.Items.Add(item)
            combo_sd_1.Items.Add(item)
            combo_sd_2.Items.Add(item)
            combo_sd_3.Items.Add(item)
            combo_sd_4.Items.Add(item)
            combo_sd_5.Items.Add(item)
            combo_sd_6.Items.Add(item)
            combo_sd_7.Items.Add(item)
            combo_sd_8.Items.Add(item)
        Next
    End Sub

#End Region

#End Region

#Region "Save\Load\Reset"

    Private Sub LoadSettings()
        LoadSyntaxHighlighting()
        'Quickpaste
        txt_quickpaste1.Text = My.Settings.set_quickpaste(0)
        txt_quickpaste2.Text = My.Settings.set_quickpaste(1)
        txt_quickpaste3.Text = My.Settings.set_quickpaste(2)
        txt_quickpaste4.Text = My.Settings.set_quickpaste(3)
        txt_quickpaste5.Text = My.Settings.set_quickpaste(4)
        txt_quickpaste6.Text = My.Settings.set_quickpaste(5)
        txt_quickpaste7.Text = My.Settings.set_quickpaste(6)
        txt_quickpaste8.Text = My.Settings.set_quickpaste(7)
        txt_quickpaste9.Text = My.Settings.set_quickpaste(8)
        txt_quickpaste10.Text = My.Settings.set_quickpaste(9)
        txt_quickpaste11.Text = My.Settings.set_quickpaste(10)
        txt_quickpaste12.Text = My.Settings.set_quickpaste(11)
        txt_quickpaste13.Text = My.Settings.set_quickpaste(12)
        txt_quickpaste14.Text = My.Settings.set_quickpaste(13)
        txt_quickpaste15.Text = My.Settings.set_quickpaste(14)
        txt_quickpaste16.Text = My.Settings.set_quickpaste(15)
        txt_quickpaste17.Text = My.Settings.set_quickpaste(16)
        txt_quickpaste18.Text = My.Settings.set_quickpaste(17)
        '---------------
        'Studio
        '-Style
        check_displaycustomimage.Checked = My.Settings.set_displaywelcomeimage
        combo_welcomeimagestyle.SelectedItem = My.Settings.set_welcomeimagestyle
        txt_customimage.Text = My.Settings.set_welcomeimagelocation
        combo_theme.SelectedItem = My.Settings.set_theme.ToString
        pnl_toolpanelcolor.BackColor = My.Settings.set_toolpanelcolor
        pnl_projectexplorercolor.BackColor = My.Settings.set_projectexplorercolor
        pnl_menustripcolor.BackColor = My.Settings.set_menustripcolor
        check_setmenustriptextcolorwhite.Checked = My.Settings.set_menustriptextcolorwhite
        txt_toolpanelwidth.Text = My.Settings.set_toolpanelwidth
        txt_projectexplorerwidth.Text = My.Settings.set_projectexplorerwidth
        check_toolpanelvisible.Checked = My.Settings.set_toolpanelvisibleatstartup
        check_menustrip_mousehover.Checked = My.Settings.set_menustrip_mousehover
        If My.Settings.set_tabstriplocation = WeifenLuo.WinFormsUI.Docking.DocumentTabStripLocation.Top Then
            radio_tabstriptop.Checked = True
        Else
            radio_tabstripbottom.Checked = True
        End If
        txt_studiobg.Text = My.Settings.set_dockpanelbg
        check_displaystudiobgimage.Checked = My.Settings.set_displaystudiobgimage
        '-Default Locations
        txt_defaultprojlocation.Text = My.Settings.set_defaultprojlocation
        txt_defaultdownloadlocation.Text = My.Settings.set_defaultdownloadlocation
        '-Custom Compiler
        check_customcompilerenabled.Checked = My.Settings.set_customcompilerenabled
        txt_customcompilerloc.Text = My.Settings.set_customcompilerloc
        txt_customcompilerpathvar.Text = My.Settings.set_customcompilerpathvar
        txt_customcompilercommand.Text = My.Settings.set_customcompilercommand
        txt_customcompilerparams.Text = My.Settings.set_customcompilerparams
        check_customcompilerrequiresoutputfile.Checked = My.Settings.set_customcompilerrequiressecondfile
        txt_customcompilerfileextension.Text = My.Settings.set_customcompilerextension
        '-Security
        check_applockenabled.Checked = My.Settings.set_applockenabled
        txt_applockpassword.Text = My.Settings.set_applockpassword
        check_dispsecuritywarninglinksnotepad.Checked = My.Settings.set_notepad_linksecuritynotification
        '-Toolbars
        pnl_toolbars_backcolor.BackColor = My.Settings.set_toolbars_backcolor
        '-Speed Dial
        combo_sd_0.SelectedItem = My.Settings.set_speeddial(0)
        combo_sd_1.SelectedItem = My.Settings.set_speeddial(1)
        combo_sd_2.SelectedItem = My.Settings.set_speeddial(2)
        combo_sd_3.SelectedItem = My.Settings.set_speeddial(3)
        combo_sd_4.SelectedItem = My.Settings.set_speeddial(4)
        combo_sd_5.SelectedItem = My.Settings.set_speeddial(5)
        combo_sd_6.SelectedItem = My.Settings.set_speeddial(6)
        combo_sd_7.SelectedItem = My.Settings.set_speeddial(7)
        combo_sd_8.SelectedItem = My.Settings.set_speeddial(8)
        check_sd_mousehover.Checked = My.Settings.set_speeddial_mousehover
        pnl_sd_backcolor.BackColor = My.Settings.set_speeddial_backcolor
        '-Other
        If My.Settings.set_defaultwindowstate = FormWindowState.Normal Then
            combo_defaultwindowstate.SelectedItem = "Normal"
        Else
            combo_defaultwindowstate.SelectedItem = "Maximized"
        End If
        check_displaytrayicon.Checked = My.Settings.set_displaytrayicon
        check_openfileinselectededitor.Checked = My.Settings.set_openfileinselectededitor
        If My.Settings.set_actionifnotabs = 0 Then
            radio_donothing.Checked = True
        ElseIf My.Settings.set_actionifnotabs = 1 Then
            radio_notabs_addeditor.Checked = True
        ElseIf My.Settings.set_actionifnotabs = 2 Then
            radio_notabs_exitstudio.Checked = True
        End If
        check_confirmexit.Checked = My.Settings.set_confirmexit
        check_enableperformancemodeatstartup.Checked = My.Settings.set_enableperformancemodeatstartup
        check_keepfileloc.Checked = My.Settings.set_keepfileloc
        check_rememberfilesonshutdown.Checked = My.Settings.set_rememberopenedfiles
        check_autosaveenabled.Checked = My.Settings.set_autosave
        txt_autosaveinterval.Text = My.Settings.set_autosave_interval
        check_displaysplashscreen.Checked = My.Settings.set_displaysplashscreen
        combo_startuptab.SelectedItem = My.Settings.set_startuptab
        check_requirefilestobecreated.Checked = My.Settings.set_requirefilecreation
        check_runscriptatstartup.Checked = My.Settings.set_runscriptatstartup
        txt_scriptatstartup.Text = My.Settings.set_scripttorunatstartup
        check_storenotifications.Checked = My.Settings.set_storenotifications
        '----------------
        'Editor
        '-Document
        lbl_font.Font = My.Settings.set_defaultfont
        lbl_font.Text = My.Settings.set_defaultfont.Name
        check_righttoleft.Checked = My.Settings.set_righttoleft
        combo_endofline.SelectedItem = My.Settings.set_endofline.ToString
        check_eolvisible.Checked = My.Settings.set_eolvisible
        combo_caret.SelectedItem = My.Settings.set_caret.ToString
        check_allowdragdrop.Checked = My.Settings.set_allowdragdrop
        check_overtype.Checked = My.Settings.set_Overtype
        If My.Settings.set_cursor = 0 Then
            combo_cursor.SelectedItem = "IBeam"
        ElseIf My.Settings.set_cursor = 1 Then
            combo_cursor.SelectedItem = "Arrow"
        End If
        check_highlightselectedline.Checked = My.Settings.set_highlightselectedline
        check_hl_enabled.Checked = My.Settings.set_highlightmatchingselection
        check_documentmap.Checked = My.Settings.set_editordocumentmap
        check_multiselection.Checked = My.Settings.set_multiselection
        If My.Settings.set_multipaste = ScintillaNET.MultiPaste.Each Then
            combo_multipaste.SelectedItem = "Each"
        Else
            combo_multipaste.SelectedItem = "Once"
        End If
        If My.Settings.set_wrapmode = ScintillaNET.WrapMode.None Then
            combo_wrapmode.SelectedItem = "None"
        ElseIf My.Settings.set_wrapmode = ScintillaNET.WrapMode.Word Then
            combo_wrapmode.SelectedItem = "Word"
        ElseIf My.Settings.set_wrapmode = ScintillaNET.WrapMode.Char Then
            combo_wrapmode.SelectedItem = "Char"
        Else
            combo_wrapmode.SelectedItem = "Whitespace"
        End If
        check_smartcopy.Checked = My.Settings.set_smartcopy
        check_smartcut.Checked = My.Settings.set_smartcut
        check_smartpaste.Checked = My.Settings.set_smartpaste
        check_highlightmatchingwords.Checked = My.Settings.set_highlightmatchingwords
        For Each item As String In My.Settings.set_snippetlist
            lb_snippets.Items.Add(item)
        Next
        check_multiselectiontyping.Checked = My.Settings.set_multiselectiontyping
        check_highlightblock.Checked = My.Settings.set_highlightcurrentblock
        check_recordclipboardhistory.Checked = My.Settings.set_recordclipboardhistory
        check_rememberclipboardhistory.Checked = My.Settings.set_rememberclipboardhistory
        check_homelinewrap.Checked = My.Settings.set_homekeywrappedlines
        '-Code Intelligence
        check_intellisenseenabled.Checked = My.Settings.set_autocomplete_enabled
        check_usesmartindentation.Checked = My.Settings.set_usesmartindentation
        check_usesmartcompletion.Checked = My.Settings.set_usesmartcompletion
        check_highlightmatchingbraces.Checked = My.Settings.set_highlightmatchingbraceswhenselected
        check_showindentationguides.Checked = My.Settings.set_showindentationguides
        '-InfoPanel
        txt_infopanelsize.Text = My.Settings.set_infopanelsize
        check_showinfopanel.Checked = My.Settings.set_showinfopanelbydefault
        check_hoveroverinfopaneltoopen.Checked = My.Settings.set_hoveroverinfopaneltoopen
        '-Tab Triggers
        RefreshTriggerList()
        check_replacephrasewithtriggertext.Checked = My.Settings.set_tabtriggers_replacephrase
        check_triggersenabled.Checked = My.Settings.set_tabtriggers_enabled
        '-Code Templates
        RefreshTemplateList()
        '--------------------
        'Tools
        '-Voice++
        check_voicepp_commanddetectionatstartup.Checked = My.Settings.set_voicepp_commandrecatstartup
        '-Backup++
        txt_backupdirectory.Text = My.Settings.set_backupsloc
        check_autobackup.Checked = My.Settings.set_autobackup
        txt_backupinterval.Text = My.Settings.set_autobackupinterval
        check_alertbackup.Checked = My.Settings.set_alertbackup
        check_backupwhensaving.Checked = My.Settings.set_backupwhensaving
        check_encryptbackup.Checked = My.Settings.set_encryptbackup
        '-Encrypt++
        check_autoencrypt.Checked = My.Settings.set_autoencrypt
        txt_encryptinterval.Text = My.Settings.set_autoencryptinterval
        '-Web Browser
        txt_browserhomepage.Text = My.Settings.set_browserhome
        '-RSS
        txt_rssdefaultfeed.Text = My.Settings.set_rssdefaultfeed
        '-Code Recovery
        check_coderecovery_enabled.Checked = My.Settings.set_coderecovery_enabled
        txt_coderecovery_interval.Text = My.Settings.set_coderecovery_interval
        '--------------
        'Languages
        '-Java
        txt_javaclasspath.Text = My.Settings.set_javaclasspath
        '-Custom
        check_customlang_enabled.Checked = My.Settings.set_customlang_enabled
        txt_customlang_keywords0.Text = My.Settings.set_customlang_keywords0
        txt_customlang_keywords1.Text = My.Settings.set_customlang_keywords1
        txt_customlang_autocomplete.Text = My.Settings.set_customlang_autocompletelist
        '-------------
        'FTP
        txt_ftphostname.Text = My.Settings.set_ftphostname
        txt_ftpusername.Text = My.Settings.set_ftpusername
        txt_ftpuserpass.Text = My.Settings.set_ftpuserpass
        '-------------
    End Sub

    Private Sub ResetSettingsToDefault()
        ResetSyntaxHighlighting()
        'Quickpaste
        btn_resetallquickpastes.PerformClick()
        '----------------------
        'Studio
        '-Style
        combo_theme.SelectedItem = "Default"
        txt_customimage.Text = ""
        check_displaycustomimage.Checked = False
        combo_welcomeimagestyle.SelectedItem = "Stretch"
        pnl_toolpanelcolor.BackColor = System.Drawing.SystemColors.ActiveCaption
        pnl_projectexplorercolor.BackColor = System.Drawing.SystemColors.ActiveCaption
        pnl_menustripcolor.BackColor = System.Drawing.SystemColors.ActiveCaption
        check_setmenustriptextcolorwhite.Checked = False
        txt_toolpanelwidth.Text = "200"
        txt_projectexplorerwidth.Text = "200"
        check_toolpanelvisible.Checked = False
        check_menustrip_mousehover.Checked = True
        radio_tabstriptop.Checked = True
        txt_studiobg.Text = "DEFAULT"
        check_displaystudiobgimage.Checked = True
        '-Default Locations
        txt_defaultprojlocation.Text = "DEFAULT"
        txt_defaultdownloadlocation.Text = "DEFAULT"
        '-Custom Compiler
        check_customcompilerenabled.Checked = False
        txt_customcompilerloc.Text = ""
        txt_customcompilerpathvar.Text = ""
        txt_customcompilercommand.Text = ""
        txt_customcompilerparams.Text = ""
        check_customcompilerrequiresoutputfile.Checked = False
        txt_customcompilerfileextension.Text = ""
        '-Security
        check_applockenabled.Checked = False
        txt_applockpassword.Text = ""
        check_dispsecuritywarninglinksnotepad.Checked = True
        '-Toolbars
        pnl_toolbars_backcolor.BackColor = System.Drawing.SystemColors.ActiveCaption
        '-Speed Dial
        combo_sd_0.SelectedItem = "Code Editor"
        combo_sd_1.SelectedItem = "Notepad"
        combo_sd_2.SelectedItem = "Code Metrics"
        combo_sd_3.SelectedItem = "Bookmarks"
        combo_sd_4.SelectedItem = "Calendar"
        combo_sd_5.SelectedItem = "Documentation"
        combo_sd_6.SelectedItem = "Site Previewer"
        combo_sd_7.SelectedItem = "Universal Search"
        combo_sd_8.SelectedItem = "Web Browser"
        check_sd_mousehover.Checked = True
        pnl_sd_backcolor.BackColor = System.Drawing.SystemColors.ActiveCaption
        '-Other
        check_displaytrayicon.Checked = True
        combo_defaultwindowstate.SelectedItem = "Normal"
        check_openfileinselectededitor.Checked = False
        radio_donothing.Checked = True
        check_confirmexit.Checked = True
        check_enableperformancemodeatstartup.Checked = False
        check_keepfileloc.Checked = True
        check_rememberfilesonshutdown.Checked = True
        check_autosaveenabled.Checked = False
        txt_autosaveinterval.Text = "60"
        check_displaysplashscreen.Checked = True
        combo_startuptab.SelectedItem = "Welcome"
        check_requirefilestobecreated.Checked = False
        check_runscriptatstartup.Checked = False
        txt_scriptatstartup.Text = ""
        check_storenotifications.Checked = True
        '------------------------
        'Editor
        '-Document
        lbl_font.Font = New Font("Sans Serif", 9, FontStyle.Regular)
        lbl_font.Text = "Sans Serif"
        check_righttoleft.Checked = False
        combo_endofline.SelectedItem = "Crlf"
        check_eolvisible.Checked = False
        combo_caret.SelectedItem = "Line"
        check_allowdragdrop.Checked = True
        check_overtype.Checked = False
        combo_cursor.SelectedItem = "IBeam"
        check_highlightselectedline.Checked = False
        check_highlightmatchingbraces.Checked = True
        check_hl_enabled.Checked = True
        check_multiselection.Checked = True
        combo_multipaste.SelectedItem = "Each"
        combo_multipaste.SelectedItem = "None"
        check_smartcopy.Checked = True
        check_smartcut.Checked = True
        check_smartpaste.Checked = True
        check_highlightmatchingwords.Checked = True
        For Each item As String In My.Settings.set_snippetlist
            lb_snippets.Items.Add(item)
        Next
        check_multiselectiontyping.Checked = True
        check_highlightblock.Checked = True
        check_recordclipboardhistory.Checked = True
        check_rememberclipboardhistory.Checked = True
        check_homelinewrap.Checked = False
        '-Code Intelligence
        check_intellisenseenabled.Checked = True
        check_usesmartindentation.Checked = True
        check_usesmartcompletion.Checked = True
        check_showindentationguides.Checked = True
        '-InfoPanel
        txt_infopanelsize.Text = "200"
        check_showinfopanel.Checked = False
        check_hoveroverinfopaneltoopen.Checked = True
        check_documentmap.Checked = True
        '-Tab Triggers
        check_replacephrasewithtriggertext.Checked = True
        check_triggersenabled.Checked = False
        '-Code Templates
        '------------------------
        'Tools
        '-Voice++
        check_voicepp_commanddetectionatstartup.Checked = False
        '-Backup++
        txt_backupdirectory.Text = "DEFAULT"
        check_autobackup.Checked = False
        txt_backupinterval.Text = "300"
        check_alertbackup.Checked = True
        check_backupwhensaving.Checked = False
        check_encryptbackup.Checked = False
        '-Encrypt++
        check_autoencrypt.Checked = False
        txt_encryptinterval.Text = "300"
        '-Web Browser
        txt_browserhomepage.Text = "http://www.google.com"
        '-RSS
        txt_rssdefaultfeed.Text = ""
        '-Code Recovery
        check_coderecovery_enabled.Checked = True
        txt_coderecovery_interval.Text = 10
        '------------------
        'Languages
        '-Java
        txt_javaclasspath.Text = "C:\Program Files\Java\jdk1.7.0_71\bin"
        '-Custom
        check_customlang_enabled.Checked = False
        txt_customlang_keywords0.Text = ""
        txt_customlang_keywords1.Text = ""
        txt_customlang_autocomplete.Text = ""
        '-----------------------
        'FTP
        txt_ftphostname.Text = ""
        txt_ftpusername.Text = ""
        txt_ftpuserpass.Text = ""
        '------------
    End Sub

    Private Sub SaveSettings()
        SaveSyntaxHighlighting()
        'QuickPaste
        My.Settings.set_quickpaste(0) = txt_quickpaste1.Text
        My.Settings.set_quickpaste(1) = txt_quickpaste2.Text
        My.Settings.set_quickpaste(2) = txt_quickpaste3.Text
        My.Settings.set_quickpaste(3) = txt_quickpaste4.Text
        My.Settings.set_quickpaste(4) = txt_quickpaste5.Text
        My.Settings.set_quickpaste(5) = txt_quickpaste6.Text
        My.Settings.set_quickpaste(6) = txt_quickpaste7.Text
        My.Settings.set_quickpaste(7) = txt_quickpaste8.Text
        My.Settings.set_quickpaste(8) = txt_quickpaste9.Text
        My.Settings.set_quickpaste(9) = txt_quickpaste10.Text
        My.Settings.set_quickpaste(10) = txt_quickpaste11.Text
        My.Settings.set_quickpaste(11) = txt_quickpaste12.Text
        My.Settings.set_quickpaste(12) = txt_quickpaste13.Text
        My.Settings.set_quickpaste(13) = txt_quickpaste14.Text
        My.Settings.set_quickpaste(14) = txt_quickpaste15.Text
        My.Settings.set_quickpaste(15) = txt_quickpaste16.Text
        My.Settings.set_quickpaste(16) = txt_quickpaste17.Text
        My.Settings.set_quickpaste(17) = txt_quickpaste18.Text
        '-----------------
        'Studio
        '-Style
        If combo_theme.SelectedItem = "Default" Then
            My.Settings.set_theme = MetroFramework.MetroThemeStyle.Default
        Else
            My.Settings.set_theme = MetroFramework.MetroThemeStyle.Dark
        End If
        My.Settings.set_welcomeimagelocation = txt_customimage.Text
        My.Settings.set_displaywelcomeimage = check_displaycustomimage.Checked
        My.Settings.set_welcomeimagestyle = combo_welcomeimagestyle.SelectedItem
        My.Settings.set_menustriptextcolorwhite = check_setmenustriptextcolorwhite.Checked
        My.Settings.set_toolpanelcolor = pnl_toolpanelcolor.BackColor
        My.Settings.set_projectexplorercolor = pnl_projectexplorercolor.BackColor
        My.Settings.set_menustripcolor = pnl_menustripcolor.BackColor
        My.Settings.set_toolpanelwidth = txt_toolpanelwidth.Text
        My.Settings.set_projectexplorerwidth = txt_projectexplorerwidth.Text
        My.Settings.set_toolpanelvisibleatstartup = check_toolpanelvisible.Checked
        My.Settings.set_menustrip_mousehover = check_menustrip_mousehover.Checked
        If radio_tabstriptop.Checked Then
            My.Settings.set_tabstriplocation = WeifenLuo.WinFormsUI.Docking.DocumentTabStripLocation.Top
        ElseIf radio_tabstripbottom.Checked Then
            My.Settings.set_tabstriplocation = WeifenLuo.WinFormsUI.Docking.DocumentTabStripLocation.Bottom
        End If
        My.Settings.set_dockpanelbg = txt_studiobg.Text
        My.Settings.set_displaystudiobgimage = check_displaystudiobgimage.Checked
        '-Default Locations
        My.Settings.set_defaultprojlocation = txt_defaultprojlocation.Text
        My.Settings.set_defaultdownloadlocation = txt_defaultdownloadlocation.Text
        '-Custom Compiler
        My.Settings.set_customcompilerenabled = check_customcompilerenabled.Checked
        My.Settings.set_customcompilerloc = txt_customcompilerloc.Text
        My.Settings.set_customcompilerpathvar = txt_customcompilerpathvar.Text
        My.Settings.set_customcompilercommand = txt_customcompilercommand.Text
        My.Settings.set_customcompilerparams = txt_customcompilerparams.Text
        My.Settings.set_customcompilerrequiressecondfile = check_customcompilerrequiresoutputfile.Checked
        My.Settings.set_customcompilerextension = txt_customcompilerfileextension.Text
        '-Security
        My.Settings.set_applockenabled = check_applockenabled.Checked
        My.Settings.set_applockpassword = txt_applockpassword.Text
        My.Settings.set_notepad_linksecuritynotification = check_dispsecuritywarninglinksnotepad.Checked
        '-Toolbars
        My.Settings.set_toolbars_backcolor = pnl_toolbars_backcolor.BackColor
        '-Speed Dial
        My.Settings.set_speeddial(0) = combo_sd_0.SelectedItem
        My.Settings.set_speeddial(1) = combo_sd_1.SelectedItem
        My.Settings.set_speeddial(2) = combo_sd_2.SelectedItem
        My.Settings.set_speeddial(3) = combo_sd_3.SelectedItem
        My.Settings.set_speeddial(4) = combo_sd_4.SelectedItem
        My.Settings.set_speeddial(5) = combo_sd_5.SelectedItem
        My.Settings.set_speeddial(6) = combo_sd_6.SelectedItem
        My.Settings.set_speeddial(7) = combo_sd_7.SelectedItem
        My.Settings.set_speeddial(8) = combo_sd_8.SelectedItem
        My.Settings.set_speeddial_mousehover = check_sd_mousehover.Checked
        My.Settings.set_speeddial_backcolor = pnl_sd_backcolor.BackColor
        '-Other
        If combo_defaultwindowstate.SelectedItem = "Normal" Then
            My.Settings.set_defaultwindowstate = FormWindowState.Normal
        Else
            My.Settings.set_defaultwindowstate = FormWindowState.Maximized
        End If
        My.Settings.set_displaytrayicon = check_displaytrayicon.Checked
        My.Settings.set_openfileinselectededitor = check_openfileinselectededitor.Checked
        If radio_donothing.Checked Then
            My.Settings.set_actionifnotabs = 0
        ElseIf radio_notabs_addeditor.Checked Then
            My.Settings.set_actionifnotabs = 1
        ElseIf radio_notabs_exitstudio.Checked Then
            My.Settings.set_actionifnotabs = 2
        End If
        My.Settings.set_confirmexit = check_confirmexit.Checked
        My.Settings.set_enableperformancemodeatstartup = check_enableperformancemodeatstartup.Checked
        My.Settings.set_keepfileloc = check_keepfileloc.Checked
        My.Settings.set_rememberopenedfiles = check_rememberfilesonshutdown.Checked
        My.Settings.set_autosave = check_autosaveenabled.Checked
        My.Settings.set_autosave_interval = txt_autosaveinterval.Text
        My.Settings.set_displaysplashscreen = check_displaysplashscreen.Checked
        My.Settings.set_startuptab = combo_startuptab.SelectedItem
        My.Settings.set_requirefilecreation = check_requirefilestobecreated.Checked
        My.Settings.set_runscriptatstartup = check_runscriptatstartup.Checked
        My.Settings.set_scripttorunatstartup = txt_scriptatstartup.Text
        My.Settings.set_storenotifications = check_storenotifications.Checked
        '----------------
        'Editor
        '-Document
        My.Settings.set_defaultfont = lbl_font.Font
        My.Settings.set_righttoleft = check_righttoleft.Checked
        If combo_endofline.SelectedItem = "Crlf" Then
            My.Settings.set_endofline = ScintillaNET.Eol.CrLf
        ElseIf combo_endofline.SelectedItem = "LF" Then
            My.Settings.set_endofline = ScintillaNET.Eol.Lf
        Else
            My.Settings.set_endofline = ScintillaNET.Eol.Cr
        End If
        My.Settings.set_eolvisible = check_eolvisible.Checked
        If combo_caret.SelectedItem = "Invisible" Then
            My.Settings.set_caret = ScintillaNET.CaretStyle.Invisible
        ElseIf combo_caret.SelectedItem = "Line" Then
            My.Settings.set_caret = ScintillaNET.CaretStyle.Line
        Else
            My.Settings.set_caret = ScintillaNET.CaretStyle.Block
        End If
        My.Settings.set_allowdragdrop = check_allowdragdrop.Checked
        My.Settings.set_Overtype = check_overtype.Checked
        If combo_cursor.SelectedItem = "Arrow" Then
            My.Settings.set_cursor = 1
        ElseIf combo_cursor.SelectedItem = "IBeam" Then
            My.Settings.set_cursor = 0
        End If
        My.Settings.set_highlightselectedline = check_highlightselectedline.Checked
        My.Settings.set_highlightmatchingselection = check_hl_enabled.Checked
        My.Settings.set_editordocumentmap = check_documentmap.Checked
        If combo_wrapmode.SelectedItem = "None" Then
            My.Settings.set_wrapmode = ScintillaNET.WrapMode.None
        ElseIf combo_wrapmode.SelectedItem = "Word" Then
            My.Settings.set_wrapmode = ScintillaNET.WrapMode.Word
        ElseIf combo_wrapmode.SelectedItem = "Char" Then
            My.Settings.set_wrapmode = ScintillaNET.WrapMode.Char
        Else
            My.Settings.set_wrapmode = ScintillaNET.WrapMode.Whitespace
        End If
        My.Settings.set_smartcopy = check_smartcopy.Checked
        My.Settings.set_smartcut = check_smartcut.Checked
        My.Settings.set_smartpaste = check_smartpaste.Checked
        My.Settings.set_highlightmatchingwords = check_highlightmatchingwords.Checked
        My.Settings.set_snippetlist.Clear()
        For Each item As String In lb_snippets.Items
            My.Settings.set_snippetlist.Add(item)
        Next
        My.Settings.set_multiselectiontyping = check_multiselectiontyping.Checked
        My.Settings.set_highlightcurrentblock = check_highlightblock.Checked
        My.Settings.set_recordclipboardhistory = check_recordclipboardhistory.Checked
        My.Settings.set_rememberclipboardhistory = check_rememberclipboardhistory.Checked
        My.Settings.set_homekeywrappedlines = check_homelinewrap.Checked
        '-Code Intelligence
        My.Settings.set_autocomplete_enabled = check_intellisenseenabled.Checked
        My.Settings.set_usesmartindentation = check_usesmartindentation.Checked
        My.Settings.set_usesmartcompletion = check_usesmartcompletion.Checked
        My.Settings.set_highlightmatchingbraceswhenselected = check_highlightmatchingbraces.Checked
        My.Settings.set_showindentationguides = check_showindentationguides.Checked
        '-InfoPanel
        My.Settings.set_infopanelsize = txt_infopanelsize.Text
        My.Settings.set_showinfopanelbydefault = check_showinfopanel.Checked
        My.Settings.set_hoveroverinfopaneltoopen = check_hoveroverinfopaneltoopen.Checked
        My.Settings.set_multiselection = check_multiselection.Checked
        If combo_multipaste.SelectedItem = "Each" Then
            My.Settings.set_multipaste = ScintillaNET.MultiPaste.Each
        Else
            My.Settings.set_multipaste = ScintillaNET.MultiPaste.Once
        End If
        '-Tab Triggers
        My.Settings.set_tabtriggers_replacephrase = check_replacephrasewithtriggertext.Checked
        My.Settings.set_tabtriggers_enabled = check_triggersenabled.Checked
        '-Code Templates
        '---------------
        'Tools
        '-Voice++
        My.Settings.set_voicepp_commandrecatstartup = check_voicepp_commanddetectionatstartup.Checked
        '-Backup++
        My.Settings.set_backupsloc = txt_backupdirectory.Text
        My.Settings.set_autobackup = check_autobackup.Checked
        My.Settings.set_autobackupinterval = txt_backupinterval.Text
        My.Settings.set_alertbackup = check_alertbackup.Checked
        My.Settings.set_backupwhensaving = check_backupwhensaving.Checked
        My.Settings.set_encryptbackup = check_encryptbackup.Checked
        '-Encrypt++
        My.Settings.set_autobackup = check_autobackup.Checked
        My.Settings.set_autoencryptinterval = txt_encryptinterval.Text
        '-Web Browser
        My.Settings.set_browserhome = txt_browserhomepage.Text
        '-RSS
        My.Settings.set_rssdefaultfeed = txt_rssdefaultfeed.Text
        '-Code Recovery
        My.Settings.set_coderecovery_enabled = check_coderecovery_enabled.Checked
        My.Settings.set_coderecovery_interval = txt_coderecovery_interval.Text
        '------------------
        'Languages
        '-Java
        My.Settings.set_javaclasspath = txt_javaclasspath.Text
        '-Custom
        My.Settings.set_customlang_enabled = check_customlang_enabled.Checked
        My.Settings.set_customlang_keywords0 = txt_customlang_keywords0.Text
        My.Settings.set_customlang_keywords1 = txt_customlang_keywords1.Text
        My.Settings.set_customlang_autocompletelist = txt_customlang_autocomplete.Text
        '----------
        'FTP
        My.Settings.set_ftphostname = txt_ftphostname.Text
        My.Settings.set_ftpusername = txt_ftpusername.Text
        My.Settings.set_ftpuserpass = txt_ftpuserpass.Text
        '-------------
        My.Settings.Save()
    End Sub

#Region "Syntax Highlighting"

    Private Sub LoadSyntaxHighlighting()
        Try
            Dim xml = XDocument.Load(XDev.Path.Locator.GetDataPath & "\Editor\syntaxhighlighting.xml")
            pnl_highlighting_default.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DEFAULT>.Value)
            pnl_highlighting_comment.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENT>.Value)
            pnl_highlighting_commentblock.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENTBLOCK>.Value)
            pnl_highlighting_commentline.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENTLINE>.Value)
            pnl_highlighting_commentlinedoc.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENTLINEDOC>.Value)
            pnl_highlighting_number.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<NUMBER>.Value)
            pnl_highlighting_word.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<WORD>.Value)
            pnl_highlighting_word2.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<WORD2>.Value)
            pnl_highlighting_word3.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<WORD3>.Value)
            pnl_highlighting_string.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<STRING>.Value)
            pnl_highlighting_character.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CHARACTER>.Value)
            pnl_highlighting_verbatim.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<VERBATIM>.Value)
            pnl_highlighting_stringeol.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<STRINGEOL>.Value)
            pnl_highlighting_charactereol.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CHARACTEREOL>.Value)
            pnl_highlighting_operator.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<OPERATOR>.Value)
            pnl_highlighting_preprocessor.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<PREPROCESSOR>.Value)
            pnl_highlighting_delimiter.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DELIMITER>.Value)
            pnl_highlighting_label.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<LABEL>.Value)
            pnl_highlighting_illegal.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ILLEGAL>.Value)
            pnl_highlighting_identifier.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<IDENTIFIER>.Value)
            pnl_highlighting_cpuinstruction.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CPUINSTRUCTION>.Value)
            pnl_highlighting_mathinstruction.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<MATHINSTRUCTION>.Value)
            pnl_highlighting_extinstruction.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<EXTINSTRUCTION>.Value)
            pnl_highlighting_register.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<REGISTER>.Value)
            pnl_highlighting_directive.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DIRECTIVE>.Value)
            pnl_highlighting_directiveoperand.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DIRECTIVEOPERAND>.Value)
            pnl_highlighting_hide.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<HIDE>.Value)
            pnl_highlighting_triple.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<TRIPLE>.Value)
            pnl_highlighting_tripledouble.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<TRIPLEDOUBLE>.Value)
            pnl_highlighting_classname.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CLASSNAME>.Value)
            pnl_highlighting_defname.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DEFNAME>.Value)
            pnl_highlighting_decorator.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DECORATOR>.Value)
            pnl_highlighting_uuid.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<UUID>.Value)
            pnl_highlighting_regex.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<REGEX>.Value)
            pnl_highlighting_commentdockeyword.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENTDOCKEYWORD>.Value)
            pnl_highlighting_commentdockeyworderror.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENTDOCKEYWORDERROR>.Value)
            pnl_highlighting_tag.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<TAG>.Value)
            pnl_highlighting_tagunknown.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<TAGUNKNOWN>.Value)
            pnl_highlighting_pseudoclass.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<PSEUDOCLASS>.Value)
            pnl_highlighting_unknownpseudoclass.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<UNKNOWNPSEUDOCLASS>.Value)
            pnl_highlighting_unknownidentifier.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<UNKNOWNIDENTIFIER>.Value)
            pnl_highlighting_value.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<VALUE>.Value)
            pnl_highlighting_id.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ID>.Value)
            pnl_highlighting_important.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<IMPORTANT>.Value)
            pnl_highlighting_attribute.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ATTRIBUTE>.Value)
            pnl_highlighting_attributeunknown.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ATTRIBUTEUNKNOWN>.Value)
            pnl_highlighting_entity.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ENTITY>.Value)
            pnl_highlighting_continuation.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CONTINUATION>.Value)
            pnl_highlighting_doublestring.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DOUBLESTRING>.Value)
            pnl_highlighting_other.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<OTHER>.Value)
            pnl_highlighting_xmlstart.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<XMLSTART>.Value)
            pnl_highlighting_xmlend.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<XMLEND>.Value)
            pnl_highlighting_script.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SCRIPT>.Value)
            pnl_highlighting_asp.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ASP>.Value)
            pnl_highlighting_aspat.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ASPAT>.Value)
            pnl_highlighting_question.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<QUESTION>.Value)
            pnl_highlighting_cdata.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CDATA>.Value)
            pnl_highlighting_xccomment.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<XCCOMMENT>.Value)
            pnl_highlighting_special.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SPECIAL>.Value)
            pnl_highlighting_symbol.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SYMBOL>.Value)
            pnl_highlighting_instructionword.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<INSTRUCTIONWORD>.Value)
            pnl_highlighting_scalar.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SCALAR>.Value)
            pnl_highlighting_array.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ARRAY>.Value)
            pnl_highlighting_hash.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<HASH>.Value)
            pnl_highlighting_symboltable.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SYMBOLTABLE>.Value)
            pnl_highlighting_datasection.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DATASECTION>.Value)
            pnl_highlighting_pod.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<POD>.Value)
            pnl_highlighting_longquote.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<LONGQUOTE>.Value)
            pnl_highlighting_backticks.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<BACKTICKS>.Value)
            pnl_highlighting_punctuation.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<PUNCTUATION>.Value)
            pnl_highlighting_variable.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<VARIABLE>.Value)
            pnl_highlighting_global.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<GLOBAL>.Value)
            pnl_highlighting_modulename.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<MODULENAME>.Value)
            pnl_highlighting_instancevar.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<INSTANCEVAR>.Value)
            pnl_highlighting_stdin.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<STDIN>.Value)
            pnl_highlighting_stdout.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<STDOUT>.Value)
            pnl_highlighting_stderr.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<STDERR>.Value)
            pnl_highlighting_worddemoted.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<WORDDEMOTED>.Value)
            pnl_highlighting_classvar.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CLASSVAR>.Value)
            pnl_highlighting_specsel.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SPECSEL>.Value)
            pnl_highlighting_assign.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ASSIGN>.Value)
            pnl_highlighting_kwsend.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<KWSEND>.Value)
            pnl_highlighting_return.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<RETURN>.Value)
            pnl_highlighting_nil.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<NIL>.Value)
            pnl_highlighting_binary.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<BINARY>.Value)
            pnl_highlighting_super.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SUPER>.Value)
            pnl_highlighting_self.BackColor = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SELF>.Value)
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Sub ResetSyntaxHighlighting()
        pnl_highlighting_default.BackColor = Color.Black
        pnl_highlighting_comment.BackColor = Color.FromArgb(0, 128, 0)
        pnl_highlighting_commentblock.BackColor = Color.FromArgb(0, 128, 0)
        pnl_highlighting_commentline.BackColor = Color.FromArgb(0, 128, 0)
        pnl_highlighting_commentlinedoc.BackColor = Color.FromArgb(128, 128, 128)
        pnl_highlighting_number.BackColor = Color.Goldenrod
        pnl_highlighting_word.BackColor = Color.Blue
        pnl_highlighting_word2.BackColor = Color.Blue
        pnl_highlighting_word3.BackColor = Color.Blue
        pnl_highlighting_string.BackColor = Color.FromArgb(163, 21, 21)
        pnl_highlighting_character.BackColor = Color.FromArgb(163, 21, 21)
        pnl_highlighting_verbatim.BackColor = Color.FromArgb(163, 21, 21)
        pnl_highlighting_stringeol.BackColor = Color.Pink
        pnl_highlighting_charactereol.BackColor = Color.Pink
        pnl_highlighting_operator.BackColor = Color.Purple
        pnl_highlighting_preprocessor.BackColor = Color.Maroon
        pnl_highlighting_delimiter.BackColor = Color.LightCoral
        pnl_highlighting_label.BackColor = Color.Brown
        pnl_highlighting_illegal.BackColor = Color.Red
        pnl_highlighting_identifier.BackColor = Color.Black
        pnl_highlighting_cpuinstruction.BackColor = Color.DarkBlue
        pnl_highlighting_mathinstruction.BackColor = Color.Blue
        pnl_highlighting_extinstruction.BackColor = Color.LightBlue
        pnl_highlighting_register.BackColor = Color.Purple
        pnl_highlighting_directive.BackColor = Color.Blue
        pnl_highlighting_directiveoperand.BackColor = Color.DarkBlue
        pnl_highlighting_hide.BackColor = Color.HotPink
        pnl_highlighting_triple.BackColor = Color.FromArgb(&H7F, &H0, &H0)
        pnl_highlighting_tripledouble.BackColor = Color.FromArgb(&H7F, &H0, &H0)
        pnl_highlighting_classname.BackColor = Color.FromArgb(&H0, &H0, &HFF)
        pnl_highlighting_defname.BackColor = Color.FromArgb(&H0, &H7F, &H7F)
        pnl_highlighting_decorator.BackColor = Color.FromArgb(&H80, &H50, &H0)
        pnl_highlighting_uuid.BackColor = Color.FromArgb(163, 21, 21)
        pnl_highlighting_regex.BackColor = Color.Black
        pnl_highlighting_commentdockeyword.BackColor = Color.DarkCyan
        pnl_highlighting_commentdockeyworderror.BackColor = Color.DarkCyan
        pnl_highlighting_tag.BackColor = Color.Blue
        pnl_highlighting_tagunknown.BackColor = Color.Black
        pnl_highlighting_pseudoclass.BackColor = Color.Orange
        pnl_highlighting_unknownpseudoclass.BackColor = Color.LightCoral
        pnl_highlighting_unknownidentifier.BackColor = Color.Black
        pnl_highlighting_value.BackColor = Color.Orange
        pnl_highlighting_id.BackColor = Color.RoyalBlue
        pnl_highlighting_important.BackColor = Color.Red
        pnl_highlighting_attribute.BackColor = Color.Red
        pnl_highlighting_attributeunknown.BackColor = Color.Black
        pnl_highlighting_entity.BackColor = Color.Black
        pnl_highlighting_continuation.BackColor = Color.FromArgb(0, 128, 0)
        pnl_highlighting_doublestring.BackColor = Color.Purple
        pnl_highlighting_other.BackColor = Color.Black
        pnl_highlighting_xmlstart.BackColor = Color.Blue
        pnl_highlighting_xmlend.BackColor = Color.Blue
        pnl_highlighting_script.BackColor = Color.Plum
        pnl_highlighting_asp.BackColor = Color.Plum
        pnl_highlighting_aspat.BackColor = Color.Plum
        pnl_highlighting_question.BackColor = Color.DarkGray
        pnl_highlighting_cdata.BackColor = Color.Orange
        pnl_highlighting_xccomment.BackColor = Color.FromArgb(0, 128, 0)
        pnl_highlighting_special.BackColor = Color.RoyalBlue
        pnl_highlighting_symbol.BackColor = Color.Navy
        pnl_highlighting_instructionword.BackColor = Color.Blue
        pnl_highlighting_scalar.BackColor = Color.Orange
        pnl_highlighting_array.BackColor = Color.Purple
        pnl_highlighting_hash.BackColor = Color.MediumPurple
        pnl_highlighting_symboltable.BackColor = Color.Red
        pnl_highlighting_datasection.BackColor = Color.Maroon
        pnl_highlighting_pod.BackColor = Color.Black
        pnl_highlighting_longquote.BackColor = Color.Orange
        pnl_highlighting_backticks.BackColor = Color.Yellow
        pnl_highlighting_punctuation.BackColor = Color.Brown
        pnl_highlighting_variable.BackColor = Color.Navy
        pnl_highlighting_global.BackColor = Color.DarkBlue
        pnl_highlighting_modulename.BackColor = Color.Brown
        pnl_highlighting_instancevar.BackColor = Color.Black
        pnl_highlighting_stdin.BackColor = Color.LightBlue
        pnl_highlighting_stdout.BackColor = Color.Blue
        pnl_highlighting_stderr.BackColor = Color.Red
        pnl_highlighting_worddemoted.BackColor = Color.DarkGoldenrod
        pnl_highlighting_classvar.BackColor = Color.DarkCyan
        pnl_highlighting_specsel.BackColor = Color.Pink
        pnl_highlighting_assign.BackColor = Color.Red
        pnl_highlighting_kwsend.BackColor = Color.RoyalBlue
        pnl_highlighting_return.BackColor = Color.Blue
        pnl_highlighting_nil.BackColor = Color.Purple
        pnl_highlighting_binary.BackColor = Color.Navy
        pnl_highlighting_super.BackColor = Color.LightBlue
        pnl_highlighting_self.BackColor = Color.MediumSlateBlue
    End Sub

    Private Sub SaveSyntaxHighlighting()
        Dim writer As New XmlTextWriter(XDev.Path.Locator.GetDataPath & "\Editor\syntaxhighlighting.xml", System.Text.Encoding.UTF8)
        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        writer.WriteStartElement("XDevStudio_SyntaxHighlighting")
        '----------------------
        writer.WriteStartElement("DEFAULT")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_default.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("COMMENT")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_comment.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("COMMENTBLOCK")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_commentblock.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("COMMENTLINE")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_commentline.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("COMMENTLINEDOC")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_commentlinedoc.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("NUMBER")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_number.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("WORD")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_word.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("WORD2")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_word2.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("WORD3")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_word3.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("STRING")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_string.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("CHARACTER")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_character.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("VERBATIM")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_verbatim.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("STRINGEOL")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_stringeol.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("CHARACTEREOL")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_charactereol.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("OPERATOR")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_operator.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("PREPROCESSOR")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_preprocessor.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("DELIMITER")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_delimiter.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("LABEL")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_label.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("ILLEGAL")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_illegal.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("IDENTIFIER")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_identifier.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("CPUINSTRUCTION")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_cpuinstruction.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("MATHINSTRUCTION")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_mathinstruction.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("EXTINSTRUCTION")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_extinstruction.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("REGISTER")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_register.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("DIRECTIVE")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_directive.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("DIRECTIVEOPERAND")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_directiveoperand.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("HIDE")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_hide.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("TRIPLE")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_triple.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("TRIPLEDOUBLE")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_tripledouble.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("CLASSNAME")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_classname.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("DEFNAME")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_defname.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("DECORATOR")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_decorator.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("UUID")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_uuid.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("REGEX")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_regex.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("COMMENTDOCKEYWORD")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_commentdockeyword.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("COMMENTDOCKEYWORDERROR")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_commentdockeyworderror.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("TAG")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_tag.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("TAGUNKNOWN")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_tagunknown.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("PSEUDOCLASS")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_pseudoclass.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("UNKNOWNPSEUDOCLASS")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_unknownpseudoclass.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("UNKNOWNIDENTIFIER")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_unknownidentifier.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("VALUE")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_value.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("ID")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_id.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("IMPORTANT")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_important.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("ATTRIBUTE")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_attribute.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("ATTRIBUTEUNKNOWN")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_attributeunknown.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("ENTITY")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_entity.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("CONTINUATION")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_continuation.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("DOUBLESTRING")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_doublestring.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("OTHER")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_other.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("XMLSTART")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_xmlstart.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("XMLEND")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_xmlend.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("SCRIPT")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_script.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("ASP")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_asp.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("ASPAT")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_aspat.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("QUESTION")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_question.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("CDATA")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_cdata.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("XCCOMMENT")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_xccomment.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("SPECIAL")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_special.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("SYMBOL")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_symbol.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("INSTRUCTIONWORD")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_instructionword.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("SCALAR")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_scalar.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("ARRAY")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_array.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("HASH")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_hash.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("SYMBOLTABLE")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_symboltable.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("DATASECTION")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_datasection.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("POD")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_pod.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("LONGQUOTE")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_longquote.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("BACKTICKS")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_backticks.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("PUNCTUATION")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_punctuation.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("VARIABLE")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_variable.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("GLOBAL")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_global.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("MODULENAME")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_modulename.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("INSTANCEVAR")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_instancevar.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("STDIN")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_stdin.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("STDOUT")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_stdout.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("STDERR")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_stderr.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("WORDDEMOTED")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_worddemoted.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("CLASSVAR")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_classvar.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("SPECSEL")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_specsel.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("ASSIGN")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_assign.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("KWSEND")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_kwsend.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("RETURN")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_return.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("NIL")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_nil.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("BINARY")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_binary.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("SUPER")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_super.BackColor))
        writer.WriteEndElement()
        writer.WriteStartElement("SELF")
        writer.WriteString(ColorConverter.ConvertColorToString(pnl_highlighting_self.BackColor))
        writer.WriteEndElement()
        '---------------------
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
    End Sub


#End Region

#End Region

    Private Sub Tab_Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()
        InitializeSpeedDialComboBoxes()
        LoadSettings()
        Me.ResumeLayout()
    End Sub

#Region "Bottom Panel"

    Private Sub btn_upgradesettings_Click(sender As Object, e As EventArgs) Handles btn_upgradesettings.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to upgrade the settings from a previous config version? This updates the settings with values from a previously installed version of XDev Studio. Please note that you should only use this option if you have upgraded XDev Studio from a previous version.", "Upgrade Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            My.Settings.Upgrade()
            Settings.LoadSettings(True)
            frmManager.UpdateMenuItems()
        End If
    End Sub

    Private Sub btn_resetsettingstodefault_Click(sender As Object, e As EventArgs) Handles btn_resetsettingstodefault.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to reset all settings to their default values?", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ResetSettingsToDefault()
            Logger.Write(Logger.TypeOfLog.Studio, "Reset settings to their default values.")
        End If
    End Sub

    Private Sub btn_savesettings_Click(sender As Object, e As EventArgs) Handles btn_savesettings.Click
        SaveSettings()
        If MetroFramework.MetroMessageBox.Show(frmManager, "All Settings have been saved! Do you want to apply these settings now? This will also affect any open code editors. Otherwise the changes will take effect upon restart.", "Settings Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            Settings.LoadSettings(True)
            frmManager.UpdateMenuItems()
        End If
        Logger.Write(Logger.TypeOfLog.Studio, "Saved any changes made to the settings.")
    End Sub

#End Region

End Class
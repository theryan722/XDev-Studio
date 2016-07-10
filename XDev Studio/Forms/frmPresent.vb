Imports ScintillaNET

Friend Class frmPresent
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
    Private hcolor As Color = Color.Yellow
    'Private highlightmode As Boolean = False
    'Dim highlightlist As New List(Of Range)

#Region "Methods"
    
    Public Sub HideNotes()
        pnl_notes.Hide()
    End Sub

    Public Sub ShowNotes()
        pnl_notes.Location = New System.Drawing.Point(0, 60)
        pnl_notes.Show()
    End Sub

    Public Sub UpdateTitle(ByVal title As String)
        Me.Text = title & " - Presentation Mode"
    End Sub

#Region "SetCheckedLanguage"

    Public Sub SetCheckedLanguage(ByVal lang As XDev.Editor.Language.EditorLanguage)
        Select Case lang
            Case XDev.Editor.Language.EditorLanguage.Ada
                AdaToolStripMenuItem.Checked = True
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Assembly
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = True
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Batch
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = True
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Cpp
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = True
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Csharp
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = True
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Css
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = True
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Fortran
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = True
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Html
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = True
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Java
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = True
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.JavaScript
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = True
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Lisp
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = True
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Lua
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = True
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Pascal
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = True
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Perl
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = True
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Php
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = True
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Psql
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = True
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Python
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = True
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Ruby
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = True
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.SmallTalk
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = True
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Sql
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = True
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.VB
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = True
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Xml
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = True
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.Yaml
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = True
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = False
            Case XDev.Editor.Language.EditorLanguage.CustomLanguage
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = False
                CustomToolStripMenuItem.Checked = True
            Case XDev.Editor.Language.EditorLanguage.PlainText
                AdaToolStripMenuItem.Checked = False
                AssemblyToolStripMenuItem.Checked = False
                BatchToolStripMenuItem.Checked = False
                CToolStripMenuItem.Checked = False
                CToolStripMenuItem1.Checked = False
                CSSToolStripMenuItem.Checked = False
                FortranToolStripMenuItem.Checked = False
                HTMLToolStripMenuItem.Checked = False
                JavaToolStripMenuItem.Checked = False
                JavaScriptToolStripMenuItem.Checked = False
                LispToolStripMenuItem.Checked = False
                LuaToolStripMenuItem.Checked = False
                PascalToolStripMenuItem.Checked = False
                PerlToolStripMenuItem.Checked = False
                PHPToolStripMenuItem.Checked = False
                PostgreSQLToolStripMenuItem.Checked = False
                PythonToolStripMenuItem.Checked = False
                RubyToolStripMenuItem.Checked = False
                SmalltalkToolStripMenuItem.Checked = False
                SQLToolStripMenuItem.Checked = False
                VBScriptToolStripMenuItem.Checked = False
                XMLToolStripMenuItem.Checked = False
                YAMLToolStripMenuItem.Checked = False
                PlainTextToolStripMenuItem.Checked = True
                CustomToolStripMenuItem.Checked = False
            Case Else
        End Select
    End Sub

#End Region

#End Region

#Region "Status Bar"

#Region "Menu"

    Private Sub ToolStripSplitButton1_MouseHover(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.MouseHover
        ToolStripSplitButton1.ShowDropDown()
    End Sub

    Private Sub TopmostToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TopmostToolStripMenuItem.Click
        If Me.TopMost = True Then
            Me.TopMost = False
            TopmostToolStripMenuItem.Checked = False
        Else
            Me.TopMost = True
            TopmostToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

#End Region

#Region "Zoom"

    Private Sub ToolStripSplitButton2_MouseHover(sender As Object, e As EventArgs) Handles ToolStripSplitButton2.MouseHover
        ToolStripSplitButton2.ShowDropDown()
    End Sub

    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultToolStripMenuItem.Click
        TextBox1.Zoom = 1
        ZoomLevelToolStripMenuItem.Text = "Zoom Level: " + TextBox1.Zoom.ToString
    End Sub

    Private Sub ZoomInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomInToolStripMenuItem.Click
        TextBox1.Zoom += 1
        ZoomLevelToolStripMenuItem.Text = "Zoom Level: " + TextBox1.Zoom.ToString
    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomOutToolStripMenuItem.Click
        TextBox1.Zoom -= 1
        ZoomLevelToolStripMenuItem.Text = "Zoom Level: " + TextBox1.Zoom.ToString
    End Sub

#End Region

#Region "Tools"

    Private Sub ToolStripSplitButton3_MouseHover(sender As Object, e As EventArgs) Handles ToolStripSplitButton3.MouseHover
        ToolStripSplitButton3.ShowDropDown()
    End Sub

    Private Sub CopyDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyDocumentToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(TextBox1.Text)
        MetroFramework.MetroMessageBox.Show(frmManager, "Copied Document to Clipboard!", "Copied Document", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub HighlightCurrentLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HighlightCurrentLineToolStripMenuItem.Click
        If TextBox1.HighlightCurrentLine Then
            TextBox1.HighlightCurrentLine = False
            HighlightCurrentLineToolStripMenuItem.Checked = False
        Else
            TextBox1.HighlightCurrentLine = True
            HighlightCurrentLineToolStripMenuItem.Checked = True
        End If
    End Sub

#End Region

#Region "Language"

    Private Sub ToolStripSplitButton4_MouseHover(sender As Object, e As EventArgs) Handles ToolStripSplitButton4.MouseHover
        ToolStripSplitButton4.ShowDropDown()
    End Sub

    Private Sub PlainTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlainTextToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.PlainText
    End Sub

    Private Sub CustomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.CustomLanguage
    End Sub

    Private Sub AdaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdaToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Ada
    End Sub

    Private Sub AssemblyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssemblyToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Assembly
    End Sub

    Private Sub BatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BatchToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Batch
    End Sub

    Private Sub CToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Csharp
    End Sub

    Private Sub CToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CToolStripMenuItem1.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Cpp
    End Sub

    Private Sub CSSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSSToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Css
    End Sub

    Private Sub FortranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FortranToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Fortran
    End Sub

    Private Sub HTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTMLToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Html
    End Sub

    Private Sub JavaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JavaToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Java
    End Sub

    Private Sub JavaScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JavaScriptToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.JavaScript
    End Sub

    Private Sub LispToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LispToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Lisp
    End Sub

    Private Sub LuaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LuaToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Lua
    End Sub

    Private Sub PascalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PascalToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Pascal
    End Sub

    Private Sub PerlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerlToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Perl
    End Sub

    Private Sub PHPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PHPToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Php
    End Sub

    Private Sub PostgreSQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PostgreSQLToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Psql
    End Sub

    Private Sub PythonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PythonToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Python
    End Sub

    Private Sub RubyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RubyToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Ruby
    End Sub

    Private Sub SmalltalkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SmalltalkToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.SmallTalk
    End Sub

    Private Sub SQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Sql
    End Sub

    Private Sub VBScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VBScriptToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.VB
    End Sub

    Private Sub XMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMLToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Xml
    End Sub

    Private Sub YAMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YAMLToolStripMenuItem.Click
        TextBox1.Language = XDev.Editor.Language.EditorLanguage.Yaml
    End Sub

#End Region

#Region "Notes"

    Private Sub ToolStripSplitButton5_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton5.ButtonClick
        ShowNotes()
    End Sub

    Private Sub ToolStripSplitButton5_MouseHover(sender As Object, e As EventArgs) Handles ToolStripSplitButton5.MouseHover
        ShowNotes()
    End Sub

#End Region

#End Region

#Region "frmPresent"

    Private Sub frmPresent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TopmostToolStripMenuItem.Checked = Me.TopMost
        ZoomLevelToolStripMenuItem.Text = "Zoom Level: " + TextBox1.Zoom.ToString
        HideNotes()
    End Sub

#End Region

#Region "Context Menu"

#Region "Highlight Color"

    Private Sub UncheckColors()
        RedToolStripMenuItem.Checked = False
        YellowToolStripMenuItem.Checked = False
        OrangeToolStripMenuItem.Checked = False
        BlueToolStripMenuItem.Checked = False
        GreenToolStripMenuItem.Checked = False
        GrayToolStripMenuItem.Checked = False
    End Sub

    Private Sub RedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedToolStripMenuItem.Click
        hcolor = Color.Red
        UncheckColors()
        RedToolStripMenuItem.Checked = True
    End Sub

    Private Sub YellowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YellowToolStripMenuItem.Click
        hcolor = Color.Yellow
        UncheckColors()
        YellowToolStripMenuItem.Checked = True
    End Sub

    Private Sub OrangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrangeToolStripMenuItem.Click
        hcolor = Color.Orange
        UncheckColors()
        OrangeToolStripMenuItem.Checked = True
    End Sub

    Private Sub BlueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlueToolStripMenuItem.Click
        hcolor = Color.Blue
        UncheckColors()
        BlueToolStripMenuItem.Checked = True
    End Sub

    Private Sub GreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GreenToolStripMenuItem.Click
        hcolor = Color.Green
        UncheckColors()
        GreenToolStripMenuItem.Checked = True
    End Sub

    Private Sub GrayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrayToolStripMenuItem.Click
        hcolor = Color.Gray
        UncheckColors()
        GrayToolStripMenuItem.Checked = True
    End Sub

#End Region

    Private Sub HighlightSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HighlightSelectionToolStripMenuItem.Click
        TextBox1.HighlightPresentWords(hcolor)
    End Sub

    Private Sub ClearHighlightsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClearHighlightsToolStripMenuItem1.Click
        TextBox1.ClearPresentHighlightedWords()
    End Sub

#End Region

#Region "Panel Notes"

#Region "Context Menu"

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        txt_notes.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem4.Click
        txt_notes.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        txt_notes.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        txt_notes.SelectAll()
    End Sub

    Private Sub ClearToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem2.Click
        txt_notes.Clear()
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        Dim newb As New FontDialog
        newb.Font = txt_notes.Font
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_notes.Font = newb.Font
        End If
    End Sub

    Private Sub BackcolorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackcolorToolStripMenuItem.Click
        Dim newb As New ColorDialog
        newb.Color = txt_notes.BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_notes.BackColor = newb.Color
        End If
    End Sub

    Private Sub ForecolorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForecolorToolStripMenuItem.Click
        Dim newb As New ColorDialog
        newb.Color = txt_notes.ForeColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_notes.ForeColor = newb.Color
        End If
    End Sub

#End Region

    Private Sub txt_notes_LostFocus(sender As Object, e As EventArgs) Handles txt_notes.LostFocus
        HideNotes()
    End Sub

    Private Sub Btn_CloseProjectExplorer_MouseClick(sender As Object, e As MouseEventArgs) Handles Btn_CloseProjectExplorer.MouseClick
        HideNotes()
    End Sub

    Private Sub pnl_notes_titlebar_MouseDown(sender As Object, e As MouseEventArgs) Handles pnl_notes_titlebar.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub

    Private Sub pnl_notes_titlebar_MouseMove(sender As Object, e As MouseEventArgs) Handles pnl_notes_titlebar.MouseMove
        If allowCoolMove = True Then
            pnl_notes.Location = New Point(pnl_notes.Location.X + e.X - myCoolPoint.X, pnl_notes.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub pnl_notes_titlebar_MouseUp(sender As Object, e As MouseEventArgs) Handles pnl_notes_titlebar.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "TextBox1"

    'Private Sub TextBox1_SelectionChanged(sender As Object, e As EventArgs) Handles TextBox1.SelectionChanged
    '    'Highlighter
    '    If highlightmode = True Then
    '        TextBox1.Indicators(1).Style = IndicatorStyle.RoundBox
    '        TextBox1.Indicators(1).Color = Color.Yellow
    '        Dim b As String = TextBox1.Selection.Text
    '        If b <> "" And b <> " " Then
    '            For Each r As Range In TextBox1.FindReplace.FindAll(b)
    '                If r.End = TextBox1.CurrentPos Or r.Start = TextBox1.CurrentPos Then
    '                    r.SetIndicator(1)
    '                    highlightlist.Add(r)
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    End If
    'End Sub

#End Region

End Class
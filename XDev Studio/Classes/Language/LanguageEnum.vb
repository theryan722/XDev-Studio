Imports XDev.Editor.Language

Friend Class LanguageEnum

    Public Shared Function ConvertReadableToEnum(ByVal lang As String) As EditorLanguage
        Select Case lang
            Case "Ada"
                Return EditorLanguage.Ada
            Case "Assembly"
                Return EditorLanguage.Assembly
            Case "Batch"
                Return EditorLanguage.Batch
            Case "csharp"
                Return EditorLanguage.Csharp
            Case "cplusplus"
                Return EditorLanguage.Cpp
            Case "CSS"
                Return EditorLanguage.Css
            Case "Fortran"
                Return EditorLanguage.Fortran
            Case "HTML"
                Return EditorLanguage.Html
            Case "Java"
                Return EditorLanguage.Java
            Case "JavaScript"
                Return EditorLanguage.JavaScript
            Case "Lisp"
                Return EditorLanguage.Lisp
            Case "Lua"
                Return EditorLanguage.Lua
            Case "Markdown"
                Return EditorLanguage.Markdown
            Case "Pascal"
                Return EditorLanguage.Pascal
            Case "Perl"
                Return EditorLanguage.Perl
            Case "PHP"
                Return EditorLanguage.Php
            Case "PostgreSQL"
                Return EditorLanguage.Psql
            Case "Python"
                Return EditorLanguage.Python
            Case "Ruby"
                Return EditorLanguage.Ruby
            Case "SmallTalk"
                Return EditorLanguage.SmallTalk
            Case "SQL"
                Return EditorLanguage.Sql
            Case "VB"
                Return EditorLanguage.VB
            Case "XML"
                Return EditorLanguage.Xml
            Case "YAML"
                Return EditorLanguage.Yaml
            Case "CustomLanguage"
                Return EditorLanguage.CustomLanguage
            Case "PlainText"
                Return EditorLanguage.PlainText
            Case Else
                Return EditorLanguage.PlainText
        End Select
    End Function

    Public Shared Function ConvertEnumToReadable(ByVal lang As EditorLanguage) As String
        Select Case lang
            Case EditorLanguage.Ada
                Return "Ada"
            Case EditorLanguage.Assembly
                Return "Assembly"
            Case EditorLanguage.Batch
                Return "Batchh"
            Case EditorLanguage.Csharp
                Return "csharp"
            Case EditorLanguage.Cpp
                Return "cplusplus"
            Case EditorLanguage.Css
                Return "CSS"
            Case EditorLanguage.Fortran
                Return "Fortran"
            Case EditorLanguage.Html
                Return "HTML"
            Case EditorLanguage.Java
                Return "Java"
            Case EditorLanguage.JavaScript
                Return "JavaScript"
            Case EditorLanguage.Lisp
                Return "Lisp"
            Case EditorLanguage.Lua
                Return "Lua"
            Case EditorLanguage.Markdown
                Return "Markdown"
            Case EditorLanguage.Pascal
                Return "Pascal"
            Case EditorLanguage.Perl
                Return "Perl"
            Case EditorLanguage.Php
                Return "PHP"
            Case EditorLanguage.Psql
                Return "PSQL"
            Case EditorLanguage.Python
                Return "Python"
            Case EditorLanguage.Ruby
                Return "Ruby"
            Case EditorLanguage.SmallTalk
                Return "SmallTalk"
            Case EditorLanguage.Sql
                Return "SQL"
            Case EditorLanguage.VB
                Return "VB"
            Case EditorLanguage.Xml
                Return "XML"
            Case EditorLanguage.Yaml
                Return "YAML"
            Case EditorLanguage.CustomLanguage
                Return "CustomLanguage"
            Case EditorLanguage.PlainText
                Return "PlainText"
            Case Else
                Return "PlainText"
        End Select
    End Function

    Public Shared Function ConvertExtensionToEnum(ByVal ext As String) As EditorLanguage
        Select Case ext
            Case ".adb", ".a", ".ads", ".ada"
                Return EditorLanguage.Ada
            Case ".asm", ".s", ".S"
                Return EditorLanguage.Assembly
            Case ".bat", ".cmd", ".nt"
                Return EditorLanguage.Batch
            Case ".cs"
                Return EditorLanguage.Csharp
            Case ".cpp", ".cc", ".cxx", ".cp", ".c++", ".hpp", ".hxx"
                Return EditorLanguage.Cpp
            Case ".css"
                Return EditorLanguage.Css
            Case ".f", ".f90", ".f95", ".f03", ".for", ".F", ".F90", ".f2k"
                Return EditorLanguage.Fortran
            Case ".html", ".htm", ".xhtml", ".jhtml", ".shtml", ".shtm", ".hta"
                Return EditorLanguage.Html
            Case ".java", ".jsp", ".jspx"
                Return EditorLanguage.Java
            Case ".js"
                Return EditorLanguage.JavaScript
            Case ".lisp", ".cl", ".el", ".lsp"
                Return EditorLanguage.Lisp
            Case ".lua"
                Return EditorLanguage.Lua
            Case ".md", ".markdown", ".mdown", ".mkdn", ".mkd", ".mdwn", ".mdtxt", ".mdtext"
                Return EditorLanguage.Markdown
            Case ".pas", ".pp", ".pascal", ".inc"
                Return EditorLanguage.Pascal
            Case ".pl", ".pm", ".plx"
                Return EditorLanguage.Perl
            Case ".php", ".php4", ".php3", ".phtml"
                Return EditorLanguage.Php
            Case ".py", ".pyw"
                Return EditorLanguage.Python
            Case ".rb", ".rhtml", ".rbw"
                Return EditorLanguage.Ruby
            Case ".st"
                Return EditorLanguage.SmallTalk
            Case ".sql"
                Return EditorLanguage.Sql
            Case ".vb", ".vbs"
                Return EditorLanguage.VB
            Case ".xml", ".rss", ".svg", ".xsml", ".xsl", ".xsd", ".kml", ".wsdl", ".xlf", ".xliff"
                Return EditorLanguage.Xml
            Case ".yaml", ".yml"
                Return EditorLanguage.Yaml
            Case ".txt"
                Return EditorLanguage.PlainText
            Case Else
                Return EditorLanguage.PlainText
        End Select
    End Function

    Public Shared Function ConvertEnumToExtension(ByVal lang As EditorLanguage) As String
        Select Case lang
            Case EditorLanguage.Ada
                Return ".adb"
            Case EditorLanguage.Assembly
                Return ".asm"
            Case EditorLanguage.Batch
                Return ".bat"
            Case EditorLanguage.Csharp
                Return ".cs"
            Case EditorLanguage.Cpp
                Return ".cpp"
            Case EditorLanguage.Css
                Return ".css"
            Case EditorLanguage.Fortran
                Return ".f"
            Case EditorLanguage.Html
                Return ".html"
            Case EditorLanguage.Java
                Return ".java"
            Case EditorLanguage.JavaScript
                Return ".js"
            Case EditorLanguage.Lisp
                Return ".lisp"
            Case EditorLanguage.Lua
                Return ".lua"
            Case EditorLanguage.Markdown
                Return ".md"
            Case EditorLanguage.Pascal
                Return ".pas"
            Case EditorLanguage.Perl
                Return ".pl"
            Case EditorLanguage.Php
                Return ".php"
            Case EditorLanguage.Psql
                Return ".sql"
            Case EditorLanguage.Python
                Return ".py"
            Case EditorLanguage.Ruby
                Return ".rb"
            Case EditorLanguage.SmallTalk
                Return ".st"
            Case EditorLanguage.Sql
                Return ".sql"
            Case EditorLanguage.VB
                Return ".vb"
            Case EditorLanguage.Xml
                Return ".xml"
            Case EditorLanguage.Yaml
                Return ".yaml"
            Case EditorLanguage.CustomLanguage
                Return ".txt"
            Case EditorLanguage.PlainText
                Return ".txt"
            Case Else
                Return ".txt"
        End Select
    End Function

    'Ada            .adb .a .ads .ada
    'Assembly       .asm .s .S
    'Batch          .bat .cmd .nt
    'csharp         .cs
    'cplusplus      .cpp .cc .cxx .cp .c++ .hpp .hxx
    'CSS            .css
    'Fortran        .f .f90 .f95 .f03 .for .F .F90 .f2k
    'HTML           .html .htm .xhtml .jhtml .shtml .shtm .hta
    'Java           .java .jsp .jspx
    'JavaScript     .js 
    'Lisp           .lisp .cl .el .lsp
    'Lua            .lua
    'Markdown       .md .markdown .mdown .mkdn .mkd .mdwn .mdtxt .mdtext
    'Pascal         .pas .pp .pascal .inc
    'Perl           .pl .pm .plx
    'PHP            .php .php4 .php3 .phtml
    'PostgreSQL     .sql
    'Python         .py .pyw
    'Ruby           .rb .rhtml .rbw
    'SmallTalk      .st
    'SQL            .sql
    'VB             .vb
    'XML            .xml .rss .svg .xsml .xsl .xsd .kml .wsdl .xlf .xliff
    'YAML           .yaml .yml
    'CustomLanguage 
    'PlainText      .txt

End Class

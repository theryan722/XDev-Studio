Imports XDev.Editor.Language

Public Class LanguageEnum

    ''' <summary>
    ''' Converts language name in string format to language enum
    ''' </summary>
    ''' <param name="lang"></param>
    ''' <returns>Enum of the language name</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Converts language enum to string equivalent
    ''' </summary>
    ''' <param name="lang"></param>
    ''' <returns>String equivalent of the language enum</returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertEnumToReadable(ByVal lang As EditorLanguage) As String
        Select Case lang
            Case EditorLanguage.Ada
                Return "Ada"
            Case EditorLanguage.Assembly
                Return "Assembly"
            Case EditorLanguage.Batch
                Return "Batch"
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

    ''' <summary>
    ''' Converts file extension to language enum
    ''' </summary>
    ''' <param name="ext"></param>
    ''' <returns>Language enum of file extension</returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertExtensionToEnum(ByVal ext As String) As EditorLanguage
        Select Case ext
            Case ".adb"
                Return EditorLanguage.Ada
            Case ".asm"
                Return EditorLanguage.Assembly
            Case ".bat"
                Return EditorLanguage.Batch
            Case ".cs"
                Return EditorLanguage.Csharp
            Case ".cpp"
                Return EditorLanguage.Cpp
            Case ".css"
                Return EditorLanguage.Css
            Case ".f"
                Return EditorLanguage.Fortran
            Case ".html"
                Return EditorLanguage.Html
            Case ".java"
                Return EditorLanguage.Java
            Case ".js"
                Return EditorLanguage.JavaScript
            Case ".lisp"
                Return EditorLanguage.Lisp
            Case ".lua"
                Return EditorLanguage.Lua
            Case ".pas"
                Return EditorLanguage.Pascal
            Case ".pl"
                Return EditorLanguage.Perl
            Case ".php"
                Return EditorLanguage.Php
            Case ".py"
                Return EditorLanguage.Python
            Case ".rb"
                Return EditorLanguage.Ruby
            Case ".st"
                Return EditorLanguage.SmallTalk
            Case ".sql"
                Return EditorLanguage.Sql
            Case ".vb"
                Return EditorLanguage.VB
            Case ".vbs"
                Return EditorLanguage.VB
            Case ".xml"
                Return EditorLanguage.Xml
            Case ".yaml"
                Return EditorLanguage.Yaml
            Case ".txt"
                Return EditorLanguage.PlainText
            Case Else
                Return EditorLanguage.PlainText
        End Select
    End Function

    ''' <summary>
    ''' Converts language enum to file extension
    ''' </summary>
    ''' <param name="lang"></param>
    ''' <returns>String file extension of language enum</returns>
    ''' <remarks></remarks>
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

    'Ada            .adb
    'Assembly       .asm
    'Batch          .bat    
    'csharp         .cs
    'cplusplus      .cpp
    'CSS            .css
    'Fortran        .f
    'HTML           .html
    'Java           .java
    'JavaScript     .js
    'Lisp           .lisp
    'Lua            .lua
    'Pascal         .pas
    'Perl           .pl
    'PHP            .php
    'PostgreSQL     .sql
    'Python         .py
    'Ruby           .rb
    'SmallTalk      .st
    'SQL            .sql
    'VB             .vb
    'XML            .xml
    'YAML           .yaml
    'CustomLanguage 
    'PlainText      .txt

End Class

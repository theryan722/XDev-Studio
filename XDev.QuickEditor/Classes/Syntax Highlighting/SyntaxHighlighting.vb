﻿Friend Class SyntaxHighlighting
    Private Shared _synthigh(87) As Color

    Public Shared Sub GenerateArray()
        Dim ret(87) As Color
        Dim xml = XDocument.Load(XDev.Path.Locator.GetDataPath & "\Editor\syntaxhighlighting.xml")
        ret(0) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DEFAULT>.Value)
        ret(1) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENT>.Value)
        ret(2) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENTBLOCK>.Value)
        ret(3) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENTLINE>.Value)
        ret(4) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENTLINEDOC>.Value)
        ret(5) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<NUMBER>.Value)
        ret(6) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<WORD>.Value)
        ret(7) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<WORD2>.Value)
        ret(8) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<WORD3>.Value)
        ret(9) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<STRING>.Value)
        ret(10) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CHARACTER>.Value)
        ret(11) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<VERBATIM>.Value)
        ret(12) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<STRINGEOL>.Value)
        ret(13) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CHARACTEREOL>.Value)
        ret(14) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<OPERATOR>.Value)
        ret(15) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<PREPROCESSOR>.Value)
        ret(16) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DELIMITER>.Value)
        ret(17) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<LABEL>.Value)
        ret(18) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ILLEGAL>.Value)
        ret(19) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<IDENTIFIER>.Value)
        ret(20) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CPUINSTRUCTION>.Value)
        ret(21) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<MATHINSTRUCTION>.Value)
        ret(22) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<EXTINSTRUCTION>.Value)
        ret(23) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<REGISTER>.Value)
        ret(24) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DIRECTIVE>.Value)
        ret(25) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DIRECTIVEOPERAND>.Value)
        ret(26) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<HIDE>.Value)
        ret(27) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<TRIPLE>.Value)
        ret(28) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<TRIPLEDOUBLE>.Value)
        ret(29) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CLASSNAME>.Value)
        ret(30) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DEFNAME>.Value)
        ret(31) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DECORATOR>.Value)
        ret(32) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<UUID>.Value)
        ret(33) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<REGEX>.Value)
        ret(34) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENTDOCKEYWORD>.Value)
        ret(35) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<COMMENTDOCKEYWORDERROR>.Value)
        ret(36) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<TAG>.Value)
        ret(37) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<TAGUNKNOWN>.Value)
        ret(38) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<PSEUDOCLASS>.Value)
        ret(39) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<UNKNOWNPSEUDOCLASS>.Value)
        ret(40) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<UNKNOWNIDENTIFIER>.Value)
        ret(41) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<VALUE>.Value)
        ret(42) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ID>.Value)
        ret(43) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<IMPORTANT>.Value)
        ret(44) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ATTRIBUTE>.Value)
        ret(45) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ATTRIBUTEUNKNOWN>.Value)
        ret(46) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ENTITY>.Value)
        ret(47) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CONTINUATION>.Value)
        ret(48) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DOUBLESTRING>.Value)
        ret(49) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<OTHER>.Value)
        ret(50) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<XMLSTART>.Value)
        ret(51) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<XMLEND>.Value)
        ret(52) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SCRIPT>.Value)
        ret(53) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ASP>.Value)
        ret(54) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ASPAT>.Value)
        ret(55) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<QUESTION>.Value)
        ret(56) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CDATA>.Value)
        ret(57) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<XCCOMMENT>.Value)
        ret(58) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SPECIAL>.Value)
        ret(59) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SYMBOL>.Value)
        ret(60) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<INSTRUCTIONWORD>.Value)
        ret(61) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SCALAR>.Value)
        ret(62) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ARRAY>.Value)
        ret(63) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<HASH>.Value)
        ret(64) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SYMBOLTABLE>.Value)
        ret(65) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<DATASECTION>.Value)
        ret(66) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<POD>.Value)
        ret(67) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<LONGQUOTE>.Value)
        ret(68) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<BACKTICKS>.Value)
        ret(69) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<PUNCTUATION>.Value)
        ret(70) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<VARIABLE>.Value)
        ret(71) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<GLOBAL>.Value)
        ret(72) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<MODULENAME>.Value)
        ret(73) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<INSTANCEVAR>.Value)
        ret(74) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<STDIN>.Value)
        ret(75) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<STDOUT>.Value)
        ret(76) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<STDERR>.Value)
        ret(77) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<WORDDEMOTED>.Value)
        ret(78) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<CLASSVAR>.Value)
        ret(79) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SPECSEL>.Value)
        ret(80) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<ASSIGN>.Value)
        ret(81) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<KWSEND>.Value)
        ret(82) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<RETURN>.Value)
        ret(83) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<NIL>.Value)
        ret(84) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<BINARY>.Value)
        ret(85) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SUPER>.Value)
        ret(86) = ColorConverter.ConvertStringToColor(xml.<XDevStudio_SyntaxHighlighting>.<SELF>.Value)
        _synthigh = ret
    End Sub

    Public Shared Function GetHighlightArray() As Color()
        Return _synthigh
    End Function
End Class

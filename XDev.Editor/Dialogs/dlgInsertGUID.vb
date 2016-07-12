﻿Imports System.Windows.Forms

Public Class dlgInsertGUID

    Private editor As XEditor

#Region "Methods"

    'Converts the selected item into its equivalent GUID
    Private Function ConvertItemToGUID(ByVal item As String) As String
        Dim ret As String = ""
        Select Case item
            Case "ASP.NET MVC 1"
                Return "{603C0E0B-DB56-11DC-BE95-000D561079B0}"
            Case "ASP.NET MVC 2"
                Return "{F85E285D-A4E0-4152-9332-AB1D724D3325}"
            Case "ASP.NET MVC 3"
                Return "{E53F8FEA-EAE0-44A6-8774-FFD645390401}"
            Case "ASP.NET MVC 4"
                Return "{E3E379DF-F4C6-4180-9B81-6769533ABE47}"
            Case "ASP.NET MVC 5"
                Return "{349C5851-65DF-11DA-9384-00065B846F21}"
            Case "C#"
                Return "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"
            Case "C++"
                Return "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}"
            Case "Database"
                Return "{A9ACE9BB-CECE-4E62-9AA4-C7E7C5BD2124}"
            Case "Database (other project types)"
                Return "{4F174C21-8C12-11D0-8340-0000F80270F8}"
            Case "Deployment Cab"
                Return "{3EA9E505-35AC-4774-B492-AD1749C4943A}"
            Case "Deployment Merge Module"
                Return "{06A35CCD-C46D-44D5-987B-CF40FF872267}"
            Case "Deployment Setup"
                Return "{978C614F-708E-4E1A-B201-565925725DBA}"
            Case "Deployment Smart Device Cab"
                Return "{AB322303-2255-48EF-A496-5904EB18DA55}"
            Case "Distributed System"
                Return "{F135691A-BF7E-435D-8960-F99683D2D49C}"
            Case "Dynamics 2012 AX C# in AOT"
                Return "{BF6F8E12-879D-49E7-ADF0-5503146B24B8}"
            Case "F#"
                Return "{F2A71F9B-5D33-465A-A702-920D77279786}"
            Case "J#"
                Return "{E6FDF86B-F3D1-11D4-8576-0002A516ECE8}"
            Case "Legacy (2003) Smart Device (C#)"
                Return "{20D4826A-C6FA-45DB-90F4-C717570B9F32}"
            Case "Legacy (2003) Smart Device (VB.NET)"
                Return "{CB4CE8C6-1BDB-4DC7-A4D3-65A1999772F8}"
            Case "Model-View-Controller v2 (MVC 2)"
                Return "{F85E285D-A4E0-4152-9332-AB1D724D3325}"
            Case "Model-View-Controller v3 (MVC 3)"
                Return "{E53F8FEA-EAE0-44A6-8774-FFD645390401}"
            Case "Model-View-Controller v4 (MVC 4)"
                Return "{E3E379DF-F4C6-4180-9B81-6769533ABE47}"
            Case "Model-View-Controller v5 (MVC 5)"
                Return "{349C5851-65DF-11DA-9384-00065B846F21}"
            Case "Mono for Android"
                Return "{EFBA0AD7-5A72-4C68-AF49-83D382785DCF}"
            Case "MonoTouch"
                Return "{6BC8ED88-2882-458C-8E55-DFD12B67127B}"
            Case "MonoTouch Binding"
                Return "{F5B4F3BC-B597-4E2B-B552-EF5D8A32436F}"
            Case "Portable Class Library"
                Return "{786C830F-07A1-408B-BD7F-6EE04809D6DB}"
            Case "SharePoint (C#)"
                Return "{593B0543-81F6-4436-BA1E-4747859CAAE2}"
            Case "SharePoint (VB.NET)"
                Return "{EC05E597-79D4-47f3-ADA0-324C4F7C7484}"
            Case "SharePoint Workflow"
                Return "{F8810EC1-6754-47FC-A15F-DFABD2E3FA90}"
            Case "Silverlight"
                Return "{A1591282-1198-4647-A2B1-27E5FF5F6F3B}"
            Case "Smart Device (C#)"
                Return "{4D628B5B-2FBC-4AA6-8C16-197242AEB884}"
            Case "Smart Device (VB.NET)"
                Return "{68B1623D-7FB9-47D8-8664-7ECEA3297D4F}"
            Case "Solution Folder"
                Return "{2150E333-8FDC-42A3-9474-1A3956D46DE8}"
            Case "Test"
                Return "{3AC096D0-A1C2-E12C-1390-A8335801FDAB}"
            Case "VB.NET"
                Return "{F184B08F-C81C-45F6-A57F-5ABD9991F28F}"
            Case "Visual Database Tools"
                Return "{C252FEB5-A946-4202-B1D4-9916A0590387}"
            Case "Visual Studio Tools for Applications (VSTA)"
                Return "{A860303F-1F3F-4691-B57E-529FC101A107}"
            Case "Visual Studio Tools for Office (VSTO)"
                Return "{BAA0C2D2-18E2-41B9-852F-F413020CAA33}"
            Case "Web Application"
                Return "{349C5851-65DF-11DA-9384-00065B846F21}"
            Case "Web Site"
                Return "{E24C65DC-7377-472B-9ABA-BC803B73C61A}"
            Case "Windows (C#)"
                Return "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"
            Case "Windows (VB.NET)"
                Return "{F184B08F-C81C-45F6-A57F-5ABD9991F28F}"
            Case "Windows (Visual C++)"
                Return "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}"
            Case "Windows Communication Foundation (WCF)"
                Return "{3D9AD99F-2412-4246-B90B-4EAA41C64699}"
            Case "Windows Phone 8/8.1 Blank/Hub/Webview App"
                Return "{76F1466A-8B6D-4E39-A767-685A06062A39}"
            Case "Windows Phone 8/8.1 App (C#)"
                Return "{C089C8C0-30E0-4E22-80C0-CE093F111A43}"
            Case "Windows Phone 8/8.1 App (VB.NET)"
                Return "{DB03555F-0C8B-43BE-9FF9-57896B3C5E56}"
            Case "Windows Presentation Foundation (WPF)"
                Return "{60DC8134-EBA5-43B8-BCC9-BB4BC16C2548}"
            Case "Windows Store (Metro) Apps & Components"
                Return "{BC8A1FFA-BEE3-4634-8014-F334798102B3}"
            Case "Workflow (C#)"
                Return "{14822709-B5A1-4724-98CA-57A101D1B079}"
            Case "Workflow (VB.NET)"
                Return "{D59BE175-2ED0-4C54-BE3D-CDAA9F3214C8}"
            Case "Workflow Foundation"
                Return "{32F31D43-81CC-4C15-9DE6-3FC5453562B6}"
            Case "Xamarin.Android"
                Return "{EFBA0AD7-5A72-4C68-AF49-83D382785DCF}"
            Case "Xamarin.iOS"
                Return "{6BC8ED88-2882-458C-8E55-DFD12B67127B}"
            Case "XNA (Windows)"
                Return "{6D335F3A-9D43-41b4-9D22-F6F17C4BE596}"
            Case "XNA (XBox)"
                Return "{2DF5C3F4-5A5F-47a9-8E94-23B4456F55E2}"
            Case "XNA (Zune)"
                Return "{D399B71A-8929-442a-A9AC-8BEC78BB2433}"
        End Select
        Return ret
    End Function

    Private Sub InsertSelectedSymbol()
        If ListBox1.SelectedIndex <> -1 Then
            editor.Scintilla1.InsertText(editor.Scintilla1.CurrentPosition, ConvertItemToGUID(ListBox1.SelectedItem))
            Me.Close()
        End If
    End Sub

#End Region

#Region "dlgInsertGUID"

    Public Sub New(ByRef ed As XEditor)
        InitializeComponent()
        editor = ed
    End Sub

    Private Sub dlgGUID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormPosition.CenterForm(Me, editor.ParentForm)
        Catch
        End Try
    End Sub

    'Set in the editor that the dialog is no longer being displayed
    Private Sub dlgInsertGUID_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        editor.insertguiddlgshowing = False
    End Sub

#End Region

#Region "ListBox1"

    Private Sub ListBox1_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            InsertSelectedSymbol()
        End If
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        InsertSelectedSymbol()
    End Sub

#End Region

End Class
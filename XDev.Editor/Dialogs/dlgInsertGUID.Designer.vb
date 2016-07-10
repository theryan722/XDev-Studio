<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgInsertGUID
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ListBox1.FormattingEnabled = true
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Items.AddRange(New Object() {"ASP.NET MVC 1", "ASP.NET MVC 2", "ASP.NET MVC 3", "ASP.NET MVC 4", "ASP.NET MVC 5", "C#", "C++", "Database", "Database (other project types)", "Deployment Cab", "Deployment Merge Module", "Deployment Setup", "Deployment Smart Device Cab", "Distributed System", "Dynamics 2012 AX C# in AOT", "F#", "J#", "Legacy (2003) Smart Device (C#)", "Legacy (2003) Smart Device (VB.NET)", "Model-View-Controller v2 (MVC 2)", "Model-View-Controller v3 (MVC 3)", "Model-View-Controller v4 (MVC 4)", "Model-View-Controller v5 (MVC 5)", "Mono for Android", "MonoTouch", "MonoTouch Binding", "Portable Class Library", "SharePoint (C#)", "SharePoint (VB.NET)", "SharePoint Workflow", "Silverlight", "Smart Device (C#)", "Smart Device (VB.NET)", "Solution Folder", "Test", "VB.NET", "Visual Database Tools", "Visual Studio Tools for Applications (VSTA)", "Visual Studio Tools for Office (VSTO)", "Web Application", "Web Site", "Windows (C#)", "Windows (VB.NET)", "Windows (Visual C++)", "Windows Communication Foundation (WCF)", "Windows Phone 8/8.1 Blank/Hub/Webview App", "Windows Phone 8/8.1 App (C#)", "Windows Phone 8/8.1 App (VB.NET)", "Windows Presentation Foundation (WPF)", "Windows Store (Metro) Apps & Components", "Workflow (C#)", "Workflow (VB.NET)", "Workflow Foundation", "Xamarin.Android", "Xamarin.iOS", "XNA (Windows)", "XNA (XBox)", "XNA (Zune)"})
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = true
        Me.ListBox1.Size = New System.Drawing.Size(234, 216)
        Me.ListBox1.TabIndex = 0
        '
        'dlgGUID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(234, 216)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "dlgGUID"
        Me.ShowInTaskbar = false
        Me.Text = "Insert GUID"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents ListBox1 As Windows.Forms.ListBox
End Class

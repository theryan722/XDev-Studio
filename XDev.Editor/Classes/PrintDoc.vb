Imports System.Drawing
Imports System.Drawing.Printing

Public Class PrintDoc : Inherits Printing.PrintDocument

#Region " Property Variables "
    ''' <summary>
    ''' Property variable for the Font the user wishes to use
    ''' </summary>
    ''' <remarks></remarks>
    Private _font As Font

    ''' <summary>
    ''' Property variable for the text to be printed
    ''' </summary>
    ''' <remarks></remarks>
    Private _text As String
#End Region

#Region " Class Properties "
    ''' <summary>
    ''' Property to hold the text that is to be printed
    ''' </summary>
    ''' <value></value>
    ''' <returns>A string</returns>
    ''' <remarks></remarks>
    Public Property TextToPrint() As String
        Get
            Return _text
        End Get
        Set(ByVal Value As String)
            _text = Value
        End Set
    End Property

    ''' <summary>
    ''' Property to hold the font the users wishes to use
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PrinterFont() As Font
        ' Allows the user to override the default font
        Get
            Return _font
        End Get
        Set(ByVal Value As Font)
            _font = Value
        End Set
    End Property
#End Region

#Region " Class Constructors "
    ''' <summary>
    ''' Empty constructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        'Set the file stream
        MyBase.New()
        'Instantiate out Text property to an empty string
        _text = String.Empty
    End Sub

    ''' <summary>
    ''' Constructor to initialize our printing object
    ''' and the text it's supposed to be printing
    ''' </summary>
    ''' <param name="str">Text that will be printed</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal str As String)
        'Set the file stream
        MyBase.New()
        'Set our Text property value
        _text = str
    End Sub
#End Region

#Region " OnBeginPrint "
    ''' <summary>
    ''' Override the default OnBeginPrint method of the PrintDocument Object
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnBeginPrint(ByVal e As Printing.PrintEventArgs)
        ' Run base code
        MyBase.OnBeginPrint(e)

        'Check to see if the user provided a font
        'if they didnt then we default to Times New Roman
        If _font Is Nothing Then
            'Create the font we need
            _font = New Font("Times New Roman", 10)
        End If
    End Sub
#End Region

#Region " OnPrintPage "
    ''' <summary>
    ''' Override the default OnPrintPage method of the PrintDocument
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks>This provides the print logic for our document</remarks>
    ''' 
    Protected Overrides Sub OnPrintPage(ByVal e As Printing.PrintPageEventArgs)
        ' Run base code
        MyBase.OnPrintPage(e)

        'Declare local variables needed
        Static curChar As Integer
        Dim printHeight As Integer
        Dim printWidth As Integer
        Dim leftMargin As Integer
        Dim rightMargin As Integer
        Dim lines As Int32
        Dim chars As Int32

        'Set print area size and margins
        With MyBase.DefaultPageSettings
            printHeight = .PaperSize.Height - .Margins.Top - .Margins.Bottom
            printWidth = .PaperSize.Width - .Margins.Left - .Margins.Right
            leftMargin = .Margins.Left 'X
            rightMargin = .Margins.Top   'Y
        End With

        'Check if the user selected to print in Landscape mode
        'if they did then we need to swap height/width parameters
        If MyBase.DefaultPageSettings.Landscape Then
            Dim tmp As Integer
            tmp = printHeight
            printHeight = printWidth
            printWidth = tmp
        End If

        'Now we need to determine the total number of lines
        'we're going to be printing
        Dim numLines As Int32 = CInt(printHeight / PrinterFont.Height)

        'Create a rectangle printing are for our document
        Dim printArea As New RectangleF(leftMargin, rightMargin, printWidth, printHeight)

        'Use the StringFormat class for the text layout of our document
        Dim format As New StringFormat(StringFormatFlags.LineLimit)

        'Fit as many characters as we can into the print area      

        e.Graphics.MeasureString(_text.Substring(curChar, _text.Length - curChar), PrinterFont, New SizeF(printWidth, printHeight), format, chars, lines)
        'Print the page
        e.Graphics.DrawString(_text.Substring(curChar, chars), PrinterFont, Brushes.Black, printArea, format)
        'Increase current char count
        curChar += chars

        'Detemine if there is more text to print, if
        'there is the tell the printer there is more coming
        If curChar < _text.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            curChar = 0
        End If

    End Sub
#End Region

#Region " RemoveZeros "
    ''' <summary>
    ''' Function to replace any zeros in the size to a 1
    ''' Zero's will mess up the printing area
    ''' </summary>
    ''' <param name="value">Value to check</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveZeros(ByVal value As Integer) As Integer
        'Check the value passed into the function,
        'if the value is a 0 (zero) then return a 1,
        'otherwise return the value passed in
        Select Case value
            Case 0
                Return 1
            Case Else
                Return value
        End Select
    End Function
#End Region

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgInsertSymbol
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
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Items.AddRange(New Object() {"☺", "☻", "♥", "♂", "♀", "♪", "♫", "©", "®", "™", "►", "◄", "■", "▲", "▼", "↨", "↑", "↓", "→", "←", "↔", "♥", "❤", "❥", "웃", "유", "♋", "☮", "✌", "☢", "☏", "☠", "✔", "☑", "♚", "✈", "☿", "✍", "✉", "☣", "☤", "✘", "☒", "♛", "ღ", "ツ", "☼", "☁", "❅", "♒", "✎", "✪", "✯", "☭", "➳", "✞", "°", "✿", "☃", "☂", "✄", "☯", "✡", "☪", "ϟ", "¿", "♦", "♣", "♠", "•", "◘", "☼", "⌂", "‰", "±", "¼", "½", "¾", "≡", "≈", "≥", "≤", "√", "ⁿ", "¹", "²", "³", "π", "°", "∞", "µ", "Σ", "∩", "ª", "º", "α", "ß", "Γ", "δ", "ε", "Θ", "τ", "Φ", "φ", "Ω", "¤", "£", "€", "¢", "¥", "₧", "ƒ", "¡", "¿", "‼", "░", "▒", "▓", "│", "┤", "╡", "╢", "╖", "╕", "╣", "║", "╗", "╝", "╜", "╛", "┐", "└", "┴", "┬", "├", "─", "┼", "╞", "╟", "╚", "╔", "╩", "╦", "╠", "═", "╬", "╧", "╨", "╤", "╥", "╙", "╘", "╒", "╓", "╫", "╪", "┘", "┌", "█", "▄", "▌", "▐", "▀", "…", "¯", "¨", "—", "▬", "⌠", "⌡", "·", "·", "¬", "∟", "§", "¶", "†", "‡", "«", "»", "‹", "›", "„", "ð", "Ñ", "æ", "ø", "Þ", "œ", "Å", "Ð", "ß", "ñ", "Æ", "Ø", "þ", "Œ", "å", "À", "Á", "Â", "Ã", "Ç", "È", "É", "Ê", "Ë", "Ì", "Í", "Ï", "Ï", "Ñ", "Ò", "Ó", "Ô", "Õ", "Ö", "Š", "Ú", "Û", "Ü", "Ù", "Ý", "Ÿ", "Ž", "à", "á", "â", "ã", "ä", "ç", "è", "é", "ê", "ë", "ì", "í", "î", "ï", "ñ", "ò", "ó", "ô", "õ", "ö", "š", "ú", "û", "ü", "ù", "ý", "ÿ", "ž"})
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(234, 216)
        Me.ListBox1.TabIndex = 0
        '
        'dlgInsertSymbol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(234, 216)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgInsertSymbol"
        Me.ShowInTaskbar = False
        Me.Text = "Insert Symbol"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class

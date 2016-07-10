Namespace MacroObjects
    ''These Classes log the KeyPress event on all controls on
    ''a form to a 'Macro' which can be replayed at anytime

    ''the macro-recorder
    ''this hooks up to a form and logs keyboard events
    ''and then return a Macro object
    Friend Class MacroRecorder
        Implements IDisposable
        Private running As Boolean
        Private currentMacro As Macro
        Public Sub New(ByRef frm As Form)

            Dim ctl As Control = frm.GetNextControl(frm, True) 'Get the first control in the tab order.
            Do Until ctl Is Nothing
                AddHandler ctl.KeyPress, AddressOf EventCatcherKeyPress
                ctl = frm.GetNextControl(ctl, True) 'Get the next control in the tab order.
            Loop
            'also add the form
            AddHandler frm.KeyPress, AddressOf EventCatcherKeyPress
        End Sub
        Public ReadOnly Property Recording() As Boolean
            Get
                Return running
            End Get
        End Property
        Public Sub BeginRecording()
            running = True
            currentMacro = New Macro 'start new macro
        End Sub
        Public Function StopRecording()
            running = False
            Return currentMacro 'return finished macro (dont forget to dispose it when you are done!)
        End Function
        Private Sub EventCatcherKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            'record keypress
            If running Then currentMacro.AddEvent(DirectCast(sender, Windows.Forms.Control).Name, e)
        End Sub

        Overridable Sub Dispose() Implements IDisposable.Dispose
            currentMacro.Dispose()
        End Sub
    End Class

    ''the resulted macro object
    ''this can play back recorded events
    <Serializable()> Friend Class Macro
        Implements IDisposable
        Private Events As ArrayList = New ArrayList
        Private running As Boolean
        <Serializable()> Private Structure FormEvent
            Dim control As String 'name of the control involved
            Dim Key As Char 'keypressed
        End Structure
        Public ReadOnly Property Playing() As Boolean
            Get
                Return running
            End Get
        End Property
        Public Sub AddEvent(ByVal ControlName As String, ByVal KEvents As System.Windows.Forms.KeyPressEventArgs)
            'used by the recorder
            Dim e As New FormEvent
            If Events.Count > 0 AndAlso DirectCast(Events(Events.Count - 1), FormEvent).control = ControlName Then
                e.control = "$[PREV]" 'use previous control
            Else
                e.control = ControlName
            End If
            e.Key = KEvents.KeyChar
            Events.Add(e)
        End Sub
        Public Sub PlayBack(ByRef frm As Form)
            'replay all the events in the array
            frm.Focus()
            running = True 'for the developers convinience
            Dim ctl As Control = Nothing
            For Each fe As FormEvent In Events
                If Not fe.control = "$[PREV]" Then
                    ctl = FindControl(frm, fe.control)
                End If
                ctl.Focus()
                SendKeys.SendWait(fe.Key)
            Next
            running = False
        End Sub
        Private Function FindControl(ByVal frm As Form, ByVal name As String) As Control
            'find control matching the given name
            Dim ctl As Control = frm.GetNextControl(frm, True) 'Get the first control in the tab order.
            Do Until ctl Is Nothing
                If ctl.Name = name Then Return ctl
                ctl = frm.GetNextControl(ctl, True) 'Get the next control in the tab order.
            Loop
            Return Nothing
        End Function
        Overridable Sub Dispose() Implements IDisposable.Dispose
            Events.Clear()
        End Sub
    End Class
End Namespace

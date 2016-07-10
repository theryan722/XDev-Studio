Imports WeifenLuo.WinFormsUI.Docking

Public Class XDockContent
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    Public Overloads Sub Show(dPanel As DockPanel, dState As DockState, floatWindowBounds As Rectangle)
        MyBase.Show(dPanel, dState)
        'shows the panel like normal
        'now for the part to initialize the float pane and size
        If DockHandler.FloatPane Is Nothing Then
            DockHandler.FloatPane = dPanel.DockPaneFactory.CreateDockPane(Me, DockState.Float, False)
            DockHandler.FloatPane.FloatWindow.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        End If
        DockHandler.FloatPane.FloatWindow.Bounds = floatWindowBounds
    End Sub

    Public Overloads Sub ShowPanel(dPanel As DockPanel, dState As DockState)
        MyBase.Show(dPanel, dState)
        'shows the panel like normal
        'now for the part to initialize the float pane and size
        If DockHandler.FloatPane Is Nothing Then
            DockHandler.FloatPane = DockPanel.DockPaneFactory.CreateDockPane(Me, DockState.Float, False)
            DockHandler.FloatPane.FloatWindow.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        End If
        DockHandler.FloatPane.FloatWindow.Bounds = New Rectangle(Me.Location, Me.Size)
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'XDockContent
        '
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "XDockContent"
        Me.ResumeLayout(False)

    End Sub

End Class

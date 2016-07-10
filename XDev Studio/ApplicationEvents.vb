Imports System.Collections.ObjectModel

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Protected Overrides Function Oninitialize(commandLineArgs As ReadOnlyCollection(Of String)) As Boolean
            If Not My.Settings.set_displaysplashscreen Then
                'Add a commandline argument to suppress the splash screen.
                commandLineArgs = New ReadOnlyCollection(Of String)(commandLineArgs.Concat({"/nosplash"}).ToArray())
            End If

            Return MyBase.OnInitialize(commandLineArgs)
        End Function

    End Class

End Namespace
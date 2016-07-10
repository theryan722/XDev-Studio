Friend Class CPUMonitor
    Private Shared CPU As New PerformanceCounter
    Private Shared Value As Byte

    Public Shared Function GetCPUUsage() As Integer
        CPU.CategoryName = "Processor"
        CPU.CounterName = "% Processor Time"
        CPU.InstanceName = "_Total"
        Value = CPU.NextValue()
        Return CInt(Value)
    End Function
End Class

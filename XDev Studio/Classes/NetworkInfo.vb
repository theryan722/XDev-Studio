Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.IO
Imports System.Management
Imports System.Management.ManagementObjectCollection
Imports System.Net
Imports System.Windows.Forms

Friend Class NetworkInfo

    Private Shared i As Integer
    Private Shared x As Integer
    Private Shared toCase As Integer
    Private Shared toBase As Integer = 10                  'Convert unit8, uint16 and unit32 to Base 10
    Private Shared dt As DateTime
    Private Shared str As String
    Private Shared myReader As StringReader

    Public Shared Function GetNetworkInfo() As String
        Dim b As String = ""
        Try
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", _
                "SELECT * FROM Win32_NetworkAdapterConfiguration")
            For Each queryObj As ManagementObject In searcher.Get()
                b += "Description: " & queryObj("Description") & vbCrLf & vbCrLf

                If queryObj("ArpAlwaysSourceRoute") Then
                    b += "      ArpAlwaysSourceRoute" & vbTab & " = Yes" & vbCrLf
                Else
                    b += ("      ArpAlwaysSourceRoute" & vbTab & " = No" & vbCrLf)
                End If

                If queryObj("ArpUseEtherSNAP") Then
                    b += ("      ArpUseEtherSNAP" & vbTab & vbTab & " = Yes" & vbCrLf)
                Else
                    b += ("      ArpUseEtherSNAP" & vbTab & vbTab & " = No" & vbCrLf)
                End If

                If queryObj("Caption") Is Nothing Then
                    b += ("      Caption" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                Else
                    b += ("      Caption" & vbTab & vbTab & vbTab & " = " & _
                        queryObj("Caption") & vbCrLf)
                End If

                If queryObj("DatabasePath") Is Nothing Then
                    b += ("      DatabasePath" & vbTab & vbTab & " = " & vbCrLf)
                Else
                    b += ("      DatabasePath" & vbTab & vbTab & " = " & _
                        queryObj("DatabasePath") & vbCrLf)
                End If

                If queryObj("DeadGWDetectEnabled") Then
                    b += ("      DeadGWDetectEnabled" & vbTab & " = " & vbCrLf)
                Else
                    b += ("      DeadGWDetectEnabled" & vbTab & " = No" & vbCrLf)
                End If

                x = 0

                If queryObj("DefaultIPGateway") Is Nothing Then
                    b += ("      DefaultIPGateway" & vbTab & vbTab & " = " & vbCrLf)
                Else
                    i = 1
                    Dim arrDefaultIPGateway() As String
                    arrDefaultIPGateway = queryObj("DefaultIPGateway")
                    For Each arrValue As String In arrDefaultIPGateway
                        If i = 1 Then
                            i = 0
                            b += ("      DefaultIPGateway" & vbTab & vbTab & _
                                " = " & queryObj("DefaultIPGateway")(x) & vbCrLf)
                        Else
                            b += ("      " & vbTab & vbTab & vbTab & vbTab & " = " & _
                                queryObj("DefaultIPGateway")(x) & vbCrLf)
                        End If

                        x = x & 1
                    Next
                End If

                If queryObj("DefaultTOS") >= 0 Then
                    b += ("      DefaultTOS" & vbTab & vbTab & vbTab & " = " & _
                        Convert.ToString(queryObj("DefaultTOS"), toBase) & vbCrLf)
                Else
                    b += ("      DefaultTOS" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                End If

                If queryObj("DefaultTTL") >= 0 Then
                    b += ("      DefaultTTL" & vbTab & vbTab & vbTab & " = " & _
                        Convert.ToString(queryObj("DefaultTTL"), toBase) & vbCrLf)
                Else
                    b += ("      DefaultTTL" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                End If

                If queryObj("DHCPEnabled") Then
                    b += ("      DHCPEnabled" & vbTab & vbTab & " = Yes" & vbCrLf)

                    If queryObj("DHCPLeaseExpires") Is Nothing Then
                        b += ("      DHCPEnabled" & vbTab & vbTab & vbTab & _
                            " = Yes" & vbCrLf)
                    Else
                        dt = _
                        ManagementDateTimeConverter.ToDateTime(queryObj("DHCPLeaseExpires"))
                        b += ("      DHCPLeaseExpires" & vbTab & vbTab & " = " & _
                            dt & vbCrLf)
                    End If

                    If queryObj("DHCPLeaseObtained") Is Nothing Then
                        b += ("DHCPLeaseObtained" & vbTab & _
                            " = " & vbCrLf)
                    Else
                        dt = _
                        ManagementDateTimeConverter.ToDateTime(queryObj("DHCPLeaseObtained"))
                        b += ("      DHCPLeaseObtained" & vbTab & vbTab & " = " & _
                            dt & vbCrLf)
                    End If
                Else
                    b += ("      DHCPEnabled" & vbTab & vbTab & " = No" & vbCrLf)
                    b += ("      DHCPLeaseExpires" & vbTab & vbTab & " = " & vbCrLf)
                    b += ("      DHCPLeaseObtained" & vbTab & vbTab & " = " & vbCrLf)
                End If

                If queryObj("DNSDomain") Is Nothing Then
                    b += ("      DNSDomain" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                Else
                    b += ("      DNSDomain" & vbTab & vbTab & vbTab & " = " & _
                        queryObj("DNSDomain") & vbCrLf)
                End If

                x = 0

                If queryObj("DNSDomainSuffixSearchOrder") Is Nothing Then
                    b += ("      DNSDomainSuffixSearchOrder" & vbTab & " = " & vbCrLf)
                Else
                    i = 1
                    Dim arrDNSDomainSuffixSearchOrder() As String
                    arrDNSDomainSuffixSearchOrder = queryObj("DNSDomainSuffixSearchOrder")
                    For Each arrValue As String In arrDNSDomainSuffixSearchOrder
                        If i = 1 Then
                            i = 0
                            b += ("      DNSDomainSuffixSearchOrder" & _
                             vbTab & " = " & queryObj("DNSDomainSuffixSearchOrder")(x) & _
                              vbCrLf)
                        Else
                            b += (vbTab & vbTab & " = " & _
                             queryObj("DNSDomainSuffixSearchOrder")(x) & vbCrLf)
                        End If

                        x = x & 1
                    Next
                End If

                If queryObj("DNSEnabledForWINSResolution") Then
                    b += ("      DNSEnabledForWINSResolution" & " = Yes" & vbCrLf)
                Else
                    b += ("      DNSEnabledForWINSResolution" & " = No" & _
                        vbCrLf)
                End If

                If queryObj("DNSHostName") Is Nothing Then
                    b += ("      DNSHostName" & vbTab & vbTab & " = " & vbCrLf)
                Else
                    b += ("      DNSHostName" & vbTab & vbTab & " = " & _
                        queryObj("DNSHostName") & vbCrLf)
                End If

                x = 0

                'If queryObj("DNSServerSearchOrder") Is Nothing Then
                '    b += ("      DNSServerSearchOrder" & vbTab & " = " & vbCrLf)
                'Else
                '    i = 1
                '    Dim arrDNSServerSearchOrder() As String
                '    arrDNSServerSearchOrder = queryObj("DNSServerSearchOrder")
                '    For Each arrValue As String In arrDNSServerSearchOrder
                '        If i = 1 Then
                '            i = 0
                '            b += ("      DNSServerSearchOrder" & vbTab & " = " & _
                '                queryObj("DNSServerSearchOrder")(x) & vbCrLf)
                '        Else
                '            b += ("      " & vbTab & " = " & _
                '             queryObj("DNSServerSearchOrder")(x) & vbCrLf)
                '        End If

                '        x = x & 1
                '    Next
                'End If

                If queryObj("DomainDNSRegistrationEnabled") Then
                    b += ("      DomainDNSRegistrationEnabled" & " = " & vbCrLf)
                Else
                    b += ("      DomainDNSRegistrationEnabled" & " = No" & _
                        vbCrLf)
                End If

                If queryObj("ForwardBufferMemory") >= 0 Then
                    b += ("      ForwardBufferMemory" & vbTab & _
                        " = " & Convert.ToString(queryObj("ForwardBufferMemory"), toBase) & vbCrLf)
                Else
                    b += ("      ForwardBufferMemory" & vbTab & " = " & vbCrLf)
                End If

                If queryObj("FullDNSRegistrationEnabled") Then
                    b += ("      FullDNSRegistrationEnabled" & vbTab & " = Yes" & _
                        vbCrLf)
                Else
                    b += ("      FullDNSRegistrationEnabled" & vbTab & " = No" & vbCrLf)
                End If

                x = 0

                If queryObj("GatewayCostMetric") Is Nothing Then
                    b += ("      GatewayCostMetric" & vbTab & vbTab & " = " & vbCrLf)
                Else
                    i = 1
                    Dim arrGatewayCostMetric() As UInt16
                    arrGatewayCostMetric = queryObj("GatewayCostMetric")
                    For Each arrValue As Integer In arrGatewayCostMetric
                        If i = 1 Then
                            i = 0
                            b += ("      GatewayCostMetric" & vbTab & vbTab & " = " & _
                                Convert.ToString(queryObj("GatewayCostMetric")(x), toBase) & vbCrLf)
                        Else
                            b += ("      GatewayCostMetric" & vbTab & vbTab & vbTab & _
                                " = " & Convert.ToString(queryObj("GatewayCostMetric")(x), toBase) & vbCrLf)
                        End If

                        x = x & 1
                    Next arrValue
                End If

                If queryObj("IGMPLevel") Is Nothing Then
                    b += ("      IGMPLevel" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                Else
                    toCase = Convert.ToString(queryObj("GMPLevel"), toBase)
                    Select Case toCase
                        Case 0
                            b += ("      IGMPLevel" & vbTab & vbTab & vbTab & _
                             " = No Multicast" & vbCrLf)

                        Case 1
                            b += ("      IGMPLevel" & vbTab & vbTab & vbTab & _
                             " = IP Multicast" & vbCrLf)

                        Case 2
                            b += ("      IGMPLevel" & vbTab & vbTab & vbTab & _
                            " = IP and IGMP Multicast (default)" & vbCrLf)
                    End Select
                End If

                If queryObj("Index") >= 0 Then
                    b += ("      Index" & vbTab & vbTab & vbTab & " = " & _
                        Convert.ToString(queryObj("Index"), toBase) & vbCrLf)
                Else
                    b += ("      Index" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                End If

                If queryObj("InterfaceIndex") >= 0 Then
                    b += ("      InterfaceIndex" & vbTab & vbTab & " = " & _
                        Convert.ToString(queryObj("InterfaceIndex"), toBase) & vbCrLf)
                Else
                    b += ("      InterfaceIndex" & vbTab & vbTab & " = " & vbCrLf)
                End If

                x = 0

                'If queryObj("IPAddress") Is Nothing Then
                '    b += ("      IPAddress" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                'Else
                '    i = 1
                '    Dim arrIPAddress() As String
                '    arrIPAddress = queryObj("IPAddress")
                '    For Each arrValue As String In arrIPAddress
                '        If i = 1 Then
                '            i = 0
                '            b += ("      IPAddress" & _
                '             vbTab & vbTab & vbTab & " = " & queryObj("IPAddress")(x) & vbCrLf)
                '        Else
                '            b += (vbTab & vbTab & vbTab & vbTab & " = " & _
                '                queryObj("IPAddress")(x) & vbCrLf)
                '        End If

                '        x = x & 1
                '    Next
                'End If

                If queryObj("IPConnectionMetric") >= 0 Then
                    b += ("      IPConnectionMetric" & vbTab & vbTab & " = " & _
                        Convert.ToString(queryObj("IPConnectionMetric"), toBase) & vbCrLf)
                Else
                    b += ("      IPConnectionMetric" & vbTab & vbTab & " = " & vbCrLf)
                End If

                If queryObj("IPEnabled") Then
                    b += ("      IPEnabled" & vbTab & vbTab & vbTab & " = Yes" & vbCrLf)
                Else
                    b += ("      IPEnabled" & vbTab & vbTab & vbTab & " = No" & vbCrLf)
                End If

                If queryObj("IPFilterSecurityEnabled") Then
                    b += ("      IPFilterSecurityEnabled" & vbTab & " = Yes" & vbCrLf)
                Else
                    b += ("      IPFilterSecurityEnabled" & vbTab & " = No" & vbCrLf)
                End If

                If queryObj("IPPortSecurityEnabled") Then
                    b += ("      IPPortSecurityEnabled" & vbTab & vbTab & _
                        " = Yes" & vbCrLf)
                    x = 0

                    If queryObj("IPSecPermitIPProtocols") Is Nothing Then
                        b += ("      IPSecPermitIPProtocols" & vbTab & vbTab & _
                            " = " & vbCrLf)
                    Else
                        i = 1
                        Dim arrIPSecPermitIPProtocols() As String
                        arrIPSecPermitIPProtocols = queryObj("IPSecPermitIPProtocols")
                        For Each arrValue As String In arrIPSecPermitIPProtocols
                            If i = 1 Then
                                i = 0
                                b += ("      IPSecPermitIPProtocols" & vbTab & _
                                    vbTab & " = " & queryObj("IPSecPermitIPProtocols")(x) & vbCrLf)
                            Else
                                b += (vbTab & vbTab & vbTab & " = " & _
                                    queryObj("IPSecPermitIPProtocols")(x) & vbCrLf)
                            End If

                            x = x & 1
                        Next
                    End If

                    x = 0

                    If queryObj("IPSecPermitTCPPorts") Is Nothing Then
                        b += ("      IPSecPermitTCPPorts" & vbTab & vbTab & _
                            " = " & vbCrLf)
                    Else
                        i = 1
                        Dim arrIPSecPermitTCPPorts() As String
                        arrIPSecPermitTCPPorts = queryObj("IPSecPermitTCPPorts")
                        For Each arrValue As String In arrIPSecPermitTCPPorts
                            If i = 1 Then
                                i = 0
                                b += ("      IPSecPermitTCPPorts" & vbTab & _
                                 vbTab & " = " & queryObj("IPSecPermitTCPPorts")(x) & vbCrLf)
                            Else
                                b += (vbTab & vbTab & vbTab & " = " & _
                                 queryObj("IPSecPermitTCPPorts")(x) & vbCrLf)
                            End If

                            x = x & 1
                        Next
                    End If

                    x = 0

                    If queryObj("IPSecPermitUDPPorts") Is Nothing Then
                        b += ("      IPSecPermitUDPPorts" & vbTab & vbTab & _
                            " = " & vbCrLf)
                    Else
                        i = 1
                        Dim arrIPSecPermitUDPPorts() As String
                        arrIPSecPermitUDPPorts = queryObj("IPSecPermitUDPPorts")
                        For Each arrValue As String In arrIPSecPermitUDPPorts
                            If i = 1 Then
                                i = 0
                                b += ("      IPSecPermitUDPPorts" & vbTab & _
                                 vbTab & " = " & queryObj("IPSecPermitUDPPorts")(x) & vbCrLf)
                            Else
                                b += (vbTab & vbTab & vbTab & " = " & _
                                 queryObj("IPSecPermitUDPPorts")(x) & vbCrLf)
                            End If

                            x = x & 1
                        Next
                    End If
                Else
                    b += ("      IPPortSecurityEnabled" & vbTab & _
                        " = No" & vbCrLf)
                    b += ("      IPSecPermitTCPPorts" & vbTab & vbTab & " = " & vbCrLf)
                    b += ("      IPSecPermitTCPPorts" & vbTab & vbTab & " = " & vbCrLf)
                    b += ("      IPSecPermitUDPPorts" & vbTab & vbTab & " = " & vbCrLf)
                End If

                x = 0

                'If queryObj("IPSubnet") Is Nothing Then
                '    b += ("      IPSubnet" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                'Else
                '    i = 1
                '    Dim arrIPSubnet() As String
                '    arrIPSubnet = queryObj("IPSubnet")
                '    For Each arrValue As String In arrIPSubnet
                '        If i = 1 Then
                '            i = 0
                '            b += ("      IPSubnet" & vbTab & vbTab & vbTab & " = " & _
                '                queryObj("IPSubnet")(x) & vbCrLf)
                '        Else
                '            b += (vbTab & vbTab & vbTab & vbTab & " = " & _
                '                queryObj("IPSubnet")(x) & vbCrLf)
                '        End If

                '        x = x & 1
                '    Next
                'End If

                If queryObj("IPUseZeroBroadcast") Then
                    b += ("      IPUseZeroBroadcast" & vbTab & vbTab & " = Yes" & _
                        vbCrLf)
                Else
                    b += ("      IPUseZeroBroadcast" & vbTab & vbTab & " = No" & vbCrLf)
                End If

                If queryObj("KeepAliveInterval") >= 0 Then
                    b += ("      KeepAliveInterval" & vbTab & vbTab & " = " & _
                        Convert.ToString(queryObj("KeepAliveInterval"), toBase) & vbCrLf)
                Else
                    b += ("KeepAliveInterval" & vbTab & vbTab & " = " & vbCrLf)
                End If

                If queryObj("KeepAliveTime") >= 0 Then
                    b += ("      KeepAliveTime" & vbTab & vbTab & " = " & _
                        Convert.ToString(queryObj("KeepAliveTime"), toBase) & vbCrLf)
                Else
                    b += ("      KeepAliveTime" & vbTab & vbTab & " = " & vbCrLf)
                End If

                If queryObj("MACAddress") Is Nothing Then
                    b += ("      MACAddress" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                Else
                    b += ("      MACAddress" & vbTab & vbTab & vbTab & " = " & _
                     queryObj("MACAddress") & vbCrLf)
                End If

                If queryObj("MTU") >= 0 Then
                    b += ("      MTU" & vbTab & vbTab & vbTab & " = " & _
                        Convert.ToString(queryObj("MTU"), toBase) & vbCrLf)
                Else
                    b += ("      MTU" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                End If

                If queryObj("NumForwardPackets") >= 0 Then
                    b += ("      NumForwardPackets" & vbTab & vbTab & " = " & _
                        Convert.ToString(queryObj("NumForwardPackets"), toBase) & vbCrLf)
                Else
                    b += ("      NumForwardPackets" & vbTab & vbTab & " = " & vbCrLf)
                End If

                If queryObj("PMTUBHDetectEnabled") Then
                    b += ("      PMTUBHDetectEnabled" & vbTab & " = Yes" & vbCrLf)
                Else
                    b += ("      PMTUBHDetectEnabled" & vbTab & " = No" & vbCrLf)
                End If

                If queryObj("PMTUDiscoveryEnabled") Then
                    b += ("      PMTUDiscoveryEnabled" & vbTab & " = Yes" & vbCrLf)
                Else
                    b += ("      PMTUDiscoveryEnabled" & vbTab & " = No" & vbCrLf)
                End If

                If queryObj("ServiceName") Is Nothing Then
                    b += ("      ServiceName" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                Else
                    b += ("      ServiceName" & vbTab & vbTab & vbTab & " = " & _
                        queryObj("ServiceName") & vbCrLf)
                End If

                If queryObj("SettingID") Is Nothing Then
                    b += ("      SettingID" & vbTab & vbTab & vbTab & " = " & vbCrLf)
                Else
                    b += ("      SettingID" & vbTab & vbTab & vbTab & " = " & _
                        queryObj("SettingID") & vbCrLf)
                End If

                If queryObj("TcpipNetbiosOptions") Is Nothing Then
                    b += ("      TcpipNetbiosOptions" & vbTab & vbTab & " = " & vbCrLf)
                Else
                    toCase = Convert.ToString(queryObj("TcpipNetbiosOptions"), toBase)
                    Select Case queryObj("TcpipNetbiosOptions")
                        Case 0
                            b += ("      TcpipNetbiosOptions" & vbTab & vbTab & _
                                " = EnableNetbiosViaDhcp" & vbCrLf)

                        Case 1
                            b += ("      TcpipNetbiosOptions" & +vbTab & vbTab & _
                                " = EnableNetbios" & vbCrLf)

                        Case 2
                            b += ("      TcpipNetbiosOptions" & vbTab & vbTab & _
                                " = DisableNetbios" & vbCrLf)
                    End Select
                End If

                If queryObj("TcpMaxConnectRetransmissions") >= 0 Then
                    b += ("      TcpMaxConnectRetransmissions" & " = " & _
                        Convert.ToString(queryObj("TcpMaxConnectRetransmissions"), toBase) & vbCrLf)
                Else
                    b += ("      TcpMaxConnectRetransmissions" & " = " & vbCrLf)
                End If

                If queryObj("TcpMaxDataRetransmissions") >= 0 Then
                    b += ("      TcpMaxDataRetransmissions" & vbTab & " = " & _
                        Convert.ToString(queryObj("TcpMaxDataRetransmissions"), toBase) & vbCrLf)
                Else
                    b += ("      TcpMaxDataRetransmissions" & vbTab & " = " & vbCrLf)
                End If

                If queryObj("TcpNumConnections") >= 0 Then
                    b += ("      TcpNumConnections" & vbTab & vbTab & " = " & _
                        Convert.ToString(queryObj("TcpNumConnections"), toBase) & vbCrLf)
                Else
                    b += ("      TcpNumConnections" & vbTab & vbTab & " = " & vbCrLf)
                End If

                If queryObj("TcpUseRFC1122UrgentPointer") Then
                    b += ("      TcpUseRFC1122UrgentPointer" & vbTab & " = Yes" & _
                        vbCrLf)
                Else
                    b += ("      TcpUseRFC1122UrgentPointer" & vbTab & " = No" & _
                        vbCrLf)
                End If

                If queryObj("TcpWindowSize") >= 0 Then
                    b += ("      TcpWindowSize" & vbTab & vbTab & " = " & _
                        Convert.ToString(queryObj("TcpWindowSize"), toBase) & vbCrLf)
                Else
                    b += ("      TcpWindowSize" & vbTab & vbTab & " = " & vbCrLf)
                End If

                If queryObj("WINSEnableLMHostsLookup") Then
                    b += ("      WINSEnableLMHostsLookup" & vbTab & " = Yes" & vbCrLf)
                Else
                    b += ("      WINSEnableLMHostsLookup" & vbTab & " = No" & vbCrLf)
                End If

                If queryObj("WINSHostLookupFile") Is Nothing Then
                    b += ("      WINSHostLookupFile" & vbTab & vbTab & " = " & vbCrLf)
                Else
                    b += ("      WINSHostLookupFile" & vbTab & vbTab & " = " & _
                        queryObj("WINSHostLookupFile") & vbCrLf)
                End If

                If queryObj("WINSPrimaryServer") Is Nothing Then
                    b += ("      WINSPrimaryServer" & vbTab & vbTab & " = " & vbCrLf)
                Else
                    b += ("      WINSPrimaryServer" & vbTab & vbTab & " = " & _
                        queryObj("WINSPrimaryServer") & vbCrLf)
                End If

                If queryObj("WINSScopeID") Is Nothing Then
                    b += ("      WINSScopeID" & vbTab & vbTab & " = " & vbCrLf)
                Else
                    str = queryObj("WINSScopeID")
                    If str Is "" Then
                        b += ("      WINSScopeID" & vbTab & vbTab & " = " & vbCrLf)
                    Else
                        b += ("      WINSScopeID" & vbTab & vbTab & " = " & _
                            queryObj("WINSScopeID") & vbCrLf)
                    End If
                End If

                If queryObj("WINSSecondaryServer") Is Nothing Then
                    b += ("      WINSSecondaryServer" & vbTab & " = " & vbCrLf & vbCrLf)
                Else
                    b += ("      WINSSecondaryServer" & vbTab & " = " & _
                        queryObj("WINSSecondaryServer") & vbCrLf & vbCrLf)
                End If
            Next
            Return b
        Catch err As ManagementException
            Logger.Write(Logger.TypeOfLog.Studio, "ERROR: " & err.ToString)
            Return Nothing
        End Try
    End Function

End Class

'
'    Copyright © 2002, The KPD-Team
'    All rights reserved.
'    http://www.mentalis.org/

'  Redistribution and use in source and binary forms, with or without
'  modification, are permitted provided that the following conditions
'  are met:

'    - Redistributions of source code must retain the above copyright
'       notice, this list of conditions and the following disclaimer. 

'    - Neither the name of the KPD-Team, nor the names of its contributors
'       may be used to endorse or promote products derived from this
'       software without specific prior written permission. 

'  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
'  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
'  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
'  FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL
'  THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
'  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
'  (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
'  SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
'  HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
'  STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
'  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
'  OF THE POSSIBILITY OF SUCH DAMAGE.
'

Imports System
Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports Microsoft.VisualBasic


'/// <summary>
'/// Queries the appropriate whois server for a given domain name and returns the results.
'/// </summary>
Friend Class WhoisResolver
    '/// <summary>
    '/// Do not allow any instances of this class.
    '/// </summary>
    Private Sub New()
    End Sub
    '/// <summary>
    '/// Queries an appropriate whois server for the given domain name.
    '/// </summary>
    '/// <param name="domain">The domain name to retrieve the information of.</param>
    '/// <returns>A string that contains the whois information of the specified domain name.</returns>
    '/// <exception cref="ArgumentNullException"><c>domain</c> is null.</exception>
    '/// <exception cref="ArgumentException"><c>domain</c> is invalid.</exception>
    '/// <exception cref="SocketException">A network error occured.</exception>
    Public Shared Function Whois(ByVal domain As String) As String
        If domain Is Nothing Then Throw New ArgumentNullException()
        Dim ccStart As Integer = domain.LastIndexOf(".")
        If ccStart < 0 OrElse ccStart = domain.Length Then Throw New ArgumentException()
        Dim ret As String = ""
        Dim s As Socket = Nothing
        Try
            Dim cc As String = domain.Substring(ccStart + 1)
            s = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            s.Connect(New IPEndPoint(Dns.Resolve(cc + ".whois-servers.net").AddressList(0), 43))
            s.Send(Encoding.ASCII.GetBytes(domain + ControlChars.CrLf))
            Dim buffer(1023) As Byte
            Dim recv As Integer = s.Receive(buffer)
            While (recv > 0)
                ret += Encoding.ASCII.GetString(buffer, 0, recv)
                recv = s.Receive(buffer)
            End While
            s.Shutdown(SocketShutdown.Both)
        Catch
            Throw New SocketException()
        Finally
            If Not s Is Nothing Then s.Close()
        End Try
        Return ret
    End Function
End Class

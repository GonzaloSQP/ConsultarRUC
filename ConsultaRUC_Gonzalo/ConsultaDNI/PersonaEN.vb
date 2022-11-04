Imports System.Text
Imports Newtonsoft.Json
Public Class PersonaEN
    <JsonProperty(PropertyName:="razonSocial")>
    Public Property razonSocial As String
    Public Property direccion As String
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder()

        sb.AppendFormat($"{Me.razonSocial}")

        Return sb.ToString()

    End Function
End Class
Imports Newtonsoft.Json
Imports System.Diagnostics.Eventing.Reader
Imports System.Net
Public Class FrmConsulta
    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        Try
            If Trim(DNITextBox.Text) = "" Then
                ResultadoTextBox.Text = "EL CAMPO RUC NO PUEDE ESTAR VACIO"
                TextBox1.Text = "DEBE INGRESAR UN RUC"
            End If

            Dim RUC As String = Convert.ToString(DNITextBox.Text).Trim
            If IsNumeric(RUC) AndAlso RUC.Length = 11 Then

                Dim WebClient As New WebClient
                WebClient.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6Inlvc295ZmFiaWFuczJAZ21haWwuY29tIn0.7yw9kH83ugsWMcGIi6MB3NA2IjP132IhQMRKp3leOB4")
                Dim Data = WebClient.DownloadString($"https://dniruc.apisperu.com/api/v1/ruc/{RUC}")
                Dim objE = JsonConvert.DeserializeObject(Of PersonaEN)(Data)
                ResultadoTextBox.Text = objE.ToString
                Dim objE1 = JsonConvert.DeserializeObject(Of PersonaEN)(Data)
                TextBox1.Text = objE.direccion


                If objE.ToString = "" Then
                    ResultadoTextBox.Text = "NO ESTA EN LA BASE DE DATOS"
                End If


            Else

                If IsNumeric(RUC) AndAlso RUC.Length = 10 Then
                    ResultadoTextBox.Text = "Te falto 1 numero"
                End If
                If IsNumeric(RUC) AndAlso RUC.Length = 9 Then
                    ResultadoTextBox.Text = "Te faltaron 2 numeros"
                End If
                If IsNumeric(RUC) AndAlso RUC.Length = 8 Then
                    ResultadoTextBox.Text = "Te faltaron 3 numeros"
                End If
                If IsNumeric(RUC) AndAlso RUC.Length = 7 Then
                    ResultadoTextBox.Text = "Te faltaron 4 numeros"
                End If
                If IsNumeric(RUC) AndAlso RUC.Length = 6 Then
                    ResultadoTextBox.Text = "Te faltaron 5 numeros"
                End If
                If IsNumeric(RUC) AndAlso RUC.Length = 5 Then
                    ResultadoTextBox.Text = "Te faltaron 6 numeros"
                End If
                If IsNumeric(RUC) AndAlso RUC.Length = 4 Then
                    ResultadoTextBox.Text = "Te faltaron 7 numeros"
                End If
                If IsNumeric(RUC) AndAlso RUC.Length = 3 Then
                    ResultadoTextBox.Text = "Te faltaron 8 numeros"
                End If
                If IsNumeric(RUC) AndAlso RUC.Length = 2 Then
                    ResultadoTextBox.Text = "Te faltaron 9 numeros"
                End If
                If IsNumeric(RUC) AndAlso RUC.Length = 1 Then
                    ResultadoTextBox.Text = "Te faltaron 10 numeros"
                End If
            End If
        Catch ex As Exception
            ResultadoTextBox.Text = ""
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR 404")
        End Try
    End Sub



    Private Sub DNITextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DNITextBox.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class



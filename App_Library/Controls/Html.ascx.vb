Imports System.IO
Partial Class App_Library_Controls_html
    Inherits System.Web.UI.UserControl

    Dim _FilePath As String = ""

    Public Property FilePath() As String
        Get
            Return _FilePath
        End Get
        Set(ByVal Value As String)
            _FilePath = Value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If File.Exists(Server.MapPath(_FilePath)) Then

            Dim strFilePath As String = Server.MapPath(_FilePath)
            Dim objStreamReader As StreamReader

            Try
                objStreamReader = File.OpenText(strFilePath)
                litHTML.Text = objStreamReader.ReadToEnd
                objStreamReader.Close()
            Catch ex As Exception
                objStreamReader.Close()
            End Try
        End If
    End Sub
End Class

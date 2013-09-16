
Partial Class App_Library_Controls_ContactList
    Inherits System.Web.UI.UserControl

    Dim _FilePath As String

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

            Dim objConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CompassConnectionString").ConnectionString)
            Dim objDataTable As DataTable = New DataTable()

            For Each strUserName In FileToArray(Server.MapPath(_FilePath))
                Dim objCommand As New SqlCommand()
                objCommand.Connection = objConnection
                objCommand.CommandType = Data.CommandType.StoredProcedure
                objCommand.CommandText = "cmpGetOneUser"

                objCommand.Parameters.Add(New SqlParameter("@paraUserName", Data.SqlDbType.Char))
                objCommand.Parameters("@paraUserName").Value = strUserName

                Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(objCommand)
                sqlDataAdapter.Fill(objDataTable)
            Next
            rptContacts.DataSource = objDataTable
            rptContacts.DataBind()
        End If

    End Sub

    Function FileToArray(ByVal filePath As String) As String()
        Dim sr As System.IO.StreamReader
        Try
            sr = New System.IO.StreamReader(filePath)
            Return System.Text.RegularExpressions.Regex.Split(sr.ReadToEnd, "\r\n")
        Finally
            If Not sr Is Nothing Then sr.Close()
        End Try
    End Function

    ' ---------------------  Supporter Functions --------------------


    Public Function subWebDialer(ByVal strPrimaryPhone As Object, ByVal ofcExtensionPrefix As Object) As String
        If IsDBNull(ofcExtensionPrefix) Or IsDBNull(strPrimaryPhone) Then
            Return ""
        Else
            If IsDBNull(ofcExtensionPrefix) Then
                strPrimaryPhone = "91" & strPrimaryPhone
            Else
                strPrimaryPhone = ofcExtensionPrefix & Right(strPrimaryPhone, 4)
            End If
            Return "javascript:launchWebDialerServlet('" & strPrimaryPhone & "');"
        End If
    End Function
End Class

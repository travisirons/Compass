
Partial Class normal
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("UserFullName") = "" Then
            lblWelcomeMessage.Text = "Welcome " & Session("UserFullName")
        End If
		txtSearchTerm.focus()
    End Sub

    Protected Sub btnPeopleSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPeopleSearch.Click
        If txtSearchTerm.Text <> "" Then
            Response.Redirect("/_Sections/Directory/Search.aspx?q=" & txtSearchTerm.Text)
        End If
    End Sub

    Protected Sub btnWebSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnWebSearch.Click
        If txtSearchTerm.Text <> "" Then
            Response.Redirect("http://www.google.com/search?q=" & txtSearchTerm.Text)
        End If
    End Sub

    Protected Sub btnNoButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoButtonSearch.Click
        If txtSearchTerm.Text <> "" Then

            'imports System.Data
            'imports System.Data.SQLClient
            Dim objConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CompassConnectionString").ConnectionString)
            Dim objCommand As SqlCommand = New SqlCommand("proDirectorySearch", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            Dim objParameterSearch As New SqlParameter("@paraSearch", SqlDbType.VarChar)
            objCommand.Parameters.Add(objParameterSearch)
            objParameterSearch.Value = txtSearchTerm.Text

            objConnection.Open()
            Dim objReader As SqlDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                'Found a user, go to People Search
                Response.Redirect("/_Sections/Directory/Search.aspx?q=" & txtSearchTerm.Text)
            Else
                'No user found, go to google
                Response.Redirect("http://www.google.com/search?q=" & txtSearchTerm.Text)
            End If
        End If
    End Sub


End Class


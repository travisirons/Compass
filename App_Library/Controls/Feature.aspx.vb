Imports System.IO

Partial Class _Feature
    Inherits System.Web.UI.Page

    Const strFeatureFolder = "/_Source/Feature"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Load the repeater with filenames
        Dim dirInfo As New DirectoryInfo(Server.MapPath(strFeatureFolder))

        Repeater1.DataSource = dirInfo.GetFiles("_*.htm")
        Repeater1.DataBind()
    End Sub

    Protected Sub Repeater1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        Dim strPath As String
        Dim LitLoadedPage As Literal = CType(e.Item.FindControl("litLoadedPage"), Literal)
        Dim lblFileName As Label = CType(e.Item.FindControl("lblFileName"), Label)
        strPath = Server.MapPath(strFeatureFolder & "/" & lblFileName.Text)

        Dim reader As StreamReader = File.OpenText(strPath)
        Dim fileContents As String = reader.ReadToEnd
        LitLoadedPage.Text = fileContents
        reader.Close()
    End Sub
End Class

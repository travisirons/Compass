
Partial Class _Default
    Inherits System.Web.UI.Page

    Dim FolderPath As String = "/_Source/Photos/Home"
    Dim strImageFolder As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setup News Control
        Dim strPostKeyList As String

        'Set initial News Post Key String
        Dim strCommonKeys As String = "Compass,Leadership,Civil3DTips,CorpTech,Marketing"

        'Add particulars
        'Dim strRegionKeys As String = Session("UserRegion")
        Dim strOfficeKeys As String = Session("UserOffice")
        'Dim strDepartmentKeys As String = Session("UserDepartment")
        'If Session("UserDepartment") = "Information Technology" Then
        '    strDepartmentKeys = "CorpTech"
        'End If

        strPostKeyList = strCommonKeys & "," & strOfficeKeys

        News1.PostKeyList = strPostKeyList

        'Setup SlideShow
        Try
            Dim objFolders() As String = Directory.GetDirectories(Server.MapPath(FolderPath))
            strImageFolder = Path.GetFileName(objFolders(0))

            lblTitle.Text = strImageFolder
            Dim objImagesFolder As New DirectoryInfo(Server.MapPath(FolderPath & "/" & strImageFolder))
            rptSlideShow.DataSource = objImagesFolder.GetFiles("*.jpg")
            rptSlideShow.DataBind()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub rptSlideShow_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptSlideShow.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or _
            e.Item.ItemType = ListItemType.Item Then

            Dim tblItem As System.Web.UI.HtmlControls.HtmlAnchor = e.Item.FindControl("lnkID")

            If e.Item.ItemIndex = 0 Then
                tblItem.Attributes.Add("class", "show")
            End If
        End If
    End Sub

    Public Function formatImage(ByVal strName As String) As String
        formatImage = FolderPath & "/" & strImageFolder & "/" & strName
    End Function
End Class

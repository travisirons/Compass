
Partial Class _Library_Controls_TabStrip
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Get Section Path
            Dim strPath As String = Compass.Pathing.Section
            lblPageName.Text = Compass.Pathing.Folder
            If strPath = "~/_Sections/Home/" Or lblPageName.Text = "Null" Then
                pnlTabStrip.Visible = False
            Else
                Dim TabStripData As ArrayList = New ArrayList
                Dim objDirectoryInfo As New DirectoryInfo(Server.MapPath(strPath))
                Dim objFolders As DirectoryInfo() = objDirectoryInfo.GetDirectories

                'Get a list of Section Folders
                For Each objFolder As DirectoryInfo In objFolders
                    TabStripData.Add(objFolder.Name)
                Next

                lstTabs.DataSource = TabStripData
                lstTabs.DataBind()
            End If
        End If
    End Sub

    Public Function subFormatLink(ByVal strFolderName As String) As String

        Return Compass.Pathing.Section & strFolderName

    End Function
End Class
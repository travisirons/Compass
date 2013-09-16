Imports System.IO
Imports System.Data
Partial Class App_Library_Controls_LinkList
    Inherits System.Web.UI.UserControl

    Dim _FilePath As String = ""
    Dim _Title As String = "Links"

    Public Property FilePath() As String
        Get
            Return _FilePath
        End Get
        Set(ByVal Value As String)
            _FilePath = Value
        End Set
    End Property

    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal Value As String)
            _Title = Value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblTitle.Text = Title
        If File.Exists(Server.MapPath(_FilePath)) Then

            Dim strFilePath As String = Server.MapPath(_FilePath)
            Dim objStreamReader As StreamReader

            Dim LinkTable As DataTable = New DataTable("LinkTable")
            Dim colName As DataColumn = New DataColumn("Name", Type.GetType("System.String"))
            Dim colURL As DataColumn = New DataColumn("url", Type.GetType("System.String"))
            Dim colTarget As DataColumn = New DataColumn("Target", Type.GetType("System.String"))

            LinkTable.Columns.Add(colName)
            LinkTable.Columns.Add(colURL)
            LinkTable.Columns.Add(colTarget)

            Dim NewRow As DataRow

            Try
                objStreamReader = File.OpenText(strFilePath)
                While objStreamReader.Peek() <> -1
                    Dim arrString() As String = Split(objStreamReader.ReadLine(), ",")
                    NewRow = LinkTable.NewRow()
                    NewRow("Name") = arrString(0)
                    NewRow("URL") = arrString(1)
                    NewRow("Target") = arrString(2)
                    LinkTable.Rows.Add(NewRow)
                End While
                objStreamReader.Close()
                objStreamReader.Dispose()
                LinkTable.AcceptChanges()

            Catch ex As Exception
                objStreamReader.Close()
                objStreamReader.Dispose()
            End Try

            rptLinks.DataSource = LinkTable
            rptLinks.DataBind()
        End If
    End Sub
End Class

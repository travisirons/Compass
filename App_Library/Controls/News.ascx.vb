Imports System.Data
Imports System.Data.OleDb

Partial Class _Library_Controls_News
    Inherits System.Web.UI.UserControl

    Const QueryDateFormat As String = "dd-MMM-yyyy"
    Const BlogDatabase As String = "~/App_Data/Blog.mdb"
    Dim strPostKeyList As String = "any"
    Dim strBlogWidth As String = "500px"
    Dim strPostKeyLength As String = "100"
    Dim strPostID As String = ""
    Dim strPostMonth As String = ""

    Public Property BlogWidth() As String
        Get
            Return strBlogWidth
        End Get
        Set(ByVal Value As String)
            strBlogWidth = Value
        End Set
    End Property

    Public Property PostKeyList() As String
        Get
            Return strPostKeyList
        End Get
        Set(ByVal Value As String)
            strPostKeyList = Value
        End Set
    End Property

    Public Property PostKeyLength() As String
        Get
            Return strPostKeyLength
        End Get
        Set(ByVal Value As String)
            strPostKeyLength = Value
        End Set
    End Property

    Public Property PostID() As String
        Get
            Return strPostID
        End Get
        Set(ByVal Value As String)
            strPostID = Value
        End Set
    End Property

    Public Property PostMonth() As String
        Get
            Return strPostMonth
        End Get
        Set(ByVal Value As String)
            strPostMonth = Value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim arrPostKeyList() As String = strPostKeyList.Split(",")
        Dim strSQL As String = "SELECT TOP " & strPostKeyLength & " * FROM Posts WHERE (PostVisible=True) "
        If arrPostKeyList(0) = "any" Then
            strSQL = strSQL
        Else
            'add first postkey
            strSQL = strSQL & "AND ((PostKey='" & arrPostKeyList(0) & "')"
            'add any other postkeys
            If arrPostKeyList.Length > 1 Then
                For i As Integer = 1 To arrPostKeyList.Length - 1
                    strSQL = strSQL & " OR (PostKey='" & arrPostKeyList(i) & "')"
                Next
            End If
            If strPostID.Length > 1 Then
                strSQL = strSQL & " AND (PostID=" & strPostID & ")"
            End If
        End If
        ' work out postings by month
        If strPostMonth <> Nothing Then
            Dim datStart As Date = strPostMonth & "/1/" & DateTime.Now.Year
            ' check the year
            If datStart > DateTime.Now Then
                datStart = datStart.AddYears(-1)
            End If
            Dim datEnd As Date = datStart.AddMonths(1)
            strSQL = strSQL & ") AND PostDate >= #" & datStart.ToString & "# AND PostDate < #" & datEnd.ToString & "#"
        Else
            strSQL = strSQL & ") AND PostDate <= #" & DateTime.Now.ToString(QueryDateFormat) & " 11:59 pm#"
        End If
        'add sql closing
        strSQL = strSQL & " ORDER BY PostDate DESC"
        'Specify the SQL string
        Dim SQLString As String = strSQL
        Dim myOleDbConnection As OleDbConnection
        myOleDbConnection = New OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=" & Context.Server.MapPath(BlogDatabase))
        myOleDbConnection.Open()
        Dim myOleDbCommand As OleDbCommand = New OleDbCommand(SQLString, myOleDbConnection)
        Dim myOleDbDataReader As OleDbDataReader = myOleDbCommand.ExecuteReader(CommandBehavior.CloseConnection)

        PostsRepeater.DataSource = myOleDbDataReader
        PostsRepeater.DataBind()

        divBlog.Attributes.Add("style", "width: " & strBlogWidth & "; overflow: hidden; display: block;")

    End Sub
End Class

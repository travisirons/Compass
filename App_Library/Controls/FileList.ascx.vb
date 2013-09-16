Imports System.IO
Imports System.Data

Partial Class App_Library_Controls_FileList
    Inherits System.Web.UI.UserControl

    Dim _FolderPath As String = ""
    Dim _FolderRecursion As Boolean = True
    Dim _NameOnly As Boolean = False
    Dim _Sorted As Boolean = False
    Dim _Filter As String = "*.*"

    Public Property FolderPath() As String
        Get
            Return _FolderPath & "\"
        End Get
        Set(ByVal Value As String)
            _FolderPath = Value
        End Set
    End Property

    Public Property FolderRecursion() As Boolean
        Get
            Return _FolderRecursion
        End Get
        Set(ByVal Value As Boolean)
            _FolderRecursion = Value
        End Set
    End Property

    Public Property NameOnly() As Boolean
        Get
            Return _NameOnly
        End Get
        Set(ByVal Value As Boolean)
            _NameOnly = Value
        End Set
    End Property

    Public Property Sorted() As Boolean
        Get
            Return _Sorted
        End Get
        Set(ByVal Value As Boolean)
            _Sorted = Value
        End Set
    End Property

    Public Property Filter() As String
        Get
            Return _Filter
        End Get
        Set(ByVal Value As String)
            _Filter = Value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objSourceFolder As New DirectoryInfo(Server.MapPath(FolderPath))

            'Check for subfolder recusion
            If FolderRecursion = True Then
                'Bind to subfolder
                rptFolders.DataSource = objSourceFolder.GetDirectories
            Else
                'Bind to source folder
                Dim dt As DataTable = New DataTable("OneFolder")
                dt.Columns.Add("Name", GetType(System.String))
                dt.Rows.Add(objSourceFolder.Name)
                rptFolders.DataSource = dt
            End If
            rptFolders.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub rptFolders_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptFolders.ItemDataBound
        Dim item As RepeaterItem = e.Item

        If item.ItemType = ListItemType.Item Or item.ItemType = ListItemType.AlternatingItem Then
            Dim grdFileList As GridView = CType(item.FindControl("grdFileList"), GridView)
            Dim strSourceSubFolder As String
            If FolderRecursion = True Then
                strSourceSubFolder = FolderPath & CType(item.FindControl("lblFolderName"), Label).Text
            Else
                strSourceSubFolder = FolderPath
            End If

            Dim dirInfo As New DirectoryInfo(Server.MapPath(strSourceSubFolder))
            Dim files As New List(Of FileInfo)
            For Each File In dirInfo.GetFiles(_Filter)
                If File.Name <> "Thumbs.db" Then
                    files.Add(File)
                End If
            Next

            grdFileList.DataSource = files
            grdFileList.DataBind()
            If _NameOnly = True Then
                grdFileList.Columns(0).Visible = False
                grdFileList.Columns(2).Visible = False
                grdFileList.Columns(3).Visible = False
            End If
        End If
    End Sub

    ' Disabled to protect infopath files
    'Public Sub FileLink_Command(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
    '    'Used to download the requested file
    '    Response.AppendHeader("content-disposition", "attachment; filename=" & e.CommandArgument)
    '    Response.ContentType = "application/octet-stream"
    '    Response.WriteFile(e.CommandArgument)
    '    Response.Flush()
    '    Response.End()
    'End Sub

    Public Function fileFilter(ByRef strFilename As String) As Boolean
        strFilename = ""

        Dim reg As New Regex("^[a-zA-Z'.]{1,40}$")
        Response.Write(reg.IsMatch(strFilename))
        ' Static method:
        If Not Regex.IsMatch(strFilename, "^[a-zA-Z'.]{1,40}$") Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function formatFileSize(ByVal Bytes As Double) As String
        Dim dblAns As Double
        If Bytes < 1048576 Then
            dblAns = (Bytes / 1024)
            formatFileSize = Format(dblAns, "###,###,##0")
            Return formatFileSize & " kb"
        Else
            dblAns = (Bytes / 1024) / 1024
            formatFileSize = Format(dblAns, "###,###,##0.0")
            Return formatFileSize & " mb"
        End If
    End Function

    Public Function formatFileIcon(ByVal strExtension As String) As String
        Dim strPath As String = "/App_Library/Images/icn"
        strPath = strPath & strExtension.Replace(".", "") & ".png"
        If File.Exists(Server.MapPath(strPath)) Then
            Return strPath
        Else
            Return "/App_Library/Images/icnNone.png"
        End If

    End Function

    Function FormatLink(ByVal strFileName As String) As String
        Dim appPath As String = Server.MapPath(_FolderPath)
        Dim url As String = String.Format("~/{0}{1}", _FolderPath, strFileName.Replace(appPath, "").Replace("\", "/"))
        Return url
    End Function

    Function FormatName(ByVal strFileName As String) As String
        If _Sorted = True And _FolderRecursion = False Then
            FormatName = Right(strFileName, strFileName.Length - 3)
        Else
            FormatName = strFileName
        End If
    End Function
End Class

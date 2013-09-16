
Partial Class App_Library_Controls_PictureGallary
    Inherits System.Web.UI.UserControl

    Dim _Caption As Boolean = True
    Dim _ImagePath As String = ""
    Dim _RowCount As Integer = 4
    Dim _ImageWidth As Integer = 200
    Dim _ImageHeight As Integer = 150

    Public Property Caption() As Boolean
        Get
            Return _Caption
        End Get
        Set(ByVal Value As Boolean)
            _Caption = Value
        End Set
    End Property

    Public Property ImagePath() As String
        Get
            Return _ImagePath
        End Get
        Set(ByVal Value As String)
            _ImagePath = Value
        End Set
    End Property

    Public Property RowCount() As Integer
        Get
            Return _RowCount
        End Get
        Set(ByVal Value As Integer)
            _RowCount = Value
        End Set
    End Property

    Public Property ImageWidth() As Integer
        Get
            Return _ImageWidth
        End Get
        Set(ByVal Value As Integer)
            _ImageWidth = Value
        End Set
    End Property

    Public Property ImageHeight() As Integer
        Get
            Return _ImageHeight
        End Get
        Set(ByVal Value As Integer)
            _ImageHeight = Value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dlPictures.RepeatColumns = _RowCount

        Dim strSourcePath As String = _ImagePath
        Dim intMaxWidth As Integer = _ImageWidth
        Dim intMaxHeight As Integer = _ImageHeight

        Dim strImageURL As String
        Dim strCaption As String
        Dim intWidth As Integer
        Dim intHeight As Integer

        'Set up datatable
        Dim dt As DataTable = New DataTable("dtImages")
        dt.Columns.Add("ImageURL", GetType(System.String))
        dt.Columns.Add("Caption", GetType(System.String))
        dt.Columns.Add("ImageWidth", GetType(System.Int32))
        dt.Columns.Add("ImageHeight", GetType(System.Int32))

        For Each strImageName As String In Directory.GetFiles(Server.MapPath(strSourcePath), "*.jpg")
            Dim objFileStream As FileStream = File.OpenRead(strImageName)
            Dim objImage As Drawing.Image = Drawing.Image.FromStream(objFileStream)

            intWidth = objImage.Width
            intHeight = objImage.Height

            If (intWidth > intMaxWidth) OrElse (intHeight > intMaxHeight) Then
                Dim deltaWidth As Integer = intWidth - intMaxWidth
                Dim deltaHeight As Integer = intHeight - intMaxHeight
                Dim scaleFactor As Double

                If deltaHeight > deltaWidth Then
                    scaleFactor = Convert.ToDouble(intMaxHeight) / intHeight
                Else
                    scaleFactor = Convert.ToDouble(intMaxWidth) / intWidth
                End If

                intWidth = Convert.ToInt32(intWidth * scaleFactor)
                intHeight = Convert.ToInt32(intHeight * scaleFactor)
            End If

            'Bind to source folder
            strImageURL = strSourcePath & "\" & Path.GetFileName(strImageName)
            If _Caption = True Then
                strCaption = Path.GetFileNameWithoutExtension(strImageName)
            Else
                strCaption = ""
            End If
            dt.Rows.Add(strImageURL, strCaption, intWidth, intHeight)
        Next

        dlPictures.DataSource = dt
        dlPictures.DataBind()
    End Sub
End Class

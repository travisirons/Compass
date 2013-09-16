<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PictureGallary.ascx.vb"
    Inherits="App_Library_Controls_PictureGallary" %>

<link rel="stylesheet" href="/APP_Themes/Slimbox/slimbox2.css" type="text/css" media="screen" />
<script type="text/javascript" src="/App_Library/Scripts/jquery.min.js"></script>
<script type="text/javascript" src="/App_Library/Scripts/slimbox2.js"></script>

<asp:DataList runat="server" ID="dlPictures" ItemStyle-HorizontalAlign="Center" HorizontalAlign="Center"
    VerticalAlign="Middle">
    <ItemTemplate>
        <div class="gallaryimagebox">
            <a href='<%# eval("ImageURL") %>' rel="lightbox" title='<%# eval("Caption") %>'>
                <img src='<%# eval("ImageURL") %>' width='<%# eval("imageWidth") %>' height='<%# eval("imageHeight") %>' /></a><br />
            <asp:Label ID="txtCaption" CssClass="gallarycaptiontext" runat="server" Text='<%# eval("Caption") %>'></asp:Label>
        </div>
    </ItemTemplate>
</asp:DataList>
<%@ Page Title="" Language="VB" MasterPageFile="~/normal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Src="/App_Library/Controls/News.ascx" TagName="News" TagPrefix="uc1" %>
<%@ Register Src="/App_Library/Controls/LinkList.ascx" TagName="LinkList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="/App_Themes/slider.css" />
    <script type="text/javascript" src="/App_Library/Scripts/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            //Execute the slideShow  
            pictureShow();

        });

        function pictureShow() {

            //Set the opacity of all images to 0  
            $('#gallery a').css({ opacity: 0.0 });

            //Get the first image and display it (set it to full opacity)  
            $('#gallery a:first').css({ opacity: 1.0 });

            //Call the gallery function to run the slideshow, 6000 = change to next image after 6 seconds  
            setInterval('gallery()', 6000);

        }

        function gallery() {

            //if no IMGs have the show class, grab the first image  
            var current = ($('#gallery a.show') ? $('#gallery a.show') : $('#gallery a:first'));

            //Get next image, if it reached the end of the slideshow, rotate it back to the first image  
            var next = ((current.next().length) ? ((current.next().hasClass('caption')) ? $('#gallery a:first') : current.next()) : $('#gallery a:first'));

            //Set the fade in effect for the next image, show class has higher z-index  
            next.css({ opacity: 0.0 })
    .addClass('show')
    .animate({ opacity: 1.0 }, 1000);

            //Hide the current image  
            current.animate({ opacity: 0.0 }, 1000)
    .removeClass('show');
        }  
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="col-two">
        <div class="left">
            <div style="padding-bottom: 12px;">
                <asp:HyperLink ID="lnkTrueNorth" runat="server" NavigateUrl="/_Sections/Company" ImageUrl="/App_Library/Images/bannerTNgrn.png">True North</asp:HyperLink>
            </div>
            <div class="container">
                <uc1:News ID="News1" runat="server" BlogWidth="100%" PostKeyLength="5" />
            </div>
        </div>
        <div class="right">
            <div class="container toppad">
                <div id="gallery">
                    <asp:Repeater ID="rptSlideShow" runat="server">
                        <ItemTemplate>
                            <a id="lnkID" href="#" runat="server">
                                <img id="imgID" runat="server" alt="SlideShow" src='<%# formatImage(eval("name")) %>'
                                    title="" height="190" /></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div style="width: 100%; text-align: center; padding-bottom: 10px;">
                    <asp:Label ID="lblTitle" runat="server" CssClass="h2"></asp:Label>
                </div>
                <p><i>Do you want to see your team’s project showcased here or on our web site? Please email <a href="mailto:whp-corp-marketing@whpacific.com">whp-corp-marketing@whpacific.com</a> with your suggestions!</i></p>
            </div>
            <div class="container">
                <uc2:LinkList ID="LinkList1" runat="server" FilePath="/_Sections/Home/TaskForce/TaskForceList.txt"
                    Title="Task Force Pages" />
            </div>
            <div class="container">
                <uc2:LinkList ID="LinkList2" runat="server" FilePath="/_Source/Forms/MostRequestedFiles.txt"
                    Title="Most Requested Forms" />
                <div style="margin: 6px;">
                    <asp:HyperLink ID="lnkFormsPage" runat="server" CssClass="bold" NavigateUrl="/_Sections/Shared/Forms.aspx">More Forms >></asp:HyperLink></div>
            </div>
            <div class="container">
                <uc2:LinkList ID="LinkList3" runat="server" FilePath="/_Source/PopularPages.txt"
                    Title="Popular Pages" />
            </div>
        </div>
    </div>
</asp:Content>

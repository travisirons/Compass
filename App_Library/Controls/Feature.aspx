<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Feature.aspx.vb" Inherits="_Feature" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Feature</title>
    <style type="text/css">
        #slideshow
        {
            margin: 0px;
            width: 449px;
            height: 243px;
            background: transparent url(/App_Library/Images/Feature-bg.jpg) no-repeat 0 0;
            position: relative;
        }
        #slideshow #slidesContainer
        {
            margin: 0 auto;
            width: 449px;
            height: 243px;
            overflow: hidden; /* no scrollbar */
            position: relative;
        }
        #slideshow #slidesContainer .slide
        {
            margin: 0 auto;
            width: 429px; /* reduce by 20 pixels of #slidesContainer to avoid horizontal scroll */
            height: 243px;
        }
        
        /*** Slideshow controls style rules. ***/
        .control
        {
            display: block;
            width: 1px;
            height: 243px;
            text-indent: -10000px;
            position: absolute;
            cursor: pointer;
        }
        #leftControl
        {
            display: none;
        }
        #rightControl
        {
            display: none;
        }
        
        /*** Style rules for Page ***/
        *
        {
            margin: 0;
            padding: 0;
            font: normal 11px Verdana, Geneva, sans-serif;
            color: #ccc;
        }
                
        #slideIndex
        {
            left: 0px;
            bottom: 0px;
            width: 449px;
            height: 18px;
            position: absolute;
            text-align: center;
            background-image: url('../Images/bg60.png');
        }
        .numbers
        {
            background-position: center center;
            width: 12px;
            height: 20px;
            display: inline-block;
            color: #959595;
            cursor: pointer;
            font: normal 1px Arial;
            background-image: url('../Images/feature-dotoff.png');
            text-decoration: none;
            background-repeat: no-repeat;
            text-align: center;
            line-height: 14px;
        }
        .active
        {
            color: #ebebeb;
            background-image: url('../Images/feature-doton.png');
        }
        
    </style>
    <script type="text/javascript" src="/App_Library/Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/App_Library/Scripts/jquery.slide.js"></script>
    <script type="text/javascript">
        $().ready(function () {
            $('#slideshow').slide({ autoplay: true, duration: 5000, showSlideIndex: true });
        });
    </script>
</head>
<body bgcolor="Black">
    <form id="form1" runat="server">
    <!-- Slideshow HTML -->
    <div id="slideshow">
        <div id="slidesContainer">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="slide">
                        <asp:Label ID="lblFileName" runat="server" Text='<%# eval("name") %>' Visible="false"></asp:Label>
                        <asp:Literal ID="litLoadedPage" runat="server"></asp:Literal>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>

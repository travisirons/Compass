<%@ Control Language="VB" AutoEventWireup="false" CodeFile="News.ascx.vb" Inherits="_Library_Controls_News" %>
<style>
    .BlogEntryHeaderPostTitle
    {
        margin-top: 12px;
        font-family: 'Segoe UI';
        font-size: 20px;
        font-weight: normal;
        color: #666666;
    }
    .BlogEntryHeaderPostDate
    {
        margin-top: 6px;    
        font-family: 'Segoe UI';
        font-size: 11px;
    }
    .BlogEntryBody
    {
        border-bottom-style: solid;
        border-bottom-width: 1px;
        border-bottom-color: #666666;
        padding-bottom: 12px;
        margin-bottom: 24px;
        margin-top: 12px;
    }
</style>
<div id="divBlog" runat="server">
    <asp:Repeater ID="PostsRepeater" runat="server">
        <ItemTemplate>
            <div class="BlogEntry">
                <div class="BlogEntryHeader">
                    <div class="BlogEntryHeaderPostTitle">
                        <asp:Label ID="blgTitleLabel" runat="server" Text='<%# Eval("PostTitle") %>'></asp:Label>
                    </div>
                    <div class="BlogEntryHeaderPostDate">
                        <asp:Label ID="blgPostKey" runat="server" Text='<%# string.format("{0} - ", Eval("PostKey")) %>'></asp:Label>
                        <asp:Label ID="blgStartDateLabel" runat="server" Text='<%# Eval("PostDate") %>'></asp:Label>
                        <asp:Label ID="blgPostAuthor" runat="server" Text='<%# string.format("by {0}", Eval("PostAuthor")) %>'></asp:Label>
                    </div>
                </div>
                <div class="BlogEntryBody">
                    <asp:Label ID="ViewBodyLabel" runat="server" Text='<%# Eval("PostBody") %>'></asp:Label>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

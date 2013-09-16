<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FileList.ascx.vb" Inherits="App_Library_Controls_FileList" %>
<style>
    .filelistheader h2
    {
        margin-bottom: 4px;
        border-bottom: solid 1px #666666;
    }
</style>
<asp:Repeater ID="rptFolders" runat="server">
    <ItemTemplate>
        <div class="filelistheader">
            <h2>
                <asp:Label ID="lblFolderName" runat="server" Text='<%#eval("Name")%>'></asp:Label></h2>
        </div>
        <div style="margin-bottom: 6px;">
            <asp:GridView ID="grdFileList" runat="server" GridLines="None" AlternatingRowStyle-BackColor="#f8f8f9"
                AutoGenerateColumns="false" Width="100%" ShowHeader="false" >
                <Columns>
                    <asp:TemplateField ItemStyle-Width="24px" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:Image ID="imgIcon" runat="server" ImageUrl='<%# formatFileIcon(eval("Extension")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkFileLink" runat="server" Text='<%# formatName(eval("Name")) %>' NavigateURL='<%# formatLink(eval("FullName")) %>' />
                            <%-- Dissable to protect infopath files 
                            <asp:LinkButton ID="btnFileLink" runat="server" Text='<%# formatName(eval("Name")) %>'
                                CommandArgument='<%# formatLink(eval("FullName")) %>' />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle"
                        ItemStyle-Width="75px">
                        <ItemTemplate>
                            <asp:Label ID="lblFileSize" runat="server" Text='<%# formatFileSize(eval("Length")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="LastWriteTime" HeaderText="Last Modified" DataFormatString="{0:d}"
                        ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="75px" />
                </Columns>
            </asp:GridView>
        </div>
    </ItemTemplate>
</asp:Repeater>

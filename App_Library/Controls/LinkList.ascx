<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LinkList.ascx.vb" ClassName="LinkList" Inherits="App_Library_Controls_LinkList" %>
<style >
.titleheader h2
{
    margin-bottom: 4px;
    border-bottom: solid 1px #666666;
}</style>
        <div class="titleheader">
            <h2>
                <asp:Label ID="lblTitle" runat="server" /></h2>
        </div>
        <table width="100%" border="0" style="margin-bottom: 6px;">
    <asp:Repeater ID="rptLinks" runat="server">
        <ItemTemplate>
            <tr style="background-color: #FFFFFF">
                <td style="height:22px;padding-left: 7px">
                    <asp:HyperLink ID="lnkLink" runat="server" Text='<%# eval("Name") %>' NavigateUrl='<%# eval("URL") %>'
                        Target='<%# eval("Target") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #f8f8f9">
                <td style="height: 22px;padding-left: 7px">
                    <asp:HyperLink ID="lnkLink" runat="server" Text='<%# eval("Name") %>' NavigateUrl='<%# eval("URL") %>'
                        Target='<%# eval("Target") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
</table>

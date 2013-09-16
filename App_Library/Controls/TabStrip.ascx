<%@ Control Language="VB" AutoEventWireup="false" CodeFile="TabStrip.ascx.vb" Inherits="_Library_Controls_TabStrip" %>
<asp:Panel ID="pnlTabStrip" runat="server">
    <div class="col-one">
        <div class="middle">
            <div class="container" style="margin-bottom: 0px;">
                <table width="100%" border="0">
                    <tr>
                        <td class="top" style="width: 200px">
                            <asp:Label ID="lblPageName" CssClass="h2" runat="server" />
                        </td>
                        <td>
                            <asp:DataList ID="lstTabs" runat="server" RepeatColumns="6" Width="100%" RepeatDirection="Horizontal">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkFolder" runat="server" NavigateUrl="<%# subFormatLink(Container.DataItem) %>"
                                        Text="<%# Container.DataItem %>" />
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Panel>

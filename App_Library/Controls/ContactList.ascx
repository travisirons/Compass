<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ContactList.ascx.vb" ClassName="ContactList" Inherits="App_Library_Controls_ContactList" %>

<script language="javascript" type="text/javascript">
    function launchWebDialerWindow(url) {
        webdialer = window.open(url, "webdialer", "status=no,resizable=yes,scrollbars=no,width=320,height=280");
    }
    function launchWebDialerServlet(destination) {
        url = 'http://whp-pdx-ccm1/webdialer/Webdialer?destination=' + escape(destination) + '&amp;loc=' + 'English United States';
        launchWebDialerWindow(url);
    }
</script>

<style type="text/css">
.imagebox 
{
 margin: 4px;
 padding: 4px;
}
</style>


<div style="margin-bottom: 6px;">
    <asp:Repeater ID="rptContacts" runat="server">
        <ItemTemplate>
            <table>
                <tr>
                    <td width="1px">
                        <div class="imagebox">
                            <asp:Image ID="imgUser" runat="server" ImageUrl='<%# Compass.Common.subFormatPhoto(Eval("UserName")) %>'
                                Width="50px" /></div>
                    </td>
                    <td>
                        <asp:Label ID="lblName" runat="server" CssClass="h2" Text='<%# string.format("{0} {1}", Eval("FirstName"), Eval("LastName")) %>'></asp:Label><br />
                        <asp:Label ID="lblOffice" runat="server" CssClass="h3" Text='<%# string.format("{0} - {1}",  Eval("Title"), Eval("Office")) %>' ></asp:Label><br />
                        <asp:HyperLink ID="lnkPhone" runat="server" NavigateUrl='<%# subWebDialer(Eval("PrimaryPhone"), Eval("ExtensionPrefix")) %>' Text='<%# Compass.Common.subFormatPhoneNumber(Eval("PrimaryPhone")) %>' /><br />
                        <asp:HyperLink ID="lnkEmail" runat="server" NavigateUrl='<%# string.format("mailto:{0}", Eval("PrimaryEmail")) %>'
                            Text='<%# Eval("PrimaryEmail") %>'>
                        </asp:HyperLink>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <div class="underline">
            </div>
        </SeparatorTemplate>
    </asp:Repeater>
</div>

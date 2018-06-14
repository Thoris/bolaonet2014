<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigateHomeControl.ascx.cs" Inherits="BolaoNet.WebSite.Controls.MenuManager.NavigateHomeControl" %>
<table>
<tr>
    <td id="homeCell" runat="server" style="vertical-align: bottom; width: 50px; text-align: center;"><asp:LinkButton ID="lnkHome" runat="server" OnCommand="Button_Click" CssClass="linkedimgandtext"><img src="<%=ResolveUrl("~/images/house.png")%>"  alt="Home" style="border:none"/><br /><span>Home</span></asp:LinkButton></td>


</tr>
</table>
<br />
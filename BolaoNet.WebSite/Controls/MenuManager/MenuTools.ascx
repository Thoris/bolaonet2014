<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuTools.ascx.cs" Inherits="BolaoNet.WebSite.Controls.MenuManager.MenuTools" %>

<table>
    <tr>
        <td id="returnCell" runat="server" style="vertical-align: bottom; width: 50px; text-align: center;"><asp:LinkButton ID="lnkReturn" runat="server" OnCommand="Button_Click" CssClass="linkedimgandtext"><img src="<%=ResolveUrl("~/images/return.gif")%>"  alt="Return" style="border:none"/><br /><span>Return</span></asp:LinkButton></td>
        <td id="facebookCell" runat="server"  style="vertical-align:bottom;width:50px;text-align:center;"><asp:LinkButton ID="lnkSocialFac" runat="server" OnCommand="Button_Click" CssClass="linkedimgandtext"><img src="<%=ResolveUrl("~/images/socialFace.gif")%>"  alt="Face" style="border:none" /><br /><span>Publicar</span></asp:LinkButton></td>
        <td id="addNewCell" runat="server"  style="vertical-align:bottom;width:50px;text-align:center;"><asp:LinkButton ID="lnkAddNew" runat="server" OnCommand="Button_Click" CssClass="linkedimgandtext"><img src="<%=ResolveUrl("~/images/add.gif")%>"  alt="Add New" style="border:none" /><br /><span>Add New</span></asp:LinkButton></td>
        <td id="saveCell" runat="server"  style="vertical-align:bottom;width:50px;text-align:center;"><asp:LinkButton ID="lnkSave" runat="server" OnCommand="Button_Click" CssClass="linkedimgandtext"><img src="<%=ResolveUrl("~/images/save.gif")%>"  alt="Save" style="border:none" /><br /><span>Save</span></asp:LinkButton></td>
        <td id="deleteCell" runat="server"  style="vertical-align:bottom;width:50px;text-align:center;"><asp:LinkButton ID="lnkDelete" runat="server" OnCommand="Button_Click" CssClass="linkedimgandtext"><img src="<%=ResolveUrl("~/images/delete.gif")%>"  alt="Delete" style="border:none" /><br /><span>Delete</span></asp:LinkButton></td>
        <td id="nextCell" runat="server"  style="vertical-align:bottom;width:50px;text-align:center;"><asp:LinkButton ID="lnkNext" runat="server" OnCommand="Button_Click" CssClass="linkedimgandtext"><img src="<%=ResolveUrl("~/images/next.gif")%>"  alt="Next" style="border:none" /><br /><span>Next</span></asp:LinkButton></td>
    </tr>
</table>
<br />
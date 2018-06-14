<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="BolaoNet.WebSite.Users.EditProfile"  %>

<%@ Register src="../Controls/Views/UserInfo.ascx" tagname="UserInfo" tagprefix="uc1" %>

<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc4" %>



<%@ Register src="../Controls/MenuUserControl.ascx" tagname="MenuUserControl" tagprefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc2:MenuUserControl ID="MenuUserControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Editar profile</asp:Label>
            </td>
            <td class="adminTools">
                <uc4:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="False" 
                    SaveVisible="True" />
            </td>
            <td class="adminHome">
                <uc3:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <p />

   
        &nbsp;<uc1:UserInfo ID="ctlUserInfo" runat="server" />

   
    


    

</asp:Content>

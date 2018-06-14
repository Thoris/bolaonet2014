<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="BolaoNet.WebSite.Users.ChangePassword"  %>
<%@ Register src="../Controls/MenuUserControl.ascx" tagname="MenuUserControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuUserControl ID="MenuUserControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Alteração de Senha</asp:Label>
            </td>
            <td class="adminTools">
                <uc3:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="False" 
                    SaveVisible="False" />
            </td>
            <td class="adminHome">
                <uc4:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <br />
    <table style="width: 100%">
        <tr>
            <td align="center">
    <asp:ChangePassword ID="ctlChangePassword" runat="server"  
        style="text-align: center" CancelDestinationPageUrl="~/Users/Home.aspx" 
        ContinueDestinationPageUrl="~/Users/Home.aspx" EditProfileText="Editar perfil" 
        EditProfileUrl="~/Users/EditPerfil.aspx" PasswordRecoveryText="Recuperar senha" 
        PasswordRecoveryUrl="~/Visitante/PasswordRecovery.aspx">
    </asp:ChangePassword>
            </td>
        </tr>
    </table>
</asp:Content>

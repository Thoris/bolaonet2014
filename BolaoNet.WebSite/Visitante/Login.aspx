<%@Page Language="C#" ValidateRequest="false" MasterPageFile="~/Shared/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BolaoNet.WebSite.Visitante.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    <p style="text-align: center">
        <br />
        <table align="center">
            <tr>
                <td align="center" valign="middle">
        <asp:Login ID="loginUser" runat="server"
            CreateUserUrl="~/Visitante/RequestLogin.aspx" CreateUserText="Registrar-se" 
            PasswordRecoveryText="Esqueci a senha" 
            PasswordRecoveryUrl="~/Visitante/PasswordRecovery.aspx" 
            DestinationPageUrl="~/Users/Home.aspx" onloggedin="loginUser_LoggedIn" 
            onloggingin="loginUser_LoggingIn">
        </asp:Login>
                </td>
            </tr>
        </table>
    </p>
    <p>
    </p>
</asp:Content>
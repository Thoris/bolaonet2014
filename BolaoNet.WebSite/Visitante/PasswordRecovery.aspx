<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.master" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="BolaoNet.WebSite.Visitante.PasswordRecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    <br />
    <table align="center" style="width: 100%">
        <tr>
            <td align="center">
                <asp:PasswordRecovery ID="PasswordRecoveryUser" runat="server" 
                    onanswerlookuperror="PasswordRecoveryUser_AnswerLookupError" 
                    onsendingmail="PasswordRecoveryUser_SendingMail" 
                    onsendmailerror="PasswordRecoveryUser_SendMailError" 
                    onuserlookuperror="PasswordRecoveryUser_UserLookupError" 
                    onverifyinganswer="PasswordRecoveryUser_VerifyingAnswer" 
                    onverifyinguser="PasswordRecoveryUser_VerifyingUser" >
                </asp:PasswordRecovery>
            </td>
        </tr>
    </table>
</asp:Content>
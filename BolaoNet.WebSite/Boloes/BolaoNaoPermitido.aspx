<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoNaoPermitido.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.BolaoNaoPermitido"  %>

<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc1" %>

<%@ Register src="../Controls/MenuUserControl.ascx" tagname="MenuUserControl" tagprefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc2:MenuUserControl ID="MenuUserControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">

    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </td>
            <td class="adminTools">&nbsp;</td>        
            <td class="adminHome">
                <uc1:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
            <td align="center">
                <br />
                <asp:Label ID="lblMessage" runat="server" 
                    Text="Este módulo não está disponível no momento."></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblMessage2" runat="server" 
                    Text="Será habilitado depois que o bolão for iniciado."></asp:Label>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

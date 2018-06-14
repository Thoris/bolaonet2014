<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ApostasJogos.aspx.cs" Inherits="BolaoNet.WebSite.Apostas.ApostasJogos"  %>
<%@ Register src="../Controls/Filters/ListJogo.ascx" tagname="ListJogo" tagprefix="uc1" %>



<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>



<%@ Register src="../Controls/MenuApostasControl.ascx" tagname="MenuApostasControl" tagprefix="uc4" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc4:MenuApostasControl ID="MenuApostasControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Apostas dos jogos</asp:Label>
            </td>
            <td class="adminTools">
                <uc2:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HyperLink ID="lnkDownloaApostas" runat="server" Target="_blank">Download</asp:HyperLink>
            <uc1:ListJogo ID="ctlListJogo" runat="server" ModeList="Apostas" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <table cellspacing="1" style="width: 100%">
        <tr>
            <td align="center" valign="middle" width="100%">
    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Salvar" 
                    style="text-align: center" />
                <br />
                            
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

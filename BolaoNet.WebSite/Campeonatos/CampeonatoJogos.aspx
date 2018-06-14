<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CampeonatoJogos.aspx.cs" Inherits="BolaoNet.WebSite.Campeonatos.CampeonatoJogos"  %>
<%@ Register src="../Controls/Filters/ListJogo.ascx" tagname="ListJogo" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuCampeonatoControl.ascx" tagname="MenuCampeonatoControl" tagprefix="uc2" %>

<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc2:MenuCampeonatoControl ID="MenuCampeonatoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Jogos do Campeonato</asp:Label>
            </td>
            <td class="adminTools">
                <uc4:MenuTools ID="MenuTools1" runat="server" AddVisible="False" DeleteVisible="False" NextVisible="False" ReturnVisible="False" SaveVisible="False" />
            </td>
            <td class="adminHome">
                <uc3:NavigateHomeControl ID="NavigateHomeControl1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:UpdatePanel ID="UpdatePanelList" runat="server">
        <ContentTemplate>
            <uc1:ListJogo ID="ctlListJogo" runat="server" ModeList="All"  />
            <asp:HyperLink ID="hlkDownload" runat="server">Download</asp:HyperLink>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

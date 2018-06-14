<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CampeonatoCampeoes.aspx.cs" Inherits="BolaoNet.WebSite.Campeonatos.CampeonatoCampeoes"  %>

<%@ Register src="../Controls/MenuCampeonatoControl.ascx" tagname="MenuCampeonatoControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuCampeonatoControl ID="MenuCampeonatoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">

    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Campeões dos campeonatos</asp:Label>
            </td>
            <td class="adminTools">&nbsp;</td>
            <td class="adminHome">
                <uc1:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="grdHistorico" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Ano" HeaderText="Ano" />
            <asp:BoundField DataField="Sede" HeaderText="Sede" />
            <asp:BoundField DataField="NomeTimeCampeao" HeaderText="Campeão" />
            <asp:BoundField DataField="FinalTime1" HeaderText="Gols" />
            <asp:TemplateField></asp:TemplateField>
            <asp:BoundField DataField="FinalTime2" HeaderText="Gols" />
            <asp:BoundField DataField="NomeTimeVice" HeaderText="Vice" />
            <asp:BoundField DataField="FinalPenaltis1" HeaderText="Pen.1" />
            <asp:BoundField DataField="FinalPenaltis2" HeaderText="Pen.2" />
        </Columns>
    </asp:GridView>
</asp:Content>

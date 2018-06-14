<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.master" AutoEventWireup="true" CodeBehind="HomeApostas.aspx.cs" Inherits="BolaoNet.WebSite.Apostas.HomeApostas" %>

<%@ Register src="../Controls/MenuUserControl.ascx" tagname="MenuUserControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuApostasControl.ascx" tagname="MenuApostasControl" tagprefix="uc2" %>


<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" Runat="Server">
    <uc2:MenuApostasControl ID="MenuApostasControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" Runat="Server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Página principal de apostas</asp:Label>
            </td>
            <td class="adminTools">
                <uc2:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="False" 
                    SaveVisible="False" />
            </td>
            <td class="adminHome">
                <uc3:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    
    <asp:GridView ID="grdMeusBoloes" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Bolao" 
        onselectedindexchanging="grdMeusBoloes_SelectedIndexChanging" >
        <Columns>
            <asp:ImageField DataAlternateTextField="Bolao" 
                DataAlternateTextFormatString="{0}" DataImageUrlField="Bolao" 
                DataImageUrlFormatString="~/Images/Database/Boloes/{0}.gif" Visible="false">
            </asp:ImageField>
            <asp:HyperLinkField DataNavigateUrlFields="Bolao" 
                DataNavigateUrlFormatString="~/Boloes/BolaoClassificacao.aspx?Bolao={0}" 
                DataTextField="Bolao" HeaderText="Nome" />
            <asp:HyperLinkField DataNavigateUrlFields="Campeonato" 
                DataNavigateUrlFormatString="~/Campeonatos/CampeonatoClassificacao.aspx?Campeonato={0}" 
                DataTextField="Campeonato" HeaderText="Cobertura" />
            <asp:BoundField DataField="Membros" HeaderText="Membros" />
            <asp:BoundField DataField="Position" HeaderText="Posição" />
            <asp:HyperLinkField DataNavigateUrlFields="Bolao" 
                DataNavigateUrlFormatString="~/Apostas/ApostasJogos.aspx?Bolao={0}" 
                Text="&lt;img src=&quot;/Images/palpites.png&quot;&gt;" >
                <ItemStyle Width="5px" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
    
</asp:Content>
<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ApostasUsuarios.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.ApostasUsuarios" Title="Download "  %>
<%@ Register src="../Controls/Filters/ListJogo.ascx" tagname="ListJogo" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc2" %>

<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc2:MenuBolaoControl ID="MenuBolaoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Apostas dos usuários</asp:Label>
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
    <asp:UpdatePanel ID="UpdatePanelUsuario" runat="server">
        <ContentTemplate>
        

            <div class="data_section_header"><asp:Label ID="lblFiltro" runat="server" Text="Usuário"></asp:Label></div>
            <div class="data_section">         
        
                <table cellspacing="1" style="width: 100%">
                    <tr>
                        <td>
                            Usuário:
                            <asp:DropDownList ID="cboUsuarios" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="cboUsuarios_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Jogos do Usuário:
                            <asp:Label ID="lblUsuarioSelecionado" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            
                            <asp:HyperLink ID="lnkDownloaApostas" runat="server" Target="_blank">Download</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                
            </div>    
                
            <uc1:ListJogo ID="ctlListJogo" runat="server" ModeList="ApostasReadOnly" />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ApostasExtrasUsuarios.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.ApostasExtrasUsuarios"  %>
<%@ Register src="../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc1" %>

<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuBolaoControl ID="MenuBolaoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Apostas Extras dos Usuários</asp:Label>
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
                            Apostas do Usuário:
                            <asp:Label ID="lblUsuarioSelecionado" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                
            </div>    
                
            <asp:GridView ID="grdApostas" runat="server" AutoGenerateColumns="False" 
                EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="Posicao" HeaderText="Posição" Visible="False" />
                    <asp:BoundField DataField="Titulo" HeaderText="Título" />
                    <asp:ImageField DataAlternateTextField="NomeTime" 
                        DataAlternateTextFormatString="{0}" DataImageUrlField="NomeTime" 
                        DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                    </asp:ImageField>
                    <asp:BoundField DataField="NomeTime" HeaderText="Nome Time" />
                    <asp:BoundField DataField="NomeTimeValidado" HeaderText="Time Validado" />
                    <asp:BoundField DataField="Pontos" HeaderText="Pontos" />
                    <asp:BoundField DataField="DataAposta" HeaderText="Data Aposta">
                        <ItemStyle CssClass="jogoDataAposta" Font-Size="XX-Small" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
                
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

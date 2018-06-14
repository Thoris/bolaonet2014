<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ApostasExtrasPosicao.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.ApostasExtrasPosicao"  %>

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
                <asp:Label ID="lblTitle" runat="server">Apostas Extras dos Usuários por posição</asp:Label>
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

              
            <table class="style1">
                <tr>
                    <td width="100px">
                        Título:</td>
                    <td>
                        <asp:DropDownList ID="cboTitulo" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="cboTitulo_SelectedIndexChanged" Width="90%">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>

              
            <asp:GridView ID="grdExtras" runat="server" AutoGenerateColumns="False" 
                EnableModelValidation="True" ondatabound="grdExtras_DataBound">
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="Usuário" />
                    <asp:CheckBoxField DataField="IsValido" HeaderText="Válido" />
                    <asp:BoundField DataField="NomeTimeValidado" HeaderText="Time" />
                    <asp:ImageField DataAlternateTextField="NomeTime" 
                        DataAlternateTextFormatString="{0}" DataImageUrlField="NomeTime" 
                        DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                    </asp:ImageField>
                    <asp:BoundField DataField="NomeTime" HeaderText="Aposta" />
                    <asp:BoundField DataField="Pontos" HeaderText="Pontos">
                        <ItemStyle CssClass="jogoPontos" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DataAposta" HeaderText="Data Aposta">
                        <ItemStyle CssClass="jogoDataAposta" Font-Size="XX-Small" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="%" />
                </Columns>
            </asp:GridView>

              
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.master" AutoEventWireup="true" CodeBehind="JogosApostasExtras.aspx.cs" Inherits="BolaoNet.WebSite.Apostas.JogosApostasExtras" %>

<%@ Register src="../Controls/MenuApostasControl.ascx" tagname="MenuApostasControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" Runat="Server">
    <uc1:MenuApostasControl ID="MenuApostasControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" Runat="Server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Apostas Extras</asp:Label>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanelAuto" runat="server">
        <ContentTemplate>    
    
    
    <asp:GridView ID="grdApostas" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="grdApostas_RowDataBound">
        <Columns>
            <asp:BoundField DataField="NomeBolao" HeaderText="Bolão" Visible="False" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" Visible="False" />
            <asp:BoundField DataField="Posicao" HeaderText="Posição" Visible="False" />
            <asp:BoundField DataField="Titulo" HeaderText="Título" />
            <asp:BoundField DataField="NomeTimeValidado" HeaderText="Validado" />
            <asp:CheckBoxField DataField="IsValido" HeaderText="Válido" />
            <asp:TemplateField HeaderText="Aposta">
                <ItemTemplate>
                    <asp:Label ID="lblNomeTime" runat="server" Text='<%# Bind("NomeTime") %>'></asp:Label>
                    <asp:DropDownList ID="cboNomeTime" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="cboNomeTime_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Image ID="imgTime" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pontos">
                <ItemTemplate>
                    <asp:Label ID="lblPontos" runat="server" Text='<%# Bind("Pontos") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="jogoPontos" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Data Aposta">
                <ItemTemplate>
                    <asp:Label ID="lblDataAposta" runat="server" Text='<%# Bind("DataAposta") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="jogoDataAposta" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <br />
    <table cellspacing="1" class="style1">
        <tr>
            <td align="center">
    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Salvar" />
            </td>
        </tr>
    </table>
    
    
</asp:Content>
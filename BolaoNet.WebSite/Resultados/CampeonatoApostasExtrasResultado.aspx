<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CampeonatoApostasExtrasResultado.aspx.cs" Inherits="BolaoNet.WebSite.Resultados.CampeonatoApostasExtrasResultado" %>

<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuCampeonatoControl.ascx" tagname="MenuCampeonatoControl" tagprefix="uc4" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">

    <uc4:MenuCampeonatoControl ID="MenuCampeonatoControl1" runat="server" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">

    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Resultados de apostas extras</asp:Label>
            </td>
            <td class="adminTools">
                <uc2:MenuTools ID="ctlMenuTools" runat="server" DeleteVisible="False" 
                    NextVisible="False" ReturnVisible="True" SaveVisible="True" 
                    AddVisible="False" />
            </td>
            <td class="adminHome">
                <uc1:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <asp:UpdatePanel ID="UpdatePanelJogo" runat="server">
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
                            <asp:Label ID="lblNomeTime" runat="server" Text='<%# Bind("NomeTimeValidado") %>'></asp:Label>
                            <asp:DropDownList ID="cboNomeTime" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="cboNomeTime_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Image ID="imgTime" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    
            <br />
            <table class="style1">
                <tr>
                    <td align="center" valign="middle">
                        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
                    </td>
                </tr>
            </table>
    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

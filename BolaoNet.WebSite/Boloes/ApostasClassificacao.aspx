<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ApostasClassificacao.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.ApostasClassificacao"  %>

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
                <asp:Label ID="lblTitle" runat="server">Classificação das apostas</asp:Label>
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

    <div class="data_section_header"><asp:Label ID="lblFiltro" runat="server" Text="Filtro"></asp:Label></div>
    <div class="data_section">     
    
        <table style="width: 100%" width="100%">
            <tr>
                <td width="70px">
                    Usuário:</td>
                <td>
                    <asp:DropDownList ID="cboUsuarios" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    Fase:</td>
                <td width="70px">
                    <asp:DropDownList ID="cboFase" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    Grupo:</td>
                <td>
                    <asp:DropDownList ID="cboGrupo" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
    </div>
    
    <br />
    
    <asp:GridView ID="grdClassificacao" runat="server" AutoGenerateColumns="False" 
            onrowdatabound="grdClassificacao_RowDataBound" 
            ondatabound="grdClassificacao_DataBound">
        <Columns>
            <asp:BoundField DataField="Posicao" HeaderText="Pos" >
                <ItemStyle CssClass="classificacaoPosicao" />
            </asp:BoundField>
            <asp:ImageField DataAlternateTextField="Time" 
                DataAlternateTextFormatString="{0}" DataImageUrlField="Time" 
                DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
            </asp:ImageField>
            <asp:BoundField DataField="Time" HeaderText="Time" />
            <asp:BoundField DataField="Fase" HeaderText="Fase" Visible="False" />
            <asp:BoundField DataField="Grupo" HeaderText="Grupo" Visible="False" />
            <asp:BoundField DataField="TotalPontos" HeaderText="Pontos" >
                <ItemStyle CssClass="classificacaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="Jogos" HeaderText="J" >
                <ItemStyle CssClass="classificacaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalVitorias" HeaderText="V" >
                <ItemStyle CssClass="classificacaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalEmpates" HeaderText="E" >
                <ItemStyle CssClass="classificacaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalDerrotas" HeaderText="D" >
                <ItemStyle CssClass="classificacaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalGolsPro" HeaderText="GP" >
                <ItemStyle CssClass="classificacaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalGolsContra" HeaderText="GC" >
                <ItemStyle CssClass="classificacaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="Saldo" HeaderText="S" >
                <ItemStyle CssClass="classificacaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="Aproveitamento" HeaderText="%" />
        </Columns>
    </asp:GridView>
    <br />
    <span style="font-size: x-small">
    <b>Legenda<br />
    </b>J - Jogos, P - Pontos, V - Vitórias, E - Empates, D - Derrotas, GP - Gols Pró, 
        GC - Gols Contra, S - Saldo, % - Aproveitamento<br />
        <br />
        </span>
        <asp:DataList ID="dtlLegend" runat="server" Width="100%">
            <ItemTemplate>
               
                <table cellspacing="1" style="width: 100%">
                    <tr>
                        <td width="21px">
                            <asp:Panel ID="pnlLegend" runat="server" BackColor='<%# Bind("BackColor") %>' 
                                BorderColor="Black" BorderWidth="1px" Height="20px" Width="20px">                    
                            </asp:Panel></td>
                        <td>
                            <asp:Label ID="lblLegend" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <br style="font-size: xx-small" />
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

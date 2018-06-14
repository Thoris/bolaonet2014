<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoGraficoHistoricoClassificacao.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.BolaoGraficoHistoricoClassificacao"  %>

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
                <asp:Label ID="lblTitle" runat="server">Gráfico de Classificação do Bolão</asp:Label>
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
<asp:UpdatePanel ID="UpdatePanelTimes" runat="server">
    <ContentTemplate>


    <div class="data_section">     
    </div>


    <div class="data_section_header"><asp:Label ID="lblMenu" runat="server" Text="Selecione os usuários para visualizar o gráfico"></asp:Label></div>
    <div class="data_section">     
    
    
        <table style="width: 100%">
            <tr valign="top">
                <td width="70px">
                    Usuário:&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="cboUsuario" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="btnAdicionar" runat="server" onclick="btnAdicionar_Click" 
                        Text="Adicionar" />
                </td>
                <td width="10px">
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="grdUsuarios" runat="server" onrowcommand="grdUsuarios_RowCommand" 
                        onrowdeleting="grdUsuarios_RowDeleting">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    
    </div>
    

    <div class="data_section_header"><asp:Label ID="lblGrafico" runat="server" Text="Gráfico de posição dos Usuários nas rodadas"></asp:Label></div>
    <div class="data_section">         
    
        <asp:Chart ID="ctlChart" runat="server" Width="650px" Height="500px">
            <Legends>
                <asp:Legend Name="Legend1" Title="Legenda">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Name="Title1" Text="Posições dos Usuários nas rodadas">
                </asp:Title>
            </Titles>
            <Series>
                <asp:Series Name="Series1" ChartType="Line" IsValueShownAsLabel="True" 
                    Legend="Legend1" MarkerSize="1" XValueType="Int32" YValuesPerPoint="10" 
                    YValueType="Int32">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <Area3DStyle Enable3D="True" Inclination="20" LightStyle="Realistic" 
                        Rotation="20" />
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    
    
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CampeonatoGraficoRodadas.aspx.cs" Inherits="BolaoNet.WebSite.Campeonatos.CampeonatoGraficoRodadas"  %>


<%@ Register src="../Controls/MenuCampeonatoControl.ascx" tagname="MenuCampeonatoControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuCampeonatoControl ID="MenuCampeonatoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">

    
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Gráfico de times das rodadas</asp:Label>
            </td>
            <td class="adminTools">&nbsp;</td>
            <td class="adminHome">
                <uc1:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:UpdatePanel ID="UpdatePanelTimes" runat="server">
    <ContentTemplate>


    <div class="data_section_header"><asp:Label ID="lblFase" runat="server" Text="Selecione a fase e grupo"></asp:Label></div>
    <div class="data_section">     
        <table style="width: 100%" width="100%">
            <tr>
                <td width="70px">
                    Fase:</td>
                <td>
                    <asp:DropDownList ID="cboFase" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
                <td width="70px">
                    Grupo:</td>
                <td>
                    <asp:DropDownList ID="cboGrupo" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
            </tr>
        </table>
    </div>


    <div class="data_section_header"><asp:Label ID="lblMenu" runat="server" Text="Selecione os times para visualizar o gráfico"></asp:Label></div>
    <div class="data_section">     
    
    
        <table style="width: 100%">
            <tr valign="top">
                <td width="70px">
                    Time:&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="cboTime" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="btnAdicionar" runat="server" onclick="btnAdicionar_Click" 
                        Text="Adicionar" />
                </td>
                <td width="10px">
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="grdTimes" runat="server" onrowcommand="grdTimes_RowCommand" 
                        onrowdeleting="grdTimes_RowDeleting">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    
    </div>
    

    <div class="data_section_header"><asp:Label ID="lblGrafico" runat="server" Text="Gráfico de posição dos times nas rodadas"></asp:Label></div>
    <div class="data_section">         
    
        <asp:Chart ID="ctlChart" runat="server" Width="650px" Height="401px">
            <Legends>
                <asp:Legend Name="Legend1" Title="Legenda">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Name="Title1" Text="Posições dos times nas rodadas">
                </asp:Title>
            </Titles>
            <Series>
                <asp:Series Name="Series1" ChartType="Line" IsValueShownAsLabel="True" 
                    Legend="Legend1" CustomProperties="PixelPointDepth=1" MarkerSize="1">
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

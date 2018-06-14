<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CampeonatoEstatisticas.aspx.cs" Inherits="BolaoNet.WebSite.Campeonatos.CampeonatoEstatisticas"  %>
<%@ Register src="../Controls/MenuCampeonatoControl.ascx" tagname="MenuCampeonatoControl" tagprefix="uc1" %>


<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc1" %>



<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuCampeonatoControl ID="MenuCampeonatoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">

    
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Estatísticas do campeonato</asp:Label>
            </td>
            <td class="adminTools">&nbsp;</td>
            <td class="adminHome">
                <uc1:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table width="100%">
        <tr>
            <td align="left" valign="top">
                <div class="data_section_header"><asp:Label ID="lblMenuLeft" runat="server" Text="Resumo de Vitórias"></asp:Label></div>
                <div class="data_section">     
                    <asp:Chart ID="ctlResumo" runat="server">
                        <Series>
                            <asp:Series Name="Series1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <br />
                    Total de jogos:
                    <asp:Label ID="lblTotalJogos" runat="server"></asp:Label>
                </div>
    
            </td>
            <td align="left" valign="top" >
                <div class="data_section_header"><asp:Label ID="lblMenuRight" runat="server" Text="Resumo de Gols"></asp:Label></div>
                <div class="data_section">     
                    <asp:GridView ID="grdResumo" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                            <asp:BoundField DataField="Gols" HeaderText="Gols" />
                            <asp:BoundField DataField="Media" HeaderText="Média" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            
                <div class="data_section_header"><asp:Label ID="lblGrafico" runat="server" Text="Placares mais frequêntes"></asp:Label></div>
                <div class="data_section" align="center">     
            
                
                    <asp:Chart ID="ctlChartPlacares" runat="server" Width="600px">
                        <Series>
                            <asp:Series ChartArea="ChartArea1" Name="Series1">
                            </asp:Series>
                        </Series>
                        <chartareas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>

                </div>


            </td>
        </tr>
    </table>
</asp:Content>

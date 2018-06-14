<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoClassificacao.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.BolaoClassificacao"  %>
<%@ Register src="../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc1" %>


<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuBolaoControl ID="MenuBolaoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">

    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Classificação do Bolão</asp:Label>
            </td>
            <td class="adminTools">&nbsp;</td>        
            <td class="adminHome">
                <uc1:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="grdClassificacao" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="grdClassificacao_RowDataBound" 
        ondatabound="grdClassificacao_DataBound" >
        <Columns>
            <asp:BoundField DataField="Posicao" HeaderText="Pos" >
                <ItemStyle CssClass="bolaoPosicao" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="imgLastPos" runat="server" />
                    <asp:Label ID="lblLastPos" runat="server" Text='<%# Bind("LastPosicao") %>' 
                        Font-Size="XX-Small"></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="bolaoPosicao" />
            </asp:TemplateField>
            
                    
            <asp:BoundField DataField="UserName" HeaderText="Membro" />
            <asp:BoundField DataField="FullName" HeaderText="Nome" />
            <asp:BoundField DataField="TotalPontos" HeaderText="PT" >
                <HeaderStyle CssClass="bolaoPontos" Width="30px" />
                <ItemStyle CssClass="bolaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalEmpate" HeaderText="E" >
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
                <ItemStyle CssClass="bolaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalVitoria" HeaderText="V" >
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
                <ItemStyle CssClass="bolaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalDerrota" HeaderText="D" >
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
                <ItemStyle CssClass="bolaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalGolsGanhador" HeaderText="GG" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
            <asp:BoundField DataField="TotalGolsPerdedor" HeaderText="GP" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
            <asp:BoundField DataField="TotalResultTime1" HeaderText="RT1" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
            <asp:BoundField DataField="TotalResultTime2" HeaderText="RT2" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
            <asp:BoundField DataField="TotalVDE" HeaderText="VDE" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
            <asp:BoundField DataField="TotalErro" HeaderText="ERR" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
            <asp:BoundField DataField="TotalGolsGanhadorFora" 
                HeaderText="GGF" >
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
                <ItemStyle CssClass="bolaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalGolsGanhadorDentro" 
                HeaderText="GGD" >
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
                <ItemStyle CssClass="bolaoPontos" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalPerdedorFora" HeaderText="PF" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
            <asp:BoundField DataField="TotalPerdedorDentro" HeaderText="PD" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
            <asp:BoundField DataField="TotalGolsEmpate" HeaderText="GE" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
            <asp:BoundField DataField="TotalGolsTime1" HeaderText="GT1" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos"  Width="30px" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalGolsTime2" HeaderText="GT2" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
            <asp:BoundField DataField="TotalPlacarCheio" HeaderText="C" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
            <asp:BoundField DataField="TotalApostaExtra" HeaderText="EX" >
                <ItemStyle CssClass="bolaoPontos" />
                <HeaderStyle CssClass="bolaoPontos" Width="30px"  />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <span style="font-size: x-small">
    <b>Legenda<br />
    </b>PT - pontos, E - Empates, V - Vitórias, GG - Gols Ganhador, GP - 
    Gols Perdedor, RT1 - Resultado time 1, RT2 - Resultado Time 2, VDE - 
    Vitória/Empate/Derrota, ERR - Erros, GGF - Gols Ganhador Fora, GGD - Gols 
    Ganhador Dentro, GPF - Gols Perdedor Fora, GPD - Gols Perdedor Dentro, GE - Gols 
    Empates, GT1 - Gols time 1, GT2 - Gols Time 2, C - Placar em cheio, EX - Pontos 
    em Apostas Extras<br />
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
    
&nbsp;
</asp:Content>

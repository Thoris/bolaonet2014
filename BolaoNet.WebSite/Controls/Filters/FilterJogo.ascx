<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterJogo.ascx.cs" Inherits="BolaoNet.WebSite.Controls.Filters.FilterJogo" %>


<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Ajax.Net" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<div class="data_section_header"><asp:Label ID="lblTitle" runat="server" 
        Text="Filtro"></asp:Label></div>
<div class="data_section"> 
    
<table cellspacing="1" style="width: 100%">
    <tr>
        <td valign="top">
            <table cellspacing="1" style="width: 95%; text-align: center;">
                <tr>
                    <td valign="top" align="left" width="30%">
                        <asp:Label ID="lblFiltro" runat="server" SkinID="labelText" Text="Tipo:"></asp:Label>
                        &nbsp;<asp:DropDownList ID="cboFiltro" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="cboFiltro_SelectedIndexChanged">
                            <asp:ListItem Value="0" Selected="True">Ontem, Hoje, Amanhã</asp:ListItem>
                            <asp:ListItem Value="1">Últimos 7 dias</asp:ListItem>
                            <asp:ListItem Value="2">Próximos 7 dias</asp:ListItem>
                            <asp:ListItem Value="3">Último Mês</asp:ListItem>
                            <asp:ListItem Value="4">Próximo mês</asp:ListItem>
                            <asp:ListItem Value="5">Este mês</asp:ListItem>
                            <asp:ListItem Value="6">Período</asp:ListItem>
                            <asp:ListItem Value="7">Rodada</asp:ListItem>
                            <asp:ListItem Value="8">Time</asp:ListItem>
                            <asp:ListItem Value="9" Enabled="False">Fase</asp:ListItem>
                            <asp:ListItem Value="10">Grupo</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="left" rowspan="2" valign="top">
                        <asp:MultiView ID="MultiViewFiltro" runat="server" ActiveViewIndex="0">
                            <asp:View ID="viewNull" runat="server">
                            </asp:View>
                            <asp:View ID="viewMes" runat="server">
                                <table cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDataInicial" runat="server" SkinID="labelText" 
                                                Text="Data Inicial:"></asp:Label>
                                            &nbsp;<asp:TextBox ID="txtFiltroDataInicial" runat="server" Columns="11" 
                                                MaxLength="10"></asp:TextBox><rjs:popcalendar id="PopCalendarDataInicial" runat="server" autopostback="True" 
                                                control="txtFiltroDataInicial" 
                                                onselectionchanged="PopCalendarDataInicial_SelectionChanged" separator="/" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblDataFinal" runat="server" SkinID="labelText" 
                                                Text="Data Final:"></asp:Label>
                                            &nbsp;<asp:TextBox ID="txtFiltroDataFinal" runat="server" Columns="11" MaxLength="10"></asp:TextBox><rjs:popcalendar id="PopCalendarDataFinal" runat="server" autopostback="True" 
                                                control="txtFiltroDataFinal" 
                                                onselectionchanged="PopCalendarDataFinal_SelectionChanged" separator="/" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="viewRodada" runat="server">
                                <asp:Label ID="lblRodada" runat="server" SkinID="labelText" Text="Rodada:"></asp:Label>
                                &nbsp;<asp:DropDownList ID="cboRodada" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="cboRodada_SelectedIndexChanged">
                                </asp:DropDownList>
                            </asp:View>
                            <asp:View ID="viewTime" runat="server">
                                <asp:Label ID="lblTime" runat="server" SkinID="labelText" Text="Time:"></asp:Label>
                                &nbsp;<asp:DropDownList ID="cboTime" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="cboTime_SelectedIndexChanged" >                                    
                                </asp:DropDownList>
                            </asp:View>
                            <asp:View ID="viewFase" runat="server">
                                <asp:Label ID="lblFase" runat="server" SkinID="labelText" Text="Fase:"></asp:Label>
                                &nbsp;<asp:DropDownList ID="cboFase" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="cboFase_SelectedIndexChanged">
                                </asp:DropDownList>
                            </asp:View>                            
                            <asp:View ID="viewGrupo" runat="server">
                                <asp:Label ID="lblGrupo" runat="server" SkinID="labelText" Text="Grupo:"></asp:Label>
                                &nbsp;<asp:DropDownList ID="cboGrupo" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="cboGrupo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</div>
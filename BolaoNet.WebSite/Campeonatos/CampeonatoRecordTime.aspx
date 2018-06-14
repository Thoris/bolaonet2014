<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CampeonatoRecordTime.aspx.cs" Inherits="BolaoNet.WebSite.Campeonatos.CampeonatoRecordTime"  %>
<%@ Register src="../Controls/MenuCampeonatoControl.ascx" tagname="MenuCampeonatoControl" tagprefix="uc1" %>


<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <p>
        <uc1:MenuCampeonatoControl ID="MenuCampeonatoControl1" runat="server" />
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Menu ID="mnuRecords" runat="server" 
        MaximumDynamicDisplayLevels="0" SkinID="SubMenu" 
                onmenuitemclick="mnuRecords_MenuItemClick">
                <Items>
                    <asp:MenuItem Text="Mais tempo sem perder" Value="2"></asp:MenuItem>
                    <asp:MenuItem Text="Recorde sem perder" Value="7"></asp:MenuItem>
                    <asp:MenuItem Text="Mais tempo sem vencer" Value="1"></asp:MenuItem>
                    <asp:MenuItem Text="Recorde sem vencer" Value="6"></asp:MenuItem>
                    <asp:MenuItem Text="Sequência de vitórias" Value="5"></asp:MenuItem>
                    <asp:MenuItem Text="Recorde Seq. de vitórias" Value="10"></asp:MenuItem>
                    <asp:MenuItem Text="Sequência de empates" Value="4"></asp:MenuItem>
                    <asp:MenuItem Text="Recorde seq. de empates" Value="9"></asp:MenuItem>
                    <asp:MenuItem Text="Sequência de derrotas" Value="3"></asp:MenuItem>
                    <asp:MenuItem Text="Recorde seq. de derrotas" Value="8"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblTitle" runat="server">Records do time especificado</asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="adminTools">
                <uc4:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" DeleteVisible="False" NextVisible="False" ReturnVisible="False" SaveVisible="False" />
            </td>
            <td class="adminHome">
                <uc3:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        
            <div class="data_section_header">
                <asp:Label ID="lblFiltro" runat="server" Text="Filtro"></asp:Label>
            </div>
            <div class="data_section">
                <table style="width: 100%">
                    <tr>
                        <td width="70px">
                            Time:</td>
                        <td>
                            <asp:DropDownList ID="cboTime" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
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
            
            
            <br />
        
        
        
            <table class="style1">
                <tr>
                    <td class="data_section_header">
                        Geral</td>
                    <td width="5px">
                        &nbsp;</td>
                    <td class="data_section_header">
                        Casa</td>
                    <td width="5px">
                        &nbsp;</td>
                    <td class="data_section_header">
                        Fora</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdGeneral" runat="server" 
                AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Derrota" HeaderText="D">
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Empate" HeaderText="E">
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Vitoria" HeaderText="V">
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:GridView ID="grdDentro" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Derrota" HeaderText="D">
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Empate" HeaderText="E">
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Vitoria" HeaderText="V">
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:GridView ID="grdFora" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Derrota" HeaderText="D">
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Empate" HeaderText="E">
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Vitoria" HeaderText="V">
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

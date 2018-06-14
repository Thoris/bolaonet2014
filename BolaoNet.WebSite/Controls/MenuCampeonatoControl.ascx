<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuCampeonatoControl.ascx.cs" Inherits="BolaoNet.WebSite.Controls.CampeonatoControl" %>
<table cellspacing="1" width="100%">
    <tr>
        <td align="center">
            Campeonato</td>
    </tr>
    <tr class="imageLeft">
        <td align="center">
            <asp:Image ID="imgCampeonato" runat="server" Height="160px" 
                ImageUrl="~/Images/noimage-usuario.jpg" Width="120px" />            
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Label ID="lblNomeCampeonato" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Menu ID="mnuCampeonato" runat="server" DataSourceID="SiteMapDataSource"
                style="text-align: center" BackColor=AliceBlue 
                MaximumDynamicDisplayLevels="0">
            </asp:Menu>
        </td>
    </tr>
    </table>
<asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
    ShowStartingNode="False" StartingNodeUrl="~\Campeonatos\CampeonatoHome.aspx" />

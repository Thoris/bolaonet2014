<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuApostasControl.ascx.cs" Inherits="BolaoNet.WebSite.Controls.MenuApostasControl" %>
<table cellspacing="1" width="100%">
    <tr>
        <td align="center">
            Apostas</td>
    </tr>
    <tr class="imageLeft">
        <td align="center">
            <asp:Image ID="imgBolao" runat="server" Height="160px" 
                ImageUrl="~/Images/noimage-usuario.jpg" Width="120px" />            
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource">
            </asp:Menu>
        </td>
    </tr>
    </table>
<asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
    ShowStartingNode="False" StartingNodeUrl="~/Apostas/HomeApostas.aspx" />

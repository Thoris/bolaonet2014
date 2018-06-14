<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBolaoControl.ascx.cs" Inherits="BolaoNet.WebSite.Controls.BolaoControl" %>
<table cellspacing="1" width="100%">
    <tr>
        <td align="center">
            Bolão</td>
    </tr>
    <tr class="imageLeft">
        <td align="center">
            <asp:Image ID="imgBolao" runat="server" Height="160px" 
                ImageUrl="~/Images/noimage-usuario.jpg" Width="120px" />
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="lblNomeBolao" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Menu ID="mnuBolaoAux" runat="server" 
                style="text-align: center" BackColor=AliceBlue 
                MaximumDynamicDisplayLevels="0" 
                onmenuitemclick="mnuBolaoAux_MenuItemClick">
                <Items>
                    <asp:MenuItem Text="Participar" ToolTip="Participar do bolão" 
                        Value="Participar"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource" 
                style="text-align: center" BackColor=AliceBlue 
                MaximumDynamicDisplayLevels="0">
            </asp:Menu>
        </td>
    </tr>
    </table>
<asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
    ShowStartingNode="False" StartingNodeUrl="~/Boloes/BolaoHome.aspx" />

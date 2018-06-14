<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuUserControl.ascx.cs" Inherits="BolaoNet.WebSite.Controls.UserControl" %>
<table cellspacing="1" width="100%" align="center">
    <tr>
        <td align="center" >
            Membro</td>
    </tr>
    <tr class="imageLeft">
        <td align="center"  >
            <asp:Image ID="imgUser" runat="server" Height="160px" 
                ImageUrl="~/Images/noimage-usuario.jpg" Width="120px" />
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="lblNome" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="lblCidade" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="lblPais" runat="server"></asp:Label>
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
    ShowStartingNode="False" StartingNodeUrl="~/Users/Home.aspx" />


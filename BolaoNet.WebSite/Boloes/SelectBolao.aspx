<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="SelectBolao.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.SelectBolao"  %>

<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">


    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <uc2:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="True" 
                    SaveVisible="False" />
            </td>
            <td class="adminHome">
                <uc1:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<br />
    
    <div class="data_section_selected_header"><asp:Label ID="lblTitle" runat="server" Text="Bolão Selecionado"></asp:Label></div>
    <div class="data_section"> 
        
        <table style="width: 100%">
            <tr>
                <td>
                    Bolão Selecionado:</td>
                <td>
                <asp:Label ID="lblBolaoCurrent" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Image ID="imgSelected" runat="server" Height="120px" Width="90px" />
                </td>
            </tr>
        </table>
        
    </div>    
    
    <br />
    
    <div class="data_section_header"><asp:Label ID="Label1" runat="server" Text="Selecione um bolão"></asp:Label></div>
    <div class="data_section"> 
    
    
                <asp:DataList ID="dtlBolao" runat="server" 
                    onitemdatabound="dtlBolao_ItemDataBound" RepeatColumns="4" 
                    RepeatDirection="Horizontal" Width="100%">
                    <ItemTemplate>
                        <table cellspacing="1" style="width: 100%">
                            <tr>
                                <td align="center" colspan="2" valign="middle">
                                    <asp:Image ID="ibtnBolao" runat="server" Height="120px" Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" valign="middle">
                                    <asp:LinkButton ID="lnkBolao" runat="server" onclick="lnkBolao_Click">LinkButton</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:Label ID="lblLastURL" runat="server" Visible="False"></asp:Label>
    </div>

</asp:Content>

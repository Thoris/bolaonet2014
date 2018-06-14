<%@ Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoParticipacao.aspx.cs" Inherits="BolaoNet.WebSite.Apostas.BolaoParticipacao"  %>
<%@ Register src="../Controls/MenuUserControl.ascx" tagname="MenuUserControl" tagprefix="uc1" %>




<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuUserControl ID="MenuUserControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
   <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Seleção de bolões para participação</asp:Label>
            </td>
            <td class="adminTools">
                <uc2:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="False" 
                    SaveVisible="False" />
            </td>
            <td class="adminHome">
                <uc3:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="data_section_header"><asp:Label ID="lblMeusBoloes" runat="server" Text="Meus Bolões"></asp:Label></div>
    <div class="data_section"> 
    
        <asp:DataList ID="dtlBolao" runat="server" RepeatColumns="4" 
            RepeatDirection="Horizontal" Width="100%" 
            onitemdatabound="dtlBolao_ItemDataBound" onitemcommand="dtlBolao_ItemCommand">
            <ItemTemplate>
                <table cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="center" valign="middle">
                            <asp:Image ID="imgBolao" runat="server" Height="120px" Width="90px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle">
                            <asp:Label ID="lblBolao" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle">
                            <asp:LinkButton ID="lnkRemove" runat="server" CommandName="Delete" Visible="false" 
                                onclick="lnkRemove_Click" 
                                onclientclick="return confirm(&quot;Deseja não ser mais um membro deste bolão?&quot;);" 
                                CommandArgument='<%# Eval("Nome") %>' oncommand="lnkRemove_Command" 
                                 >Remover-me</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>    
    
    </div>
    
    <div class="data_section_header"><asp:Label ID="lblBoloes" runat="server" Text="Bolões Disponíveis"></asp:Label></div>
    <div class="data_section"> 
    
    
                <asp:DataList ID="dtlBolaoDisponiveis" runat="server" 
                    RepeatColumns="4" 
                    RepeatDirection="Horizontal" Width="100%" 
                    onitemdatabound="dtlBolaoDisponiveis_ItemDataBound">
                    <ItemTemplate>
                        <table cellspacing="1" style="width: 100%">
                            <tr>
                                <td align="center" valign="middle">
                                    <asp:Image ID="imgBolao" runat="server" Height="120px" Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="middle">
                                    <asp:Label ID="lblBolao" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="middle">
                                    <asp:LinkButton ID="lnkAdicionar" runat="server" onclick="lnkAdicionar_Click">Participar</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
    </div>
    
</asp:Content>

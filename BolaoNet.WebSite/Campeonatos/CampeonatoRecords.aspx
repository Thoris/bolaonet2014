<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CampeonatoRecords.aspx.cs" Inherits="BolaoNet.WebSite.Campeonatos.CampeonatoRecords"  %>
<%@ Register src="../Controls/MenuCampeonatoControl.ascx" tagname="MenuCampeonatoControl" tagprefix="uc1" %>


<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuCampeonatoControl ID="MenuCampeonatoControl1" runat="server" />
    <br />
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>    
            <asp:Menu ID="mnuRecords" runat="server" 
                    MaximumDynamicDisplayLevels="0" SkinID="SubMenu" 
                    onmenuitemclick="mnuRecords_MenuItemClick" >
                <Items>
                    <asp:MenuItem Text="Mais tempo sem perder" Value="2">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Recorde sem perder" Value="7">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Mais tempo sem vencer" Value="1">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Recorde sem vencer" Value="6">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Sequência de vitórias" Value="5">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Recorde Seq. de vitórias" Value="10">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Sequência de empates" Value="4">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Recorde seq. de empates" Value="9">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Sequência de derrotas" Value="3">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Recorde seq. de derrotas" Value="8">
                    </asp:MenuItem>
                </Items>
            </asp:Menu>
            </ContentTemplate>            
            </asp:UpdatePanel>
        </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblTitle" runat="server">Records do campeonato</asp:Label>
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
    <asp:UpdatePanel ID="updatePanelMain" runat="server">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td valign="top">
                                        
                        <div class="data_section_header"><asp:Label ID="lblTitleGeneral" runat="server" Text="Geral"></asp:Label></div>
                        <div class="data_section">   


                        
                            <asp:GridView ID="grdGeneral" runat="server" AutoGenerateColumns="False" 
                                style="font-size: 11px">
                                <Columns>
                                                        
                                        
                                    <asp:BoundField DataField="Posicao" HeaderText="P">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    
                
                                    <asp:ImageField DataAlternateTextField="Time" 
                                        DataAlternateTextFormatString="{0}" DataImageUrlField="Time" 
                                        DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                                    </asp:ImageField>
                                                                            
                                    
                                    
                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                    
                                    <asp:BoundField DataField="Jogos" HeaderText="J">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="Derrotas" HeaderText="D">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Empates" HeaderText="E">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Vitorias" HeaderText="V">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        
                        </div>
                        
                        
                    </td>
                    <td>
                        &nbsp;</td>
                    <td  valign="top">
                    

                        <div class="data_section_header"><asp:Label ID="lblTitleDentro" runat="server" Text="Dentro"></asp:Label></div>
                        <div class="data_section">                      
                    
                        
                            <asp:GridView ID="grdDentro" runat="server" AutoGenerateColumns="False" 
                                style="font-size: 11px">
                                <Columns>
                                    <asp:BoundField DataField="Posicao" HeaderText="P">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    
                
                                    <asp:ImageField DataAlternateTextField="Time" 
                                        DataAlternateTextFormatString="{0}" DataImageUrlField="Time" 
                                        DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">                                                     
                                    </asp:ImageField>                       
                                    
                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                    
                                    <asp:BoundField DataField="Jogos" HeaderText="J">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="Derrotas" HeaderText="D">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Empates" HeaderText="E">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Vitorias" HeaderText="V">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            
                        </div>
                        
                    </td>
                    <td>
                        &nbsp;</td>
                    <td  valign="top">
                    

                        <div class="data_section_header"><asp:Label ID="lblTitleFora" runat="server" Text="Fora"></asp:Label></div>
                        <div class="data_section">                      
                    
                    
                            <asp:GridView ID="grdFora" runat="server" AutoGenerateColumns="False" 
                                style="font-size: 11px">
                                <Columns>
                                    <asp:BoundField DataField="Posicao" HeaderText="P">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    
                
                                    <asp:ImageField DataAlternateTextField="Time" 
                                        DataAlternateTextFormatString="{0}" DataImageUrlField="Time" 
                                        DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                                    </asp:ImageField>                                        
                                    
                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                    
                                    <asp:BoundField DataField="Jogos" HeaderText="J">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="Derrotas" HeaderText="D">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Empates" HeaderText="E">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Vitorias" HeaderText="V">
                                        <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            
                        </div>
                        
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

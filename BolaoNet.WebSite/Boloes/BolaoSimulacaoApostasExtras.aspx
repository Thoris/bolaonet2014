<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoSimulacaoApostasExtras.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.BolaoSimulacaoApostasExtras" %>


<%@ Register src="../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc2:MenuBolaoControl ID="MenuBolaoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Simulação de Apostas Extras</asp:Label>
            </td>
            <td class="adminTools">
                <uc3:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="True" 
                    SaveVisible="False" />
            </td>
            <td class="adminHome">
                <uc4:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:UpdatePanel ID="UpdatePanelJogos" runat="server">
        <ContentTemplate>
        

            <div class="data_section_header"><asp:Label ID="lblTituloApostasExtras" runat="server" 
                    Text="Apostas Extras"></asp:Label></div>
            <div class="data_section">             
                
                <asp:GridView ID="grdApostas" runat="server" AutoGenerateColumns="False" 
                    onrowdatabound="grdApostas_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="NomeBolao" HeaderText="Bolão" Visible="False" />
                        <asp:BoundField DataField="UserName" HeaderText="UserName" Visible="False" />
                        <asp:BoundField DataField="Posicao" HeaderText="Posição" Visible="False" />
                        <asp:BoundField DataField="Titulo" HeaderText="Título" />
                        <asp:BoundField DataField="NomeTimeValidado" HeaderText="Validado" />
                        <asp:CheckBoxField DataField="IsValido" HeaderText="Válido" />
                        <asp:TemplateField HeaderText="Aposta">
                            <ItemTemplate>
                                <asp:Label ID="lblNomeTime" runat="server" Text='<%# Bind("NomeTimeValidado") %>'></asp:Label>
                                <asp:DropDownList ID="cboNomeTime" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="cboNomeTime_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Image ID="imgTime" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pontos">
                            <ItemTemplate>
                                <asp:Label ID="lblPontos" runat="server" Text='<%# Bind("TotalPontos") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoPontos" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                
            </div>
            
            <table align="center" class="style1">
                <tr>
                    <td align="center">
                        <jogodetail id="ctlJogoDetail" runat="server" jogomode="Result" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSimular" runat="server" onclick="btnSimular_Click" 
                            Text="Simular" />
                        &nbsp;
                        <asp:Button ID="btnLimpar" runat="server" onclick="btnLimpar_Click" 
                            Text="Limpar" />
                    </td>
                </tr>
            </table>
            
            <br />
            
            <div class="data_section_header"><asp:Label ID="lblTituloPosicao" runat="server" 
                    Text="Posição dos Usuários"></asp:Label></div>
            <div class="data_section">             
                
                <asp:GridView ID="grdJogosUsuarios" runat="server" AutoGenerateColumns="False" 
                    ondatabinding="grdJogosUsuarios_DataBinding" 
                    ondatabound="grdJogosUsuarios_DataBound" 
                    onrowdatabound="grdJogosUsuarios_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="Posicao" HeaderText="Pos">
                            <ItemStyle CssClass="bolaoPosicao" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgLastPos" runat="server" />
                                <asp:Label ID="lblLastPos" runat="server" Text='<%# Bind("LastPosicao") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="bolaoPosicao" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="UserName" HeaderText="UserName" />
                        <asp:BoundField DataField="TotalPontosCalculado" HeaderText="Pontos" />
                        <asp:BoundField DataField="Difference" HeaderText="Diferença" />
                        <asp:ImageField DataAlternateTextField="Campeao" 
                            DataAlternateTextFormatString="{0}" DataImageUrlField="Campeao" 
                            DataImageUrlFormatString="~/Images/Database/Times/{0}.gif" HeaderText="1">
                            <ItemStyle Width="5px" />
                        </asp:ImageField>
                        <asp:ImageField DataAlternateTextField="ViceCampeao" 
                            DataAlternateTextFormatString="{0}" DataImageUrlField="ViceCampeao" 
                            DataImageUrlFormatString="~/Images/Database/Times/{0}.gif" HeaderText="2">
                            <ItemStyle Width="5px" />
                        </asp:ImageField>
                        <asp:ImageField DataAlternateTextField="Terceiro" 
                            DataAlternateTextFormatString="{0}" DataImageUrlField="Terceiro" 
                            DataImageUrlFormatString="~/Images/Database/Times/{0}.gif" HeaderText="3">
                            <ItemStyle Width="5px" />
                        </asp:ImageField>
                        <asp:ImageField DataAlternateTextField="QuartoLugar" 
                            DataAlternateTextFormatString="{0}" DataImageUrlField="QuartoLugar" 
                            DataImageUrlFormatString="~/Images/Database/Times/{0}.gif" HeaderText="4">
                            <ItemStyle Width="5px" />
                        </asp:ImageField>
                    </Columns>
                </asp:GridView>
                
            </div>
            

        </ContentTemplate>
    </asp:UpdatePanel>        
</asp:Content>

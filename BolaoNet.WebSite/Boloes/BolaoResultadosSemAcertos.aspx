<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoResultadosSemAcertos.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.BolaoResultadosSemAcertos" %>
<%@ Register src="../Controls/Filters/ListJogo.ascx" tagname="ListJogo" tagprefix="uc1" %>
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
                <asp:Label ID="lblTitle" runat="server">Jogos sem acertos</asp:Label>
            </td>
            <td class="adminTools">

            </td>
            <td class="adminHome">
                <uc4:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:UpdatePanel ID="UpdatePanelUsuario" runat="server">
        <ContentTemplate>
        

                
                
                <asp:GridView ID="grdJogos" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="IDJogo" 
                    ondatabinding="grdJogos_DataBinding" 
                    onrowdatabound="grdJogos_RowDataBound" 
                    EmptyDataText="Não foram encontrados jogos" 
                    EnableViewState="False" style="font-size: x-small; text-align: left;" 
                    Width="100%" ondatabound="grdJogos_DataBound" GridLines="None">

                    <Columns>
                        <asp:TemplateField HeaderText="ID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("IdJogo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NomeCampeonato" HeaderText="Campeonato" 
                            Visible="False" />
                        <asp:BoundField DataField="Fase" HeaderText="Fase" Visible="False" />
                        <asp:BoundField DataField="Titulo" HeaderText="Título" Visible="False" />
                        <asp:BoundField DataField="OnlyDataJogo" HeaderText="OnlyDataJogo" 
                            DataFormatString="{0:d}" >
                            <ItemStyle CssClass="jogoDia" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Hora">                        
                            <ItemTemplate>
                                Horário:
                                <asp:Label ID="lblHora" runat="server" CssClass="jogoHora" 
                                    Text='<%# Bind("HoraJogo", "{0:t}") %>'></asp:Label>
                                <br />
                                Grupo:
                                <asp:Label ID="lblGrupo" runat="server" CssClass="jogoGrupo" 
                                    Text='<%# Bind("Grupo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoGrupoHora" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estádio">
                            <ItemTemplate>
                                <asp:Label ID="lblEstadio" runat="server" Text='<%# Bind("Estadio") %>'></asp:Label>                
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoEstadio" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time1">
                            <ItemTemplate>
                                <asp:Label ID="lblTime1" runat="server" Text='<%# Bind("Time1") %>'></asp:Label>
                                <br />
                                <asp:Label ID="lblDescricaoTime1" runat="server" 
                                    Text='<%# Bind("DescricaoTime1") %>' 
                                    style="font-weight: 700; font-size: xx-small;"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoTimeCasa" />
                        </asp:TemplateField>
                        <asp:ImageField DataAlternateTextField="Time1" 
                            DataAlternateTextFormatString="{0}" DataImageUrlField="Time1" 
                            DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                            <ItemStyle HorizontalAlign="Center" Width="5px" CssClass="jogoTimeImage" />
                        </asp:ImageField>
                        <asp:TemplateField HeaderText="Gols1">
                            <ItemTemplate>
                                <asp:Label ID="lblGolsTime1" runat="server" Text='<%# Bind("GolsTime1") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoGols" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="PenaltisTime1" HeaderText="Penaltis1" 
                            Visible="False" >
                            <ItemStyle CssClass="jogoPenaltis" />
                        </asp:BoundField>
        
                        <asp:TemplateField>
                            <ItemTemplate>
                                x
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoVersus" />
                        </asp:TemplateField>
                
                        <asp:BoundField DataField="PenaltisTime2" HeaderText="Penaltis2" 
                            Visible="False" >
                            <ItemStyle CssClass="jogoPenaltis" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Gols2">
                            <ItemTemplate>
                                <asp:Label ID="lblGolsTime2" runat="server" Text='<%# Bind("GolsTime2") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoGols" />
                        </asp:TemplateField>
                        <asp:ImageField DataAlternateTextField="Time2" 
                    DataAlternateTextFormatString="{0}" DataImageUrlField="Time2" 
                    DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                            <ItemStyle HorizontalAlign="Center" Width="5px" />
                        </asp:ImageField>
                        <asp:TemplateField HeaderText="Time2">
                            <ItemTemplate>
                                <asp:Label ID="lblTime2" runat="server" Text='<%# Bind("Time2") %>'></asp:Label>
                                <br />
                                <asp:Label ID="lblDescricaoTime2" runat="server" 
                                    Text='<%# Bind("DescricaoTime2") %>' 
                                    style="font-weight: 700; font-size: xx-small;"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoTimeFora" HorizontalAlign="Left" Width="100px" />
                        </asp:TemplateField>
        
                        <asp:BoundField DataField="Rodada" HeaderText="Rodada" >
                            <ItemStyle CssClass="jogoRodada" />
                        </asp:BoundField>                        

        
        
                        <asp:TemplateField HeaderText="Pontos">
                            <ItemTemplate>
                                <asp:Label ID="lblPontos" runat="server" style="text-align: center"  Text='<%# Bind("Pontos") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle CssClass="jogoPontos" Font-Bold="True" HorizontalAlign="Center" 
                                VerticalAlign="Middle" />
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Válido">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkValido" runat="server" 
                            Checked='<%# Bind("PartidaValida") %>' Enabled="false" />
                            </ItemTemplate>
                            <ItemStyle Width="5px" CssClass="jogoValido" />
                        </asp:TemplateField>
        
                        <asp:BoundField DataField="DataValidacao" HeaderText="DataValidacao" 
                            Visible="False" >
                            <ItemStyle CssClass="jogoValidadoData" />
                        </asp:BoundField>                        
                        <asp:BoundField DataField="ValidadoBy" HeaderText="ValidadoBy" 
                            Visible="False" />
            
            
                        <asp:TemplateField HeaderText="Auto">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkApostaAuto" runat="server" Enabled="false" />
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoApostaAuto" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data Aposta">
                            <ItemTemplate>
                                <asp:Label ID="lblDataAposta" runat="server" Text='<%# Bind("DataAposta") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle CssClass="jogoDataAposta" />
                        </asp:TemplateField>            
            
                        <asp:BoundField DataField="UserName" HeaderText="Usuário" Visible="True" />
        
                        <asp:HyperLinkField DataNavigateUrlFields="Campeonato,IDJogo" 
                            DataNavigateUrlFormatString="~\Boloes\ApostasJogos.aspx?IDjogo={1}" 
                            Text="&lt;img src=&quot;/Images/palpites.png&quot;&gt;"  >
                            <ItemStyle CssClass="jogoResultado" />
                        </asp:HyperLinkField>        
        
                
                    </Columns>
    
    
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="XX-Small" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
        
                 
                
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

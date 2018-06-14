<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CampeonatoGoleadas.aspx.cs" Inherits="BolaoNet.WebSite.Campeonatos.CampeonatoGoleadas"  %>
<%@ Register src="../Controls/MenuCampeonatoControl.ascx" tagname="MenuCampeonatoControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuCampeonatoControl ID="MenuCampeonatoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Goleadas do campeonato</asp:Label>
            </td>
            <td class="adminTools">
                <uc3:MenuTools ID="MenuTools1" runat="server" AddVisible="false" DeleteVisible="false" NextVisible="false" ReturnVisible="false" SaveVisible="false" />
            </td>
            <td class="adminHome">
                <uc2:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="grdJogos" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="IDJogo" 
        ondatabinding="grdJogos_DataBinding" 
        onrowdatabound="grdJogos_RowDataBound" 
        EmptyDataText="Não foram encontrados resultados." 
        EnableViewState="False" style="font-size: x-small; text-align: left;" 
        Width="100%">
        <Columns>
            <asp:BoundField DataField="IdJogo" HeaderText="ID" Visible="False" />
            <asp:BoundField DataField="NomeCampeonato" HeaderText="Campeonato" 
                Visible="False" />
            <asp:BoundField DataField="Fase" HeaderText="Fase" Visible="False" >
                <ItemStyle CssClass="jogoFase" />
            </asp:BoundField>
            <asp:BoundField DataField="Titulo" HeaderText="Título" Visible="False" />
            
            
            <asp:BoundField DataField="Grupo" HeaderText="Grupo" >
            
                <ItemStyle CssClass="jogoGrupo" />
            </asp:BoundField>
            
            <asp:TemplateField HeaderText="Dia">
                <ItemTemplate>
                    <asp:Label ID="lblDia" runat="server" 
                        Text='<%# Bind("OnlyDataJogo", "{0:d}") %>'></asp:Label>
                    <br />
                    <asp:Label ID="lblHora" runat="server" CssClass="jogoHora" 
                        Text='<%# Bind("HoraJogo", "{0:t}") %>'></asp:Label> 
                </ItemTemplate>
                <ItemStyle CssClass="jogoDia" />
            </asp:TemplateField>

            <asp:BoundField DataField="Estadio" HeaderText="Estádio"  >                        
                 <ItemStyle CssClass="jogoEstadio" />
            </asp:BoundField>                       
            <asp:BoundField DataField="Time1" HeaderText="Time1" >
                <ItemStyle CssClass="jogoTimeCasa" />
            </asp:BoundField>
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
            <asp:BoundField DataField="Time2" HeaderText="Time2" >
                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="jogoTimeFora" />
            </asp:BoundField>
            <asp:BoundField DataField="Rodada" HeaderText="Rodada" >
                <ItemStyle CssClass="jogoRodada" />
            </asp:BoundField>                        

                  
        </Columns>        
        <HeaderStyle Font-Size="XX-Small" />
    </asp:GridView>
</asp:Content>

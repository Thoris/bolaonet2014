<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ApostasAutoResultado.aspx.cs" Inherits="BolaoNet.WebSite.Apostas.ApostasAutoResultado"  %>


<%@ Register src="../Controls/MenuApostasControl.ascx" tagname="MenuApostasControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuApostasControl ID="MenuApostasControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Apostas automáticas</asp:Label>
            </td>
            <td class="adminTools">
                <uc2:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="True" 
                    SaveVisible="False" />
            </td>
            <td class="adminHome">
                <uc3:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="grdResultado" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Campeonato" HeaderText="Campeonato" 
                Visible="False" />
            <asp:BoundField DataField="IDJogo" HeaderText="IDJogo" ReadOnly="True" 
                Visible="False" />
        
        
            <asp:BoundField DataField="OnlyDataJogo" HeaderText="Data" 
                DataFormatString="{0:d}" >
                <ItemStyle CssClass="jogoDia" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Hora">                        
                <ItemTemplate>
                    &nbsp;<asp:Label ID="lblHora" runat="server" CssClass="jogoHora" 
                        Text='<%# Bind("HoraJogo", "{0:t}") %>'></asp:Label>                    
                </ItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
                        
                
                
            <asp:BoundField DataField="DataJogo" HeaderText="DataJogo" Visible="False" />
            
            <asp:BoundField DataField="Time1" HeaderText="Time" >
                <ItemStyle CssClass="jogoTimeCasa" />
            </asp:BoundField>
            
            <asp:ImageField DataAlternateTextField="Time1" 
                DataAlternateTextFormatString="{0}" DataImageUrlField="Time1" 
                DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                <ItemStyle HorizontalAlign="Center" Width="5px" CssClass="jogoTimeImage" />
            </asp:ImageField>            
            
            
            <asp:BoundField DataField="ApostaTime1" HeaderText="Aposta" >
                 <ItemStyle CssClass="jogoAposta" />
            </asp:BoundField>
            
            <asp:TemplateField>
                <ItemTemplate>
                    x
                </ItemTemplate>
                 <ItemStyle CssClass="jogoVersus" />
            </asp:TemplateField>
            
            <asp:BoundField DataField="ApostaTime2" HeaderText="Aposta" >
                 <ItemStyle CssClass="jogoAposta" />
            </asp:BoundField>
            
            <asp:ImageField DataAlternateTextField="Time2" 
                DataAlternateTextFormatString="{0}" DataImageUrlField="Time2" 
                DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                <ItemStyle HorizontalAlign="Center" Width="5px" CssClass="jogoTimeImage" />
            </asp:ImageField>             
            
            
            <asp:BoundField DataField="Time2" HeaderText="Time" >
                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="jogoTimeFora" />
            </asp:BoundField>
            
<%--            <asp:HyperLinkField DataNavigateUrlFields="Campeonato,IDJogo" 
                DataNavigateUrlFormatString="~\Resultados\CampeonatoResultado.aspx?IDjogo={1}" 
                Text="&lt;img src=&quot;~/Images/resultado.png&quot;&gt;" >
                <ItemStyle CssClass="jogoResultado" />
            </asp:HyperLinkField>   --%>          
            
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</asp:Content>

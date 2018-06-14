<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BolaoNet.WebSite.Users.Home" %>


<%@ Register src="../Controls/MenuUserControl.ascx" tagname="MenuUserControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" Runat="Server">
    <uc1:MenuUserControl ID="MenuUserControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" Runat="Server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Página principal</asp:Label>
            </td>
            <td class="adminTools">
                <uc2:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="False" 
                    SaveVisible="false" />
            </td>
            <td class="adminHome">
                <uc3:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">

    <table style="width: 100%" align="left">
        <tr>
            <td valign="top" style="width=60%" >

                <div class="data_section_header"><asp:Label ID="lblAdminTools" runat="server" Text="Meus Bolões"></asp:Label></div>
                <div class="data_section">                   

                    <asp:GridView ID="grdMeusBoloes" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Bolao" EmptyDataText="Você não faz parte de nenhum bolão" 
                        style="font-size: 16px; text-align: left;" 
                        onrowdatabound="grdMeusBoloes_RowDataBound" 
                        onrowcommand="grdMeusBoloes_RowCommand" EnableModelValidation="True"  >
                        <Columns>
                            <asp:ImageField DataAlternateTextField="Bolao" 
                                DataAlternateTextFormatString="{0}" DataImageUrlField="Bolao" 
                                DataImageUrlFormatString="~/Images/Database/Boloes/{0}.gif" Visible="false">
                            </asp:ImageField>
                            <asp:TemplateField HeaderText="Nome">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkBolao2" runat="server" 
                                        NavigateUrl='<%# "~/Boloes/BolaoClassificacao.aspx?Bolao=" + Eval("Bolao") + "&Campeonato=" + Eval("Campeonato") %>' 
                                        Text='<%# Eval("Bolao") %>'></asp:HyperLink>
                                    <asp:LinkButton ID="lnkBolao" runat="server" 
                                        CommandArgument='<%# Eval("Bolao", "~/Boloes/BolaoClassificacao.aspx?Bolao={0}") %>' 
                                        onclick="lnkBolao_Click" Text='<%# Eval("Bolao") %>' Visible="False"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Height="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cobertura">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkCobertura" runat="server" 
                                        NavigateUrl='<%# "~/Campeonatos/CampeonatoClassificacao.aspx?Campeonato=" + Eval("Campeonato") + "&Bolao=" + Eval("Bolao") %>' 
                                        Text='<%# Eval("Campeonato") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Membros">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkMembros" runat="server" 
                                        
                                        NavigateUrl='<%# "~/Boloes/BolaoClassificacao.aspx" + "?Bolao=" + Eval("Bolao") + "&Campeonato=" + Eval("Campeonato") %>' 
                                        Text='<%# Eval("Membros") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Position" HeaderText="Posição" />
                            <asp:TemplateField HeaderText="Restantes">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkRestantes" runat="server" 
                                        
                                        NavigateUrl='<%# "~/Apostas/HomeApostas.aspx?Bolao=" + Eval("Bolao") + "&Campeonato=" + Eval("Campeonato") %>' 
                                        Text='<%# Eval("ApostasRestantes") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField DataNavigateUrlFields="Bolao,Campeonato" 
                                DataNavigateUrlFormatString="~/Apostas/ApostasJogos.aspx?Bolao={0}&amp;Campeonato={1}" 
                                Text="&lt;img src=&quot;/Images/palpites.png&quot;&gt;" >
                                <ItemStyle Width="5px" />
                            </asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
            
            
            </td>
            <td width="7px">
                &nbsp;</td>
            <td align="left" valign="top">
                <div class="data_section_header"><asp:Label ID="Label1" runat="server" Text="Pagamentos"></asp:Label></div>
                <div class="data_section">
                
                
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <asp:GridView ID="grdPagamentos" runat="server" AutoGenerateColumns="False" 
                                    EmptyDataText="Você está com o pagamento dos seus bolões em dia" 
                                    style="font-size: 13px" EnableModelValidation="True">
                                    <Columns>
                                        <asp:BoundField DataField="bolao" HeaderText="Bolão" >
                                        <ItemStyle Height="40px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DataInicio" HeaderText="Início" Visible="False" />
                                        <asp:BoundField DataField="Total" HeaderText="Valor" DataFormatString="{0:c}" >
                                            <ItemStyle Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Devendo" HeaderText="Devendo" 
                                            DataFormatString="{0:C}" >
                                            <ItemStyle Width="60px" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Total devedor:  <asp:Label ID="lblTotalDevedor" runat="server" ForeColor="Red" 
                                    style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                    </table>
                
                
                </div>
            </td>
        </tr>

        <tr>
            <td valign="top" colspan="3" >

                &nbsp;</td>
        </tr>

        <tr>
            <td valign="top" colspan="3" >

                <table width="100%">
                    <tr>
                        <td width="30%" valign="top">


                            <div class="data_section_header"><asp:Label ID="Label2" runat="server" Text="Grupo de Comparação"></asp:Label></div>
                            <div class="data_section">
                
                                <asp:GridView ID="grdClassificacao" runat="server" AutoGenerateColumns="False" 
                                    onrowdatabound="grdClassificacao_RowDataBound" 
                                    ondatabound="grdClassificacao_DataBound" 
                                    EmptyDataText="Você não tem nenhum grupo de comparação." 
                                    EnableModelValidation="True" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Posição">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPosicao" runat="server" Text="Label"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Posicao" HeaderText="Geral" >
                                            <ItemStyle CssClass="bolaoPosicao" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="imgLastPos" runat="server" />
                                                <asp:Label ID="lblLastPos" runat="server" Text='<%# Bind("LastPosicao") %>' 
                                                    Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="bolaoPosicao" />
                                        </asp:TemplateField>
            
                    
                                        <asp:BoundField DataField="UserName" HeaderText="Membro" />                                        
                                        <asp:BoundField DataField="TotalPontos" HeaderText="PT" >
                                            <HeaderStyle CssClass="bolaoPontos" Width="30px" />
                                            <ItemStyle CssClass="bolaoPontos" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                
                                <asp:LinkButton ID="lnkConfigurar" runat="server" onclick="lnkConfigurar_Click" 
                                    Font-Size="XX-Small">Configurar</asp:LinkButton>
                                

                            </div>
                        </td>

                        <td width="70%" valign="top">

                 
                            <div class="data_section_header"><asp:Label ID="lblProximasApostas" runat="server" Text="Próximas apostas"></asp:Label></div>
                            <div class="data_section">
                
                                
                                
                
                <asp:GridView ID="grdJogos" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="IDJogo" 
                    EmptyDataText="Não existem jogos." 
                    EnableViewState="False" style="font-size: x-small; text-align: left;" 
                    Width="100%" GridLines="None" EnableModelValidation="True">

                    <Columns>
                        <asp:BoundField DataField="Fase" HeaderText="Fase" Visible="False" />
                        <asp:BoundField DataField="DataJogo" HeaderText="Data" DataFormatString="{0:d}" >
                            <ItemStyle CssClass="jogoDia" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Estádio">
                            <ItemTemplate>
                                <asp:Label ID="lblEstadio" runat="server" Text='<%# Bind("Estadio") %>'></asp:Label>                
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoEstadio" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time1">
                            <ItemTemplate>
                                <asp:Label ID="lblTime1" runat="server" Text='<%# Bind("Time1Classificado") %>'></asp:Label>
                                <br />
                                <asp:Label ID="lblDescricaoTime1" runat="server" 
                                    Text='<%# Bind("DescricaoTime1") %>' 
                                    style="font-weight: 700; font-size: xx-small;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle CssClass="jogoTimeCasa" />
                        </asp:TemplateField>
                        <asp:ImageField DataAlternateTextField="Time1Classificado" 
                            DataAlternateTextFormatString="{0}" DataImageUrlField="Time1Classificado" 
                            DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                            <ItemStyle HorizontalAlign="Center" Width="5px" CssClass="jogoTimeImage" />
                        </asp:ImageField>
                        <asp:TemplateField HeaderText="Gols1">
                            <ItemTemplate>
                                <asp:Label ID="lblGolsTime1" runat="server" Text='<%# Bind("ApostaTime1") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle CssClass="jogoGols" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                                x
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoVersus" />
                        </asp:TemplateField>
                
                        <asp:TemplateField HeaderText="Gols2">
                            <ItemTemplate>
                                <asp:Label ID="lblGolsTime2" runat="server" Text='<%# Bind("ApostaTime2") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle CssClass="jogoGols" />
                        </asp:TemplateField>
                        <asp:ImageField DataAlternateTextField="Time2Classificado" 
                    DataAlternateTextFormatString="{0}" DataImageUrlField="Time2Classificado" 
                    DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                            <ItemStyle HorizontalAlign="Center" Width="5px" />
                        </asp:ImageField>
                        <asp:TemplateField HeaderText="Time2">
                            <ItemTemplate>
                                <asp:Label ID="lblTime2" runat="server" Text='<%# Bind("Time2Classificado") %>'></asp:Label>
                                <br />
                                <asp:Label ID="lblDescricaoTime2" runat="server" 
                                    Text='<%# Bind("DescricaoTime2") %>' 
                                    style="font-weight: 700; font-size: xx-small;"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle CssClass="jogoTimeFora" HorizontalAlign="Left" Width="100px" />
                        </asp:TemplateField>

                         <asp:HyperLinkField DataNavigateUrlFields="Campeonato,IDJogo" 
                                            DataNavigateUrlFormatString="~\Boloes\ApostasJogos.aspx?IDjogo={1}" 
                                            Text="&lt;img src=&quot;/Images/palpites.png&quot;&gt;"  HeaderText="ap.">
                                            <ItemStyle CssClass="jogoResultado" />
                                        </asp:HyperLinkField>  

                                         <asp:HyperLinkField DataNavigateUrlFields="Campeonato,IDJogo"
                                            DataNavigateUrlFormatString="~\Boloes\BolaoSimulacao.aspx?IDjogo={1}" 
                                            Text="&lt;img src=&quot;/Images/simulacao.png&quot;&gt;" HeaderText="sim.">
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







                            </div> 
                            <br />

                            <div class="data_section_header"><asp:Label ID="lblPontosObtidos" runat="server" Text="Pontos Obtidos"></asp:Label></div>
                            <div class="data_section">

                                <asp:GridView ID="grdPontosObtidos" runat="server" AutoGenerateColumns="False" 
                                    DataKeyNames="IDJogo" 
                                    EmptyDataText="Não existem jogos" 
                                    EnableViewState="False" style="font-size: x-small; text-align: left;" 
                                    Width="100%"  GridLines="None" EnableModelValidation="True">

                                    <Columns>
                                        <asp:BoundField DataField="OnlyDataJogo" HeaderText="Data" 
                                            DataFormatString="{0:d}" >
                                            <ItemStyle CssClass="jogoDia" />
                                        </asp:BoundField>                                        
                                        <asp:TemplateField HeaderText="Estádio">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEstadio" runat="server" Text='<%# Bind("Estadio") %>'></asp:Label>                
                                            </ItemTemplate>
                                            <ItemStyle CssClass="jogoEstadio" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Time1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTime1" runat="server" Text='<%# Bind("Time1Classificado") %>'></asp:Label>
                                                <br />
                                                <asp:Label ID="lblDescricaoTime1" runat="server" 
                                                    Text='<%# Bind("DescricaoTime1") %>' 
                                                    style="font-weight: 700; font-size: xx-small;"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle CssClass="jogoTimeCasa" />
                                        </asp:TemplateField>
                                        <asp:ImageField DataAlternateTextField="Time1Classificado" 
                                            DataAlternateTextFormatString="{0}" DataImageUrlField="Time1Classificado" 
                                            DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                                            <ItemStyle HorizontalAlign="Center" Width="5px" CssClass="jogoTimeImage" />
                                        </asp:ImageField>
                                        <asp:TemplateField HeaderText="Gols1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGolsTime1" runat="server" Text='<%# Bind("ApostaTime1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="jogoGols" />
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                x
                                            </ItemTemplate>
                                            <ItemStyle CssClass="jogoVersus" />
                                        </asp:TemplateField>                
                                        <asp:TemplateField HeaderText="Gols2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGolsTime2" runat="server" Text='<%# Bind("ApostaTime2") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="jogoGols" />
                                        </asp:TemplateField>
                                        <asp:ImageField DataAlternateTextField="Time2Classificado" 
                                    DataAlternateTextFormatString="{0}" DataImageUrlField="Time2Classificado" 
                                    DataImageUrlFormatString="~/Images/Database/Times/{0}.gif">
                                            <ItemStyle HorizontalAlign="Center" Width="5px" />
                                        </asp:ImageField>
                                        <asp:TemplateField HeaderText="Time2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTime2" runat="server" Text='<%# Bind("Time2Classificado") %>'></asp:Label>
                                                <br />
                                                <asp:Label ID="lblDescricaoTime2" runat="server" 
                                                    Text='<%# Bind("DescricaoTime2") %>' 
                                                    style="font-weight: 700; font-size: xx-small;"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle CssClass="jogoTimeFora" HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                                
                                        <asp:TemplateField HeaderText="Pontos">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPontos" runat="server" style="text-align: center"  Text='<%# Bind("Pontos") %>' ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle CssClass="jogoPontos" Font-Bold="True" HorizontalAlign="Center" 
                                                VerticalAlign="Middle" Font-Size="Medium" />
                                        </asp:TemplateField>
        
                                                  
            
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





                            </div>
                        
                            <br />
                            <div class="data_section_header"><asp:Label ID="lblMensagens" runat="server" Text="Mensagens"></asp:Label></div>
                            <div class="data_section">
                
                
                                <asp:GridView ID="grdMensagens" runat="server" AutoGenerateColumns="False" 
                                    EmptyDataText="Você não possui mensagens." style="font-size: 13px">
                                    <Columns>
                                        <asp:BoundField DataField="CreationDate" HeaderText="Data">
                                            <ItemStyle Width="140px" Height="40px"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Bolao" HeaderText="Bolao">
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FromUser" HeaderText="De">
                                            <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Title" HeaderText="Título" />
                                    </Columns>
                                </asp:GridView>
                
                
                            </div>

                        </td>
                    </tr>
                </table>

            </td>
        </tr>

    </table>
    
    
</asp:Content>
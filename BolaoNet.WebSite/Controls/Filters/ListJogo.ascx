<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListJogo.ascx.cs" Inherits="BolaoNet.WebSite.Controls.Filters.ListJogo" %>
<%@ Register src="FilterJogo.ascx" tagname="FilterJogo" tagprefix="uc1" %>

<script language="javascript" type="text/javascript">
    function isNumberKey(evt) {        
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;


        return true;
    }
    function onChangeText(textbox1, textbox2, radioButton1, radioButton2, grupo) {

        var text1 = document.getElementById(textbox1);
        var text2 = document.getElementById(textbox2);

        var radio1 = document.getElementById(radioButton1);
        var radio2 = document.getElementById(radioButton2);

        var grupoNome = document.getElementById(grupo);

        if (text1.value != text2.value) {

            radio1.style.visibility = "hidden";
            radio2.style.visibility = "hidden";

        }
        else {

            var myText = (grupoNome.innerText || grupoNome.textContent);

            if (myText == "" || myText  == " ") {

                radio1.style.visibility = "visible";
                radio2.style.visibility = "visible";

            }
        }
    }
</script>
<style type="text/css">
a
{
	color: #3399FF;
}
</style>
<uc1:FilterJogo ID="ctlFilterJogo" runat="server" />
<br />            
<asp:GridView ID="grdJogos" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="IDJogo" 
    ondatabinding="grdJogos_DataBinding" 
    onrowdatabound="grdJogos_RowDataBound" 
    EmptyDataText="Não foram encontrados jogos para o filtro selecionado" 
    EnableViewState="False" style="font-size: x-small; text-align: left;" 
    Width="100%" ondatabound="grdJogos_DataBound" GridLines="None" 
    EnableModelValidation="True">

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
        <asp:BoundField DataField="OnlyDataJogo" HeaderText="Data" 
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
        
        <asp:TemplateField HeaderText="Ap.">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lblAposta1" runat="server"  />
                    <asp:TextBox ID="txtAposta1" runat="server" Columns="1" MaxLength="2" SkinID=InputAposta  onkeypress="return isNumberKey(this);"   />
                </div>
            </ItemTemplate>
            <ItemStyle CssClass="jogoAposta" />
        </asp:TemplateField>
     
        
        
        <asp:TemplateField>
            <ItemTemplate>
                <table border="0">
                    <tr>
                        <td><asp:RadioButton ID="rdoTime1" runat="server" GroupName="Jogo" /></td>
                        <td>x</td>
                        <td><asp:RadioButton ID="rdoTime2" runat="server" GroupName="Jogo" /></td>
                    </tr>
                </table>        
            </ItemTemplate>
            <ItemStyle CssClass="jogoVersus" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Ap.">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lblAposta2" runat="server"  />
                    <asp:TextBox ID="txtAposta2" runat="server" Columns="1" MaxLength="2" SkinID=InputAposta onkeypress="return isNumberKey(this);" />
                </div>
            </ItemTemplate>
            <ItemStyle CssClass="jogoAposta" />
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
                <asp:Label ID="lblPontos" runat="server" style="text-align: center" ></asp:Label>
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
                <asp:Label ID="lblDataAposta" runat="server" />
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle CssClass="jogoDataAposta" />
        </asp:TemplateField>            
            
            
            
        <asp:HyperLinkField DataNavigateUrlFields="Campeonato,IDJogo" 
            DataNavigateUrlFormatString="~\Resultados\CampeonatoResultado.aspx?IDjogo={1}" 
            Text="&lt;img src=&quot;/Images/resultado.png&quot;&gt;" HeaderText="res" >
            <ItemStyle CssClass="jogoResultado" />
        </asp:HyperLinkField>   
        
        
        <asp:HyperLinkField DataNavigateUrlFields="Campeonato,IDJogo" 
            DataNavigateUrlFormatString="~\Boloes\ApostasJogos.aspx?IDjogo={1}" 
            Text="&lt;img src=&quot;/Images/palpites.png&quot;&gt;" 
            HeaderText="apostas"  >
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

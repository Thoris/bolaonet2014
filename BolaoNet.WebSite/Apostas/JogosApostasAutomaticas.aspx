<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.master" AutoEventWireup="true" CodeBehind="JogosApostasAutomaticas.aspx.cs" Inherits="BolaoNet.WebSite.Apostas.JogosApostasAutomaticas" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Ajax.Net" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuApostasControl.ascx" tagname="MenuApostasControl" tagprefix="uc3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" Runat="Server">
    <uc3:MenuApostasControl ID="MenuApostasControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" Runat="Server">
<script language="javascript" type="text/javascript">
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
</script>
<table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Apostas automáticas</asp:Label>
            </td>
            <td class="adminTools">
                <uc2:MenuTools ID="ctlMenuTools" runat="server" DeleteVisible="False" 
                    NextVisible="False" ReturnVisible="False" SaveVisible="True" 
                    AddVisible="False" />
            </td>
            <td class="adminHome">
                <uc1:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanelAuto" runat="server">
        <ContentTemplate>
        

            
            
            <asp:MultiView ID="MultiViewAuto" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewAuto" runat="server">
                
                    <div class="data_section_header"><asp:Label ID="lblTipoAposta" runat="server" Text="Tipo de Aposta"></asp:Label>
                        <asp:CustomValidator ID="cvTipoAposta" runat="server" 
                            EnableClientScript="False" 
                            ErrorMessage="O tipo de aposta precisa ser selecionado" 
                            onservervalidate="cvTipoAposta_ServerValidate">*</asp:CustomValidator>
                    </div>
                    <div class="data_section">    
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoDefault" runat="server" AutoPostBack="True" 
                                        GroupName="Tipo" oncheckedchanged="rdoDefault_CheckedChanged" 
                                        Text="Aposta padrão para todos os jogos" />
                                </td>                    
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoPeriodo" runat="server" AutoPostBack="True" 
                                        GroupName="Tipo" oncheckedchanged="rdoPeriodo_CheckedChanged" 
                                        Text="Apostas padrão para jogos durante um período" />
                                </td>                    
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoRodada" runat="server" AutoPostBack="True" 
                                        GroupName="Tipo" oncheckedchanged="rdoRodada_CheckedChanged" 
                                        Text="Apostas padrão para todos os jogos de uma rodada" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                    <br />
                    
                    <asp:MultiView ID="MultiViewApostasTipo" runat="server">
                        <asp:View ID="viewDefault" runat="server">
                        </asp:View>
                        <asp:View ID="viewPeriodo" runat="server">
                            <div class="data_section_header"><asp:Label ID="Label1" runat="server" Text="Período"></asp:Label></div>
                            <div class="data_section"> 
                                <table width="100%">
                                    <tr>
                                        <td width="30%">
                                            Data Inicial
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDataInicial" runat="server" Columns="11" MaxLength="10"></asp:TextBox>
                                            <rjs:PopCalendar ID="PopCalendarDataInicial" runat="server" AutoPostBack="True" 
                                                Control="txtDataInicial" 
                                                onselectionchanged="PopCalendarDataInicial_SelectionChanged" Separator="/" />
                                            <asp:RequiredFieldValidator ID="rfvDataInicial" runat="server" 
                                                ControlToValidate="txtDataInicial" 
                                                ErrorMessage="O filtro Data inicial deve estar preenchido">*</asp:RequiredFieldValidator>                                                
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Data Final
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDataFinal" runat="server" Columns="11" MaxLength="10"></asp:TextBox>
                                            <rjs:PopCalendar ID="PopCalendarDataFinal" runat="server" AutoPostBack="True" 
                                                Control="txtDataFinal" 
                                                onselectionchanged="PopCalendarDataFinal_SelectionChanged" Separator="/" />
                                            <asp:RequiredFieldValidator ID="rfvDataInicial0" runat="server" 
                                                ControlToValidate="txtDataInicial" 
                                                ErrorMessage="O filtro Data inicial deve estar preenchido">*</asp:RequiredFieldValidator>                                                
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Total
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalPeriodo" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div> 
                            

                        </asp:View>
                        <asp:View ID="viewRodada" runat="server">
                        
                        
                            <div class="data_section_header"><asp:Label ID="Label2" runat="server" Text="Rodada"></asp:Label></div>
                            <div class="data_section">
                                <table width="100%">
                                    <tr>
                                        <td width="30%">
                                            Rodada
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="cboRodadas" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="cboRodadas_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>   
                                    <tr>
                                        <td>
                                            Total
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalRodada" runat="server"></asp:Label>
                                        </td>
                                    
                                    </tr>      
                                
                                </table>                                                                       
                            </div>                                                                                                                               
                        </asp:View>
                    </asp:MultiView>

                    <br />
                    
                    <div class="data_section_header"><asp:Label ID="Label3" runat="server" 
                            Text="Tipo de Valor"></asp:Label>
                        <asp:CustomValidator ID="cvTipoValor" runat="server" EnableClientScript="False" 
                            ErrorMessage="O tipo de valor precisa ser selecionado" 
                            onservervalidate="cvTipoValor_ServerValidate">*</asp:CustomValidator>
                    </div>
                    <div class="data_section"> 
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoFixo" runat="server" Text="Valores Fixos" 
                                        AutoPostBack="True" GroupName="ValorTipo" 
                                        oncheckedchanged="rdoFixo_CheckedChanged" />                        
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoAleatorio" runat="server" Text="Valores Aleatórios" 
                                        AutoPostBack="True" GroupName="ValorTipo" 
                                        oncheckedchanged="rdoAleatorio_CheckedChanged" />                        
                                </td>                    
                            </tr>                
                        </table>            
                    </div>
                    
                    <br />
                    
                    <asp:MultiView ID="MultiViewTipoValores" runat="server">
                        <asp:View ID="viewValoresFixos" runat="server">
                        
                            <div class="data_section_header"><asp:Label ID="Label4" runat="server" 
                                    Text="Resultados fixos"></asp:Label></div>
                            <div class="data_section">                 
                                <table width="100%">
                                    <tr>
                                        <td width="30%">
                                            Time em casa:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTimeCasa" runat="server" Columns="5" MaxLength="2" onkeypress="return isNumberKey(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvTimeCasa" runat="server" 
                                                ControlToValidate="txtTimeCasa" EnableClientScript="False" 
                                                ErrorMessage="O Valor dos gols do time de casa deve ser preenchido">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Time fora de casa:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTimeFora" runat="server" Columns="5" MaxLength="2" onkeypress="return isNumberKey(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvTimeFora" runat="server" 
                                                ControlToValidate="txtTimeFora" EnableClientScript="False" 
                                                ErrorMessage="O Valor dos gols do time fora de casa deve ser preenchido">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        
                        </asp:View>
                        
                        <asp:View ID="viewValoresAleatorios" runat="server">
                        
                        
                            <div class="data_section_header"><asp:Label ID="Label5" runat="server" 
                                    Text="Resultados aleatórios"></asp:Label></div>
                            <div class="data_section">                 
                                <table width="100%">
                                    <tr>
                                        <td width="30%">
                                            Valor Inicial:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtValorInicial" runat="server" Columns="5" MaxLength="2" onkeypress="return isNumberKey(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvTimeCasa0" runat="server" 
                                                ControlToValidate="txtValorFinal" EnableClientScript="False" 
                                                ErrorMessage="O Valor inicial para geração dos gols deve ser preenchido">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Valor Final:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtValorFinal" runat="server" Columns="5" MaxLength="2" onkeypress="return isNumberKey(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvTimeCasa1" runat="server" 
                                                ControlToValidate="txtValorFinal" EnableClientScript="False" 
                                                ErrorMessage="O Valor final para geração dos gols deve ser preenchido">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        
                        </asp:View>
                    </asp:MultiView>            
                    
                    <br />
                
                    <div class="data_section_header"><asp:Label ID="Label6" runat="server" Text="Tipo de Atualização"></asp:Label>
                        <asp:CustomValidator ID="cvTipoAtualizacao" runat="server" 
                            EnableClientScript="False" 
                            ErrorMessage="O tipo de atualização precisa ser selecionado" 
                            onservervalidate="cvTipoAtualizacao_ServerValidate">*</asp:CustomValidator>
                    </div>
                    <div class="data_section">                 
                        <table width="100%">      
                            <tr>
                                <td width="50%">
                                    <asp:RadioButton ID="rdoTodasApostas" runat="server" 
                                        GroupName="TipoAtualizacao" Text="Aplicar a todas as apostas" 
                                        oncheckedchanged="rdoTodasApostas_CheckedChanged" AutoPostBack="True" />                        
                                </td>
                                <td width="20%">
                                    Total:
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalJogos" runat="server"></asp:Label>
                                </td>
                            </tr>     
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoNaoApostados" runat="server" 
                                        GroupName="TipoAtualizacao" Text="Aplicar a todos os jogos não apostados" 
                                        oncheckedchanged="rdoNaoApostados_CheckedChanged" AutoPostBack="True" />
                                </td>
                                <td>
                                    Total:
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalJogosNaoApostados" runat="server"></asp:Label>
                                </td>
                            </tr>   
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoApostados" runat="server" GroupName="TipoAtualizacao" 
                                        Text="Aplicar a todos os jogos já apostados" 
                                        oncheckedchanged="rdoApostados_CheckedChanged" AutoPostBack="True" />
                                </td>
                                <td>
                                    Total:
                                </td>
                                <td>
                                    <asp:Label ID="lbltotalJogosApostados" runat="server"></asp:Label>
                                </td>
                            </tr>                                      
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="2">
                                    <asp:MultiView ID="MultiViewApostas" runat="server" ActiveViewIndex="0">
                                        <asp:View ID="viewApostadosNull" runat="server">
                                        </asp:View>
                                        <asp:View ID="viewApostadosAutomatico" runat="server">
                                            <table cellspacing="1" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton ID="rdoApostadoTodos" runat="server" AutoPostBack="True" 
                                                            GroupName="Apostados" oncheckedchanged="rdoApostadoTodos_CheckedChanged" 
                                                            Text="Todas as apostas" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton ID="rdoApostadoAuto" runat="server" AutoPostBack="True" 
                                                            GroupName="Apostados" oncheckedchanged="rdoApostadoAuto_CheckedChanged" 
                                                            Text="Apostas automáticas" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton ID="rdoApostadoManual" runat="server" AutoPostBack="True" 
                                                            GroupName="Apostados" oncheckedchanged="rdoApostadoManual_CheckedChanged" 
                                                            Text="Apostas manuais" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                                
                
                    <div class="data_section">        
                    </div>
                    
                    
                    <table cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSalvar" runat="server" onclick="btnSalvar_Click" 
                                    Text="Salvar" />
                            </td>
                        </tr>
                    </table>                
                
                
                </asp:View>
                <asp:View ID="viewNoAutoAnymore" runat="server">
                    <br />
                    <br />
                    Você não pode mais realizar apostas automáticas<br />
                </asp:View>
            </asp:MultiView>
            
            
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
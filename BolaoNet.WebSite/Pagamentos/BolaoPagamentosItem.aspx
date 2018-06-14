<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoPagamentosItem.aspx.cs" Inherits="BolaoNet.WebSite.Pagamentos.BolaoPagamentosItem"  %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Ajax.Net" namespace="RJS.Web.WebControl" tagprefix="rjs" %>


<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>


<%@ Register src="../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc1" %>


<%@ Register src="../Controls/MenuBolaoAdminControl.ascx" tagname="MenuBolaoAdminControl" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc2:MenuBolaoAdminControl ID="MenuBolaoAdminControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">

    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">&nbsp;</td>
            <td class="adminTools">
                <uc3:MenuTools ID="ctlMenuTools" runat="server" AddVisible="false" 
                    DeleteVisible="false" NextVisible="False" ReturnVisible="True" 
                    SaveVisible="true" />
            </td>
            <td class="adminHome">
                <uc4:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">


    <div class="data_section_header"><asp:Label ID="lblAdminTools" runat="server" Text="Informações de Admin"></asp:Label></div>
    <div class="data_section"> 
       <table width="100%">
            <tr>
                <td align="left" valign="top" width="50%">
                    <table >
                        <tr>
                            <td>
                                <asp:Label ID="lblDescBolao"  SkinID=labelText runat="server" Text="Bolão:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBolao" runat="server" SkinID="labelValue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescDataPagamento"  SkinID=labelText runat="server" 
                                    Text="Data de Pagamento:"></asp:Label>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtDataPagamento" runat="server"></asp:TextBox>
                                <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtDataPagamento" 
                                    Separator="/" />
                                <asp:RequiredFieldValidator ID="rfvData" runat="server" 
                                    ControlToValidate="txtDataPagamento" EnableClientScript="False" 
                                    ErrorMessage="Não foi apontado a data do pagamento" 
                                    ValidationGroup="UpdateItem">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>                            
                </td>
                <td align="left" valign="top">
                    <table >
                        <tr>
                            <td>
                                <asp:Label ID="lblDescUserName"  SkinID=labelText runat="server" Text="Usuário:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cboUser" runat="server">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="cvUser" runat="server" ControlToValidate="cboUser" 
                                    EnableClientScript="False" ErrorMessage="Usuário não selecionado." 
                                    onservervalidate="cvUser_ServerValidate" ValidationGroup="UpdateItem">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescTipo"  SkinID=labelText runat="server" Text="Tipo:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cboTipoPagamento" runat="server">
                                    <asp:ListItem Value="0">&lt;Escolha&gt;</asp:ListItem>
                                    <asp:ListItem Value="1">Dinheiro</asp:ListItem>
                                    <asp:ListItem Value="2">Cheque</asp:ListItem>
                                    <asp:ListItem Value="3">Depósito</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CustomValidator ID="cvTipo" runat="server" 
                                    ControlToValidate="cboTipoPagamento" EnableClientScript="False" 
                                    ErrorMessage="Tipo de pagamento não selecionado" 
                                    onservervalidate="cvTipo_ServerValidate" ValidationGroup="UpdateItem">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescValor"  SkinID=labelText runat="server" Text="Valor:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvValor" runat="server" 
                                    ControlToValidate="txtValor" EnableClientScript="False" 
                                    ErrorMessage="Não foi apontado o valor do pagamento" 
                                    ValidationGroup="UpdateItem">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>  
                </td>
            </tr>
            <tr>
                <td colspan="2">
                
                    <asp:TextBox ID="txtDescricao" runat="server" Height="100px" MaxLength="255" 
                        TextMode="MultiLine" Width="90%"></asp:TextBox>
                
                    <br />
                
                </td>

            </tr>            
        </table>                            
    </div>

</asp:Content>

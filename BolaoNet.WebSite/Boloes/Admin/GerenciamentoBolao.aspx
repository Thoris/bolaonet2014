<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="GerenciamentoBolao.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.Admin.GerenciamentoBolao" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Ajax.Net" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<%@ Register src="../../Controls/MenuBolaoAdminControl.ascx" tagname="MenuBolaoAdminControl" tagprefix="uc1" %>


<%@ Register src="../../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuBolaoAdminControl ID="MenuBolaoAdminControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">&nbsp;</td>
            <td class="adminTools">
                <uc3:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="False" 
                    SaveVisible="True" />
            </td>
            <td class="adminHome">
                <uc4:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">


    <div class="data_section_header"><asp:Label ID="lblTitulo" runat="server" 
            Text="Dados do Bolão"></asp:Label></div>
    <div class="data_section">  
    
    
        <table width="100%">
            <tr>
                <td width="130px" align="left" valign="top">
                    
                    <asp:Image ID="imgUser" runat="server" BorderColor="#999999" BorderWidth="1px" 
                        Height="160px" ImageUrl="~/Images/noimage-usuario.jpg" Width="120px" />
                    <br />
                    <br />
                    
                </td>
                <td align="left" valign="top">
                   <table width="100%">
                        <tr>
                            <td width="220px">
                                <asp:Label ID="Label6" runat="server" SkinID="labelText" Text="Nome:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNome" runat="server" Columns="31" MaxLength="30"></asp:TextBox>
                                <asp:Label ID="lblNome" runat="server" SkinID="labelValue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" SkinID="labelText" Text="Cobertura:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cboCobertura" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="lblCobertura" runat="server" SkinID="labelValue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" SkinID="labelText" 
                                    Text="Permitir apostas depois de iniciado:"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkPermitirApostasDepois" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" SkinID="labelText" 
                                    Text="Horas permitidas antes do jogo:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHorasAllowed" runat="server" Columns="5" MaxLength="4"></asp:TextBox>
                                <asp:Label ID="lblHorasPermitidasAntes" runat="server" SkinID="labelValue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" SkinID="labelText" 
                                    Text="Data de início:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDataInicio" runat="server"></asp:TextBox>
                                <rjs:PopCalendar ID="PopCalendarBirthDate" runat="server" 
                                    Control="txtDataInicio" Separator="/" />
                                <asp:Label ID="lblDataInicio" runat="server" SkinID="labelValue"></asp:Label>
                                </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" SkinID="labelText" Text="Taxa:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTaxa" runat="server" Columns="10" MaxLength="9"></asp:TextBox>
                                <asp:Label ID="lblTaxa" runat="server" SkinID="labelValue"></asp:Label>
                                </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" SkinID="labelText" Text="Público:"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkPublico" runat="server" />
                                </td>
                        </tr>
                    </table>                 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                
                    <asp:FileUpload ID="fileUploadPicture" runat="server" />
                
                </td>
            </tr>
        </table>
    
    
        <table width="100%">
            <tr>
                <td width="50%" valign="top" align="left">
                    
                    <table class="style1">
                        <tr>
                            <td width="120px">
                                <asp:Label ID="Label1" runat="server" SkinID="labelText" Text="Bolão Iniciado:"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkIniciado" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" SkinID="labelText" Text="Data iniciado:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDataIniciado" runat="server" SkinID="labelValue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" SkinID="labelText" Text="Iniciado por:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblIniciadoPor" runat="server" SkinID="labelValue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" SkinID="labelText" Text="Forum ativado:"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkForumAtivado" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" SkinID="labelText" 
                                    Text="Permitir msg. anônimas:"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkPermitirMsgAnonimos" runat="server" />
                            </td>
                        </tr>
                    </table>
                    
                </td>
                <td valign="top" align="left">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescCountry" runat="server" SkinID="labelText" Text="País:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCountry" runat="server" Columns="26" MaxLength="25"></asp:TextBox>
                                <asp:Label ID="lblCountry" runat="server" SkinID="labelValue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescState" runat="server" SkinID="labelText" Text="Estado:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtState" runat="server" Columns="4" MaxLength="3"></asp:TextBox>
                                <asp:Label ID="lblState" runat="server" SkinID="labelValue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescCity" runat="server" SkinID="labelText" Text="Cidade:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server" Columns="51" MaxLength="50"></asp:TextBox>
                                <asp:Label ID="lblCity" runat="server" SkinID="labelValue"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="txtDescricao" runat="server" MaxLength="255" 
            TextMode="MultiLine" Width="100%"></asp:TextBox>
        <br />
    
    </div>


</asp:Content>

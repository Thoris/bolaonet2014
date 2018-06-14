<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="MensagensAdd.aspx.cs" Inherits="BolaoNet.WebSite.Mensagens.MensagensAdd"  %>

<%@ Register src="../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>



<%@ Register src="../Controls/MenuUserControl.ascx" tagname="MenuUserControl" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuUserControl ID="MenuUserControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable" width="100%">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Enviar mensagem</asp:Label>
            </td>
            <td class="adminTools">
                <uc3:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="True" 
                    SaveVisible="True" />
            </td>
            <td class="adminHome">
                <uc4:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="data_section_header">
                <asp:Label ID="Label1" runat="server" Text="Mensagem"></asp:Label>
            </div>
            <div class="data_section">
                <table style="width: 80%">
                    <tr>
                        <td>
                            <asp:Label ID="lblPara" runat="server" Text="Para:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboUsers" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="cboUsers_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td rowspan="6" width="1px">
                            <asp:Image ID="imgUser" runat="server" BorderColor="#999999" BorderWidth="1px" 
                                Height="160px" ImageUrl="~/Images/noimage-usuario.jpg" Width="120px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPrivate" runat="server" Text="Mensagem Privada:"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkPrivate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTitleText" runat="server" Text="Título"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtTitle" runat="server" Width="95%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" 
                                ControlToValidate="txtTitle" Display="Dynamic" EnableClientScript="False" 
                                ErrorMessage="O campo título precisa estar preenchido">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMessage" runat="server" Text="Mensagem"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox ID="txtMessage" runat="server" Height="100px" TextMode="MultiLine" 
                                Width="95%" Rows="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMessage" runat="server" 
                                ControlToValidate="txtMessage" Display="Dynamic" EnableClientScript="False" 
                                ErrorMessage="O Campo mensagem precisa ser preenchido">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    
    <table class="style1">
        <tr>
            <td align="center">
                            <asp:Button ID="btnEnviar" runat="server" onclick="btnEnviar_Click" 
                                Text="Enviar" />
                        </td>
        </tr>
    </table>
&nbsp;


</asp:Content>

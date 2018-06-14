<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.ascx.cs" Inherits="BolaoNet.WebSite.Controls.Views.UserInfo" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Ajax.Net" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
    
    
    
    <%@ Register src="AdminUserInfo.ascx" tagname="AdminUserInfo" tagprefix="uc1" %>
    
    
    
    <div class="data_section_header"><asp:Label ID="lblTitle" runat="server" Text="Dados do Usuário"></asp:Label></div>
    <div class="data_section">       

        <table width="100%">
        
            <tr >
                <td align="left" valign="top" width="130px" >
                    <asp:Image ID="imgUser" runat="server" Height="160px" 
                        ImageUrl="~/Images/noimage-usuario.jpg" Width="120px" 
                        BorderColor="#999999" BorderWidth="1px" />
                       <br />
                </td>
                <td align="left" valign="top"  >
                    <table >
                        <tr>
                            <td>
                                <asp:Label ID="lblDescUserName" runat="server" SkinID=labelText Text="Login:"></asp:Label>
                                </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" Columns="26" MaxLength="25" 
                                    Visible="False"></asp:TextBox>
                                <asp:Label ID="lblUserName" runat="server" SkinID=labelValue></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                                    ControlToValidate="txtUserName" 
                                    ErrorMessage="O campo login precisa ser preenchido" 
                                    InitialValue="*" EnableClientScript="False">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescFirstName" runat="server" SkinID=labelText Text="Primeiro Nome:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server" Columns="30" MaxLength="50"></asp:TextBox>
                                <asp:Label ID="lblFirstName" runat="server" SkinID=labelValue></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                                    ControlToValidate="txtFirstName" 
                                    ErrorMessage="O primeiro nome precisa ser preenchido" 
                                    EnableClientScript="False">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescMiddleName" runat="server" SkinID=labelText Text="Nome do meio:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMiddleName" runat="server" Columns="30" MaxLength="50"></asp:TextBox>
                                <asp:Label ID="lblMiddleName" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescLastName" runat="server" SkinID=labelText Text="Último Nome:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server" Columns="30" MaxLength="50"></asp:TextBox>
                                <asp:Label ID="lblLastName" runat="server" SkinID=labelValue></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                                    ControlToValidate="txtLastName" 
                                    ErrorMessage="O último nome precisa ser preenchido" 
                                    EnableClientScript="False">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSexo" runat="server" SkinID=labelText Text="Sexo:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cboSex" runat="server">
                                    <asp:ListItem Value="0">&lt;Select&gt;</asp:ListItem>
                                    <asp:ListItem Value="1">Masculino</asp:ListItem>
                                    <asp:ListItem Value="1">Feminino</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblSex" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        </table>
                </td>
                <td align="left" valign="top">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescBirthDate" runat="server" SkinID=labelText Text="Data de Aniversário:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBirthDate" runat="server"></asp:TextBox>
                                <rjs:PopCalendar ID="PopCalendarBirthDate" runat="server" 
                                    Control="txtBirthDate" Separator="/" />
                                <asp:Label ID="lblBirthDate" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescRG" runat="server"  SkinID=labelText Text="RG:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRG" runat="server" Columns="21" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="lblRG" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>                                    
                        <tr>
                            <td>
                                <asp:Label ID="lblDescCPF" runat="server"  SkinID=labelText Text="CPF:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCPF" runat="server" Columns="21" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="lblCPF" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>                                    
                        <tr>
                            <td>
                                <asp:Label ID="lblDescMaritalStatus" runat="server"  SkinID=labelText Text="Relacionamento:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cboMaritalStatus" runat="server">
                                    <asp:ListItem Value="0">&lt;Select&gt;</asp:ListItem>
                                    <asp:ListItem Value="1">Solteiro(a)</asp:ListItem>
                                    <asp:ListItem Value="2">Casado(a)</asp:ListItem>
                                    <asp:ListItem Value="3">Em um relacionamento</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblMarialStatus" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>                                    
                    </table>
                </td>
            </tr>
        
            <tr >
                <td align="left" valign="top" width="150px" colspan="3" >
                    <asp:FileUpload ID="fileUploadPicture" runat="server" />
                </td>
            </tr>
        </table>

    </div>        
    
    <br />
    
    <div class="data_section_header"><asp:Label ID="lblAddress" runat="server" Text="Endereço"></asp:Label></div>
    <div class="data_section">         
        <table width="100%">
            <tr>
                <td align="left" valign="top" width="50%">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescCountry" runat="server"  SkinID=labelText Text="País:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCountry" runat="server" Columns="26" MaxLength="25"></asp:TextBox>
                                            <asp:Label ID="lblCountry" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescState" runat="server"  SkinID=labelText Text="Estado:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtState" runat="server" Columns="4" MaxLength="3"></asp:TextBox>
                                            <asp:Label ID="lblState" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescCity" runat="server"  SkinID=labelText Text="Cidade:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server" Columns="51" MaxLength="50"></asp:TextBox>
                                            <asp:Label ID="lblCity" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescStreet" runat="server"  SkinID=labelText Text="Rua:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStreet" runat="server" Columns="51" MaxLength="50"></asp:TextBox>
                                            <asp:Label ID="lblStreet" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescNumber" runat="server"  SkinID=labelText Text="Número:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNumber" runat="server" Columns="7" MaxLength="6"></asp:TextBox>
                                            <asp:Label ID="lblNumber" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescPostalCode" runat="server"  SkinID=labelText Text="CEP:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblPostalCode" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="left" valign="top">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescCellPhone" runat="server"  SkinID=labelText Text="Telefone Celular:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCellPhone" runat="server" Columns="21" MaxLength="20"></asp:TextBox>
                                            <asp:Label ID="lblCellPhone" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescPhoneNumber" runat="server"  SkinID=labelText Text="Telefone Residencial:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhoneNumber" runat="server" Columns="21" MaxLength="20"></asp:TextBox>
                                            <asp:Label ID="lblPhoneNumber" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescCompanyPhone" runat="server"  SkinID=labelText Text="Telefone Comercial:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyPhone" runat="server" Columns="21" MaxLength="20"></asp:TextBox>
                                            <asp:Label ID="lblCompanyPhone" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    
    <br />

    <div class="data_section_header"><asp:Label ID="lblDescInternet" runat="server" Text="Dados de Internet"></asp:Label></div>
    <div class="data_section">       
 
        <table width="100%">
            <tr>
                <td>
                    <table >
                        <tr>
                            <td>
                                <asp:Label ID="lblDescEmail" runat="server"  SkinID=labelText Text="Email:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Columns="50" MaxLength="200"></asp:TextBox>
                                            <asp:Label ID="lblEmail" runat="server" SkinID=labelValue></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="O email precisa ser preenchido" 
                                    EnableClientScript="False">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                    ControlToValidate="txtEmail" 
                                    ErrorMessage="O email não possui um formáto válido" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    EnableClientScript="False">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescSkype" runat="server"  SkinID=labelText Text="Skype:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSkype" runat="server" Columns="50" MaxLength="100"></asp:TextBox>
                                            <asp:Label ID="lblSkype" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescMSN" runat="server"  SkinID=labelText Text="MSN:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMSN" runat="server" Columns="50" MaxLength="100"></asp:TextBox>
                                            <asp:Label ID="lblMSN" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescWebSite" runat="server"  SkinID=labelText Text="Web Site:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWebSite" runat="server" Columns="50" MaxLength="100"></asp:TextBox>
                                            <asp:Label ID="lblWebSite" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescReceiveEmails" runat="server"  SkinID=labelText 
                                    Text="Receber Notificações:"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkReceiveEmails" runat="server" />
                                            <asp:Label ID="lblReceiveEmails" runat="server" SkinID=labelValue></asp:Label>
                            </td>
                        </tr>
                        </table>
                </td>
            </tr>
        </table>
 
    </div>
    

    <br />
    
    <uc1:AdminUserInfo ID="ctlAdminUserInfo" runat="server" />

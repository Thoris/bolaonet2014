<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoCarregarExcel.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.Admin.BolaoCarregarExcel"  %>
<%@ Register src="../../Controls/MenuBolaoAdminControl.ascx" tagname="MenuBolaoAdminControl" tagprefix="uc1" %>
<%@ Register src="../../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuBolaoAdminControl ID="MenuBolaoAdminControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Carregamento de apostas através do arquivo excel.</asp:Label>
            </td>
            <td class="adminTools">
                <uc3:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="False" 
                    SaveVisible="False" />
            </td>
            <td class="adminHome">
                <uc4:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <%--<asp:UpdatePanel ID="UpdatePanelMain" runat="server">
        <ContentTemplate>--%>
        
            <table width=80% align="center">
                <tr>
                    <td>

                       
                        <div class="data_section_header">
                            <asp:Label ID="lblMessageTile" runat="server" 
                                Text="Dados do Usuário"></asp:Label></div>
                        <div class="data_section">       


                            <table>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblDescUserName0" runat="server" SkinID="labelText" 
                                            Text="Tipo de atualização:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdoList" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="rdoList_SelectedIndexChanged">
                                            <asp:ListItem Selected="True">Novo Usuário</asp:ListItem>
                                            <asp:ListItem>Usuário Existente</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>                            
                            </table>
                            
                            <br />
                            <asp:MultiView ID="MultiViewType" runat="server" ActiveViewIndex="0">
                            
                                <asp:View ID="viewNew" runat="server">
                                    
                                    <table class="style1" width="30%">
                                        <tr>
                                            <td width="150px">
                                                <asp:Label ID="lblDescUserName" runat="server" SkinID="labelText" Text="Login:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUserName" runat="server" Columns="26" MaxLength="25"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvLogin" runat="server" 
                                                    ControlToValidate="txtUserName" 
                                                    ErrorMessage="O campo login precisa ser preenchido">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDescNome" runat="server" SkinID="labelText" Text="Nome:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNome" runat="server" Columns="50" MaxLength="150"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvNome" runat="server" 
                                                    ControlToValidate="txtNome" ErrorMessage="O campo Nome precisa ser preenchido">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDescEmail" runat="server" SkinID="labelText" Text="Email:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" runat="server" Columns="50" MaxLength="200"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                                                    ControlToValidate="txtEmail" 
                                                    ErrorMessage="O campo Email precisa ser preenchido">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDescSenha" runat="server" SkinID="labelText" Text="Senha:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSenha" runat="server" Columns="26" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvSenha" runat="server" 
                                                    ControlToValidate="txtSenha" 
                                                    ErrorMessage="O campo Senha precisa ser preenchido">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDescConfirmSenha" runat="server" SkinID="labelText" 
                                                    Text="Confirmar:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtConfirmSenha" runat="server" Columns="26" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvConfirmar" runat="server" 
                                                    ControlToValidate="txtConfirmSenha" 
                                                    ErrorMessage="O campo Confirmar precisa ser preenchido">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        
                                        
                                        <tr>
                                            <td width="150px">
                                                <asp:Label ID="Label1" runat="server" SkinID="labelText" 
                                                    Text="Arquivo:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="FileUploadNewUser" runat="server" />
                                                <asp:CustomValidator ID="cvArquivoNew" runat="server" 
                                                    ControlToValidate="FileUploadNewUser" 
                                                    ErrorMessage="É necessário selecionar o arquivo." 
                                                    onservervalidate="cvArquivoNew_ServerValidate">*</asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                <asp:Button ID="btnSalvarNew" runat="server" onclick="btnSalvarNew_Click" 
                                                    onclientclick="return confirm('Deseja criar o usuário com as apostas do arquivo excel.?');" 
                                                    Text="Salvar" />
                                            </td>
                                        </tr>                                        
                                        
                                    </table>                                
                                    
                                
                                </asp:View>
                                
                                <asp:View ID="viewExisting" runat="server">
                                    <table class="style1" width="30%">
                                        <tr>
                                            <td width="150px">
                                                <asp:Label ID="lblDescUserName1" runat="server" SkinID="labelText" 
                                                    Text="Login:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="cboUsers" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        
                                        
                                        <tr>
                                            <td width="150px">
                                                <asp:Label ID="Label2" runat="server" SkinID="labelText" 
                                                    Text="Arquivo:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="FileUploadExisting" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                <asp:Button ID="btnSalvarExisting" runat="server" 
                                                    onclick="btnSalvarExisting_Click" Text="Salvar" 
                                                    onclientclick="return confirm('Deseja atribuir as apostas do excel para o usuário determinado?')" />
                                            </td>
                                        </tr>                                        
                                        
                                    </table>
                                </asp:View>
                            
                            </asp:MultiView>
                            <br />
                            <br />


                


                        </div>

                    </td>
                </tr>
            </table>
        
        <%--
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.master" AutoEventWireup="true" CodeBehind="RequestLogin.aspx.cs" Inherits="BolaoNet.WebSite.Visitante.RequestLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    
            <asp:MultiView ID="MultiViewNewLogin" runat="server" ActiveViewIndex="0">
                <asp:View runat="server" ID="FillRow">
                    <asp:DetailsView ID="dtvNewUser" runat="server" AutoGenerateRows="False" 
                        DefaultMode="Insert" ondatabound="dtvNewUser_DataBound">
                        <Fields>
                            <asp:TemplateField HeaderText="Dados Pessoais">
                                <HeaderTemplate>
                                    &nbsp;<asp:Label ID="lblTituloDadosPessoais" runat="server" Text="Dados Pessoais"></asp:Label>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="data_section_header" />
                                <ItemStyle CssClass="data_section_header" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Login (*)" SortExpression="LOGIN">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtLogin" runat="server" Columns="21" MaxLength="20" 
                                        Text='<%# Bind("UserName") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLogin" runat="server" 
                                        ControlToValidate="txtLogin" EnableClientScript="False" 
                                        ErrorMessage="O campo Login precisa ser preenchido">*</asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nome Completo (*)" SortExpression="FullName">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtNome" runat="server" Columns="60" MaxLength="150" 
                                        Text='<%# Bind("FullName") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNome" runat="server" 
                                        ControlToValidate="txtNome" EnableClientScript="False" 
                                        ErrorMessage="O campo Nome Completo precisa ser preenchido">*</asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sexo">
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="cboSexo" runat="server">
                                        <asp:ListItem>&lt;Selecione&gt;</asp:ListItem>
                                        <asp:ListItem Value="true">Masculino</asp:ListItem>
                                        <asp:ListItem Value="false">Feminino</asp:ListItem>
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data de Nascimento">
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="cboDia" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="cboMes" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="cboAno" runat="server">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvNascimento" runat="server" 
                                        EnableClientScript="False" ErrorMessage="Data de nascimento inválida" 
                                        OnServerValidate="cvNascimento_ServerValidate">*</asp:CustomValidator>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CPF" SortExpression="CPF" Visible="False">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtCPF" runat="server" Columns="21" MaxLength="20" 
                                        Text='<%# Bind("CPF") %>'></asp:TextBox>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dados do login">
                                <HeaderStyle CssClass="data_section_header" />
                                <ItemStyle CssClass="data_section_header" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email (*)" SortExpression="EMAIL">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtEmail" runat="server" Columns="60" MaxLength="150" 
                                        Text='<%# Bind("EMAIL") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                                        ControlToValidate="txtEmail" EnableClientScript="False" 
                                        ErrorMessage="O campo Email precisa ser preenchido">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                        ControlToValidate="txtEmail" ErrorMessage="O email não é válido" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Confirme seu email (*)">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtConfirmEmail" runat="server" Columns="60" MaxLength="150" 
                                        Text='<%# Bind("EMAIL") %>'></asp:TextBox>
                                    <asp:CustomValidator ID="cvEmail" runat="server" 
                                        ControlToValidate="txtConfirmEmail" EnableClientScript="False" 
                                        ErrorMessage="Confirmação de email não confere" 
                                        OnServerValidate="cvEmail_ServerValidate" ValidateEmptyText="True">*</asp:CustomValidator>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Senha (*)">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtSenha" runat="server" Columns="50" MaxLength="150" 
                                        Text='<%# Bind("EMAIL") %>' TextMode="Password"></asp:TextBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="rfvSenha" runat="server" 
                                        ControlToValidate="txtSenha" EnableClientScript="False" 
                                        ErrorMessage="O campo Senha precisa ser preenchido">*</asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Confirme sua senha (*)">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtConfirmSenha" runat="server" Columns="50" MaxLength="150" 
                                        Text='<%# Bind("EMAIL") %>' TextMode="Password"></asp:TextBox>
                                    <asp:CustomValidator ID="cvSenha" runat="server" 
                                        ControlToValidate="txtConfirmSenha" EnableClientScript="False" 
                                        ErrorMessage="Confirmação de senha não confere" 
                                        OnServerValidate="cvSenha_ServerValidate" ValidateEmptyText="True">*</asp:CustomValidator>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pergunta secreta (*)">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtPergunta" runat="server" Columns="60" MaxLength="255" 
                                        Text='<%# Bind("EMAIL") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPergunta" runat="server" 
                                        ControlToValidate="txtPergunta" EnableClientScript="False" 
                                        ErrorMessage="O campo Pergunta secreta precisa ser preenchido">*</asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Resposta (*)">
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtResposta" runat="server" Columns="60" MaxLength="255" 
                                        Text='<%# Bind("EMAIL") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvResposta" runat="server" 
                                        ControlToValidate="txtResposta" EnableClientScript="False" 
                                        ErrorMessage="O campo Resposta precisa ser preenchido">*</asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Termos de uso">
                                <HeaderStyle CssClass="data_section_header" />
                                <ItemStyle CssClass="data_section_header" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <InsertItemTemplate>
                                    Para ativar este serviço, leia atentamente as regras de uso<br />
                                    regras de uso
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <InsertItemTemplate>
                                    <asp:CheckBox ID="chkConcordo" runat="server" Text="Concordo com os termos" />
                                    <asp:CustomValidator ID="cvTermos" runat="server" EnableClientScript="False" 
                                        ErrorMessage="É necessário concordar com os termos para prosseguir" 
                                        OnServerValidate="cvTermos_ServerValidate">*</asp:CustomValidator>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <InsertItemTemplate>
                                    <asp:CheckBox ID="chkReceberNotificacao" runat="server" Checked="True" 
                                        Text="Quero receber notificação" />
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Digite o texto da mensagem" Visible="false">
                                <InsertItemTemplate>
                                    <asp:Image ID="imgCodigo" runat="server" ImageUrl="~/Visitante/JpegImage.aspx" />
                                </InsertItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtCodigo" runat="server" Columns="6" MaxLength="5" Visible="false"></asp:TextBox>
                                    <asp:Button ID="btnSalvar" runat="server" onclick="btnSalvar_Click" 
                                        Text="Salvar" />
                                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" 
                                        ControlToValidate="txtCodigo" EnableClientScript="False"  Enabled="false"
                                        ErrorMessage="Entre com o código para criar o usuário">*</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvCodigo" runat="server" ControlToValidate="txtCodigo" 
                                        EnableClientScript="False" ErrorMessage="O código digitado não é válido" Enabled="false"
                                        onservervalidate="cvCodigo_ServerValidate">*</asp:CustomValidator>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                        </Fields>
                    </asp:DetailsView>
                </asp:View>
                <asp:View ID="viewUserCreated" runat="server">
                    <br />
                    Usuário criado com sucesso.<br />
                    <br />
                    Um email foi enviado para que seu login possa ser ativado. Por favor, clique no 
                    link enviado no email.<br />
                    <br />
                    <asp:HyperLink ID="lnkVoltarLogin" runat="server" 
                        NavigateUrl="~/Visitante/Login.aspx">Voltar para a tela de login</asp:HyperLink>
                    <br />
                    <br />
                </asp:View>
                <asp:View ID="viewErrorMail" runat="server">
                
                    <br />
                    Usuário não foi criado pois não foi possível enviar um email para o usuário 
                    criado.<br />
                    <br />
                    <asp:Label ID="lblErrorSendMail" runat="server" 
                        style="font-weight: 700; color: #FF0000"></asp:Label>
                    <br />
                    <br />
                    <asp:HyperLink ID="lnkVoltarLogin0" runat="server" 
                        NavigateUrl="~/Visitante/Login.aspx">Voltar para a tela de login</asp:HyperLink>
                    <br />
                    <asp:LinkButton ID="lnkTenteNovamente" runat="server" 
                        onclick="lnkTenteNovamente_Click">Tentar Novamente</asp:LinkButton>
                    <br />
                    <br />
                    <br />
                
                </asp:View>
            </asp:MultiView>
        
</asp:Content>
        
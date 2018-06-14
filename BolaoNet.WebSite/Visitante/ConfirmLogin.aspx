<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.master" AutoEventWireup="true" CodeBehind="ConfirmLogin.aspx.cs" Inherits="BolaoNet.WebSite.Visitante.ConfirmLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">


    <asp:MultiView ID="MultiViewConfirm" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewFillData" runat="server">

            <div class="data_section_header"><asp:Label ID="lblTitle" runat="server" Text="Dados de Ativação"></asp:Label></div>
            <div class="data_section">    
                <asp:DetailsView ID="dtvLogin" runat="server" AutoGenerateRows="False" 
                    DefaultMode="Insert" Height="50px" Width="125px">
                    <Fields>
                        <asp:TemplateField HeaderText="Login">
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtLogin" runat="server" Columns="27" MaxLength="25"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLogin" runat="server" 
                                    ControlToValidate="txtLogin" 
                                    ErrorMessage="O campo login precisa ser preenchido" 
                                    EnableClientScript="False">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chave">
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtChave" runat="server" Columns="70" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvKey" runat="server" 
                                    ControlToValidate="txtChave" 
                                    ErrorMessage="O campo chave precisa ser preenchido" 
                                    EnableClientScript="False">*</asp:RequiredFieldValidator>
                            </InsertItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <InsertItemTemplate>
                                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" 
                                    onclick="btnConfirmar_Click" />
                            </InsertItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                </asp:DetailsView>    
                
                <br />

            </div>                    
        </asp:View>
        <asp:View ID="viewStatus" runat="server">
                

            <div class="data_section_header"><asp:Label ID="Label1" runat="server" Text="Dados do Usuário"></asp:Label></div>
            <div class="data_section">    
                <table align="center" cellpadding="0" cellspacing="0" style="width: 90%">
                    <tr>
                        <td style="width: 200px">
                            Login</td>
                        <td>
                            <asp:Label ID="lblLogin" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            Nome</td>
                        <td>
                            <asp:Label ID="lnlNome" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                                        
                </table>
            </div>

            <br />

            <div class="data_section_header"><asp:Label ID="Label2" runat="server" Text="Status do Usuário"></asp:Label></div>
            <div class="data_section">    
                <table align="center" cellpadding="0" cellspacing="0" style="width: 90%">                                                
                    <tr>
                        <td style="width: 200px">
                            &nbsp;</td>
                        <td>
                            <asp:CheckBox ID="chkAtivado" runat="server" Enabled="False" Text="Ativado" />
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            &nbsp;</td>
                        <td>
                            <asp:CheckBox ID="chkAprovado" runat="server" Enabled="False" Text="Aprovado" />
                        </td>
                        
                    </tr>
                </table>
            </div>

            <br />

            <div class="data_section_header"><asp:Label ID="Label3" runat="server" Text="Status da Confirmação"></asp:Label></div>
            <div class="data_section">    

                <table align="center" cellpadding="0" cellspacing="0" style="width: 90%">                        
                    
                    
                    <tr>
                        <td style="width: 200px">
                            Chave</td>
                        <td>
                            <asp:Label ID="lblChave" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            Data/Hora de requisição</td>
                        <td>
                            <asp:Label ID="lblDataRequisicao" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            Data/Hora de resposta</td>
                        <td>
                            <asp:Label ID="lblDataResposta" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            Status</td>
                        <td>
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width: 200px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                </table>
            </div>                    
                
        
            <br />
            <br />
                

            <asp:LinkButton ID="lnkTentarNovamente" runat="server" 
                onclick="lnkTentarNovamente_Click">Tentar novamente</asp:LinkButton>
                <br />
            <asp:HyperLink ID="lnkVoltarLogin" runat="server" 
                NavigateUrl="~/Visitante/Login.aspx">Voltar para a tela de login</asp:HyperLink>                    
                
            
        </asp:View>
    </asp:MultiView>
        
    
</asp:Content>

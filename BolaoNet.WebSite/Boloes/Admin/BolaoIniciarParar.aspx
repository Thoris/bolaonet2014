<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoIniciarParar.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.Admin.BolaoIniciarParar"  %>
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
                <asp:Label ID="lblTitle" runat="server">Gerenciamento de início de bolão</asp:Label>
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
    <asp:UpdatePanel ID="UpdatePanelMain" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkDownloadBolaoPDF" />
            <asp:PostBackTrigger ControlID="lnkDownloadBolaoZIP" />
            <asp:PostBackTrigger ControlID="lnkDownloadBolaoPDFFim" />
            <asp:PostBackTrigger ControlID="lnkDownloadBolaoZIPFim" />
        </Triggers>
        <ContentTemplate>
        
            <table width=80% align="center">
                <tr>
                    <td>

                       
                        <div class="data_section_header"><asp:Label ID="lblMessageTile" runat="server" 
                                Text="Dados do bolão"></asp:Label></div>
                        <div class="data_section">       


                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDescLabelStatus" runat="server" Text="Status:" 
                                            SkinID="labelText"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStatus" runat="server" SkinID="labelValue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDescLabelIniciadoPor" runat="server" SkinID="labelText" 
                                            Text="Iniciado Por:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIniciadoPor" runat="server" SkinID="labelValue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDescLabelDataInicio" runat="server" SkinID="labelText" 
                                            Text="Data Início:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDataInicio" runat="server" SkinID="labelValue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnIniciar" runat="server" onclick="btnIniciar_Click" 
                                            Text="Iniciar" 
                                            
                                            onclientclick="return confirm('Deseja iniciar o bolão, isto pode implicar em bloqueios de apostas dos usuários.')" />
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="btnVoltar" runat="server" onclick="btnVoltar_Click" 
                                            Text="Aguardar" 
                                            
                                            onclientclick="return confirm('Deseja deixar o bolão em situação de aguardando início do bolão, isto pode implicar em bloqueios de apostas dos usuários.')" />
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
                                        <asp:Button ID="btnGerarApostas" runat="server" onclick="btnGerarApostas_Click" 
                                            Text="Gerar Apostas" />
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="btnEnviarEmails" runat="server" onclick="btnEnviarEmails_Click" 
                                            Text="Enviar Apostas" 
                                            onclientclick="return confirm('Deseja enviar as apostas para todos os usuários?')" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:LinkButton ID="lnkDownloadBolaoPDF" runat="server" 
                                            onclick="lnkDownloadBolaoPDF_Click">Download</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:LinkButton ID="lnkDownloadBolaoZIP" runat="server" 
                                            onclick="lnkDownloadBolaoZIP_Click">Download</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnGerarApostasFinais" runat="server" 
                                            onclick="btnGerarApostasFinais_Click" Text="Gerar Resultados Finais" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:LinkButton ID="lnkDownloadBolaoPDFFim" runat="server" 
                                            onclick="lnkDownloadBolaoPDFFim_Click">Download</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:LinkButton ID="lnkDownloadBolaoZIPFim" runat="server" 
                                            onclick="lnkDownloadBolaoZIPFim_Click">Download</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnEnviarPagamentos" runat="server" 
                                            onclick="btnEnviarPagamentos_Click" Text="Enviar Não Pago" onclientclick="return confirm('Deseja enviar email de falta de pagamento a todos os usuários que ainda não pagaram?')" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnEnviarApostasNaoFeitas" runat="server" 
                                            onclick="btnEnviarApostasNaoFeitas_Click" Text="Enviar Apostas Faltantes" onclientclick="return confirm('Deseja enviar alerta de email para os usuários que ainda não finalizaram as apostas?')" />
                                    </td>
                                </tr>
                            </table>


                        </div>

                    </td>
                </tr>
            </table>
        
        
            <br />
            <br />
            <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" 
                onrowdeleting="grdUsers_RowDeleting" 
                onrowdatabound="grdUsers_RowDataBound" style="font-size: x-small">
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="Login" />
                    <asp:BoundField DataField="FullName" HeaderText="UserName" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField HeaderText="Restantes" DataField="ApostasRestantes" />
                    <asp:CheckBoxField HeaderText="Pago" DataField="IsPago" InsertVisible="False" 
                        ReadOnly="True" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkDownload" runat="server" Target="_blank">Download</asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="5px" />
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" >
                        <ItemStyle Width="5px" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
        
        
            <br />
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <table align="center" width="80%">
                    <tr>
                        <td>
                            <div class="data_section_header">
                                <asp:Label ID="Label1" runat="server" Text="Dados do bolão"></asp:Label>
                            </div>
                            <div class="data_section">
                                <table class="style1" width="20%">
                                    <tr>
                                        <td width="20%">
                                            <asp:Label ID="lblDescLabelStatus1" runat="server" SkinID="labelText" 
                                                Text="UserName:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUserName" runat="server" Width="95%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                                                ControlToValidate="txtUserName" ErrorMessage="O Campo user name é requerido" 
                                                ValidationGroup="InsertItem">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDescLabelStatus2" runat="server" SkinID="labelText" 
                                                Text="Email:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="InsertItem" 
                                                Width="95%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                                                ControlToValidate="txtEmail" ErrorMessage="O Campo email é requerido" 
                                                ValidationGroup="InsertItem">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td align="right">
                                            <asp:Button ID="btnInserir" runat="server" onclick="btnInserir_Click" 
                                                Text="Inserir" ValidationGroup="InsertItem" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            
            
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

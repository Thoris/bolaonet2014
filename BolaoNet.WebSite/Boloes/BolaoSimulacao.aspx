<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoSimulacao.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.BolaoSimulacao"  %>

<%@ Register src="../Controls/Filters/ListJogo.ascx" tagname="ListJogo" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc2" %>


<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>




<%@ Register src="../Controls/JogoDetail.ascx" tagname="JogoDetail" tagprefix="uc5" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc2:MenuBolaoControl ID="MenuBolaoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">

    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Simulação de Apostas</asp:Label>
            </td>
            <td class="adminTools">
                <uc3:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="True" 
                    SaveVisible="False" />
            </td>
            <td class="adminHome">
                <uc4:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:UpdatePanel ID="UpdatePanelJogos" runat="server">
        <ContentTemplate>


            <table align="center" class="style1">
                <tr>
                    <td align="center">
                        <uc5:JogoDetail ID="ctlJogoDetail" runat="server" JogoMode="Result" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSimular" runat="server" Text="Simular" 
                            onclick="btnSimular_Click" />
                        &nbsp;
                        <asp:Button ID="btnLimpar" runat="server" onclick="btnLimpar_Click" 
                            Text="Limpar" />
                    </td>
                </tr>
            </table>
            <br />
        

            <div class="data_section_header"><asp:Label ID="lblFiltro" runat="server" 
                    Text="Pontuação"></asp:Label></div>
            <div class="data_section">             
        
            
                <asp:GridView ID="grdJogosUsuarios" runat="server" AutoGenerateColumns="False" 
                    ondatabound="grdJogosUsuarios_DataBound" 
                    onrowdatabound="grdJogosUsuarios_RowDataBound" 
                    ondatabinding="grdJogosUsuarios_DataBinding" EnableModelValidation="True" >
                    <Columns>
                        <asp:BoundField DataField="Posicao" HeaderText="Pos" >
                            <ItemStyle CssClass="bolaoPosicao" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgLastPos" runat="server" />
                                <asp:Label ID="lblLastPos" runat="server" Text='<%# Bind("LastPosicao") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="bolaoPosicao" />
                        </asp:TemplateField>                    
                        <asp:BoundField DataField="UserName" 
                HeaderText="UserName" />
            
                        <asp:BoundField DataField="TotalPontos" HeaderText="Pontos" />
                        <asp:BoundField DataField="ApostaTime1" 
                HeaderText="T1" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                x
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ApostaTime2" 
                HeaderText="T2" />
                        <asp:BoundField DataField="Pontos" HeaderText="P">
                            <ItemStyle Font-Bold="True" HorizontalAlign="Center" 
                    VerticalAlign="Middle" Width="30px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="A">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkAuto" runat="server" 
                        Checked='<%# Bind("Automatico") %>' Enabled="false" />
                            </ItemTemplate>
                            <ItemStyle CssClass="jogoApostaAuto" />
                        </asp:TemplateField>
                        <asp:CheckBoxField DataField="IsEmpate" HeaderText="E" 
                ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsVitoria" HeaderText="V" 
                ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsDerrota" HeaderText="D" 
                ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsGolsGanhador" 
                HeaderText="GG" ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsGolsPerdedor" 
                HeaderText="GP" ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsResultTime1" 
                HeaderText="RT1" ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsResultTime2" 
                HeaderText="RT2" ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsVde" HeaderText="VDE" 
                ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsErro" HeaderText="ERR" 
                ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsGolsGanhadorFora" 
                HeaderText="GGF" ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsGolsGanhadorDentro" 
                HeaderText="GGD" ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsGolsPerdedorFora" 
                HeaderText="GPF" ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsGolsPerdedorDentro" 
                HeaderText="GPD" ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsGolsEmpate" 
                HeaderText="GE" ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsGolsTime1" 
                HeaderText="GT1" ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsGolsTime2" 
                HeaderText="GT2" ReadOnly="True" Visible="False" />
                        <asp:CheckBoxField DataField="IsPlacarCheio" 
                HeaderText="C" ReadOnly="True" Visible="False" />
                        <asp:TemplateField HeaderText="Auxiliar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsMultiploTime" runat="server" 
                        Checked='<%# Eval("IsMultiploTime") %>' Enabled="False" />
                                <asp:Label ID="lblMultiplo" runat="server" 
                        Text='<%# Eval ("MultiploTime") %>' Visible='<%# Eval("IsMultiploTime") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="DataAposta" 
                HeaderText="DataAposta">
                            <ItemStyle CssClass="jogoDataAposta" Font-Size="XX-Small" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

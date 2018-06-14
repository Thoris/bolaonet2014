<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ApostasJogos.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.ApostasJogos"  %>
<%@ Register src="../Controls/JogoDetail.ascx" tagname="JogoDetail" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc2" %>


<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc2:MenuBolaoControl ID="MenuBolaoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
<table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Apostas do jogo</asp:Label>
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
    <br />
    <table align="center" cellspacing="1" class="style1">
        <tr>
            <td width="30px">
                &nbsp;</td>
            <td>
    <uc1:JogoDetail ID="ctlJogoDetail" runat="server" JogoMode="ReadOnly" />
                <br />
            </td>
            <td width="30px">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    
            <table style="width: 348px; font-size: x-small;" align="center">
                <tr>
                    <td width="30%">Time1: <asp:Label ID="lblPorcentTime1" runat="server" Text="0"></asp:Label> </td>
                    <td width="30%">Empate: <asp:Label ID="lblPorcentEmpate" runat="server" Text="0"></asp:Label> </td>
                    <td width="30%">Time2: <asp:Label ID="lblPorcentTime2" runat="server" Text="0"></asp:Label> </td>
                </tr>
            </table>
    
    <div class="data_section_header"><asp:Label ID="lblTitulo" runat="server">Apostas dos Usuários</asp:Label></div>
    <div class="data_section">    
         
    
    <asp:GridView ID="grdJogosUsuarios" runat="server" AutoGenerateColumns="False" 
            ondatabinding="grdJogosUsuarios_DataBinding" 
            onrowdatabound="grdJogosUsuarios_RowDataBound" 
            EnableModelValidation="True" ondatabound="grdJogosUsuarios_DataBound">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="UserName" />
            <asp:ImageField DataAlternateTextField="NomeTimeResult1" 
                DataAlternateTextFormatString="{0}" DataImageUrlField="NomeTimeResult1" 
                DataImageUrlFormatString="~/Images/Database/Times/{0}.gif" HeaderText="Ap.User">
                <ItemStyle Width="5px" />
            </asp:ImageField>
            <asp:BoundField DataField="ApostaTime1" HeaderText="T1" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    x
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ApostaTime2" HeaderText="T2" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:ImageField DataAlternateTextField="NomeTimeResult2" 
                DataAlternateTextFormatString="{0}" DataImageUrlField="NomeTimeResult2" 
                DataImageUrlFormatString="~/Images/Database/Times/{0}.gif" HeaderText="Ap.User">
                <ItemStyle Width="5px" />
            </asp:ImageField>
            <asp:BoundField DataField="Pontos" HeaderText="P" >
                <ItemStyle Width="30px" Font-Bold="True" HorizontalAlign="Center" 
                    VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="A">
                <ItemTemplate>
                    <asp:CheckBox ID="chkAuto" runat="server" Checked='<%# Bind("Automatico") %>' 
                        Enabled="false" />
                </ItemTemplate>
                <ItemStyle CssClass="jogoApostaAuto" />
            </asp:TemplateField>
            <asp:CheckBoxField DataField="IsEmpate" HeaderText="E" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsVitoria" HeaderText="V" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsDerrota" HeaderText="D" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsGolsGanhador" HeaderText="GG" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsGolsPerdedor" HeaderText="GP" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsResultTime1" HeaderText="RT1" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsResultTime2" HeaderText="RT2" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsVde" HeaderText="VDE" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsErro" HeaderText="ERR" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsGolsGanhadorFora" HeaderText="GGF" 
                ReadOnly="True" Visible="False" />
            <asp:CheckBoxField DataField="IsGolsGanhadorDentro" HeaderText="GGD" 
                ReadOnly="True" Visible="False" />
            <asp:CheckBoxField DataField="IsGolsPerdedorFora" HeaderText="GPF" 
                ReadOnly="True" Visible="False" />
            <asp:CheckBoxField DataField="IsGolsPerdedorDentro" HeaderText="GPD" 
                ReadOnly="True" Visible="False" />
            <asp:CheckBoxField DataField="IsGolsEmpate" HeaderText="GE" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsGolsTime1" HeaderText="GT1" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsGolsTime2" HeaderText="GT2" ReadOnly="True" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsPlacarCheio" HeaderText="C" ReadOnly="True" 
                Visible="False" />
            <asp:TemplateField HeaderText="Auxiliar">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsMultiploTime" runat="server" 
                        Checked='<%# Eval("IsMultiploTime") %>' Enabled="False" />
                    <asp:Label ID="lblMultiplo" runat="server" Text='<%# Eval ("MultiploTime") %>' 
                        Visible='<%# Eval("IsMultiploTime") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10px" />
            </asp:TemplateField>
            <asp:BoundField DataField="DataAposta" HeaderText="DataAposta" >
                <ItemStyle CssClass="jogoDataAposta" Font-Size="XX-Small" />
            </asp:BoundField>
            <asp:BoundField HeaderText="%" />
        </Columns>
    </asp:GridView>
    </div>
    <br />
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JogoDetail.ascx.cs" Inherits="BolaoNet.WebSite.Controls.JogoDetail" %>


    
    <div class="data_section_header"><asp:Label ID="lblTitulo" runat="server"></asp:Label></div>
    <div class="data_section" style="font-family: 'Arial Narrow'; font-size: 15px">    
        <table width=100% cellpadding="0" cellspacing="0">
            <tr bgcolor="#EEFCFD">
                <td width="50%">
                    Fase:<asp:Label ID="lblFase" runat="server"></asp:Label></td>
                <td>
                    Grupo:<asp:Label ID="lblGrupo" runat="server"></asp:Label></td>
                <td width="150px">
                    Rodada:<asp:Label ID="lblRodada" runat="server"></asp:Label></td>
            </tr>
        </table>
        <table width=100% cellpadding="0" cellspacing="0">
            <tr bgcolor="#DDDDDD">
                <td width="200px">
                    Data: <asp:Label ID="lblDataJogo" runat="server"></asp:Label>
                </td>
                <td>
                    Estádio:<asp:Label ID="lblEstadio" runat="server"></asp:Label></td>
            </tr>
        </table>
        <table width=100% cellspacing="0" cellpadding="0">
            <tr bgcolor="#EAF7FF">
                <td width="200px" >
                    Hora:  <asp:Label ID="lblHoraJogo" runat="server"></asp:Label>
                </td>
                <td align="right">
                    <asp:Label ID="lblTime1" runat="server"></asp:Label>
                </td>
                <td align="center" width="45px" style="text-align: center" >
                    <asp:Image ID="imgTime1" runat="server" style="text-align: center" />
                </td>
                <td align="center" width="20px" >
                    <asp:Label ID="lblGols1" runat="server"></asp:Label>
                    <asp:TextBox ID="txtGols1" runat="server" Columns="2" MaxLength="2" 
                        SkinID="InputResult"></asp:TextBox>
                </td>
                <td align="center" width="5px">
                    x
                </td>
                <td align="center" width="20px" >
                    <asp:Label ID="lblGols2" runat="server"></asp:Label>
                    <asp:TextBox ID="txtGols2" runat="server" Columns="2" MaxLength="2" 
                        SkinID="InputResult"></asp:TextBox>
                </td>
                <td width="45px" style="text-align: center">
                    <asp:Image ID="imgTime2" runat="server" />
                </td>
                <td align="left">
                    <asp:Label ID="lblTime2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr bgcolor="#FFFFCC" id="cellPenaltis" runat="server">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td align="center">
                    <asp:Label ID="lblPenaltis1" runat="server"></asp:Label>
                    <asp:TextBox ID="txtPenaltis1" runat="server" Columns="2" MaxLength="2" 
                        SkinID="InputResult"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Label ID="lblPenaltis2" runat="server"></asp:Label>
                    <asp:TextBox ID="txtPenaltis2" runat="server" Columns="2" MaxLength="2" 
                        SkinID="InputResult"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr bgcolor="#ECFBFF">
                <td>
                    <asp:CheckBox ID="chkPenaltis" runat="server" AutoPostBack="True" 
                            oncheckedchanged="chkPenaltis_CheckedChanged" Text="Penaltis" />
                </td>
                <td colspan="3" align="center">
                    <asp:Label ID="lblDescricaoTime1" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td colspan="3" align="center">
                    <asp:Label ID="lblDescricaoTime2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table width=100% cellpadding="0" cellspacing="0">
            <tr bgcolor="#C1C1C1">
                <td width="200px">
                    <asp:CheckBox ID="chkValido" runat="server" Text="Jogo Válido" 
                        Enabled="False" />
                </td>
                <td>
                    Por:
                    <asp:Label ID="lblValidadoBy" runat="server"></asp:Label>
                </td>
                <td width="50%">
                    Data de Validação:
                    <asp:Label ID="lblDataValidacao" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Label ID="lblCampeonato" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblIDJogo" runat="server" Visible="False"></asp:Label>

    </div>
        
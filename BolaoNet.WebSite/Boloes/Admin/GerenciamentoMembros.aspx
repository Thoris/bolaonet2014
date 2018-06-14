<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="GerenciamentoMembros.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.Admin.GerenciamentoMembros"  %>

<%@ Register src="../../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc1" %>



<%@ Register src="../../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>
<%@ Register src="../../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>



<%@ Register src="../../Controls/MenuBolaoAdminControl.ascx" tagname="MenuBolaoAdminControl" tagprefix="uc4" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc4:MenuBolaoAdminControl ID="MenuBolaoAdminControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">

    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">&nbsp;</td>
            <td class="adminTools">
                
                <uc2:MenuTools ID="ctlMenuTools" runat="server" AddVisible="false"
                    DeleteVisible="false" NextVisible="false" ReturnVisible="false" SaveVisible="false" />
                
            </td>
            <td class="adminHome">
                
                <uc3:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
                
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="data_section_header">
        <asp:Label ID="lblRequisicoes" runat="server" 
            Text="Requisições Pendentes do bolão"></asp:Label>
    </div>
    <div class="data_section">
        <asp:GridView ID="grdRequests" runat="server" AutoGenerateColumns="False" 
            onrowdatabound="grdRequests_RowDataBound" 
            onrowcommand="grdRequests_RowCommand">
            <Columns>
                <asp:BoundField DataField="RequestID" HeaderText="RequestID" />
                <asp:BoundField DataField="NomeBolao" HeaderText="Bolão" Visible="False" />
                <asp:BoundField DataField="RequestedBy" HeaderText="RequestedBy" />
                <asp:BoundField DataField="RequestedDate" HeaderText="Data" />
                <asp:BoundField DataField="Owner" HeaderText="Owner" />
                <asp:BoundField DataField="AnsweredBy" HeaderText="AnsweredBy" 
                    Visible="False" />
                <asp:BoundField DataField="AnsweredDate" HeaderText="AnsweredDate" 
                    Visible="False" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkAprovar" runat="server" CausesValidation="false" 
                            CommandName="Aprovar" Text="Aprovar"></asp:LinkButton>
                        <asp:Label ID="lblStatus" runat="server" Text="Aguardando resposta" 
                            Visible="False"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="120px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkRejeitar" runat="server" CausesValidation="false" 
                            CommandName="Rejeitar" Text="Rejeitar"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <br />
    <div class="data_section_header">
        <asp:Label ID="Label1" runat="server" 
            Text="Convidar um novo membro"></asp:Label>
    </div>
    <div class="data_section">

    
    <table cellspacing="1" style="width: 100%">
        <tr>
            <td colspan="5">
                Search for users</td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 74px">
                Search by:</td>
            <td>
                <asp:DropDownList ID="cboSearchBy" runat="server">
                    <asp:ListItem Selected="True">UserName</asp:ListItem>
                    <asp:ListItem>Email</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                for</td>
            <td style="width: 144px">
                <asp:TextBox ID="txtTextToFind" runat="server"></asp:TextBox>
            </td>
            <td style="width: 100px">
                <asp:Button ID="btnFind" runat="server" Text="Find User" 
                    onclick="btnFind_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:LinkButton ID="lnkA" runat="server" onclick="lnkLetter_Click">A</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="lnkB" runat="server" onclick="lnkLetter_Click">B</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkC" runat="server" onclick="lnkLetter_Click">C</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkD" runat="server" onclick="lnkLetter_Click">D</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkE" runat="server" onclick="lnkLetter_Click">E</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkF" runat="server" onclick="lnkLetter_Click">F</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkG" runat="server" onclick="lnkLetter_Click">G</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkH" runat="server" onclick="lnkLetter_Click">H</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkI" runat="server" onclick="lnkLetter_Click">I</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkJ" runat="server" onclick="lnkLetter_Click">J</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkK" runat="server" onclick="lnkLetter_Click">K</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkL" runat="server" onclick="lnkLetter_Click">L</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkM" runat="server" onclick="lnkLetter_Click">M</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkN" runat="server" onclick="lnkLetter_Click">N</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkO" runat="server" onclick="lnkLetter_Click">O</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkP" runat="server" onclick="lnkLetter_Click">P</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkQ" runat="server" onclick="lnkLetter_Click">Q</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkR" runat="server" onclick="lnkLetter_Click">R</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkS" runat="server" onclick="lnkLetter_Click">S</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkT" runat="server" onclick="lnkLetter_Click">T</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkU" runat="server" onclick="lnkLetter_Click">U</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkV" runat="server" onclick="lnkLetter_Click">V</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkX" runat="server" onclick="lnkLetter_Click">X</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkW" runat="server" onclick="lnkLetter_Click">W</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkY" runat="server" onclick="lnkLetter_Click">Y</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkZ" runat="server" onclick="lnkLetter_Click">Z</asp:LinkButton></td>
            <td>
                </td>
        </tr>
        <tr>
            <td colspan="5" class="data_section_header">
                Users</td>
            <td class="data_section_header">
                Membros do Bolão</td>
        </tr>
        <tr>
            <td colspan="5" align="left" valign="top">
                <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" 
                    AllowPaging="True" DataKeyNames="UserName" 
                    EmptyDataText="There is no user found using the specified filter" 
                    onrowdatabound="grdUsers_RowDataBound" >
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="UserName" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkConvidar" runat="server" CausesValidation="false" 
                                    CommandName="" Text="Convidar" onclick="lnkConvidar_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td align="left" valign="top">
                <asp:GridView ID="grdUserBolao" runat="server" AutoGenerateColumns="False" 
                    onrowdatabound="grdUserBolao_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="UserName" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRemover" runat="server" CausesValidation="false" 
                                    CommandName="" onclick="lnkRemover_Click" Text="Remover" 
                                    onclientclick="return confirm('Deseja remover o usuário do bolão? Isto fará com que todas as apostas do usuário sejam excluí-das.');"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>    
</div>    
    
</asp:Content>

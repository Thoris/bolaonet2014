<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoCriteriosPontos.aspx.cs" Inherits="BolaoNet.WebSite.Pontuacao.BolaoCriteriosPontos" %>



<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc3" %>



<%@ Register src="../Controls/MenuBolaoAdminControl.ascx" tagname="MenuBolaoAdminControl" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuBolaoAdminControl ID="MenuBolaoAdminControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">&nbsp;</td>
            <td class="adminTools">
                <uc2:MenuTools ID="ctlMenuTools" runat="server" AddVisible="False" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="False" 
                    SaveVisible="True" />
            </td>
            <td class="adminHome">
                <uc3:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div class="data_section_header"><asp:Label ID="lblCriterios" runat="server" Text="Critérios dos pontos do bolão"></asp:Label></div>
    <div class="data_section">  


    <asp:GridView ID="grdCriterios" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="grdCriterios_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Bolao" HeaderText="Bolão" Visible="False" />
            <asp:BoundField DataField="CriterioID" HeaderText="CriterioID" />
            <asp:TemplateField HeaderText="Pontos">
                <ItemTemplate>
                    <asp:Label ID="lblPontos" runat="server" Text='<%# Bind("Pontos") %>' Visible="False"></asp:Label>
                    <asp:TextBox ID="txtPontos" runat="server" Columns="4" MaxLength="3" 
                        Text='<%# Bind("Pontos") %>' SkinID="InputResult"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:TemplateField HeaderText="Time Jogado">
                <ItemTemplate>
                    <asp:Label ID="lblNomeTime" runat="server" Text='<%# Bind("Time") %>' Visible="false"></asp:Label>
                    <asp:DropDownList ID="cboNomeTime" runat="server"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Multiplo">
                <ItemTemplate>
                    <asp:Label ID="lblMultiplo" runat="server" Text='<%# Bind("MultiploTime") %>' Visible="False"></asp:Label>
                    <asp:TextBox ID="txtMultiplo" runat="server" Columns="4" MaxLength="3" Text='<%# Bind("MultiploTime") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>--%>            
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
            <asp:BoundField DataField="ModifiedDate" HeaderText="Data Modificação" 
                Visible="False" />
            <asp:BoundField DataField="ModifiedBy" HeaderText="Modificado Por" 
                Visible="False" />
        </Columns>
    </asp:GridView>
    
    
    </div>
    <br />
    <br />
    
    <div class="data_section_header"><asp:Label ID="lblTimes" runat="server" Text="Acréscimos de pontos dos times"></asp:Label></div>
    <div class="data_section">  


        <asp:GridView ID="grdTimes" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Times">
                    <ItemTemplate>
                        <asp:Label ID="lblTime" runat="server" Text='<%# Bind("Time") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Time") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Multiplo">
                    <ItemTemplate>
                        <asp:Label ID="lblMultiplo" runat="server" Text='<%# Bind("MultiploTime") %>' 
                            Visible="False"></asp:Label>
                        <asp:TextBox ID="txtMultiplo" runat="server" Columns="3" MaxLength="2" 
                            Text='<%# Bind("MultiploTime") %>' SkinID="InputResult"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


    </div>
    
    
</asp:Content>

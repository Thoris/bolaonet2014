<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoPagamentos.aspx.cs" Inherits="BolaoNet.WebSite.Pagamentos.BolaoPagamentos"  %>


<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>
<%@ Register src="../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuBolaoAdminControl.ascx" tagname="MenuBolaoAdminControl" tagprefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc2:MenuBolaoAdminControl ID="MenuBolaoAdminControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Pagamentos</asp:Label>
            </td>
            <td class="adminTools">
                <uc3:MenuTools ID="ctlMenuTools" runat="server" AddVisible="true" 
                    DeleteVisible="False" NextVisible="False" ReturnVisible="false" 
                    SaveVisible="False" />
            </td>
            <td class="adminHome">
                <uc4:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="grdPagamentos" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Bolao,UserName,DataPagamento" 
        onrowcommand="grdPagamentos_RowCommand">
        <Columns>
            <asp:BoundField DataField="NomeBolao" HeaderText="Bolão" Visible="False" />
            <asp:BoundField DataField="UserName" HeaderText="Usuário" />
            <asp:BoundField DataField="DataPagamento" HeaderText="Data" />
            <asp:BoundField DataField="TipoPagamento" HeaderText="Tipo" />
            <asp:BoundField DataField="Valor" HeaderText="Valor" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnView" runat="server" ImageUrl="~/Images/View.gif" CommandName="ViewDetails" CommandArgument='<%#  "Bolao=" + DataBinder.Eval(Container.DataItem, "Bolao") + "&UserName=" + DataBinder.Eval(Container.DataItem, "UserName")+ "&DataPagamento=" + DataBinder.Eval(Container.DataItem, "DataPagamento")+ "&Mode=4" %>' AlternateText="Visualizar detalhes do registro" />
                </ItemTemplate>      
                <ItemStyle Width="5px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Edit.gif" CommandName="EditItem" CommandArgument='<%# "Bolao=" + DataBinder.Eval(Container.DataItem, "Bolao") + "&UserName=" + DataBinder.Eval(Container.DataItem, "UserName")+ "&DataPagamento=" + DataBinder.Eval(Container.DataItem, "DataPagamento")+ "&Mode=2" %>' AlternateText="Editar registro"/>
                </ItemTemplate>
                <ItemStyle Width="5px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/Delete.gif" 
                        CommandName="DeleteItem" 
                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Bolao") + "|" + DataBinder.Eval(Container.DataItem, "UserName") + "|" + DataBinder.Eval(Container.DataItem, "DataPagamento")%>' 
                        AlternateText="Excluir registro" 
                        onclientclick="return confirm(&quot;Deseja excluir este pagamento?&quot;)" 
                        oncommand="ibtnDelete_Command" />
                </ItemTemplate>
                <ItemStyle Width="5px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

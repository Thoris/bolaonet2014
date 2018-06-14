<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoClassificacaoGrupoManager.aspx.cs" Inherits="BolaoNet.WebSite.Users.BolaoClassificacaoGrupoManager" %>
<%@ Register src="../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc1" %>
<%@ Register src="../Controls/MenuApostasControl.ascx" tagname="MenuApostasControl" tagprefix="uc2" %>
<%@ Register src="../Controls/MenuUserControl.ascx" tagname="MenuUserControl" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc3:MenuUserControl ID="MenuUserControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <table width="100%">
        <tr>
            <td align="left" valign="top" width="50%">
            
                <div class="data_section_header"><asp:Label ID="Label2" runat="server" Text="Grupo de Comparação"></asp:Label></div>
                <div class="data_section">
                
                    <asp:GridView ID="grdSelecionados" runat="server" AutoGenerateColumns="False" 
                        onrowdatabound="grdSelecionados_RowDataBound" 
                        EnableModelValidation="True" 
                        EmptyDataText="Você não possui nenhum usuário selecionado." 
                        onrowcommand="grdSelecionados_RowCommand" >
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="Membro" />
                            <asp:BoundField DataField="FullName" HeaderText="Nome" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemove" runat="server">Remover</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>        
            
                </div>

            </td>

            <td align="right" valign="top" width="50%">
                <asp:GridView ID="grdClassificacao" runat="server" AutoGenerateColumns="False" 
                    onrowdatabound="grdClassificacao_RowDataBound" 
                    EnableModelValidation="True" onrowcommand="grdClassificacao_RowCommand" >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkAdd" runat="server">Adicionar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                        <asp:BoundField DataField="UserName" HeaderText="Membro" />
                        <asp:BoundField DataField="FullName" HeaderText="Nome" />
                        <asp:BoundField DataField="TotalPontos" HeaderText="Pontos" >
                        <HeaderStyle CssClass="bolaoPontos" Width="30px" />
                        <ItemStyle CssClass="bolaoPontos" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>        
            </td>
        </tr>
    </table>

</asp:Content>

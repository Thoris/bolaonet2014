<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="UsersInRoles.aspx.cs" Inherits="BolaoNet.WebSite.Users.Admin.Roles.UsersInRoles"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellspacing="1" style="width: 100%">
        <tr>
            <td style="width: 50%" width="50%">
                Select a Role:
                <asp:DropDownList ID="cboRoles" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="cboRoles_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="data_section_header">
                                        Find a user</td>
                                    <td class="data_section_header">
                                        Users in Role:  
                                        <asp:Label ID="lblRoleSelected" runat="server" style="font-weight: 700"></asp:Label>
        <tr>
            <td style="width: 306px">
                &nbsp;</td>
            <td>
                <asp:GridView ID="grdUsersInRole" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="UserName">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="UserName" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                                    CommandName="" Text="Remove User"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

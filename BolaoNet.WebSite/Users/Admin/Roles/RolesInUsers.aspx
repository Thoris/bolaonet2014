<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="RolesInUsers.aspx.cs" Inherits="BolaoNet.WebSite.Users.Admin.Roles.RolesInUsers"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellspacing="1" style="width: 100%">
        <tr>
            <td colspan="5">
                Search for users</td>
            <td>
                &nbsp;</td>
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
                Roles</td>
        </tr>
        <tr>
            <td colspan="5" align="left" valign="top">
                <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" 
                    AllowPaging="True" DataKeyNames="UserName" 
                    EmptyDataText="There is no user found using the specified filter" 
                    onpageindexchanging="grdUsers_PageIndexChanging" 
                    onrowdatabound="grdUsers_RowDataBound" PageSize="50" 
                    style="margin-right: 0px">
                    <Columns>
                        <asp:TemplateField HeaderText="Approved">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsApproved" runat="server" AutoPostBack="True" 
                                    Checked='<%# Bind("IsApproved") %>' 
                                    oncheckedchanged="chkIsApproved_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IsLocked">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsLockedOut" runat="server" 
                                    Checked='<%# Bind("IsLockedOut") %>' AutoPostBack="True" 
                                    oncheckedchanged="chkIsLockedOut_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UserName">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditRoles" runat="server" CausesValidation="false" 
                                    CommandName="" onclick="lnkEditRoles_Click" Text="Edit Roles"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td align="left" valign="top">
                Selected User:                 <asp:Label ID="lblSelectedUser" runat="server" style="font-weight: 700"></asp:Label>
                <br />
                <asp:CheckBoxList ID="chklRoles" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="chklRoles_SelectedIndexChanged">
                </asp:CheckBoxList>
            </td>
        </tr>
    </table>
</asp:Content>

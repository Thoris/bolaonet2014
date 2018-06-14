<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="BolaoNet.WebSite.ErrorPage"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <h2>
        Application Error</h2>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server"><b>Um erro inesperado ocorreu com o Bolão Net:</b></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <%= DateTime.Now.ToLongDateString() %>
                &nbsp;<%= DateTime.Now.ToLongTimeString() %>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ErrorMessage" runat="server" EnableViewState="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ContactLabel" runat="server" EnableViewState="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

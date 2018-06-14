<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ReleaseNotes.aspx.cs" Inherits="BolaoNet.WebSite.Visitante.ReleaseNotes"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <br />
    <table style="width: 100%">
        <tr>
            <td width="15px">
                &nbsp;</td>
            <td>
    <asp:Label ID="lblNotes" runat="server" style="text-align: left" Width="100%" 
                    SkinID="labelText"></asp:Label>
            </td>
            <td width="15px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

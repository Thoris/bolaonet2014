<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BolaoAdminHome.aspx.cs" Inherits="BolaoNet.WebSite.Boloes.Admin.BolaoAdminHome"  %>
<%@ Register src="../../Controls/MenuBolaoAdminControl.ascx" tagname="MenuBolaoAdminControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuBolaoAdminControl ID="MenuBolaoAdminControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
</asp:Content>

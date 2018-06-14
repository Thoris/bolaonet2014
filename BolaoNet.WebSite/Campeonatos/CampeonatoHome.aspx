<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CampeonatoHome.aspx.cs" Inherits="BolaoNet.WebSite.Campeonatos.CampeonatoHome"  %>
<%@ Register src="../Controls/MenuCampeonatoControl.ascx" tagname="MenuCampeonatoControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc1:MenuCampeonatoControl ID="MenuCampeonatoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
</asp:Content>

<%@Page Language="C#" ValidateRequest="false"MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CampeonatoResultado.aspx.cs" Inherits="BolaoNet.WebSite.Resultados.CampeonatoResultado"  %>


<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc1" %>

<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc2" %>

<%@ Register src="../Controls/JogoDetail.ascx" tagname="JogoDetail" tagprefix="uc3" %>

<%@ Register src="../Controls/MenuCampeonatoControl.ascx" tagname="MenuCampeonatoControl" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">



    <uc4:MenuCampeonatoControl ID="MenuCampeonatoControl1" runat="server" />



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">

    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">&nbsp;</td>
            <td class="adminTools">
                <uc2:MenuTools ID="ctlMenuTools" runat="server" DeleteVisible="False" 
                    NextVisible="False" ReturnVisible="True" SaveVisible="True" 
                    AddVisible="False" />
            </td>
            <td class="adminHome">
                <uc1:NavigateHomeControl ID="ctlNavigateHomeControl" runat="server" />
            </td>
        </tr>
    </table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanelJogo" runat="server">
        <ContentTemplate>
    
    <p>
        <uc3:JogoDetail ID="JogoDetail" runat="server" />
    </p>
    
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>

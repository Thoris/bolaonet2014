<%@ Page Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Mensagens.aspx.cs" Inherits="BolaoNet.WebSite.Mensagens.Mensagens"  %>

<%@ Register src="../Controls/MenuManager/MenuTools.ascx" tagname="MenuTools" tagprefix="uc3" %>
<%@ Register src="../Controls/MenuManager/NavigateHomeControl.ascx" tagname="NavigateHomeControl" tagprefix="uc4" %>
<%@ Register src="../Controls/MenuBolaoControl.ascx" tagname="MenuBolaoControl" tagprefix="uc1" %>


<%@ Register src="../Controls/MenuUserControl.ascx" tagname="MenuUserControl" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
    <uc2:MenuUserControl ID="MenuUserControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
    <table class="adminTable">
        <tr>
            <td class="welcome-message" colspan="2">
                <asp:Label ID="lblTitle" runat="server">Mensagens</asp:Label>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DataList ID="dtlMessages" runat="server" HorizontalAlign="Center" 
                Width="95%" onitemcommand="dtlMessages_ItemCommand" 
                onitemdatabound="dtlMessages_ItemDataBound" Caption="Mural de recados">
                <ItemTemplate>
                
                
                
                    <div class="data_section_header"><asp:Label ID="lblTitleMessage" runat="server" Text="Mensagem"></asp:Label></div>
                    <div class="data_section">  
                
                
                    <table width="100%" bgcolor="#BFDAFF">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblLogin" runat="server" Text='<%# Eval("FromUser") %>' 
                                    style="font-weight: 700"></asp:Label>
                            </td>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDescDe" runat="server" Text="De:" SkinID="labelText"></asp:Label>
                                        </td>
                                        <td width="50%" bgcolor="White" align="center">
                                            <asp:Label ID="lblDe" runat="server" Text='<%# Eval("FromFullName") %>' 
                                                SkinID="labelValue"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDescData" runat="server" Text="Data:" SkinID="labelText"></asp:Label>
                                        </td>
                                        <td bgcolor="White" align="center">
                                            <asp:Label ID="lblData" runat="server" Text='<%# Eval("CreationDate") %>' 
                                                SkinID="labelValue"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top" width="130px">
                                <asp:Image ID="imgUser" runat="server" BorderColor="#999999" BorderWidth="1px" 
                                    Height="160px" ImageUrl="~/Images/noimage-usuario.jpg" Width="120px" />
                            </td>
                            <td valign="top">
                                <table width="100%">
                                    <tr>
                                        <td bgcolor="White">
                                            <asp:Label ID="lblTitle" runat="server" SkinID="labelValue" 
                                                style="font-weight: 700" Text='<%# Eval("Title") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="White" height="100px" valign="top">
                                            <asp:Label ID="lblMessage" runat="server" SkinID="labelValue" 
                                                Text='<%# Eval("Message") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="100%">
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" 
                                                onclick="lnkDelete_Click" 
                                                onclientclick="return confirm(&quot;Deseja excluir esta mensagem?&quot;)">Excluir Mensagem</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <p>
                    
                    </div>
                    
                </ItemTemplate>
            </asp:DataList>
            <br />
            <asp:Label ID="lblSemMensagens" runat="server" style="font-size: large" 
                Text="Você não possui recados" Visible="False"></asp:Label>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

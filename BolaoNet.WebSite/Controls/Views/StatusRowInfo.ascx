<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatusRowInfo.ascx.cs" Inherits="BolaoNet.WebSite.Controls.Views.StatusRowInfo" %>



   <div class="data_section_header"><asp:Label ID="lblDescRow" runat="server" Text="Informações do Registro"></asp:Label></div>
   <div class="data_section">       
        <table width="100%" >
            <tr>
                <td width="50%">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescCreatedBy"  SkinID=labelText runat="server" Text="Created By:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCreatedBy" SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescCreatedDate" runat="server"  SkinID=labelText Text="Created Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCreatedDate" SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescActiveFlag" runat="server" SkinID=labelText  Text="Active Flag"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblActiveFlag" SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescModifiedBy" runat="server"  SkinID=labelText Text="Modified By:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblModifiedBy" SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescModifiedDate" runat="server"  SkinID=labelText Text="Modified Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblModifiedDate"  SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>                
                </td>
            </tr>
        </table>   
   </div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminUserInfo.ascx.cs" Inherits="BolaoNet.WebSite.Controls.Views.AdminUserInfo" %>


    <%@ Register src="StatusRowInfo.ascx" tagname="StatusRowInfo" tagprefix="uc1" %>


    <div class="data_section_header"><asp:Label ID="lblAdminTools" runat="server" Text="Informações de Admin"></asp:Label></div>
    <div class="data_section">       
    
        <table width="100%">
            <tr>
                <td align="left" valign="top" width="50%">
                    <table >
                        <tr>
                            <td>
                                <asp:Label ID="lblDescIsLockedOut"  SkinID=labelText runat="server" Text="Is Locked:"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkIsLockedOut" runat="server" Enabled="False" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescLastLockoutDaet" runat="server"  SkinID=labelText Text="Last Lockout Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblLastLockoutDate"  SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblDescRequestedBy" runat="server"  SkinID=labelText Text="Requested By:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRequestedBy"  SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:Label ID="lblDescRequestedDate" runat="server" SkinID=labelText  Text="Requested Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRequestedDate"  SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        
                    </table>
                </td>
                <td align="left" valign="top">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescIsApproved" runat="server"  SkinID=labelText Text="Is Approved:"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkIsApproved" runat="server" Enabled="False" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescApprovedBy" runat="server"  SkinID=labelText Text="Approved By:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblApprovedBy" SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescApprovedDate" runat="server"  SkinID=labelText Text="Approved Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblApprovedDate"  SkinID=labelValue  runat="server"></asp:Label>
                            </td>
                        </tr>
                        </table>
                </td>
            </tr>
        </table>
    </div>
    
    <br />
    
    <div class="data_section_header"><asp:Label ID="lblAccessInfo" runat="server" Text="Informações de Acesso"></asp:Label></div>
    <div class="data_section">       
        <table width="100%">
            <tr>
                <td align="left" valign="top" width="50%">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescLastActivityDate" runat="server"  SkinID=labelText Text="Last Activity Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblLastActivityDate" SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescLastLoginDate" runat="server"  SkinID=labelText Text="Last login Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblLastLoginDate"  SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        </table>
                </td>
                <td align="left" valign="top">
                    <table>
                        <tr>
                            <td align="left" valign="top">
                                <asp:Label ID="lblDescLastPasswordChangedDate" runat="server"  SkinID=labelText Text="Last Password Changed Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblLastPasswordChangedDate"  SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescFailedPasswordAttemptCount" runat="server"  SkinID=labelText Text="Failed Password Attempt Count:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFailedPasswordAttemptCount"  SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescFailedPasswordAttemptDate" runat="server"  SkinID=labelText Text="Failed Password Attempt Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFailedPasswordAttemptDate"  SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescFailedPasswordAnswerAttemptCount"  SkinID=labelText runat="server" Text="Failed Password Answer Attempt Count:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFailedPasswordAnswerAttemptCount"  SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescFailedPasswordAnswerAttemptDate" runat="server" SkinID=labelText  Text="Failed Password Answer Attempt Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFailedPasswordAnswerAttemptDate"  SkinID=labelValue runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>   
   </div>    
    
    <br />
    
   <uc1:StatusRowInfo ID="ctlStatusRowInfo" runat="server" />
    
    
    
    
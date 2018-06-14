<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBConnectionTest.aspx.cs" Inherits="BolaoNet.WebSite.DBConnectionTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Connection Test</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblSqlServerCnnStr" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnTestSqlServer" runat="server" 
            onclick="btnTestSqlServer_Click" Text="Test Sql Server" />
        <br />
        <asp:Label ID="lblStatusSql" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btnLoadFactories" runat="server" 
            onclick="btnLoadFactories_Click" Text="Load Factories" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Label ID="lblStatusFactories" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lblCommonCnnStr" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnTestConnection" runat="server" 
            onclick="btnTestConnection_Click" Text="Test Sql Server" />
        <br />
        <asp:Label ID="lblStatusCommon" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lblSelect" runat="server">SELECT * FROM Users</asp:Label>
        <br />
        <asp:Button ID="btnTestWithSqlServer" runat="server" 
            onclick="btnTestWithSqlServer_Click" Text="Test Sql Server" />
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <asp:Label ID="lblStatusSelectSql" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnTestCommon" runat="server" 
            onclick="btnTestCommon_Click" Text="Test Common" />
        <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>
        <asp:Label ID="lblStatusSelectCommon" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btnTestInserCommand" runat="server" 
            onclick="btnTestInserCommand_Click" Text="Test Sql Insert/Update/Delete" />
        <br />
        <asp:Label ID="lblStatusIUDSql" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btnTestInsertCommon" runat="server" 
            onclick="btnTestInsertCommon_Click" 
            Text="Test Common Insert/Update/Delete" />
        <br />
        <asp:Label ID="lblStatusIUDCommon" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btnLoadUsers" runat="server" onclick="btnLoadUsers_Click" 
            Text="Provider Load User" />
        <asp:GridView ID="GridView4" runat="server">
        </asp:GridView>
        <asp:Label ID="lblStatusProviderUser" runat="server"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>

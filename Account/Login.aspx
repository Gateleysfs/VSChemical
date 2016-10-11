<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            width: 1225px;
            height: 158px;
            text-align: left;
            margin-left: 0px;
        }
        </style>
</head>
<body style="height: 28px; width: 1639px">
    <form id="form1" runat="server">
        <asp:Login ID="Login1" runat="server">
        </asp:Login>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" />
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                Please login to continue
            </AnonymousTemplate>
            <LoggedInTemplate>
                You are logged in
            </LoggedInTemplate>
        </asp:LoginView>
        <br />
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
    </form>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test(Delete).aspx.cs" Inherits="Test_Delete_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
    
    </div>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="height: 26px" Text="Button" />
        </p>
    </form>
</body>
</html>
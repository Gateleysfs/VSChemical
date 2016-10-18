﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Account_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LabelWelcome" runat="server" Text="Welcome"></asp:Label>
        <br />
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
        <br />
    </div>

    <div id="mainNav">
      <ul>
        <li><a href="Transaction.aspx">Make Transaction</a></li>
	    <li><a href="TransactionList.aspx">See Transactions</a></li>
	    <li><a href="Inventory.aspx">See Current Inventory</a></li>
      </ul>
    </div>

    </form>
</body>
</html>
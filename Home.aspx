﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Account_Default" %>

<!DOCTYPE html>
<link rel="stylesheet" href="BasicLayout.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            left: 0px;
            top: -1px;
            height: 128px;
        }
    </style>
</head>
<body id="PageBackGround">
    <form id="form1" runat="server">
    <div>
        <h1 id="Header" class="auto-style2">
            <br />
        <asp:Label ID="LabelWelcome" runat="server" Text="Welcome" Font-Bold="True" Font-Size="XX-Large" Font-Strikeout="False"></asp:Label>
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
        </h1>
        <img class="ImgRight" src="Images/sfs logo green transparent.png" alt="Superior Forestry Logo" width="140" height="98">
        <div>
        </div>
    </div>

    <div id="mainNav">

      <ul>
        <li><a href="Transaction.aspx">Add Transaction</a></li>
        <li><a href="TransactionList.aspx">Transactions List</a></li>
        <li><a href="Invoice.aspx">Add Invoice</a></li>
        <li><a href="InvoiceList.aspx">Invoices List</a></li>
	    <li><a href="Inventory.aspx">Current Inventory</a></li>
      </ul>
    </div>
    </form>
</body>

    <!-- Footer -->
<div  id="footer" class="PadTen SansSerif">
	<p class ="CenterText MarginFive">Superior Forestry Service <br/> P.O. Box 25 <br/> Tilly, AR 72679 <br/> 800.541.1060<br/>
	</p>
	<p class ="CenterText MarginFive"> 
		<a href="mailto:sfs@superiorforestry.com">sfs@superiorforestry.com</a><br/>
	</p>
	<p class ="MarginFive CenterText">
		©2016 Superior Forestry Service, Inc.
	</p>
</div>
</html>

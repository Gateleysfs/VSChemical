<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Account_Default" %>

<!DOCTYPE html>

<title>Home</title>

<link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

<link rel="stylesheet" href="BasicLayout.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
            .auto-style1 {
        position: absolute;
        left: 0;
        top: 0;
        height: 98px;
        width: 140px;
    }
        .auto-style2 {
            left: 0px;
            top: -1px;
            height: 128px;
        }
        .auto-style3 {
            font-size: xx-large;
        }
    </style>
</head>
<body id="PageBackGround">
    <form id="form1" runat="server">
        <h1 id="Header" class="auto-style2">
            <br />
            <asp:Label ID="LabelWelcome" runat="server" Text="Welcome" Font-Bold="True" Font-Size="XX-Large" Font-Strikeout="False"></asp:Label>
            <div class="ImgRight"><asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" /></div>
            <br />
            <br />
        <a href="Home.aspx">
            <img class="auto-style1" src="Images/sfs logo green transparent.png" alt="Superior Forestry Logo" width="140" height="98">
        </a>
        </h1>
        <div>
        </div>

    <div id="mainNav">

      <ul>
        <li><a href="Transaction.aspx">Add Transaction</a></li>
        <li><a href="TransactionList.aspx">Transactions List</a></li>
        <li><a href="Invoice.aspx">Add Invoice</a></li>
        <li><a href="InvoiceList.aspx">Invoices List</a></li>
	    <li><a href="Inventory.aspx">Current Inventory</a></li>
        <li><a href="TransactionbyDate.aspx">Rescent Transactions</a></li>
      </ul>
    </div>
        <div>
            <br>
            <br>
            <center><p class="auto-style3">In Development</p></center>
        </div>
    </form>

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
</body>
</html>

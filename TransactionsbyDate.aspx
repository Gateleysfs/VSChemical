<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransactionsbyDate.aspx.cs" Inherits="TransactionsbyDate" %>

<!DOCTYPE html>

<title>TransactionsbyDate</title>

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
    </style>
</head>
<body id="PageBackGround">
    <form id="form1" runat="server">
        <div id="Header" class="auto-style2">
            <br>
            <div>
                <h1>TransactionbyDate</h1>
            </div>
            <a href="Home.aspx">
            <img class="auto-style1" src="Images/sfs logo green transparent.png" alt="Superior Forestry Logo">
                </a>
            <div class="ImgRight">
                <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" /></div>
        </div>

    <div id="mainNav">
      <ul>
        <li><a href="Transaction.aspx">Add Transaction</a></li>
        <li><a href="TransactionList.aspx">Transactions List</a></li>
        <li><a href="Invoice.aspx">Add Invoice</a></li>
        <li><a href="InvoiceList.aspx">Invoices List</a></li>
	    <li><a href="Inventory.aspx">Current Inventory</a></li>
        <li><a href="TransactionsbyDate.aspx">TransactionsbyDate</a></li>
      </ul>
    </div>
        <div>
            <br>
            <br>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Barcode" HeaderText="Barcode" SortExpression="Barcode" />
                    <asp:BoundField DataField="ItemName" HeaderText="ItemName" SortExpression="ItemName" />
                    <asp:BoundField DataField="Employee" HeaderText="Employee" SortExpression="Employee" />
                    <asp:BoundField DataField="CrewNumber" HeaderText="CrewNumber" SortExpression="CrewNumber" />
                    <asp:BoundField DataField="Sender" HeaderText="Sender" SortExpression="Sender" />
                    <asp:BoundField DataField="Receiver" HeaderText="Receiver" SortExpression="Receiver" />
                    <asp:BoundField DataField="AmountLeft" HeaderText="AmountLeft" SortExpression="AmountLeft" />
                    <asp:BoundField DataField="ContainerSize" HeaderText="ContainerSize" SortExpression="ContainerSize" />
                    <asp:BoundField DataField="Measurement" HeaderText="Measurement" SortExpression="Measurement" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" />
                    <asp:BoundField DataField="Program" HeaderText="Program" SortExpression="Program" />
                    <asp:BoundField DataField="ContractID" HeaderText="ContractID" SortExpression="ContractID" />
                    <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
                </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="DarkGreen" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sfsBarcodeHolderConnectionString %>" SelectCommand="SELECT * FROM [tblInventoryTransactionscopy] ORDER BY [CreatedDate]"></asp:SqlDataSource>
            <br>
            <br>
        </div>
    </form>
</body>
</html>


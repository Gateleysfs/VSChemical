﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransactionList.aspx.cs" Inherits="TransactionList" %>

<!DOCTYPE html>

<title>Transaction List</title>
<link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

<link rel ="stylesheet" href="BasicLayout.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<body id="PageBackGround">
    <form id="form1" runat="server">
        <div id="Header" class="auto-style2">
            <br>
            <h1>Transaction List</h1>
            <a href="Home.aspx">
                        <img class="ImgRight" src="Images/sfs logo green transparent.png" alt="Superior Forestry Logo" width="140" height="98">
            </a>
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
    <div>
        <br>
        <br>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataSourceID="SqlDataSourceTransactionList" ForeColor="Black" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="ItemNo" HeaderText="ItemNo" SortExpression="ItemNo" />
                <asp:BoundField DataField="CrewNumber" HeaderText="CrewNumber" SortExpression="CrewNumber" />
                <asp:BoundField DataField="TransactionType" HeaderText="TransactionType" SortExpression="TransactionType" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Measurement" HeaderText="Measurement" SortExpression="Measurement" />
                <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" />
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
            <asp:SqlDataSource ID="SqlDataSourceTransactionList" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalTransactionListConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT  [tblInventoryTransactionsSFS].ID, Username, ItemNo, CrewNumber, TransactionType, Quantity, Measurement, CreatedDate, [tblInventoryTransactionsSFS].Comments
FROM [tblInventoryTransactionsSFS], [tblEmployeeSFS], [tblInventorySFS]
WHERE [tblInventoryTransactionsSFS].EmployeeId = [tblEmployeeSFS].UserID
AND [tblInventoryTransactionsSFS].TransactionItemId = [tblInventorySFS].ID
"></asp:SqlDataSource>
    </div>
    </form>

    </body>
</html>

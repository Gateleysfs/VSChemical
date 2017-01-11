<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransactionList.aspx.cs" Inherits="TransactionList" %>

<!DOCTYPE html>

<title>Transaction List</title>
<link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

<link rel ="stylesheet" href="BasicLayout.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<style type="text/css">
    .auto-style1 {
        position: absolute;
        left: 0;
        top: 0;
        height: 98px;
        width: 140px;
    }
</style>

<body id="PageBackGround">
    <form id="form1" runat="server">
         <div id="Header" class="auto-style2">
            <br>
            <div>
                <h1>Transaction List</h1>
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
      </ul>
     </div>
    <div>
        <br>
        <br>
        <div style="text-align:center">
            <asp:Panel id="pnlDefaultButton" runat="server" DefaultButton="ButtonSearch">
            <asp:DropDownList ID="DropDownListCategory" runat="server">
                <asp:ListItem>All</asp:ListItem>
                <asp:ListItem>ID</asp:ListItem>
                <asp:ListItem>ItemName</asp:ListItem>
                <asp:ListItem>Employee</asp:ListItem>
                <asp:ListItem>CrewNumber</asp:ListItem>
                <asp:ListItem>Sender</asp:ListItem>
                <asp:ListItem>Receiver</asp:ListItem>
                <asp:ListItem>AmountLeft</asp:ListItem>
                <asp:ListItem>ContainerSize</asp:ListItem>
                <asp:ListItem>Measurement</asp:ListItem>
                <asp:ListItem>CreatedDate</asp:ListItem>
                <asp:ListItem>Program</asp:ListItem>
                <asp:ListItem>Contract</asp:ListItem>
                <asp:ListItem>Comments</asp:ListItem>
            </asp:DropDownList>
        <asp:TextBox ID="txtSearch" runat="server" HorizontalAlign ="Center"></asp:TextBox>
        <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="Search" HorizontalAlign ="Center"/>
                </asp:Panel>
        </div>
        <br>
        <br>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="False" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="ID" HorizontalAlign="Center" >
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Employee" HeaderText="Employee" SortExpression="Employee" />
                <asp:BoundField DataField="ItemName" HeaderText="ItemName" SortExpression="ItemName" />
                <asp:BoundField DataField="CrewNumber" HeaderText="CrewNumber" SortExpression="CrewNumber" />
                <asp:BoundField DataField="Sender" HeaderText="Sender" SortExpression="Sender" />
                <asp:BoundField DataField="Receiver" HeaderText="Receiver" SortExpression="Receiver" />
                <asp:BoundField DataField="AmountLeft" HeaderText="AmountLeft" SortExpression="AmountLeft" />
                <asp:BoundField DataField="ContainerSize" HeaderText="ContainerSize" SortExpression="ContainerSize" />
                <asp:BoundField DataField="Measurement" HeaderText="Measurement" SortExpression="Measurement" />
                <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" />
                <asp:BoundField DataField="Program" HeaderText="Program" SortExpression="Program" />
                <asp:BoundField DataField="Contract" HeaderText="Contract" SortExpression="Contract" />
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

        <asp:SqlDataSource ID="SqlDataSourceTransactionList" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalTransactionListConnectionString %>" SelectCommand="SELECT  [tblInventoryTransactionsSFS].ID, Username, ItemNo, CrewNumber, TransactionType, Quantity, Measurement, CreatedDate, [tblInventoryTransactionsSFS].Comments FROM [tblInventoryTransactionsSFS], [tblEmployeeSFS], [tblInventorySFS] WHERE [tblInventoryTransactionsSFS].EmployeeId = [tblEmployeeSFS].UserID AND [tblInventoryTransactionsSFS].TransactionItemId = [tblInventorySFS].ID"></asp:SqlDataSource>
    </div>
    </form>

    </body>
</html>

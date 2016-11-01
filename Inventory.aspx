<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Account_Default" %>

<!DOCTYPE html>

<title>Inventory</title>
<link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

<link rel="stylesheet" href="BasicLayout.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<body id ="PageBackGround">
    <form id="form2" runat="server">
        <div id="Header" class="auto-style2">
                    <br>
                    <h1>Inventory</h1>
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
        <br>
        <br>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="ID" DataSourceID="SqlDataSourceInventory" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" InsertVisible="False" />
                <asp:BoundField DataField="InvNo" HeaderText="InvNo" SortExpression="InvNo" />
                <asp:BoundField DataField="Ordered" HeaderText="Ordered" SortExpression="Ordered" />
                <asp:BoundField DataField="Shipped" HeaderText="Shipped" SortExpression="Shipped" />
                <asp:BoundField DataField="ItemNo" HeaderText="ItemNo" SortExpression="ItemNo" />
                <asp:BoundField DataField="Prescription" HeaderText="Prescription" SortExpression="Prescription" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                <asp:BoundField DataField="ExtendedPrice" HeaderText="ExtendedPrice" SortExpression="ExtendedPrice" />
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                <asp:CheckBoxField DataField="PartialContainer" HeaderText="PartialContainer" SortExpression="PartialContainer" />
                <asp:BoundField DataField="ChemicalAmount" HeaderText="ChemicalAmount" SortExpression="ChemicalAmount" />
                <asp:BoundField DataField="ContainerType" HeaderText="ContainerType" SortExpression="ContainerType" />
                <asp:BoundField DataField="WetDry" HeaderText="WetDry" SortExpression="WetDry" />
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
    
        <asp:SqlDataSource ID="SqlDataSourceInventory" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalInventoryConnectionString %>" SelectCommand="SELECT * FROM [tblInventorySFS]" OnSelecting="SqlDataSourceInventory_Selecting"></asp:SqlDataSource>
    </form>
</body>
</html>

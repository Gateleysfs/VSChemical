<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Account_Default" %>

<!DOCTYPE html>

<head>

<title>Inventory</title>
<link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

<link rel="stylesheet" href="BasicLayout.css">
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
    </head>
<body id="PageBackGround">
    <form id="form2" runat="server">
        <div id="Header" class="auto-style2">
            <br>
            <div>
                <h1>Inventory</h1>
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
        <br>
        <br>
                    <asp:Panel id="pnlDefaultButton" runat="server" DefaultButton="ButtonSearch">
        <div style="text-align: center">
            <asp:DropDownList ID="DropDownListCategory" runat="server">
                <asp:ListItem>All</asp:ListItem>
                <asp:ListItem>ID</asp:ListItem>
                <asp:ListItem>ItemNo</asp:ListItem>
                <asp:ListItem>Prescription</asp:ListItem>
                <asp:ListItem>CurrentLocation</asp:ListItem>
                <asp:ListItem>ContainerCount</asp:ListItem>
                <asp:ListItem>AmountLeft</asp:ListItem>
                <asp:ListItem>ContainerType</asp:ListItem>
                <asp:ListItem>Total</asp:ListItem>
                <asp:ListItem>Category</asp:ListItem>
                <asp:ListItem>PartialContainer</asp:ListItem>
                <asp:ListItem>ContainerSize</asp:ListItem>
            </asp:DropDownList>
                <asp:TextBox ID="txtSearch" runat="server" HorizontalAlign="Center" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="Search" HorizontalAlign="Center" />
            </asp:Panel>

        </div>
        <br>
        <br>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="False" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="2" CellSpacing="2" DataKeyNames="ID" ForeColor="Black" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" InsertVisible="False" />
                <asp:BoundField DataField="ItemNo" HeaderText="ItemNo" SortExpression="ItemNo" />
                <asp:BoundField DataField="Prescription" HeaderText="Prescription" SortExpression="Prescription" />
                <asp:BoundField DataField="CurrentLocation" HeaderText="CurrentLocation" SortExpression="CurrentLocation" />
                <asp:BoundField DataField="ContainerCount" HeaderText="ContainerCount" SortExpression="ContainerCount" />
                <asp:BoundField DataField="AmountLeft" HeaderText="AmountLeft" SortExpression="AmountLeft" />
                <asp:BoundField DataField="ContainerType" HeaderText="ContainerType" SortExpression="ContainerType" />
                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:CheckBoxField DataField="PartialContainer" HeaderText="PartialContainer" SortExpression="PartialContainer" />
                <asp:BoundField DataField="ChemicalAmount" HeaderText="ContainerSize(ChemicalAmount)" SortExpression="ChemicalAmount" />
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

        <asp:SqlDataSource ID="SqlDataSourceInventory" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalInventoryConnectionString %>" SelectCommand="SELECT * FROM [tblInventorySFS]"></asp:SqlDataSource>
    </form>
</body>
</html>

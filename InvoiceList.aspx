<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoiceList.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<title>Invoice List</title>
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
<head runat="server">
    <title></title>
</head>
<body id="PageBackGround">
    <form id="form1" runat="server">
        <div id="Header" class="auto-style2">
            <br>
            <div>
                <h1>Invoice List</h1>
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
        <li><a href="TransactionbyDate.aspx">Rescent Transactions</a></li>
      </ul>
     </div>
        <br>
        <br>
        <asp:Panel id="pnlDefaultButton" runat="server" DefaultButton="ButtonSearch">
        <div style="text-align:center">
            <asp:DropDownList ID="DropDownListCategory" runat="server">
                <asp:ListItem>All</asp:ListItem>
                <asp:ListItem>ID</asp:ListItem>
                <asp:ListItem>InvNo</asp:ListItem>
                <asp:ListItem>Supplier</asp:ListItem>
                <asp:ListItem>OrderFrom</asp:ListItem>
                <asp:ListItem>OrderFrom</asp:ListItem>
                <asp:ListItem>InvDate</asp:ListItem>
                <asp:ListItem>ShippedVia</asp:ListItem>
                <asp:ListItem>ShippedTo</asp:ListItem>
                <asp:ListItem>ShipDate</asp:ListItem>
                <asp:ListItem>DueBy</asp:ListItem>
                <asp:ListItem>FOB</asp:ListItem>
                <asp:ListItem>TotalDue</asp:ListItem>
            </asp:DropDownList>
        <asp:TextBox ID="txtSearch" runat="server" HorizontalAlign ="Center"></asp:TextBox>
        <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="Search" HorizontalAlign ="Center"/>
            </asp:Panel>
        </div>
        <br>
        <br>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="InvNo" ForeColor="#333333" HorizontalAlign="Center" GridLines="None">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:TemplateField HeaderText="Link">
                   <ItemTemplate>
                         <a href='<%# "InvoiceListFull.aspx?selectedInvNo=" + Eval("InvNo") %>'>Full</a>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="InvNo" HeaderText="InvNo" SortExpression="InvNo" ReadOnly="True" />
                <asp:BoundField DataField="Supplier" HeaderText="Supplier" SortExpression="Supplier" />
                <asp:BoundField DataField="OrderFrom" HeaderText="OrderFrom" SortExpression="OrderFrom" />
                <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                <asp:BoundField DataField="InvDate" HeaderText="InvDate" SortExpression="InvDate" />
                <asp:BoundField DataField="ShippedVia" HeaderText="ShippedVia" SortExpression="ShippedVia" />
                <asp:BoundField DataField="ShippedTo" HeaderText="ShippedTo" SortExpression="ShippedTo" />
                <asp:BoundField DataField="ShipDate" HeaderText="ShipDate" SortExpression="ShipDate" />
                <asp:BoundField DataField="DueBy" HeaderText="DueBy" SortExpression="DueBy" />
                <asp:BoundField DataField="FOB" HeaderText="FOB" SortExpression="FOB" />
                <asp:BoundField DataField="TotalDue" HeaderText="TotalDue" SortExpression="TotalDue" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
        <asp:SqlDataSource ID="SqlDataSourceInvoice" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalInvoiceConnectionString %>" SelectCommand="SELECT * FROM [tblInvoiceSFS]"></asp:SqlDataSource>
    
    </form>
</body>
</html>

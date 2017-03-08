<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Inventory" %>

<!DOCTYPE html>

<head>

<title>Current Inventory</title>
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
                <h1>Current Inventory</h1>
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
  
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="Barcode" HeaderText="Barcode" SortExpression="Barcode" />
                <asp:BoundField DataField="ItemName" HeaderText="ItemName" SortExpression="ItemName" />
                <asp:BoundField DataField="AmountLeft" HeaderText="AmountLeft" SortExpression="AmountLeft" />
                <asp:BoundField DataField="Measurement" HeaderText="Measurement" SortExpression="Measurement" />
                <asp:BoundField DataField="ContractID" HeaderText="ContractID" SortExpression="ContractID" />
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


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalInventoryConnectionString %>" SelectCommand="SELECT * FROM [tblInventorySFS]"></asp:SqlDataSource>

         <br>
            <br>
        <div style="text-align:center">
            <asp:Panel id="pnlDefaultButton" runat="server" >
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"  
            style="z-index: 1; left: 203px; top: 313px; position: absolute">
            <asp:ListItem>All</asp:ListItem>
            <asp:ListItem>Barcode</asp:ListItem>
            <asp:ListItem>ItemName</asp:ListItem>
            <asp:ListItem>AmountLeft</asp:ListItem>
            <asp:ListItem>Measurement</asp:ListItem>
            <asp:ListItem>ContractID</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox2" runat="server" style="z-index: 1; left: 348px; top: 313px; position: absolute"></asp:TextBox>
        </asp:Panel>
           
            <asp:Button ID="Button1" runat="server" style="z-index: 1; left: 523px; top: 311px; position: absolute" Text="Button" OnClick="Button"/>
           
        </div>
    </form>
</body>



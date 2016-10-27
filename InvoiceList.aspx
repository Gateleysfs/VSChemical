<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoiceList.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SqlDataSourceInvoice" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalInvoiceConnectionString %>" SelectCommand="SELECT * FROM [tblInvoiceSFS]"></asp:SqlDataSource>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="InvNo" DataSourceID="SqlDataSourceInvoice" ForeColor="Black">

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
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 448px">
    <form id="form1" runat="server">
    <div style="height: 446px">
    
        <asp:DropDownList ID="DropDownList1" runat="server" style="z-index: 1; left: 13px; position: absolute; height: 16px; width: 114px; top: 15px; " AutoPostBack="True">
            <asp:ListItem>All</asp:ListItem>
                <asp:ListItem>ItemName</asp:ListItem>
                <asp:ListItem>Barcode</asp:ListItem>
                <asp:ListItem>AmountLeft</asp:ListItem>
                <asp:ListItem>Measurement</asp:ListItem>
                <asp:ListItem>Contract</asp:ListItem>

        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; left: 193px; top: 15px; position: absolute"></asp:TextBox>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" style="z-index: 1; left: 15px; top: 93px; position: absolute; height: 133px; width: 187px">
            <Columns>
                <asp:BoundField DataField="Barcode" HeaderText="Barcode" SortExpression="Barcode" />
                <asp:BoundField DataField="ItemName" HeaderText="ItemName" SortExpression="ItemName" />
                <asp:BoundField DataField="AmountLeft" HeaderText="AmountLeft" SortExpression="AmountLeft" />
                <asp:BoundField DataField="Measurement" HeaderText="Measurement" SortExpression="Measurement" />
                <asp:BoundField DataField="ContractID" HeaderText="ContractID" SortExpression="ContractID" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalInventoryConnectionString %>" SelectCommand="SELECT * FROM [tblInventorySFS]"></asp:SqlDataSource>
    
        <asp:Button ID="Button1" runat="server" style="z-index: 1; left: 379px; top: 15px; position: absolute" Text="Search" />
    
    </div>
    </form>
</body>
</html>

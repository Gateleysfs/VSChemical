<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransactionList.aspx.cs" Inherits="TransactionList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SqlDataSourceTransactionList" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalTransactionListConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT  [tblInventoryTransactionsSFS].ID, Username, ChemicalName, CrewNumber, TransactionType, Quantity, Measurement, WetDry, CreatedDate, [tblInventoryTransactionsSFS].Comments
FROM [tblInventoryTransactionsSFS], [tblEmployeeSFS], [tblInventorySFS]
WHERE [tblInventoryTransactionsSFS].EmployeeId = [tblEmployeeSFS].UserID
AND [tblInventoryTransactionsSFS].TransactionItemId = [tblInventorySFS].ID
"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataSourceID="SqlDataSourceTransactionList" ForeColor="Black" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="ChemicalName" HeaderText="ChemicalName" SortExpression="ChemicalName" />
                <asp:BoundField DataField="CrewNumber" HeaderText="CrewNumber" SortExpression="CrewNumber" />
                <asp:BoundField DataField="TransactionType" HeaderText="TransactionType" SortExpression="TransactionType" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Measurement" HeaderText="Measurement" SortExpression="Measurement" />
                <asp:BoundField DataField="WetDry" HeaderText="WetDry" SortExpression="WetDry" />
                <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" />
                <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
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
    
    </div>
    </form>
</body>
</html>

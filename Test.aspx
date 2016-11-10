<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnlTextBoxes" runat="server">
            </asp:Panel>
            <hr />
            <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="AddTextBox" />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Save" />
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalInventoryConnectionString %>" SelectCommand="SELECT *
FROM dbo.tblInventorySFS"></asp:SqlDataSource>
    </form>

</body>
</html>

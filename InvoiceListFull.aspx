<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoiceListFull.aspx.cs" Inherits="InvoiceListFull" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SqlDataSourceInvoiceListFull" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalInvoiceListFullConnectionString %>" SelectCommand="SELECT *
FROM tblInventorySFS, tblInvoiceSFS
WHERE tblInvoiceSFS.InvNo = tblInventorySFS.InvNo"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>

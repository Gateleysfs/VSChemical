<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Barcode.aspx.cs" Inherits="Barcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
<asp:Button ID="btnGenerate" runat="server" Text="Generate" onclick="btnGenerate_Click" />
<hr />
<asp:PlaceHolder ID="plBarCode" runat="server" />
</form>
</body>
</html>

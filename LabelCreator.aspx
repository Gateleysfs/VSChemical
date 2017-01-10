<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LabelCreator.aspx.cs" Inherits="LabelCreator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Data To Encode"></asp:Label>
        <asp:TextBox ID="txtDataToEncode" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="Label2" runat="server" Text="Barcodes:"></asp:Label>
        <br/>
        <asp:TextBox ID="txtEncodedDataBarcode" runat="server" Height="100px" Width="400px"></asp:TextBox>
    <br/>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generate Barcodes" />
        <br/>
        <asp:SqlDataSource ID="sfsBarcodeHolderConnectionString" runat="server" ConnectionString="<%$ ConnectionStrings:sfsBarcodeHolderConnectionString %>" SelectCommand="SELECT * FROM [tblBarcodeHolderSFS]"></asp:SqlDataSource>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

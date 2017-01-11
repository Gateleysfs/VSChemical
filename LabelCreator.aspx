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
        <asp:Label ID="Label1" runat="server" Text="Number of barcodes:"></asp:Label>
        <asp:TextBox ID="txtDataToEncode" runat="server"></asp:TextBox>
            <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="javascript:window.print();" OnClick="printButton_Click"/>
            <br/>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generate Barcodes" />
            <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>

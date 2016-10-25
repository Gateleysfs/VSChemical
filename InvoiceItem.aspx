<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoiceItem.aspx.cs" Inherits="InvoiceItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: xx-large;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 201px;
            text-align: right;
        }
        .auto-style4 {
            width: 315px;
        }
        .auto-style5 {
            width: 201px;
            text-align: right;
            height: 23px;
        }
        .auto-style6 {
            width: 315px;
            height: 23px;
        }
        .auto-style7 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <strong>Invoices Continued</strong></div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">Ordered</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxOrdered" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Shipped</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxShipped" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">ItemNo</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxItemNo" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Description (Prescription)</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxDescription" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Unit Price</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxUnitPrice" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6">
                    <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" style="height: 26px" Text="Submit" Width="120px" />
                    <asp:Button ID="ButtonAdd" runat="server" Text="Add Another" Width="120px" />
                </td>
                <td class="auto-style7"></td>
            </tr>
        </table>
    </form>
</body>
</html>

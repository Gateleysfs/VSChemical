<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Invoice" %>

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
            width: 159px;
            text-align: right;
        }
        .auto-style4 {
            width: 159px;
            text-align: right;
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style6 {
            width: 315px;
        }
        .auto-style7 {
            height: 23px;
            width: 315px;
        }
        .auto-style8 {
            width: 159px;
            text-align: right;
            height: 26px;
        }
        .auto-style9 {
            width: 315px;
            height: 26px;
        }
        .auto-style10 {
            height: 26px;
        }
        .auto-style11 {
            width: 129px;
        }
        .auto-style12 {
            height: 23px;
            width: 129px;
        }
        .auto-style13 {
            height: 26px;
            width: 129px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style1">
            <strong>Invoices</strong></p>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">Invoice No. </td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxInvNo" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorInvoiceNo" runat="server" ControlToValidate="TextBoxInvNo" ErrorMessage="Please enter an invoice number" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Company Supplier</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxSupplier" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSupplier" runat="server" ControlToValidate="TextBoxSupplier" ErrorMessage="Please enter company supplier" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Person Ordered From</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxOrderFrom" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderFrom" runat="server" ControlToValidate="TextBoxOrderFrom" ErrorMessage="Please enter a person the chemicals were ordered from" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Order Date</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxOrderDate" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style11">Format mm/dd/yy</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderDate" runat="server" ControlToValidate="TextBoxOrderDate" ErrorMessage="Please enter an order date" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Inv Date</td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBoxInvDate" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style12">Format mm/dd/yy</td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorInvDate" runat="server" ControlToValidate="TextBoxInvDate" ErrorMessage="Please enter an invoice date" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">Shipped Via</td>
                <td class="auto-style9">
                    <asp:TextBox ID="TextBoxShippedVia" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style13"></td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorShippedVia" runat="server" ControlToValidate="TextBoxShippedVia" ErrorMessage="Please enter how the chemicals are beign shipped" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Ship Date</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxShipDate" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style11">Format mm/dd/yy</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorShipDate" runat="server" ControlToValidate="TextBoxShipDate" ErrorMessage="Please enter the ship date" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Due By</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxDueBy" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style11">Format mm/dd/yy</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDueBy" runat="server" ControlToValidate="TextBoxDueBy" ErrorMessage="Please enter the due date" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">FOB</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxFOB" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFOB" runat="server" ControlToValidate="TextBoxFOB" ErrorMessage="Please enter FOB" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Total Due</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxTotalDue" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTotalDue" runat="server" ControlToValidate="TextBoxTotalDue" ErrorMessage="Please enter total amount due" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Button ID="ButtonSubmitInvoice" runat="server" OnClick="ButtonSubmitInvoice_Click" Text="Submit" Width="150px" />
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>

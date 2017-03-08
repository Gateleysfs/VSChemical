<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Invoice" %>

<!DOCTYPE html>

<head>

    <title>Invoice</title>
    <link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

    <link rel="stylesheet" href="BasicLayout.css">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }

        .auto-style2 {
            height: 18px;
        }
            .auto-style5 {
        position: absolute;
        left: 0;
        top: 0;
        height: 98px;
        width: 140px;
    }
    </style>
</head>
<body id="PageBackGround">
    <form id="form1" runat="server">
        <div id="Header" class="auto-style2">
            <br>
            <div>
                <h1>Invoice</h1>
            </div>
            <a href="Home.aspx">
                <img class="auto-style5" src="Images/sfs logo green transparent.png" alt="Superior Forestry Logo">
            </a>
            <div class="ImgRight">
                <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" /></div>
        </div>
        <div id="mainNav">
            <ul>
                <li><a href="Transaction.aspx">Add Transaction</a></li>
                <li><a href="TransactionList.aspx">Transactions List</a></li>
                <li><a href="Invoice.aspx">Add Invoice</a></li>
                <li><a href="InvoiceList.aspx">Invoices List</a></li>
                <li><a href="Inventory.aspx">Current Inventory</a></li>
                <li><a href="TransactionbyDate.aspx">Rescent Transactions</a></li>
            </ul>
        </div>
        <br>
        <div class="Content SansSerif">
            <table>
                <tr>
                    <td class="auto-style1">Invoice No. </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBoxInvNo" runat="server" Width="300px" Style="text-transform: uppercase;"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorInvoiceNo" runat="server" ControlToValidate="TextBoxInvNo" ErrorMessage="Please enter an invoice number" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Company Supplier</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBoxSupplier" runat="server" Width="300px" Style="text-transform: uppercase;"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSupplier" runat="server" ControlToValidate="TextBoxSupplier" ErrorMessage="Please enter company supplier" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Person Ordered From</td>
                    <td class="auto-style6" style="text-transform: uppercase;">
                        <asp:TextBox ID="TextBoxOrderFrom" runat="server" Width="300px" Style="text-transform: uppercase;"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderFrom" runat="server" ControlToValidate="TextBoxOrderFrom" ErrorMessage="Please enter a person the chemicals were ordered from" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Order Date</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBoxOrderDate" runat="server" Width="300px" Style="text-transform: uppercase;" TextMode="Date"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderDate" runat="server" ControlToValidate="TextBoxOrderDate" ErrorMessage="Please enter an order date" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Inv Date</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBoxInvDate" runat="server" Width="300px" Style="text-transform: uppercase;" TextMode="Date"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorInvDate" runat="server" ControlToValidate="TextBoxInvDate" ErrorMessage="Please enter an invoice date" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Shipped Via</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBoxShipVia" runat="server" Width="300px" Style="text-transform: uppercase;"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorShippedVia" runat="server" ControlToValidate="TextBoxShipVia" ErrorMessage="Please enter how the chemicals are being shipped" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Shipped To</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBoxShipTo" runat="server" Width="300px" Style="text-transform: uppercase;"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorShippedTo" runat="server" ControlToValidate="TextBoxShipTo" ErrorMessage="Please enter where the chemicals are being shipped to" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Ship Date</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBoxShipDate" runat="server" Width="300px" Style="text-transform: uppercase;" TextMode="Date"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorShipDate" runat="server" ControlToValidate="TextBoxShipDate" ErrorMessage="Please enter the ship date" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Due By</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBoxDueBy" runat="server" Width="300px" Style="text-transform: uppercase;" TextMode="Date"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDueBy" runat="server" ControlToValidate="TextBoxDueBy" ErrorMessage="Please enter the due date" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">FOB</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBoxFOB" runat="server" Width="300px" Style="text-transform: uppercase;"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFOB" runat="server" ControlToValidate="TextBoxFOB" ErrorMessage="Please enter FOB" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Total Due</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBoxTotalDue" runat="server" Width="300px" Style="text-transform: uppercase;"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTotalDue" runat="server" ControlToValidate="TextBoxTotalDue" ErrorMessage="Please enter total amount due" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style6">
                        Chemicals:</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:Panel ID="pnlTextBoxes" runat="server">
            </asp:Panel>
            <asp:Button ID="ButtonSubmitInvoice" runat="server" OnClick="ButtonSubmitInvoice_Click" Text="Submit" Width="150px" />
            <asp:Button ID="ButtonAddChemical" runat="server" OnClick="ButtonAddChemical_Click" Text="Add Chemical" Width="150px" />
        </div>
    </form>
</body>
</html>

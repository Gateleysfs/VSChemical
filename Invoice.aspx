<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Invoice" %>

<!DOCTYPE html>

<title>Invoice</title>
<link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

<link rel="stylesheet" href="BasicLayout.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<body id="PageBackGround">
    <form id="form1" runat="server">
        <div id="Header" class="auto-style2">
                    <br>
                    <h1>Invoice</h1>
                    <a href="Home.aspx">
                        <img class="ImgRight" src="Images/sfs logo green transparent.png" alt="Superior Forestry Logo" width="140" height="98">
                    </a>
        </div>
      <div id="mainNav">
      <ul>
        <li><a href="Transaction.aspx">Add Transaction</a></li>
        <li><a href="TransactionList.aspx">Transactions List</a></li>
        <li><a href="Invoice.aspx">Add Invoice</a></li>
        <li><a href="InvoiceList.aspx">Invoices List</a></li>
	    <li><a href="Inventory.aspx">Current Inventory</a></li>
      </ul>
     </div>
        <br>
        <table class="Content SansSerif">
            <tr>
                <td class="auto-style1">Invoice No. </td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxInvNo" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorInvoiceNo" runat="server" ControlToValidate="TextBoxInvNo" ErrorMessage="Please enter an invoice number" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Company Supplier</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxSupplier" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSupplier" runat="server" ControlToValidate="TextBoxSupplier" ErrorMessage="Please enter company supplier" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Person Ordered From</td>
                <td class="auto-style6" style="text-transform:uppercase;">
                    <asp:TextBox ID="TextBoxOrderFrom" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderFrom" runat="server" ControlToValidate="TextBoxOrderFrom" ErrorMessage="Please enter a person the chemicals were ordered from" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Order Date</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxOrderDate" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">Format mm/dd/yy</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderDate" runat="server" ControlToValidate="TextBoxOrderDate" ErrorMessage="Please enter an order date" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Inv Date</td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBoxInvDate" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style12">Format mm/dd/yy</td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorInvDate" runat="server" ControlToValidate="TextBoxInvDate" ErrorMessage="Please enter an invoice date" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Shipped Via</td>
                <td class="auto-style9">
                    <asp:TextBox ID="TextBoxShippedVia" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style13"></td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorShippedVia" runat="server" ControlToValidate="TextBoxShippedVia" ErrorMessage="Please enter how the chemicals are being shipped" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Shipped To</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxShippedTo" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorShippedTo" runat="server" ControlToValidate="TextBoxShippedTo" ErrorMessage="Please enter where the chemicals are being shipped to" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Ship Date</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxShipDate" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">Format mm/dd/yy</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorShipDate" runat="server" ControlToValidate="TextBoxShipDate" ErrorMessage="Please enter the ship date" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Due By</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxDueBy" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">Format mm/dd/yy</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDueBy" runat="server" ControlToValidate="TextBoxDueBy" ErrorMessage="Please enter the due date" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">FOB</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxFOB" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFOB" runat="server" ControlToValidate="TextBoxFOB" ErrorMessage="Please enter FOB" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Total Due</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxTotalDue" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTotalDue" runat="server" ControlToValidate="TextBoxTotalDue" ErrorMessage="Please enter total amount due" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style6">
                    Chemicals</td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Ordered</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxOrdered" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Shipped</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxShipped" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">ItemNo</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxItemNo" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Description (Prescription)</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxPescription" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Unit Price</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxUnitPrice" runat="server" Width="300px" style="text-transform:uppercase;"></asp:TextBox>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Chemical Category</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="DropDownListChemicalCategory" runat="server" Width="305px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>HERBICIDE</asp:ListItem>
                        <asp:ListItem>SURFACTANT</asp:ListItem>
                        <asp:ListItem>BASAL OIL</asp:ListItem>
                        <asp:ListItem>DYE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style3">
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style1">Chemical Amount</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxChemicalAmount" runat="server" Width="192px" style="text-transform:uppercase;"></asp:TextBox>
                    <asp:DropDownList ID="DropDownListContainerType" runat="server" Height="16px" Width="104px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>lbs</asp:ListItem>
                        <asp:ListItem>Oz</asp:ListItem>
                        <asp:ListItem>Gal</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style11">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Wet/Dry</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownListWetDry" runat="server" Height="16px" Width="305px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>WET</asp:ListItem>
                        <asp:ListItem>DRY</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style5">
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style11">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Button ID="ButtonSubmitInvoice" runat="server" OnClick="ButtonSubmitInvoice_Click" Text="Submit" Width="150px" />
                </td>
                <td class="auto-style11">
                    <asp:Button ID="Button1" runat="server" Text="Add Another Chemical" Width="150px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
    </body>
</html>

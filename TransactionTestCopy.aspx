<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransactionTestCopy.aspx.cs" Inherits="Transaction" %>

<!DOCTYPE html>

<head>

<title>Transaction</title>
<link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

<link rel="stylesheet" href="BasicLayout.css">
<html xmlns="http://www.w3.org/1999/xhtml">


<style type="text/css">
    .auto-style1 {
        width: 821px;
    }
    .auto-style2 {
        height: 24px;
    }
    .auto-style3 {
        width: 821px;
        height: 24px;
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
    <div>
        <div id="Header" class="auto-style2">
            <br>
            <div>
                <h1>Transaction</h1>
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
      </ul>
     </div>
        <br>
        <table class="Content SansSerif">
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelTransaction" runat="server" Text="Transaction"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownListTransaction" runat="server" Height="18px" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTransaction_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>ADDITION</asp:ListItem>
                        <asp:ListItem>REMOVAL</asp:ListItem>
                        <asp:ListItem>TRANSFER</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelBarcode" runat="server" Text="Barcode"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownListBarcode" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="DropDownListBarcode_SelectedIndexChanged" Width="300px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelAmountLeft" runat="server" Text="Amount Left"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownListAmountLeft" runat="server" Height="20px" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListAmountLeft_SelectedIndexChanged">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelCrewNumber" runat="server" Text="Crew Number"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxCrewNumber" runat="server" Width="296px" style="text-transform:uppercase;" OnTextChanged="TextBoxCrewNumber_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" Width="150px" OnClick="ButtonSubmit_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    &nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    &nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    &nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
        </table>
            <asp:Panel ID="pnlControls" runat="server">

            </asp:Panel>
    </div>
        <strong><span class="auto-style4">
        <asp:SqlDataSource ID="SqlDataSourceProduct" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalProductConnectionString %>" SelectCommand="SELECT DISTINCT [ItemNo] FROM [tblInventorySFS]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceLocation" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalLocationConnectionString %>" SelectCommand="SELECT [FirstName], [LastName] FROM [tblEmployeeSFS] ORDER BY [FirstName]"></asp:SqlDataSource>
        </span></strong>
    </form>
    </body>

</html>

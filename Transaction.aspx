<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Transaction.aspx.cs" Inherits="Transaction" %>

<!DOCTYPE html>

<head>

<title>Inventory</title>
<link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

<link rel="stylesheet" href="BasicLayout.css">
<html xmlns="http://www.w3.org/1999/xhtml">


<style type="text/css">
    .auto-style2 {
        height: 37px;
    }
    .auto-style4 {
        height: 35px;
    }
    .auto-style5 {
        height: 25px;
    }
    .auto-style7 {
        height: 5px;
    }
    .auto-style10 {
        width: 342px;
    }
    .auto-style11 {
        height: 25px;
        width: 342px;
    }
    .auto-style12 {
        height: 5px;
        width: 342px;
    }
    .auto-style13 {
        height: 30px;
    }
    .auto-style14 {
        height: 30px;
        width: 342px;
    }
</style>
    </head>


<body id="PageBackGround">
    <form id="form1" runat="server">
    <div>
        <div id="Header" class="auto-style2">
                    <br>
                    <h1>Transaction</h1>
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
                <td>Crew Number</td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBoxCrewNumber" runat="server" Width="296px" style="text-transform:uppercase;" Height="20px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCrewNumber" runat="server" ControlToValidate="TextBoxCrewNumber" ErrorMessage="Please enter a crew number" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Transaction</td>
                <td class="auto-style11">
                    <asp:DropDownList ID="DropDownListTransaction" runat="server" Height="25px" Width="300px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>ADDITION</asp:ListItem>
                        <asp:ListItem>REMOVAL</asp:ListItem>
                        <asp:ListItem>TRANSFER</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTransaction" runat="server" ControlToValidate="DropDownListTransaction" ErrorMessage="Please enter a transaction" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style5">
                    </td>
            </tr>
            <tr>
                <td class="auto-style5">Product</td>
                <td class="auto-style11">
                    <asp:DropDownList AppendDataBoundItems="true" ID="DropDownListProduct" runat="server" Height="25px" Width="300px" DataSourceID="SqlDataSourceProduct" DataTextField="ItemNo" DataValueField="ItemNo">
                        <asp:ListItem Selected="True"></asp:ListItem>
                    </asp:DropDownList>

                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorProduct" runat="server" ControlToValidate="DropDownListProduct" ErrorMessage="Please enter a product" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style5">
                    </td>
            </tr>
            <tr>
                <td class="auto-style5">Amount</td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextBoxAmount" runat="server" Width="192px" Height="20px"></asp:TextBox>
                    <asp:DropDownList ID="DropDownListWeight" runat="server" Height="26px" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>lbs</asp:ListItem>
                        <asp:ListItem>Oz</asp:ListItem>
                        <asp:ListItem>Gal</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAmount" runat="server" ControlToValidate="TextBoxAmount" ErrorMessage="Please enter an amount" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSizes" runat="server" ControlToValidate="DropDownListWeight" ErrorMessage="Please enter a weight" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Location</td>
                <td class="auto-style12">
                    <asp:DropDownList AppendDataBoundItems="true" ID="DropDownListLocation" runat="server" Width="300px" DataSourceID="SqlDataSourceLocation" DataTextField="FirstName" DataValueField="FirstName" Height="25px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Russellville Chemical Storage</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style7">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocation" runat="server" ControlToValidate="DropDownListLocation" ErrorMessage="Please enter a location" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">
                    </td>
            </tr>
            <tr>
                <td>Comments</td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBoxComment" runat="server" Height="40px" TextMode="MultiLine" Width="294px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style14">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" Width="150px" OnClick="ButtonSubmit_Click" />
                </td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
            </tr>
        </table>
    </div>
        <strong><span class="auto-style4">
        <asp:SqlDataSource ID="SqlDataSourceProduct" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalProductConnectionString %>" SelectCommand="SELECT DISTINCT [ItemNo] FROM [tblInventorySFS]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceLocation" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalLocationConnectionString %>" SelectCommand="SELECT [FirstName], [LastName] FROM [tblEmployeeSFS] ORDER BY [FirstName]"></asp:SqlDataSource>
        </span></strong>
    </form>
    </body>

</html>

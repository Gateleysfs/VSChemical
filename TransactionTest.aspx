<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransactionTest.aspx.cs" Inherits="Transaction" %>

<!DOCTYPE html>

<head>

<title>Inventory</title>
<link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

<link rel="stylesheet" href="BasicLayout.css">
<html xmlns="http://www.w3.org/1999/xhtml">


<style type="text/css">
    .auto-style1 {
        width: 821px;
    }
</style>
    </head>


<body id="PageBackGround">
    <form id="form1" runat="server">
    <div>
        <div id="Header" class="auto-style2">
                    <br>
                    <h1>Transaction<asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
                    </h1>
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
                    <asp:Label ID="LabelCrewNumber" runat="server" Text="Crew Number"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxCrewNumber" runat="server" Width="296px" style="text-transform:uppercase;" OnTextChanged="TextBoxCrewNumber_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelProduct" runat="server" Text="Product"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList AppendDataBoundItems="True" ID="DropDownListProduct" runat="server" Height="18px" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListProduct_SelectedIndexChanged">
                        <asp:ListItem Selected="True"></asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelPartial" runat="server" Text="Partial"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownListPartial" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPartial_SelectedIndexChanged" Width="300px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelAmount" runat="server" Text="Amount"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxAmount" runat="server" Width="192px"></asp:TextBox>
                    <asp:DropDownList ID="DropDownListWeight" runat="server" Height="18px" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>lbs</asp:ListItem>
                        <asp:ListItem>Oz</asp:ListItem>
                        <asp:ListItem>Gal</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListAmount" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListAmount_SelectedIndexChanged" Width="300px">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelQuantity" runat="server" Text="Quantity"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownListQuantity" runat="server" Width="301px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListQuantity_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelLocation" runat="server" Text="Location"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList AppendDataBoundItems="true" ID="DropDownListLocation" runat="server" Width="300px" DataSourceID="SqlDataSourceLocation" DataTextField="FirstName" DataValueField="FirstName">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Russellville Chemical Storage</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelComments" runat="server" Text="Comments"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxComment" runat="server" Width="296px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style1">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" Width="150px" OnClick="ButtonSubmit_Click" />
                </td>
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

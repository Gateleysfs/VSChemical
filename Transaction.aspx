<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Transaction.aspx.cs" Inherits="Transaction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
            width: 1510px;
        }
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            font-size: xx-large;
        }
        .auto-style6 {
            height: 23px;
            width: 300px;
        }
        .auto-style8 {
            height: 23px;
            width: 150px;
            text-align: right;
        }
        .auto-style9 {
            height: 23px;
            width: 234px;
        }
    </style>
</head>
<body style="height: 277px">
    <form id="form1" runat="server">
    <div>
    
        <div class="auto-style2">
            <strong><span class="auto-style4">Transaction</span></strong></div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style8">Crew Number</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxCrewNumber" runat="server" Width="296px"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCrewNumber" runat="server" ControlToValidate="TextBoxCrewNumber" ErrorMessage="Please enter a crew number" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">Transaction</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="DropDownListTransaction" runat="server" Height="18px" Width="300px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Addition</asp:ListItem>
                        <asp:ListItem>Removal</asp:ListItem>
                        <asp:ListItem>Transfer</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style9">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTransaction" runat="server" ControlToValidate="DropDownListTransaction" ErrorMessage="Please enter a transaction" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">Product Type</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="DropDownListProductType" runat="server" Height="18px" Width="300px" OnSelectedIndexChanged="DropDownListProductType_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Herbicide</asp:ListItem>
                        <asp:ListItem Value="Surfactant">Surfactant</asp:ListItem>
                        <asp:ListItem>Basal Oil</asp:ListItem>
                        <asp:ListItem>Dye</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style9">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductType" runat="server" ControlToValidate="DropDownListProductType" ErrorMessage="Please enter a product type" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">Product</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="DropDownListProduct" runat="server" Height="18px" Width="300px" DataSourceID="SqlDataSourceProduct" DataTextField="ChemicalName" DataValueField="ChemicalName">
                    </asp:DropDownList>
                </td>
                <td class="auto-style9"></td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">Wet/Dry</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="DropDownListWetDry" runat="server" Height="18px" Width="300px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Wet</asp:ListItem>
                        <asp:ListItem>Dry</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style9">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorWetDry" runat="server" ControlToValidate="DropDownListWetDry" ErrorMessage="Please enter wet or dry" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">Amount</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxAmount" runat="server" Width="192px"></asp:TextBox>
                    <asp:DropDownList ID="DropDownListWeight" runat="server" Height="18px" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Pounds</asp:ListItem>
                        <asp:ListItem>Ounces</asp:ListItem>
                        <asp:ListItem>Gallons</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style9">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAmount" runat="server" ControlToValidate="TextBoxAmount" ErrorMessage="Please enter an amount" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSizes" runat="server" ControlToValidate="DropDownListWeight" ErrorMessage="Please enter a weight" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">Location</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="DropDownListLocation" runat="server" Width="300px" DataSourceID="SqlDataSourceLocation" DataTextField="FirstName" DataValueField="FirstName">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Russellville</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style9">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocation" runat="server" ControlToValidate="DropDownListLocation" ErrorMessage="Please enter a location" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">Comments</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxComment" runat="server" Width="296px"></asp:TextBox>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style6">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" Width="150px" OnClick="ButtonSubmit_Click" />
                </td>
                <td class="auto-style9"></td>
                <td class="auto-style3"></td>
            </tr>
        </table>
    
    </div>
            <strong><span class="auto-style4">
        <asp:SqlDataSource ID="SqlDataSourceProduct" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalProductConnectionString %>" SelectCommand="SELECT DISTINCT [ChemicalName] FROM [tblInventorySFS]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceLocation" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalLocationConnectionString %>" SelectCommand="SELECT [FirstName], [LastName] FROM [tblEmployeeSFS] ORDER BY [FirstName]"></asp:SqlDataSource>
        </span></strong>
    </form>
</body>
</html>

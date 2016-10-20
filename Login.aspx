<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<style type="text/css">
        #form1 {
            width: 1225px;
            height: 158px;
            text-align: center;
            margin-left: 0px;
        }--%>        <%--</style>--%>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            height: 23px;
            text-align: left;
        }
        .auto-style4 {
            text-align: left;
            width: 186px;
        }
        .auto-style5 {
            height: 23px;
            text-align: left;
            width: 186px;
        }
        .auto-style8 {
            height: 23px;
            text-align: right;
            width: 119px;
        }
        .auto-style9 {
            width: 119px;
            text-align: right;
        }
        .auto-style10 {
            text-align: left;
        }
        .auto-style11 {
            font-size: xx-large;
        }
    </style>
    
</head>

<body style="height: 28px; width: 1639px; text-align:center; margin-top: 71px; margin-bottom: 0px;">
    <form id="form1" runat="server">
        <p class="auto-style11">
            <strong>Login Page</strong></p>
        <table class="auto-style2">
            <tr>
                <td class="auto-style8">Username</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxUsername" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ControlToValidate="TextBoxUsername" EnableTheming="False" ErrorMessage="Please enter a username" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Password</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Please enter a password" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Button ID="Button_Login" runat="server" OnClick="Button_Login_Click" Text="Submit" Width="185px" />
                </td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10">
            <asp:SqlDataSource ID="SqlDataSourceUsers" runat="server" ConnectionString="<%$ ConnectionStrings:sfsChemicalEmployeeConnectionString %>" SelectCommand="SELECT * FROM [tblEmployeeSFS]"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

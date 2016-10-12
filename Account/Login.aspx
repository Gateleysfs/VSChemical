<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

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
        }--%>
        <%--</style>--%>
    <style type="text/css">
        .auto-style1 {
            width: 335px;
            height: 255px;
            margin-left: 0px;
        }

    </style>

</head>

<body style="height: 28px; width: 1639px; text-align:center; margin-top: 247px;">
<img alt="" class="auto-style1" src="file:///C:\Users\Gateley\Desktop\VSChemical\Images\SuperiorForestry_RGB.jpg" />
<div style="text-align: center;">
    <form id="form1" runat="server">
        
        <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" style="margin-left: 681px; margin-top: 20px" Width="279px">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" />
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                Please login to continue
            </AnonymousTemplate>
            <LoggedInTemplate>
                You are logged in
            </LoggedInTemplate>
        </asp:LoginView>
        <br />
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
        <br />
        <a href="#">Content</a>

    </form>
</div>
</body>
</html>

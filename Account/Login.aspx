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
    
</head>

<body style="height: 28px; width: 1639px; text-align:center; margin-top: 71px; margin-bottom: 0px;">
&nbsp;<div style="text-align: center;">
    <form id="form1" runat="server">
        
        <img alt="SuperiorForestry_RGB.jpg" src="https://github.com/Gateleysfs/VSChemical/blob/master/Images/SuperiorForestry_RGB.jpg?raw=true" style="height: 354px; width: 435px; margin-left: 94px; margin-right: 0px" /><asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" style="margin-left: 718px; margin-top: 0px; margin-right: 0px;" Width="279px">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" style="margin-left: 50px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                &nbsp;Please login to continue
            </AnonymousTemplate>
            <LoggedInTemplate>
                You are logged in
            </LoggedInTemplate>
        </asp:LoginView>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LoginStatus ID="LoginStatus1" runat="server" />

    </form>
</div>
</body>
</html>

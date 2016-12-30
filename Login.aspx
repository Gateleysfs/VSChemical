<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default"%>

<!DOCTYPE html>

<title>Home</title>
<link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

<link rel="stylesheet" href="BasicLayout.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
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
            .auto-style13 {
        position: absolute;
        left: 0;
        top: 0;
        height: 98px;
        width: 140px;
    }

    </style>
    
</head>

<body id="PageBackGround">

        <div id="Header" class="auto-style2">
            <br>
            <div>
                <h1>Login Page</h1>
            </div>
            <a href="Home.aspx">
                <img class="auto-style13" src="Images/sfs logo green transparent.png" alt="Superior Forestry Logo">
            </a>
            <br>
            <br>
            <br>

    <form id="form1" runat="server">
        <div class="Content SansSerif">
        <br>
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
        </div>
    </form>
</body>
    
<!-- Footer -->
<div  id="footer" class="PadTen SansSerif">
	<p class ="CenterText MarginFive">Superior Forestry Service <br/> P.O. Box 25 <br/> Tilly, AR 72679 <br/> 800.541.1060<br/>
	</p>
	<p class ="CenterText MarginFive"> 
		<a href="mailto:sfs@superiorforestry.com">sfs@superiorforestry.com</a><br/>
	</p>
	<p class ="MarginFive CenterText">
		©2016 Superior Forestry Service, Inc.
	</p>
</div>

</html>

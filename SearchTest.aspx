<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchTest.aspx.cs" Inherits="SearchTest" %>

<!DOCTYPE html>
<link rel="stylesheet" href="BasicLayout.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<script language="javascript">
        $(document).ready(function(e){
            $('.search-panel .dropdown-menu').find('a').click(function(e) {
                e.preventDefault();
                var param = $(this).attr("href").replace("#","");
                var concept = $(this).text();
                $('.search-panel span#search_concept').text(concept);
                $('.input-group #search_param').val(param);
            });
        });
</script>


<body>
    <form id="form1" runat="server">
    <div>

        <asp:Panel ID="pnlTextBoxes" runat="server">

        </asp:Panel>

    </div>
    </form>
</body>
</html>

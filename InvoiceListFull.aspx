<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoiceListFull.aspx.cs" Inherits="InvoiceListFull" %>

<!DOCTYPE html>

<title>Invoice List</title>
<link rel="icon" href="Images/sfs logo green transparent.png" type="image/jpg">

<link rel="stylesheet" href="BasicLayout.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
    </style>
</head>
<body id ="PageBackGround">
    <form id="form1" runat="server">
                <div id="Header" class="auto-style2">
                    <br>
                    <h1>Specific Invoice<asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
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


        <div>      
            <span class="auto-style1">Invoice:</span><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" ForeColor="Black">  
            <Columns>  
                <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="InvNo">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_InvNo" runat="server" Text='<%#Eval("InvNo") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_InvNo" runat="server" Text='<%#Eval("InvNo") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Supplier">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Supplier" runat="server" Text='<%#Eval("Supplier") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Supplier" runat="server" Text='<%#Eval("Supplier") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="OrderFrom">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_OrderFrom" runat="server" Text='<%#Eval("OrderFrom") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_OrderFrom" runat="server" Text='<%#Eval("OrderFrom") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="OrderDate">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_OrderDate" runat="server" Text='<%#Eval("OrderDate") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_OrderDate" runat="server" Text='<%#Eval("OrderDate") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="InvDate">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_InvDate" runat="server" Text='<%#Eval("InvDate") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_InvDate" runat="server" Text='<%#Eval("InvDate") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ShippedVia">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ShippedVia" runat="server" Text='<%#Eval("ShippedVia") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_ShippedVia" runat="server" Text='<%#Eval("ShippedVia") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ShippedTo">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ShippedTo" runat="server" Text='<%#Eval("ShippedTo") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_ShippedTo" runat="server" Text='<%#Eval("ShippedTo") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ShipDate">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ShipDate" runat="server" Text='<%#Eval("ShipDate") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_ShipDate" runat="server" Text='<%#Eval("ShipDate") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DueBy">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_DueBy" runat="server" Text='<%#Eval("DueBy") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_DueBy" runat="server" Text='<%#Eval("DueBy") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FOB">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_FOB" runat="server" Text='<%#Eval("FOB") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_FOB" runat="server" Text='<%#Eval("FOB") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TotalDue">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_TotalDue" runat="server" Text='<%#Eval("TotalDue") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_TotalDue" runat="server" Text='<%#Eval("TotalDue") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
            </Columns>  
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="DarkGreen" ForeColor="#ffffff" Font-Bold="True"/>  
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White"/>  
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>  
    </div>
        <br />
    <div>
        <span class="auto-style1">Chemicals:</span><br />    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" ForeColor="Black">  
            <Columns>  
                <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="InvNo">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_InvNo" runat="server" Text='<%#Eval("InvNo") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_InvNo" runat="server" Text='<%#Eval("InvNo") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Ordered">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Ordered" runat="server" Text='<%#Eval("Ordered") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Ordered" runat="server" Text='<%#Eval("Ordered") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Shipped">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Shipped" runat="server" Text='<%#Eval("Shipped") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Shipped" runat="server" Text='<%#Eval("Shipped") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="ItemNo">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ItemNo" runat="server" Text='<%#Eval("ItemNo") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_ItemNo" runat="server" Text='<%#Eval("ItemNo") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prescription">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Prescription" runat="server" Text='<%#Eval("Prescription") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Prescription" runat="server" Text='<%#Eval("Prescription") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UnitPrice">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_UnitPrice" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_UnitPrice" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Category" runat="server" Text='<%#Eval("Category") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Category" runat="server" Text='<%#Eval("Category") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OriginalLocation">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_OriginalLocation" runat="server" Text='<%#Eval("OriginalLocation") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_OriginalLocation" runat="server" Text='<%#Eval("OriginalLocation") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ChemicalAmount">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ChemicalAmount" runat="server" Text='<%#Eval("ChemicalAmount") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_ChemicalAmount" runat="server" Text='<%#Eval("ChemicalAmount") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ContainerType">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ContainerType" runat="server" Text='<%#Eval("ContainerType") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_ContainerType" runat="server" Text='<%#Eval("ContainerType") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="WetDry">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_WetDry" runat="server" Text='<%#Eval("WetDry") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_WetDry" runat="server" Text='<%#Eval("WetDry") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
            </Columns>  
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="DarkGreen" ForeColor="#ffffff" Font-Bold="True"/>  
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White"/>  
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>  
        <asp:SqlDataSource ID="SqlDataSourceInvoiceChemicals" runat="server" ConnectionString="<%$ ConnectionStrings:sfsInvoiceChemicalsConnectionString %>" SelectCommand="SELECT * FROM [tblInvoiceChemicalsSFS]"></asp:SqlDataSource>
    </div>  
</form>  

</body>
</html>


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class InvoiceListFull : System.Web.UI.Page
{
    //Connection String from web.config File  
    string cs = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
    SqlConnection con;
    SqlDataAdapter adapt;
    DataTable dt;

    //Connection String from web.config File  
    string cs2 = ConfigurationManager.ConnectionStrings["sfsChemicalInvoiceConnectionString"].ConnectionString;
    SqlConnection con2;
    SqlDataAdapter adapt2;
    DataTable dt2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowData();
            ShowData2();
        }
    }

    //ShowData method for Displaying Data in Gridview  
    protected void ShowData()
    {
        string InvNo = Request.QueryString["selectedInvNo"];
        dt = new DataTable();
        con = new SqlConnection(cs);
        con.Open();
        string SelectQuery = "SELECT * FROM dbo.tblInventorySFS WHERE InvNo = '" + InvNo + "'";
        adapt = new SqlDataAdapter(SelectQuery, con);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        con.Close();
    }
    protected void ShowData2()
    {
        string InvNo = Request.QueryString["selectedInvNo"];
        dt2 = new DataTable();
        con2 = new SqlConnection(cs2);
        con2.Open();
        string SelectQuery2 = "SELECT * FROM dbo.tblInvoiceSFS WHERE InvNo = '" + InvNo + "'";
        adapt2 = new SqlDataAdapter(SelectQuery2, con2);
        adapt2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            GridView2.DataSource = dt2;
            GridView2.DataBind();
        }
        con2.Close();
    }


    protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        //NewEditIndex property used to determine the index of the row being edited.  
        GridView1.EditIndex = e.NewEditIndex;
        ShowData();
    }
    protected void GridView2_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        //NewEditIndex property used to determine the index of the row being edited.  
        GridView2.EditIndex = e.NewEditIndex;
        ShowData2();
    }

    protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        //Finding the controls from Gridview for the row which is going to update  
        Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
        TextBox invNo = GridView1.Rows[e.RowIndex].FindControl("txt_InvNo") as TextBox;
        TextBox ordered = GridView1.Rows[e.RowIndex].FindControl("txt_Ordered") as TextBox;
        TextBox shipped = GridView1.Rows[e.RowIndex].FindControl("txt_Shipped") as TextBox;
        TextBox itemNo = GridView1.Rows[e.RowIndex].FindControl("txt_ItemNo") as TextBox;
        TextBox prescription = GridView1.Rows[e.RowIndex].FindControl("txt_Prescription") as TextBox;
        TextBox unitPrice = GridView1.Rows[e.RowIndex].FindControl("txt_UnitPrice") as TextBox;
        TextBox category = GridView1.Rows[e.RowIndex].FindControl("txt_Category") as TextBox;
        TextBox location = GridView1.Rows[e.RowIndex].FindControl("txt_Location") as TextBox;
        TextBox partialContainer = GridView1.Rows[e.RowIndex].FindControl("txt_PartialContainer") as TextBox;
        TextBox chemicalAmount = GridView1.Rows[e.RowIndex].FindControl("txt_ChemicalAmount") as TextBox;
        TextBox total = GridView1.Rows[e.RowIndex].FindControl("txt_Total") as TextBox;
        TextBox containerType = GridView1.Rows[e.RowIndex].FindControl("txt_ContainerType") as TextBox;
        TextBox wetDry = GridView1.Rows[e.RowIndex].FindControl("txt_WetDry") as TextBox;
        con = new SqlConnection(cs);
        con.Open();
        //updating the record  
        SqlCommand cmd = new SqlCommand("Update dbo.tblInventorySFS set InvNo='" + invNo.Text + "',Ordered='" + ordered.Text + "',Shipped='" + shipped.Text + "' ,ItemNo='" + itemNo.Text + "',Prescription='" + prescription.Text + "',UnitPrice='" + unitPrice.Text + "',Category='" + category.Text + "' ,Location='" + location.Text + "',PartialContainer='" + partialContainer.Text + "',ChemicalAmount='" + chemicalAmount.Text + "' ,Total='" + total.Text + "' ,ContainerType='" + containerType.Text + "',WetDry='" + wetDry.Text + "'  where ID=" + Convert.ToInt32(id.Text), con);
        cmd.ExecuteNonQuery();
        con.Close();
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView1.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        ShowData();
    }
    protected void GridView2_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        //Finding the controls from Gridview for the row which is going to update  
        Label id2 = GridView2.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
        TextBox invNo2 = GridView2.Rows[e.RowIndex].FindControl("txt_InvNo") as TextBox;
        TextBox supplier = GridView2.Rows[e.RowIndex].FindControl("txt_Supplier") as TextBox;
        TextBox orderFrom = GridView2.Rows[e.RowIndex].FindControl("txt_OrderFrom") as TextBox;
        TextBox orderDate = GridView2.Rows[e.RowIndex].FindControl("txt_OrderDate") as TextBox;
        TextBox invDate = GridView2.Rows[e.RowIndex].FindControl("txt_InvDate") as TextBox;
        TextBox shippedVia = GridView2.Rows[e.RowIndex].FindControl("txt_ShippedVia") as TextBox;
        TextBox shippedTo = GridView2.Rows[e.RowIndex].FindControl("txt_ShippedTo") as TextBox;
        TextBox shipDate = GridView2.Rows[e.RowIndex].FindControl("txt_ShipDate") as TextBox;
        TextBox dueBy = GridView2.Rows[e.RowIndex].FindControl("txt_DueBy") as TextBox;
        TextBox fob = GridView2.Rows[e.RowIndex].FindControl("txt_FOB") as TextBox;
        TextBox totalDue = GridView2.Rows[e.RowIndex].FindControl("txt_TotalDue") as TextBox;
        con2 = new SqlConnection(cs2);
        con2.Open();
        //updating the record  
        SqlCommand cmd2 = new SqlCommand("Update dbo.tblInvoiceSFS set InvNo='" + invNo2.Text + "',Supplier='" + supplier.Text + "',OrderFrom='" + orderFrom.Text + "' ,OrderDate='" + orderDate.Text + "',InvDate='" + invDate.Text + "',ShippedVia='" + shippedVia.Text + "',ShippedTo='" + shippedTo.Text + "' ,ShipDate='" + shipDate.Text + "',DueBy='" + dueBy.Text + "',FOB='" + fob.Text + "' ,TotalDue='" + totalDue.Text + "'  where ID=" + Convert.ToInt32(id2.Text), con2);
        cmd2.ExecuteNonQuery();
        con2.Close();
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView2.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        ShowData2();
    }


    protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView1.EditIndex = -1;
        ShowData();
    }
    protected void GridView2_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView2.EditIndex = -1;
        ShowData2();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


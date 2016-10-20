using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Invoice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks to see if someone is logged in. If not, redirects to login page
        if (Session["new"] == null)
            Response.Redirect("Login.aspx");
    }

    protected void ButtonSubmitInvoice_Click(object sender, EventArgs e)
    {
        try
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInvoiceConnectionString"].ConnectionString);
            conn.Open();

            string insertQuery = "INSERT INTO dbo.tblInvoiceSFS ( InvNum, Supplier, OrderFrom, OrderDate, InvDate, ShippedVia, ShipDate, DueBy, FOB, TotalDue) values( @InvNum, @Supplier, @OrderFrom, @OrderDate, @InvDate, @ShippedVia, @ShipDate, @DueBy, @FOB, @TotalDue)";
            SqlCommand com = new SqlCommand(insertQuery, conn);

            //values being inserted
            com.Parameters.AddWithValue("@InvNum", TextBoxInvNo.Text);
            com.Parameters.AddWithValue("@Supplier", TextBoxSupplier.Text);
            com.Parameters.AddWithValue("@OrderFrom", TextBoxOrderFrom.Text);
            com.Parameters.AddWithValue("@OrderDate", TextBoxOrderDate.Text);
            com.Parameters.AddWithValue("@InvDate", TextBoxInvDate.Text);
            com.Parameters.AddWithValue("@ShippedVia", TextBoxShippedVia.Text);
            com.Parameters.AddWithValue("@ShipDate", TextBoxShipDate.Text);
            com.Parameters.AddWithValue("@DueBy", TextBoxDueBy.Text);
            com.Parameters.AddWithValue("@FOB", TextBoxFOB.Text);
            com.Parameters.AddWithValue("@TotalDue", TextBoxTotalDue.Text);
            com.ExecuteNonQuery();

            Response.Redirect("Invoice.aspx");

            Response.Write("Invoice Sent");
            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("ERROR:" + ex.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class InvoiceItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString);
            conn.Open();

            string insertQuery = "INSERT INTO dbo.tblInventorySFS ( InvNo, Ordered, Shipped, ItemNo, Prescription, UnitPrice, ExtendedPrice, Category, Location, PartialContainer, ChemicalAmount, ContainerType, Comments ) values( @InvNum, @Supplier, @OrderFrom, @OrderDate, @InvDate, @ShippedVia, @ShipDate, @DueBy, @FOB, @TotalDue)";
            SqlCommand com = new SqlCommand(insertQuery, conn);

            //values being inserted
            //com.Parameters.AddWithValue("@InvNum", TextBoxInvNo.Text);
            //com.Parameters.AddWithValue("@Supplier", TextBoxSupplier.Text);
            //com.Parameters.AddWithValue("@OrderFrom", TextBoxOrderFrom.Text);
            //com.Parameters.AddWithValue("@OrderDate", TextBoxOrderDate.Text);
            //com.Parameters.AddWithValue("@InvDate", TextBoxInvDate.Text);
            //com.Parameters.AddWithValue("@ShippedVia", TextBoxShippedVia.Text);
            //com.Parameters.AddWithValue("@ShipDate", TextBoxShipDate.Text);
            //com.Parameters.AddWithValue("@DueBy", TextBoxDueBy.Text);
            //com.Parameters.AddWithValue("@FOB", TextBoxFOB.Text);
            //com.Parameters.AddWithValue("@TotalDue", TextBoxTotalDue.Text);
            //com.ExecuteNonQuery();

            Response.Redirect("InvoiceItem.aspx");

            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("ERROR:" + ex.ToString());
        }
    }
}
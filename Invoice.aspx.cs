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

        /*
        // Add any controls that have been previously added dynamically
        for (int i = 0; i < TotalNumberAdded; ++i)
        {
            AddControls(i + 1);
        }

        // Attach the event handler to the button
        Button1.Click += new EventHandler(Button1_Click);
        */
    }


    //---------------------------------------------------------------------------------------
    /*
    void Button1_Click(object sender, EventArgs e)
    {
        // Increase the number added and add the new label and textbox
        TotalNumberAdded++;
        AddControls(TotalNumberAdded);
    }

    private void AddControls(int controlNumber)
    {

        var OrderedPanel = new Panel();
        var OrderedLabel = new Label();
        var OrderedTextbox = new TextBox();

        var ShippedPanel = new Panel();
        var ShippedLabel = new Label();
        var ShippedTextbox = new TextBox();

        var ItemNoPanel = new Panel();
        var ItemNoLabel = new Label();
        var ItemNoTextbox = new TextBox();

        var PrescriptionPanel = new Panel();
        var PrescriptionLabel = new Label();
        var PrescriptionTextbox = new TextBox();

        var UnitPricePanel = new Panel();
        var UnitPriceLabel = new Label();
        var UnitPriceTextbox = new TextBox();

        // textbox needs a unique id to maintain state information
        OrderedTextbox.ID = "Ordered_" + controlNumber;
        OrderedLabel.Text = "Ordered";

        ShippedTextbox.ID = "Shipped_" + controlNumber;
        ShippedLabel.Text = "Shipped";

        ItemNoTextbox.ID = "ItemNo_" + controlNumber;
        ItemNoLabel.Text = "ItemNo";

        PrescriptionTextbox.ID = "Prescription_" + controlNumber;
        PrescriptionLabel.Text = "Prescription";

        UnitPriceTextbox.ID = "UnitPrice_" + controlNumber;
        UnitPriceLabel.Text = "UnitPrice";

        // add the label and textbox to the panel, then add the panel to the form
        OrderedPanel.Controls.Add(OrderedLabel);
        OrderedPanel.Controls.Add(OrderedTextbox);
        form1.Controls.Add(OrderedPanel);

        ShippedPanel.Controls.Add(ShippedLabel);
        ShippedPanel.Controls.Add(ShippedTextbox);
        form1.Controls.Add(ShippedPanel);

        ItemNoPanel.Controls.Add(ItemNoLabel);
        ItemNoPanel.Controls.Add(ItemNoTextbox);
        form1.Controls.Add(ItemNoPanel);

        PrescriptionPanel.Controls.Add(PrescriptionLabel);
        PrescriptionPanel.Controls.Add(PrescriptionTextbox);
        form1.Controls.Add(PrescriptionPanel);

        UnitPricePanel.Controls.Add(UnitPriceLabel);
        UnitPricePanel.Controls.Add(UnitPriceTextbox);
        form1.Controls.Add(UnitPricePanel);

    }

    protected int TotalNumberAdded
    {
        get { return (int)(ViewState["TotalNumberAdded"] ?? 0); }
        set { ViewState["TotalNumberAdded"] = value; }
    }
    */
    protected void ButtonSubmitInvoice_Click(object sender, EventArgs e)
    {
        try
        {
            //Creating a connection to the Invoice table (conn) and Inventory table (conn2) so that I can store the textfields in the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInvoiceConnectionString"].ConnectionString);
            SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString);

            //Open the Connections to the database
            conn.Open();
            conn2.Open();

            //Creating the query and SqlCommand objects
            string insertQuery = "INSERT INTO dbo.tblInvoiceSFS ( InvNo, Supplier, OrderFrom, OrderDate, InvDate, ShippedVia, ShippedTo, ShipDate, DueBy, FOB, TotalDue) values( @InvNum, @Supplier, @OrderFrom, @OrderDate, @InvDate, @ShippedVia, @ShippedTo, @ShipDate, @DueBy, @FOB, @TotalDue)";
            SqlCommand com = new SqlCommand(insertQuery, conn);

            string insertQuery2 = "INSERT INTO dbo.tblInventorySFS ( InvNo, Ordered, Shipped, ItemNo, Prescription, UnitPrice, ExtendedPrice, Category, Location, PartialContainer, ChemicalAmount, ContainerType, WetDry) values( @InvNum2, @Ordered, @Shipped, @ItemNo, @Prescription, @UnitPrice, @ExtendedPrice, @Category, @Location, @PartialContainer, @ChemicalAmount, @ContainerType, @WetDry)";
            SqlCommand com2 = new SqlCommand(insertQuery2, conn2);

            //values being inserted into Invoice
            com.Parameters.AddWithValue("@InvNum", TextBoxInvNo.Text);
            com.Parameters.AddWithValue("@Supplier", TextBoxSupplier.Text);
            com.Parameters.AddWithValue("@OrderFrom", TextBoxOrderFrom.Text);
            com.Parameters.AddWithValue("@OrderDate", TextBoxOrderDate.Text);
            com.Parameters.AddWithValue("@InvDate", TextBoxInvDate.Text);
            com.Parameters.AddWithValue("@ShippedVia", TextBoxShippedVia.Text);
            com.Parameters.AddWithValue("@ShippedTo", TextBoxShippedTo.Text);
            com.Parameters.AddWithValue("@ShipDate", TextBoxShipDate.Text);
            com.Parameters.AddWithValue("@DueBy", TextBoxDueBy.Text);
            com.Parameters.AddWithValue("@FOB", TextBoxFOB.Text);
            com.Parameters.AddWithValue("@TotalDue", TextBoxTotalDue.Text);



            //To obtain the extended price: ExtendedPrice = Ordered * UnitPrice 
            double UnitPrice = double.Parse(TextBoxUnitPrice.Text);
            int Ordered = int.Parse(TextBoxOrdered.Text);
            double ExtendedPrice = UnitPrice * Ordered;

            //values being inserted into Inventory
            com2.Parameters.AddWithValue("@InvNum2", TextBoxInvNo.Text);
            com2.Parameters.AddWithValue("@Ordered", TextBoxOrdered.Text);
            com2.Parameters.AddWithValue("@Shipped", TextBoxShipped.Text);
            com2.Parameters.AddWithValue("@ItemNo", TextBoxItemNo.Text);
            com2.Parameters.AddWithValue("@Prescription", TextBoxPescription.Text);
            com2.Parameters.AddWithValue("@UnitPrice", TextBoxUnitPrice.Text);
            com2.Parameters.AddWithValue("@ExtendedPrice", ExtendedPrice);
            com2.Parameters.AddWithValue("@Category", DropDownListChemicalCategory.SelectedItem.ToString());
            com2.Parameters.AddWithValue("@Location", TextBoxShippedTo.Text); // starting location of each chemical
            com2.Parameters.AddWithValue("@PartialContainer", false);
            com2.Parameters.AddWithValue("@ChemicalAmount", TextBoxChemicalAmount.Text);
            com2.Parameters.AddWithValue("@ContainerType", DropDownListContainerType.SelectedItem.ToString());
            com2.Parameters.AddWithValue("@WetDry", DropDownListWetDry.SelectedItem.ToString());

            //Execution of the queries with the parameters from above. This places all the textboxes into the corresponding tables
            com.ExecuteNonQuery();
            com2.ExecuteNonQuery();

            //close the connections
            conn.Close();
            conn2.Close();

            //Redirects after a successful InvoiceTransaction
            Response.Redirect("Home.aspx");


        }
        catch (Exception ex)
        {
            Response.Write("ERROR:" + ex.ToString());
        }
    }
}
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
    // Ensures that there is an account logged in. If not, the user is redirected to login page
    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks to see if someone is logged in. If not, redirects to login page
        if (Session["new"] == null)
            Response.Redirect("Login.aspx");
    }

    // This is called when the Add Chemical Button is pressed. It simply creates the next set of controls
    protected void ButtonAddChemical_Click(object sender, EventArgs e)
    {
        int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("Ordered", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("Shipped", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("ItemNo", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("Prescription", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("UnitPrice", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateDropDown("ChemicalCategory", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("ChemicalAmount", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateDropDown("ContainerType", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateDropDown("WetDry", index);
    }

    // Creates all the text box inputs as well as the labels associated with them
    private void CreateTextBox(string id, int index)
    {
        TextBox txt = new TextBox();
        txt.ID = id + index;


        Label dynamicLabel = new Label();
        dynamicLabel.Text = id;
        //dynamicLabel.Attributes.Add("Style", "text-align:right");
        dynamicLabel.Width = 150;
        dynamicLabel.Height = 25;
        pnlTextBoxes.Controls.Add(dynamicLabel);

        //pnlTextBoxes.Controls.Add(new LiteralControl(id + " "));
        pnlTextBoxes.Controls.Add(txt);
        if (id != "ChemicalAmount")
            pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
    }

    // Creates all the drop down menu inputs as well as the labels associated with them
    private void CreateDropDown(string id, int index)
    {
        if (id != "ContainerType")
        {
            Label dynamicLabel = new Label();
            dynamicLabel.Text = id;
            //dynamicLabel.Attributes.Add("Style", "text-align:right");
            dynamicLabel.Width = 150;
            dynamicLabel.Height = 25;
            pnlTextBoxes.Controls.Add(dynamicLabel);
        }


        if (id == "ChemicalCategory")
        {
            DropDownList ddl = new DropDownList();
            ddl.ID = id + index;
            ddl.Width = 173;
            ddl.Items.Add(new ListItem(""));
            ddl.Items.Add(new ListItem("HERBICIDE"));
            ddl.Items.Add(new ListItem("SURFACTANT"));
            ddl.Items.Add(new ListItem("BASAL OIL"));
            ddl.Items.Add(new ListItem("DYE"));


            pnlTextBoxes.Controls.Add(ddl);
            pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));

        }

        else if (id == "ContainerType")
        {
            DropDownList ddl = new DropDownList();
            ddl.ID = id + index;
            ddl.Width = 50;
            ddl.Items.Add(new ListItem(""));
            ddl.Items.Add(new ListItem("lbs"));
            ddl.Items.Add(new ListItem("Oz"));
            ddl.Items.Add(new ListItem("Gal"));

            pnlTextBoxes.Controls.Add(ddl);
            pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
        }

        else if (id == "WetDry")
        {
            DropDownList ddl = new DropDownList();
            ddl.ID = id + index;
            ddl.Width = 173;
            ddl.Items.Add(new ListItem(""));
            ddl.Items.Add(new ListItem("WET"));
            ddl.Items.Add(new ListItem("DRY"));


            pnlTextBoxes.Controls.Add(ddl);
            pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
        }
    }

    // Runs first after every click of the Add Chemical button. It processes all the current controls on the page
    // and then outputs all the textboxes on the next iteration while keeping their value (postback)
    protected void Page_PreInit(object sender, EventArgs e)
    {
        List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("Ordered") || key.Contains("Shipped") || key.Contains("ItemNo") || key.Contains("Prescription") || key.Contains("UnitPrice") || key.Contains("ChemicalCategory") || key.Contains("ChemicalAmount") || key.Contains("ContainerType") || key.Contains("WetDry")).ToList();
        int i = 1;
        foreach (string key in keys)
        {
            if (key.Contains("Ordered"))
            {
                this.CreateTextBox("Ordered", i);
            }
            else if (key.Contains("Shipped"))
            {
                this.CreateTextBox("Shipped", i);
            }
            else if (key.Contains("ItemNo"))
            {
                this.CreateTextBox("ItemNo", i);
            }
            else if (key.Contains("Prescription"))
            {
                this.CreateTextBox("Prescription", i);
            }
            else if (key.Contains("UnitPrice"))
            {
                this.CreateTextBox("UnitPrice", i);
            }
            else if (key.Contains("ChemicalCategory"))
            {
                this.CreateDropDown("ChemicalCategory", i);
            }
            else if (key.Contains("ChemicalAmount"))
            {
                this.CreateTextBox("ChemicalAmount", i);
            }
            else if (key.Contains("ContainerType"))
            {
                this.CreateDropDown("ContainerType", i);
            }
            else if (key.Contains("WetDry"))
            {
                this.CreateDropDown("WetDry", i);
                pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
            }
            i++;
        }
    }

    // This inserts the invoice and chemicals into their respective locations in the database. The first part is for invoice
    // and the second part is for chemicals. The chemical insert is a bit more complicated due to its recursive nature for
    // inserting any number of chemicals into the database.
    protected void ButtonSubmitInvoice_Click(object sender, EventArgs e)
    {
        try
        {
            // Inserts into Invoice table the Invoice information from the page------------------------------------------------------------------------------------------
            // Creating a connection to the Invoice table (conn) and Inventory table (conn2) so that I can store the textfields in the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInvoiceConnectionString"].ConnectionString);

            // Creating the query and SqlCommand objects
            string insertQuery = "INSERT INTO dbo.tblInvoiceSFS ( InvNo, Supplier, OrderFrom, OrderDate, InvDate, ShippedVia, ShippedTo, ShipDate, DueBy, FOB, TotalDue) values( @InvNum, @Supplier, @OrderFrom, @OrderDate, @InvDate, @ShippedVia, @ShippedTo, @ShipDate, @DueBy, @FOB, @TotalDue)";
            SqlCommand com = new SqlCommand(insertQuery, conn);

            // values being inserted into Invoice
            com.Parameters.AddWithValue("@InvNum", TextBoxInvNo.Text);
            com.Parameters.AddWithValue("@Supplier", TextBoxSupplier.Text);
            com.Parameters.AddWithValue("@OrderFrom", TextBoxOrderFrom.Text);
            com.Parameters.AddWithValue("@OrderDate", TextBoxOrderDate.Text);
            com.Parameters.AddWithValue("@InvDate", TextBoxInvDate.Text);
            com.Parameters.AddWithValue("@ShippedVia", TextBoxShipVia.Text);
            com.Parameters.AddWithValue("@ShippedTo", TextBoxShipTo.Text);
            com.Parameters.AddWithValue("@ShipDate", TextBoxShipDate.Text);
            com.Parameters.AddWithValue("@DueBy", TextBoxDueBy.Text);
            com.Parameters.AddWithValue("@FOB", TextBoxFOB.Text);
            com.Parameters.AddWithValue("@TotalDue", TextBoxTotalDue.Text);

            //Open the connection to the database, execute the com parameters from above, then close connection
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();

            // End of Invoice Insertion-----------------------------------------------------------------------------------------------------------------------------------


            // This inserts all of the Chemicals into the InvoiceChemical table--------------------------------------------------------------------------------------------------
            string conString = ConfigurationManager.ConnectionStrings["sfsInvoiceChemicalsConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.tblInvoiceChemicalsSFS(InvNo, Ordered, Shipped, ItemNo, Prescription, UnitPrice, ExtendedPrice, Category, OriginalLocation, ChemicalAmount, ContainerType, WetDry) VALUES(@InvNo, @Ordered, @Shipped, @ItemNo, @Prescription, @UnitPrice, @ExtendedPrice, @Category, @OriginalLocation, @ChemicalAmount, @ContainerType, @WetDry)"))
                {
                    foreach (Control control in pnlTextBoxes.Controls)
                    {
                        cmd.Connection = con;
                        if (control is TextBox && control.ID.Contains("Ordered"))
                        {
                            cmd.Parameters.AddWithValue("@Ordered", (control as TextBox).Text);
                        }
                        else if (control is TextBox && control.ID.Contains("Shipped"))
                        {
                            cmd.Parameters.AddWithValue("@Shipped", (control as TextBox).Text);
                        }
                        else if (control is TextBox && control.ID.Contains("ItemNo"))
                        {
                            cmd.Parameters.AddWithValue("@ItemNo", (control as TextBox).Text); 
                        }
                        else if (control is TextBox && control.ID.Contains("Prescription"))
                        {
                            cmd.Parameters.AddWithValue("@Prescription", (control as TextBox).Text);
                        }
                        else if (control is TextBox && control.ID.Contains("UnitPrice"))
                        {
                            cmd.Parameters.AddWithValue("@UnitPrice", (control as TextBox).Text);
                        }
                        else if (control is TextBox && control.ID.Contains("ChemicalAmount"))
                        {
                            cmd.Parameters.AddWithValue("@ChemicalAmount", (control as TextBox).Text);
                        }
                        else if (control is DropDownList && control.ID.Contains("ChemicalCategory"))
                        {
                            cmd.Parameters.AddWithValue("@Category", (control as DropDownList).SelectedItem.ToString());
                        }
                        else if (control is DropDownList && control.ID.Contains("ContainerType"))
                        {
                            cmd.Parameters.AddWithValue("@ContainerType", (control as DropDownList).SelectedItem.ToString());
                        }
                        else if (control is DropDownList && control.ID.Contains("WetDry"))
                        {
                            cmd.Parameters.AddWithValue("@WetDry", (control as DropDownList).SelectedItem.ToString());

                            //Other information to be inserted
                            cmd.Parameters.AddWithValue("@invNo", TextBoxInvNo.Text);
                            cmd.Parameters.AddWithValue("@OriginalLocation", TextBoxShipTo.Text);
                            cmd.Parameters.AddWithValue("@ExtendedPrice", 111); //unit price * ordered

                            //Since this is the last control in a form, we insert all the parameters in the database then clear parameters for the next iteration
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmd.Parameters.Clear();
                        }
                    }
                }
            }
            // End of inserting chemicals into InvoiceChemicals-------------------------------------------------------------------------------------------------------------------



            // Inserts the information from the boxes to the Inventory Table-----------------------------------------------------------------------------------------------------
            string conString2 = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString2))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.tblInventorySFS(ItemNo, Prescription, CurrentLocation, ContainerCount, ChemicalAmount, AmountLeft, ContainerType, Total, PartialContainer, Category) VALUES(@ItemNo, @Prescription, @CurrentLocation, @ContainerCount, @ChemicalAmount, @AmountLeft, @ContainerType, @Total, @PartialContainer, @Category)"))
                {
                    foreach (Control control in pnlTextBoxes.Controls)
                    {
                        cmd.Connection = con;
                        if (control is TextBox && control.ID.Contains("Shipped"))
                        {
                            cmd.Parameters.AddWithValue("ContainerCount", (control as TextBox).Text);
                        }
                        else if (control is TextBox && control.ID.Contains("ItemNo"))
                        {
                            cmd.Parameters.AddWithValue("@ItemNo", (control as TextBox).Text);
                        }
                        else if (control is TextBox && control.ID.Contains("Prescription"))
                        {
                            cmd.Parameters.AddWithValue("@Prescription", (control as TextBox).Text);
                        }
                        else if (control is TextBox && control.ID.Contains("ChemicalAmount"))
                        {
                            cmd.Parameters.AddWithValue("@ChemicalAmount", (control as TextBox).Text);
                            cmd.Parameters.AddWithValue("@AmountLeft", (control as TextBox).Text);
                        }
                        else if (control is DropDownList && control.ID.Contains("ChemicalCategory"))
                        {
                            cmd.Parameters.AddWithValue("@Category", (control as DropDownList).SelectedItem.ToString());
                        }
                        else if (control is DropDownList && control.ID.Contains("ContainerType"))
                        {
                            cmd.Parameters.AddWithValue("@ContainerType", (control as DropDownList).SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@CurrentLocation", TextBoxShipTo.Text);
                            cmd.Parameters.AddWithValue("@PartialContainer", "False");
                            cmd.Parameters.AddWithValue("@Total", 111); //  amount left * ordered

                            //Since this is the last control in a form, we insert all the parameters in the database then clear parameters for the next iteration
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmd.Parameters.Clear();

                        }
                    }
                }
            }
            // End of Inventory table inserting-----------------------------------------------------------------------------------------------------------------------------------






            //Redirects after a successful InvoiceTransaction
            Response.Redirect("Home.aspx");


        }
        catch (Exception ex)
        {
            Response.Write("ERROR:" + ex.ToString());
        }
    }
}
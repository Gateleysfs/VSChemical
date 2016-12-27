using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

public partial class Invoice : System.Web.UI.Page
{
    // Ensures that there is an account logged in. If not, the user is redirected to login page
    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks to see if someone is logged in. If not, redirects to login page
        if (Session["new"] == null)
            Response.Redirect("Login.aspx");
    }

    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        //Logout of website when logout button is clicked
        Session["new"] = null;
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
                    //creates a data table and adds the columns to the table
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Ordered", typeof(String));
                    dt.Columns.Add("Shipped", typeof(String));
                    dt.Columns.Add("ItemNo", typeof(String));
                    dt.Columns.Add("Prescription", typeof(String));
                    dt.Columns.Add("UnitPrice", typeof(String));
                    dt.Columns.Add("ChemicalAmount", typeof(String));
                    dt.Columns.Add("ChemicalCategory", typeof(String));
                    dt.Columns.Add("ContainerType", typeof(String));
                    dt.Columns.Add("WetDry", typeof(String));
                    dt.Columns.Add("InvNo", typeof(String));
                    dt.Columns.Add("OriginalLocation", typeof(String));
                    dt.Columns.Add("ExtendedPrice", typeof(String));

                    
                    //creates a new row inside the datatable(dt)
                    DataRow dr = dt.NewRow();
                         
                    //This foreach searches the webpage and matches the id of the textboxes and dropdownlists to the corresponding column name from above
                    foreach (Control control in pnlTextBoxes.Controls)
                    {
                        if (control is TextBox && control.ID.Contains("Ordered"))              
                            dr["Ordered"] = (control as TextBox).Text;
                        else if (control is TextBox && control.ID.Contains("Shipped"))           
                            dr["Shipped"] = (control as TextBox).Text;                        
                        else if (control is TextBox && control.ID.Contains("ItemNo"))           
                            dr["ItemNo"] = (control as TextBox).Text; 
                        else if (control is TextBox && control.ID.Contains("Prescription"))              
                            dr["Prescription"] = (control as TextBox).Text;
                        else if (control is TextBox && control.ID.Contains("UnitPrice"))       
                            dr["UnitPrice"] = (control as TextBox).Text;
                        else if (control is TextBox && control.ID.Contains("ChemicalAmount"))          
                            dr["ChemicalAmount"] = (control as TextBox).Text;
                        else if (control is DropDownList && control.ID.Contains("ChemicalCategory"))                 
                            dr["ChemicalCategory"] = (control as DropDownList).SelectedItem.ToString();
                        else if (control is DropDownList && control.ID.Contains("ContainerType"))
                            dr["ContainerType"] = (control as DropDownList).SelectedItem.ToString();
                        else if (control is DropDownList && control.ID.Contains("WetDry"))
                        {
                            dr["WetDry"] = (control as DropDownList).SelectedItem.ToString();

                            //Other information to be inserted
                            dr["InvNo"] = TextBoxInvNo.Text;
                            dr["OriginalLocation"] = TextBoxShipTo.Text;

                            //converts unitprice and ordered to an integer, multiplies, then turns the integer result back into a string
                            dr["ExtendedPrice"] = (Double.Parse(dr["UnitPrice"].ToString()) * Int32.Parse(dr["Ordered"].ToString())).ToString(); //unit price * ordered

                            //adds all the information to the datatable(dt)
                            dt.Rows.Add(dr);

                            //dataRow(dr) moves to the next row in the table to insert more rows
                            dr = dt.NewRow();
                        }
                    }

                    foreach (DataRow row in dt.Rows)
                    {

                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@Ordered", row["Ordered"]);
                        cmd.Parameters.AddWithValue("@Shipped", row["Shipped"]);
                        cmd.Parameters.AddWithValue("@ItemNo", row["ItemNo"]);
                        cmd.Parameters.AddWithValue("@Prescription", row["Prescription"]);
                        cmd.Parameters.AddWithValue("@UnitPrice", row["UnitPrice"]);
                        cmd.Parameters.AddWithValue("@ChemicalAmount", row["ChemicalAmount"]);
                        cmd.Parameters.AddWithValue("@Category", row["ChemicalCategory"]);
                        cmd.Parameters.AddWithValue("@ContainerType", row["ContainerType"]);
                        cmd.Parameters.AddWithValue("@WetDry", row["WetDry"]);
                        cmd.Parameters.AddWithValue("@InvNo", row["InvNo"]);
                        cmd.Parameters.AddWithValue("@OriginalLocation", row["OriginalLocation"]);
                        cmd.Parameters.AddWithValue("@ExtendedPrice", row["ExtendedPrice"]);

                        // insert all the parameters in the database then clear parameters for the next iteration
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        cmd.Parameters.Clear();
                    }
                }
            }
            // End of inserting chemicals into InvoiceChemicals------------------------------------------------------------------------------------------------------------------



            // Inserts the information from the boxes to the Inventory Table-----------------------------------------------------------------------------------------------------
            string conString2 = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString2))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.tblInventorySFS(ItemNo, Prescription, CurrentLocation, ContainerCount, ChemicalAmount, AmountLeft, ContainerType, Total, PartialContainer, Category) VALUES(@ItemNo, @Prescription, @CurrentLocation, @ContainerCount, @ChemicalAmount, @AmountLeft, @ContainerType, @Total, @PartialContainer, @Category)"))
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ContainerCount", typeof(String));
                    dt.Columns.Add("ItemNo", typeof(String));
                    dt.Columns.Add("Prescription", typeof(String));
                    dt.Columns.Add("ChemicalAmount", typeof(String));
                    dt.Columns.Add("AmountLeft", typeof(String));
                    dt.Columns.Add("ChemicalCategory", typeof(String));
                    dt.Columns.Add("ContainerType", typeof(String));
                    dt.Columns.Add("CurrentLocation", typeof(String));
                    dt.Columns.Add("PartialContainer", typeof(String));
                    dt.Columns.Add("Total", typeof(String));


                    //creates a new row inside the datatable(dt)
                    DataRow dr = dt.NewRow();

                    //This foreach searches the webpage and matches the id of the textboxes and dropdownlists to the corresponding column name from above
                    foreach (Control control in pnlTextBoxes.Controls)
                    {
                        if (control is TextBox && control.ID.Contains("Shipped"))
                            dr["ContainerCount"] = (control as TextBox).Text;
                        else if (control is TextBox && control.ID.Contains("ItemNo"))
                            dr["ItemNo"] = (control as TextBox).Text;
                        else if (control is TextBox && control.ID.Contains("Prescription"))
                            dr["Prescription"] = (control as TextBox).Text;
                        else if (control is TextBox && control.ID.Contains("ChemicalAmount"))
                        {
                            dr["ChemicalAmount"] = (control as TextBox).Text;
                            dr["AmountLeft"] = (control as TextBox).Text;
                        }
                        else if (control is DropDownList && control.ID.Contains("ChemicalCategory"))
                            dr["ChemicalCategory"] = (control as DropDownList).SelectedItem.ToString();
                        else if (control is DropDownList && control.ID.Contains("ContainerType"))
                        {
                            dr["ContainerType"] = (control as DropDownList).SelectedItem.ToString();
                            dr["CurrentLocation"] = TextBoxShipTo.Text;
                            dr["PartialContainer"] = false;
                            //multiplies the number of chemical containers by how much is in each container to get a total amount of chemical 
                            dr["Total"] = (Int32.Parse(dr["Shipped"].ToString()) * Double.Parse(dr["AmountLeft"].ToString())).ToString(); //ContainerCount * AmountLeft

                            //adds all the information for the row to the datatable(dt)
                            dt.Rows.Add(dr);

                            //dataRow(dr) moves to the next row in the table to insert more rows
                            dr = dt.NewRow();
                        }
                    }


                    foreach (DataRow row in dt.Rows)
                    {

                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@ContainerCount", row["ContainerCount"]);
                        cmd.Parameters.AddWithValue("@ItemNo", row["ItemNo"]);
                        cmd.Parameters.AddWithValue("@Prescription", row["Prescription"]);
                        cmd.Parameters.AddWithValue("@ChemicalAmount", row["ChemicalAmount"]);
                        cmd.Parameters.AddWithValue("@AmountLeft", row["AmountLeft"]);
                        cmd.Parameters.AddWithValue("@Category", row["Category"]);
                        cmd.Parameters.AddWithValue("@ContainerType", row["ContainerType"]);
                        cmd.Parameters.AddWithValue("@CurrentLocation", row["CurrentLocation"]);
                        cmd.Parameters.AddWithValue("@PartialContainer", row["PartialContainer"]);
                        cmd.Parameters.AddWithValue("@Total", row["Total"]);

                        // insert all the parameters in the database then clear parameters for the next iteration
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        cmd.Parameters.Clear();
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
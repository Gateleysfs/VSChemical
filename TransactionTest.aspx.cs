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

public partial class Transaction : System.Web.UI.Page
{
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


    //called from Page_PreInit
    protected void transaction()
    {
        //REMOVAL
        if (Request.QueryString["transaction"] == "REMOVAL")
        {
            //Keeps REMOVAL in the DropDownListTransaction box
            DropDownListTransaction.Text = "REMOVAL";

            //Enables the TextBoxCrewNumber to be edited
            TextBoxCrewNumber.Visible = true;
            LabelCrewNumber.Visible = true;

            //Enables the DropDownListProduct and DropDownListPartial to be edited
            DropDownListProduct.Visible = true;
            LabelProduct.Visible = true;

            // Populates DropDownListProduct with all Chemicals that are located in Russellville
            // Removal will always be from the Russellville storage
            string constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Prescription FROM dbo.tblInventorySFS WHERE CurrentLocation = 'Russellville' "))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    DropDownListProduct.DataSource = cmd.ExecuteReader();
                    DropDownListProduct.DataTextField = "Prescription";
                    DropDownListProduct.DataBind();
                    con.Close();
                }
            }

            DropDownListProduct.Text = Request.QueryString["prescription"];

            if (Request.QueryString["prescription"] != null)
            {
                DropDownListPartial.Visible = true;
                LabelPartial.Visible = true;
                //partial is now called to determine whether DropDownListPartial is True or False and proceeds with more execution
                partialRemoval();
            }

        }

        //ADDITION
        else if (Request.QueryString["transaction"] == "ADDITION")
        {
            DropDownListTransaction.Text = "ADDITION";

            //Enables the DropDownListProduct and DropDownListPartial to be edited
            DropDownListProduct.Visible = true;
            LabelProduct.Visible = true;

            // Populates DropDownListProduct with all Chemicals that are located in Russellville
            // Removal will always be from the Russellville storage
            string constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Prescription FROM dbo.tblInventorySFS WHERE CurrentLocation ='" + Session["new"] + "'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    DropDownListProduct.DataSource = cmd.ExecuteReader();
                    DropDownListProduct.DataTextField = "Prescription";
                    DropDownListProduct.DataBind();
                    con.Close();
                }
            }

            // Because of postback, gets the product from the url and puts it in the product drop down
            DropDownListProduct.Text = Request.QueryString["prescription"];

            if (Request.QueryString["prescription"] != null)
            {
                DropDownListPartial.Visible = true;
                LabelPartial.Visible = true;
                //partial is now called to determine whether DropDownListPartial is True or False and proceeds with more execution
                partialAddition();
            }
        }

        // TRANSFER do later...
        else if (Request.QueryString["transaction"] == "TRANSFER")
        {
            DropDownListTransaction.Text = "TRANSFER";
        }
    }

    protected void partialRemoval()
    {

        if (Request.QueryString["partial"] != null)
        {
            //This determines whether partial is true or false. Yes == True; No == False;
            string partials = "";
            if (Request.QueryString["partial"] == "Yes")
            {
                partials = "True";
            }
            else if (Request.QueryString["partial"] == "No")
            {
                partials = "False";
            }

            //put the text back in dropdownlistpartial after postback
            DropDownListPartial.Text = Request.QueryString["partial"];

            //set dropdownlist amount to visible
            DropDownListAmount.Visible = true;
            LabelAmount.Visible = true;

            //populates the dropdownlistamount so it corresponds with the product and partial dropdownlists
            string constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT CONCAT(AmountLeft, ' ', ContainerType) as combine FROM dbo.tblInventorySFS WHERE Prescription ='" + Request.QueryString["prescription"] + "' AND PartialContainer = '" + partials + "' AND CurrentLocation = 'Russellville'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    DropDownListAmount.DataSource = cmd.ExecuteReader();
                    DropDownListAmount.DataTextField = "combine";
                    DropDownListAmount.DataBind();
                    con.Close();
                }
            }

            DropDownListAmount.Items.Insert(0, new ListItem("", ""));

            if (Request.QueryString["amount"] != null)
            {
                DropDownListAmount.SelectedItem.Text = Request.QueryString["amount"];
                LabelQuantity.Visible = true;
                DropDownListQuantity.Visible = true;

                string s = Request.QueryString["amount"];

                //pulls out the amountleft from the url
                string AmountLeft = Regex.Match(s, @"\d+").Value;
                //pulls out the ContainerType from the url
                string ContainerType = Regex.Replace(s, @"[\d-]", string.Empty);
                ContainerType = ContainerType.Trim();

                constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("SELECT ContainerCount FROM dbo.tblInventorySFS WHERE Prescription ='" + Request.QueryString["prescription"] + "' AND PartialContainer ='" + partials + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation = 'Russellville'", con);
                con.Open();
                int test = (Int32)cmd.ExecuteScalar();

                //populates the Quantity drop down list to include the number of containers that the employee may remove
                DropDownListQuantity.Items.Add(new ListItem("", "0"));
                for (int i = 1; i <= test; i++)
                {
                    DropDownListQuantity.Items.Add(new ListItem(i.ToString()));
                }
                DropDownListQuantity.DataBind();
                con.Close();

                //checks to see if a quantity has been selected
                if (Request.QueryString["quantity"] != null)
                {
                    DropDownListQuantity.SelectedItem.Text = Request.QueryString["quantity"];
                    ButtonSubmit.Visible = true;
                }
            }
        }
    }

    protected void partialAddition()
    {
        if (Request.QueryString["partial"] != null)
        {
            //This determines whether partial is true or false. Yes == True; No == False;
            string partials = "";

            //parses products that do have partials 
            if (Request.QueryString["partial"] == "Yes")
            {
                partials = "True";

                //put the text back in dropdownlistpartial after postback
                DropDownListPartial.Text = Request.QueryString["partial"];

                //set dropdownlist amount to visible
                DropDownListAmount.Visible = true;
                LabelAmount.Visible = true;

                //populates the dropdownlistamount so it corresponds with the product and partial dropdownlists
                string constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT AmountLeft, ContainerType FROM dbo.tblInventorySFS WHERE Prescription ='" + Request.QueryString["prescription"] + "' AND PartialContainer = '" + partials + "' AND CurrentLocation ='" + Session["new"] + "'", con))
                    {
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        string temp = "";
                        int AmountLeft = 0;
                        string ContainerType = "";
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //Amount Left
                                temp = reader.GetString(0);
                                AmountLeft = Int32.Parse(temp);

                                //Container Type
                                ContainerType = reader.GetString(1);

                                for (int i = 0; i <= AmountLeft; i++)
                                {
                                    DropDownListAmount.Items.Add(new ListItem(i.ToString() + " " + ContainerType));
                                }
                                reader.NextResult();
                            }
                        }
                        con.Close();
                    }
                }

                if (Request.QueryString["amount"] != null)
                {
                    DropDownListAmount.SelectedItem.Text = Request.QueryString["amount"];
                    LabelQuantity.Visible = true;
                    DropDownListQuantity.Visible = true;

                    string s = Request.QueryString["amount"];

                    //pulls out the amountleft from the url
                    string AmountLeft = Regex.Match(s, @"\d+").Value;
                    //pulls out the ContainerType from the url
                    string ContainerType = Regex.Replace(s, @"[\d-]", string.Empty);
                    ContainerType = ContainerType.Trim();

                    //grabs the number of containers for the chemical chosen in DropDownListProduct, Partial, and Amount
                    constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);
                    SqlCommand cmd = new SqlCommand("SELECT ContainerCount FROM dbo.tblInventorySFS WHERE Prescription ='" + Request.QueryString["prescription"] + "' AND PartialContainer ='" + partials + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation ='" + Session["new"] + "'", con);
                    con.Open();
                    int test = (Int32)cmd.ExecuteScalar();

                    //populates the Quantity drop down list to include the number of containers that the employee may remove
                    DropDownListQuantity.Items.Add(new ListItem("", "0"));
                    for (int i = 1; i <= test; i++)
                    {
                        DropDownListQuantity.Items.Add(new ListItem(i.ToString()));
                    }
                    DropDownListQuantity.DataBind();
                    con.Close();

                    //checks to see if a quantity has been selected
                    if (Request.QueryString["quantity"] != null)
                    {
                        DropDownListQuantity.SelectedItem.Text = Request.QueryString["quantity"];
                        ButtonSubmit.Visible = true;
                    }
                }
            }
            //parses products that do not have partials (slightly different from products that do have partials)
            else if (Request.QueryString["partial"] == "No")
            {
                partials = "False";

                //put the text back in dropdownlistpartial after postback
                DropDownListPartial.Text = Request.QueryString["partial"];

                //set dropdownlist amount to visible
                DropDownListAmount.Visible = true;
                LabelAmount.Visible = true;

                //populates the dropdownlistamount so it corresponds with the product and partial dropdownlists
                string constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT CONCAT(AmountLeft, ' ', ContainerType) as combine FROM dbo.tblInventorySFS WHERE Prescription ='" + Request.QueryString["prescription"] + "' AND PartialContainer = '" + partials + "' AND CurrentLocation ='" + Session["new"] + "'"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        DropDownListAmount.DataSource = cmd.ExecuteReader();
                        DropDownListAmount.DataTextField = "combine";
                        DropDownListAmount.DataBind();
                        con.Close();
                    }
                }

                DropDownListAmount.Items.Insert(0, new ListItem("", ""));

                if (Request.QueryString["amount"] != null)
                {
                    DropDownListAmount.SelectedItem.Text = Request.QueryString["amount"];
                    LabelQuantity.Visible = true;
                    DropDownListQuantity.Visible = true;

                    string s = Request.QueryString["amount"];


                    //pulls out the amountleft from the url
                    string AmountLeft = Regex.Match(s, @"\d+").Value;
                    //pulls out the ContainerType from the url
                    string ContainerType = Regex.Replace(s, @"[\d-]", string.Empty);
                    ContainerType = ContainerType.Trim();

                    //grabs the number of containers for the chemical chosen in DropDownListProduct, Partial, and Amount
                    constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);
                    SqlCommand cmd = new SqlCommand("SELECT ContainerCount FROM dbo.tblInventorySFS WHERE Prescription ='" + Request.QueryString["prescription"] + "' AND PartialContainer ='" + partials + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation ='" + Session["new"] + "'", con);
                    con.Open();
                    int test = (Int32)cmd.ExecuteScalar();

                    //populates the Quantity drop down list to include the number of containers that the employee may remove
                    DropDownListQuantity.Items.Add(new ListItem("", "0"));
                    for (int i = 1; i <= test; i++)
                    {
                        DropDownListQuantity.Items.Add(new ListItem(i.ToString()));
                    }
                    DropDownListQuantity.DataBind();
                    con.Close();

                    //checks to see if a quantity has been selected
                    if (Request.QueryString["quantity"] != null)
                    {
                        DropDownListQuantity.SelectedItem.Text = Request.QueryString["quantity"];
                        ButtonSubmit.Visible = true;
                    }
                }
            }//end else if (Request.QueryString["partial"] == "No")
        }
    }

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        //disable controls so they will show up one by one after each postback
        TextBoxCrewNumber.Visible = false;
        DropDownListProduct.Visible = false;
        DropDownListPartial.Visible = false;
        TextBoxAmount.Visible = false;
        DropDownListLocation.Visible = false;
        DropDownListWeight.Visible = false;
        DropDownListAmount.Visible = false;
        LabelCrewNumber.Visible = false;
        LabelProduct.Visible = false;
        LabelPartial.Visible = false;
        LabelAmount.Visible = false;
        LabelLocation.Visible = false;
        LabelComments.Visible = false;
        TextBoxComment.Visible = false;
        LabelQuantity.Visible = false;
        DropDownListQuantity.Visible = false;
        ButtonSubmit.Visible = false;

        //transaction is called which performas all the logic of the transactions
        transaction();
    }


    /*
     * When the ButtonSubmite_Click is clicked, the information inside the textboxes will be placed into the database. 
     * The ID is unique increment and is automatically inserted 
     * The EmpId is obtained from the current logged in session
     * The TransactionId is obtained from the corresponding Id in the Inventory table
     * The CreatedDate is obtained from the date and time function
     * Everything else will be entered by the user
     */
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //Variables Below
            //pulls out the amountleft from the url
            string AmountLeft = Regex.Match(Request.QueryString["amount"], @"\d+").Value;

            //pulls out the ContainerType from the url
            string ContainerType = Regex.Replace(Request.QueryString["amount"], @"[\d-]", string.Empty);
            ContainerType = ContainerType.Trim();

            //creates a variable that stores true or false. Determined by what the user put in the Partial drop down menu
            string partial = "";
            if (Request.QueryString["partial"] == "Yes")
                partial = "True";
            else if (Request.QueryString["partial"] == "No")
                partial = "False";



            //This block inserts the transaction into the transactions table--------------------------------------------------------------------------------------------------------------------------
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalTransactionListConnectionString"].ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("INSERT INTO dbo.tblInventorytransactionsSFS(TransactionItemId, EmployeeId, CrewNumber, TransactionType, Quantity, Measurement, CreatedDate, Comments) values(@transid, @empid, @crew, @ttype, @quant, @measure, @date, @comment)", conn))
                {
                    conn.Open();

                    //Select a unique Inventory ID that matches the Product drop down menu chosen. It is then cast into an int so it can be inserted into dbo.tblInventorytransactionsSFS
                    string selectTranId = "SELECT ID FROM dbo.tblInventorySFS WHERE Prescription='" + DropDownListProduct.SelectedItem.ToString() + "' AND PartialContainer='" + partial + "'AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation = 'Russellville'";
                    SqlCommand tranId = new SqlCommand(selectTranId, conn);
                    Int32 transaction = ((Int32)tranId.ExecuteScalar());

                    //Select a unique User ID that matches the Username that is currently logged in then cast it to an int so it can be inserted into dbo.tblInventorytransactionsSFS
                    string selectEmpId = "SELECT UserID FROM dbo.tblEmployeeSFS WHERE Username='" + Session["new"].ToString() + "'";
                    SqlCommand userId = new SqlCommand(selectEmpId, conn);
                    Int32 id = ((Int32)userId.ExecuteScalar());


                    com.Parameters.AddWithValue("@transid", transaction);
                    com.Parameters.AddWithValue("@empid", id);
                    com.Parameters.AddWithValue("@crew", TextBoxCrewNumber.Text);
                    com.Parameters.AddWithValue("@ttype", DropDownListTransaction.SelectedItem.ToString());
                    com.Parameters.AddWithValue("@quant", AmountLeft);
                    com.Parameters.AddWithValue("@measure", ContainerType);
                    com.Parameters.AddWithValue("@date", DateTime.Now);
                    com.Parameters.AddWithValue("@comment", TextBoxComment.Text);
                    com.ExecuteNonQuery();
                    conn.Close();
                }
            }
            // End of transaction table block-------------------------------------------------------------------------------------------------------------------------------------------------------------------
            
            // This block creates the removal information for inventory table-----------------------------------------------------------------------------------------------------------------------------------
            if (DropDownListTransaction.Text == "REMOVAL")
            {
                using (SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString))
                {
                    
                    using (SqlCommand com2 = new SqlCommand("SELECT * FROM dbo.tblInventorySFS WHERE Prescription='" + Request.QueryString["prescription"] + "' AND PartialContainer='" + partial + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType +"'", conn2))
                    {
                        conn2.Open();

                        // creates a reader and stores the rows in a datatable
                        // only one row should be created in the table and then parsed through with a foreach loop
                        SqlDataReader reader = com2.ExecuteReader();
                        DataTable dt = new DataTable();
                        var filtered = dt.AsEnumerable().Where(row => row.Field<string>("CurrentLocation") == "Russellville");
                        dt.Load(reader);
                        foreach (DataRow dr in filtered)
                        {
                            //foreach(var item in dr.ItemArray)
                            //{
                            //    Response.Write(item);
                            //}

                            // Grabs the information from the the row by matching the column name
                            string itemNo = dr["ItemNo"].ToString();
                            string prescription = dr["Prescription"].ToString();
                            string currentLocation = dr["CurrentLocation"].ToString();
                            int containerCount = Convert.ToInt32(dr["ContainerCount"].ToString());
                            string chemicalAmount = dr["ChemicalAmount"].ToString();
                            double amountLeft = Convert.ToDouble(dr["AmountLeft"].ToString());
                            string containerType = dr["ContainerType"].ToString();
                            double total = Convert.ToDouble(dr["Total"].ToString());
                            string partialContainer = dr["PartialContainer"].ToString();
                            string category = dr["Category"].ToString();

                            // Subtracts the data in the inventory table when a removal transaction is created
                            int alterContainerCount = containerCount - Convert.ToInt32(DropDownListQuantity.SelectedItem.Text);
                            double alterTotal = total - (amountLeft * Convert.ToInt32(DropDownListQuantity.SelectedItem.Text));

                            // total amount of chemical the user takes
                            double userTotal = amountLeft * Convert.ToInt32(DropDownListQuantity.SelectedItem.Text);

                            // query to alter the chemical amount and total in the existing row
                            SqlCommand com3 = new SqlCommand("UPDATE dbo.tblInventorySFS SET ContainerCount='" + alterContainerCount.ToString() + "', Total= '" + alterTotal.ToString() + "' WHERE Prescription='" + Request.QueryString["prescription"] + "' AND PartialContainer='" + partial + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation = 'Russellville'", conn2);
                            com3.ExecuteNonQuery();

                            // query to check if a new row should be created (if there are no duplicates, exists == 0) or whether a row should be updated (if there are duplicates, exists > 0)
                            SqlCommand checkRecords = new SqlCommand("SELECT COUNT(*) FROM dbo.tblInventorySFS WHERE CurrentLocation ='" + Session["new"] + "' AND Prescription ='" + DropDownListProduct.SelectedItem.Text + "' AND AmountLeft= '" + AmountLeft + "' AND PartialContainer='" + partial + "'", conn2);
                            int exists = (int)checkRecords.ExecuteScalar();
                            if (exists == 0)
                            {
                                // query to insert record with the user, chemical, and how much chemical they took if there is no other row that matches
                                string insertQuery = "INSERT INTO dbo.tblInventorySFS(ItemNo, Prescription, CurrentLocation, ContainerCount, ChemicalAmount, AmountLeft, ContainerType, Total, PartialContainer, Category) values ('" + itemNo + "','" + prescription + "','" + Session["new"] + "','" + DropDownListQuantity.SelectedItem.Text + "','" + chemicalAmount + "','" + amountLeft + "','" + containerType + "','" + userTotal+ "','" +partial+"','"+category+ "')";
                                SqlCommand com4 = new SqlCommand(insertQuery, conn2);
                                com4.ExecuteNonQuery();
                            }
                            else if (exists == 1)
                            {
                                using (SqlCommand com4 = new SqlCommand("SELECT * FROM dbo.tblInventorySFS WHERE Prescription='" + Request.QueryString["prescription"] + "' AND PartialContainer='" + partial + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation = '" + Session["new"] + "'", conn2))
                                {
                                    SqlDataReader reader2 = com4.ExecuteReader();
                                    DataTable dt2 = new DataTable();
                                    dt2.Load(reader2);
                                    // Only runs once (dt2 only has a single row)
                                    foreach (DataRow dr2 in dt2.Rows)
                                    {
                                        int newContainerCount = Convert.ToInt32(dr2["ContainerCount"].ToString());
                                        double oldAmountLeft = Convert.ToDouble(dr2["AmountLeft"].ToString());

                                        newContainerCount = newContainerCount + Convert.ToInt32(DropDownListQuantity.SelectedItem.Text);
                                        double newTotal = newContainerCount * oldAmountLeft;

                                        SqlCommand com5 = new SqlCommand("UPDATE dbo.tblInventorySFS SET ContainerCount = '" + newContainerCount + "', Total='" + newTotal + "' WHERE Prescription='" + Request.QueryString["prescription"] + "' AND PartialContainer='" + partial + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation = '" + Session["new"] + "'", conn2);
                                        com5.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                Response.Write("ERROR: Duplicates found in the table while trying to insert data.");
                            }
                        }
                        conn2.Close();
                    }
                }
            }
            // Removal Transaction to Inventory table finished---------------------------------------------------------------------------------------------------------------------------------------------------

            // This block creates the addition information for inventory table-----------------------------------------------------------------------------------------------------------------------------------
            else if (DropDownListTransaction.Text == "ADDITION")
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("SELECT * FROM dbo.tblInventorySFS WHERE Prescription='" + Request.QueryString["prescription"] + "' AND PartialContainer='" + partial + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "'", conn))
                    {
                        conn.Open();

                        // creates a reader and stores the rows in a datatable
                        // only one row should be created in the table and then parsed through with a foreach loop
                        SqlDataReader reader = com.ExecuteReader();
                        DataTable dt = new DataTable();
                        var filtered = dt.AsEnumerable().Where(row => row.Field<string>("CurrentLocation") == Session["new"].ToString());
                        dt.Load(reader);
                        foreach (DataRow dr in filtered)
                        {
                            foreach (var item in dr.ItemArray)
                            {
                                Response.Write(item);
                            }

                            string itemNo = dr["ItemNo"].ToString();
                            string prescription = dr["Prescription"].ToString();
                            string currentLocation = dr["CurrentLocation"].ToString();
                            int containerCount = Convert.ToInt32(dr["ContainerCount"].ToString());
                            string chemicalAmount = dr["ChemicalAmount"].ToString();
                            double amountLeft = Convert.ToDouble(dr["AmountLeft"].ToString());
                            string containerType = dr["ContainerType"].ToString();
                            double total = Convert.ToDouble(dr["Total"].ToString());
                            string partialContainer = dr["PartialContainer"].ToString();
                            string category = dr["Category"].ToString();

                            // Subtracts the data in the inventory table when a removal transaction is created
                            int alterContainerCount = containerCount - Convert.ToInt32(DropDownListQuantity.SelectedItem.Text);
                            double alterTotal = total - (amountLeft * Convert.ToInt32(DropDownListQuantity.SelectedItem.Text));

                            // total amount of chemical the user takes
                            double userTotal = amountLeft * Convert.ToInt32(DropDownListQuantity.SelectedItem.Text);

                            // query to alter the chemical amount and total in the existing row
                            SqlCommand com3 = new SqlCommand("UPDATE dbo.tblInventorySFS SET ContainerCount='" + alterContainerCount.ToString() + "', Total= '" + alterTotal.ToString() + "' WHERE Prescription='" + Request.QueryString["prescription"] + "' AND PartialContainer='" + partial + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation = '"+Session["new"]+"'", conn);
                            com3.ExecuteNonQuery();

                            // query to check if a new row should be created (if there are no duplicates, exists == 0) or whether a row should be updated (if there are duplicates, exists > 0)
                            SqlCommand checkRecords = new SqlCommand("SELECT COUNT(*) FROM dbo.tblInventorySFS WHERE CurrentLocation ='Russellville' AND Prescription ='" + DropDownListProduct.SelectedItem.Text + "' AND AmountLeft= '" + AmountLeft + "' AND PartialContainer='" + partial + "'", conn);
                            int exists = (int)checkRecords.ExecuteScalar();

                            if(exists == 0)
                            {
                                // query to insert record with the user, chemical, and how much chemical they took if there is no other row that matches
                                string insertQuery = "INSERT INTO dbo.tblInventorySFS(ItemNo, Prescription, CurrentLocation, ContainerCount, ChemicalAmount, AmountLeft, ContainerType, Total, PartialContainer, Category) values ('" + itemNo + "','" + prescription + "','" + Session["new"] + "','" + DropDownListQuantity.SelectedItem.Text + "','" + chemicalAmount + "','" + amountLeft + "','" + containerType + "','" + userTotal + "','" + partial + "','" + category + "')";
                                SqlCommand com4 = new SqlCommand(insertQuery, conn);
                                com4.ExecuteNonQuery();
                            }
                            else if (exists == 1)
                            {
                                // Query to change a record if a record is found
                                Response.Write("here");
                            }
                            else
                            {
                                Response.Write("ERROR: duplicates found in the table while trying to insert data");
                            }

                        }
                        conn.Close();
                    }
                }
            }
            // Addition Transaction to Inventory table finished-------------------------------------------------------------------------------------------------------------------------------------------------





            //do later...
            else if (DropDownListTransaction.Text == "TRANSFER")
            {

            }
        }
        catch (Exception ex)
        {
            Response.Write("ERROR:" + ex.ToString());
        }
    }


    /*
     * The below functions are for post back that grabs the information in the drop down list and put it in the URL to be accessed later
     * 
     */
    protected void TextBoxCrewNumber_TextChanged(object sender, EventArgs e)
    {
    }

    protected void DropDownListTransaction_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Postback for TransactionType
        string transaction = DropDownListTransaction.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction=" + transaction);
    }

    protected void DropDownListProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Postback for Product
        string prescription = DropDownListProduct.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction=" + Request.QueryString["transaction"] + "&prescription=" + prescription);
    }

    protected void DropDownListPartial_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Postback for Partial
        string partial = DropDownListPartial.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction=" + Request.QueryString["transaction"] + "&prescription=" + Request.QueryString["prescription"] + "&partial=" + partial);
    }

    protected void DropDownListAmount_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Postback for Amount
        string amount = DropDownListAmount.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction=" + Request.QueryString["transaction"] + "&prescription=" + Request.QueryString["prescription"] + "&partial=" + Request.QueryString["partial"] + "&amount=" + amount);
    }

    protected void DropDownListQuantity_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Postback for Quantity
        string quantity = DropDownListQuantity.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction=" + Request.QueryString["transaction"] + "&prescription=" + Request.QueryString["prescription"] + "&partial=" + Request.QueryString["partial"] + "&amount=" + Request.QueryString["amount"] + "&quantity=" + quantity);
    }
}
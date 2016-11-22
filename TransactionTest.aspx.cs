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


    //called from Page_PreInit
    protected void transaction()
    {
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
                partial();
            }

        }

        //Do later...
        else if (Request.QueryString["transaction"] == "ADDITION")
        {
            DropDownListTransaction.Text = "ADDITION";
            Response.Write("Addition");
        }
        else if (Request.QueryString["transaction"] == "TRANSFER")
        {
            DropDownListTransaction.Text = "TRANSFER";
            Response.Write("Transfer");
        }
    }

    protected void partial()
    {

        if(Request.QueryString["partial"] != null)
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
                using (SqlCommand cmd = new SqlCommand("SELECT CONCAT(AmountLeft, ' ', ContainerType) as combine FROM dbo.tblInventorySFS WHERE Prescription ='" + Request.QueryString["prescription"] + "' AND PartialContainer = '"+partials+"' AND CurrentLocation = 'Russellville'"))
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
                SqlCommand cmd = new SqlCommand("SELECT ContainerCount FROM dbo.tblInventorySFS WHERE Prescription ='" + Request.QueryString["prescription"] + "' AND PartialContainer ='"+partials+"' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation = 'Russellville'", con);
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
        try { 

            if(DropDownListTransaction.Text == "REMOVAL")
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



                //This block inserts the transaction into the transactions table-------------------------------------
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalTransactionListConnectionString"].ConnectionString);
                conn.Open();

                string insertTransaction = "INSERT INTO dbo.tblInventorytransactionsSFS(TransactionItemId, EmployeeId, CrewNumber, TransactionType, Quantity, Measurement, CreatedDate, Comments) values(@transid, @empid, @crew, @ttype, @quant, @measure, @date, @comment)";
                SqlCommand com = new SqlCommand(insertTransaction, conn);



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
                //End of transaction table block-----------------------------------------------------------------------



                //This block creates the removal information for inventory table---------------------------------------
                SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString);
                conn2.Open();

                string selectQuery = "SELECT * FROM dbo.tblInventorySFS WHERE Prescription='" + Request.QueryString["prescription"] + "' AND PartialContainer='" + partial + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='"+ ContainerType+"' AND CurrentLocation = 'Russellville'" ;
                SqlCommand com2 = new SqlCommand(selectQuery, conn2);


                //This is the reader that grabs the rows that are pulled back from the above sql statement. There should only be one row pulled back
                using (SqlDataReader reader = com2.ExecuteReader())
                {
                    //only executed once
                    while (reader.Read())
                    {
                        //pulls all the values from the sql statement through a reader that should only get executed once
                        string invNo = reader["InvNo"].ToString();
                        string ordered = reader["Ordered"].ToString();
                        string shipped = reader["Shipped"].ToString();
                        int containerCount = Convert.ToInt32(reader["ContainerCount"].ToString());
                        string itemNo = reader["ItemNo"].ToString();
                        string prescription = reader["Prescription"].ToString();
                        string unitPrice = reader["UnitPrice"].ToString();
                        string extendedPrice = reader["ExtendedPrice"].ToString();
                        string category = reader["Category"].ToString();
                        string originalLocation = reader["OriginalLocation"].ToString();
                        string currentLocation = reader["CurrentLocation"].ToString();
                        string partialContainer = reader["PartialContainer"].ToString();
                        string chemicalAmount = reader["ChemicalAmount"].ToString();
                        double amountLeft = Convert.ToDouble(reader["AmountLeft"].ToString());
                        double total = Convert.ToDouble(reader["Total"].ToString());
                        string containerType = reader["ContainerType"].ToString();
                        string wetDry = reader["WetDry"].ToString();


                        //Subtracts the data in the inventory table when a removal transaction is created
                        int alterContainerCount = containerCount - Convert.ToInt32(DropDownListQuantity.SelectedItem.Text);
                        double alterTotal = total - (amountLeft * Convert.ToInt32(DropDownListQuantity.SelectedItem.Text));

                        SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString);
                        conn3.Open();
                        //query to alter the chemical amount and total in the existing row
                        string updateQuery = "UPDATE dbo.tblInventorySFS SET ContainerCount='" + alterContainerCount.ToString() + "', Total= '" + alterTotal.ToString() + "' WHERE Prescription='" + Request.QueryString["prescription"] + "' AND PartialContainer='" + partial + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation = 'Russellville'";
                        SqlCommand com3 = new SqlCommand(updateQuery, conn3);
                        com3.ExecuteNonQuery();

                        //amount that user takes
                        double userTotal = amountLeft * Convert.ToInt32(DropDownListQuantity.SelectedItem.Text);





                        //query to insert record that displays the person with the chemical and how much they took
                        SqlCommand checkRecords = new SqlCommand("SELECT COUNT(*) FROM dbo.tblInventorySFS WHERE CurrentLocation ='" + Session["new"] + "' AND Prescription ='" +DropDownListProduct.SelectedItem.Text + "' AND AmountLeft= '" +AmountLeft+"' AND PartialContainer='" +partial+ "'", conn3);
                        int exists = (int)checkRecords.ExecuteScalar();
                        if (exists == 0)
                        {
                            string insertQuery = "INSERT INTO dbo.tblInventorySFS(InvNo, Ordered, Shipped, ContainerCount, ItemNo, Prescription, UnitPrice, ExtendedPrice, Category, OriginalLocation, CurrentLocation, PartialContainer, ChemicalAmount, AmountLeft, Total, ContainerType, WetDry) values('" + invNo + "','" + ordered + "','" + shipped + "','" + DropDownListQuantity.SelectedItem.Text + "','" + itemNo + "','" + prescription + "','" + unitPrice + "','" + extendedPrice + "','" + category + "','" + originalLocation + "','" + Session["new"] + "','" + partialContainer + "','" + chemicalAmount + "','" + amountLeft + "','" + userTotal + "','" + containerType + "','" + wetDry + "')";
                            SqlCommand com4 = new SqlCommand(insertQuery, conn3);
                            com4.ExecuteNonQuery();
                            conn3.Close();
                        }
                        else if (exists > 0)
                        {
                            SqlConnection conn4 = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString);
                            conn4.Open();
                            string selectQuery2 = "SELECT * FROM dbo.tblInventorySFS WHERE Prescription='" + Request.QueryString["prescription"] + "' AND PartialContainer='" + partial + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation = '"+Session["new"]+"'";
                            SqlCommand com4 = new SqlCommand(selectQuery2, conn4);
                            using (SqlDataReader reader2= com4.ExecuteReader())
                            {
                                //error: cant have nested readers
                                while (reader2.Read())
                                {
                                    int newContainerCount = Convert.ToInt32(reader["ContainerCount"].ToString());
                                    double oldAmountLeft = Convert.ToDouble(reader["AmountLeft"].ToString());

                                    newContainerCount = newContainerCount + Convert.ToInt32(DropDownListQuantity.SelectedItem.Text);
                                    double newTotal = newContainerCount * oldAmountLeft;

                                    string newUpdateQuery = "UPDATE dbo.tblInventorySFS SET ContainerCount = '" +newContainerCount+ "' AND Total='" + newTotal + "' WHERE Prescription='" + Request.QueryString["prescription"] + "' AND PartialContainer='" + partial + "' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation = '" + Session["new"] + "'";
                                    SqlCommand com5 = new SqlCommand(newUpdateQuery, conn4);
                                    com5.ExecuteNonQuery();




                                }
                            }
                        }

                    }
                }
                //Removal Transaction to Inventory table finished---------------------------------------------------------------------








            }
            //do later...
            else if(DropDownListTransaction.Text == "ADDITION")
            {

            }




            else if(DropDownListTransaction.Text == "TRANSFER")
            {

            }
        }
        catch (Exception ex)
        {
            Response.Write("ERROR:"+ex.ToString());
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
        string prescription= DropDownListProduct.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction="+ Request.QueryString["transaction"] + "&prescription=" + prescription);
    }

    protected void DropDownListPartial_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Postback for Partial
        string partial = DropDownListPartial.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction=" + Request.QueryString["transaction"] + "&prescription=" + Request.QueryString["prescription"] + "&partial=" +partial);
    }

    protected void DropDownListAmount_SelectedIndexChanged(object sender, EventArgs e)
    {
        string amount = DropDownListAmount.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction=" + Request.QueryString["transaction"] + "&prescription=" + Request.QueryString["prescription"] + "&partial=" + Request.QueryString["partial"] + "&amount=" + amount);
    }

    protected void DropDownListQuantity_SelectedIndexChanged(object sender, EventArgs e)
    {
        string quantity = DropDownListQuantity.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction=" + Request.QueryString["transaction"] + "&prescription=" + Request.QueryString["prescription"] + "&partial=" + Request.QueryString["partial"] + "&amount=" + Request.QueryString["amount"] + "&quantity=" + quantity);
    }
}
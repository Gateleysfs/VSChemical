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
using System.Diagnostics;

public partial class Transaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks to see if someone is logged in. If not, redirects to login page
        if (Session["new"] == null)
            Response.Redirect("Login.aspx");
    }

    //If logout button is pressed
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
            DropDownListTransaction.Text = "REMOVAL";

            DropDownListBarcode.Visible = true;
            LabelBarcode.Visible = true;

            string constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Barcode FROM dbo.tblInventorySFS WHERE CurrentLocation ='Russellville'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    DropDownListBarcode.DataSource = cmd.ExecuteReader();
                    DropDownListBarcode.DataTextField = "Barcode";
                    DropDownListBarcode.DataBind();
                    con.Close();
                }
            }
            DropDownListBarcode.Items.Insert(0, new ListItem("", ""));

            if (Request.QueryString["barcode"] != null)
            {
                DropDownListBarcode.SelectedItem.Text = Request.QueryString["barcode"];
                ButtonSubmit.Visible = true;

            }
        }

        //ADDITION
        else if (Request.QueryString["transaction"] == "ADDITION")
        {
            DropDownListTransaction.Text = "ADDITION";


            DropDownListBarcode.Visible = true;
            LabelBarcode.Visible = true;

            string constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Barcode FROM dbo.tblInventorySFS WHERE CurrentLocation ='" + Session["new"] + "'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    DropDownListBarcode.DataSource = cmd.ExecuteReader();
                    DropDownListBarcode.DataTextField = "Barcode";
                    DropDownListBarcode.DataBind();
                    con.Close();
                }
            }

            DropDownListBarcode.Items.Insert(0, new ListItem("", ""));

            // Because of postback, gets the barcode from the url and puts it in the product drop down
            DropDownListBarcode.Text = Request.QueryString["barcode"];

            //pulls the barcode from the url
            if (Request.QueryString["barcode"] != null)
            {
                //sets the label and DropDownList of AmountLeft to visible so the user can use them
                DropDownListAmountLeft.Visible = true;
                LabelAmountLeft.Visible = true;



                constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT AmountLeft FROM dbo.tblInventorySFS WHERE Barcode ='" + Request.QueryString["barcode"] + "'", con))
                    {
                        con.Open();
                        string temp = cmd.ExecuteScalar().ToString();


                        //pulls out the ChemicalAmount from the url
                        int AmountLeft = Int32.Parse(Regex.Match(temp, @"\d+").Value);
                        //pulls out the ContainerType from the url
                        string ContainerType = Regex.Replace(temp, @"[\d-]", string.Empty);
                        ContainerType = ContainerType.Trim();

                        //populates the DropDownListAmountLeft with amounts
                        DropDownListAmountLeft.Items.Add(new ListItem("", "0"));
                        for (int i = 0; i <= AmountLeft; i++)
                        {
                            DropDownListAmountLeft.Items.Add(new ListItem(i.ToString() + " " + ContainerType));
                        }
                        DropDownListAmountLeft.DataBind();
                    }
                }


                if (Request.QueryString["amountLeft"] != null)
                {
                    DropDownListAmountLeft.SelectedItem.Text = Request.QueryString["amountLeft"];

                    LabelCrewNumber.Visible = true;
                    TextBoxCrewNumber.Visible = true;
                    ButtonSubmit.Visible = true;
                }
            }
        }

        // TRANSFER do later...
        else if (Request.QueryString["transaction"] == "TRANSFER")
        {
            DropDownListTransaction.Text = "TRANSFER";
        }
    }

    //This function is the first function to be ran, even before Page_Init.
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        //disable controls so they will show up one by one after each postback
        LabelCrewNumber.Visible = false;
        TextBoxCrewNumber.Visible = false;
        ButtonSubmit.Visible = false;
        LabelAmountLeft.Visible = false;
        DropDownListAmountLeft.Visible = false;
        LabelBarcode.Visible = false;
        DropDownListBarcode.Visible = false;

        //transaction is called which performas all the logic of the transactions
        transaction();
    }


    /*
     * When the ButtonSubmit_Click is clicked, the information inside the textboxes will be placed into the database. 
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
            //This block inserts the transaction into the transactions table--------------------------------------------------------------------------------------------------------------------------
            //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalTransactionListConnectionString"].ConnectionString))
            //{
            //    using (SqlCommand com = new SqlCommand("INSERT INTO dbo.tblInventorytransactionsSFS(TransactionItemId, EmployeeId, CrewNumber, TransactionType, Quantity, Measurement, CreatedDate, Comments) values(@transid, @empid, @crew, @ttype, @quant, @measure, @date, @comment)", conn))
            //    {
            //        conn.Open();

            //        //Select a unique Inventory ID that matches the Product drop down menu chosen. It is then cast into an int so it can be inserted into dbo.tblInventorytransactionsSFS
            //        string selectTranId = "SELECT ID FROM dbo.tblInventorySFS WHERE Prescription='" + DropDownListProduct.SelectedItem.ToString() + "'AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType + "' AND CurrentLocation = 'Russellville'";
            //        SqlCommand tranId = new SqlCommand(selectTranId, conn);
            //        Int32 transaction = ((Int32)tranId.ExecuteScalar());

            //        //Select a unique User ID that matches the Username that is currently logged in then cast it to an int so it can be inserted into dbo.tblInventorytransactionsSFS
            //        string selectEmpId = "SELECT UserID FROM dbo.tblEmployeeSFS WHERE Username='" + Session["new"].ToString() + "'";
            //        SqlCommand userId = new SqlCommand(selectEmpId, conn);
            //        Int32 id = ((Int32)userId.ExecuteScalar());


            //        com.Parameters.AddWithValue("@transid", transaction);
            //        com.Parameters.AddWithValue("@empid", id);
            //        com.Parameters.AddWithValue("@crew", TextBoxCrewNumber.Text);
            //        com.Parameters.AddWithValue("@ttype", DropDownListTransaction.SelectedItem.ToString());
            //        com.Parameters.AddWithValue("@quant", AmountLeft);
            //        com.Parameters.AddWithValue("@measure", ContainerType);
            //        com.Parameters.AddWithValue("@date", DateTime.Now);
            //        com.Parameters.AddWithValue("@comment", TextBoxComment.Text);
            //        com.ExecuteNonQuery();
            //        conn.Close();
            //    }
            //}
            // End of transaction table block-------------------------------------------------------------------------------------------------------------------------------------------------------------------

            // This block creates the removal information for inventory table-----------------------------------------------------------------------------------------------------------------------------------
            if (DropDownListTransaction.Text == "REMOVAL")
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("SELECT * FROM dbo.tblInventorySFS WHERE Barcode='" + Request.QueryString["barcode"] + "'", conn))
                    {
                        conn.Open();
                        // creates a reader and stores the rows in a datatable
                        SqlDataReader reader = com.ExecuteReader();
                        //creates a new datatable called dt
                        DataTable dt = new DataTable();

                        dt.Load(reader);

                        foreach (DataRow dr in dt.Rows)
                        {
                            string ItemNo = dr["ItemNo"].ToString();
                            string Barcode = dr["Barcode"].ToString();
                            string Prescription = dr["Prescription"].ToString();
                            string CurrentLocation = dr["CurrentLocation"].ToString();
                            string ContainerCount = dr["ContainerCount"].ToString();
                            string ChemicalAmount = dr["ChemicalAmount"].ToString();
                            string AmountLeft = dr["AmountLeft"].ToString();
                            string ContainerType = dr["ContainerType"].ToString();
                            string Total = dr["Total"].ToString();
                            string PartialContainer = dr["PartialContainer"].ToString();
                            string Category = dr["Category"].ToString();
                            string Contract = dr["Contract"].ToString();

                            SqlCommand com3 = new SqlCommand("UPDATE dbo.tblInventorySFS SET CurrentLocation='" + Session["new"] + "' WHERE Barcode='" + Request.QueryString["barcode"] + "'", conn);
                            com3.ExecuteNonQuery();
                        }
                    }
                }
            }
            // Removal Transaction to Inventory table finished---------------------------------------------------------------------------------------------------------------------------------------------------

            // This block creates the addition information for inventory table-----------------------------------------------------------------------------------------------------------------------------------

            else if (DropDownListTransaction.Text == "ADDITION")
            {


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("SELECT * FROM dbo.tblInventorySFS WHERE Barcode='" + Request.QueryString["barcode"] + "'", conn))
                    {
                        conn.Open();
                        // creates a reader and stores the rows in a datatable
                        SqlDataReader reader = com.ExecuteReader();
                        //creates a new datatable called dt
                        DataTable dt = new DataTable();

                        dt.Load(reader);

                        foreach (DataRow dr in dt.Rows)
                        {
                            string ItemNo = dr["ItemNo"].ToString();
                            string Barcode = dr["Barcode"].ToString();
                            string Prescription = dr["Prescription"].ToString();
                            string CurrentLocation = dr["CurrentLocation"].ToString();
                            string ContainerCount = dr["ContainerCount"].ToString();
                            string ChemicalAmount = dr["ChemicalAmount"].ToString();
                            string AmountLeft = dr["AmountLeft"].ToString();
                            string ContainerType = dr["ContainerType"].ToString();
                            string Total = dr["Total"].ToString();
                            string PartialContainer = dr["PartialContainer"].ToString();
                            string Category = dr["Category"].ToString();
                            string Contract = dr["Contract"].ToString();

                            if(Int32.Parse(ChemicalAmount) == Int32.Parse(Request.QueryString["amountLeft"]))
                            {
                            SqlCommand com3 = new SqlCommand("UPDATE dbo.tblInventorySFS SET CurrentLocation='Russellville', AmountLeft='" + Request.QueryString["amountLeft"] + "' WHERE Barcode='" + Request.QueryString["barcode"] + "'", conn);
                            com3.ExecuteNonQuery();
                            }
                            else if (Int32.Parse(ChemicalAmount) > Int32.Parse(Request.QueryString["amountLeft"]))
                            {
                            SqlCommand com3 = new SqlCommand("UPDATE dbo.tblInventorySFS SET CurrentLocation='Russellville', AmountLeft='" + Request.QueryString["amountLeft"] + "', PartialContainer = 'True' WHERE Barcode='" + Request.QueryString["barcode"] + "'", conn);
                            com3.ExecuteNonQuery();
                            }

                        }
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
     * The below functions are for post back which grabs the information in the drop down list and puts it in the URL to be accessed later
     * 
     */
    protected void TextBoxCrewNumber_TextChanged(object sender, EventArgs e)
    {
    }

    protected void DropDownListTransaction_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Postback for TransactionType
        string transaction = DropDownListTransaction.SelectedItem.Text;
        Response.Redirect("~/TransactionTestCopy.aspx?transaction=" + transaction);
    }
    protected void DropDownListBarcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Postback for Product
        string barcode = DropDownListBarcode.SelectedItem.Text;
        Response.Redirect("~/TransactionTestCopy.aspx?transaction=" + Request.QueryString["transaction"] + "&barcode=" + barcode);
    }
    protected void DropDownListAmountLeft_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Postback for AmountLeft
        string amountLeft = DropDownListAmountLeft.SelectedItem.Text;
        Response.Redirect("~/TransactionTestCopy.aspx?transaction=" + Request.QueryString["transaction"] + "&barcode=" + Request.QueryString["barcode"] + "&amountLeft=" + amountLeft);
    }





    //Not needed, only used for debugging. Prints a data table in the debug window of Visual Studio.
    public void DebugTable(DataTable table)
    {
        Debug.WriteLine("--- DebugTable(" + table.TableName + ") ---");
        int rowCount = table.Rows.Count;
        int colCount = table.Columns.Count;

        // Header
        for (int i = 0; i < table.Columns.Count; i++)
        {
            string s = table.Columns[i].ToString();
            Debug.Write(String.Format("{0,-20} | ", s));
        }
        Debug.Write(Environment.NewLine);
        for (int i = 0; i < table.Columns.Count; i++)
        {
            Debug.Write("---------------------|-");
        }
        Debug.Write(Environment.NewLine);

        // Data
        for (int i = 0; i < rowCount; i++)
        {
            DataRow row = table.Rows[i];
            //Debug.WriteLine("{0} {1} ", row[0], row[1]);
            for (int j = 0; j < colCount; j++)
            {
                string s = row[j].ToString();
                if (s.Length > 20) s = s.Substring(0, 17) + "...";
                Debug.Write(String.Format("{0,-20} | ", s));
            }
            Debug.Write(Environment.NewLine);
        }
        for (int i = 0; i < table.Columns.Count; i++)
        {
            Debug.Write("---------------------|-");
        }
        Debug.Write(Environment.NewLine);
    }


}
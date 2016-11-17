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
        //if (Session["new"] == null)
        //    Response.Redirect("Login.aspx");
    }


    protected void Page_PreInit(Object sender, EventArgs e)
    {
        //disable controls
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

            DropDownListProduct.Text = Request.QueryString["product"];

            if (Request.QueryString["product"] != null)
            {
                DropDownListPartial.Visible = true;
                LabelPartial.Visible = true;

                if (Request.QueryString["partial"] == "Yes")
                {
                    //put the text back in dropdownlistpartial after postback
                    DropDownListPartial.Text = "Yes";

                    //set dropdownlist amount to visible
                    DropDownListAmount.Visible = true;
                    LabelAmount.Visible = true;

                    //populates the dropdownlistamount so it corresponds with the product and partial dropdownlists
                    constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT CONCAT(AmountLeft, ' ', ContainerType) as combine FROM dbo.tblInventorySFS WHERE Prescription ='" + Request.QueryString["product"] +"' AND PartialContainer = 'True'"))
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

                    if (Request.QueryString["amount"]!= null)
                    {
                        DropDownListAmount.SelectedItem.Text = Request.QueryString["amount"];
                        LabelQuantity.Visible = true;
                        DropDownListQuantity.Visible = true;


                    }
                }
                else if(Request.QueryString["partial"] == "No")
                {
                    DropDownListPartial.Text = "No";

                    DropDownListAmount.Visible = true;
                    LabelAmount.Visible = true;

                    //populates the dropdownlistamount so it corresponds with the product and partial dropdownlists
                    constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT CONCAT(AmountLeft, ' ', ContainerType) as combine FROM dbo.tblInventorySFS WHERE Prescription ='" + Request.QueryString["product"] + "' AND PartialContainer = 'False'"))
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
                        //pulls out the prescription from the URL
                        string prescription = Request.QueryString["product"];



                        constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT ContainerCount FROM dbo.tblInventorySFS WHERE Prescription ='" + prescription + "' AND PartialContainer = 'False' AND AmountLeft='" + AmountLeft + "' AND ContainerType='" + ContainerType +"'"))
                            {
                                //Start here on 
                                //string test = (string)cmd.ExecuteScalar();
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = con;
                                con.Open();
                                DropDownListQuantity.DataSource = cmd.ExecuteReader();
                                DropDownListQuantity.DataTextField = "ContainerCount";

                                DropDownListQuantity.DataBind();
                                con.Close();
                            }
                        }

                    }
                }

            }
        }





        //Do later...
        else if(Request.QueryString["transaction"] == "ADDITION")
        {
            DropDownListTransaction.Text = "ADDITION";
            Response.Write("Addition");
        }
        else if(Request.QueryString["transaction"] == "TRANSFER")
        {
            DropDownListTransaction.Text = "TRANSFER";
            Response.Write("Transfer");
        }
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
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalTransactionListConnectionString"].ConnectionString);
            conn.Open();

            string insertQuery = "INSERT INTO dbo.tblInventoryTransactionsSFS ( TransactionItemId, EmployeeId, CrewNumber, TransactionType, Quantity, Measurement, CreatedDate, Comments) values( @transid, @empid, @crew, @ttype, @quant, @measure, @date, @comment)";
            SqlCommand com = new SqlCommand(insertQuery, conn);

            //Select a unique ID that matches the Product drop down menu chosen. It is then cast into an int so it can be inserted into dbo.tblInventorytransactionsSFS
            string selectTranId = "SELECT ID FROM dbo.tblInventorySFS WHERE ItemNo='"+ DropDownListProduct.SelectedItem.ToString() +"'";
            SqlCommand tranId = new SqlCommand(selectTranId, conn);
            Int32 transaction = ((Int32)tranId.ExecuteScalar());


            //Select a unique ID that matches the Username that is currently logged in then cast it to an int so it can be inserted into dbo.tblInventorytransactionsSFS
            string selectEmpId = "SELECT UserID FROM dbo.tblEmployeeSFS WHERE Username='"+ Session["new"].ToString() +"'";
            SqlCommand userId = new SqlCommand(selectEmpId, conn);
            Int32 id = ((Int32)userId.ExecuteScalar());




            //values being inserted
            com.Parameters.AddWithValue("@transid", transaction);
            com.Parameters.AddWithValue("@empid", id);
            com.Parameters.AddWithValue("@crew", TextBoxCrewNumber.Text);
            com.Parameters.AddWithValue("@ttype", DropDownListTransaction.SelectedItem.ToString());
            com.Parameters.AddWithValue("@quant", TextBoxAmount.Text);
            com.Parameters.AddWithValue("@measure", DropDownListWeight.SelectedItem.ToString());
            com.Parameters.AddWithValue("@date", DateTime.Now);
            com.Parameters.AddWithValue("@comment", TextBoxComment.Text);
            com.ExecuteNonQuery();

            Response.Redirect("Transaction.aspx");


            conn.Close();

        }
        catch (Exception ex)
        {
            Response.Write("ERROR:"+ex.ToString());
        }
    }

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
        string product = DropDownListProduct.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction="+ Request.QueryString["transaction"] + "&product=" + product);
    }

    protected void DropDownListPartial_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Postback for Partial
        string partial = DropDownListPartial.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction=" + Request.QueryString["transaction"] + "&product=" + Request.QueryString["product"] + "&partial=" +partial);
    }

    protected void DropDownListAmount_SelectedIndexChanged(object sender, EventArgs e)
    {
        string amount = DropDownListAmount.SelectedItem.Text;
        Response.Redirect("~/TransactionTest.aspx?transaction=" + Request.QueryString["transaction"] + "&product=" + Request.QueryString["product"] + "&partial=" + Request.QueryString["partial"] + "&amount=" + amount);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Transaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks to see if someone is logged in. If not, redirects to login page
        if (Session["new"] == null)
            Response.Redirect("Login.aspx");
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
            string selectTranId = "SELECT ID FROM dbo.tblInventorySFS WHERE ChemicalName='"+ DropDownListProduct.SelectedItem.ToString() +"'";
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

            Response.Write("Transaction Sent");
            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("ERROR:"+ex.ToString());
        }
    }

    protected void DropDownListTransaction_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownListProductType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownListWetDry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
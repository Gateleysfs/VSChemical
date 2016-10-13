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

    }


    /*
     * When the submit button is clicked, the information inside the textboxes will be placed
     * into the database. 
     * The ID is unique increment
     * The EmpId is obtained from the current logged in session
     * The TransactionId is obtained from the corresponding Id in the Inventory table
     * The CreatedDate is obtained from the date and time function
     * Everything else will be entered by the user
     */
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        //This code is working but I commented it out in case there are any unexpected errors
        /*
        try { 
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalTransactionListConnectionString"].ConnectionString);
            conn.Open();
            string insertQuery = "INSERT INTO dbo.tblInventoryTransactionsSFS (ID, TransactionItemId, EmployeeId, CrewNumber, TransactionType, Quantity, Measurement, CreatedDate, Comments) values(@id, @transid, @empid, @crew, @ttype, @quant, @measure, @date, @comment)";

            SqlCommand com = new SqlCommand(insertQuery, conn);
            com.Parameters.AddWithValue("@id",1);
            com.Parameters.AddWithValue("@transid",1);
            com.Parameters.AddWithValue("@empid",1);
            com.Parameters.AddWithValue("@crew", TextBoxCrewNumber.Text);
            com.Parameters.AddWithValue("@ttype", DropDownListTransaction.SelectedItem.ToString());
            com.Parameters.AddWithValue("@quant", TextBoxAmount.Text);
            com.Parameters.AddWithValue("@measure", DropDownListWeight.SelectedItem.ToString());
            com.Parameters.AddWithValue("@date", DateTime.Now);
            com.Parameters.AddWithValue("@comment", "none");
            com.ExecuteNonQuery();
            
            //Response.Redirect("");

            Response.Write("Transaction Sent");
            conn.Close();
            
        }
        catch (Exception ex)
        {
            Response.Write("ERROR:"+ex.ToString());
        }
        */
    }

    protected void DropDownListTransaction_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
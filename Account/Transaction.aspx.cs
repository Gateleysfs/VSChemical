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

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        try { 
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalTransactionListConnectionString"].ConnectionString);
            conn.Open();
            string insertQuery = "INSERT INTO dbo.tblInventoryTransactionsSFS values(TransactionItemId, EmployeeId, CrewNumber, TransactionType, Quantity, CreatedDate, Comments) values (@trans, @empid, @ttype, @quant, @date, @comment)";
            SqlCommand com = new SqlCommand(insertQuery, conn);
            com.Parameters.AddWithValue("",);


            conn.Close();


            Response.Write("Transaction Sent");
        }
        catch (Exception ex)
        {
            Response.Write("ERROR:"+ex.ToString());
        }
    }

    protected void DropDownListTransaction_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
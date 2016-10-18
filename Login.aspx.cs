using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void TextBoxUsername_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBoxUsername_TextChanged1(object sender, EventArgs e)
    {

    }

    protected void Button_Login_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalEmployeeConnectionString"].ConnectionString);
        conn.Open();
        string checkuser = "select count(*) from dbo.tblEmployeeSFS where Username='" + TextBoxUsername.Text + "'";
        SqlCommand com = new SqlCommand(checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        if (temp == 1)
        {
            conn.Open();
            string checkPasswordQuery = "select Password from dbo.tblEmployeeSFS where Username='" + TextBoxUsername.Text + "'"; //sql for password
            SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
            string password = passComm.ExecuteScalar().ToString().Replace(" ", "");
            if (password == TextBoxPassword.Text)
            {
                Session["New"] = TextBoxUsername.Text;
                Response.Write("Password is correct");
                Response.Redirect("Home.aspx");
            }
            else
                Response.Write("Password is incorrect");
        }
        else
        {
            Response.Write("Username is incorrect");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

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

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        

        /*
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
        conn.Open();
        string checkuser = ""; //sql here
        SqlCommand com = new SqlCommand(checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        if (temp == 1)
        {
             conn.Open();
             string checkPasswordQuery = ""; //sql for password
             SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
             string password = passComm.ExecuteScalar().ToString();
             if(password== TextBoxPassword.Text)
             {
                Session["New"] = TextBoxUsername.Text;
                Response.Write("Password is correct");  
             }
             else
                Response.Write("Password is incorrect");
        }
        else
        {
            Response.Write("Username is incorrect");
        }
        */
    }

}
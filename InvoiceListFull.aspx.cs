using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class InvoiceListFull : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Checks to see if someone is logged in. If not, redirects to login page
        if (Session["new"] == null)
            Response.Redirect("Login.aspx");





        //if (Request.QueryString["selectedInvNo"] != null)
        //    Response.Write("From InvoiceList: selectedInvNo value = " + Request.QueryString["selectedInvNo"]);

        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInvoiceListFullConnectionString"].ConnectionString);
        //conn.Open();

        //string query = "SELECT * FROM dbo.tblInventorySFS, dbo.tblInvoiceSFS WHERE dbo.tblInventorySFS.InvNo = dbo.tblInvoiceSFS.InvNo AND dbo.tblInvoiceSFS.InvNo =\""+ Request.QueryString["selectedInvNo"] + "\"";
        //string query = "SELECT * FROM dbo.tblInventorySFS, dbo.tblInvoiceSFS WHERE dbo.tblInventorySFS.InvNo = dbo.tblInvoiceSFS.InvNo";
        //SqlCommand cmd = new SqlCommand(query, conn);
        //SqlDataReader rdr = cmd.ExecuteReader();
        //DataTable dataTable = new DataTable();
        //dataTable.Load(rdr);
        //while (rdr.Read())
        //{
        //    Response.Write(String.Format("{0}", rdr[0]));
        //}


        //Response.Write(query);
        //conn.Close();
    }
}
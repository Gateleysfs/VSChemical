using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Inventory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks to see if someone is logged in. If not, redirects to login page
        if (Session["new"] == null)
            Response.Redirect("Login.aspx");

        if (!this.IsPostBack)
            this.BindGrid();
    }

    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        //Logout of website when logout button is clicked
        Session["new"] = null;
        Response.Redirect("Login.aspx");
    }
    protected void Button(object sender, EventArgs e)
    {
        this.BindGrid();
    }
    private void BindGrid()
    {
        //establishing connection to the connection string
        string constr = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                if (DropDownList1.SelectedItem.ToString() == "All")
                {
                    //selects what is typed in the search bar. If nothing is typed, load entire table
                    cmd.CommandText = "SELECT * FROM [tblInventorySFS] WHERE Concat( Barcode, ' ', ItemName, ' ', AmountLeft, ' ', Measurement, ' ', ContractID) LIKE '%' + @Input+ '%'";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Input", TextBox2.Text.Trim());

                    DataTable dt = new DataTable();

                    //repopulates the table
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM[tblInventorySFS] WHERE " + DropDownList1.SelectedItem.ToString() + "  LIKE   '%' + @Input + '%'";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Input", TextBox2.Text.Trim());
                    DataTable dt = new DataTable();

                    //repopulates the table
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }

    //never called
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    // highlights any data in first column that is matched by the search bar
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = Regex.Replace(e.Row.Cells[0].Text, TextBox2.Text.Trim(), delegate (Match match)
            {
                return string.Format("<span style = 'background-color:#D9EDF7'>{0}</span>", match.Value);
            }, RegexOptions.IgnoreCase);
        }
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnClearCI_Click(object sender, EventArgs e)
    {
        TextBox2.Text = " ";
        this.BindGrid();
    }
}

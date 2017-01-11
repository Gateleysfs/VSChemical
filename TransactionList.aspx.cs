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

public partial class TransactionList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks to see if someone is logged in. If not, redirects to login page
        if (Session["new"] == null)
            Response.Redirect("Login.aspx");


        //This loads the full table if there have been no searches on the page
        if (!this.IsPostBack)
            this.BindGrid();
    }

    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        //Logout of website when logout button is clicked
        Session["new"] = null;
        Response.Redirect("Login.aspx");
    }

    protected void Search(object sender, EventArgs e)
    {
        //This is called when the search button is pressed. (in the HTML: OnClick="Search")
        this.BindGrid();
    }

    private void BindGrid()
    {
        //establishing connection to the connection string
        string constr = ConfigurationManager.ConnectionStrings["sfsChemicalTransactionListConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                if (DropDownListCategory.SelectedItem.ToString() == "All")
                {
                    //selects what is typed in the search bar. If nothing is typed, load entire table
                    cmd.CommandText = "SELECT ID, Barcode, ItemName, Employee, CrewNumber, Sender, Receiver, AmountLeft, ContainerSize, Measurement, CreatedDate, Program, Contract, Comments FROM [tblInventoryTransactionsSFS] WHERE  concat([tblInventoryTransactionsSFS].ID, ' ', Barcode, ' ', Employee, ' ', CrewNumber, ' ', Sender, ' ', Receiver, ' ', AmountLeft, ' ',ContainerSize, ' ',Measurement, ' ' , CreatedDate, ' ',Program, ' ', Contract, ' ', Comments) LIKE '%' + @Input + '%'";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Input", txtSearch.Text.Trim());
                    DataTable dt = new DataTable();


                    //repopulates the table
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                else if (DropDownListCategory.SelectedItem.ToString() == "ID")
                {
                    //selects what is typed in the search bar. If nothing is typed, load entire table
                    cmd.CommandText = "SELECT * FROM [tblInventoryTransactionsSFS] Where " + DropDownListCategory.SelectedItem.ToString() + " like @Input";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Input", txtSearch.Text.Trim());
                    DataTable dt = new DataTable();


                    //repopulates the table
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM[tblInventoryTransactionsSFS] WHERE " + DropDownListCategory.SelectedItem.ToString() + "  LIKE   '%' + @Input + '%'";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Input", txtSearch.Text.Trim());
                    DataTable dt = new DataTable();

                    //repopulates the table
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = Regex.Replace(e.Row.Cells[0].Text, txtSearch.Text.Trim(), delegate (Match match)
            {
                return string.Format("<span style = 'background-color:#D9EDF7'>{0}</span>", match.Value);
            }, RegexOptions.IgnoreCase);
        }
    }
}
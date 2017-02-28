﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Default2 : System.Web.UI.Page
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
        string constr = ConfigurationManager.ConnectionStrings["sfsChemicalInvoiceConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                if (DropDownListCategory.SelectedItem.ToString() == "All")
                {
                    //selects what is typed in the search bar. If nothing is typed, load entire table
                    cmd.CommandText = "SELECT * FROM[tblInvoiceSFS] WHERE Concat(ID, ' ', InvNo, ' ', Supplier, ' ', OrderFrom, ' ', OrderDate, ' ', InvDate, ' ', ShippedVia, ' ', ShippedTo, ' ', ShipDate, ' ', DueBy, ' ', FOB, ' ', TotalDue)  LIKE   '%' + @Input + '%'";
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
                //for advanced searching
                else
                {
                    cmd.CommandText = "SELECT * FROM[tblInvoiceSFS] WHERE " + DropDownListCategory.SelectedItem.ToString() + "  LIKE   '%' + @Input + '%'";
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
    protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
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
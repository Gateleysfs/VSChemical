using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_Delete_ : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private List<TableRow> TableRows
    {
        get
        {
            if (Session["TableRows"] == null)
                Session["TableRows"] = new List<TableRow>();
            return (List<TableRow>)Session["TableRows"];
        }
    }


    protected void Button1_Click(object sender, System.EventArgs e)
    {

        TextBox txtE, txtM, txtB;

        TableRow trow;
        TableCell tcell;

        foreach (TableRow tr in TableRows)
            Table1.Controls.Add(tr);

        int count = TableRows.Count + 1;

        txtE = new TextBox();
        txtE.ID = "E" + count.ToString();
        txtE.Visible = true;
        //txtE.Text = "E " + count.ToString();
        txtE.BorderWidth = 0;
        txtE.TextMode = TextBoxMode.SingleLine;
        txtE.Height = 15;

        txtM = new TextBox();
        txtM.ID = "M" + count.ToString();
        txtM.Visible = true;
        txtM.Text = "M " + count.ToString();
        txtM.TextMode = TextBoxMode.SingleLine;
        txtM.Height = 15;

        txtB = new TextBox();
        txtB.ID = "B" + count.ToString();
        txtB.Visible = true;
        txtB.Text = "B " + count.ToString();
        txtB.TextMode = TextBoxMode.SingleLine;
        txtB.Height = 15;

        trow = new TableRow();
        trow.ID = "R" + count.ToString();
        trow.BorderWidth = 1;

        tcell = new TableCell();
        tcell.ID = "E" + count.ToString();
        tcell.Controls.Add(txtE);
        trow.Controls.Add(tcell);

        tcell = new TableCell();
        tcell.ID = "M" + count.ToString();
        tcell.Controls.Add(txtM);
        trow.Controls.Add(tcell);

        tcell = new TableCell();
        tcell.ID = "B" + count.ToString();
        tcell.Controls.Add(txtB);
        trow.Controls.Add(tcell);

        Table1.Controls.Add(trow);
        TableRows.Add(trow);
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        foreach (TableRow tr in TableRows)
        {
            Response.Write("test");
        }
    }
}

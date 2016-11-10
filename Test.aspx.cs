using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Test : System.Web.UI.Page
{
    List<string> masterList = new List<string>();
    int number = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void AddTextBox(object sender, EventArgs e)
    {
        int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("Ordered", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("Shipped", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("ItemNo", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("Prescription", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("UnitPrice", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateDropDown("ChemicalCategory", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateTextBox("ChemicalAmount", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateDropDown("ContainerType", index);

        index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + pnlTextBoxes.Controls.OfType<DropDownList>().ToList().Count + 1;
        this.CreateDropDown("WetDry", index);
    }

    private void CreateTextBox(string id, int index)
    {
        TextBox txt = new TextBox();
        txt.ID = id + index;


        pnlTextBoxes.Controls.Add(new LiteralControl(id + " "));
        pnlTextBoxes.Controls.Add(txt);
        if (id != "ChemicalAmount")
            pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
    }

    private void CreateDropDown(string id, int index)
    {
        if (id == "ChemicalCategory")
        {
            DropDownList ddl = new DropDownList();
            ddl.ID = id + index;
            ddl.Width = 173;
            ddl.Items.Add(new ListItem(""));
            ddl.Items.Add(new ListItem("HERBICIDE"));
            ddl.Items.Add(new ListItem("SURFACTANT"));
            ddl.Items.Add(new ListItem("BASAL OIL"));
            ddl.Items.Add(new ListItem("DYE"));
            //ddl.AutoPostBack = true;

            pnlTextBoxes.Controls.Add(new LiteralControl(id));
            pnlTextBoxes.Controls.Add(ddl);
            pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
        }

        else if (id == "ContainerType")
        {
            DropDownList ddl = new DropDownList();
            ddl.ID = id + index;
            ddl.Width = 50;
            ddl.Items.Add(new ListItem(""));
            ddl.Items.Add(new ListItem("lbs"));
            ddl.Items.Add(new ListItem("Oz"));
            ddl.Items.Add(new ListItem("Gal"));
            //ddl.AutoPostBack = true;

            pnlTextBoxes.Controls.Add(ddl);
            pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
        }

        else if (id == "WetDry")
        {
            DropDownList ddl = new DropDownList();
            ddl.ID = id + index;
            ddl.Width = 173;
            ddl.Items.Add(new ListItem(""));
            ddl.Items.Add(new ListItem("WET"));
            ddl.Items.Add(new ListItem("DRY"));
            //ddl.AutoPostBack = true;

            pnlTextBoxes.Controls.Add(new LiteralControl(id));
            pnlTextBoxes.Controls.Add(ddl);
            pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
        }
    }


    protected void Page_PreInit(object sender, EventArgs e)
    {
        number++;
        List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("Ordered") || key.Contains("Shipped") || key.Contains("ItemNo") || key.Contains("Prescription") || key.Contains("UnitPrice") || key.Contains("ChemicalCategory") || key.Contains("ChemicalAmount") || key.Contains("ContainerType") || key.Contains("WetDry")).ToList();
        int i = 1;
        foreach (string key in keys)
        {
            if (key.Contains("Ordered"))
            {
                this.CreateTextBox("Ordered", i);
            }
            else if (key.Contains("Shipped"))
            {
                this.CreateTextBox("Shipped", i);
            }
            else if (key.Contains("ItemNo"))
            {
                this.CreateTextBox("ItemNo", i);
            }
            else if (key.Contains("Prescription"))
            {
                this.CreateTextBox("Prescription", i);
            }
            else if (key.Contains("UnitPrice"))
            {
                this.CreateTextBox("UnitPrice", i);
            }
            else if (key.Contains("ChemicalCategory"))
            {
                this.CreateDropDown("ChemicalCategory", i);
            }
            else if (key.Contains("ChemicalAmount"))
            {
                this.CreateTextBox("ChemicalAmount", i);
            }
            else if (key.Contains("ContainerType"))
            {
                this.CreateDropDown("ContainerType", i);
            }
            else if (key.Contains("WetDry"))
            {
                this.CreateDropDown("WetDry", i);
                pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
            }
            i++;
        }
    }

    protected void Save(object sender, EventArgs e)
    {

            string conString = ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.tblInventorySFS(InvNo, Ordered, Shipped, ItemNo, Prescription, UnitPrice, ChemicalAmount) VALUES(@InvNo, @Ordered, @Shipped, @ItemNo, @Prescription, @UnitPrice, @ChemicalAmount)"))
                {
                foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
                {
                    cmd.Connection = con;
                    if (textBox.ID.Contains("Ordered"))
                        cmd.Parameters.AddWithValue("@Ordered", textBox.Text);
                    else if (textBox.ID.Contains("Shipped"))
                        cmd.Parameters.AddWithValue("@Shipped", textBox.Text);
                    else if (textBox.ID.Contains("ItemNo"))
                        cmd.Parameters.AddWithValue("@ItemNo", textBox.Text);
                    else if (textBox.ID.Contains("Prescription"))
                        cmd.Parameters.AddWithValue("@Prescription", textBox.Text);
                    else if (textBox.ID.Contains("UnitPrice"))
                        cmd.Parameters.AddWithValue("@UnitPrice", textBox.Text);
                    else if (textBox.ID.Contains("ChemicalAmount"))
                    {
                        cmd.Parameters.AddWithValue("@ChemicalAmount", textBox.Text);
                        cmd.Parameters.AddWithValue("@InvNo", "Test Invoice");
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
    }
}

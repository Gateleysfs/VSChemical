using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IDAutomation.NetAssembly;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

public partial class LabelCreator : System.Web.UI.Page
{
    FontEncoder Encode = new FontEncoder();

    protected void Page_Load(object sender, EventArgs e)
    {
        //when the page loads, printButton is set to false
        printButton.Visible = false;
    }

    //This exectues when Generate Barcodes button is pressed
    protected void Button1_Click(object sender, EventArgs e)
    {
        printButton.Visible = true;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsBarcodeHolderConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT BarcodeHolder FROM dbo.tblBarcodeHolderSFS", conn))
            {
                conn.Open();

                string temp;

                //lower bound: grabs the number from tblBarcodeHolderSFS
                int numMin = int.Parse(cmd.ExecuteScalar().ToString());
                //upper bound: adds numMin to the number located in the txtToEncode textbox
                int numMax = numMin + int.Parse(txtDataToEncode.Text);

                //loop to render all the barcodes
                for (int i = numMin; i < numMax; i++)
                {
                    temp = Encode.Code128("S" + i.ToString(), 0, false);
                    //dynamically generates a barcode with specific characteristics
                    TextBox Barcode = new TextBox();
                    Barcode.ID = "Barcode" + temp;
                    Barcode.Text = temp;
                    Barcode.Style["text-align"] = "center";
                    Barcode.Font.Name = "IDAutomationC128L";
                    Barcode.Font.Size = 11;
                    Barcode.ReadOnly = true;
                    form1.Controls.Add(Barcode);

                    //if i is divisible by 4 with no remainder then a new line is created
                    if (i % 4 == 0)
                        form1.Controls.Add(new LiteralControl("<br/>"));
                }

                //Updates the number in tblBarcodeHolderSFS
                SqlCommand cmd2 = new SqlCommand("UPDATE dbo.tblBarcodeHolderSFS SET BarcodeHolder='" + numMax + "' WHERE BarcodeHolder='" + numMin + "'", conn);
                cmd2.ExecuteNonQuery();

                //Sets these controls to not visible to the user
                Button1.Visible = false;
                Label1.Visible = false;
                txtDataToEncode.Visible = false;
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
    }

    protected void printButton_Click(object sender, EventArgs e)
    {
        printButton.Visible = false;
    }
}
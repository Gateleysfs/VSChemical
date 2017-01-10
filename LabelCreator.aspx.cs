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



    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsChemicalInventoryConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT AmountLeft FROM dbo.tblInventorySFS", con))
            {
                con.Open();
                string temp = cmd.ExecuteScalar().ToString();

            }
        }



                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sfsBarcodeHolderConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT BarcodeHolder FROM dbo.tblBarcodeHolderSFS"))
            {
                conn.Open();

                string numMin = cmd.ExecuteScalar().ToString();
    //            int numMax = numMin + int.Parse(txtDataToEncode.Text);
    //            for (int i = numMin; i < numMax; i++)
    //            {
    //                TextBox Barcode = new TextBox();
    //        Barcode.ID = "Barcode" + i.ToString();
    //        Barcode.Text = "S" + txtDataToEncode.Text;
    //        Barcode.Font.Name = "IDAutomationC128L";
    //        Barcode.Font.Size = 32;
    //}
            }
        }
    }
}
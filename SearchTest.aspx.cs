using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

public partial class SearchTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Ordered", typeof(String));
        dt.Columns.Add("Shipped", typeof(String));
        dt.Columns.Add("ItemNo", typeof(String));
        dt.Columns.Add("Prescription", typeof(String));
        dt.Columns.Add("UnitPrice", typeof(String));
        dt.Columns.Add("ChemicalAmount", typeof(String));
        dt.Columns.Add("ChemicalCategory", typeof(String));
        dt.Columns.Add("ContainerType", typeof(String));
        dt.Columns.Add("WetDry", typeof(String));

        DataRow dr = dt.NewRow();

        dr["Ordered"] = "ordered";
        dr["Shipped"] = "shipped";
        dt.Rows.Add(dr);

        dr = dt.NewRow();

        dr["Ordered"] = "ordered2";
        dt.Rows.Add(dr);

        foreach (DataRow row in dt.Rows)
        {
            Response.Write(row["Ordered"]);
            Response.Write(row["Shipped"]);
        }




        DebugTable(dt);
    }


    public void DebugTable(DataTable table)
    {
        Debug.WriteLine("--- DebugTable(" + table.TableName + ") ---");
        int zeilen = table.Rows.Count;
        int spalten = table.Columns.Count;

        // Header
        for (int i = 0; i < table.Columns.Count; i++)
        {
            string s = table.Columns[i].ToString();
            Debug.Write(String.Format("{0,-20} | ", s));
        }
        Debug.Write(Environment.NewLine);
        for (int i = 0; i < table.Columns.Count; i++)
        {
            Debug.Write("---------------------|-");
        }
        Debug.Write(Environment.NewLine);

        // Data
        for (int i = 0; i < zeilen; i++)
        {
            DataRow row = table.Rows[i];
            //Debug.WriteLine("{0} {1} ", row[0], row[1]);
            for (int j = 0; j < spalten; j++)
            {
                string s = row[j].ToString();
                if (s.Length > 20) s = s.Substring(0, 17) + "...";
                Debug.Write(String.Format("{0,-20} | ", s));
            }
            Debug.Write(Environment.NewLine);
        }
        for (int i = 0; i < table.Columns.Count; i++)
        {
            Debug.Write("---------------------|-");
        }
        Debug.Write(Environment.NewLine);
    }



}
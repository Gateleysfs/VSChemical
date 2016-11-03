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

    protected void Button1_Click(object sender, System.EventArgs e)
    {


        // Total number of rows.
        int rowCnt;

        // Current row count.
        int rowCtr;

        // Total number of cells per row (columns).
        int cellCtr;

        rowCnt = int.Parse(TextBox1.Text);
        string[] Ordered = new string[rowCnt];
        rowCnt = rowCnt * 9;

        //Below are two nested for loops to traverse through the rows and columns of a table
        for (rowCtr = 1; rowCtr <= rowCnt; rowCtr++)
        {
            TableRow tRow = new TableRow();
            Table1.Rows.Add(tRow);
            for (cellCtr = 1; cellCtr <= 3; cellCtr++)
            {
                //This creates the first column with all the labels
                TableCell tCell = new TableCell();
                if (cellCtr == 1 && rowCtr == 1)
                {
                    tCell.Text = "Number Ordered";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 1 && rowCtr == 2)
                {
                    tCell.Text = "Number Shipped";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 1 && rowCtr == 3)
                {
                    tCell.Text = "Item Number";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 1 && rowCtr == 4)
                {
                    tCell.Text = "Product";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 1 && rowCtr == 5)
                {
                    tCell.Text = "Unit Price";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 1 && rowCtr == 6)
                {
                    tCell.Text = "Chemical Category";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 1 && rowCtr == 7)
                {
                    tCell.Text = "Chemical Amount";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 1 && rowCtr == 8)
                {
                    tCell.Text = "Wet/Dry";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 1 && rowCtr == 9)
                {
                    tCell.Text = "";
                    tRow.Cells.Add(tCell);
                }

                //This creates the second column with all the text boxes
                if (cellCtr == 2 && rowCtr == 1)
                {
                    TextBox txt = new TextBox();
                    txt.ID = "textBox1";
                    form1.Controls.Add(txt);
                }
                else if (cellCtr == 2 && rowCtr == 2)
                {
                    tCell.Text = "Number Shipped";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 2 && rowCtr == 3)
                {
                    tCell.Text = "Item Number";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 2 && rowCtr == 4)
                {
                    tCell.Text = "Product";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 2 && rowCtr == 5)
                {
                    tCell.Text = "Unit Price";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 2 && rowCtr == 6)
                {
                    tCell.Text = "Chemical Category";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 2 && rowCtr == 7)
                {
                    tCell.Text = "Chemical Amount";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 2 && rowCtr == 8)
                {
                    tCell.Text = "Wet/Dry";
                    tRow.Cells.Add(tCell);
                }
                else if (cellCtr == 2 && rowCtr == 9)
                {
                    tCell.Text = "";
                    tRow.Cells.Add(tCell);
                }
            }
        }
    }
}
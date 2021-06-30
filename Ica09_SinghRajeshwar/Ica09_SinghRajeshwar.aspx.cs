using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Ica09_SinghRajeshwar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach(GridViewRow  row in GridView1.Rows)
        {
            foreach (TableCell cell in row.Cells)
            {
                cell.Attributes.CssStyle["text-align"] = "center";
            }
        }
    }


    protected void ButtonShow_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void ButtonEdit_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Sanity Check, ensure the data is there
        if (e == null || e.Row == null || e.Row.DataItem == null) return;

        DataRowView drv = e.Row.DataItem as DataRowView;

        if (Convert.ToDouble(drv["UnitsInStock"]) < 25)
            e.Row.BackColor = Color.LightSalmon;

        if (Convert.ToDouble(drv["UnitPrice"]) > 25)
            e.Row.Cells[2].BackColor = Color.Yellow;

        if (Convert.ToDouble(drv["UnitsInStock"]) < 20 && Convert.ToDouble(drv["UnitsOnOrder"]) < 5)
        {
            e.Row.BackColor = Color.Cyan;
            e.Row.Cells[3].BackColor = Color.YellowGreen;
        }
            
    }
}
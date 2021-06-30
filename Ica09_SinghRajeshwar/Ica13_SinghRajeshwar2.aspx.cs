using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ica13_SinghRajeshwar2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ButtonOrderDetails_Click(object sender, EventArgs e)
    {
        try
        {
            if(TextBoxOrderID.Text != "")
            {
                GridView1.DataBind();
                LabelStatus.Text = "Status : Loaded";
            }
            else
                LabelStatus.Text = "Please input OrderID";

        }
        catch(Exception exc)
        {
            LabelStatus.Text = exc.Message;
        }
    }

    protected void ButtonDeleteSelected_Click(object sender, EventArgs e)
    {
        try
        {
            int productID = (int)GridView1.SelectedDataKey.Values["ProductID"];
            int OrderID = (int)GridView1.SelectedDataKey.Values["OrderID"];
            LabelStatus.Text = NorthwindAccess.DeleteOrderDetails(OrderID, productID);
            GridView1.DataBind();
        }
        catch(Exception exc)
        {
            LabelStatus.Text = exc.Message;
        }
    }

    protected void ButtonInsertRecord_Click(object sender, EventArgs e)
    {
        try
        {
            int orderid = Convert.ToInt32(TextBoxEnterOrder.Text);
            int productid = Convert.ToInt32(DropDownList1.SelectedValue);
            short quantity = Convert.ToInt16(TextBoxEnterQuantity.Text);
            LabelStatus2.Text = NorthwindAccess.InsertOrderDetails(orderid, productid, quantity);
            GridView1.DataBind();
        }
        catch(Exception exc)
        {
            LabelStatus2.Text = exc.Message;
        }
    }
}
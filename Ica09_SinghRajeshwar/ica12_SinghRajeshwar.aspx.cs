using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ica12_SinghRajeshwar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            NorthwindAccess.FillCustomersDDL("", DropDownListCustomer);
        }
    }

    protected void ButtonFilter_Click(object sender, EventArgs e)
    {
        GridViewCategory.DataSource = null;
        GridViewCategory.DataBind();
        NorthwindAccess.FillCustomersDDL(TextBoxfilter.Text, DropDownListCustomer);
    }

    protected void DropDownListCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListCustomer.SelectedIndex == 0)
        {
            LabelNoRows.Text = "Pick a valid Customer";
            GridViewCategory.DataSource = NorthwindAccess.CustomerCategorySummary(DropDownListCustomer.SelectedValue);
            GridViewCategory.DataBind();
            return;
        }
        GridViewCategory.DataSource = NorthwindAccess.CustomerCategorySummary(DropDownListCustomer.SelectedValue);
        GridViewCategory.DataBind();
        if (GridViewCategory.Rows.Count < 1)
            LabelNoRows.Text = "No Data found";
        else
            LabelNoRows.Text = "";
    }

    protected void GridViewCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header)
        {
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        }
    }
}
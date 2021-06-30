using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class ica11_SinghRajeshwar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillDropList(TextBoxfilter.Text);
        }
    }

    public void FillDropList(string s)
    {
        
        DropDownListSupplier.DataSource = NorthwindAccess.GetSuppliersSDS(s);
        DropDownListSupplier.DataTextField = "CompanyName";
        DropDownListSupplier.DataValueField = "SupplierID";
        DropDownListSupplier.Items.Clear();
        DropDownListSupplier.DataBind();
        DropDownListSupplier.AppendDataBoundItems = true;
        DropDownListSupplier.Items.Insert(0, new ListItem("Now Pick a Company from ["+DropDownListSupplier.Items.Count+"]"));
        DropDownListSupplier.AutoPostBack = true;
    }

    protected void ButtonFilter_Click(object sender, EventArgs e)
    {
        FillDropList(TextBoxfilter.Text);
    }

    protected void DropDownListSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListSupplier.SelectedIndex == 0) return;

        var wholeList = NorthwindAccess.GetProducts(DropDownListSupplier.SelectedValue);

        if ((wholeList as List<List<string>>).Count < 1) return;
        TableHeaderRow Names = new TableHeaderRow();
        foreach ( var item in wholeList[0])
        {
            TableHeaderCell tcNames = new TableHeaderCell();
            tcNames.Text = item;
            tcNames.Font.Size = 35;
            tcNames.BackColor = Color.LightBlue;
            Names.Cells.Add(tcNames);
        }
        wholeList.RemoveAt(0);
        TableData.Rows.Add(Names);
        foreach(var item in  wholeList)
        {
            TableRow tb = new TableRow();
            foreach(var i in item)
            {
                TableCell tc = new TableCell();
                tc.Text = i;
                //tc.Font.Size = 15;
                tb.Cells.Add(tc);
            }
            TableData.Rows.Add(tb);
        }

        
    }
}
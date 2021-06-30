using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Practice2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillDroplist("");
            Practice2Class.FillCustomerDDl("", DropDownList2);
        }
    }

    private void FillDroplist(string filter)
    {
        DropDownListSupplier.DataSource = Practice2Class.GetSuppliersSDS(filter);
        DropDownListSupplier.DataTextField = "CompanyName";
        DropDownListSupplier.DataValueField = "SupplierID";
        DropDownListSupplier.Items.Clear();
        DropDownListSupplier.DataBind();
        DropDownListSupplier.AppendDataBoundItems = true;
        DropDownListSupplier.Items.Insert(0, new ListItem("Now Pick a Company from [" + DropDownListSupplier.Items.Count + "]"));
        DropDownListSupplier.AutoPostBack = true;
    }

    protected void ButtonFilter_Click(object sender, EventArgs e)
    {
        FillDroplist(TextBoxfilter.Text);
    }

    protected void DropDownListSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListSupplier.SelectedIndex == 0)
            return;

        List<List<string>> table = Practice2Class.GetProducts(DropDownListSupplier.SelectedValue);

        TableRow Names = new TableRow();
        foreach (var item in table[0])
        {
            TableCell tcNames = new TableCell();
            tcNames.Text = item;
            tcNames.Font.Size = 35;
            tcNames.BackColor = Color.LightBlue;
            Names.Cells.Add(tcNames);
        }
        table.RemoveAt(0);
        Table1.Rows.Add(Names);
        foreach (var item in table)
        {
            TableRow tb = new TableRow();
            foreach (var i in item)
            {
                TableCell tc = new TableCell();
                tc.Text = i;
                //tc.Font.Size = 15;
                tb.Cells.Add(tc);
            }
            Table1.Rows.Add(tb);
        }
    }

    protected void ButtonFilter2_Click(object sender, EventArgs e)
    {
        Practice2Class.FillCustomerDDl(TextBoxFilter2.Text, DropDownList2);
    }
}
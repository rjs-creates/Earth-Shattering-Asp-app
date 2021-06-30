using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ica10_SinghRajeshwar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            DropDownListCompanyName.AppendDataBoundItems = true;
            DropDownListCompanyName.Items.Add(new ListItem("Pick a Customer", ""));
        }
    }


    protected void DropDownListCompanyName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsView1.PageIndex = -1;
        ListView1.SelectedIndex = -1;
    }
}
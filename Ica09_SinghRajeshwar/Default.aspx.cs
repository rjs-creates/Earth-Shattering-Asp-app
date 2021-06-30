using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            DirectoryInfo dr = Directory.CreateDirectory(MapPath(""));
            List<FileInfo> myfiles = dr.GetFiles("*.aspx").ToList();
            foreach(FileInfo fi in myfiles)
            {
                if (fi.Name != "Default.aspx")
                {
                    LinkButton newLink = new LinkButton();
                    newLink.Text = fi.Name;
                    newLink.PostBackUrl = "~/"+fi.Name; /*"~/Ica09_SinghRajeshwar.aspx"*/

                    PlaceHolder1.Controls.Add(newLink);
                    PlaceHolder1.Controls.Add(new LiteralControl("<br>"));
                }               
            }
        }
    }
}
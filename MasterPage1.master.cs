using System;
using System.Web.UI;

public partial class MasterPage1 : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblCounter.Text = "Active users: " + Application["TotalUserCounter"].ToString();
    }
}
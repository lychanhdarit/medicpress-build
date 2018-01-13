using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_ListPostLastest : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            GetList();
    }
    private void GetList()
    {
        DiamondProcessCode _dm = new DiamondProcessCode();
        rpLastestPost.DataSource = _dm.GetTopPost(10,"", true);
        rpLastestPost.DataBind();
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_ViewMovies : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            viewVideo();

        }
    }
    DBClass _db = new DBClass();
    private void viewVideo()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["i"]))
        {

            int id = ToSQL.SQLToInt(Request.QueryString["i"]);
            DataRow r = _db.get_Info_Media(id);
            if (r != null)
            {
                lbTieude.Text = BaseView.GetStringFieldValue(r, "name");
                lbView.Text = " <iframe width='640' height='350' src='" + "https://www.youtube.com/embed/" + BaseView.GetStringFieldValue(r, "links").Replace("&", "?") + "' frameborder='0' allowfullscreen></iframe>";
            }

        }
    }
}
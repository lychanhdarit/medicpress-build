using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_bai_viet_previews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["adminUserName"];
        if (cookie == null)
        {
            Response.Redirect("~/admin-us/account/login.aspx");
        }
        if (!IsPostBack)
            ReadContent();
    }
    private void ReadContent()
    {
        string content = "";
        if (Session["pageContent"] != null)
        {
            content = (string)Session["pageContent"];
        }
        if (!String.IsNullOrEmpty(Request.QueryString["indexauto"]))
        {
            int id = ToSQL.SQLToInt(Request.QueryString["indexauto"]);
            DBClass _db = new DBClass();
            DataRow info = _db.Get_Info_News(id);
            if (info != null)
            {
                content = BaseView.GetStringFieldValue(info, "noidung");
            }
        }
        ltContent.Text = content;

    }
}
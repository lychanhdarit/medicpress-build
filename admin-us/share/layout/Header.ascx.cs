using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_share_layout_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["adminUserName"];
        if (cookie == null)
        {
            Response.Redirect("~/admin-us/account/login.aspx");
        }
        DataRow rUser = _db.get_Info_user_cms(ReadCookie("adminUserName"));
        //DataTable dt = null;
        if (BaseView.GetBooleanFieldValue(rUser, "isAdmin") != true)
        {
            //hpAdmin.Visible = false;
            //ltAdmin.Visible = false;
        }
        if (!IsPostBack)
        {
            string createDate = BaseView.GetStringFieldValue(rUser, "CreateDate");
            string name = BaseView.GetStringFieldValue(rUser, "hoten");
            string URLImages = BaseView.GetStringFieldValue(rUser, "URLImages") == "" ? "~/admin-us/upload/user/noimg.png" : "~/admin-us/upload/user/" + BaseView.GetStringFieldValue(rUser, "URLImages");
            lbTen.Text = lbTen2.Text  = name;
            ltCreateDate.Text = createDate.Trim() == "" ? DateTime.Now.ToString() : createDate;
            imgAcc.ImageUrl = imgAcc2.ImageUrl = URLImages;
        }
    }
    DBClass _db = new DBClass();
    private string ReadCookie(string name)
    {
        //Get the cookie name the user entered
        String strCookieName = name;
        HttpCookie cookie = Request.Cookies[strCookieName];
        if (cookie == null)
        {
            return "";
        }
        else
        {
            //Write the cookie value
            String strCookieValue = cookie.Value.ToString();
            return strCookieValue;
        }
    }
}
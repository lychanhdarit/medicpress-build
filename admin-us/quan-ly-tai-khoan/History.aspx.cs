using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_quan_ly_tai_khoan_History : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DBClass _db = new DBClass();
        DataRow rUser = _db.get_Info_user_cms(ReadCookie("adminUserName"));
        if (rUser != null)
        {
            if (BaseView.GetStringFieldValue(rUser, "isAdmin").ToLower() != "true")
            {
                Response.Redirect("~/admin-us/account/login.aspx");
            }
        }
        if (!IsPostBack)
        {
            GetHistory();
            if (!String.IsNullOrEmpty(Request.QueryString["user"]))
            {
                btnXEM.Visible = true;
                btnXEM.PostBackUrl = "~/admin-us/quan-ly-tai-khoan/info-acc.aspx?user=" + Request.QueryString["user"];

            }
        }
    }
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
    private void GetHistory()
    {
        DBClass _db = new DBClass();
        DataTable dt = new DataTable();
        dt = _db.sqlGetData("select * from Historys where 1=1 order by id desc");
        string Username = Request.QueryString["user"];
        if (!String.IsNullOrEmpty(Username))
        {
            dt = _db.sqlGetData("select * from Historys where Username = '" + Username + "' order by id desc");
        }
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();

    }
}
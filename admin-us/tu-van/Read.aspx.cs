using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_tu_van_Read : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getItem(ToSQL.SQLToInt(Request.QueryString["id"]));
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
    private bool isAdmin()
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
            //box_manager.Visible = false;
            return false;
        }
        return true;
    }
    private void getItem(int id)
    {
        string sqlQ = "Select * from TuVan where id=" + id;
        string username = ReadCookie("adminUserName");
        DataRow r = _db.sqlGetDataRow(sqlQ);
        if (r != null)
        {
            txtEmail.Text = BaseView.GetStringFieldValue(r, "email");
            txtDiaChi.Text = BaseView.GetStringFieldValue(r, "diachi");
            txtDienThoai.Text = BaseView.GetStringFieldValue(r, "dienthoai");
            txtSkype.Text = BaseView.GetStringFieldValue(r, "skype");
            txtNoiDung.Text = BaseView.GetStringFieldValue(r, "noidung");
            if (BaseView.GetIntFieldValue(r, "status") == 1)
            {
                _db.insert_update_delete_tuvan(id, "", "", "", "", "", "", txtNoiDung.Text, false, 2, username, "update-status");
            }
        }
    }

    protected void lbChot_Click(object sender, EventArgs e)
    {
        string username = ReadCookie("adminUserName");
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            int id = ToSQL.SQLToInt(Request.QueryString["id"]);
            _db.insert_update_delete_tuvan(id, "", "", "", "", "", "", txtNoiDung.Text, false,3, username, "update-status");
            Response.Redirect("~/admin-us/tu-van/");
        }
    }
    protected void lbKOChot_Click(object sender, EventArgs e)
    {
        string username = ReadCookie("adminUserName");
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            int id = ToSQL.SQLToInt(Request.QueryString["id"]);
            _db.insert_update_delete_tuvan(id, "", "", "", "", "", "", txtNoiDung.Text, false, 4, username, "update-status");
            Response.Redirect("~/admin-us/tu-van/");
        }
    }
}
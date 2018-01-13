using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_user_info_ChangePW : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataRow rUser = _db.get_Info_user_cms(ReadCookie("adminUserName")); 
            txtID.Text = BaseView.GetStringFieldValue(rUser, "username");
            txtTen.Text = BaseView.GetStringFieldValue(rUser, "hoten");
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
    DBClass _db = new DBClass();
    protected void btnThayDoi_Click(object sender, EventArgs e)
    {
        DataRow user = null;
        HttpCookie cookie = Request.Cookies["adminUserName"];
        if (cookie != null)
        {
            if (txtMKMoi.Text == txtMKMoi2.Text)
            {
                user = _db.get_Info_user_cms(ReadCookie("adminUserName"));
                if (CheckUser(BaseView.GetStringFieldValue(user, "username"), txtMKCu.Text) == 1)
                {
                    string username = BaseView.GetStringFieldValue(user, "username");
                    _db.insert_update_delete_cms_user(username, BaseView.md5(BaseView.GetStringFieldValue(user, "username") + txtMKMoi2.Text.Trim()), "", "", "", true, true, "", username, username, "127.0.0.1", "changepass");
                    Response.Redirect("~/admin-us/account/login.aspx");
                }
                else
                {
                    lbE.Text =" <span style='color:red;padding:10px;border:1px solid #f00; border-radius:10px;'> Mật khẩu cũ không đúng!</span>" ;
                }
            }
            else
            {
                lbE.Text = " <span style='color:red;padding:10px;border:1px solid #f00; border-radius:10px;'> Nhập lại mật khẩu mới! </span>";
            }
        }
        else
        {
            lbE.Text = " <span style='color:red;padding:10px;border:1px solid #f00; border-radius:10px;'> Không thành công!</span>";
        }
    }
    public int CheckUser(string user, string pass)
    {
        string ip = "";
        DataRow row = _db.Admin_Login(user, BaseView.md5(user + pass), ip);
        if (row != null)
        {
            return 1;
        }
        else
            return 0;
    }
}
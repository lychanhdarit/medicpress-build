using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_quan_ly_tai_khoan_info_acc : System.Web.UI.Page
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

            string UserName = Request.QueryString["user"];
            if (!String.IsNullOrEmpty(UserName))
            {
                getInfoUser(UserName);
                btnCapNhat.PostBackUrl = "~/admin-us/quan-ly-tai-khoan/details.aspx?user=" + Request.QueryString["user"];
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
      
    bool getQuyen()
    {
        if (ddlUser.SelectedValue == "1")
        {
            //pnPhanQuyen.Visible = false;
            return true;
        }
        else
        {
            //pnPhanQuyen.Visible = true;
            return false;
        }
        // return false;
    }
    private void getInfoUser(string username)
    {
        DBClass _db = new DBClass();
        DataRow r = _db.get_Info_user_cms(username);
        if (r != null)
        {
            txtUserName.Text = BaseView.GetStringFieldValue(r, "username");
            txtHoTen.Text = BaseView.GetStringFieldValue(r, "hoten");
            txtDienThoai.Text = BaseView.GetStringFieldValue(r, "sodt");
            txtEmail.Text = BaseView.GetStringFieldValue(r, "email");
            string URLImages = BaseView.GetStringFieldValue(r, "URLImages") == "" ? "~/admin-us/upload/user/noimg.png" : "~/admin-us/upload/user/" + BaseView.GetStringFieldValue(r, "URLImages");
            imgBS.ImageUrl = URLImages;
            bool user = BaseView.GetBooleanFieldValue(r, "isAdmin");
            if (user == true)
            {
                ddlUser.SelectedValue = "1";
                getQuyen();
            }
            else
            {
                ddlUser.SelectedValue = "0";
                getQuyen();
            }

        }
        
        
    }
}
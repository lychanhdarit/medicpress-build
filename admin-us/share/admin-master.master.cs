﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_share_admin_master : System.Web.UI.MasterPage
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
            //lbTen.Text = BaseView.GetStringFieldValue(rUser, "hoten");
            ltNameLeft.Text = BaseView.GetStringFieldValue(rUser, "hoten");
            imgUser.ImageUrl = BaseView.GetStringFieldValue(rUser, "URLImages") == "" ? "~/admin-us/upload/user/noimg.png" : "~/admin-us/upload/user/" + BaseView.GetStringFieldValue(rUser, "URLImages");
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_quan_ly_tai_khoan_Default : System.Web.UI.Page
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
            getAllUser();
        }
    }
    private void getAllUser()
    {
        DBClass _db = new DBClass();
        DataTable dt = _db.get_all_admin();
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        string ip ="";
        DBClass _db = new DBClass();
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chkChon");
            if (chk.Checked == true)
            {
                _db.insert_update_delete_khuvuc_user(chk.CssClass,"", 0, "del");
                _db.insert_update_delete_cms_user(chk.CssClass, "", "", "", "",true,true,"","","",ip, "del");
            }
        }
        getAllUser();
    }
    protected void grDataTinh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvTaskNew, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Nhấn vào đây để chọn ";
        }
    }
    protected void grDataTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvTaskNew.Rows)
        {
            if (row.RowIndex == grvTaskNew.SelectedIndex)
            {
                row.BackColor = ColorTranslator.FromHtml("#fcc075");
                row.ToolTip = string.Empty;
                string id = grvTaskNew.SelectedValue.ToString();
                //getItem(id);
                //getDataKhuVuc(id);
                //lbE.Text = "";
            }
            else
            {
                row.BackColor = ColorTranslator.FromHtml("#EFFCDB");
                row.ToolTip = "Nhấn vào đây để chọn";
            }
        }
    }


    protected void grvTaskNew_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lock" || e.CommandName == "unlock" || e.CommandName == "changepass")
        {
            string Ip = "";
            DBClass _db = new DBClass();
            DataRow rUser = _db.get_Info_user_cms(ReadCookie("adminUserName"));
            string UserLogin = BaseView.GetStringFieldValue(rUser, "username");
            string username = e.CommandArgument.ToString();
            _db.insert_update_delete_cms_user(username, BaseView.md5(username + "123"), "", "", "", true, true, "", UserLogin, UserLogin, Ip, e.CommandName);
            getAllUser();
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
}
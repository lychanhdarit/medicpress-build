using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_tu_van_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            getData(0);
    }

    private void getData(int index)
    {
        int status = 0;
        string username = ReadCookie("adminUserName");
        string sqlQ = "Select * from TuVan where isDelete = 0 or isDelete is null  order by id desc";

        if (!String.IsNullOrEmpty(Request.QueryString["idStatus"]))
        {
            status = ToSQL.SQLToInt(Request.QueryString["idStatus"]);
            sqlQ = "Select * from TuVan where (isDelete = 0 or isDelete is null) and Status =" + status + "   order by id desc";
        }
        if (!String.IsNullOrEmpty(Request.QueryString["idcmt"]) && Request.QueryString["idcmt"] == "trash")
        {
            sqlQ = "Select * from TuVan where isDelete = 1 order by id desc";
        }
        DataTable dt = _db.sqlGetData(sqlQ);
        grvTaskNew.PageIndex = index;
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
    }
    protected void grDataTinh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label ltStatus = (Label)e.Row.FindControl("ltStatus");
            if (ltStatus.Text == "1")
                ltStatus.Text = "<span class='label label-warning'>Đang chờ ...</span>";
            if (ltStatus.Text == "2")
                ltStatus.Text = "<span class='label label-info'>Đang xử lý ... </span>";
            if (ltStatus.Text == "3")
                ltStatus.Text = "<span class='label label-success'>Khách đồng ý</span>";
            if (ltStatus.Text == "4")
                ltStatus.Text = "<span class='label label-danger'>Khách hủy</span>";

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
                int id = ToSQL.SQLToInt(grvTaskNew.SelectedValue.ToString());
                Response.Redirect("~/admin-us/tu-van/read.aspx?id=" + id);
            }
            else
            {
                row.BackColor = ColorTranslator.FromHtml("#EFFCDB");
                row.ToolTip = "Nhấn vào đây để chọn";
            }
        }
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        ////try
        ////{
        //int id = 0;
        //string command = "insert";
        //if (txtID.Text != "")
        //{
        //    id = ToSQL.SQLToInt(txtID.Text);
        //    command = "update";
        //}
        ////_db.insert_update_delete_FooterLinks(id, txtName.Text, txtUrl.Text, chkActive.Checked, command);

        //lbE.Text = "Đã cập nhật";
        //getData();
        ////}
        ////catch { }
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        //txtID.Text = "";
        //lbE.Text = "";
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
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        string username = ReadCookie("adminUserName");
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
            HyperLink lbNOIDUNG = (HyperLink)grvTaskNew.Rows[i].FindControl("lbNOIDUNG");

            if (chk.Checked == true)
            {
                _db.insert_update_delete_tuvan(ToSQL.SQLToInt(chk.CssClass), "", "", "", "", "", "", lbNOIDUNG.Text, false, 1, username, "del");
            }
        }
        getData(0);
    }
    protected void grvTaskNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int index = e.NewPageIndex;
        getData(index);
    }


}
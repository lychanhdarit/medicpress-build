using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_pages_danh_muc_Default : System.Web.UI.Page
{
    private DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (isAdmin() != true)
            {
                box_manager.Visible = false;
            }
            getDataDM();
            getData(0, 0);
            getDanhMuc();
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                DBClass _db = new DBClass();
                DataTable dt = _db.sqlGetData("select * from LoaiTin where isPatient = " + Request.QueryString["id"]);
                grvTaskNew.DataSource = dt;
                grvTaskNew.DataBind();
            }
        }
    }
    private DataTable getLoai(int maloai)
    {
       string sql = "select * from LoaiTin";
       if (maloai > 0)
       {
           sql = "select * from LoaiTin l1 where l1.name like  N'%" + txtSearch.Text + "%' and l1.isPatient = " + maloai + " or l1.isPatient in (select l2.id from LoaiTin l2 where l2.isPatient = " + maloai + ")";
       }
       return _db.sqlGetData(sql);
    }
    private void getData(int index, int maloai)
    {
        grvTaskNew.PageIndex = index;
        bool? actived = null;
        if (isAdmin() != true)
            actived = true;
        //grvTaskNew.DataSource = _db.get_data_LoaiTin("", idDanhMuc, actived);
        grvTaskNew.DataSource = getLoai(maloai);
        grvTaskNew.DataBind();
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
            box_manager.Visible = false;
            return false;
        }
        return true;
    }
    private void getDanhMuc()
    {
        ddlDanhMuc.DataSource = _db.Get_All_LoaiTin();
        ddlDanhMuc.DataBind();
        ddlDanhMuc.Items.Insert(0, new ListItem("----- chọn Danh mục -------", "0"));
    }
    protected void grvTaskNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        getData(e.NewPageIndex, ToSQL.SQLToInt(ddlDanhMuc.SelectedValue));
    }
    protected void ddlDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
    {
        getData(0, ToSQL.SQLToInt(ddlDanhMuc.SelectedValue));
    }
    protected void grvTaskNew_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label lb = (Label)e.Row.FindControl("lbDanhMuc");

            //int id = ToSQL.SQLToInt(lb.CssClass.Trim());
            //DataRow row = _db.get_Info_DanhMucTin(id);
            //if (row != null)
            //{
            //    lb.Text = BaseView.GetStringFieldValue(row, "tenDanhMuc");
            //}
            Label lbisPatient = (Label)e.Row.FindControl("lbisPatient");

            int idlbisPatient = ToSQL.SQLToInt(lbisPatient.CssClass.Trim());
            DataRow rowlbisPatient = _db.get_info_loai(idlbisPatient);
            if (rowlbisPatient != null)
            {
                lbisPatient.Text = BaseView.GetStringFieldValue(rowlbisPatient, "name");
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
    protected void btnAn_Click(object sender, EventArgs e)
    {
        string username = ReadCookie("adminUserName");
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
            Label lbTD = (Label)grvTaskNew.Rows[i].FindControl("lbTD");

            if (chk.Checked == true)
            {
                //_db.OnInsert_Update_Delete_News(ToSQL.SQLToInt(chk.CssClass), "", "", "", "", "", DateTime.Now, "", "", true, "", 1, "", "", "", 0, 0, "", null, "", "del");
                _db.OnInsert_Update_Delete_LoaiTin(ToSQL.SQLToInt(chk.CssClass), lbTD.Text, "", "", "", "", "", "", "", "", ToSQL.SQLToInt(ddlDanhMuc.SelectedValue), true, 0, 0, true, username, "del-actived");
            }
        }
        getData(0, 0);
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        string username = ReadCookie("adminUserName");
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
            Label lbTD = (Label)grvTaskNew.Rows[i].FindControl("lbTD");
            if (chk.Checked == true)
            {
                //_db.OnInsert_Update_Delete_News(ToSQL.SQLToInt(chk.CssClass), "", "", "", "", "", DateTime.Now, "", "", true, "", 1, "", "", "", 0, 0, "", null, "", "del");
                _db.OnInsert_Update_Delete_LoaiTin(ToSQL.SQLToInt(chk.CssClass), lbTD.Text, "", "", "", "", "", "", "", "", ToSQL.SQLToInt(ddlDanhMuc.SelectedValue), true, 0, 0, true, username, "del");
            }
        }
        getData(0, 0);
    }
    protected void btnChuaDuyet_Click(object sender, EventArgs e)
    {
        grvTaskNew.DataSource = _db.get_data_LoaiTin("", ToSQL.SQLToInt(ddlDanhMuc.SelectedValue), false);
        grvTaskNew.DataBind();
    }
    protected void btnDuyet_Click(object sender, EventArgs e)
    {
        string username = ReadCookie("adminUserName");
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
            Label lbTD = (Label)grvTaskNew.Rows[i].FindControl("lbTD");
            if (chk.Checked == true)
            {
                //_db.OnInsert_Update_Delete_News(ToSQL.SQLToInt(chk.CssClass), "", "", "", "", "", DateTime.Now, "", "", true, "", 1, "", "", "", 0, 0, "", null, "", "del");
                _db.OnInsert_Update_Delete_LoaiTin(ToSQL.SQLToInt(chk.CssClass), lbTD.Text, "", "", "", "", "", "", "", "", ToSQL.SQLToInt(ddlDanhMuc.SelectedValue), true, 0, 0, true, username, "actived");
            }
        }
        getData(0, 0);
    }
    private void getDataDM()
    {
        ddlLevel1.DataSource = _db.sqlGetData("select * from LoaiTin where isPatient = 0");
        ddlLevel1.DataBind();
        ddlLevel1.Items.Insert(0, new ListItem("----- chọn Danh mục -------", "0"));
    }
    protected void ddlLevel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = _db.Get_All_LoaiTin();
        if (ToSQL.SQLToInt(ddlLevel1.SelectedValue) > 0)
            dt = _db.sqlGetData("select * from LoaiTin where isPatient = " + ddlLevel1.SelectedValue);
        ddlDanhMuc.DataSource = dt;
        ddlDanhMuc.DataBind();
        ddlDanhMuc.Items.Insert(0, new ListItem("----- chọn Danh mục -------", "0"));
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
       // getData(0, ToSQL.SQLToInt(ddlLevel1.SelectedValue));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DBClass _db = new DBClass();
        DataTable dt = _db.sqlGetData("select * from LoaiTin where name like  N'%" + txtSearch.Text+ "%'");
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
    }
    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }
    protected void grvTaskNew_Sorting(object sender, GridViewSortEventArgs e)
    {
        int id = 0;
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            id = ToSQL.SQLToInt(Request.QueryString["id"]);
        }
        DataTable dt = getLoai(id);

        if (dt != null)
        {
            grvTaskNew.AllowPaging = false;
            DataView dataView = new DataView(dt);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
            
            grvTaskNew.DataSource = dataView;
            grvTaskNew.DataBind();
        }
    }
    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;

            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }

        return GridViewSortDirection;
    }
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        if (chk.Checked == true)
        {
            for (int i = 0; i < grvTaskNew.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
                chkItem.Checked = true;
            }
        }
        if (chk.Checked == false)
        {
            for (int i = 0; i < grvTaskNew.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
                chkItem.Checked = false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_comments_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getDropdownList(0);
            getDataForUser(0);

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
        return true;
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
    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }
    protected void grvTaskNew_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = getDataTable(false);

        if (dt != null)
        {
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

    private void getDropdownList(int maDanhMuc)
    {
        DataTable dtLoai = _db.Get_All_LoaiTin();
        if (maDanhMuc > 0)
        {
            dtLoai = _db.get_all_LoaiTin_idDanhMuc(maDanhMuc);
        }
        ddlLoai.DataSource = dtLoai;
        ddlLoai.DataBind();
        ddlLoai.Items.Insert(0, new ListItem("---( chọn loại tin )---", "0"));
    }

    private DataTable getDataTable(bool? isactived)
    {
        return _db.get_all_comments(isactived);
    }
    private void getData(int index, bool? isactived)
    {
        grvTaskNew.PageIndex = index;
        grvTaskNew.DataSource = getDataTable(isactived);
        grvTaskNew.DataBind();
    }
    private void getDataForUser(int index)
    {
        if (isAdmin() == true)
            getData(index, null);
        else
            getData(index, true);
    }
    protected void grvTaskNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        getDataForUser(e.NewPageIndex);
    }
    protected void ddlLoai_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDataForUser(0);
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        string username = ReadCookie("adminUserName");
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
            HyperLink lbTieuDe = (HyperLink)grvTaskNew.Rows[i].FindControl("lbTieuDe");
            if (chk.Checked == true)
            {
                _db.insert_update_comments(ToSQL.SQLToInt(chk.CssClass), "", "", "", 0, 0, null, "del");
            }
        }
        getDataForUser(0);
        checkALL.Checked = false;
    }
    protected void grvTaskNew_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink lbPost = (HyperLink)e.Row.FindControl("lbPost");

            DataRow row = _db.Get_Info_News(ToSQL.SQLToInt(lbPost.Text));
            if (row != null)
            {
                lbPost.Text = BaseView.GetStringFieldValue(row, "tieude");

            }

        }
    }
    protected void btnDuyet_Click(object sender, EventArgs e)
    {
        string username = ReadCookie("adminUserName");
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
            HyperLink lbTieuDe = (HyperLink)grvTaskNew.Rows[i].FindControl("lbTieuDe");
            if (chk.Checked == true)
            {
                _db.insert_update_comments(ToSQL.SQLToInt(chk.CssClass), "", "", "", 0, 0, true, "actived");
            }
        }
        getDataForUser(0);
        checkALL.Checked = false;
    }
    protected void btnChuaDuyet_Click(object sender, EventArgs e)
    {
        getData(0, false);
    }

    protected void btnTim_Click(object sender, EventArgs e)
    {
        getDataForUser(0);
    }

    protected void btnAn_Click(object sender, EventArgs e)
    {
        string username = ReadCookie("adminUserName");
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
            HyperLink lbTieuDe = (HyperLink)grvTaskNew.Rows[i].FindControl("lbTieuDe");
            if (chk.Checked == true)
            {
                _db.insert_update_comments(ToSQL.SQLToInt(chk.CssClass), "", "", "", 0, 0, false, "actived");
            }
        }
        getDataForUser(0);
        checkALL.Checked = false;
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        getData(0, null);
    }
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        if (checkALL.Checked == true)
        {
            for (int i = 0; i < grvTaskNew.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
                chkItem.Checked = true;
            }
        }
        if (checkALL.Checked == false)
        {
            for (int i = 0; i < grvTaskNew.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
                chkItem.Checked = false;
            }
        }
    }
}
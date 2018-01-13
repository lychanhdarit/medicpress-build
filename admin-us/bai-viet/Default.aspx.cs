using System;
using System.Collections.Generic;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_pages_danh_muc_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (isAdmin() != true)
            //{
            //    box_manager.Visible = false;
            //}
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
        //DataTable dt = null;
        if (BaseView.GetBooleanFieldValue(rUser, "isAdmin") != true)
        {
            box_manager.Visible = false;
            return false;
        }
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
        DataTable dt = getDataTable(null);

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
        return _db.get_data_news(txtSearch.Text, ToSQL.SQLToInt(ddlLoai.SelectedValue), isactived);
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
                _db.OnInsert_Update_Delete_News(ToSQL.SQLToInt(chk.CssClass), "", "", "", "", lbTieuDe.Text, DateTime.Now, "", "", true, "", 1, "", "", "", 0, 0, username, null, "", "", "del");
            }
        }
        getDataForUser(0);
    }
    protected void grvTaskNew_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Image img = (Image)e.Row.FindControl("Image1");
            string hinh = img.ToolTip;
            Label lbTin = (Label)e.Row.FindControl("lbLoai");
            if (hinh.IndexOf("http") == -1 && hinh.Trim() != "")
            {
                hinh = "~/uploadFile/postImages/" + hinh;
            }
            else if (hinh.Trim() == "")
            {
                hinh = "~/uploadFile/postImages/noImg.png";
            }

            img.ImageUrl = hinh;
            DataRow row = _db.get_info_loai(ToSQL.SQLToInt(lbTin.Text));
            if (row != null)
                lbTin.Text = BaseView.GetStringFieldValue(row, "Name");

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
                _db.OnInsert_Update_Delete_News(ToSQL.SQLToInt(chk.CssClass), "", "", "", "", lbTieuDe.Text, DateTime.Now, "", "", true, "", 1, "", "", "", 0, 0, username, null, "", "", "actived");
            }
        }
        getDataForUser(0);
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
                _db.OnInsert_Update_Delete_News(ToSQL.SQLToInt(chk.CssClass), "", "", "", "", lbTieuDe.Text, DateTime.Now, "", "", false, "", 1, "", "", "", 0, 0, username, null, "", "", "del-actived");
            }
        }
        getDataForUser(0);
    }

    protected void grvTaskNew_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string username = ReadCookie("adminUserName");
        if (e.CommandName == "actived" || e.CommandName == "del-actived" || e.CommandName == "del" )
        {
            string id = e.CommandArgument.ToString();
            bool isActived = e.CommandName == "actived" ? true : false;
            _db.OnInsert_Update_Delete_News(ToSQL.SQLToInt(id), "", "", "", "", "", DateTime.Now, "", "", isActived, "", 1, "", "", "", 0, 0, "", null, "", "", e.CommandName);
            getDataForUser(0);
        }
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
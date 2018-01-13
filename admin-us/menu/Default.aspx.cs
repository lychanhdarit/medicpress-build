using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_menu_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    BaseView _bv = new BaseView();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadKieu();
            getDropdownListMuc1(0);
            getMenuDD();
            getData(0);
            getDataDropdownListMenuParent();
            getDanhMuc();
            //getDropdownListMuc1();
            lbService.Text = _bv.serverUrl() + "/";
            AddControl(false);
        }
    }

    private void getItem(int id)
    {
        DataRow r = _db.get_Info_Menu(id);
        if (r != null)
        {
            txtTen.Text = BaseView.GetStringFieldValue(r, "name");
            txtID.Text = BaseView.GetStringFieldValue(r, "id");
            txtURL.Text = BaseView.GetStringFieldValue(r, "url");
            txtIndex.Text = BaseView.GetStringFieldValue(r, "numberSort");
            ddlKieu.SelectedValue = BaseView.GetStringFieldValue(r, "styleShow");
            try
            {
                ddlparent.SelectedValue = BaseView.GetStringFieldValue(r, "isparent");
                
            }
            catch { }
            bool rd = BaseView.GetBooleanFieldValue(r, "isActived");
            if (rd == true)
            {
                rdkhonghienthi.Checked = false;
                rdhienthi.Checked = true;
            }
            if (rd == false)
            {
                rdhienthi.Checked = false;
                rdkhonghienthi.Checked = true;
            }
        }
    }

    private string SpitLink(string link)
    {
        string[] s = link.Split('/');
        return s[s.Length - 1];
    }

    private void getData(int index)
    {

        DataTable dt = _db.get_all_Menu();
        if (ToSQL.SQLToInt(ddlmenu.SelectedValue) > -1)
        {
            dt = _db.sqlGetData("select * from Menu where isParent = '" + ddlmenu.SelectedValue+"' order by numberSort");
        }
        grvTaskNew.PageIndex = index;
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
    }
    private void getDataDropdownListMenuParent()
    {
        DataTable dt = _db.sqlGetData("select * from Menu order by name desc");
        ddlparent.DataSource = dt;
        ddlparent.DataBind();
       
        ddlparent.Items.Insert(0,new ListItem("--- chọn 1 danh mục nếu có ---","0"));
    }
    private void getDropdownListMuc1(int idDanhMuc)
    {
        DataTable dt = _db.sqlGetData("select * from LoaiTin order by name desc");
        ddlMuc1.DataSource = dt;
        ddlMuc1.DataBind();
        ddlMuc1.Items.Insert(0, new ListItem("---( chọn loại tin )---", "0"));
    }
    private DataTable getLoai(int maloai)
    {
        string sql = "select * from LoaiTin";
        if (maloai > 0)
        {
            sql = "select * from LoaiTin l1 where l1.isPatient = " + maloai + " or l1.isPatient in (select l2.id from LoaiTin l2 where l2.isPatient = " + maloai + ")";
        }
        return _db.sqlGetData(sql);
    }
    private void getDropdownListMucCon(int maMuc1)
    {
        //string sql = "select * from loaiTin where isPatient = "+ maMuc1;
        ddlMucCon.DataSource = getLoai(maMuc1);
        ddlMucCon.DataBind();
        ddlMucCon.Items.Insert(0, new ListItem("---( chọn loại tin )---", "0"));
    }
    protected void ddlMuc1_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDropdownListMucCon(ToSQL.SQLToInt(ddlMuc1.SelectedValue));
    }
    protected void grDataTinh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 1; i < grvTaskNew.Columns.Count - 1; i++)
            {
                e.Row.Cells[i].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvTaskNew, "Select$" + e.Row.RowIndex);
                e.Row.Cells[i].ToolTip = "Nhấn vào đây để chọn ";
                
            }
            
            Label lbisParent = (Label)e.Row.FindControl("lbisParent");
            int iPa = ToSQL.SQLToInt(lbisParent.Text);
            lbisParent.Text = "-";
            if (iPa != 0)
            {
                DataRow dr = _db.get_Info_Menu(iPa);
                if (dr != null)
                {

                    lbisParent.Text = BaseView.GetStringFieldValue(dr, "name");
                }
            }
            Label lbstyleShow = (Label)e.Row.FindControl("lbstyleShow");
            if (lbstyleShow.Text == "0")
            {
                lbstyleShow.Text = "-";
            }
            else
            {
                lbstyleShow.Text = "Dạng 1 cột";
            }
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
                getItem(id);
                lbE.Text = "";
                AddControl(true);
            }
            else
            {
                //row.BackColor = ColorTranslator.FromHtml("#EFFCDB");
                row.ToolTip = "Nhấn vào đây để chọn";
            }
        }
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        try
        {
            int id = 0;
            string command = "insert";
            if (txtID.Text != "")
            {
                id = ToSQL.SQLToInt(txtID.Text);
                command = "update";
                _db.OnInsert_Update_Delete_Menu(id, txtTen.Text, txtURL.Text, rdhienthi.Checked, ToSQL.SQLToInt(ddlparent.SelectedValue), ToSQL.SQLToInt(txtIndex.Text), ToSQL.SQLToInt(ddlKieu.SelectedValue), command);
            }
            if (command == "insert")
            {
                string sql="select * from menu where url = '"+txtURL.Text+"'";
                DataTable dtUrl = _db.sqlGetData(sql);
                if (dtUrl.Rows.Count == 0)
                {
                    _db.OnInsert_Update_Delete_Menu(id, txtTen.Text, txtURL.Text, rdhienthi.Checked, ToSQL.SQLToInt(ddlparent.SelectedValue), ToSQL.SQLToInt(txtIndex.Text), ToSQL.SQLToInt(ddlKieu.SelectedValue), command);
                }
                else
                {
                    lbE.Text = "Trùng url, không lưu được!";
                    return;
                }
            }
            lbE.Text = "Đã cập nhật";
            getData(0);
            getDataDropdownListMenuParent();
            AddControl(false);
            txtID.Text = "";
        }
        catch { }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
       
        string sql = "select top 1 * from Menu where 1 = 1 order by numberSort desc";
        DataRow row = _db.sqlGetDataRow(sql);
        if (row != null)
        {
            txtIndex.Text = (BaseView.GetIntFieldValue(row, "numberSort") + 1).ToString();
        }
        AddControl(true);
        txtID.Text = "";
        lbE.Text = "";
       
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chkChon");
            if (chk.Checked == true)
            {
                _db.OnInsert_Update_Delete_Menu(ToSQL.SQLToInt(chk.CssClass), txtTen.Text, txtURL.Text, rdhienthi.Checked, ToSQL.SQLToInt(ddlparent.SelectedValue), 0,0, "del");
            }
        }
        getData(0);
    }

    protected void btnChon_Click(object sender, EventArgs e)
    {
        int id = ToSQL.SQLToInt(ddlMucCon.SelectedValue);
        if(id == 0)
            id = ToSQL.SQLToInt(ddlMuc1.SelectedValue);
        DataRow row = _db.get_info_loai(id);
        if(row != null)
        {
            txtTen.Text = BaseView.GetStringFieldValue(row, "name");
            txtURL.Text = BaseView.GetStringFieldValue(row, "code")+".html";
        }
        // id loai tin khong co chon danh muc
        if (id == 0)
            id = ToSQL.SQLToInt(ddlDanhMuc.SelectedValue);
        row = _db.get_Info_DanhMucTin(id);
        if (row != null)
        {
            txtTen.Text = BaseView.GetStringFieldValue(row, "tenDanhMuc");
            txtURL.Text = BaseView.repalce_UrlFriendly(BaseView.convertToUnSign2(BaseView.GetStringFieldValue(row, "tenDanhMuc"))) + "-" + BaseView.GetStringFieldValue(row, "madanhMuc") + ".hxml";
           
        }
        string sql = "select top 1 * from Menu where 1 = 1 order by numberSort desc";
        DataRow rowS = _db.sqlGetDataRow(sql);
        if (rowS != null)
        {
            txtIndex.Text = (BaseView.GetIntFieldValue(rowS, "numberSort")+1).ToString();
        }
        txtID.Text = "";
    }
    private void getDanhMuc()
    {
        ddlDanhMuc.DataSource = _db.get_all_DanhMuc();
        ddlDanhMuc.DataBind();
        ddlDanhMuc.Items.Insert(0, new ListItem("---( tất cả danh mục )---", "0"));
    }
    private void getMenuDD()
    {
        ddlmenu.DataSource = _db.get_all_Menu();
        ddlmenu.DataBind();
        ddlmenu.Items.Insert(0, new ListItem(">>> Xem các mục chính", "0"));
        ddlmenu.Items.Insert(0, new ListItem("---( tất cả danh mục )---", "-1"));
    }
    protected void ddlDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDropdownListMuc1(ToSQL.SQLToInt(ddlDanhMuc.SelectedValue));
    }
    protected void grvTaskNew_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Up")
        {
            string id_sortIdex_rowIndex = e.CommandArgument.ToString();
            
            string[] mang = id_sortIdex_rowIndex.Split('-');
            if (ToSQL.SQLToInt(mang[1]) - 1 > 0 || ToSQL.SQLToInt(mang[2]) > 0)
            {
                int currentIndex = ToSQL.SQLToInt(mang[1]);
                _db.updown_menu(ToSQL.SQLToInt(mang[0]), currentIndex-- );

                Label lbKey = (Label)grvTaskNew.Rows[ToSQL.SQLToInt(mang[2]) - 1].FindControl("lbKey");

                Label lbnumberSort = (Label)grvTaskNew.Rows[ToSQL.SQLToInt(mang[2]) - 1].FindControl("lbnumberSort");

                if (currentIndex - 1 == ToSQL.SQLToInt(lbnumberSort.Text))
                {

                    _db.updown_menu(ToSQL.SQLToInt(lbKey.Text), currentIndex);

                }
            }
            getData(0);
        }
        if (e.CommandName == "Down")
        {
            string id_sortIdex_rowIndex = e.CommandArgument.ToString();
           
            string[] mang = id_sortIdex_rowIndex.Split('-');
            if (ToSQL.SQLToInt(mang[2]) < grvTaskNew.Rows.Count - 1)
            {
                _db.updown_menu(ToSQL.SQLToInt(mang[0]), ToSQL.SQLToInt(mang[1]) + 1);
            }
            try
            {
                Label lbKey = (Label)grvTaskNew.Rows[ToSQL.SQLToInt(mang[2]) + 1].FindControl("lbKey");
                _db.updown_menu(ToSQL.SQLToInt(lbKey.Text), ToSQL.SQLToInt(mang[1]));
            }
            catch { }

            getData(0);
        }
    }
    protected void ddlmenu_SelectedIndexChanged(object sender, EventArgs e)
    {
        getData(0);
    }
    protected void grvTaskNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        getData(e.NewPageIndex);
    }
    protected void ddlparent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlparent.SelectedValue != "0")
        {
            ddlKieu.Visible = false;
        }
        else
            ddlKieu.Visible = true;
    }
    private void loadKieu()
    {
        ddlKieu.Items.Insert(0, new ListItem("--- Dạng 1 cột ---", "1"));
        ddlKieu.Items.Insert(0, new ListItem("---( mặc định )---", "0"));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DBClass _db = new DBClass();
        DataTable dt = _db.sqlGetData("select * from Menu where name like  N'%" + txtSearch.Text + "%'");
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        AddControl(false);
    }
    private void AddControl(bool q)
    {
        btnCapNhat.Visible = q;
        btnHuy.Visible = q;
        btnChon.Visible = q;

        btnThem.Visible = !q;

        txtTen.Enabled = q;
        txtURL.Enabled = q;
        ddlDanhMuc.Enabled = q;
        ddlKieu.Enabled = q;
        ddlMuc1.Enabled = q;
        ddlMucCon.Enabled = q;
        ddlparent.Enabled = q;
        txtIndex.Enabled = q;
    }
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        if (checkAll.Checked == true)
        {
            for (int i = 0; i < grvTaskNew.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)grvTaskNew.Rows[i].FindControl("chkChon");
                chkItem.Checked = true;
            }
        }
        if (checkAll.Checked == false)
        {
            for (int i = 0; i < grvTaskNew.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)grvTaskNew.Rows[i].FindControl("chkChon");
                chkItem.Checked = false;
            }
        }
    }
}
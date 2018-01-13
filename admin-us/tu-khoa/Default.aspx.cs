using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_tu_khoa_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData(0);
            AddControl(false);
        }
    }
    private void getItem(int id)
    {
        DataRow r = _db.get_info_words(id);
        if (r != null)
        {
            txtTuKhoa.Text = BaseView.GetStringFieldValue(r, "keywords");
            txtLink.Text = BaseView.GetStringFieldValue(r, "links");
            txtDesc.Text = BaseView.GetStringFieldValue(r, "desc");
            txtTitle.Text = BaseView.GetStringFieldValue(r, "title");
            txtID.Text = BaseView.GetStringFieldValue(r, "id");
        }
    }
    private void getData(int index)
    {
        DataTable dt = _db.get_all_words();
        grvTaskNew.PageIndex = index;
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
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
                int id = ToSQL.SQLToInt(grvTaskNew.SelectedValue.ToString());
                getItem(id);
                lbE.Text = "";
                AddControl(true);
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
        try
        {
            int id = 0;
            string command = "insert";
            if (txtID.Text != "")
            {
                id = ToSQL.SQLToInt(txtID.Text);
                command = "update";
            }
            _db.insert_update_delete_words(id, txtTuKhoa.Text, txtLink.Text, txtTitle.Text, txtDesc.Text, command);
            lbE.Text = "Đã cập nhật";
            getData(0);
            AddControl(false);
            txtID.Text = "";
        }
        catch { }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        AddControl(true);
        txtID.Text = "";
        txtTitle.Text = "";
        txtDesc.Text = "";
        txtLink.Text = "";
        lbE.Text = "";
    }
    private void AddControl(bool q)
    {
        btnCapNhat.Visible = q;
        btnHuy.Visible = q;

        btnThem.Visible = !q;

        txtTitle.Enabled = q;
        txtDesc.Enabled = q;
        txtLink.Enabled = q;
        txtTuKhoa.Enabled = q;

    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
            if (chk.Checked == true)
            {
                _db.insert_update_delete_words(ToSQL.SQLToInt(chk.CssClass), txtTuKhoa.Text, txtLink.Text, txtTitle.Text, txtDesc.Text, "del");
               
            }
        }
        getData(0);
        checkALL.Checked = false;
    }
    protected void grvTaskNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        getData(e.NewPageIndex);
    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        AddControl(false);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_clips_loai : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData();
            AddControl(false);
        }
    }

    private void getItem(int id)
    {
        DataRow r = _db.get_Info_Media_C(id);
        if (r != null)
        {
            txtTen.Text = BaseView.GetStringFieldValue(r, "name");
            txtID.Text = BaseView.GetStringFieldValue(r, "id");

        }
    }

    private void getData()
    {
        DataTable dt = _db.get_all_Media_C();
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
            _db.Oninsert_update_delete_loai_media(id, txtTen.Text, command);
            lbE.Text = "Đã cập nhật";
            getData();
            AddControl(false);
            txtID.Text = "";
        }
        catch { }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
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
                _db.Oninsert_update_delete_loai_media(ToSQL.SQLToInt(chk.CssClass), txtTen.Text, "del");
            }
        }
        getData();
    }
    private void AddControl(bool q)
    {
        btnCapNhat.Visible = q;
        btnHuy.Visible = q;


        btnThem.Visible = !q;
        txtTen.Enabled = q;
       
    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        AddControl(false);
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
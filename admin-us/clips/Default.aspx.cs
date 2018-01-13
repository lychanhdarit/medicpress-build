using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_clips_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData();
            getC();
            AddControl(false);
        }
    }
    private void getC()
    {
        ddlTheLoai.DataSource = _db.get_all_Media_C();
        ddlTheLoai.DataBind();
        ddlTheLoai.Items.Insert(0, new ListItem("Chọn thể loại", "0"));
    }
    private void getItem(int id)
    {
        DataRow r = _db.get_Info_Media(id);
        if (r != null)
        {
            txtTen.Text = BaseView.GetStringFieldValue(r, "name");
            txtID.Text = BaseView.GetStringFieldValue(r, "id");
            txtMota.Text = BaseView.GetStringFieldValue(r, "desc_");
            txtLinks.Text = BaseView.GetStringFieldValue(r, "links");
            try
            {
                ddlTheLoai.SelectedValue = BaseView.GetStringFieldValue(r, "id_c");
            }
            catch { }
            imgBS.ImageUrl = "~/uploadFile/" + BaseView.GetStringFieldValue(r, "images");
        }
    }
    private void UploadFile()
    {
        HttpPostedFile files = fHinh.PostedFile;
        if (fHinh.HasFile == false && files.ContentLength > 500000)
        {
            lbError.Text = "Ảnh không hợp lệ";
        }
        else
        {
            try
            {
                string path = Server.MapPath("~/uploadFile/" + fHinh.FileName);
                fHinh.SaveAs(path);
            }
            catch
            {
                lbError.Text = "Trùng tên hoặc chưa chọn hình";
            }
        }
    }
    private string SpitLink(string link)
    {
        string[] s = link.Split('/');
        return s[s.Length - 1];
    }
    private string getImage()
    {
        string hinhAnh = SpitLink(imgBS.ImageUrl);
        if (fHinh.FileName != "")
        {
            hinhAnh = fHinh.FileName;
            UploadFile();
        }
        else if (hinhAnh == "")
            hinhAnh = "video.png";
        return hinhAnh;
    }
    private void getData()
    {
        DataTable dt = _db.get_all_Media();
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
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
            Label lbID_Loai = (Label)e.Row.FindControl("lbID_Loai");
            DataRow dr = _db.get_Info_Media_C(ToSQL.SQLToInt(lbID_Loai.Text));
            if (dr != null)
            {
                lbID_Loai.Text = BaseView.GetStringFieldValue(dr, "name");
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
                AddControl(true);
                lbE.Text = "";
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
            _db.OnInsert_Update_Delete_Media(id, txtTen.Text, txtMota.Text, txtLinks.Text, getImage(), ToSQL.SQLToInt(ddlTheLoai.SelectedValue), command);
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
                _db.OnInsert_Update_Delete_Media(ToSQL.SQLToInt(chk.CssClass), "", "", "", "", 0, "del");
            }
        }
        AddControl(false);
        getData();
    }
    private void AddControl(bool q)
    {
        btnCapNhat.Visible = q;
        btnHuy.Visible = q;
      

        btnThem.Visible = !q;
        txtTen.Enabled = q;
        txtLinks.Enabled = q;
        txtMota.Enabled = q;
        ddlTheLoai.Enabled = q;
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
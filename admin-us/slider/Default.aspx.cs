using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_slider_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    BaseView _bv = new BaseView();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData(0);
            lbService.Text = _bv.serverUrl() + "/";
            clearControl();
        }
    }

    private void getItem(int id)
    {
        DataRow r = _db.get_info_slider(id);// Edit
        if (r != null)
        {
            txtTen.Text = BaseView.GetStringFieldValue(r, "name");
            txtID.Text = BaseView.GetStringFieldValue(r, "id");
            txtUrl.Text = BaseView.GetStringFieldValue(r, "url");
            string hinh = BaseView.GetStringFieldValue(r, "filename");
            if (hinh.Trim() != "")
            {
                hinh = "~/uploadFile/slider/" + hinh;
            }
            else if (hinh.Trim() == "")
            {
                hinh = "~/uploadFile/slider/noImg.png";
            }

            imgBS.ImageUrl = hinh;
            chkSudung.Checked = BaseView.GetBooleanFieldValue(r, "isActived");
        }
    }

    private string SpitLink(string link)
    {
        string[] s = link.Split('/');
        return s[s.Length - 1];
    }

    protected void grDataTinh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            for (int i = 1; i < grvData.Columns.Count - 1; i++)
            {
                e.Row.Cells[i].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvData, "Select$" + e.Row.RowIndex);
                e.Row.Cells[i].ToolTip = "Nhấn vào đây để chọn ";

            }
            Label lbHinhThuc = (Label)e.Row.FindControl("lbHinhThuc");

            System.Web.UI.WebControls.Image img = (System.Web.UI.WebControls.Image)e.Row.FindControl("Image1");
            string hinh = img.ToolTip;

            if (hinh.Trim() == "")
            {
                hinh = "~/uploadFile/slider/noimg.png";
            }
            else
            {
                hinh = "~/UploadFile/Slider/" + hinh;
              
            }
            img.ImageUrl = hinh;
        }
    }
    private void clearControl()
    {
        txtID.Text = "";
        lbE.Text = "";
        txtTen.Text = "";
        txtUrl.Text = "";
        btnCapNhat.Text = "Thêm";
    }
    protected void grDataTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvData.Rows)
        {
            if (row.RowIndex == grvData.SelectedIndex)
            {
                row.BackColor = ColorTranslator.FromHtml("#fcc075");
                row.ToolTip = string.Empty;
                int id = ToSQL.SQLToInt(grvData.SelectedValue.ToString());
                getItem(id);
                lbE.Text = "";
                btnCapNhat.Text = "Sửa";
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
            _db.insert_update_delete_slider(id, txtTen.Text, getImage(), txtUrl.Text, chkSudung.Checked, command);
            lbE.Text = "Đã cập nhật";
            getData(0);
        }
        catch { }
    }

    private void getData(int p)
    {
        grvData.DataSource = _db.get_all_slider(null);
        grvData.PageIndex = p;
        grvData.DataBind();
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        clearControl();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvData.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvData.Rows[i].FindControl("chkChon");
            if (chk.Checked == true)
            {
                _db.insert_update_delete_slider(ToSQL.SQLToInt(chk.CssClass), "", "", "", false, "del");
                clearControl();
            }
        }

        getData(0);
    }

    protected void grvTaskNew_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grvTaskNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        getData(e.NewPageIndex);
    }
    protected void ddlHinhThucTimKiem_SelectedIndexChanged(object sender, EventArgs e)
    {
        getData(0);
    }
    #region Process Images
    private void UploadFile()
    {
        HttpPostedFile files = fHinh.PostedFile;
        if (fHinh.HasFile == false && files.ContentLength > 500000)
        {
            //lbError.Text = "Ảnh không hợp lệ";
        }
        else
        {
            try
            {
                string path = Server.MapPath("~/uploadFile/slider/" + fHinh.FileName);
                fHinh.SaveAs(path);
            }
            catch
            {
                // lbError.Text = "Trùng tên hoặc chưa chọn hình";
            }
        }
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
            hinhAnh = "noImg.png";
        return hinhAnh;
    }
    #endregion
    protected void btnActived_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvData.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvData.Rows[i].FindControl("chkChon");
            if (chk.Checked == true)
            {
                _db.insert_update_delete_slider(ToSQL.SQLToInt(chk.CssClass), "", "", "", false, "actived");
                clearControl();
            }
        }

        getData(0);
    }
    protected void btnDeactived_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvData.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvData.Rows[i].FindControl("chkChon");
            if (chk.Checked == true)
            {
                _db.insert_update_delete_slider(ToSQL.SQLToInt(chk.CssClass), "", "", "", false, "deactived");
                clearControl();
            }
        }

        getData(0);
    }
}
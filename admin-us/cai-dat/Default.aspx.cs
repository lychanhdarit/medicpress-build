using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_cai_dat_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getCaiDat();
            getData();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            _db.insert_update_delete_url("url", txtHttp.Text.Trim(), "update");
            lbError.Text = "Đã cập nhật!";
        }
        catch
        {
            lbError.Text = "Lỗi cập nhật!";
        }
    }
    private void getData()
    {
        DataRow row = _db.get_info_url();
        if (row != null)
        {
            txtHttp.Text = BaseView.GetStringFieldValue(row, "links");
        }
    }

    private void getCaiDat()
    {
        DataRow dr = _db.get_info_caidat();
        if (dr != null)
        {
            txtLinksBaiViet.Text = BaseView.GetStringFieldValue(dr, "SoLink");
            txtNgayDang.Text = BaseView.GetStringFieldValue(dr, "SoNgay");
            txtSoBaiDang.Text = BaseView.GetStringFieldValue(dr, "SoTin");
            txtTieuDeTrang.Text = BaseView.GetStringFieldValue(dr, "tieudetrang");
            txtTieuDeTrangChu.Text = BaseView.GetStringFieldValue(dr, "tieudetrangchu");
            txtDescription.Text = BaseView.GetStringFieldValue(dr, "Description");
            txtKeywords.Text = BaseView.GetStringFieldValue(dr, "Keywords");
            txtVideo.Text = BaseView.GetStringFieldValue(dr, "tieudetrangchuvideo");//ID analytics
            txtRaoVat.Text = BaseView.GetStringFieldValue(dr, "tieudetrangchuraovat");//ID tawk.to
        }
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        try
        {
            _db.insert_update_caidat(1, ToSQL.SQLToInt(txtSoBaiDang.Text), ToSQL.SQLToInt(txtLinksBaiViet.Text), ToSQL.SQLToInt(txtNgayDang.Text), txtTieuDeTrang.Text, txtTieuDeTrangChu.Text, txtDescription.Text, txtKeywords.Text, txtVideo.Text, txtRaoVat.Text,"");
            getCaiDat();
            lbTB.Text = "Đã cập nhật";
        }
        catch { }
    }
}
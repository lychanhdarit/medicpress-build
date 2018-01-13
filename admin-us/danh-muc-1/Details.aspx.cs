using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_danh_muc_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int autoId = 0;
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                autoId = ToSQL.SQLToInt(Request.QueryString["id"]);
            }
            getItem(autoId);
        }
    }
    DBClass _db = new DBClass();
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        try
        {
            int autoId = 0;
            string sqlCommand = "insert";
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                sqlCommand = "update";
                autoId = ToSQL.SQLToInt(Request.QueryString["id"]);
            }
            _db.OnInsert_Update_Delete_DanhMuc(autoId, txtTen.Text, txtMota.Text, txtKeys.Text, txtNoiDung.Text, chkMenu.Checked, getImage(), 0, sqlCommand);
            Response.Redirect("~/admin-us/danh-muc/");
        }
        catch { }
    }
    private void getItem(int id)
    {
        DataRow r = _db.get_Info_DanhMucTin(id);
        if (r != null)
        {
            txtTen.Text = BaseView.GetStringFieldValue(r, "TenDanhMuc");
            txtID.Text = BaseView.GetStringFieldValue(r, "maDanhMuc");
            txtMota.Text = BaseView.GetStringFieldValue(r, "motaDanhMuc");
            txtKeys.Text = BaseView.GetStringFieldValue(r, "keywords");
            txtNoiDung.Text = BaseView.GetStringFieldValue(r, "noidung");
            chkMenu.Checked = BaseView.GetBooleanFieldValue(r, "isNews");
            imgDaiDien.ImageUrl = "~/uploadFile/DanhMuc/" + BaseView.GetStringFieldValue(r, "HinhAnh");
        }
    }
    private string SpitLink(string link)
    {
        string[] s = link.Split('/');
        return s[s.Length - 1];
    }
    private string getImage()
    {
        string hinhAnh = SpitLink(imgDaiDien.ImageUrl);
        if (fHinh.FileName != "")
        {
            hinhAnh = fHinh.FileName;
            UploadFile();
        }
        else if (hinhAnh == "")
            hinhAnh = "noImg.png";
        return hinhAnh;
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
                string path = Server.MapPath("~/uploadFile/DanhMuc/" + fHinh.FileName);
                fHinh.SaveAs(path);
            }
            catch
            {
                lbError.Text = "Trùng tên hoặc chưa chọn hình";
            }
        }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin-us/danh-muc/");
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_quan_ly_tai_khoan_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label1.Text = ReadCookie("adminUserName");
        if (!IsPostBack)
        {

            DataRow rUser = _db.get_Info_user_cms(ReadCookie("adminUserName"));
            if (rUser != null)
            {
                if (BaseView.GetStringFieldValue(rUser, "isAdmin").ToLower() != "true")
                {
                    Response.Redirect("~/admin-us/account/login.aspx");
                }
            }
            getTinh();
            getAllUser();
            ddlUser.Items.Insert(0, new ListItem("User", "0"));
            ddlUser.Items.Insert(0, new ListItem("Admin", "1"));
            getQuyen();

            string UserName = Request.QueryString["user"];
            if (!String.IsNullOrEmpty(UserName))
            {
                getInfoUser(UserName);

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

    bool getQuyen()
    {
        if (ddlUser.SelectedValue == "1")
        {
            //pnPhanQuyen.Visible = false;
            return true;
        }
        else
        {
            //pnPhanQuyen.Visible = true;
            return false;
        }
        // return false;
    }
    private void getInfoUser(string username)
    {
        DataRow r = _db.get_Info_user_cms(username);
        if (r != null)
        {
            txtUserName.Text = BaseView.GetStringFieldValue(r, "username");
            txtHoTen.Text = BaseView.GetStringFieldValue(r, "hoten");
            txtDienThoai.Text = BaseView.GetStringFieldValue(r, "sodt");
            txtEmail.Text = BaseView.GetStringFieldValue(r, "email");
            string URLImages = BaseView.GetStringFieldValue(r, "URLImages") == "" ? "~/admin-us/upload/user/noimg.png" : "~/admin-us/upload/user/" + BaseView.GetStringFieldValue(r, "URLImages");
            imgBS.ImageUrl = URLImages;
            bool user = BaseView.GetBooleanFieldValue(r, "isAdmin");
            if (user == true)
            {
                ddlUser.SelectedValue = "1";
                getQuyen();
            }
            else
            {
                ddlUser.SelectedValue = "0";
                getQuyen();
            }

        }
        r = _db.get_Info_KhuVuc(username);
        for (int i = 0; i < chkQuan.Items.Count - 1; i++)
        {

            chkQuan.Items[i].Selected = false;

        }
        if (r != null)
        {
            getQuan(0);
            string _khuVuc = BaseView.GetStringFieldValue(r, "KhuVuc");
            ddlTinh.SelectedValue = BaseView.GetStringFieldValue(r, "Tinh");
            getQuan(ToSQL.SQLToInt(ddlTinh.SelectedValue));
            string[] kvArr = _khuVuc.Split('-');
            if (kvArr.Length > 0)
            {
                for (int i = 0; i < chkQuan.Items.Count - 1; i++)
                {
                    for (int j = 0; j < kvArr.Length; j++)
                    {
                        if (chkQuan.Items[i].Value == kvArr[j])
                        {
                            chkQuan.Items[i].Selected = true;
                        }
                    }

                }
            }
        }
    }
    private void getAllUser()
    {
        DataTable dt = _db.get_all_admin();
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
                string id = grvTaskNew.SelectedValue.ToString();
                getInfoUser(id);
                getDataKhuVuc(id);
                lbE.Text = "";
            }
            else
            {
                row.BackColor = ColorTranslator.FromHtml("#EFFCDB");
                row.ToolTip = "Nhấn vào đây để chọn";
            }
        }
    }
    string getKhuVuc()
    {
        string idKhuVucArr = "";
        for (int i = 0; i < chkQuan.Items.Count; i++)
        {

            if (chkQuan.Items[i].Selected == true)
            {
                idKhuVucArr += chkQuan.Items[i].Value + "-";
            }
        }
        return idKhuVucArr;
    }
    private void getTinh()
    {
        ddlTinh.DataSource = _db.get_all_Tinh();
        ddlTinh.DataBind();
        ddlTinh.Items.Insert(0, new ListItem("---( chọn tỉnh )---", "0"));
    }
    private void getQuan(int tinh)
    {
        chkQuan.DataSource = _db.get_all_Quan(tinh);
        chkQuan.DataBind();

    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        //try
        //{

        DataRow r = _db.get_Info_user_cms(txtUserName.Text.Trim());
        string Ip = "";
        string UserName = Request.QueryString["user"];
        if (!String.IsNullOrEmpty(UserName))
        {
            DataRow rUser = _db.get_Info_user_cms(ReadCookie("adminUserName"));
            string UserLogin = BaseView.GetStringFieldValue(rUser, "username");

            string UrlImages = getImage();

            _db.insert_update_delete_cms_user(UserName, BaseView.md5(txtUserName.Text.Trim() + "123"), txtHoTen.Text, txtEmail.Text, txtDienThoai.Text, chkActived.Checked, getQuyen(), UrlImages, UserLogin, UserLogin, Ip, "update");

            //if (_db.get_Info_KhuVuc(txtUserName.Text.Trim()) == null)
            //{
            //    _db.insert_update_delete_khuvuc_user(txtUserName.Text.Trim(), getKhuVuc(), ToSQL.SQLToInt(ddlTinh.SelectedValue), "insert");
            //}
            //else
            //{
            //    _db.insert_update_delete_khuvuc_user(txtUserName.Text.Trim(), getKhuVuc(), ToSQL.SQLToInt(ddlTinh.SelectedValue), "update");
            //}
            Response.Redirect("~/admin-us/quan-ly-tai-khoan/");
        }
        else
        {
            lbE.Text = "User không tồn tại, không thể sửa...";
        }

        //}
        //catch
        //{
        //    lbE.Text = "Không thể cập nhật tài khoản này!";
        //}
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {

        try
        {
            DataRow r = _db.get_Info_user_login(txtUserName.Text.Trim());
            string Ip = "";
            if (r != null)
            {
                lbE.Text = "User đã tồn tại, không thể thêm...";
            }
            else
            {
                DataRow rUser = _db.get_Info_user_cms(ReadCookie("adminUserName"));
                string UserLogin = BaseView.GetStringFieldValue(rUser, "username");
                string UrlImages = getImage();
                _db.insert_update_delete_cms_user(txtUserName.Text.Trim(), BaseView.md5(txtUserName.Text.Trim() + "123"), txtHoTen.Text, txtEmail.Text, txtDienThoai.Text, chkActived.Checked, getQuyen(), UrlImages, UserLogin, UserLogin, Ip, "insert");
                if (getQuyen() == false)
                {

                    _db.insert_update_delete_khuvuc_user(txtUserName.Text.Trim(), getKhuVuc(), ToSQL.SQLToInt(ddlTinh.SelectedValue), "insert");
                }
                getAllUser();
            }
        }
        catch
        {
            lbE.Text = "Không thể thêm tài khoản này!";
        }
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chkChon");
            if (chk.Checked == true)
            {
                _db.insert_update_delete_khuvuc_user(chk.CssClass, getKhuVuc(), 0, "del");
                _db.insert_update_delete_cms_user(chk.CssClass, "", "", "", "", false, false, "", "", "", "", "del");
            }
        }
        getAllUser();
    }
    protected void btnLamMoi_Click(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtHoTen.Text = "";
        txtDienThoai.Text = "";
        txtEmail.Text = "";
    }
    protected void ddlTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        getQuan(ToSQL.SQLToInt(ddlTinh.SelectedValue));
    }
    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        getQuyen();
    }
    private void getDataKhuVuc(string username)
    {
        DataTable dt = _db.get_data_KhuVuc(username);
        grvQuyen.DataSource = dt;
        grvQuyen.DataBind();
    }
    
    

    private void UploadFile(string filename)
    {
        HttpPostedFile files = fHinh.PostedFile;
        if (fHinh.HasFile == false && files.ContentLength > 500000)
        {
            ltTB.Text = " <span style='color:red;padding:10px;border:1px solid #f00; border-radius:10px;'> Ảnh không hợp lệ! </span>";
        }
        else
        {
            try
            {
                string path = Server.MapPath("~/admin-us/upload/user/" + filename);
                fHinh.SaveAs(path);
            }
            catch
            {

                ltTB.Text = " <span style='color:red;padding:10px;border:1px solid #f00; border-radius:10px;'> Trùng tên hoặc chưa chọn hình! </span>";
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
        string fileName = SpitLink(imgBS.ImageUrl);
        if (fHinh.FileName != "")
        {
            DateTime date = DateTime.Now;
            fileName = date.Year + date.Month + date.Day + date.Hour + date.Minute + date.Second + date.Millisecond + fHinh.FileName;
            UploadFile(fileName);
        }
        else if (fileName == "")
            fileName = "noImg.png";
        return fileName;
    }
}
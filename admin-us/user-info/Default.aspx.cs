using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_user_info_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label1.Text = ReadCookie("adminUserName");
        if (!IsPostBack)
        {
            getInfoUser();
        }
    }
    private void getInfoUser()
    {
        DataRow rUser = _db.get_Info_user_cms(ReadCookie("adminUserName"));
        if (rUser != null)
        {
            string UserName = BaseView.GetStringFieldValue(rUser, "username");
            getInfoUser(UserName);
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
            String strCookieValue = cookie.Value.ToString();
            return strCookieValue;
        }
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
            imgBS.ImageUrl = "~/admin-us/upload/user/" + BaseView.GetStringFieldValue(r, "URLImages");
        }
       
    }
    
    
    
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        
        string Ip = "";
        DataRow rUser = _db.get_Info_user_cms(ReadCookie("adminUserName"));
        if (rUser != null)
        {
            string UserName = BaseView.GetStringFieldValue(rUser, "username");
           
            string UserLogin = BaseView.GetStringFieldValue(rUser, "username");
            string UrlImages = getImage();

            _db.insert_update_delete_cms_user(UserName, BaseView.md5(txtUserName.Text.Trim() + "123"), txtHoTen.Text, txtEmail.Text, txtDienThoai.Text, true,false, UrlImages, UserLogin, UserLogin, Ip, "user-update");

            getInfoUser();
            ltTB.Text = " <span style='color:red;padding:10px;border:1px solid #f00; border-radius:10px;'> Cập nhật thành công! </span>";
        }
        else
        {
            ltTB.Text = " <span style='color:red;padding:10px;border:1px solid #f00; border-radius:10px;background: rgba(243, 243, 243, 0.56);'> Có lỗi xảy ra, vui lòng kiểm tra rồi!</span>";
        }
    }
   
    protected void btnLamMoi_Click(object sender, EventArgs e)
    {

        getInfoUser();
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
            DateTime date =  DateTime.Now;
            fileName = date.Year + date.Month + date.Day + date.Hour + date.Minute + date.Second + date.Millisecond + fHinh.FileName;
            UploadFile(fileName);
        }
        else if (fileName == "")
            fileName = "noImg.png";
        return fileName;
    }
    
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class admin_us_danh_muc_Details : System.Web.UI.Page
{
    DBClass _db = new DBClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getLoai();
            getDropdownlist();
            getInfo();


        }
    }
    private void getLoai()
    {
        DataTable dt = _db.Get_All_LoaiTin();
        ddlLoai.DataSource = dt;
        ddlLoai.DataBind();
        ddlLoai.Items.Insert(0, new ListItem("----chọn loại -------------", "0"));
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
    private void getInfo()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
           
            int id = ToSQL.SQLToInt(Request.QueryString["id"].Replace("'", ""));
            DataRow row = _db.get_info_loai(id);
            if (row != null)
            {
                txtName.Text = BaseView.GetStringFieldValue(row, "name");
                txtUrl.Text = BaseView.GetStringFieldValue(row, "url");
                txtUrlCT.Text = BaseView.GetStringFieldValue(row, "urlct");
                txtTT.Text = BaseView.GetStringFieldValue(row, "title");
                txtMT.Text = BaseView.GetStringFieldValue(row, "description");
                txtNoiDung.Text = BaseView.GetStringFieldValue(row, "noidung");
                txtKeyWord.Text = BaseView.GetStringFieldValue(row, "keywords");
                txtCode.Text = BaseView.GetStringFieldValue(row, "code");
                imgBS.ImageUrl = "~/uploadFile/DanhMuc/" + BaseView.GetStringFieldValue(row, "Images");
                try
                {
                    ddlLoai.SelectedValue = BaseView.GetStringFieldValue(row, "isPatient");
                }
                catch { }
                try
                {
                    ddlDanhMuc.SelectedValue = BaseView.GetStringFieldValue(row, "madanhmuc");
                }
                catch { }
            }
        }
    }
    private void Insert_Update_Data()
    {
        //if (ToSQL.SQLToInt(ddlDanhMuc.SelectedValue) > 0)
        //{ 
            string username = ReadCookie("adminUserName");
            int id = 0;
            string sqlCommand = "insert";
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = ToSQL.SQLToInt(Request.QueryString["id"]);
                sqlCommand = "update";
            }

            string code = txtCode.Text.Trim().ToLower();
            if (code.Length == 0)
            {
                code = BaseView.convertToUnSign2(txtName.Text).ToLower();
                code = BaseView.repalce_UrlFriendly(code);
            }
            
            _db.OnInsert_Update_Delete_LoaiTin(id, txtName.Text, txtUrl.Text, getImageDD(), txtTT.Text, txtMT.Text, txtNoiDung.Text, txtKeyWord.Text, getImage(), code, ToSQL.SQLToInt(ddlDanhMuc.SelectedValue), true, ToSQL.SQLToInt(ddlLoai.SelectedValue),0,true,username, sqlCommand);
            BaseView _bv = new BaseView();
            if (sqlCommand != "update")
            {
                writeXML(_bv.serverUrl() + "/" + code + ".html", DateTime.Now.ToShortDateString());
            }
        //}
        //else
        //{
        //    Label1.Text = "Chưa chọn Danh Mục";
        //}
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
    private void UploadFileDD()
    {
        HttpPostedFile files = fHinhDD.PostedFile;
        if (fHinhDD.HasFile == false && files.ContentLength > 500000)
        {
            lbErrorDD.Text = "Ảnh không hợp lệ";
        }
        else
        {
            try
            {
                string path = Server.MapPath("~/uploadFile/DanhMuc/" + fHinhDD.FileName);
                fHinhDD.SaveAs(path);
            }
            catch
            {
                lbErrorDD.Text = "Trùng tên hoặc chưa chọn hình";
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
            hinhAnh = "noImg.png";
        return hinhAnh;
    }
    private string getImageDD()
    {
        string hinhAnh = SpitLink(ImgDaiDien.ImageUrl);
        if (fHinhDD.FileName != "")
        {
            hinhAnh = fHinhDD.FileName;
            UploadFileDD();
        }
        else if (hinhAnh == "")
            hinhAnh = "noImg.jpg";
        return hinhAnh;
    }

    private void writeXML(string link, string time)
    {
        //Doc du lieu cu
        DataTable dt = new DataTable();
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Sitemap.xml"));
            dt = ds.Tables["url"];
        }
        catch
        {

        }
        //---------------------------------------------------

        using (XmlTextWriter writer = new XmlTextWriter(Server.MapPath("~/Sitemap.xml"), Encoding.UTF8))
        {
            // Khoi tao
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns", "http://www.google.com/schemas/sitemap/0.84");
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "http://www.google.com/schemas/sitemap/0.84 http://www.google.com/schemas/sitemap/0.84/sitemap.xsd");

            // Ghi lai du lieu cu
            foreach (DataRow r in dt.Rows)
            {
                //tableSiteMap.Rows.Add(new object[] { r[0].ToString(), r[1].ToString(), r[2].ToString() });
                writer.WriteStartElement("url");
                writer.WriteElementString("loc", r[0].ToString() + "");
                writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
                writer.WriteElementString("changefreq", "daily");
                writer.WriteElementString("priority", "1.00");
                writer.WriteEndElement();
            }
            // Ghi du lieu moi
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", link + "");
            writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
            writer.WriteElementString("changefreq", "daily");
            writer.WriteElementString("priority", "1.00");
            writer.WriteEndElement();
            //------------------------------------------------------

            // Ghi vào file xml
            writer.WriteEndElement();
            writer.Flush();
        }
    }
    private void getDropdownlist()
    {
        ddlDanhMuc.DataSource = _db.get_all_DanhMuc();
        ddlDanhMuc.DataBind();
        ddlDanhMuc.Items.Insert(0, new ListItem("----chọn danh mục -------------", "0"));
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        Insert_Update_Data();
        Response.Redirect("~/admin-us/danh-muc/");
    }
}
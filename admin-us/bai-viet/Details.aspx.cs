using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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
            getLoaiTin();
            getListTag();
            getInfoNews();
        }
    }
    private void getListTag()
    {
        lstKeywords.DataSource = _db.get_all_words();
        lstKeywords.DataBind();
    }
    public static string convertToUnSign2(string s)
    {
        string stFormD = s.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();
        for (int ich = 0; ich < stFormD.Length; ich++)
        {
            System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
            if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                sb.Append(stFormD[ich]);
            }
        }
        sb = sb.Replace('Đ', 'D');
        sb = sb.Replace('đ', 'd');
        return (sb.ToString().Normalize(NormalizationForm.FormD));
    }

    private void getLoaiTin()
    {
        string sql = "SELECT * from LoaiTin order by name";
        DataTable dt = _db.sqlGetData(sql);
        ddlLoaiTin.DataSource = dt;
        ddlLoaiTin.DataTextField = "name";
        ddlLoaiTin.DataValueField = "id";
        ddlLoaiTin.DataBind();
        ddlLoaiTin.Items.Insert(0, new ListItem("--------chọn loại tin----------", "0"));
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
    private void getInfoNews()
    {

        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            int id = ToSQL.SQLToInt(Request.QueryString["id"]);
            DataRow row = _db.Get_Info_News(id);
            if (row != null)
            {
                ddlLoaiTin.SelectedValue = BaseView.GetStringFieldValue(row, "maloai");

                txtTitle.Text = BaseView.GetStringFieldValue(row, "title");
                txtDesc.Text = BaseView.GetStringFieldValue(row, "desc");
                //lbIDKey.Text = BaseView.GetStringFieldValue(row, "keywords");
                txtTieuDe.Text = BaseView.GetStringFieldValue(row, "tieude");
                txtTomTat.Text = BaseView.GetStringFieldValue(row, "tomtat");
                string noidung = BaseView.GetStringFieldValue(row, "noidung");
                txtContent.Text = noidung;
                txtUrl.Enabled = false;
                string hinhDD = BaseView.GetStringFieldValue(row, "HinhAnh");
                if (hinhDD.IndexOf("http") == -1)
                {
                    hinhDD = "~/uploadFile/postImages/" + hinhDD;
                }
                imgBS.ImageUrl = hinhDD;

                bool iSeo = false;
                if (BaseView.GetStringFieldValue(row, "tinh") == "1")
                    iSeo = true;
                chSEO.Checked = iSeo;

                txtUrl.Text = BaseView.GetStringFieldValue(row, "url").Replace(".html", "");

                string[] keywords = BaseView.GetStringFieldValue(row, "keywords").Split(',');

                string tags = "";
                for (int i = 0; i < keywords.Length - 1; i++)
                {
                    string[] ids = keywords[i].Split('-');
                    int idKey = ToSQL.SQLToInt(ids[ids.Length - 1]);
                    DataRow rowK = _db.get_info_words(idKey);
                    try
                    {
                        if (row != null)
                        {
                            tags = BaseView.GetStringFieldValue(rowK, "keywords");
                            chkList.Items.Add(new ListItem(tags, keywords[i]));
                        }
                    }
                    catch { }

                }

                //lbkeyWord.Text = tags;
            }
        }
    }
    private void selectDdl(DataRow row)
    {
        try
        {
            ddlLoaiTin.SelectedValue = BaseView.GetStringFieldValue(row, "maloai");
        }
        catch (Exception)
        {
            ddlLoaiTin.SelectedValue = "0";
        }
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        UpdatePost(true);
    }
    // isActived = true -> public ; isActived = false -> draff
    private void UpdatePost(bool isActived)
    {
        if (ToSQL.SQLToInt(ddlLoaiTin.SelectedValue) > 0)
        {
            string username = ReadCookie("adminUserName");
            string sqlCommand = "";
            int autoId = 0;

            string content = txtContent.Text;
            string url = txtUrl.Text;
            if (url == "")
            {
                url = linkReplace(txtTieuDe.Text);
            }
            url += ".html";// Add .html for url
            //DataRow dr = _db.get_info_news_url(url);
            //if (dr != null && sqlCommand == "insert")
            //{
                //Random ran = new Random();
                //url = linkReplace(txtTieuDe.Text) + ran.Next(1, 1000) + ".html";
            //}
            string _title = txtTitle.Text;
            if (_title == "")
            {
                _title = txtTieuDe.Text;
            }
            string _desc = txtDesc.Text;
            if (_desc == "")
            {
                _desc = txtTomTat.Text;
            }
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                sqlCommand = "update";
                autoId = ToSQL.SQLToInt(Request.QueryString["id"]);
                //url = txtUrl.Text;
            }
            BaseView _bv = new BaseView();
            if (autoId == 0)
            {
                sqlCommand = "insert";
                writeXML(_bv.serverUrl() + "/" + url, DateTime.Now.ToShortDateString());
            }
            int baiSeo = 0;
            if (chSEO.Checked)
                baiSeo = 1;
            _db.OnInsert_Update_Delete_News(autoId, "", _title, _desc, getTag(), BaseView.replaceLinkHtml(txtTieuDe.Text), DateTime.Now, txtTomTat.Text, content, isActived, getImage(), ToSQL.SQLToInt(ddlLoaiTin.SelectedValue), url, "", "", 1, baiSeo, username, null, "", "", sqlCommand);

            Response.Redirect("~/admin-us/bai-viet/");
        }
        else
        {
            ltError.Text = "<span style='padding:5px;border:1px solid #FF0000;border-radius:10px;'>Chọn danh mục</span>";
        }
    }
    private void writeXML(string link, string time)
    {
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
                string path = Server.MapPath("~/uploadFile/postImages/" + fHinh.FileName);
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
        string hinhAnh = "";
        if (imgBS.ImageUrl.IndexOf("http") == -1)
        {
            hinhAnh = SpitLink(imgBS.ImageUrl);
            if (fHinh.FileName != "")
            {
                hinhAnh = fHinh.FileName;
                UploadFile();
            }
            else if (hinhAnh == "")
                hinhAnh = "noImg.png";
        }
        else
        {
            hinhAnh = cleanPath(imgBS.ImageUrl);
            string[] h = hinhAnh.Split('/');
            using (WebClient wc = new WebClient())
                wc.DownloadFile(hinhAnh, Server.MapPath("~/uploadFile/postImages/" + h[h.Length - 1]));
            hinhAnh = h[h.Length - 1];
        }

        return hinhAnh;
    }
    private string cleanPath(string path)
    {
        string[] CP = path.Split('?');
        return CP[0];
    }

    private string linkReplace(string chuoi)
    {
        string s = convertToUnSign2(chuoi);
        s = BaseView.repalce_UrlFriendly(s);
        return (s.ToLower());
    }
    protected void lstKeywords_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkList.Items.Add(new ListItem(lstKeywords.SelectedItem.Text, lstKeywords.SelectedItem.Text + "-" + lstKeywords.SelectedValue));
    }
    string getTag()
    {
        string keys = "";
        for (int i = 0; i < chkList.Items.Count; i++)
        {
            keys += convertStringLinks(chkList.Items[i].Value) + ", ";
        }
        return keys;
    }
    private string convertStringLinks(string s)
    {
        s = BaseView.convertToUnSign2(s);
        s = BaseView.repalce_UrlFriendly(s);
        return (s.ToLower());
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        try
        {
            int id = 0;
            string command = "insert";
            string tag = txtTag.Text;

            string[] tags = txtTag.Text.Split(',');
            if (tags.Length > 0)
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    _db.insert_update_delete_words(id, tags[i].Trim(), "", "", "", command);
                }
            }
            getListTag();
        }
        catch { }
    }

    protected void btnXoaTag_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkList.Items.Count; i++)
        {
            if (chkList.Items[i].Selected)
            {
                chkList.Items.Remove(new ListItem(chkList.Items[i].Text, chkList.Items[i].Value));
            }
        }
    }
    protected void btnLuuNhap_Click(object sender, EventArgs e)
    {
        UpdatePost(false);
    }
    protected void btnXemTruoc_Click(object sender, EventArgs e)
    {
        if (ToSQL.SQLToInt(ddlLoaiTin.SelectedValue) > 0)
        {
            Session["pageContent"] = txtContent.Text;
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Redirect", "window.open('previews.aspx', '_blank');", true);
        }
        else
        {
            ltError.Text = "<span style='padding:5px;border:1px solid #FF0000;border-radius:10px;'>Thông tin không hợp lệ, vui lòng chọn một danh mục! P/S: thích làm khó.</span>";
        }
    }
}
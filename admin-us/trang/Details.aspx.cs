using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_danh_muc_Details : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getInfoPages();

            getListTag();
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
    private void getInfoPages()
    {

        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            int id = ToSQL.SQLToInt(Request.QueryString["id"]);
            DataRow row = _db.Get_Info_Pages(id);
            if (row != null)
            {

                txtTitle.Text = BaseView.GetStringFieldValue(row, "title");
                txtDesc.Text = BaseView.GetStringFieldValue(row, "desc");
                lbIDKey.Text = BaseView.GetStringFieldValue(row, "keywords");
                txtTieuDe.Text = BaseView.GetStringFieldValue(row, "tieude");
                txtTomTat.Text = BaseView.GetStringFieldValue(row, "tomtat");
                txtContent.Text = BaseView.GetStringFieldValue(row, "noidung");
                txtUrl.Text = BaseView.GetStringFieldValue(row, "url");
                txtCssClass.Text = BaseView.GetStringFieldValue(row, "code");
                imgBS.ImageUrl = "~/uploadFile/" + BaseView.GetStringFieldValue(row, "HinhAnh");
                chkHienThi.Checked = BaseView.GetBooleanFieldValue(row, "isHome");
                string[] keywords = BaseView.GetStringFieldValue(row, "keywords").Split(',');
                string tags = "";
                for (int i = 0; i < keywords.Length - 1; i++)
                {
                    string[] ids = keywords[i].Split('-');
                    int idKey = ToSQL.SQLToInt(ids[ids.Length - 1]);
                    DataRow rowK = _db.get_info_words(idKey);
                    if (row != null)
                    {
                        tags += BaseView.GetStringFieldValue(rowK, "keywords") + ", ";
                    }

                }

                lbkeyWord.Text = tags;
            }
        }
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {

        //if (txtUrl.Text.Trim() != "")
        //{
        //DataRow dr = _db.Get_URL_Pages(txtUrl.Text.Trim());
        //if (dr == null)
        //{
        string sqlCommand = "";
        int autoId = 0;
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            sqlCommand = "update";
            autoId = ToSQL.SQLToInt(Request.QueryString["id"]);
        }
        if (autoId == 0)//& dr == null)
        {
            sqlCommand = "insert";
        }
        string content = txtContent.Text;
        string url = txtUrl.Text;
        if (url == "")
        {
            url = linkReplace(txtTieuDe.Text) + ".html";
        }
		
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
        _db.OnInsert_Update_Delete_Pages(autoId, txtCssClass.Text, _title, _desc, lbIDKey.Text, BaseView.replaceLinkHtml(txtTieuDe.Text), DateTime.Now, txtTomTat.Text, content, chkHienThi.Checked, getImage(), url, "admin", sqlCommand);
        Response.Redirect("~/admin-us/trang/");

        //}
        //else
        //{
        //    lbError.Text = "Url đã tồn tại, vui long thay đổi url khác";
        //}
        //}

    }
    private string linkReplace(string chuoi)
    {
        string s = convertToUnSign2(chuoi);
        s = BaseView.repalce_UrlFriendly(s);
        return (s.ToLower());
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
            hinhAnh = "noImg.png";
        return hinhAnh;
    }

    protected void txtTitle_TextChanged(object sender, EventArgs e)
    {
        string s = convertToUnSign2(txtTitle.Text);
        s = BaseView.repalce_UrlFriendly(s);
        txtUrl.Text = s + ".html";
    }
    protected void txtTieuDe_TextChanged(object sender, EventArgs e)
    {
        txtTitle.Text = txtTieuDe.Text;
        string s = convertToUnSign2(txtTieuDe.Text);
        s = BaseView.repalce_UrlFriendly(s);
        txtUrl.Text = s.ToLower() + ".html";
    }

    protected void lstKeywords_SelectedIndexChanged(object sender, EventArgs e)
    {
        string curItem = lstKeywords.SelectedItem.ToString();
        lbIDKey.Text += convertStringLinks(lstKeywords.SelectedItem.Text + "-" + lstKeywords.SelectedValue) + ", ";
        lbkeyWord.Text += lstKeywords.SelectedItem.Text + ", ";

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
            _db.insert_update_delete_words(id, txtTag.Text, "", "", "", command);
            getListTag();
        }
        catch { }
    }
    protected void txtTomTat_TextChanged(object sender, EventArgs e)
    {
        txtDesc.Text = txtTomTat.Text;
    }
}
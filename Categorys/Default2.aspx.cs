using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Categorys_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Form.Action = Request.RawUrl;
        if (!IsPostBack)
            getData();
    }
    private void getData()
    {
        DBClass _db = new DBClass();
        if (!String.IsNullOrEmpty(Request.QueryString["code"]))
        {
            string urlServer = BaseView.UrlServer();
            string urlCode = Request.QueryString["code"];
            string[] urlShort = Request.QueryString["code"].Split('/');
            if (urlShort.Length > 0)
                urlCode = urlShort[urlShort.Length - 1];
            DataRow infoDM = _db.sqlGetData("select * from LoaiTin where code = '" + urlCode + "'").Rows[0];

            if (infoDM != null)
            {
                int id = BaseView.GetIntFieldValue(infoDM, "id");
                string name = BaseView.GetStringFieldValue(infoDM, "name");
                string title = BaseView.GetStringFieldValue(infoDM, "title");
                string desc = BaseView.GetStringFieldValue(infoDM, "description");
                string content = BaseView.GetStringFieldValue(infoDM, "noidung");
                string keywords = BaseView.GetStringFieldValue(infoDM, "keywords");
                string hinhanh = BaseView.GetStringFieldValue(infoDM, "Images").ToLower();

                Page.Title = title == "" ? name : (title);

                Page.MetaDescription = desc;
                Page.MetaKeywords = keywords;
                LbTieuDeChinh.Text = name;
                //ltDescPost.Text = desc;
                //ltContent.Text = content;

                ltCat.Text = "<a itemprop='url' href='" + BaseView.GetStringFieldValue(infoDM, "code").ToLower() + ".hjml'>" + name + "</a>";
                //ltImg.Text = "<meta property='og:image' content='" + BaseView.UrlServer() + "/UploadFile/DanhMuc/" + BaseView.GetStringFieldValue(row, "hinhanh") + "'>";

                if (hinhanh == "")
                    imgDanhMuc.Visible = false;
                else
                    imgDanhMuc.Visible = true;
                imgDanhMuc.ImageUrl = BaseView.UrlServer() + "/uploadFile/DanhMuc/" + hinhanh;
                imgDanhMuc.AlternateText = name;

                string sqlPost = "SELECT top(5000) * from News where isActived = 1 and  (maloai = " + id + " or maloai in (select l.Id from LoaiTin l where l.isPatient = " + id + " ) ) order by id desc";
                string sqlDM = "SELECT * from LoaiTin l where l.isPatient = " + id;

                string htmlTop = "", htmlContent = "";
                DataTable dataDanhMuc = _db.sqlGetData(sqlDM);
                for (int i = 0; i <= dataDanhMuc.Rows.Count - 1; i++)
                {
                    DataRow r = dataDanhMuc.Rows[i];
                    id = BaseView.GetIntFieldValue(r, "id");
                    DataTable dtCount = _db.sqlGetData("SELECT top(5000) * from News where isActived = 1 and  (maloai = " + id + " or maloai in (select l.Id from LoaiTin l where l.isPatient = " + id + " ) ) order by id desc");
                    if (dtCount.Rows.Count > 0)
                    {
                        htmlTop += "<li class='segment-" + (i + 1) + "'><a href='#' class='" + BaseView.GetStringFieldValue(r, "code") + "'>" + BaseView.GetStringFieldValue(r, "name").Replace("Dịch vụ", "") + "</a></li>";
                    }
                }

                DataTable dataNews = _db.sqlGetData(sqlPost);
                for (int i = 0; i <= dataNews.Rows.Count - 1; i++)
                {
                    DataRow r = dataNews.Rows[i];
                    DataRow info = _db.sqlGetData("select * from LoaiTin where id = " + BaseView.GetStringFieldValue(r, "maloai") + "").Rows[0];

                    string HinhAnh = BaseView.GetStringFieldValue(r, "HinhAnh");
                    string url = urlServer + "/" + BaseView.GetStringFieldValue(r, "id_tt");
                    string tieude = BaseView.GetStringFieldValue(r, "tieude");
                    string Desc = BaseView.GetStringFieldValue(r, "Desc").Length > 60 ? BaseView.GetStringFieldValue(r, "Desc").Substring(0, 60) + "..." : BaseView.GetStringFieldValue(r, "Desc");

                    htmlContent += "<li data-id='" + (+i + 1) + "' data-type='" + BaseView.GetStringFieldValue(info, "code") + "'>";
                    htmlContent += "<div class='view view-one'>";
                    htmlContent += "<img src='" + urlServer + "/UploadFile/postImages/" + HinhAnh + "' alt='' />";
                    htmlContent += "<div class='mask'>";
                    htmlContent += "<p>" + Desc + "</p>";
                    htmlContent += "<a href='" + urlServer + "/UploadFile/postImages/" + HinhAnh + "' class='picon-zoom' rel='prettyPhoto' title='" + tieude + "'>";
                    htmlContent += "<i class='icon-zoom-in icon-large'></i>";
                    htmlContent += "</a>";
                    htmlContent += "<a href='" + url + "' class='picon-info'>";
                    htmlContent += "<i class='icon-info icon-large'></i>";
                    htmlContent += "</a>";
                    htmlContent += "</div>";
                    htmlContent += "</div>";
                    htmlContent += "<div class='project-info'>";
                    htmlContent += "<h3><a href='" + url + "' >" + tieude + "</a></h3>";
                    htmlContent += "<p>" + Desc + "</p>";
                    htmlContent += "</div>";
                    htmlContent += "</li>";
                }
                ltTabs.Text = htmlTop;
                ltContentTabs.Text = htmlContent;

            }

        }
    }
}
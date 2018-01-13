using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Categorys_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Form.Action = Request.RawUrl;
        //if (!IsPostBack)
        getInfo();
        if (!IsPostBack)
            getData();
    }
    private string TieuDeTrang()
    {
        DBClass _db = new DBClass();
        string title = "";
        DataRow dr = _db.get_info_caidat();
        if (dr != null)
        {
            title = BaseView.GetStringFieldValue(dr, "tieudetrang");
        }
        return title;
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
                    DataRow info = _db.sqlGetData("select * from LoaiTin where id = '" + BaseView.GetStringFieldValue(r, "maloai") + "'").Rows[0];

                    string HinhAnh = BaseView.GetStringFieldValue(r, "HinhAnh");
                    string url = urlServer + "/" + BaseView.GetStringFieldValue(r, "id_tt");
                    string tieude = BaseView.GetStringFieldValue(r, "tieude");
                    string Desc = BaseView.GetStringFieldValue(r, "Desc").Length > 60 ? BaseView.GetStringFieldValue(r, "Desc").Substring(0, 60) + "..." : BaseView.GetStringFieldValue(r, "Desc");
                    htmlContent += "<li data-id='" + (+i + 1) + "' data-type='" + BaseView.GetStringFieldValue(info, "code") + "'>";
                    htmlContent += "<div class='view view-one'>";
                    htmlContent += "<img src='" + urlServer + "/UploadFile/postImages/" + HinhAnh + "' alt='' />";
                    htmlContent += "<div class='mask'>";
                    htmlContent += "<p>" + Desc + "</p>";
                    htmlContent += "<a href='" + url + "' class='picon-zoom' rel='prettyPhoto' title='" + tieude + "'>";
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
                //ltTabs.Text = htmlTop;
                //ltContentTabs.Text = htmlContent;
                DataTable dtDanhmuc = new DataTable();

                rpDM.DataSource = dataDanhMuc;
                rpDM.DataBind();

            }

        }
    }
    private void getInfo()
    {
        DataRow row = getLoai();
        if (row != null)
        {
            int id = BaseView.GetIntFieldValue(row, "id");
            string name = BaseView.GetStringFieldValue(row, "name");
            string title = BaseView.GetStringFieldValue(row, "title");
            string desc = BaseView.GetStringFieldValue(row, "description");
            string content = BaseView.GetStringFieldValue(row, "noidung");
            string keywords = BaseView.GetStringFieldValue(row, "keywords");

            Page.Title = title == "" ? (BaseView.GetStringFieldValue(row, "name") ) : (title);

            Page.MetaDescription = desc;
            Page.MetaKeywords = keywords;

            ltImg.Text = "<meta property='og:image' content='" + BaseView.UrlServer() + "/UploadFile/DanhMuc/" + BaseView.GetStringFieldValue(row, "hinhanh") + "'>";

            LbTieuDeChinh.Text = name;
            ltDescPost.Text = desc;
            ltContent.Text = content;

            ltCat.Text = "<a itemprop='url' href='" + BaseView.GetStringFieldValue(row, "code").ToLower() + ".hxml'>" + name + "</a>";
            ltCat2.Text = name;
            string hinhanh = BaseView.GetStringFieldValue(row, "Images").ToLower();
            //if (hinhanh == "")
            //    //imgDanhMuc.Visible = false;
            //else
            //    imgDanhMuc.Visible = true;
            //imgDanhMuc.ImageUrl = BaseView.UrlServer() + "/uploadFile/DanhMuc/" + hinhanh;
            //imgDanhMuc.AlternateText = name;
            //getPostWithCat(0);
            BindRepeater(id);
        }
        else
        {
            Response.Redirect("~/404/");
        }

    }
    private void getPostWithCat(int id)
    {
        DBClass _db = new DBClass();
        //rpData.DataSource = _db.Get_All_News_IDLoai(id);
        rpData.DataSource = _db.Get_All_News();
        rpData.DataBind();
    }
    private DataRow getLoai()
    {
        try
        {
            DBClass _db = new DBClass();
            if (!String.IsNullOrEmpty(Request.QueryString["code"]))
            {
                string code = Request.QueryString["code"];
                string[] urlShort = Request.QueryString["code"].Split('/');
                if (urlShort.Length > 0)
                    code = urlShort[urlShort.Length - 1];
                return _db.sqlGetData("select * from LoaiTin where code = '" + code + "'").Rows[0];
            }
            return null;
        }
        catch { return null; }

    }
    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
            {
                return Convert.ToInt32(ViewState["PageNumber"]);
            }
            else
            {
                return 0;
            }
        }
        set { ViewState["PageNumber"] = value; }
    }
    private void BindRepeater(int id)
    {
        //Do your database connection stuff and get your data
        DBClass _db = new DBClass();

        //Create the PagedDataSource that will be used in paging
        PagedDataSource pgitems = new PagedDataSource();
        pgitems.DataSource = _db.Get_all_post_actived(id, true).DefaultView;
        pgitems.AllowPaging = true;

        //Control page size from here 
        pgitems.PageSize = 12;
        pgitems.CurrentPageIndex = PageNumber;
        if (pgitems.PageCount > 1)
        {
            rptPaging.Visible = true;
            ArrayList pages = new ArrayList();
            for (int i = 0; i <= pgitems.PageCount - 1; i++)
            {
                pages.Add((i + 1).ToString());
            }
            rptPaging.DataSource = pages;
            rptPaging.DataBind();
        }
        else
        {
            rptPaging.Visible = false;
        }

        //Finally, set the datasource of the repeater
        //rpData.DataSource = _db.Get_All_News_IDLoai(id);
        rpData.DataSource = pgitems;
        rpData.DataBind();

    }

    //This method will fire when clicking on the page no link from the pager repeater
    protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        ltPage.Text = (PageNumber + 1).ToString();
        getInfo();
        //BindRepeater(0);
    }
    protected void rptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}
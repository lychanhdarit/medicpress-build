using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Posts_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Form.Action = Request.RawUrl;
        HttpCookie cookie = Request.Cookies["adminUserName"];
        if (cookie != null)
        {
            //btnSua.Visible = true;
        }
        //if (!IsPostBack)
        //{
        getInfo();

        //getComments();
        //}
    }
    private string convertStringLinks(string s)
    {
        s = BaseView.convertToUnSign2(s);
        s = BaseView.repalce_UrlFriendly(s);
        return (s.ToLower());
    }
    private void getDataLQ(string idPost)
    {
        DBClass _db = new DBClass();

        string sqlData = "select * from BaiLQ where url_Post = '" + idPost + "'";
        //rpLQ.DataSource = _db.sqlGetData(sqlData);
        //rpLQ.DataBind();
    }
    private void getInfo()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            DiamondProcessCode _dm = new DiamondProcessCode();
            DBClass _db = new DBClass();
            string url = Request.QueryString["id"] + ".html";
            string[] urlShort = Request.QueryString["id"].Split('/');
            if (urlShort.Length > 0)
                url = urlShort[urlShort.Length - 1] + ".html";
            DataRow rowPost = _dm.GetSinglePost(null, url, null, true);
            //int countKey = 0;
            if (rowPost == null)
            {
                rowPost = _db.Get_URL_Pages(url);
            }
            if (rowPost != null)
            {
                string name = BaseView.GetStringFieldValue(rowPost, "tieude");
                string title = BaseView.GetStringFieldValue(rowPost, "title");
                string desc = BaseView.GetStringFieldValue(rowPost, "desc");
                string tomtat = BaseView.GetStringFieldValue(rowPost, "tomtat");
                string content = BaseView.GetStringFieldValue(rowPost, "noidung");
                string keywords = BaseView.GetStringFieldValue(rowPost, "keywords");
                int maloai = BaseView.GetIntFieldValue(rowPost, "maloai");

                Page.Title = title == "" ? BaseView.GetStringFieldValue(rowPost, "name") : title;
                Page.MetaDescription = desc;
                Page.MetaKeywords = keywords;
                ltImg.Text = "<meta property='og:image' content='" + BaseView.UrlServer() + "/UploadFile/postImages/" + BaseView.GetStringFieldValue(rowPost, "hinhanh") + "'>";
                LbTieuDeChinh.Text = name;
                ltDescPost.Text = "<div class=''>" + tomtat + "</div>";
                ltContent.Text = content;
                getDataLQ(BaseView.GetStringFieldValue(rowPost, "id"));
                DataRow infoLoai = _db.get_info_loai(maloai);
                if (infoLoai != null)
                {
                    ltCat.Text = "<a itemprop='url' href='" + BaseView.GetStringFieldValue(infoLoai, "code").ToLower() + ".hxml'>" + BaseView.GetStringFieldValue(infoLoai, "name") + "</a>";
                    ltCat2.Text = BaseView.GetStringFieldValue(infoLoai, "name") ;
                    string hinhanh = BaseView.GetStringFieldValue(infoLoai, "Images").ToLower();
                    //if (hinhanh == "")
                        //imgDanhMuc.Visible = false;
                    //else
                        //imgDanhMuc.Visible = true;
                    //imgDanhMuc.ImageUrl = BaseView.UrlServer() + "/uploadFile/DanhMuc/" + hinhanh;
                    //imgDanhMuc.AlternateText = name;
                }
                //ltCat.Text = "<a itemprop='url' href='" + BaseView.GetStringFieldValue(rowPost, "code").ToLower() + ".hxml'>" + name + "</a>";

                BindRepeater(maloai);

                //btnSua.PostBackUrl = "~/EditPost/default.aspx?id=" + BaseView.GetStringFieldValue(rowPost, "id");
                //try
                //{
                string[] keywordArr = BaseView.GetStringFieldValue(rowPost, "keywords").Split(',');
                string tags = "";
                if (keywordArr.Length > 0)
                {
                    for (int i = 0; i < keywordArr.Length - 1; i++)
                    {
                        //lbTags.Text += i.ToString() + " ";
                        string[] ids = keywordArr[i].Split('-');
                        int idKey = ToSQL.SQLToInt(ids[ids.Length - 1]);
                        DataRow row = _db.get_info_words(idKey);
                        if (row != null)
                        {
                            tags += "<a class='button small' itemprop='keywords' href='../tags/" + BaseView.GetStringFieldValue(row, "id") + "-" + convertStringLinks(BaseView.GetStringFieldValue(row, "keywords")) + "'>" + BaseView.GetStringFieldValue(row, "keywords") + "</a>";
                        }

                    }
                }
                lbTags.Text = tags;
                //}
                //catch { }


                //getLienQuan(BaseView.GetIntFieldValue(r, "maloai"));
                //getCamNangLienQuan(BaseView.GetIntFieldValue(r, "maloai"));
            }
            else
            {
                Response.Redirect("~/404/");
            }

        }
        if (Page.Title == "")
        {
            Page.Title = "Trang không tồn tại.";
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
                string id = Request.QueryString["code"];
                return _db.sqlGetData("select * from LoaiTin where code = '" + id + "'").Rows[0];
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
        pgitems.PageSize = 6;
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
        BindRepeater(0);
    }
    protected void rptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }

    private int getParent()
    {
        return 0;
    }
   
    private int getPostID()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
           
            DBClass _db = new DBClass();
            string url = Request.QueryString["id"] + ".html";
            string[] urlShort = Request.QueryString["id"].Split('/');
            if (urlShort.Length > 0)
                url = urlShort[urlShort.Length - 1] + ".html";
            DiamondProcessCode _dm = new DiamondProcessCode();
            DataRow rowPost = _dm.GetSinglePost(null, url, null, true);
            if (rowPost == null)
            {
                rowPost = _db.Get_URL_Pages(url);
            }
            if (rowPost != null)
            {
                return BaseView.GetIntFieldValue(rowPost, "id");
            }
        }
        return 0;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ab : System.Web.UI.Page
{
    DBClass _db = new DBClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        Form.Action = Request.RawUrl;
        if (!IsPostBack)
        {
            getInfo();
        }
    }


    #region Get Info Page

    public DataRow GetPOST(string urlPage)
    {
        return _db.get_all_news_url(urlPage) == null ? _db.Get_URL_Pages(urlPage) : _db.get_all_news_url(urlPage);
    }
    private string getKeyword(string keywords)
    {
        string tags = "";
        string[] keywordArr = keywords.Split(',');
        if (keywordArr.Length > 0)
        {
            for (int i = 0; i < keywordArr.Length - 1; i++)
            {
                string[] ids = keywordArr[i].Split('-');
                int idKey = ToSQL.SQLToInt(ids[ids.Length - 1]);
                DataRow row = _db.get_info_words(idKey);
                if (row != null)
                {
                    tags += "<li><a href=href='../" + BaseView.convertStringLinks(BaseView.GetStringFieldValue(row, "keywords")) + "-" + BaseView.GetStringFieldValue(row, "id") + ".html'>" + BaseView.GetStringFieldValue(row, "keywords") + "</a></li>";

                }
            }
        }
        return tags;
    }

    private void WritePost(string title, string desc, string keywords, string images, string content, string url, string Seo_Title, string Seo_Desc, string Seo_Key)
    {
        Page.Title = Seo_Title == "" ? title : Seo_Title;
        Page.MetaDescription = Seo_Desc;
        Page.MetaKeywords = Seo_Key;
        ltImgHeader.Text = "<meta property='og:image' content='" + images + "'>";
        ltTitle.Text = title;
        ltTitle2.Text = title;
        ltDescPost.Text = "<div class=''>" + desc + "</div>";
        ltContent.Text = content;
        ltLinkStrema.Text = "<a itemprop='url' href='" + url + "'>" + title + "</a>";
        lbTags.Text = getKeyword(keywords);
    }

    private void getInfo()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["urlcode"]))
        {
            DataRow rowPost = GetPOST(Request.QueryString["urlcode"] + ".html");
            if (rowPost != null)
            {
                string name = BaseView.GetStringFieldValue(rowPost, "tieude");
                string title = BaseView.GetStringFieldValue(rowPost, "title");
                string desc = BaseView.GetStringFieldValue(rowPost, "desc");
                string tomtat = BaseView.GetStringFieldValue(rowPost, "tomtat");
                string content = BaseView.GetStringFieldValue(rowPost, "noidung");
                string keywords = BaseView.GetStringFieldValue(rowPost, "keywords");
                string url = BaseView.GetStringFieldValue(rowPost, "url");
                int maloai = BaseView.GetIntFieldValue(rowPost, "maloai");
                DateTime ngaydang = BaseView.GetDateTimeFieldValue(rowPost, "ngaydang");
                string hinh = BaseView.GetStringFieldValue(rowPost, "hinhanh");
                hinh = hinh.IndexOf("http") == -1 ? BaseView.UrlServer() + "/UploadFile/postImages/" + BaseView.GetStringFieldValue(rowPost, "hinhanh") : hinh;

                //Write Info html----------------------------------------------------

                WritePost(name, tomtat, keywords, hinh, content, url, title, desc, keywords);
                DataRow row = _db.get_info_loai(maloai);
                if (row != null)
                {
                    string urlCat = BaseView.GetStringFieldValue(row, "code") + ".html";
                    string nameCat = BaseView.GetStringFieldValue(row, "name");
                    ltLinkStrema.Text = "<a itemprop='url' href='" + urlCat + "'>" + nameCat + "</a> <i class='fa fa-angle-right'></i><a itemprop='url' href='" + url + "'>" + title + "</a>";
                    ltDM.Text = "<a href='" + urlCat + "'>" + nameCat + "</a>";
                    //ltChuyenMuc.Text = nameCat;
                }
                //Get Category -----------------------------------------------------------------
                BindRepeater(_db.Get_All_News_Loai_SEO(maloai, 0));
                getPostisSEO(maloai, 10, 1, rpBaiSEO);
            }
            else if (_db.get_info_loai_code(Request.QueryString["urlcode"]) != null)
            {
                DataRow infoDM = _db.get_info_loai_code(Request.QueryString["urlcode"]);
                int id = BaseView.GetIntFieldValue(infoDM, "id");
                string name = BaseView.GetStringFieldValue(infoDM, "name");
                string title = BaseView.GetStringFieldValue(infoDM, "title");
                string desc = BaseView.GetStringFieldValue(infoDM, "description");
                string content = BaseView.GetStringFieldValue(infoDM, "noidung");
                string keywords = BaseView.GetStringFieldValue(infoDM, "keywords");
                string url = BaseView.GetStringFieldValue(infoDM, "code");

                //Write Info html----------------------------------------------------

                WritePost(name, name, keywords, desc, content, url, title, desc, keywords);

                //Get Category ------------------------------------------------------

                BindRepeater(_db.Get_All_News_Loai_SEO(id, 0));
                getPostisSEO(id, 10, 1, rpBaiSEO);
                //ltChuyenMuc.Text = name;
            }
            else
            {
                if (dataTags() != null)
                {
                    BindRepeater(dataTags());
                }
                else
                {
                    Response.Redirect("~/404/");
                }
            }

        }
    }

    #endregion



    #region Process List
    private void getPostisSEO(int _maloai,int _top,int _isSeo,Repeater dataRepeater)
    {
        DataTable dt = _db.Get_Top_SEO_Loai(_maloai, _top, _isSeo);
        dataRepeater.DataSource = dt;
        dataRepeater.DataBind();
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

    private DataTable dataTags()
    {
        DBClass _db = new DBClass();
        try
        {
            string idString = Request.QueryString["urlcode"];

            //Info Key ------------------------------------------------------
            string[] sKey = idString.Split('-');
            int idKey = ToSQL.SQLToInt(sKey[sKey.Length - 1]);
            DataRow row = _db.get_info_words(idKey);
            if (row != null)
            {
                string keytext = BaseView.GetStringFieldValue(row, "keywords");
                string title = BaseView.GetStringFieldValue(row, "Title") == "" ? keytext : BaseView.GetStringFieldValue(row, "Title");
                string desc = BaseView.GetStringFieldValue(row, "desc") == "" ? keytext : BaseView.GetStringFieldValue(row, "desc");
                string url = BaseView.convertStringLinks(keytext) + "-" + idKey;
                WritePost(title, desc, keytext, "", "", url, title, desc, keytext);
            }

            //-----------------------------------------------------------
            string key = "%" + idString + "%";
            return _db.Get_Top_News_Tag(key, 2000);
        }
        catch
        {
            return null;
        }
    }

    private void BindRepeater(DataTable data)
    {
        //Do your database connection stuff and get your data
        DBClass _db = new DBClass();

        //Create the PagedDataSource that will be used in paging
        PagedDataSource pgitems = new PagedDataSource();
        //data source

        pgitems.DataSource = data.DefaultView;
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
        rpData.DataSource = pgitems;
        rpData.DataBind();

    }

    //This method will fire when clicking on the page no link from the pager repeater
    protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        ltPage.Text = (PageNumber + 1).ToString();
        getInfo();
    }

    #endregion

    private void sendEmail(string pageName, string body)
    {
        string path = Server.MapPath("~/UploadFile/email.txt");
        using (StreamReader sr = File.OpenText(path))
        {
            string s = String.Empty;
            while ((s = sr.ReadLine()) != null)
            {
                MailDaemon.sendmail(s, pageName, body);
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtMXN.Text == "thammydiamond.net")
        {
            DBClass _db = new DBClass();
            string pageName = "Thẩm mỹ Diamond", address = "", name = txtYourName.Text, email = "", phone = txtPhone.Text, content = txtMessage.Text, domain = "thammydiamond.net";
            string body = BaseView.htmlBody(name, email, phone, address, pageName, content, domain);
            sendEmail(pageName, body);
            Response.Redirect("~/lien-he/success.aspx?urlRequest=XBNMK");
        }
        else
        {
            ltError.Text = "<span style='display:block;padding:5px;border-radius:5px; border:1px solid red;color:red;margin:10px'>Vui lòng điền mã xác nhận!</span>";
        }
    }
}
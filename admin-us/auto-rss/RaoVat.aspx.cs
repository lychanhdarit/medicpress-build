using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class admin_rv_auto_Default2 : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        beginUpdate();
        getNews();
    }
    private void getNews()
    {
        DataTable dt = _db.Get_Top_News_notNews(1000);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    private void beginUpdate()
    {
        DataTable dtrSS = getRSS();
        foreach (DataRow row in dtrSS.Rows)
        {
            string url = BaseView.GetStringFieldValue(row, "url");
            string urlRSS = BaseView.GetStringFieldValue(row, "urlRSS");
            string title = BaseView.GetStringFieldValue(row, "title");
            string date = BaseView.GetStringFieldValue(row, "date");
            string Desc = BaseView.GetStringFieldValue(row, "Desc");
            int idLoai = BaseView.GetIntFieldValue(row, "IdCatalogy");
            if (getContent(urlRSS, url, title, date, Desc, idLoai) == 1)
            {
                return;
            }
        }
    }
    private int getContent(string urlRss, string urls, string title, string datePost, string description, int idLoai)
    {
        try
        {
            string content = "";
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(urls);
            DataRow rowNode = _db.get_info_loai(idLoai);
            int result = 0;
            if (rowNode != null)
            {
                content = "";
                string nodeContent = BaseView.GetStringFieldValue(rowNode, "noidung");
                HtmlNodeCollection node = doc.DocumentNode.SelectNodes("//" + nodeContent);
                foreach (var item in node)
                {
                    string sHtml = item.InnerHtml.Replace("href=", @" href='#' ") + Environment.NewLine;
                    content += sHtml;
                }
                string[] a = urls.Split('/');
                if (a.Length > 2)
                {
                    content += "<div class='nguon'> Nguồn: " + a[2] + "</div>";
                }
                if (Post(urlRss, urls, title, description, datePost, content, getImages(content), createUrlFriendly(title.Trim()), idLoai) == 1)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }
        catch { return 0; }
    }
    private int checkNews(string url)
    {
        DataRow row = _db.Get_Code_News(url);
        if (row != null)
        {
            return 1;
        }
        return 0;
    }

    private string getKeyWord(string url)
    {

        DataRow row = _db.get_loai_url(url);
        if (row != null)
        {
            string id = BaseView.GetStringFieldValue(row, "keywords");
            return id;
        }

        return "";
    }
    private int Post(string urlRss, string url, string tieude, string description,string datePost, string content, string img, string code_url_friendly, int idLoai)
    {
        try
        {
            if (checkNews(url) == 0)
            {
                if (img.Length >= 200)
                {
                    img = img.Substring(0, 200);
                }
                if (code_url_friendly.Length > 50)
                {
                    code_url_friendly = code_url_friendly.Substring(0, 50);
                }
                if (BaseView.CheckImg(img) == false)
                {
                    img = "Nha-khoa-thuan-kieu.png";
                }
                if (content.Trim().Length > 200)
                    _db.OnInsert_Update_Delete_News(0, url, tieude, description, getKeyWord(urlRss), tieude, ToSQL.SQLToDateRic(datePost), description, content, true, img, idLoai, code_url_friendly, "", "", 0, 0, "", ToSQL.SQLToDateRic(datePost).AddMonths(12),"","", "insert");
                return 1;
            }
            else return 0;
        }
        catch { return 0; }
    }
    string createUrlFriendly(string title)
    {
        string s = BaseView.convertToUnSign2(title);
        s = BaseView.repalce_UrlFriendly(s);
        return s;
    }
    string getImages(string content)
    {
        int beginIndex = content.IndexOf("src=");
        string ctSub = "";
        try
        {
            ctSub = content.Substring(beginIndex, content.Length - beginIndex);
        }
        catch { }
        int endIndex = ctSub.IndexOf(".jpg");
        if (endIndex >= 200)
        {
            endIndex = ctSub.IndexOf(".gif");
        }
        if (endIndex >= 200)
        {
            endIndex = ctSub.IndexOf(".png");
        }
        if (endIndex >= 200)
        {
            endIndex = ctSub.IndexOf(".jpeg");
        }
        string imgString = "";
        try
        {
            imgString = ctSub.Substring(5, ((endIndex) - (5)) + 4);
        }
        catch
        {
            imgString = "nha-khoa-thuan-kieu.png";
        }
        return imgString;
    }
    private DataTable getRSS()
    {
        DataTable dtRSS = new DataTable();
        dtRSS.Columns.Add("url");
        dtRSS.Columns.Add("title");
        dtRSS.Columns.Add("date");
        dtRSS.Columns.Add("Desc"); 
        dtRSS.Columns.Add("urlRss");
        dtRSS.Columns.Add("IdCatalogy");
        DataTable dt = _db.get_all_LoaiTin_UrlNotNull_RV();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                try
                {

                   string feedUrl = BaseView.GetStringFieldValue(dr, "url");
                    //string feedUrl = "http://ndfloodinfo.com/external.php?type=RSS2&forumids=13‎";
                    //feedUrl = "http://gamek.vn/game-online.rss";
                    if (!String.IsNullOrEmpty(feedUrl))
                    {
                        WebClient client = new WebClient();
                        using (XmlReader reader = new SyndicationFeedXmlReader(client.OpenRead(feedUrl)))
                        {
                            SyndicationFeed feed = SyndicationFeed.Load(reader);
                            foreach (SyndicationItem album in feed.Items)
                            {
                                try
                                {
                                    DataRow row = dtRSS.NewRow();
                                    row[0] = album.Links[0].Uri;
                                    row[1] = album.Title.Text;
                                    row[2] = album.PublishDate;
                                    row[3] = album.Summary.Text ;
                                    row[4] = BaseView.GetStringFieldValue(dr, "url");
                                    row[5] = BaseView.GetStringFieldValue(dr, "id");
                                    dtRSS.Rows.Add(row);
                                }
                                catch { }
                            }
                        }

                    }
                }
                catch { }
            }
        }
        return dtRSS;
    }
}
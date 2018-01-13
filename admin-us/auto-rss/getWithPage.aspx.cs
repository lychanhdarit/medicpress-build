using Facebook;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_rv_auto_getWithPage : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        beginUpdate();
        if (!IsPostBack)
        {
            GridView1.DataSource = getRSS();
            GridView1.DataBind();
        }
    }
    private void getData(int index)
    {
        //grvTaskNew.PageIndex = index;
        //DataTable dt = _db.Get_All_News();
        //if (ddlLoai.SelectedValue != "0")
        //{
        //    dt = _db.Get_All_News_IDLoai(ToSQL.SQLToInt(ddlLoai.SelectedValue));
        //}
        //grvTaskNew.DataSource = dt;
        //grvTaskNew.DataBind();
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
        DataTable dt = _db.Get_All_LoaiTin();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (url.IndexOf(BaseView.GetStringFieldValue(dr, "urlct")) != -1)
                {
                    DataRow row = _db.get_loai_url(BaseView.GetStringFieldValue(dr, "url"));
                    if (row != null)
                    {
                        string id = BaseView.GetStringFieldValue(row, "keywords");
                        return id;
                    }
                }
            }

        }
        return "";
    }
    private void getItem(string urls, string title, string description, string datePost, string content, string maloai)
    {
        try
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(urls);
            DataRow rowNode = _db.get_info_loai(ToSQL.SQLToInt(maloai));
            if (rowNode != null)
            {
                string nodeTitle = BaseView.GetStringFieldValue(rowNode, "title");
                HtmlNodeCollection nodetitle_news = doc.DocumentNode.SelectNodes("//" + nodeTitle);
                title = "";
                foreach (var item in nodetitle_news)
                {
                    title += item.InnerText + Environment.NewLine;
                }
                string nodeDesc  = BaseView.GetStringFieldValue(rowNode, "description");
                HtmlNodeCollection nodeshort_intro = doc.DocumentNode.SelectNodes("//" + nodeDesc);
                description = "";
                foreach (var item in nodeshort_intro)
                {
                    description += item.InnerText + Environment.NewLine;
                }

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
                if (content.Trim().Length > 200)
                    Post(urls, title, description, datePost, content, getImages(content), createUrlFriendly(title.Trim()), maloai);
            }
            
        }
        catch { }
    }
    private void Do(string cmd, string link, string pic, string tt, string desc)
    {
        string app_id = "1561979964048650";//"1003892819626567"; //
        string app_secret = "d9357fd5551b312c2e5ebdcca34846e0";//"b050ba010add354bab18ac9460cbc488"; //
        string scope = "publish_stream,manage_pages";

        if (Request["code"] == null)
        {
            Response.Redirect(string.Format(
                "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                app_id, Request.Url.AbsoluteUri, scope));
        }
        else
        {
            Dictionary<string, string> tokens = new Dictionary<string, string>();

            string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);

            HttpWebRequest request = System.Net.WebRequest.Create(url) as HttpWebRequest;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string vals = reader.ReadToEnd();

                foreach (string token in vals.Split('&'))
                {
                    //meh.aspx?token1=steve&token2=jake&...
                    tokens.Add(token.Substring(0, token.IndexOf("=")),
                        token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                }
            }

            string access_token = tokens["access_token"];

            var client = new FacebookClient(access_token);

            dynamic parameters = new ExpandoObject();
            parameters.message = cmd;
            parameters.link = link;
            parameters.picture = pic;
            parameters.name = tt;
            parameters.caption = desc;

            //446533181408238 is my fan page
            client.Post("/lamdep123.org/feed", parameters);

        }
    }

    private void Post(string url, string tt, string des,string datepost, string content, string img, string url_f,string maloai)
    {
        //try
        //{
            if (checkNews(url) == 0)
            {
                if (img.Length >= 200)
                {
                    img = img.Substring(0, 200);
                }
                if (url_f.Length > 50)
                {
                    url_f = url_f.Substring(0, 50);
                }
                url_f = url_f +".html";
                if (BaseView.CheckImg(img) == false)
                {
                    img = "Nha-khoa-thuan-kieu.png";
                }
                if (content.Trim().Length > 100)
                {
                    _db.OnInsert_Update_Delete_News(0, url, tt, des, getKeyWord(url), tt, ToSQL.SQLToDateRic(BaseView.getDateTimeNow()), des, content, true, img, ToSQL.SQLToInt(maloai), url_f, "", "", 0, 0, "", ToSQL.SQLToDateRic(BaseView.getDateTimeNow()),"","", "insert");
                }

            }
        //}
        //catch { }
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
            string Desc ="",DatePost="",Content="";
            string idLoai = BaseView.GetStringFieldValue(row, "IdCatalogy");
            getItem(url, title,Desc, DatePost, Content, idLoai);
        }
        
    }

    private DataTable getRSS()
    {
        DataTable dtRSS = new DataTable();
        dtRSS.Columns.Add("title");
        dtRSS.Columns.Add("url");
        dtRSS.Columns.Add("date");
        dtRSS.Columns.Add("IdCatalogy");
        dtRSS.Columns.Add("urlRss");
        DataTable dt = _db.get_all_LoaiTin_UrlNotNull();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string url = BaseView.GetStringFieldValue(dr, "url");
                string urlct = BaseView.GetStringFieldValue(dr, "urlct");
                if (!String.IsNullOrEmpty(url))
                {
                    try
                    {
                        var web = new HtmlWeb();
                        var doc = web.Load(url);
                        var links = from lnk in doc.DocumentNode.Descendants()
                                    where lnk.Name == "a" &&
                                    lnk.Attributes["href"] != null &&
                                    lnk.InnerText.Trim().Length > 30
                                    select new
                                    {
                                        link = lnk.Attributes["href"].Value,
                                        text = lnk.InnerText.Replace("&nbsp;", "")
                                    };
                        foreach (var l in links)
                        {
                            DataRow r = dtRSS.NewRow();
                            r[0] = l.text;
                            string[] A = l.link.Split('/');
                            r[1] = urlct + A[A.Length - 1];
                            r[2] = ToSQL.SQLToDateRic(BaseView.getDateTimeNow());
                            r[3] = BaseView.GetStringFieldValue(dr, "id");
                            r[4] = BaseView.GetStringFieldValue(dr, "url");
                            dtRSS.Rows.Add(r);
                        }
                    }
                    catch { }

                }
            }
        }
        return dtRSS;
    }
    protected void grvTaskNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        getData(e.NewPageIndex);
    }
    protected void ddlLoai_SelectedIndexChanged(object sender, EventArgs e)
    {
        getData(0);
    }
}
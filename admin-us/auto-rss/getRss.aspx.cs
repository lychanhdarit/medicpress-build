using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Facebook;
using HtmlAgilityPack;
using System.Data;
using System.Net;
using System.IO;
using System.Dynamic;
using System.Text;
using Google.GData.Blogger;
using Google.GData.Client;
using Google.GData.Photos;
using Google.GData.Extensions;
public partial class _Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    private string GetAlbumRSS(SyndicationItem album)
    {

        string url = "";
        foreach (SyndicationElementExtension ext in album.ElementExtensions)
            if (ext.OuterName == "itemRSS") url = ext.GetObject<string>();
        return (url);

    }
    public int sendPostToBlogspot(string blogId, string username, string password, string title, string postBody, string tags)
    {
        //CheckForIllegalCrossThreadCalls = false;
        int q = 0;
        Service service = new Service("blogger", "googleAPIshittyName");
        service.Credentials = new GDataCredentials(username, password);
        GDataGAuthRequestFactory factory = (GDataGAuthRequestFactory)service.RequestFactory;
        factory.AccountType = "GOOGLE";
        /////////////////////////////////////////////////////////////

        if (postBody.Contains("[IMGLINK]"))
        {
            postBody = postBody.Replace("[IMGLINK]", uploadImageToGoogle("image.png", username, password, blogId));
        }
        postBody = BaseView.RemoveHtmlTagsUsingCharArray(postBody);
        ///////post////////////////////////////////
        AtomEntry post = new AtomEntry();
        post.Title.Text = title;
        post.Content = new AtomContent();
        post.Content.Content = postBody;
        post.Content.Type = "xhtml";
        int length = 0;
        //make sure that tags are not too long
        string[] tagsS = tags.Split(',');
        foreach (string label in tagsS)
        {
            length = length + label.Count();
            if (length > 198)
            {
                string label2 = label.Substring(0, 199);
                AtomCategory cat = new AtomCategory();
                cat.Scheme = new Uri("http://www.blogger.com/atom/ns#");
                cat.Term = label2;
                post.Categories.Add(cat);
                //this.txtTag.Text = this.txtTag.Text + label2 + ",";
                break;
            }
            else
            {
                AtomCategory cat = new AtomCategory();
                cat.Scheme = new Uri("http://www.blogger.com/atom/ns#");
                cat.Term = label;
                post.Categories.Add(cat);
            }
        }
        post.IsDraft = false;
        ///////////////publishing post/_/_/_/_/_/_\_|_/_)_(_--> () - {} - [] 0_o
        Uri blogFeedUri = new Uri("http://www.blogger.com/feeds/" + blogId + "/posts/default");
        AtomEntry createdEntry = null;
        try
        {
            createdEntry = service.Insert(blogFeedUri, post);
            //MessageBox.Show("Done!");
            Label1.Text += "Thành Công!!! <br/>";
            q = 1;
        }
        catch (GDataRequestException exception)
        {
            if (exception.ResponseString == "Blog has exceeded rate limit or otherwise requires word verification for new posts")
            {   // MessageBox.Show("Blog has exceeded rate limit or otherwise requires word verification for new posts");
                Label1.Text += "Blog has exceeded rate limit or otherwise requires word verification for new posts <br/>";
                q = 0;
            }
        }
        if (createdEntry == null)
        {
            //MessageBox.Show("Something went wrong, atricle was not published...\nCheck all html tags...");
            Label1.Text += "Something went wrong, atricle was not published...\nCheck all html tags...<br/>";
            q = 0;
        }
        return q;
    }

    public string uploadImageToGoogle(string path, string username, string password, string blogId)
    {
        if (!System.IO.File.Exists(path))
            return "Error! Image file not found";
        ///////////////////////token session and shits...///////////
        PicasaService service = new PicasaService("HowToFixPRO");
        service.setUserCredentials(username, password);
        /////////////////cdefault album is dropBox or something////
        Uri postUri = new Uri(PicasaQuery.CreatePicasaUri(username));

        System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
        System.IO.FileStream fileStream = fileInfo.OpenRead();

        PicasaEntry entry = (PicasaEntry)service.Insert(postUri, fileStream, "image/png", "nameOfYourFile");
        fileStream.Close();

        PhotoAccessor ac = new PhotoAccessor(entry);
        string contentUrl = entry.Media.Content.Attributes["url"] as string;

        return contentUrl;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // getDropdownList();
            gvd.DataSource = getRSS();
            gvd.DataBind();
        }
        beginUpdate();
        getData(0);
    }

    private void getData(int index)
    {
        grvTaskNew.PageIndex = index;
        DataTable dt = _db.Get_All_News();
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
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

    private void autoPost(string urlRss, string url, string tieude, string description, string content, string img, string code_url_friendly, int idLoai)
    {
        try
        {
            
            if (checkNews(url) == 0)
            {
                //Do(tieude, "http://lamdep123.org/" + code_url_friendly, img, tieude, description);
                if (code_url_friendly.Length > 50)
                {
                    code_url_friendly = code_url_friendly.Substring(0, 50);
                }
                if (code_url_friendly.Trim().Length == 0)
                {
                    code_url_friendly = BaseView.convertToUnSign2(tieude);

                    code_url_friendly = BaseView.repalce_UrlFriendly(code_url_friendly.Trim()) + ".html";
                }
                else
                {
                    if (code_url_friendly.IndexOf(".html") == -1)
                        code_url_friendly = code_url_friendly + ".html";
                }
               
                if (BaseView.CheckImg(img) == false)
                {
                    img = "noImg.png";
                }
                if (content.Trim().Length > 200)
                {
                    
                    DataRow rowL = _db.get_info_loai(idLoai);
                    if (rowL != null)
                    {
                        //string idBlog = BaseView.GetStringFieldValue(rowL, "idBlog");
                        //DataRow infoBlog = _db.get_info_blog(idBlog);
                        //if (infoBlog != null)
                        //{
                           //int q= sendPostToBlogspot(idBlog, BaseView.GetStringFieldValue(infoBlog, "user_name"), BaseView.GetStringFieldValue(infoBlog, "pass_word"), tieude, content, BaseView.GetStringFieldValue(infoBlog, "tag"));
                           //if (q == 1)
                           //{
                               _db.OnInsert_Update_Delete_News(0, url, tieude, description, getKeyWord(urlRss), tieude, ToSQL.SQLToDateRic(BaseView.getDateTimeNow()), description, content, true, img, idLoai, code_url_friendly, "", "", 0, 0, "", null, "","", "insert");
                           //}
                        //}
                    }
                }

            }
        }
        catch { }
    }
    
    private void beginUpdate()
    {
        DataTable dtrSS = getRSS();
        foreach (DataRow row in dtrSS.Rows)
        {
            string url = BaseView.GetStringFieldValue(row, "url");
            string urlRSS = BaseView.GetStringFieldValue(row, "urlRSS");
            int idLoai = BaseView.GetIntFieldValue(row, "IdCatalogy");
            getItem(urlRSS, url, idLoai);
        }
    }
    private DataTable getRSS()
    {
        DataTable dtRSS = new DataTable();
        dtRSS.Columns.Add("url");
        dtRSS.Columns.Add("text");
        dtRSS.Columns.Add("urlRss");
        dtRSS.Columns.Add("IdCatalogy");
        DataTable dt = _db.get_all_LoaiTin_UrlNotNull();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                try
                {

                    string feedUrl = BaseView.GetStringFieldValue(dr, "url");
                    //string feedUrl = "http://gamek.vn/game-online.rss‎";

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
                                    
                                    row[2] = BaseView.GetStringFieldValue(dr, "url");
                                    row[3] = BaseView.GetStringFieldValue(dr, "id");
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
    private void getItem(string urlRss, string urls, int idLoai)
    {
        try
        {
            string title = "", description = "", content = "";
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(urls);
            DataRow rowNode = _db.get_loai_url(urlRss);
            if (rowNode != null)
            {
                string titleNode = BaseView.GetStringFieldValue(rowNode, "title");
                HtmlNodeCollection nodetitle_news = doc.DocumentNode.SelectNodes("//" + titleNode);
                title = "";
                foreach (var item in nodetitle_news)
                {
                    title += item.InnerText + Environment.NewLine;
                }
                string nodeDesc = BaseView.GetStringFieldValue(rowNode, "description");
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
                int beginIndex = content.IndexOf("src=");
                string ctSub = "";
                try
                {
                    ctSub = content.Substring(beginIndex, content.Length - beginIndex);
                }
                catch { }
                int endIndex = ctSub.IndexOf(".jpg");
                if (endIndex == -1)
                {
                    endIndex = ctSub.IndexOf(".gif");
                }
                if (endIndex == -1)
                {
                    endIndex = ctSub.IndexOf(".png");
                }
                if (endIndex == -1)
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
                    imgString = "noImg.png";
                }
                string[] a = urls.Split('/');
                if (a.Length > 2)
                {
                    content += "<div class='nguon'> Nguồn: " + a[2] + "</div>";
                }

                string code_url_friendly = a[a.Length - 1];
                autoPost(urlRss, urls, title, description, content, imgString, code_url_friendly, idLoai);
            }
        }
        catch { }
    }
    
}
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class admin_us_auto_post_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getGroupRSS();
            getListRSS();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        DataTable dt = getListRSS();
        int j = 0, co = 0, ko = 0;
        foreach (DataRow row in dt.Rows)
        {
            string url = BaseView.GetStringFieldValue(row, "url");
            string hinhanh = BaseView.GetStringFieldValue(row, "hinhanh");
            int IdGroupRSS = ToSQL.SQLToInt(ddlCT.SelectedValue);
            j++;
            int i = Post(url, hinhanh, IdGroupRSS);
            if (i == 0)
            {
                lthtml.Text += "<span style='display:block;padding:5px;border:1px solid #F39C12;color:#F39C12;margin-top:2px'>" + j + ". Url: " + url + " không thành công </span>";
                ko++;
            }
            else
            {
                lthtml.Text += "<span style='display:block;padding:5px;border:1px solid #00A65A;color:#00A65A;margin-top:2px'>" + j + ". Url: " + url + " thành công!  </span>";
                co++;
            }
        }
        ltThongSo.Text = "<b>Thống kê:</b> " + co + " bài đã đăng / " + ko + " không đăng được.";

    }

    private DataTable getListRSS()
    {
        /* get list URL from RSS */
        DataTable dtRSS = new DataTable();
        dtRSS.Columns.Add("url");
        dtRSS.Columns.Add("hinhanh");
        /* get list URL from RSS */

        string feedUrl = txtURL.Text;
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

                        //get hinh
                        const string rx = @"(?<=img\s+src\=[\x27\x22])(?<Url>[^\x27\x22]*)(?=[\x27\x22])";
                        string hinhanh = "";
                        foreach (Match m in Regex.Matches(album.Summary.Text, rx, RegexOptions.IgnoreCase | RegexOptions.Multiline))
                        {
                            hinhanh = m.Groups[1].Value;
                            if (hinhanh.StartsWith("//")) // Google RSS has it
                            {
                                hinhanh = hinhanh.Replace("//", "http://");
                            }


                        }
                        // end get hinh
                        row[1] = hinhanh;
                        dtRSS.Rows.Add(row);
                    }
                    catch { }
                }
            }
        }
        return dtRSS;
    }
    private void getGroupRSS()
    {
        //
        DBClass _db = new DBClass();
        DataTable data = _db.sqlGetData("select * from RssGroups");
        ddlCT.DataSource = data;
        ddlCT.DataBind();
    }
    private int Post(string url, string hinhdaidien, int idRSSGroup)
    {
        try
        {
            DBClass _db = new DBClass();
            string title = "", description = "", content = "";
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(url);

            DataRow rowNode = _db.sqlGetDataRow("select * from RssGroups where id  = " + idRSSGroup + "");// get tag </> form Group
            if (rowNode != null)
            {
                string titleNode = BaseView.GetStringFieldValue(rowNode, "Tagtitle");
                HtmlNodeCollection nodetitle_news = doc.DocumentNode.SelectNodes("//" + titleNode);
                title = "";
                foreach (var item in nodetitle_news)
                {
                    title += item.InnerText + Environment.NewLine;
                }
                string nodeDesc = BaseView.GetStringFieldValue(rowNode, "TagDesc");
                HtmlNodeCollection nodeshort_intro = doc.DocumentNode.SelectNodes("//" + nodeDesc);
                description = "";

                foreach (var item in nodeshort_intro)
                {
                    description += item.InnerText + Environment.NewLine;

                }
                content = "";
                string nodeContent = BaseView.GetStringFieldValue(rowNode, "TagContent");

                HtmlNodeCollection node = doc.DocumentNode.SelectNodes("//" + nodeContent);
                foreach (var item in node)
                {
                    string sHtml = BaseView.RemoveLinks(item.InnerHtml) + Environment.NewLine;
                    content += sHtml;

                }

                // Process Images
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

                string hinhDaiDien = "";
                try
                {
                    hinhDaiDien = ctSub.Substring(5, ((endIndex) - (5)) + 4);
                }
                catch
                {

                }
                // Process link
                string[] a = url.Split('/');
                if (a.Length > 2)
                {
                    content += "<div class='nguon'> Nguồn: " + a[2] + "</div>";
                }

                string url_friendly = a[a.Length - 1];

                if (BaseView.CheckImg(hinhdaidien) == false)
                {
                    hinhdaidien = hinhDaiDien;
                }
                if (BaseView.CheckImg(hinhdaidien) == false)
                {
                    hinhdaidien = "noImg.png";
                }
                // Save to database
                return SavePost(url, title, description, content, hinhdaidien, url_friendly);
            }
            return 0;
        }
        catch { return 0; }
    }


    private int checkNews(string url)
    {
        DBClass _db = new DBClass();
        DataRow row = _db.Get_Code_News(url);
        if (row != null)
        {
            return 1;
        }
        return 0;
    }

    private int SavePost(string url_from_rss, string tieude, string description, string content, string img, string code_url_friendly)
    {
        try
        {
            DBClass _db = new DBClass();
            if (checkNews(url_from_rss) == 0)
            {

                if (code_url_friendly.Length > 50)
                {
                    code_url_friendly = code_url_friendly.Substring(0, 50);
                }
                if (code_url_friendly.Trim().Length == 0)
                {
                    code_url_friendly = BaseView.RemoveKiTuDacBietVaKhoangTrang(tieude.ToLower()) + ".html";
                }
                else
                {
                    if (code_url_friendly.IndexOf(".html") == -1)
                        code_url_friendly = code_url_friendly + ".html";
                }

                if (content.Trim().Length > 200)
                {
                   
                        //_db.OnInsert_Update_Delete_News(0, url_from_rss, tieude, description, "", tieude, ToSQL.SQLToDateRic(BaseView.getDateTimeNow()), description, content, true, img, idLoai, code_url_friendly, "", "", 0, 0, "", null, "", "", "insert");
                        // ltHome.Text +="<img src='"+ img+ "'/></br>";
                        string html = "<div style='border:1px solid #808080;margin:10px;padding:10px;'>";
                        html += "<img src='" + img + "'/></br>";
                        html += "<h2>"+tieude+"</h2>";
                        html += "<p>" + description + "</p>";
                        html += "<p>" + content + "</p>";
                        html += "</div>";

                        ltHome.Text += html;

                        return 1;
                    
                }
            }
            return 0;
        }
        catch { return 0; }
    }

}
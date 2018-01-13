using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class GetRSS : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["code"]))
        {
            DataRow row = _db.get_info_url();
            string LinksServer = BaseView.UrlServer();
            //if (row != null)
            //{
            //    LinksServer = BaseView.GetStringFieldValue(row, "links");
            //}
            NewsRSS rss = new NewsRSS();

            NewsRSS.RssChannel channel = new NewsRSS.RssChannel();

            channel.Title = "";

            channel.Link = LinksServer;

            channel.Description = "Website TMDM";

            rss.AddRssChannel(channel);

            DataTable dt = _db.Get_Rss_News(Request.QueryString["code"].Replace("'", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string hinh = BaseView.GetStringFieldValue(dr, "HinhAnh");
                if (hinh.IndexOf("http") == -1 && hinh.Trim() != null)
                {
                    hinh = LinksServer + "/uploadFile/postImages/" + hinh;
                }
                else if (hinh.Trim() == "")
                {
                    hinh = LinksServer + "/uploadFile/postImages/noimg.png";
                }
                string linkR = LinksServer + "/" + BaseView.GetStringFieldValue(dr, "url") + "";
                string linkR_Img = "<a href='" + LinksServer
                    + "/" + BaseView.GetStringFieldValue(dr, "url") + "" + "'>" + "<img width=130 height=100 src='" + hinh + "' ></a></br>";
                NewsRSS.RssItem item = new NewsRSS.RssItem();

                item.Title = BaseView.GetStringFieldValue(dr, "Title");

                item.Link = linkR;

                // item.Description = "<![CDATA[   "+ linkR_Img + BaseView.GetStringFieldValue(dr, "desc") + "]]>";

                item.cData = linkR_Img + BaseView.GetStringFieldValue(dr, "desc");
                rss.AddRssItem(item);
            }
            Response.Clear();

            Response.ContentType = "text/xml";

            Response.Write(rss.RssDocument);

            Response.End();
        }
        else
        {

            string LinksServer = BaseView.UrlServer();
            //if (row != null)
            //{
            //    LinksServer = BaseView.GetStringFieldValue(row, "links");
            //}
            NewsRSS rss = new NewsRSS();

            NewsRSS.RssChannel channel = new NewsRSS.RssChannel();

            channel.Title = "";

            channel.Link = LinksServer;

            channel.Description = "Website TMDM";

            rss.AddRssChannel(channel);

            DataTable dt = _db.get_top_news(100);

            foreach (DataRow dr in dt.Rows)
            {
                string hinh = BaseView.GetStringFieldValue(dr, "HinhAnh");
                if (hinh.IndexOf("http") == -1 && hinh.Trim() != null)
                {
                    hinh = LinksServer + "/uploadFile/postImages/" + hinh;
                }
                else if (hinh.Trim() == "")
                {
                    hinh = LinksServer + "/uploadFile/postImages/noimg.png";
                }
                string linkR = LinksServer + "/" + BaseView.GetStringFieldValue(dr, "url") + "";
                string linkR_Img = "<a href='" + LinksServer
                    + "/" + BaseView.GetStringFieldValue(dr, "url") + "" + "'>" + "<img width=130 height=100 src='" + hinh + "' ></a></br>";
                NewsRSS.RssItem item = new NewsRSS.RssItem();

                item.Title = BaseView.GetStringFieldValue(dr, "Title");

                item.Link = linkR;

                // item.Description = "<![CDATA[   "+ linkR_Img + BaseView.GetStringFieldValue(dr, "desc") + "]]>";

                item.cData = linkR_Img + BaseView.GetStringFieldValue(dr, "desc");
                rss.AddRssItem(item);
            }
            Response.Clear();

            Response.ContentType = "text/xml";

            Response.Write(rss.RssDocument);

            Response.End();
        }

    }
}

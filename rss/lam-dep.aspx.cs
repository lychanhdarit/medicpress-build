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
        NewsRSS rss = new NewsRSS();

        NewsRSS.RssChannel channel = new NewsRSS.RssChannel();

        channel.Title = "Nha Khoa Thuận Kiều";

        channel.Link = HttpContext.Current.Request.Url.Host;

        channel.Description = "Website Nha Khoa Thuận Kiều.";

        rss.AddRssChannel(channel);

        DataTable dt = _db.Get_All_News_IDLoai(5);// GetData("SELECT * FROM Feeds WHERE ChannelId = @ChannelId", channelId);
        foreach (DataRow dr in dt.Rows)
        {

            string linkR = HttpContext.Current.Request.Url.Host + "/news/chi-tiet.aspx?id=" + BaseView.GetStringFieldValue(dr, "id");
            string linkR_Img= "<a href='" + HttpContext.Current.Request.Url.Host
                + "/news/chi-tiet.aspx?id=" + BaseView.GetStringFieldValue(dr, "id") + "'>" + "<img width=130 height=100 src='" + HttpContext.Current.Request.Url.Host + @"/upload/" + BaseView.GetStringFieldValue(dr, "HinhAnh") + "' ></a></br>";
            NewsRSS.RssItem item = new NewsRSS.RssItem();

            item.Title = BaseView.GetStringFieldValue(dr,"Title");

            item.Link = linkR;

            item.Description = "<![CDATA[   "+ linkR_Img + BaseView.GetStringFieldValue(dr, "desc") + "]]>"; 

            rss.AddRssItem(item);
        }
        Response.Clear();

        Response.ContentType = "text/xml";

        Response.Write(rss.RssDocument);

        Response.End();

    }
}

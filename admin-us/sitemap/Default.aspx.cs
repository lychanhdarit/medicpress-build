using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class admin_us_sitemap_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void UpdateXml()
    {
       
            //Response.Clear();
            //Response.ContentType = "text/xml";
            using (XmlTextWriter writer = new XmlTextWriter(Server.MapPath("~/sitemap.xml"), Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("urlset");
                writer.WriteAttributeString("xmlns", "http://www.google.com/schemas/sitemap/0.84");
                writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                writer.WriteAttributeString("xsi:schemaLocation", "http://www.google.com/schemas/sitemap/0.84 http://www.google.com/schemas/sitemap/0.84/sitemap.xsd");


                DBClass _db = new DBClass();
                DataTable dtDM = _db.get_all_DanhMuc();
                BaseView _bv = new BaseView();
                foreach (DataRow row in dtDM.Rows)
                {
                    int idDanhMuc = BaseView.GetIntFieldValue(row, "maDanhMuc");
                    string convertTitleToUrl = BaseView.repalce_UrlFriendly(BaseView.convertToUnSign2(BaseView.GetStringFieldValue(row, "tenDanhMuc")).ToLower());
                    string linkURL = BaseView.repalce_UrlFriendly(convertTitleToUrl + "-" + idDanhMuc) + ".html";
                   

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", _bv.serverUrl() + "/" + linkURL + "");
                    writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "1.00");
                    writer.WriteEndElement();
                }

                DataTable dtLT = _db.Get_All_LoaiTin();
                foreach (DataRow row in dtLT.Rows)
                {
                    //tableSiteMap.Rows.Add(new object[] { "http://thammydiamond.com/"+ BaseView.GetStringFieldValue(row, "code").ToLower() + ".html", DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day, "weekly" });
                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", _bv.serverUrl() + "/" + BaseView.GetStringFieldValue(row, "code").ToLower() + ".html");
                    writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "1.00");
                    writer.WriteEndElement();
                }
                //DataTable dtTag = _db.get_top_words(10000);
                //foreach (DataRow row in dtTag.Rows)
                //{
                //    //tableSiteMap.Rows.Add(new object[] { "http://thammydiamond.com/" + "tags/" + BaseView.GetStringFieldValue(row, "id") + "-" + convertStringLinks(BaseView.GetStringFieldValue(row, "keywords")), DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day, "weekly" });

                //    writer.WriteStartElement("url");
                //    writer.WriteElementString("loc", _bv.serverUrl() + "/" + "tags/" + BaseView.GetStringFieldValue(row, "id") + "-" + convertStringLinks(BaseView.GetStringFieldValue(row, "keywords")));
                //    writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
                //    writer.WriteElementString("changefreq", "daily");
                //    writer.WriteElementString("priority", "1.00");
                //    writer.WriteEndElement();
                //}
                DataTable dt = _db.get_all_news_actived(true);
                foreach (DataRow r in dt.Rows)
                {
                    DateTime datePost = BaseView.GetDateTimeFieldValue(r, "ngaydang");

                    //tableSiteMap.Rows.Add(new object[] { "http://thammydiamond.com/" + r["url"].ToString(), dateT.Year + "-" + dateT.Month + "-" + dateT.Day, "weekly" });

                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", _bv.serverUrl() + "/" + r["url"].ToString());
                    writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", datePost));
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", "1.00");
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.Flush();

            }
       
    }
    private string convertStringLinks(string s)
    {
        return BaseView.repalce_UrlFriendly(BaseView.convertToUnSign2(s)).ToLower();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        UpdateXml();
        lbAdd.Text = "Cập nhật thành công!";
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_SingleInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            getDetails();
        }
    }
    private void getDetails()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
           
            DBClass _db = new DBClass();
            string url = Request.QueryString["id"] + ".html";
            DiamondProcessCode _dm = new DiamondProcessCode();
            DataRow info = _dm.GetSinglePost(null,url,null, true);
            //int countKey = 0;
            if (info == null)
            {
                info = _db.Get_URL_Pages(url);
            }
            if (info != null)
            {
                ltTitle.Text = BaseView.GetStringFieldValue(info, "tieude");
                ltDesc.Text = BaseView.GetStringFieldValue(info, "tomtat");
                string noidung = BaseView.GetStringFieldValue(info, "noidung");
                ltContent.Text = noidung;

                Page.Title = BaseView.GetStringFieldValue(info, "title");
                Page.MetaDescription = BaseView.GetStringFieldValue(info, "description");
                Page.MetaKeywords = BaseView.GetStringFieldValue(info, "keywords");

                string[] keywords = BaseView.GetStringFieldValue(info, "keywords").Split(',');
                string tags = "";
                for (int i = 0; i < keywords.Length - 1; i++)
                {
                    string[] ids = keywords[i].Split('-');
                    int idKey = ToSQL.SQLToInt(ids[ids.Length - 1]);
                    DataRow row = _db.get_info_words(idKey);
                    if (row != null)
                    {
                        tags += "<a class='f-tag b-tag' itemprop='keywords' href='../tags/" + BaseView.GetStringFieldValue(row, "id") + "-" + BaseView.convertStringLinks(BaseView.GetStringFieldValue(row, "keywords")) + "'>" + BaseView.GetStringFieldValue(row, "keywords") + "</a>";
                    }

                }
                //btnSua.PostBackUrl = "~/admin-us/sua-bai/default.aspx?id=" + BaseView.GetStringFieldValue(r, "id");
                lbTags.Text = tags;

            }
        }
    }

}
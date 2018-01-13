using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_tk_sua_bai_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getInfoNews();
        }
    }
    DBClass _db = new DBClass();
    private void getInfoNews()
    {

        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            int id = ToSQL.SQLToInt(Request.QueryString["id"]);
            DataRow row = _db.Get_Info_News(id);
            if (row != null)
            {

                lbLinks.Text = BaseView.GetStringFieldValue(row, "url");
                txtContent.Text = BaseView.GetStringFieldValue(row, "noidung");
                btnHuy.PostBackUrl = "~/" + BaseView.GetStringFieldValue(row, "url");
                string[] keywords = BaseView.GetStringFieldValue(row, "keywords").Split(',');
                string tags = "";
                for (int i = 0; i < keywords.Length - 1; i++)
                {
                    string[] ids = keywords[i].Split('-');
                    int idKey = ToSQL.SQLToInt(ids[ids.Length - 1]);
                    DataRow rowK = _db.get_info_words(idKey);
                    if (row != null)
                    {
                        tags += BaseView.GetStringFieldValue(rowK, "keywords") + ", ";
                    }

                }


            }
        }
    }
    private string urlCode()
    {
        string url = "";
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            int id = ToSQL.SQLToInt(Request.QueryString["id"]);
            DataRow row = _db.Get_Info_News(id);
            if (row != null)
            {

                url = BaseView.GetStringFieldValue(row, "url");
            }
        }
        return url;
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {


        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {

            int autoId = ToSQL.SQLToInt(Request.QueryString["id"]);

            string content = txtContent.Text;

            DataRow row = _db.Get_Info_News(autoId);
            string _title, _desc, _keywords, _tieude, _tomtat, _maloai, _hinhanh, _url;
            int _iSeo = 0;
            if (row != null)
            {
                _title = BaseView.GetStringFieldValue(row, "title");
                _desc = BaseView.GetStringFieldValue(row, "desc");
                _tieude = BaseView.GetStringFieldValue(row, "tieude");
                _tomtat = BaseView.GetStringFieldValue(row, "tomtat");
                _maloai = BaseView.GetStringFieldValue(row, "maloai");
                _keywords = BaseView.GetStringFieldValue(row, "keywords");
                _hinhanh = BaseView.GetStringFieldValue(row, "HinhAnh");
                _url = BaseView.GetStringFieldValue(row, "url");

                if (BaseView.GetStringFieldValue(row, "tinh") == "1")
                    _iSeo = 1;
                _db.OnInsert_Update_Delete_News(autoId, "", _title, _desc, _keywords, BaseView.replaceLinkHtml(_tieude), DateTime.Now, _tomtat, content, false, _hinhanh, ToSQL.SQLToInt(_maloai), _url, "", "", 1, _iSeo, "admin", null, "", "", "update");
                Response.Redirect("~/" + urlCode());
            }
        }

    }

}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Share_medical_layout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getCurrentPage();
            getBaiMoi();
            ltCanonical.Text = "<link rel='canonical' href='" + "http://" + Request.Url.Host + HttpContext.Current.Request.RawUrl + "' />";
        }
    }
    private void getCurrentPage()
    {
        string html = "<meta name='DC.Publisher' content='Y Khoa VN' />";
        html += "<meta name='DC.Title' content='" + Page.Title + "' />";
        html += "<meta name='DC.Description' content='" + Page.MetaDescription + "' />";
        html += "<meta property='og:type' content='website' />";
        html += "<meta property='og:locale' content='vi_VN' />";
        html += "<meta property='og:title' content='" + Page.Title + "' />";
        html += "<meta property='og:description' content='" + Page.MetaDescription + "' /> ";
        ltHeader.Text = html;
    }
    private void getBaiMoi()
    {
        DBClass _db = new DBClass();
        string html = "";
        string sqlCMD = "select top 3 * from news order by id desc";
        DataTable dt = _db.sqlGetData(sqlCMD);
        foreach (DataRow row in dt.Rows)
        {
            string hinh = "../uploadFile/postImages/" + BaseView.GetStringFieldValue(row, "HinhAnh");


            html += "<div class='item-bai-moi2' style='border-bottom: 1px dashed rgba(243, 243, 243, 0.13)'>";
            html += "<div class='img-c'>";
            html += "<a '../" + BaseView.GetStringFieldValue(row, "id_tt") + "' title=' " + BaseView.GetStringFieldValue(row, "TieuDe") + "'>";
            html += "<img src='" + hinh + "' alt='" + BaseView.GetStringFieldValue(row, "TieuDe") + "' height='70px' width='70px' /></a></div>";
            html += "<div class='table-c'>";
            string tieude = BaseView.GetStringFieldValue(row, "TieuDe");
            if (tieude.Length > 50)
                tieude = tieude.Substring(0, 50) + " ...";
            html += "<h3><a href='../" + BaseView.GetStringFieldValue(row, "id_tt") + "' title=' " + BaseView.GetStringFieldValue(row, "TieuDe") + "'>" + tieude + "</a></h3></div>";
            html += "<div class='clear'></div></div>";
        }
        html += "";
        //lbBaiVietMoi.Text = html;
    }
}

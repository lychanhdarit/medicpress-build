using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Share_medical_latestNewsHome : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getBaiMoi();
            //getDataHome();
        }
    }
    private void getBaiMoi()
    {
        DBClass _db = new DBClass();
        string sqlCMD = "select top 4 * from news where isActived = 1 order by id desc ";
        DataTable dt = _db.sqlGetData(sqlCMD);
        rplastNews.DataSource = dt;
        rplastNews.DataBind();
    }
    
    private void getDataHome()
    {
        DBClass _db = new DBClass();
        string[] catArr = { "dich-vu","Kham-phu-khoa", "Benh-ly-phu-khoa", "Viem-phu-khoa" };
        string html = "";
        for (int i = 0; i < catArr.Length - 1; i++)
        {
            string urlServer = BaseView.UrlServer();
            DataRow infoCat = _db.get_info_loai_code(catArr[i]);
            int maloai = BaseView.GetIntFieldValue(infoCat, "id");
            string nameloai = BaseView.GetStringFieldValue(infoCat, "name");
            string urlCat = urlServer + "/" + BaseView.GetStringFieldValue(infoCat, "code") + ".hxml";
            string sqlCMD = "select top 4 * from news where (maloai = " + maloai + " or maloai in (select id from LoaiTin where isPatient = " + maloai + " and  isActived = 1)) and isActived = 1 order by id desc";
            DataTable dt = _db.sqlGetData(sqlCMD);
            
            if (dt.Rows.Count > 0)
            {
                // Get Title Category
                html += "<div class='title-block'> ";
                html += "<h2 class='title-home'><a href='"+urlCat+"' >" + nameloai + "</a></h2>";
                html += "<div class='clearfix'></div>";
                html += "</div> ";
                html += "<div class='divider'><span></span></div>";
                html += "<div class='row'> ";
                foreach (DataRow row in dt.Rows)
                {
                    string url = BaseView.GetStringFieldValue(row, "id_tt");
                    string title = BaseView.GetStringFieldValue(row, "tieude");
                    string Desc = BaseView.GetStringFieldValue(row, "Desc");
                    string HinhAnh = BaseView.GetStringFieldValue(row, "HinhAnh");
                    html += "<article class='large-3 columns' style='overflow:hidden'>";
                    html += "<div class='post_img'>";
                    html += "<a href='" + urlServer + "/" + url + "'><img src='" + urlServer + "/UploadFile/postImages/" + HinhAnh + "' alt='" + title + "'/></a>";
                    
                    html += "</div> ";
                    html += "<div style='width: 115px;overflow:hidden'><div style='margin-top:10px;' class='fb-like' data-href='" + url + "' data-layout='standard' data-action='like' data-show-faces='true' data-share='true'></div></div>";
                    html += "<div class='mod_con_text'>";
                    html += "<h3> <a href='" + urlServer + "/" + url + "'>" + title + "</a> </h3>";
                    html += "<div class='divline'><span></span></div>";
                    Desc = Desc.Length > 50 ? Desc.ToString().Substring(0, 50) : Desc;
                  
                    html += "</div> ";
                    
                    html += "</article>";
                }
                html += "</div> ";
            }
        }

        ltCatNews.Text = html;

    }

}
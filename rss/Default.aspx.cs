using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rss_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //DataTable dt = _db.Get_All_LoaiTin();
            //lvItem.DataSource = dt;
            //lvItem.DataBind();
            getRSS();
        }
    }
    private void getRSS()
    {
        string html = "<ul>";

        DataTable rSecond = _db.Get_All_LoaiTin();
        if (rSecond.Rows.Count > 0)
        {
            foreach (DataRow rS in rSecond.Rows)
            {
                if (BaseView.GetStringFieldValue(rS, "isNews") == "True")
                {
                    // html += "<li><a href='../" + BaseView.GetStringFieldValue(rS, "code") + ".ws'>" + BaseView.GetStringFieldValue(rS, "name") + "</a></li>";
                    html += "<li><a href='../rss/index.aspx?code=" + BaseView.GetStringFieldValue(rS, "code") + "'>" + BaseView.GetStringFieldValue(rS, "name") + "</a></li>";
                }
            }
            html += "</ul>";
            lbRSS.Text = html;
        }
    }
}
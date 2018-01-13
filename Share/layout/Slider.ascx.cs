using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Share_layout_Slider : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            getSlider();
    }
    public void getSlider()
    {
        DBClass _db = new DBClass();
        string html = "";
        DataTable dtSlider = _db.get_all_slider(true);
        html += " <div class='slider-wrapper' style='border-bottom:1px solid #D5A82B;'><div class='slider' id='slider'>";
        foreach (DataRow row in dtSlider.Rows)
        {
            html += "<div class='ls-slide' data-ls='transition2d:9;slidedelay:7000;'>";
            html += "<img src='/UploadFile/slider/" + BaseView.GetStringFieldValue(row, "filename") + "' alt='" + BaseView.GetStringFieldValue(row, "name") + "' class='ls-bg' />";
            html += "<div class='intro ls-l'  style='left: 85%; top: 80%;'>";
            html += "<span class='icon fa fa-heart'></span>";
            //html += "<h2>.</h2>";
            //html += "<p>...</p>";
            html += "<div class='buttons'>";
            html += "<a href='../" + BaseView.GetStringFieldValue(row, "url") + "' class='prev' style='background: #434645;border-color:#434645;'><i class='fa fa-angle-left'></i></a>";
            if (BaseView.GetStringFieldValue(row, "url").IndexOf("http://") > -1)
            {
                html += "<a href='" + BaseView.GetStringFieldValue(row, "url") + "' class='button'>Xem thêm</a><a href='#' class='next' style='background: #434645;border-color:#434645;'><i class='fa fa-angle-right'></i></a>";
            }
            else
                html += "<a href='../" + BaseView.GetStringFieldValue(row, "url") + "' class='button'>Xem thêm</a><a href='#' class='next' style='background: #434645;border-color:#434645;'><i class='fa fa-angle-right'></i></a>";
            html += "</div>";
            html += "</div></div>";

        }
        html += "</div></div>";

        lbSlider.Text = html;

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class peter_hung_SliderController : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            getSliderFull();
    }

    public void getSliderFull()
    {
        string html = "", htmlControl = "", htmlContentSlider = "";
        DBClass _db = new DBClass();
        DataTable dtSlider = _db.get_all_slider(true);
        
        //End
        int i = 0;
        foreach (DataRow row in dtSlider.Rows)
        {
            string urlImages = "UploadFile/slider/" + BaseView.GetStringFieldValue(row, "filename");
            string TitleSlider = BaseView.GetStringFieldValue(row, "name");
            string urlTo = BaseView.GetStringFieldValue(row, "url");
            if (urlTo.IndexOf("http://") < 0 && urlTo.IndexOf("https://") < 0)
            {
                urlTo = "../" + urlTo;
            }
            string active = "";
            if (i == 0)
                active = "active";

            htmlControl += "<li data-target='#carouselExampleIndicators' data-slide-to='" + i + "' class='" + active + "'></li>";

            htmlContentSlider += "<div class='carousel-item " + active + "' style='background-image: url(" + urlImages + "); background-size: cover'>";
            htmlContentSlider += "<a href='/' class='view'><div class='carousel-caption d-none d-md-block'>";
            //htmlContentSlider += "<h3>" + TitleSlider + "</h3>";
            //htmlContentSlider += "<p></p>";
            htmlContentSlider += "</div><a/>";
            htmlContentSlider += "</div>";

            i++;

        }

        html += "<ol class='carousel-indicators'>";
        html += htmlControl;
        html += "</ol>";
        html += "<div class='carousel-inner' role='listbox'>";
        html += htmlContentSlider;
        html += " </div>";


        ltSlider.Text = html;

    }
}


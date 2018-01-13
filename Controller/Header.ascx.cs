using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
          
            getCurrentPage();
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
        html += "<meta name='twitter:card' content='summary' />";
        html += "<meta name='twitter:site' content='@nytimesbits' />";
        html += "<meta name='twitter:creator' content='@nickbilton' />";


        //html += "<meta property='og:image' content='' />";
        ltHeader.Text = html;
    }
}
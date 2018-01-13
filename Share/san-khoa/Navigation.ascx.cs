using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Share_san_khoa_Navigation : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            //getMenuFullPage();
            getMenuSimple();
    }
    private void getMenuSimple()
    {
        DBClass _db = new DBClass();

        int idParent = 0;
        DataTable dt = _db.get_menu(idParent);
        string url = "", name = "";
        string currentURL = HttpContext.Current.Request.RawUrl.ToLower().Trim();
        string html = "";
        html += "<li class='dropdown'><a class='dropdown-toggle'  href='/' > <i class='fa fa-home' ></i> Trang chủ </a></li>";
        foreach (DataRow row in dt.Rows)
        {
            url = BaseView.GetStringFieldValue(row, "url");
            name = BaseView.GetStringFieldValue(row, "name");
            string cssClass = "", datadata_toggle = " data-toggle='dropdown'";
            cssClass = currentURL.IndexOf(url) > -1 ? "active" : "";
            // begin - get sub 1 menu
            idParent = BaseView.GetIntFieldValue(row, "id");
            DataTable dt2 = _db.get_menu(idParent);//get sub 1 menu
            if (dt2.Rows.Count == 0)
            {
                datadata_toggle = "";
               
            }

            html += "<li class='dropdown'><a class='dropdown-toggle' " + datadata_toggle + " href='../" + url+ "' title='" + name + "'>" + name + "</a>";

           

            if (dt2.Rows.Count > 0)
            {
                html += "<ul class='dropdown-menu'>";
                foreach (DataRow row2 in dt2.Rows)
                {
                    
                    url = BaseView.GetStringFieldValue(row2, "url");
                    name = BaseView.GetStringFieldValue(row2, "name");
                    idParent = BaseView.GetIntFieldValue(row2, "id");
                    cssClass = currentURL.IndexOf(url) > -1 ? "active" : "";
                    int sizeCol = (100 / dt2.Rows.Count) - 1;
                   

                    DataTable dt3 = _db.get_menu(idParent);
                    if (dt3.Rows.Count > 0)
                    {
                        string sub = "<i class='fa fa-angle-right pull-right'></i>";

                        html += "<li class='dropdown-submenu'><a href='../" + url + "'  title='" + name + "'> <strong>  " + name + " "+sub+"</strong> </a>";

                        html += "<ul class='dropdown-menu'>";
                        foreach (DataRow row3 in dt3.Rows)
                        {
                            url = BaseView.GetStringFieldValue(row3, "url");
                            name = BaseView.GetStringFieldValue(row3, "name");
                            idParent = BaseView.GetIntFieldValue(row3, "id");
                            html += "<li><a href='../" + url + "' title='" + name + "'> <i class='fa fa-check-square-o' aria-hidden='true'></i> " + name + "</a></li>";
                        }

                        html += "</ul>";
                    }
                    else
                        html += "<li ><a href='../" + url + "'  title='" + name + "'> <strong>  " + name + "</strong> </a>";

                    html += "</li>";


                }
                html += "</ul>";
               

            }
            html += "</li>";

        }

        ltNavigation.Text = html;

    }

    private void getMenuFullPage()
    {
        DBClass _db = new DBClass();

        int idParent = 0;
        DataTable dt = _db.get_menu(idParent);
        string url = "", name = "";
        string currentURL = HttpContext.Current.Request.RawUrl.ToLower().Trim();
        string html = "";
        html += "<li class='dropdown'><a class='dropdown-toggle'  href='/' > <i class='fa fa-home' ></i> Trang chủ </a></li>";
        foreach (DataRow row in dt.Rows)
        {
            url = BaseView.GetStringFieldValue(row, "url");
            name = BaseView.GetStringFieldValue(row, "name");
            string cssClass = "", datadata_toggle = " data-toggle='dropdown'", megamenu = "mega-menu-item";
            cssClass = currentURL.IndexOf(url) > -1 ? "active" : "";
            // begin - get sub 1 menu
            idParent = BaseView.GetIntFieldValue(row, "id");
            DataTable dt2 = _db.get_menu(idParent);//get sub 1 menu
            if (dt2.Rows.Count == 0)
            {
                datadata_toggle = "";
                megamenu = "";
            }

            html += "<li class='dropdown " + cssClass + " " + megamenu + "'><a class='dropdown-toggle' " + datadata_toggle + " href='../" + url + "' title='" + name + "'>" + name + "</a>";



            if (dt2.Rows.Count > 0)
            {
                html += "<div class='mega-menu dropdown-menu'>";
                if (dt2.Rows.Count <= 3)
                    html += "<img src='../Share/san-khoa/images/mega-menu-img.jpg' class='img-rounded' alt='' title='' />";
                foreach (DataRow row2 in dt2.Rows)
                {
                    html += "<ul>";
                    url = BaseView.GetStringFieldValue(row2, "url");
                    name = BaseView.GetStringFieldValue(row2, "name");
                    idParent = BaseView.GetIntFieldValue(row2, "id");
                    cssClass = currentURL.IndexOf(url) > -1 ? "active" : "";
                    int sizeCol = (100 / dt2.Rows.Count) - 1;
                    html += "<li ><a href='../" + url + "'  title='" + name + "' class='title-a'> <strong><i class='fa fa-heart' aria-hidden='true'></i> " + name + "</strong></a></li>";

                    DataTable dt3 = _db.get_menu(idParent);
                    if (dt3.Rows.Count > 0)
                    {

                        foreach (DataRow row3 in dt3.Rows)
                        {
                            url = BaseView.GetStringFieldValue(row3, "url");
                            name = BaseView.GetStringFieldValue(row3, "name");
                            idParent = BaseView.GetIntFieldValue(row3, "id");
                            html += "<li><a href='../" + url + "' title='" + name + "'> <i class='fa fa-check-square-o' aria-hidden='true'></i> " + name + "</a></li>";
                        }


                    }


                    html += "</ul>";

                }

                html += "</div>";

            }
            html += "</li>";

        }

        ltNavigation.Text = html;

    }

}
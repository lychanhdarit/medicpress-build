using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class peter_hung_MenuController : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            menu_new_custom();
        }
    }
    #region Menu

    private void menu_new_custom()
    {
        DBClass _db = new DBClass();
        string html = "";
        //html += "<li class='nav-item'><a class='nav-link' href='../gioi-thieu.html'><i class='fa b-menu-1level-ico' data-name=''></i>Giới thiệu </a>";
        DataTable dt = _db.get_menu(0);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow r in dt.Rows)
            {
                int styleShow = BaseView.GetIntFieldValue(r, "styleShow");
                //if (styleShow == 1)
                //{
                //   html += styleDefaultColunm(r);
                //}
                //else
                //{
                //html += styleDefault(r);
                html += styleBoxDefault(r);
                //}
            }
            ltMenu.Text = html;
        }

    }

    private string styleDefault(DataRow r)
    {

        DBClass _db = new DBClass();
        string html = "", htmlNews = "";
        int idDanhMuc = BaseView.GetIntFieldValue(r, "id");
        string linkURL = BaseView.GetStringFieldValue(r, "url");
        // html += "<li class='b-top-nav__1level f-top-nav__1level f-primary-b b-top-nav-big'><a href='../" + linkURL + "' class='menu-link main-menu-link'><i class='fa b-menu-1level-ico' data-name=''></i>" + BaseView.GetStringFieldValue(r, "name") + " <span class='b-ico-dropdown'><i class='fa fa-arrow-circle-down'></i></span></a>";

        string idMenu = BaseView.GetStringFieldValue(r, "id");
        html += "<li class='nav-item dropdown'><a class='nav-link dropdown-toggle' data-toggle='dropdown' id='navbarDropdownPortfolio" + idMenu + "' aria-haspopup='true' aria-expanded='false'>" + BaseView.GetStringFieldValue(r, "name") + " </a>";
        DataTable dt1 = _db.get_menu(idDanhMuc);
        if (dt1.Rows.Count > 0)
        {
            html += "<div class='dropdown-menu dropdown-menu-right' aria-labelledby='navbarDropdownPortfolio" + idMenu + "' >";
            html += "<div class=' container row'style ='margin: auto; margin-top: -7px;    border: 0px solid #f9f2df'  > ";

            html += "<div class='col-md-3 firstMenu' >";
            int index = 0;
            foreach (DataRow row in dt1.Rows)
            {
                idDanhMuc = BaseView.GetIntFieldValue(row, "id");
                DataTable dt2 = _db.get_menu(idDanhMuc);
                int rowCount = dt1.Rows.Count;
                int percent = 100 / rowCount;
                if (percent > 40)
                    percent = 35;
                html += "<a class='dropdown-item' href='../" + BaseView.GetStringFieldValue(row, "url") + "'>" + BaseView.GetStringFieldValue(row, "name") + " <i class='fa fa-angle-right' style='float:right'></i></a>";


            }
            html += "</div>";



        }
       
        html += "</div>";
        html += "</div>";

        html += "</li>";
        return html;
    }
    private string styleBoxDefault(DataRow r)
    {

        DBClass _db = new DBClass();
        string html = "", htmlNews = "";
        int idDanhMuc = BaseView.GetIntFieldValue(r, "id");
        string linkURL = BaseView.GetStringFieldValue(r, "url");
        // html += "<li class='b-top-nav__1level f-top-nav__1level f-primary-b b-top-nav-big'><a href='../" + linkURL + "' class='menu-link main-menu-link'><i class='fa b-menu-1level-ico' data-name=''></i>" + BaseView.GetStringFieldValue(r, "name") + " <span class='b-ico-dropdown'><i class='fa fa-arrow-circle-down'></i></span></a>";

        string idMenu = BaseView.GetStringFieldValue(r, "id");
        
        DataTable dt1 = _db.get_menu(idDanhMuc);
        if (dt1.Rows.Count > 0)
        {
            html += "<li class='nav-item dropdown'><a class='nav-link dropdown-toggle' data-toggle='dropdown' id='navbarDropdownPortfolio" + idMenu + "' aria-haspopup='true' aria-expanded='false'>" + BaseView.GetStringFieldValue(r, "name") + " </a>";
            html += "<div class='dropdown-menu dropdown-menu-right' aria-labelledby='navbarDropdownPortfolio" + idMenu + "' >";
            html += "<div class=' container row'style ='margin: auto; margin-top: -7px;    border: 05px solid #f9f2df'  > ";

            html += "<div class='col-md-3 firstMenu' ><ul>";
            int index = 0;
            foreach (DataRow row in dt1.Rows)
            {
                idDanhMuc = BaseView.GetIntFieldValue(row, "id");
                DataTable dt2 = _db.get_menu(idDanhMuc);
                int rowCount = dt1.Rows.Count;
                int percent = 100 / rowCount;
                if (percent > 40)
                    percent = 35;
                html += "<li><a class='dropdown-item' href='../" + BaseView.GetStringFieldValue(row, "url") + "'>" + BaseView.GetStringFieldValue(row, "name") + " <i class='fa fa-angle-right' style='float:right'></i></a>";


                html += "<div  class='box-menu'><div  class='row'>" + getBoxPostForMenu(BaseView.GetStringFieldValue(row, "url").Replace(".hxml","")) + "</div></div>";

                html += "</li>";
            }
            html += "</ul></div>";
            htmlNews += getBoxPostForMenu(linkURL.Replace(".hxml", ""));
            html += "<div  class='col-md-9'><div  class='row'>" + htmlNews + "</div></div>";
            html += "</div>";
            html += "</div>";
            html += "</li>";

        }
        else
        {
            html += "<li class='nav-item dropdown'><a class='nav-link' href='../" + BaseView.GetStringFieldValue(r, "url") + "'>" + BaseView.GetStringFieldValue(r, "name") + " </a></li>";
        }

       
        return html;
    }
    private string getBoxPostForMenu(string linkURL)
    {
        string htmlNews = "";

        DiamondProcessCode _diamond = new DiamondProcessCode();

        DataRow infoCategory = _diamond.GetSingleCategory(null, linkURL.Replace(".hxml", ""), null);
        if (infoCategory != null)
        {
            int idCategory = BaseView.GetIntFieldValue(infoCategory, "isPatient");
            if (idCategory == 0)
            {
                idCategory = BaseView.GetIntFieldValue(infoCategory, "id");
            }
            DataTable dataNews = _diamond.GetListPost("", idCategory, null, true);
            int rowsCount = 0;
            rowsCount = dataNews.Rows.Count < 8 ? dataNews.Rows.Count : 8;
            for (int i = 0; i < rowsCount; i++)
            {
                DataRow infoNews = dataNews.Rows[i];
                htmlNews += "<div class='col-md-3' style='padding: 5px;'>";
                string hinh = BaseView.GetStringFieldValue(infoNews, "HinhAnh");
                if (hinh.IndexOf("http") == -1 && hinh.Trim() != "")
                {
                    hinh = BaseView.pathImagesPost() + hinh;
                }

                htmlNews += "<div class='practise-area'>";
                htmlNews += "<div class='thumb-top'>";
                htmlNews += "<a href='" + BaseView.GetStringFieldValue(infoNews, "id_tt") + "'>";
                htmlNews += "<img  src='" + hinh + "' alt='" + BaseView.GetStringFieldValue(infoNews, "TieuDe") + "' /></a>";
                htmlNews += "</div>";
                htmlNews += "<div class=''>";
                htmlNews += "<p class='details'>" + BaseView.GetStringFieldValue(infoNews, "TieuDe") + "</p>";
                //htmlNews += "<a href='" + BaseView.UrlServer() + "/" + BaseView.GetStringFieldValue(infoNews, "id_tt") + "'>Xem thêm <i class='fa fa-arrow-circle-right'></i></a>";
                htmlNews += "</div>";
                htmlNews += "</div>";
                htmlNews += "</div>";

            }

        }

        return htmlNews;
    }

    private string getPostForMenu(string linkURL)
    {
        string htmlNews = "";

        DiamondProcessCode _diamond = new DiamondProcessCode();

        DataRow infoCategory = _diamond.GetSingleCategory(null, linkURL.Replace(".hxml", ""), true);
        if (infoCategory != null)
        {
            int idCategory = BaseView.GetIntFieldValue(infoCategory, "isPatient");
            if (idCategory == 0)
            {
                idCategory = BaseView.GetIntFieldValue(infoCategory, "id");
            }
            DataTable dataNews = _diamond.GetListPost("", idCategory, null, true);
            int rowsCount = 0;
            rowsCount = dataNews.Rows.Count < 8 ? dataNews.Rows.Count : 8;
            for (int i = 0; i < rowsCount; i++)
            {
                DataRow infoNews = dataNews.Rows[i];
                htmlNews += "<div class='col-md-3' style='padding: 5px;'>";
                string hinh = BaseView.GetStringFieldValue(infoNews, "HinhAnh");
                if (hinh.IndexOf("http") == -1 && hinh.Trim() != "")
                {
                    hinh = BaseView.pathImagesPost() + hinh;
                }

                htmlNews += "<div class='practise-area'>";
                htmlNews += "<div class='thumb-top'>";
                htmlNews += "<a href='" + BaseView.GetStringFieldValue(infoNews, "id_tt") + "'>";
                htmlNews += "<img  src='" + hinh + "' alt='" + BaseView.GetStringFieldValue(infoNews, "TieuDe") + "' /></a>";
                htmlNews += "</div>";
                htmlNews += "<div class=''>";
                htmlNews += "<p class='details'>" + BaseView.GetStringFieldValue(infoNews, "TieuDe") + "</p>";
                //htmlNews += "<a href='" + BaseView.UrlServer() + "/" + BaseView.GetStringFieldValue(infoNews, "id_tt") + "'>Xem thêm <i class='fa fa-arrow-circle-right'></i></a>";
                htmlNews += "</div>";
                htmlNews += "</div>";
                htmlNews += "</div>";

            }

        }

        return htmlNews;
    }
    private string styleDefaultColunm(DataRow r)
    {
        DBClass _db = new DBClass();
        string html = "";
        int idDanhMuc = BaseView.GetIntFieldValue(r, "id");
        string linkURL = BaseView.GetStringFieldValue(r, "url");

        //html += "<li class='b-top-nav__1level f-top-nav__1level f-primary-b'><a href='../" + linkURL + "' title='" + BaseView.GetStringFieldValue(r, "name") + "'><i class='fa fa-home b-menu-1level-ico'></i>" + BaseView.GetStringFieldValue(r, "name") + " <span class='b-ico-dropdown'><i class='fa fa-arrow-circle-down'></i></span></a>";
        html += "<li class='b-top-nav__1level f-top-nav__1level f-primary-b'><a ><i class='fa fa-home b-menu-1level-ico'></i>" + BaseView.GetStringFieldValue(r, "name") + " <span class='b-ico-dropdown'><i class='fa fa-arrow-circle-down'></i></span></a>";
        DataTable dt1 = _db.get_menu(idDanhMuc);
        if (dt1.Rows.Count > 0)
        {
            html += "<div class='b-top-nav__dropdomn'>";
            html += "<ul class='b-top-nav__2level_wrap'>";
        }
        foreach (DataRow row in dt1.Rows)
        {
            idDanhMuc = BaseView.GetIntFieldValue(row, "id");
            DataTable dt2 = _db.get_menu(idDanhMuc);
            if (dt2.Rows.Count > 0)
            {
                html += "<li class='b-top-nav__2level f-top-nav__2level f-primary'><a href='../" + BaseView.GetStringFieldValue(row, "url") + "'  title='" + BaseView.GetStringFieldValue(row, "name") + "'><i class='fa fa-angle-right'></i>" + BaseView.GetStringFieldValue(row, "name") + " </a>";
                html += "<ul class='lv3'>";
                foreach (DataRow row2 in dt2.Rows)
                {
                    html += "<li class='b-top-nav__3level f-top-nav__3level f-primary'><a href='../" + BaseView.GetStringFieldValue(row2, "url") + "' title='" + BaseView.GetStringFieldValue(row2, "name") + "'><i class='fa fa-angle-right'></i>" + BaseView.GetStringFieldValue(row2, "name") + " </a></li>";

                }
                html += "</ul></li>";
            }
            else
            {
                html += "<li class='b-top-nav__2level f-top-nav__2level f-primary'><a href='../" + BaseView.GetStringFieldValue(row, "url") + "' title='" + BaseView.GetStringFieldValue(row, "name") + "'><i class='fa fa-angle-right'></i>" + BaseView.GetStringFieldValue(row, "name") + " </a></li>";
            }
        }
        if (dt1.Rows.Count > 0)
        {
            html += "</ul>";
            html += "</div>";
        }
        html += "</li>";
        return html;

    }

    #endregion
}
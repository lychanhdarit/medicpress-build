using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Share_medical_headerMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // getMenu();
            getMenuFullPage();
             getTagCategories();
        }
         
    }
    private void getTagCategories()
    {
        DBClass _db = new DBClass();
        string html = "<div id='cssmenu2'><ul>";
        int idParent = 0;
        DataTable dt = _db.get_menu(idParent);
        string url = "", name = "";
        string currentURL = HttpContext.Current.Request.RawUrl.ToLower().Trim();
        html += "<li ><a href='/' title='" + name + "'><i class='icon-home'></i> Trang chủ <span class='b-ico-dropdown'></span></a><li>";
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow r in dt.Rows)
            {
                url = BaseView.GetStringFieldValue(r, "url");
                name = BaseView.GetStringFieldValue(r, "name");


                idParent = BaseView.GetIntFieldValue(r, "id");
                DataTable dt1 = _db.get_menu(idParent);
                if (dt1.Rows.Count > 0)
                {
                    html += "<li class='has-sub'><a href='../" + url + "' title='" + name + "'><i class='icon-double-angle-right'></i> " + name + " <span class='b-ico-dropdown'><i class='fa fa-arrow-circle-down'></i></span></a>";
                    html += "<ul>";
                }
                else
                {
                    html += "<li ><a href='../" + url + "' title='" + name + "'><i class='icon-double-angle-right'></i> " + name + " <span class='b-ico-dropdown'></span></a>";
                }
                foreach (DataRow row in dt1.Rows)
                {
                    url = BaseView.GetStringFieldValue(row, "url");
                    name = BaseView.GetStringFieldValue(row, "name");
                    idParent = BaseView.GetIntFieldValue(row, "id");
                    DataTable dt2 = _db.get_menu(idParent);

                    if (dt2.Rows.Count > 0)
                    {
                        html += "<li class='has-sub'><a href='../" + url + "'  title='" + name + "'><i class='icon-double-angle-right'></i> " + name + " </a>";
                        html += "<ul >";
                        foreach (DataRow row2 in dt2.Rows)
                        {
                            url = BaseView.GetStringFieldValue(row2, "url");
                            name = BaseView.GetStringFieldValue(row2, "name");
                            html += "<li><a href='../" + url + "' title='" + name + "'><i class='icon-double-angle-right'></i> " + name + " </a></li>";

                        }
                        html += "</ul></li>";
                    }
                    else
                    {
                        html += "<li ><a href='../" + url + "' title='" + name + "'><i class='icon-double-angle-right'></i> " + name + " </a></li>";
                    }
                }
                if (dt1.Rows.Count > 0)
                {
                    html += "</ul>";

                }
                html += "</li>";
            }

        }
        lbTagCategories.Text = html + "</ul></div>";

    }
    private void getMenuFullPage()
    {
        DBClass _db = new DBClass();
  
        int idParent = 0;
        DataTable dt = _db.get_menu(idParent);
        string url = "", name = "";
        string currentURL = HttpContext.Current.Request.RawUrl.ToLower().Trim();
        string html = "";
       
        foreach (DataRow row in dt.Rows)
        {
            url = BaseView.GetStringFieldValue(row, "url");
            name = BaseView.GetStringFieldValue(row, "name");
            string cssClass = "";
            cssClass = currentURL.IndexOf(url) > -1 ? "active" : "";
            html += "<li class='has-dropdown'><a class='" + cssClass + "' href='../" + url.Replace("hxml","hjml") + "' title='" + name + "'><i class='icon-plus-sign-alt'></i>" + name + "</a>";

            idParent = BaseView.GetIntFieldValue(row, "id");
            DataTable dt2 = _db.get_menu(idParent);
            if (dt2.Rows.Count > 0)
            {
                html += "<div class='div-dropdown'><ul style='background:#f3f3f3'>";
               
                foreach (DataRow row2 in dt2.Rows)
                {
                    url = BaseView.GetStringFieldValue(row2, "url");
                    name = BaseView.GetStringFieldValue(row2, "name");
                    idParent = BaseView.GetIntFieldValue(row2, "id");
                    cssClass = currentURL.IndexOf(url) > -1 ? "active" : "";
                    int sizeCol = (100/dt2.Rows.Count) - 1 ;
                    html += "<li style=' width: "+sizeCol+"%;'><a class='" + cssClass + " dich-vu-nav' href='../" + url + "'  title='" + name + "'> <i class='icon-double-angle-right'></i>" + name + "</a>";

                    DataTable dt3 = _db.get_menu(idParent);
                    if (dt3.Rows.Count > 0)
                    {
                        html += "<ul>";
                        foreach (DataRow row3 in dt3.Rows)
                        {
                            url = BaseView.GetStringFieldValue(row3, "url");
                            name = BaseView.GetStringFieldValue(row3, "name");
                            idParent = BaseView.GetIntFieldValue(row3, "id");
                            html += "<li><a href='../" + url + "' title='" + name + "'> - " + name + "</a></li>";
                        }

                        html += "</ul>";
                    }

                    html += "</li>";

                }

                html += "</ul></div>";
               
            }
            html += "</li>";
           
        }
      
        lbMenu.Text = html;
      
    }
    private void getMenu()
    {
        DBClass _db = new DBClass();
        int idParent = 0;
        DataTable dt = _db.get_menu(idParent);
        string url = "", name = "";
        string currentURL = HttpContext.Current.Request.RawUrl.ToLower().Trim();
        string html = "", html2 = "<div id='cssmenu'><ul>";
        //if (currentURL == "/" || currentURL == "default.aspx")
        //    html += "<li><a href='../' class='active'>Trang Chủ</a></li>";
        //else
        //    html += "<li><a href='../'>Trang Chủ</a></li>";
        foreach (DataRow row in dt.Rows)
        {


            url = BaseView.GetStringFieldValue(row, "url");
            name = BaseView.GetStringFieldValue(row, "name");
            string cssClass = "";
            cssClass = currentURL.IndexOf(url) > -1 ? "active" : "";

            html += "<li class='has-dropdown'><a class='" + cssClass + "' href='../" + url + "' title='" + name + "'> " + name + "</a>";

            html2 += "<li class='has-sub'><a href='../" + url + "' title='" + name + "'>" + name + "</a>";

            idParent = BaseView.GetIntFieldValue(row, "id");
            DataTable dt2 = _db.get_menu(idParent);
            if (dt2.Rows.Count > 0)
            {
                html += "<ul class='dropdown'>";
                html2 += "<ul>";
                foreach (DataRow row2 in dt2.Rows)
                {


                    url = BaseView.GetStringFieldValue(row2, "url");
                    name = BaseView.GetStringFieldValue(row2, "name");
                    idParent = BaseView.GetIntFieldValue(row2, "id");
                    cssClass = currentURL.IndexOf(url) > -1 ? "active" : "";
                    html += "<li><a class='" + cssClass + "' href='../" + url + "'  title='" + name + "'> <i class='icon-double-angle-right'></i>" + name + "</a>";
                    DataTable dt3 = _db.get_menu(idParent);
                    if (dt3.Rows.Count > 0)
                    {
                        html2 += "<li ><a  href='../" + url + "'  title='" + name + "'><i class='icon-double-angle-right'></i> " + name + "</a>";
                        //html2 += "<ul>";

                        html += "<ul>";

                        foreach (DataRow row3 in dt3.Rows)
                        {
                            url = BaseView.GetStringFieldValue(row3, "url");
                            name = BaseView.GetStringFieldValue(row3, "name");
                            idParent = BaseView.GetIntFieldValue(row3, "id");
                            html += "<li><a href='../" + url + "' title='" + name + "'><i class='icon-double-angle-right'></i> " + name + "</a></li>";
                        }

                        html += "</ul>";
                        //html2 += "</ul></li>";
                        html2 += "</li>";
                    }
                    html += "</li>";

                }
                html += "</ul>";
                html2 += "</ul>";
            }
            html += "</li>";
            html2 += "</li>";
        }
        //if(currentURL == "/su-kien/su-kien.hxml")
        //     html += "<li><a href='../su-kien/su-kien.hxml' class='active'><i class='icon-plus-sign-alt'></i>Sự kiện </a></li>";
        //else
        //     html += "<li><a href='../su-kien/su-kien.hxml'><i class='icon-plus-sign-alt'></i>Sự kiện</a></li>";


        //if (currentURL == "/tro-chuyen-voi-bac-sy.hxml")
        //    html += "<li><a href='../tro-chuyen-voi-bac-sy.hxml' class='active'><i class='icon-plus-sign-alt'></i>Trò chuyện cùng bác sĩ </a></li>";
        //else
        //    html += "<li><a href='../tro-chuyen-voi-bac-sy.hxml'><i class='icon-plus-sign-alt'></i>Trò chuyện cùng bác sĩ</a></li>";

        lbMenu.Text = html;
        //lbMenu2.Text = html2 + "</ul></div>";
        //string sql2 = string.Format("select * from baiviet where BSMoiTuan=1");
        //DataTable dtsql2 = _db.sqlGetData(sql2);
        //if (dtsql2.Rows.Count > 0)
        //    lbBSMoiTuan.Text = "<a href='../tro-chuyen-voi-bac-si/tuan-moi-" + dtsql2.Rows[0]["ID"].ToString().Trim() + ".html'>Trò chuyện với bác sĩ</a>";
    }

    private string getStringSQL(int top, int id)
    {
        return "select top(" + top + ") * from menu where ParentID =" + id;
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Share_layout_Header_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getMenu();
        }
    }
      //<li class="has-dropdown"><a href="#">Features</a>
      //                              <ul class="dropdown">
      //                                  <li><a href="about.html">About page</a></li>
      //                                  <li><a href="grid.html">Grid</a></li>
      //                                  <li><a href="navigation.html">Navigation</a></li>
      //                                  <li><a href="buttons.html">Buttons</a></li>
      //                                  <li><a href="forms.html">Forms</a></li>
      //                                  <li><a href="typography.html">Typography</a></li>
      //                                  <li><a href="orbit.html">Orbit - Foundation Slider</a></li>
      //                                  <li><a href="clearing.html">Clearing -  Responsive Lightboxes</a></li>
      //                                  <li><a href="dropdown.html">Dropdown</a></li>
      //                                  <li><a href="joyride.html">Joyride</a></li>
      //                                  <li><a href="magellan.html">Magellan</a></li>
      //                                  <li><a href="reveal.html">Reveal - Modal dialogs / pop-up windows</a></li>
      //                                  <li><a href="section.html">Section - Accordion, Tabs &amp; Vertical Nav</a></li>
      //                                  <li><a href="tooltips.html">Info tooltips</a></li>
      //     </ul>
      // </li>

    private void getMenu()
    {
        DBClass _db = new DBClass();
        int idParent = 0;
        DataTable dt = _db.get_menu(idParent);
        string url = "", name = "";
        string currentURL = HttpContext.Current.Request.RawUrl.ToLower().Trim();
        string html = "", html2 = "<div id='cssmenu'><ul>";
        if (currentURL == "/" || currentURL == "default.aspx")
            html += "<li><a href='../' class='active'>Trang Chủ</a></li>";
        else
            html += "<li><a href='../'>Trang Chủ</a></li>";
        foreach (DataRow row in dt.Rows)
        {


            url = BaseView.GetStringFieldValue(row, "url");
            name = BaseView.GetStringFieldValue(row, "name");
            string cssClass = "";
            cssClass = currentURL.IndexOf(url) > -1 ? "active" : "";

            html += "<li class='has-dropdown'><a class='"+cssClass+"' href='../" + url + "' title='" + name + "'><i class='fa fa-plus'></i>" + name + "</a>";

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
                    html += "<li><a class='" + cssClass + "' href='../" + url + "'  title='" + name + "'>" + name + "</a>";
                    DataTable dt3 = _db.get_menu(idParent);
                    if (dt3.Rows.Count > 0)
                    {
                        html2 += "<li ><a  href='../" + url + "'  title='" + name + "'>" + name + "</a>";
                        //html2 += "<ul>";

                        html += "<ul>";

                        foreach (DataRow row3 in dt3.Rows)
                        {
                            url = BaseView.GetStringFieldValue(row3, "url");
                            name = BaseView.GetStringFieldValue(row3, "name");
                            idParent = BaseView.GetIntFieldValue(row3, "id");
                            html += "<li><a href='../" + url + "' title='" + name + "'>" + name + "</a></li>";
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
        //     html += "<li><a href='../su-kien/su-kien.hxml' class='active'><i class='fa fa-plus'></i>Sự kiện </a></li>";
        //else
        //     html += "<li><a href='../su-kien/su-kien.hxml'><i class='fa fa-plus'></i>Sự kiện</a></li>";


        //if (currentURL == "/tro-chuyen-voi-bac-sy.hxml")
        //    html += "<li><a href='../tro-chuyen-voi-bac-sy.hxml' class='active'><i class='fa fa-plus'></i>Trò chuyện cùng bác sĩ </a></li>";
        //else
        //    html += "<li><a href='../tro-chuyen-voi-bac-sy.hxml'><i class='fa fa-plus'></i>Trò chuyện cùng bác sĩ</a></li>";

        lbMenu.Text = html;
        lbMenu2.Text = html2 + "</ul></div>";
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
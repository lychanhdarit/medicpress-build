using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Share_medical_rightMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            getTagCategories();
    }
    private void getTagCategories()
    {
        DBClass _db = new DBClass();
        string html = "<div id='cssmenu'><ul>";
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
}
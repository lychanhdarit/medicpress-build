using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_Tags : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            getData();
        }
    }
    private DBClass _db = new DBClass();
    private void getData()
    {
        DataTable dt = _db.get_all_words();
        string html = "<ul>";
        foreach (DataRow info in dt.Rows)
        {
            string link1 = BaseView.GetStringFieldValue(info, "id") + "-" + BaseView.convertStringLinks(BaseView.GetStringFieldValue(info, "keywords"));
            string link2 = BaseView.convertStringLinks(BaseView.GetStringFieldValue(info, "keywords")) + "-" + BaseView.GetStringFieldValue(info, "id");

            html += "<li> <a href='" + settingLink(link1, 1) + "'> " + BaseView.GetStringFieldValue(info, "keywords") + "</a></li>";
        }
        html += "</ul>";

        ltHtml.Text = html;
    }
    private string settingLink(string link, int vs)
    {

        switch (vs)
        {
            case 1:
                link = "../tags/" + link;
                break;
            case 2:
                link = "../" + link + ".html";
                break;
        }
        return link;
    }
}
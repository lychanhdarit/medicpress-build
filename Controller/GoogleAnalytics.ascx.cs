using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Config_GoogleAnalytics : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string getIDanalytics()
    {
        DBClass _db = new DBClass();
        DataRow dr = _db.get_info_caidat();
        string IDanalytics = "";
        if (dr != null)
        {
            IDanalytics = BaseView.GetStringFieldValue(dr, "tieudetrangchuvideo");
        }
        return IDanalytics;
    }
}
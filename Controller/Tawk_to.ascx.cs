using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Config_Tawk_to : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string getIdTawkTo()
    {
        DBClass _db = new DBClass();
        DataRow dr = _db.get_info_caidat();
        string IdTawkTo = "";
        if (dr != null)
        {
            IdTawkTo = "https://embed.tawk.to/"+BaseView.GetStringFieldValue(dr, "tieudetrangchuraovat")+"/default";
        }
        return IdTawkTo;
    }
}
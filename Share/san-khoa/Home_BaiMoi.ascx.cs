using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Share_san_khoa_Home_BaiMoi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            getBaiMoi();
    }
    private void getBaiMoi()
    {
        DBClass _db = new DBClass();
        string sqlCMD = "select top 10 * from news where isActived = 1 order by id desc ";
        DataTable dt = _db.sqlGetData(sqlCMD);
        rpData.DataSource = dt;
        rpData.DataBind();
    }
}
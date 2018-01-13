using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class peter_hung_main_details : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            getBaiMoiFooter();
            getCatFooter();
        }

    }
    private void getCatFooter()
    {
        DBClass _db = new DBClass();
        string sqlCMD = "select top 6 * from LoaiTin order by id desc";
        DataTable dt = _db.sqlGetData(sqlCMD);
        rpCat.DataSource = dt;
        rpCat.DataBind();
    }
    private void getBaiMoiFooter()
    {
        DBClass _db = new DBClass();
        string sqlCMD = "select top 10 * from news where isActived = 1 order by id desc";
        DataTable dt = _db.sqlGetData(sqlCMD);
        rpBai.DataSource = dt;
        rpBai.DataBind();

    }
}

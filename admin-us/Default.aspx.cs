using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData(0);
            getDataPost();
            listUser();
        }
    }
    private void listUser()
    {
        DBClass _db = new DBClass();
        DataTable dt = _db.get_all_admin();
        rpUser.DataSource = dt;
        rpUser.DataBind();
    }
   
    private void getDataPost()
    {
        DBClass _db = new DBClass();
        rpDataPost.DataSource = _db.sqlGetData("Select top(7) * from News where isActived = 1 order by id desc");
        rpDataPost.DataBind();
    }
    private void getData(int index)
    {
        DBClass _db = new DBClass();
        string sqlQ = "Select top(7) * from TuVan where isDelete = 0 or isDelete is null  order by id desc";
        DataTable dt = _db.sqlGetData(sqlQ);
        grvOrder.PageIndex = index;
        grvOrder.DataSource = dt;
        grvOrder.DataBind();
    }
    protected void grvOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label ltStatus = (Label)e.Row.FindControl("ltStatus");
            if (ltStatus.Text == "1")
                ltStatus.Text = "<span class='label label-warning'>Đang chờ ...</span>";
            if (ltStatus.Text == "2")
                ltStatus.Text = "<span class='label label-info'>Đang xử lý ... </span>";
            if (ltStatus.Text == "3")
                ltStatus.Text = "<span class='label label-success'>Khách đồng ý</span>";
            if (ltStatus.Text == "4")
                ltStatus.Text = "<span class='label label-danger'>Khách hủy</span>";

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_pages_danh_muc_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataTable dt = _db.Get_All_Pages();
            getData(0, dt);

        }
    }

    private void getData(int index, DataTable dt)
    {
        grvTaskNew.PageIndex = index;

        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
    }

    protected void grvTaskNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dt = _db.Get_All_Pages();
        getData(e.NewPageIndex, dt);
    }
    protected void ddlLoai_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataTable dt = _db.Get_All_Pages();
        getData(0, dt);
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
            if (chk.Checked == true)
            {
                _db.OnInsert_Update_Delete_Pages(ToSQL.SQLToInt(chk.CssClass), "", "", "", "", "", DateTime.Now, "", "", false, "", "", "admin", "del");
            }
        }

        DataTable dt = _db.Get_All_Pages();
        getData(0, dt);
    }
    protected void grvTaskNew_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Image img = (Image)e.Row.FindControl("Image1");
            string hinh = img.ToolTip;
            //Label lbTin = (Label)e.Row.FindControl("lbLoai");
            if (hinh.IndexOf("http") == -1 && hinh.Trim() != "")
            {
                hinh = "~/uploadFile/" + hinh;
            }
            else if (hinh.Trim() == "")
            {
                hinh = "~/uploadFile/NoImg.png";
            }
            img.ImageUrl = hinh;

            //DataRow row = _db.get_info_loai(ToSQL.SQLToInt(lbTin.Text));
            //if (row != null)
            //    lbTin.Text = BaseView.GetStringFieldValue(row, "Name");
        }
    }
    protected void btnDuyet_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chk");
            if (chk.Checked == true)
            {
                _db.OnInsert_Update_Delete_News(ToSQL.SQLToInt(chk.CssClass), "", "", "", "", "", DateTime.Now, "", "", true, "", 1, "", "", "", 0, 0, "", null, "","", "actived");
            }
        }
        DataTable dt = _db.Get_All_Pages();
        getData(0, dt);
    }
   
}
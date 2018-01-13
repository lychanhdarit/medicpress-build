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
            getData();
    }

    private void getData()
    {
        DataTable dt = _db.get_all_DanhMuc();
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
    }
    protected void grDataTinh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Image img = (Image)e.Row.FindControl("Image1");
            string hinh = img.ToolTip;
           
            if (hinh.IndexOf("http") == -1 && hinh.Trim() != "")
            {
                hinh = "~/uploadFile/DanhMuc/" + hinh;
            }
            else if (hinh.Trim() == "")
            {
                hinh = "~/uploadFile/noImg.png";
            }
            img.ImageUrl = hinh;

        }
    }
    protected void grDataTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }


    protected void btnXoa_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chkChon");
            if (chk.Checked == true)
            {
                _db.OnInsert_Update_Delete_DanhMuc(ToSQL.SQLToInt(chk.CssClass), "", "", "", "", true,"",0, "del");
            }
        }

        getData();
    }
}
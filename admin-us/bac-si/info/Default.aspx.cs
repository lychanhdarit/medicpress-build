using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_rv_danh_muc_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            getData(0);
    }
    
    private void getData(int index)
    {
        string sqlCommand = "select * from Doctor";
       
        DataTable dt = _db.sqlGetData(sqlCommand);
        grvTaskNew.PageIndex = index;
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
    }
    protected void grDataTinh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvTaskNew, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Nhấn vào đây để chọn ";

            Label lbChuyenKhoa = (Label)e.Row.FindControl("lbChuyenKhoa");
            string sqlCommand = "select * from ChuyenKhoa where id =" + ToSQL.SQLToInt(lbChuyenKhoa.Text);
            DataRow row = _db.sqlGetDataRow(sqlCommand);
            if(row != null)
            {
                lbChuyenKhoa.Text = BaseView.GetStringFieldValue(row,"name");
            }
        }
    }
    protected void grDataTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvTaskNew.Rows)
        {
            if (row.RowIndex == grvTaskNew.SelectedIndex)
            {
                ////row.BackColor = ColorTransTahomar.FromHtml("#fcc075");
                row.ToolTip = string.Empty;
                int id = ToSQL.SQLToInt(grvTaskNew.SelectedValue.ToString());
                
            }
            else
            {
                ////row.BackColor = ColorTransTahomar.FromHtml("#EFFCDB");
                row.ToolTip = "Nhấn vào đây để chọn";
            }
        }
    }
   

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        //for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        //{
        //    CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chkChon");
        //    if (chk.Checked == true)
        //    {
        //        _db.OnInsert_Update_Delete_DanhMuc(ToSQL.SQLToInt(chk.CssClass), "","","","",true, "del");
        //    }
        //}

        //getData();
    }
    protected void grvTaskNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int index = e.NewPageIndex;
        getData(index);
    }
}
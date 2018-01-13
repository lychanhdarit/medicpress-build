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
            getData();
    }

    private void getData()
    {
        int autoId = ToSQL.SQLToInt(Request.QueryString["id"]);
        string sqlCommand = "select * from LichDoctor where idDoctor = " + autoId;
        DataTable dt = _db.sqlGetData(sqlCommand);
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
    }
    private void CapNhat(string cmd, int id, int idDoctor, string Thu, string sang, string chieu, string toi)
    {
        //try
        //{
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            int autoId = 0;
            string sqlCommand = "Insert Into LichDoctor(idDoctor,Thu,Sang,Chieu,Toi) ";
            sqlCommand += "values(" + idDoctor + ",N'" + Thu + "','" + sang + "','" + chieu + "','" + toi + "')";
            if (cmd == "update")
            {
                autoId = ToSQL.SQLToInt(Request.QueryString["id"]);
                sqlCommand = "update LichDoctor set idDoctor = " + idDoctor + ", Thu = N'" + Thu + "', Sang = '" + sang + "', Chieu = '" + chieu + "', Toi = '" + toi + "' where id = " + id;
            }
            _db.sqlSetData(sqlCommand);
        }
        //}
        //catch { }
    }
    protected void grDataTinh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvTaskNew, "Select$" + e.Row.RowIndex);
        //    e.Row.ToolTip = "Nhấn vào đây để chọn ";
        //}
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
    protected void btnThem_Click(object sender, EventArgs e)
    {
        //Tạo
        int autoId = ToSQL.SQLToInt(Request.QueryString["id"]);

        string sqlD = "Delete from LichDoctor where idDoctor = " + autoId;
        _db.sqlSetData(sqlD);

        CapNhat("insert", 0, autoId, "Thứ Hai", "", "", "");
        CapNhat("insert", 0, autoId, "Thứ Ba", "", "", "");
        CapNhat("insert", 0, autoId, "Thứ Tư", "", "", "");
        CapNhat("insert", 0, autoId, "Thứ Năm", "", "", "");
        CapNhat("insert", 0, autoId, "Thứ Sáu", "", "", "");
        CapNhat("insert", 0, autoId, "Thứ Bảy", "", "", "");
        CapNhat("insert", 0, autoId, "Chủ Nhật", "", "", "");
        getData();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int autoId = ToSQL.SQLToInt(Request.QueryString["id"]);
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chkId = (CheckBox)grvTaskNew.Rows[i].FindControl("chkChon");
            Label lbThu = (Label)grvTaskNew.Rows[i].FindControl("lbThu");
            int id = ToSQL.SQLToInt(chkId.CssClass);
            TextBox chkSang = (TextBox)grvTaskNew.Rows[i].FindControl("txtSang");
            TextBox chkChieu = (TextBox)grvTaskNew.Rows[i].FindControl("txtChieu");
            TextBox chkToi = (TextBox)grvTaskNew.Rows[i].FindControl("txtToi");
            CapNhat("update", id, autoId, lbThu.Text, chkSang.Text, chkChieu.Text, chkToi.Text);
        }
        getData();
    }
}
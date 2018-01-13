using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_tk_danh_muc_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int autoId = 0;
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                autoId = ToSQL.SQLToInt(Request.QueryString["id"]);
            }
            getChuyenKhoa();
            getItem(autoId);
           
        }
    }
    DBClass _db = new DBClass();
    private void getChuyenKhoa()
    {
        ddlChuyenKhoa.DataSource = _db.sqlGetData("select * from chuyenkhoa");
        ddlChuyenKhoa.DataBind();
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        try
        {
            int autoId = 0;
            string sqlCommand = "Insert Into Doctor(name,[email],[add],[phone],pass,username,hinhanh,idChuyenKhoa) ";
            sqlCommand += "values(N'" + txtTen.Text + "',N'" + txtEmail.Text + "',N'" + txtDiaChi.Text + "',N'" + txtDienThoai.Text + "',N'" + txtMatkhau.Text + "',N'" + txtUser.Text + "',N'hinhanh',"+ToSQL.SQLToInt(ddlChuyenKhoa.SelectedValue)+")";
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                autoId = ToSQL.SQLToInt(Request.QueryString["id"]);
                sqlCommand = "update Doctor set name = N'" + txtTen.Text + "', email = N'" + txtEmail.Text + "', [add] = N'" + txtDiaChi.Text + "', phone = N'" + txtDienThoai.Text + "', pass = N'" + txtMatkhau.Text + "', username = N'" + txtUser.Text + "', hinhanh = N'noImg.png', idChuyenKhoa = " + ToSQL.SQLToInt(ddlChuyenKhoa.SelectedValue) + " where id = " + autoId;

            }

            _db.sqlSetData(sqlCommand);
            Response.Redirect("~/admin-us/bac-si/info/");

        }
        catch { }
    }
    private void getItem(int id)
    {
        string sqlCommand = "select * from Doctor where id = "+id;
        DataRow r = _db.sqlGetDataRow(sqlCommand);
        if (r != null)
        {
            txtTen.Text = BaseView.GetStringFieldValue(r, "name");
            txtID.Text = BaseView.GetStringFieldValue(r, "id");
            txtEmail.Text = BaseView.GetStringFieldValue(r, "email");
            txtDiaChi.Text = BaseView.GetStringFieldValue(r, "add");
            txtDienThoai.Text = BaseView.GetStringFieldValue(r, "phone");
            txtMatkhau.Text = BaseView.GetStringFieldValue(r, "pass");
            txtUser.Text = BaseView.GetStringFieldValue(r, "username");
            ddlChuyenKhoa.SelectedValue = BaseView.GetStringFieldValue(r, "idChuyenKhoa");
        }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin-us/bac-si/info/");
    }
}
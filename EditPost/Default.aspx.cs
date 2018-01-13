using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditPost_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["adminUserName"];
        if (cookie == null)
        {
            Response.Redirect("~/admin-us/account/login.aspx");
        }
        if (!IsPostBack)
        {
            getLoaiTin();
            getInfoNews();
            
        }
    }
    DBClass _db = new DBClass();
    private void getInfoNews()
    {

        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            int id = ToSQL.SQLToInt(Request.QueryString["id"]);
            DataRow row = _db.Get_Info_News(id);
            if (row != null)
            {

                lbLinks.Text = BaseView.GetStringFieldValue(row, "id_tt");
                txtContent.Text = BaseView.GetStringFieldValue(row, "noidung");
                ltTitle.Text = BaseView.GetStringFieldValue(row, "tieude");
                Page.Title = "Sửa bài: " + BaseView.GetStringFieldValue(row, "tieude");
                ddlLoaiTin.SelectedValue = BaseView.GetStringFieldValue(row, "maloai");
                btnHuy.PostBackUrl = "~/" + BaseView.GetStringFieldValue(row, "id_tt");
                string[] keywords = BaseView.GetStringFieldValue(row, "keywords").Split(',');
                string tags = "";
                for (int i = 0; i < keywords.Length - 1; i++)
                {
                    string[] ids = keywords[i].Split('-');
                    int idKey = ToSQL.SQLToInt(ids[ids.Length - 1]);
                    DataRow rowK = _db.get_info_words(idKey);
                    if (row != null)
                    {
                        tags += BaseView.GetStringFieldValue(rowK, "keywords") + ", ";
                    }

                }


            }
        }
    }
    private string urlCode()
    {
        string url = "";
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            int id = ToSQL.SQLToInt(Request.QueryString["id"]);
            DataRow row = _db.Get_Info_News(id);
            if (row != null)
            {

                url = BaseView.GetStringFieldValue(row, "id_tt");
            }
        }
        return url;
    }
    private void getLoaiTin()
    {
        DataTable dt = _db.Get_All_LoaiTin();
        ddlLoaiTin.DataSource = dt;
        ddlLoaiTin.DataTextField = "name";
        ddlLoaiTin.DataValueField = "id";
        ddlLoaiTin.DataBind();
        ddlLoaiTin.Items.Insert(0, new ListItem("--------chọn loại tin----------", "0"));
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        int autoId = 0;
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            autoId = ToSQL.SQLToInt(Request.QueryString["id"]);
            int maloai = ToSQL.SQLToInt(ddlLoaiTin.SelectedValue);
            string content = txtContent.Text;
            string sqlQ = "update News set noidung =N'" + txtContent.Text + "', maloai =" + maloai + " where id=" + autoId;
            _db.sqlSetData(sqlQ);
            Response.Redirect("~/" + urlCode());
        }
    }
}
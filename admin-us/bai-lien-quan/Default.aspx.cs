using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_slider_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    BaseView _bv = new BaseView();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getInfoNews();
            getData(0);
            //lbService.Text = _bv.serverUrl() + "/";
        }
    }
    private void getInfoNews()
    {

        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            int id = ToSQL.SQLToInt(Request.QueryString["id"]);
            DataRow row = _db.Get_Info_News(id);
            if (row != null)
            {

                ltBaiLQ.Text = BaseView.GetStringFieldValue(row, "tieude");
            }
        }
    }
    private void getItem(int id)
    {
        string sqlItem = "select * from BaiLQ where id = "+id;
        DataRow r = _db.sqlGetDataRow(sqlItem);// Edit
        if (r != null)
        {
            txtTen.Text = BaseView.GetStringFieldValue(r, "title");
            txtID.Text = BaseView.GetStringFieldValue(r, "id");
            txtUrl.Text = BaseView.GetStringFieldValue(r, "url");
            string hinh = BaseView.GetStringFieldValue(r, "images");
            if (hinh.Trim() != "")
            {
                hinh = "~/uploadFile/ThumbLQ/" + hinh;
            }
            else if (hinh.Trim() == "")
            {
                hinh = "~/uploadFile/ThumbLQ/noImg.png";
            }

            imgBS.ImageUrl = hinh;
            btnCapNhat.Text = "Sửa";
           
        }
    }

    private string SpitLink(string link)
    {
        string[] s = link.Split('/');
        return s[s.Length - 1];
    }

    protected void grDataTinh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            for (int i = 1; i < grvData.Columns.Count - 1; i++)
            {
                e.Row.Cells[i].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvData, "Select$" + e.Row.RowIndex);
                e.Row.Cells[i].ToolTip = "Nhấn vào đây để chọn ";

            }
            Label lbHinhThuc = (Label)e.Row.FindControl("lbHinhThuc");

            System.Web.UI.WebControls.Image img = (System.Web.UI.WebControls.Image)e.Row.FindControl("Image1");
            string hinh = img.ToolTip;

            if (hinh.Trim() == "")
            {
                hinh = "~/uploadFile/ThumbLQ/noimg.png";
            }
            else
            {
                hinh = "~/UploadFile/ThumbLQ/" + hinh;
              
            }
            img.ImageUrl = hinh;
        }
    }
    protected void grDataTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvData.Rows)
        {
            if (row.RowIndex == grvData.SelectedIndex)
            {
                row.BackColor = ColorTranslator.FromHtml("#fcc075");
                row.ToolTip = string.Empty;
                int id = ToSQL.SQLToInt(grvData.SelectedValue.ToString());
                getItem(id);
                lbE.Text = "";
            }
            else
            {
                row.BackColor = ColorTranslator.FromHtml("#EFFCDB");
                row.ToolTip = "Nhấn vào đây để chọn";
            }
        }
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        try
        {
            int id = 0;
            string command = "";
            if (txtID.Text != "")
            {
                id = ToSQL.SQLToInt(txtID.Text);
                command = "update";
            }
            string idPost="";
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                idPost = Request.QueryString["id"];
            }
            ActionCall(command, id, txtTen.Text, getImage(), txtUrl.Text, idPost);
            lbE.Text = "Đã cập nhật";
            getData(0);
            clearControl();
        }
        catch { }
    }

    private void getData(int p)
    {
        string id="";
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            id = Request.QueryString["id"];
        }
        string sqlData = "select * from BaiLQ where url_Post = '"+id+"'";
        grvData.DataSource = _db.sqlGetData(sqlData);
        grvData.PageIndex = p;
        grvData.DataBind();
    }
    private void clearControl()
    {
        txtID.Text = "";
        lbE.Text = "";
        txtTen.Text = "";
        txtUrl.Text = "";
        btnCapNhat.Text = "Thêm";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        clearControl();
    }
    private int ActionCall(string cmd,int id,string title,string images, string url, string idpost)
    {
        string SqlCommand = "insert into BaiLQ(Title,Images,Url,Url_Post) values(N'"+title+"','"+images+"','"+url+"','"+idpost+"')";

        SqlCommand = cmd == "update" ? "update BaiLQ set Title = N'" + title + "', Images = '" + images + "', Url = '" + url + "', Url_Post = '" + idpost + "' where id = "+id : SqlCommand;

        SqlCommand = cmd == "del" ? "delete from BaiLQ where id = " + id : SqlCommand;

        _db.sqlSetData(SqlCommand);
        return 1; 
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvData.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvData.Rows[i].FindControl("chkChon");
            if (chk.Checked == true)
            {
                ActionCall("del", ToSQL.SQLToInt(chk.CssClass), "", "", "", "");

                clearControl();
            }
        }

        getData(0);
    }

    protected void grvTaskNew_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grvTaskNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        getData(e.NewPageIndex);
    }
    protected void ddlHinhThucTimKiem_SelectedIndexChanged(object sender, EventArgs e)
    {
        getData(0);
    }
    #region Process Images
    private void UploadFile()
    {
        HttpPostedFile files = fHinh.PostedFile;
        if (fHinh.HasFile == false && files.ContentLength > 500000)
        {
            //lbError.Text = "Ảnh không hợp lệ";
        }
        else
        {
            try
            {
                string path = Server.MapPath("~/uploadFile/ThumbLQ/" + fHinh.FileName);
                fHinh.SaveAs(path);
            }
            catch
            {
                // lbError.Text = "Trùng tên hoặc chưa chọn hình";
            }
        }
    }

    private string getImage()
    {
        string hinhAnh = SpitLink(imgBS.ImageUrl);
        if (fHinh.FileName != "")
        {
            hinhAnh = fHinh.FileName;
            UploadFile();
        }
        else if (hinhAnh == "")
            hinhAnh = "noImg.png";
        return hinhAnh;
    }
    #endregion
   
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_us_clips_Default : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData();
            getRssGroup();
            getRSSFeeds(0);
            AddControl(false);
            if (!String.IsNullOrEmpty(Request.QueryString["dm"]))
            {
                string idDanhmuc = ToSQL.SQLToInt(Request.QueryString["dm"]).ToString();
                DataRow dr = _db.sqlGetDataRow("select * from LoaiTin where id = " + idDanhmuc);
                if (dr != null)
                {
                    ltName.Text = BaseView.GetStringFieldValue(dr, "name");
                }
            }
        }
    }
    private void getRssGroup()
    {
        ddlGroup.DataSource = _db.sqlGetData("select * from RssGroups order by name desc");
        ddlGroup.DataBind();
        ddlGroup.Items.Insert(0, new ListItem("---- chọn Group ----", "0"));
    }
    private void getRSSFeeds(int idGroup)
    {
        DataTable dt = _db.sqlGetData("select * from RssFeeds order by name desc");
        if (idGroup != 0)
        {
            _db.sqlGetData("select * from RssFeeds where idgroup = "+idGroup+" order by name desc");
        }
        ddRSSFeeds.DataSource = dt;
        ddRSSFeeds.DataBind();
        ddRSSFeeds.Items.Insert(0, new ListItem("---- chọn RSS cho danh mục ----", "0"));
    }
    private void getItem(int id)
    {
        DataRow r = _db.sqlGetDataRow("select * from RSSRigisteds where id = "+id);
        if (r != null)
        {
            txtID.Text = BaseView.GetStringFieldValue(r, "id");
            try
            {
                ddRSSFeeds.SelectedValue = BaseView.GetStringFieldValue(r, "idRSS");
            }
            catch { }
            
        }
    }
    
    private string SpitLink(string link)
    {
        string[] s = link.Split('/');
        return s[s.Length - 1];
    }
    
    private void getData()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["dm"]))
        {
            string idDanhmuc = ToSQL.SQLToInt(Request.QueryString["dm"]).ToString();
            DataTable dt = _db.sqlGetData("select * from RSSRigisteds where idLoai = "+idDanhmuc+" order by id desc");
            grvTaskNew.DataSource = dt;
            grvTaskNew.DataBind();
        }
    }
    protected void grDataTinh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 1; i < grvTaskNew.Columns.Count - 1; i++)
            {
                e.Row.Cells[i].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvTaskNew, "Select$" + e.Row.RowIndex);
                e.Row.Cells[i].ToolTip = "Nhấn vào đây để chọn ";
            }

            Label lbidRss = (Label)e.Row.FindControl("lbidRss");
            DataRow dr = _db.sqlGetDataRow("select * from RssFeeds where id = " + ToSQL.SQLToInt(lbidRss.Text));
            if (dr != null)
            {
                lbidRss.Text = BaseView.GetStringFieldValue(dr, "name");
            }

            Label lbID_LoaiTin = (Label)e.Row.FindControl("lbidloai");
            dr = _db.sqlGetDataRow("select * from LoaiTin where id = " + ToSQL.SQLToInt(lbID_LoaiTin.Text));
            if (dr != null)
            {
                lbID_LoaiTin.Text = BaseView.GetStringFieldValue(dr, "name");
            }
        }
    }
    protected void grDataTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvTaskNew.Rows)
        {
            if (row.RowIndex == grvTaskNew.SelectedIndex)
            {
                row.BackColor = ColorTranslator.FromHtml("#fcc075");
                row.ToolTip = string.Empty;
                int id = ToSQL.SQLToInt(grvTaskNew.SelectedValue.ToString());
                AddControl(true);
                getItem(id);
               
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
            if (ddRSSFeeds.SelectedValue != "0")
            {
                int id = 0;
                string command = "insert";
                if (txtID.Text != "")
                {
                    id = ToSQL.SQLToInt(txtID.Text);
                    command = "update";
                }
                string idDanhmuc = "0";
                if (!String.IsNullOrEmpty(Request.QueryString["dm"]))
                {
                    idDanhmuc = ToSQL.SQLToInt(Request.QueryString["dm"]).ToString();
                    string sql = "insert into RssRigisteds(idLoai,idRSS) values( " + idDanhmuc + " , " + ddRSSFeeds.SelectedValue + ")";
                    if (command == "update")
                        sql = "update RssRigisteds set idLoai = " + idDanhmuc + " , idRSS = " + ddRSSFeeds.SelectedValue + " where id = " + id;
                    _db.sqlSetData(sql);
                    //lbE.Text = "Đã cập nhật";
                    getData();
                    AddControl(false);
                    txtID.Text = "";
                }
            }
        }
        catch { }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        AddControl(true);
        txtID.Text = "";
        
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chkChon");
            if (chk.Checked == true)
            {
                _db.sqlSetData("delete from RssRigisteds  where id = " + ToSQL.SQLToInt(chk.CssClass));
            }
        }
        getData();
    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        AddControl(false);
    }
    private void AddControl(bool q)
    {
        btnCapNhat.Visible = q;
        btnHuy.Visible = q;

        btnThem.Visible = !q;

     
        ddlGroup.Enabled = q;
        ddRSSFeeds.Enabled = q;
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        getRSSFeeds(ToSQL.SQLToInt(ddlGroup.SelectedValue));
    }
}
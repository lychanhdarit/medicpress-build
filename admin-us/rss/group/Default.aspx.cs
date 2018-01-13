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
            AddControl(false);
        }
    }
    
    private void getItem(int id)
    {
        DataRow r = _db.sqlGetDataRow("select * from RssGroups where id = " + id);
        if (r != null)
        {
            txtTen.Text = BaseView.GetStringFieldValue(r, "name");
            txtID.Text = BaseView.GetStringFieldValue(r, "id");
            txtTitle.Text = BaseView.GetStringFieldValue(r, "tagTitle");
            txtDesc.Text = BaseView.GetStringFieldValue(r, "tagDesc");
            txtContent.Text = BaseView.GetStringFieldValue(r, "tagContent");
            
        }
    }
    
    private string SpitLink(string link)
    {
        string[] s = link.Split('/');
        return s[s.Length - 1];
    }
    
    private void getData()
    {

        DataTable dt = _db.sqlGetData("select * from RssGroups order by id desc");
        grvTaskNew.DataSource = dt;
        grvTaskNew.DataBind();
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
        //try
        //{
            int id = 0;
            string command = "insert";
            if (txtID.Text != "")
            {
                id = ToSQL.SQLToInt(txtID.Text);
                command = "update";
            }
           
            _db.insert_update_RssGroups(id,txtTen.Text,txtTitle.Text,txtDesc.Text,txtContent.Text,command);
            //lbE.Text = "Đã cập nhật";
            getData();
            AddControl(false);
            txtID.Text = "";
        //}
        //catch { }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        AddControl(true);
        txtID.Text = "";
        txtTen.Text = "";
        txtTitle.Text = "";
        txtDesc.Text = "";
        txtContent.Text = "";
       
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grvTaskNew.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grvTaskNew.Rows[i].FindControl("chkChon");
            if (chk.Checked == true)
            {
               
                _db.insert_update_RssGroups(ToSQL.SQLToInt(chk.CssClass), txtTen.Text, txtTitle.Text, txtDesc.Text, txtContent.Text, "del");
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

        txtTen.Enabled = q;
        txtTitle.Enabled = q;
        txtDesc.Enabled = q;
        txtContent.Enabled = q;
        //if (q == true)
        //{
        //    txtID.Text;
        //    txt
        //}
    }
}
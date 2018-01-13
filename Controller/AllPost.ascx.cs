using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_AllPost : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {
            DBClass _db = new DBClass();

            string html = "<table> <tr ><th colspan='2' style='padding:10px;background: #3C8DBC;color:#fff'>Tổng Số Bài Trên WEB: " + _db.Get_All_News().Rows.Count + "</th></tr>";
            DataTable dt = _db.get_all_DanhMuc();
            int tongSL = 0;
            html += "<tr style='background:#3C8DBC;border:1px solid #3C8DBC;padding:10px;color:#fff'><th style='border:1px solid #3C8DBC;padding:10px'>Tên Danh Mục</th><th style='border:1px solid #3C8DBC;padding:10px'>Số Lượng</th></tr>";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    tongSL = 0;
                    DataTable tableLoai = _db.get_all_LoaiTin_idDanhMuc(BaseView.GetIntFieldValue(r, "maDanhMuc"));
                    DataTable tableDM = _db.Get_All_News_DanhMuc(BaseView.GetIntFieldValue(r, "maDanhMuc"));
                    html += "<tr style='border:1px solid #f3f3f3;padding:10px;font-weight:bold'><td style='border:1px solid #f3f3f3;padding:10px'>" + BaseView.GetStringFieldValue(r, "tenDanhMuc") + " </td><td style='border:1px solid #f3f3f3;padding:10px'>" + tableLoai.Rows.Count + " danh mục con</td></tr>";
                    if (tableLoai.Rows.Count > 0)
                    {

                        foreach (DataRow rS in tableLoai.Rows)
                        {
                            DataTable tableBai = _db.Get_All_News_IDLoai(BaseView.GetIntFieldValue(rS, "id"));
                            html += "<tr style='border:1px solid #f3f3f3;padding:10px'><td style='border:1px solid #f3f3f3;padding:10px'> →  " + BaseView.GetStringFieldValue(rS, "name") + " </td><td style='border:1px solid #f3f3f3;padding:10px'>" + tableBai.Rows.Count + "</td></tr>";
                            tongSL += tableBai.Rows.Count;
                        }
                        html += "<tr style='border:1px solid #f3f3f3;padding:10px;background:red'><td style='border:1px solid #f3f3f3;padding:10px;color:#fff;font-weight:bold'> →  Tổng số lượng: </td><td style='border:1px solid #f3f3f3;padding:10px;color:#fff;font-weight:bold'>" + tongSL + "</td></tr>";
                    }

                }
                html += "</table>";
                ltBC.Text = html;
            }
        }
    }

}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Share_layout_ShareSiderRight : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getMenuChuyenKhoa();
            getBaiMoi();
        }
    }
    private void getMenuChuyenKhoa()
    {
        DBClass _db = new DBClass();
        int i = 0;
        string html = "<dl>";
        string sql = "select * from LoaiTin where isPatient = 2169";
        DataTable dt2 = _db.sqlGetData(sql);
        if (dt2.Rows.Count > 0)
        {

            foreach (DataRow row2 in dt2.Rows)
            {
                i++;
                //html += "<li><a href='../chuyen-khoa/" + BaseView.GetStringFieldValue(row2, "code").ToLower() + ".hxml'  title='" + BaseView.GetStringFieldValue(row2, "name") + "'>" + BaseView.GetStringFieldValue(row2, "name") + "</a>";
                if (i == 1)
                    html += "<dt class='opened'><i class='fa fa-stethoscope'></i>" + BaseView.GetStringFieldValue(row2, "name") + "</dt>";
                else if (i == 2)
                    html += "<dt><i class='fa fa-heart'></i>" + BaseView.GetStringFieldValue(row2, "name") + "</dt>";
                else if (i == 5)
                    html += "<dt><i class='fa fa-smile-o'></i>" + BaseView.GetStringFieldValue(row2, "name") + "</dt>";
                else if (i == 3)
                    html += "<dt><i class='fa fa-child'></i>" + BaseView.GetStringFieldValue(row2, "name") + "</dt>";
                else if (i == 4)
                    html += "<dt><i class='fa fa-flask'></i>" + BaseView.GetStringFieldValue(row2, "name") + "</dt>";
                else if (i == 6)
                    html += "<dt><i class='fa fa-child'></i>" + BaseView.GetStringFieldValue(row2, "name") + "</dt>";
                else if (i == 7)
                    html += "<dt><i class='fa fa-stethoscope'></i>" + BaseView.GetStringFieldValue(row2, "name") + "</dt>";
                html += "<dd>" + BaseView.GetStringFieldValue(row2, "desc") + "<br /><ul>";
                DataTable dt3 = _db.get_menu_LoaiTin(BaseView.GetIntFieldValue(row2, "id"), BaseView.GetIntFieldValue(row2, "maDanhMuc"));
                if (dt3.Rows.Count > 0)
                {
                    foreach (DataRow row3 in dt3.Rows)
                    {
                        html += "<li><a href='../" + BaseView.GetStringFieldValue(row3, "code").ToLower() + ".hxml' title='" + BaseView.GetStringFieldValue(row3, "name") + "'><i class='fa fa-angle-right'></i>" + BaseView.GetStringFieldValue(row3, "name") + "</a></li>";
                    }
                }
                html += "</ul></dd>";
            }

        }
        html += "</dl>";
        lbChuyenKhoa.Text = html;
        //lbMenu.Text = html;
        //string sql2 = string.Format("select * from baiviet where BSMoiTuan=1");
        //DataTable dtsql2 = _db.sqlGetData(sql2);
        //if (dtsql2.Rows.Count > 0)
            //lbBSMoiTuan.Text = "<a href='../tro-chuyen-voi-bac-si/tuan-moi-" + dtsql2.Rows[0]["ID"].ToString().Trim() + ".html'>Trò chuyện với bác sĩ</a>";
    }
    private void getBaiMoi()
    {
        DBClass _db = new DBClass();
        string html = "";
        string sqlCMD = "select top 10 * from news order by id desc";
        DataTable dt = _db.sqlGetData(sqlCMD);
        foreach (DataRow row in dt.Rows)
        {
            string hinh = "../uploadFile/postImages/" + BaseView.GetStringFieldValue(row, "HinhAnh");


            html += "<div class='item-bai-moi'>";
            html += "<div class='img-c'>";
            html += "<a '../" + BaseView.GetStringFieldValue(row, "id_tt") + "' title=' " + BaseView.GetStringFieldValue(row, "TieuDe") + "'>";
            html += "<img src='" + hinh + "' alt='" + BaseView.GetStringFieldValue(row, "TieuDe") + "' height='70px' width='70px' /></a></div>";
            html += "<div class='table-c'><table><tr><td>";
            string tieude = BaseView.GetStringFieldValue(row, "TieuDe");
            if (tieude.Length > 75)
                tieude = tieude.Substring(0, 75) + "...";
            html += "<h3><a href='../" + BaseView.GetStringFieldValue(row, "id_tt") + "' title=' " + BaseView.GetStringFieldValue(row, "TieuDe") + "'>" + tieude + "</a></h3>";
            html += "</td> </tr>";
            /*
            html+="<tr> <td style='height: 23px'>";
            string mota = BaseView.GetStringFieldValue(row, "tomtat");
            if (mota.Length > 50)
                mota = mota.Substring(0, 50) + "...";
            html += " <h5> " + mota + "</h5>";
            html += "</td> </tr>";*/
            html += " <tr><td> " + BaseView.GetStringFieldValue(row, "ngaydang") + "</td>";
            html += "</tr>  </table></div>";
            html += "<div class='clear'></div></div>";
        }
        html += "";
        lbBaiMoi.Text = html;
    }
}

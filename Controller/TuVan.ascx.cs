using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_TuVan : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    DBClass _db = new DBClass();
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (txtCatpcha.Text.ToLower() == "thammydiamond.com")
        {
            LinkButton1.Visible = false;
            DateTime times = BaseView.getDateTimeNow();
            _db.insert_update_delete_tuvan(0, txtxSkype.Text, times.ToShortDateString() + " - " + times.ToShortTimeString(), txtEmail.Text, txtDiaChi.Text, txtDienThoai.Text, txtxSkype.Text, txtNoiDung.Text, false, 0, "", "insert");
            string body = "Họ tên: " + txtxSkype.Text + "<br/>";
            body += "Email: " + txtEmail.Text + "<br/>";
            body += "Số Điện Thoại: " + txtDienThoai.Text + "<br/>";
            body += "Địa chỉ: " + txtDiaChi.Text + "<br/>";
            body += "Nội dung: " + txtNoiDung.Text + "<br/>";
            MailDaemon.sendmail("daric.diamond@gmail.com", "Khách hàng vừa gửi yêu cầu đến từ thammyDiamond.com", body);
            Response.Redirect("~/tu-van/hoan-tat.aspx");
        }
        else
        {
            lbError.Text = "Mã xác nhận không đúng";
        }
    }
}
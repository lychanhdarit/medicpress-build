using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Share_layout_Register : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDatLich_Click(object sender, EventArgs e)
    {
        if (txtHoTen.Text.Trim() == "" || txtSoDienThoai.Text == "")
        {
            //ltError.Text = "<span style='display:block;padding:5px;border-radius:5px; border:1px solid red;'>Vui lòng điền đầy đủ thông tin!</span>";
        }
        else
        {
            DBClass _db = new DBClass();
            string pageName = "Phòng khám sản khoa", address = "", name = txtHoTen.Text, email = txtEmail.Text, phone = txtSoDienThoai.Text, content = txtLoiNhan.Text, domain = "phongkhamsankhoa.com";

            string body = htmlBody(name, email, phone, address, pageName, content, domain);

            MailDaemon.sendmail("cindythao.diamond@gmail.com", pageName, body);
            MailDaemon.sendmail("thanhthuy.diamond@gmail.com", pageName, body);
            MailDaemon.sendmail("daric.diamond@gmail.com", pageName, body);
            MailDaemon.sendmail("linhkhanh.diamond@gmail.com", pageName, body);
            Response.Redirect("~/register-success/");

        }
    }
    private string htmlBody(string name, string email, string phone, string address, string pagename, string content, string domain)
    {
        string urlLogo = "http://ykhoadiamond.com/Share/images/logo-ykhoa.png";
        string html = "";
        html += "<div style='width:100%;max-width:600px;margin:auto'>";
        html += "<div style='background:#01738D;padding:5px;border-bottom: 3px solid #777474; text-align: center;'>";
        html += "<img src='" + urlLogo + "' style='height:80px;margin:auto' />";
        html += "</div>";
        html += "<div>";
        html += "<table style='width:100%;border-collapse:collapse'>";
        html += "<tr><th colspan='2'style='padding:10px;background:#f3f3f3'>THÔNG TIN KHÁCH HÀNG - " + pagename + "</th></tr>";
        html += "<tr><td style='padding:10px;width:90px;'>Họ tên: ";
        html += "</td><td style='padding:10px;font-weight:bold'>" + name + "</td></tr>";
        html += "<tr><td style='padding:10px' >Số điện thoại: </td>";
        html += "<td style='padding:10px'>" + phone + "</td></tr>";
        html += "<tr><td style='padding:10px'>Email: </td>";
        html += "<td style='padding:10px'>" + email + "</td></tr>";
        html += "<tr><td style='padding:10px'>Địa chỉ: </td>";
        html += "<td style='padding:10px'>" + address + "</td></tr>";
        html += "<tr><td style='padding:10px' colspan='2'>Nội dung:</td></tr>";
        html += "<tr><td style='padding:10px;background:#f3f3f3 ; color: #E91E63;' colspan='2'><p> " + content + " </p></td></tr>";
        html += "</table>";
        html += "</div>";
        html += "<div style='background:#01738D; padding:10px;border-top: 3px solid #777474;'>";
        html += "<p style='color:#fff'>© 2016 " + pagename + ", All Rights Reserved. - " + domain + "</p>";
        html += "</div></div>";
        return html;
    }
}
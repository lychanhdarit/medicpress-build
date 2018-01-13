using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lien_he_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  
    

    private void sendEmail(string pageName, string body)
    {
        string path = Server.MapPath("~/UploadFile/email.txt");
        using (StreamReader sr = File.OpenText(path))
        {
            string s = String.Empty;
            while ((s = sr.ReadLine()) != null)
            {
                MailDaemon.sendmail(s, pageName, body);
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtMXN.Text == "thammydiamond.net")
        {
            DBClass _db = new DBClass();
            string pageName = "Thẩm mỹ Diamond", address = "", name = txtYourName.Text, email = "", phone = txtPhone.Text, content = txtMessage.Text, domain = "thammydiamond.net";
            string body = BaseView.htmlBody(name, email, phone, address, pageName, content, domain);
            sendEmail(pageName, body);
            Response.Redirect("~/lien-he/success.aspx?urlRequest=XBNMK");
        }
        else
        {
            ltError.Text = "<span style='display:block;padding:5px;border-radius:5px; border:1px solid red;color:red;margin:10px'>Vui lòng điền mã xác nhận!</span>";
        }
    }
}
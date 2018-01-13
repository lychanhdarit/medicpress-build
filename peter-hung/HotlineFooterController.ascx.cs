using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class peter_hung_HotlineFooterController : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGui_Click(object sender, EventArgs e)
    {
        string pageName = "Tham My Diamond", address = "", name = txtText.Text, email = "", phone = txtSDT.Text, content = txtMessage.Text, domain = "";
        sendEmail(pageName, BaseView.htmlBody(name, email, phone, address, pageName, content, domain));
        Response.Redirect("~/register-success/");
        //MailDaemon.sendmail("", "", "");
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
}
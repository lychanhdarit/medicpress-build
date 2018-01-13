using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class admin_us_danh_muc_Details : System.Web.UI.Page
{
    DBClass _db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtContent.Text = readTextFile();
        }
    }
    
    protected void btnLuuStyle_Click(object sender, EventArgs e)
    {
        writeTextFile(txtContent.Text);
        txtContent.Text = readTextFile();
        lbThongBao.Text = "Đã cập nhật!";
    }
    private int writeTextFile(string content)
    {
        try
        {
            string fullpath = Server.MapPath("~/UploadFile/Style/edit.css");
            File.WriteAllText(fullpath, String.Empty);
            TextWriter tw = new StreamWriter(fullpath, true);

            tw.WriteLine(content);
            tw.Close();
            return 1;
        }
        catch { return 0; }
    }
    private string readTextFile()
    {
        string content = "";
        string path = Server.MapPath("~/UploadFile/Style/edit.css");
        using (StreamReader sr = File.OpenText(path))
        {
            string s = String.Empty;
            while ((s = sr.ReadLine()) != null)
            {
                content += s + "\n";
            }
        }
        return content;
    }
    private int beginWrite(TextBox Content)
    {
        DBClass _db = new DBClass();
        string content = "";
        for (int i = 0; i < readLine(Content).Length; i++)
        {
            content += readLine(Content)[i] + "\n";
        }
        
        writeTextFile(content);
        //Luu Database
        return 1;
    }
    private string[] readLine(TextBox txtMulti)
    {
        string[] delimiter = { Environment.NewLine };
        return txtMulti.Text.Split(delimiter, StringSplitOptions.None);
    }
}
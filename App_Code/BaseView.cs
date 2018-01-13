using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using System.Net;
/// <summary>
/// Summary description for BaseView
/// </summary>
public class BaseView
{
    public BaseView()
    {

    }
    public static string pathImagesPost()
    {
        return "../upload/";
    }
    public static string htmlBody(string name, string email, string phone, string address, string pagename, string content, string domain)
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

    public static string ReadCookie(string name)
    {
        //Get the cookie name the user entered
        String strCookieName = name;
        HttpCookie cookie = HttpContext.Current.Request.Cookies[strCookieName];
        if (cookie == null)
        {
            return "";
        }
        else
        {
            //Write the cookie value
            String strCookieValue = cookie.Value.ToString();
            return strCookieValue;
        }
    }
    public static string getThang(DateTime datetime)
    {
        int thang = datetime.Month;
        string chthang ="";
        switch (thang)
        {
            case 1:
                chthang = "Tháng Một";
                break;
            case 2:
                chthang = "Tháng Hai";
                break;
            case 3:
                chthang = "Tháng Ba";
                break;
            case 4:
                chthang = "Tháng Tư";
                break;
            case 5:
                chthang = "Tháng Năm";
                break;
            case 6:
                chthang = "Tháng Sáu";
                break;
            case 7:
                chthang = "Tháng Bảy";
                break;
            case 8:
                chthang = "Tháng Tám";
                break;
            case 9:
                chthang = "Tháng Chín";
                break;
            case 10:
                chthang = "Tháng Mười";
                break;
            case 11:
                chthang = "Tháng Mười Một";
                break;
            case 12:
                chthang = "Tháng Mười Hai";
                break;
        }
        return chthang;
    }
    public static void PrintWebControl(Control ctrl)
    {
        PrintWebControl(ctrl, string.Empty);
    }
    public static int sotin()
    {
        DBClass _db = new DBClass();
        DataRow dr = _db.get_info_caidat();
        int i = 0;
        if (dr != null)
        {
            i = BaseView.GetIntFieldValue(dr, "SoTin");
        }
        return i;
    }

    public static int solinks()
    {
        DBClass _db = new DBClass();
        DataRow dr = _db.get_info_caidat();
        int i = 0;
        if (dr != null)
        {
            i = BaseView.GetIntFieldValue(dr, "SoLink");
        }
        return i;
    }
    public static int songay()
    {
        DBClass _db = new DBClass();
        DataRow dr = _db.get_info_caidat();
        int i = 0;
        if (dr != null)
        {
            i = BaseView.GetIntFieldValue(dr, "SoNgay");
        }
        return i;
    }
    public static bool CheckImg(string url)
    {
        try
        {
            //Creating the HttpWebRequest
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //Setting the Request method HEAD, you can also use GET too.
            request.Method = "HEAD";
            //Getting the Web Response.
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //Returns TURE if the Status code == 200
            return (response.StatusCode == HttpStatusCode.OK);
        }
        catch
        {
            //Any exception will returns false.
            return false;
        }
    }
    public static bool KiemTraImages(string url)
    {
        //bool result = false;
        //using (WebClient client = new WebClient())
        //{
        //    try
        //    {
        //        Stream stream = client.OpenRead(url);
        //        if (stream != null)
        //        {
        //            result = true;
        //        }
        //        else
        //        {
        //            result = false;
        //        }
        //    }
        //    catch
        //    {
        //        //Any exception will returns false.
        //        result = false;
        //    }
        //}
        //return result;
        return true;
    }
    //public static string serverUrl = "http://192.168.1.15"; //"http://lamdep123.org";
    public string serverUrl()
    {
        DBClass _db = new DBClass();
        DataRow row = _db.get_info_url();
        if (row != null)
        {
            return BaseView.GetStringFieldValue(row, "links");
        }
        return "";
    }
    public static string UrlServer()
    {
        DBClass _db = new DBClass();
        DataRow row = _db.get_info_url();
        if (row != null)
        {
            return BaseView.GetStringFieldValue(row, "links");
        }
        return "";
    }
    public static DateTime getDateTimeNow()
    {
        DateTime thisTime = DateTime.Now;
        string timeString = "";
        TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);
        if (tst.IsDaylightSavingTime(tstTime))
        {
            timeString = tst.DaylightName;
        }
        else
            timeString = tst.StandardName;

        return tstTime;
    }
    public static string repalce_UrlFriendly(string s)
    {
        s = s.Replace("/", "-");
        s = s.Replace("'", "-");
        s = s.Replace(" ", "-");
        s = s.Replace(@"\", "-");
        s = s.Replace("?", "-");
        s = s.Replace(".", "-");
        s = s.Replace("^", "-");
        s = s.Replace("_", "-");
        s = s.Replace("~", "-");
        s = s.Replace("&", "-");
        s = s.Replace("*", "-");
        s = s.Replace("@", "-");
        s = s.Replace("!", "-");
        s = s.Replace("%", "-");
        s = s.Replace("#", "-");
        s = s.Replace("+", "-");
        s = s.Replace("`", "-");
        s = s.Replace("|", "-");
        s = s.Replace(",", "-");
        s = s.Replace("<", "-");
        s = s.Replace(">", "-");
        s = s.Replace("=", "-");
        s = s.Replace("'", "-");
        s = s.Replace(";", "-");
        s = s.Replace(":", "-");
        s = s.Replace("---", "-");
        s = s.Replace("--", "-");
        s = s.Replace("[", "");
        s = s.Replace("]", "");
        return s;
    }
    public static string convertToUnSign2(string s)
    {
        string stFormD = s.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();
        for (int ich = 0; ich < stFormD.Length; ich++)
        {
            System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
            if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                sb.Append(stFormD[ich]);
            }
        }
        sb = sb.Replace('Đ', 'D');
        sb = sb.Replace('đ', 'd');
        return (sb.ToString().Normalize(NormalizationForm.FormD));
    }
    public static string convertStringLinks(string s)
    {
        s = BaseView.convertToUnSign2(s);
        s = BaseView.repalce_UrlFriendly(s);
        return (s.ToLower());
    }
    //public static string replaceLinkHtml(string data)
    //{
    //    return data.Replace("<a", "< aa");
    //}
    public static string RemoveLinks(string htmlString)
    {
        return Regex.Replace(htmlString, "</?(a|A).*?>", "");
    }
    //public static string RemoveHtmlTagsUsingRegex(string htmlString)
    //{
    //    var result = Regex.Replace(htmlString, "<.*?>", string.Empty);
    //    return result;
    //}
    public static string RemoveKiTuDacBietVaKhoangTrang(string htmlString)
    {
        htmlString = htmlString.Replace(" ", "-");
        return Regex.Replace(htmlString, "[^a-zA-Z0-9]", "-");
    }

    public static string replaceLinkHtml(string data)
    {
        return data.Replace("<a", "< aa");
    }
    public static string RemoveHtmlTagsUsingRegex(string htmlString)
    {
        var result = Regex.Replace(htmlString, "<.*?>", string.Empty);
        return result;
    }
    static readonly Regex HtmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

    public static string RemoveHtmlTagsUsingCompiledRegex(string htmlString)
    {
        var result = HtmlRegex.Replace(htmlString, string.Empty);
        return result;
    }
    public static string RemoveHtmlTagsUsingCharArray(string htmlString)
    {
        var array = new char[htmlString.Length];
        var arrayIndex = 0;
        var inside = false;

        foreach (var @let in htmlString)
        {
            if (let == '<')
            {
                inside = true;
                continue;
            }
            if (let == '>')
            {
                inside = false;
                continue;
            }
            if (inside) continue;
            array[arrayIndex] = let;
            arrayIndex++;
        }
        return new string(array, 0, arrayIndex);
    }
    public static byte[] encryptData(string data)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashedBytes;
        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
        hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
        return hashedBytes;
    }
    public static string md5(string data)
    {
        return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
    }
    public static void PrintWebControl(Control ctrl, string Script)
    {
        StringWriter stringWrite = new StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        if (ctrl is WebControl)
        {
            Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;
        }
        Page pg = new Page();
        pg.EnableEventValidation = false;
        if (Script != string.Empty)
        {
            pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
        }
        HtmlForm frm = new HtmlForm();
        pg.Controls.Add(frm);
        frm.Attributes.Add("runat", "server");
        frm.Controls.Add(ctrl);
        pg.DesignerInitialize();
        pg.RenderControl(htmlWrite);
        string strHTML = stringWrite.ToString();
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write(strHTML);
        HttpContext.Current.Response.Write("<script>window.print();</script>");
        HttpContext.Current.Response.End();
    }
    public static void SelectedTreeView(TreeView tree, int parentnodeindex, int nodeindex = -1)
    {
        tree.Nodes[parentnodeindex].Expand();
        if (nodeindex != -1)
        {
            tree.Nodes[parentnodeindex].ChildNodes[nodeindex].Selected = true;
        }
        else
        {
            tree.Nodes[parentnodeindex].Selected = true;
        }
    }
    public static void BindDataToDropdownList(DropDownList list, DataTable data, bool hasNone = true)
    {
        list.DataSource = data;
        list.DataBind();

        if (hasNone)
        {
            AddBlankDropdownItem(list, "0");
        }
    }

    public static void AddBlankDropdownItem(DropDownList list, string value = "")
    {
        if (list.Items.FindByValue(value) != null)
        {
            list.Items.Remove(new ListItem("", value));
        }
        list.Items.Insert(0, new ListItem("", value));
    }
    public static void AddBlankDropdownItem(DropDownList list, string text, string value)
    {
        if (list.Items.FindByValue(value) != null)
        {
            list.Items.Remove(new ListItem(text, value));
        }
        list.Items.Insert(0, new ListItem(text, value));
    }
    public static void BindDataToListBox(ListBox list, DataTable data)
    {
        list.DataSource = data;
        list.DataBind();
    }

    public static void SelectDropdownItem(DropDownList list, object obj)
    {
        string value = (obj != DBNull.Value ? Convert.ToString(obj) : "");

        ListItem item = list.Items.FindByValue(value);
        if (item != null)
        {
            item.Selected = true;
        }
    }

    public static bool SelectDropdownItem(DropDownList list, object obj, object enable)
    {
        SelectDropdownItem(list, obj);
        list.Enabled = (enable != DBNull.Value ? Convert.ToBoolean(enable) : false);
        return list.Enabled;
    }
    public static bool CheckImageFileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);

        switch (ext.ToLower())
        {
            case ".gif":
                return true;

            case ".png":
                return true;

            case ".jpg":
                return true;

            case ".jpeg":
                return true;

            default:
                return false;
        }
    }

    public static string Html2Text(string value)
    {
        return value.Replace("<br />", "\r");
    }

    public static string Text2Html(string value)
    {
        return value.Replace("\r", "<br />");
    }

    #region DataView
    public static object GetFieldValue(DataRowView row, string FieldName)
    {
        return (row.Row.Table.Columns.Contains(FieldName) ? row[FieldName] : null);
    }
    public static string GetStringFieldValue(DataRowView row, string FieldName)
    {
        return (row.Row.Table.Columns.Contains(FieldName) && row[FieldName] != DBNull.Value ? Convert.ToString(row[FieldName]) : "");
    }
    public static int GetIntFieldValue(DataRowView row, string FieldName)
    {
        return (row.Row.Table.Columns.Contains(FieldName) && row[FieldName] != DBNull.Value ? Convert.ToInt32(row[FieldName]) : 0);
    }
    public static float GetFloatFieldValue(DataRowView row, string FieldName)
    {
        return (row.Row.Table.Columns.Contains(FieldName) && row[FieldName] != DBNull.Value ? Convert.ToSingle(row[FieldName]) : 0);
    }
    public static bool GetBooleanFieldValue(DataRowView row, string FieldName)
    {
        return (row.Row.Table.Columns.Contains(FieldName) && row[FieldName] != DBNull.Value ? Convert.ToBoolean(row[FieldName]) : false);
    }
    public static DateTime GetDateTimeFieldValue(DataRowView row, string FieldName)
    {
        return (row.Row.Table.Columns.Contains(FieldName) && row[FieldName] != DBNull.Value ? Convert.ToDateTime(row[FieldName]) : DateTime.MinValue);
    }

    public static object GetFieldValue(DataRow row, string FieldName)
    {
        return (row.Table.Columns.Contains(FieldName) ? row[FieldName] : null);
    }
    public static string GetStringFieldValue(DataRow row, string FieldName)
    {
        return (row.Table.Columns.Contains(FieldName) && row[FieldName] != DBNull.Value ? Convert.ToString(row[FieldName]) : "");
    }
    public static int GetIntFieldValue(DataRow row, string FieldName)
    {
        return (row.Table.Columns.Contains(FieldName) && row[FieldName] != DBNull.Value ? Convert.ToInt32(row[FieldName]) : 0);
    }
    public static bool GetBooleanFieldValue(DataRow row, string FieldName)
    {
        return (row.Table.Columns.Contains(FieldName) && row[FieldName] != DBNull.Value ? Convert.ToBoolean(row[FieldName]) : false);
    }
    public static DateTime GetDateTimeFieldValue(DataRow row, string FieldName)
    {
        return (row.Table.Columns.Contains(FieldName) && row[FieldName] != DBNull.Value ? Convert.ToDateTime(row[FieldName]) : DateTime.MinValue);
    }
    #endregion
}
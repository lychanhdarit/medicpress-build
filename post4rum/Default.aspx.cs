using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class post4rum_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void postXen()
    {
        XmlTextReader rssReader;
        XmlDocument rssDoc = null;
        XmlNode nodeRss = null;
        XmlNode nodeChannel = null;
        String title;
        String text;
        HttpWebRequest http = WebRequest.Create("http://www.aerolitegaming.com/login/login/") as HttpWebRequest;
        http.KeepAlive = true;
        http.Method = "POST";
        http.AllowAutoRedirect = true;
        http.ContentType = "application/x-www-form-urlencoded";
        string postData = "login=SNIP&register=0&password=SNIP&remember=1&cookie_check=0&_xfToken=";
        byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(postData);
        http.ContentLength = dataBytes.Length;
        using (Stream postStream = http.GetRequestStream())
        {
            postStream.Write(dataBytes, 0, dataBytes.Length);
        }
        HttpWebResponse httpResponse = http.GetResponse() as HttpWebResponse;
        int y = (int)httpResponse.StatusCode;
        Console.WriteLine(Convert.ToString(y), "Response Code Debug");
        foreach (Cookie c in httpResponse.Cookies)
        {
            Console.WriteLine(c.Name + " = " + c.Value, "Cookie Debug");
        }
        http = WebRequest.Create("http://www.aerolitegaming.com/") as HttpWebRequest;
        http.CookieContainer = new CookieContainer();
        http.CookieContainer.Add(httpResponse.Cookies);
        http.AllowAutoRedirect = false;
        HttpWebResponse httpResponse2 = http.GetResponse() as HttpWebResponse;
        // RSS read
        try
        {
            rssReader = new XmlTextReader("http://aerolitegaming.com/forums/in-game-reports.132/");
            rssDoc = new XmlDocument();
            rssDoc.Load(rssReader);
        }
        catch (WebException e)
        {
            Console.WriteLine("This program is expected to throw WebException on successful run." +
                                "\n\nException Message :" + e.Message);
            if (e.Status == WebExceptionStatus.ProtocolError)
            {
                Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        // Loop for the <rss> tag
        for (int i = 0; i < rssDoc.ChildNodes.Count; i++)
        {
            // If it is the rss tag
            if (rssDoc.ChildNodes[i].Name == "rss")
            {
                // <rss> tag found
                nodeRss = rssDoc.ChildNodes[i];
            }
        }
        // Loop for the <channel> tag
        for (int i = 0; i < nodeRss.ChildNodes.Count; i++)
        {
            // If it is the channel tag
            if (nodeRss.ChildNodes[i].Name == "channel")
            {
                // <channel> tag found
                nodeChannel = nodeRss.ChildNodes[i];
            }
        }
        // Set the labels with information from inside the nodes
        title = "Title: " + nodeChannel["title"].InnerText;
        text = "Description: " + nodeChannel["description"].InnerText;
        Console.WriteLine(title);
        Console.WriteLine(text);
    }
    private void postBB()
    {
        try
        {
            string format = "autologin=1&login=true&username={0}&password={1}";

            byte[] bytes = Encoding.ASCII.GetBytes(string.Format(format, (object)HttpUtility.UrlEncode("USERNAME"), (object)HttpUtility.UrlEncode("PASSWORD")));

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://thephpbb3domain/ucp.php?mode=login");
            httpWebRequest.CookieContainer = new CookieContainer(128);
            httpWebRequest.Timeout = 10000;
            httpWebRequest.AllowAutoRedirect = false;
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0; GTB6; SLCC1; .NET CLR 2.0.50727;";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = (long)bytes.Length;
            Stream requestStream = ((WebRequest)httpWebRequest).GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpWebResponse == null)
            {
                //int num2 = (int)MessageBox.Show(Resources.ERR_MSG_NO_DATA);
                return;
            }
            else
            {
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                streamReader.ReadToEnd().Trim();
                streamReader.Close();

                IEnumerator enumerator2 = httpWebResponse.Cookies.GetEnumerator();
                try
                {
                    while (enumerator2.MoveNext())
                    {
                        Cookie cookie = (Cookie)enumerator2.Current;
                        string str = HttpUtility.UrlDecode(cookie.Value);
                        if (cookie.Name.EndsWith("_k"))
                        {
                            if (cookie.Value.Length > 5)
                            {

                                break;
                            }
                        }
                        else if (cookie.Name.EndsWith("_data") && !str.Contains("s:6:\"userid\";i:-1;") && str.Contains("s:6:\"userid\";"))
                        {


                        }
                    }

                }
                finally
                {
                    IDisposable disposable = enumerator2 as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();
                }


            }
        }
        catch (WebException ex)
        {
            //int num = (int)MessageBox.Show(ex.Message, "HTTP Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
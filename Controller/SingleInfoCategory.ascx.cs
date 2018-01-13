using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_SingleInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getDetails();
        }
    }
    private void getDetails()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["code"]))
        {
            DiamondProcessCode _dm = new DiamondProcessCode();
            DBClass _db = new DBClass();
            string url = Request.QueryString["code"];
            DataRow info = _dm.GetSingleCategory(null, url, true);

            if (info != null)
            {
                ltTitle.Text = BaseView.GetStringFieldValue(info, "name");
                ltDesc.Text = BaseView.GetStringFieldValue(info, "description");
                string noidung = BaseView.GetStringFieldValue(info, "noidung");
                ltContent.Text = noidung;


                Page.Title = BaseView.GetStringFieldValue(info, "name");
                Page.MetaDescription = BaseView.GetStringFieldValue(info, "description");
                Page.MetaKeywords = BaseView.GetStringFieldValue(info, "description");
            }
        }
    }

}
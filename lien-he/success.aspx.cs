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
        if(!IsPostBack)
        {
            if(!String.IsNullOrEmpty(Request.QueryString["urlRequest"]))
            {
                if(Request.QueryString["urlRequest"] != "XBNMK")
                {
                    Response.Redirect("~/lien-he/");
                }
            }
        }
    }
  
    protected void btnDH_Click(object sender, EventArgs e)
    {
       
    }

    
}
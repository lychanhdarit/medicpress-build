using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Categorys_tags : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Form.Action = Request.RawUrl;
		getHeader();
        if (!IsPostBack)
        {
            BindRepeater();
        }
    }
    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
            {
                return Convert.ToInt32(ViewState["PageNumber"]);
            }
            else
            {
                return 0;
            }
        }
        set { ViewState["PageNumber"] = value; }
    }
    private string TieuDeTrang()
    {
        DBClass _db = new DBClass();
        string title = "";
        DataRow dr = _db.get_info_caidat();
        if (dr != null)
        {
            title = BaseView.GetStringFieldValue(dr, "tieudetrang");
        }
        return title;
    }
    private void getHeader()
    {
        DBClass _db = new DBClass();
        string idString = Request.QueryString["code"];
        string[] sKey = idString.Split('-');
        int id = 0;
        string urlKeys = "";
        if (sKey.Length > 0)
        {
            for (int i = 1; i < sKey.Length; i++)
                urlKeys += sKey[i] + "-";

            id = ToSQL.SQLToInt(sKey[0]);
        }
        string key = "%" + urlKeys + "%";
        DataRow srow = _db.get_info_words(id);
		string title="";
        if (srow != null)
        {
            title = BaseView.GetStringFieldValue(srow, "title");
            string desc = BaseView.GetStringFieldValue(srow, "desc");
            string keywords = BaseView.GetStringFieldValue(srow, "keywords");
			
            Page.Title = title == "" ? keywords : (BaseView.GetStringFieldValue(srow, "title") + " - " + TieuDeTrang());
			//Page.Title = BaseView.GetStringFieldValue(srow, "keywords");
            Page.MetaDescription = desc;
            Page.MetaKeywords = keywords;
        }
        else
        {
            Page.Title = id + " - Trang không tồn tại.";
        }
    }
    private DataTable dataPages()
    {
        DBClass _db = new DBClass();
        try
        {
            string[] ids = Request.QueryString["code"].Split(',');
            string idString = Request.QueryString["code"];
            if (ids.Length > 1)
            {
                idString = ids[0];
            }
            string[] sKey = idString.Split('-');
            if (sKey.Length > 0)
            {
                idString = "";
                for (int i = 1; i < sKey.Length; i++)
                    idString += sKey[i] + "-";
            }
            int id = ToSQL.SQLToInt(idString[0]);
            string key = "%" + idString + "%";
          
            return _db.Get_Top_News_Tag(key, 2000);
        }
        catch
        {
            return _db.Get_All_News();
           
        }
    }
    private void BindRepeater()
    {
        //Do your database connection stuff and get your data
        DBClass _db = new DBClass();

        //Create the PagedDataSource that will be used in paging
        PagedDataSource pgitems = new PagedDataSource();
        pgitems.DataSource = dataPages().DefaultView;
        pgitems.AllowPaging = true;

        //Control page size from here 
        pgitems.PageSize = 12;
        pgitems.CurrentPageIndex = PageNumber;
        if (pgitems.PageCount > 1)
        {
            rptPaging.Visible = true;
            ArrayList pages = new ArrayList();
            for (int i = 0; i <= pgitems.PageCount - 1; i++)
            {
                pages.Add((i + 1).ToString());
            }
            rptPaging.DataSource = pages;
            rptPaging.DataBind();
        }
        else
        {
            rptPaging.Visible = false;
        }

        //Finally, set the datasource of the repeater
        //rpData.DataSource = _db.Get_All_News_IDLoai(id);
        rpData.DataSource = pgitems;
        rpData.DataBind();

    }

    //This method will fire when clicking on the page no link from the pager repeater
    protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        ltPage.Text = (PageNumber + 1).ToString();
        BindRepeater();
        //BindRepeater(0);
    }
}
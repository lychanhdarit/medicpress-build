using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_ListPostWithCategory : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindItemsList();
        }
    }


    #region > Private Properties <
    private int CurrentPage
    {
        get
        {
            object objPage = ViewState["_CurrentPage"];
            int _CurrentPage = 0;
            if (objPage == null)
            {
                _CurrentPage = 0;
            }
            else
            {
                _CurrentPage = (int)objPage;
            }
            return _CurrentPage;
        }
        set { ViewState["_CurrentPage"] = value; }
    }
    private int fistIndex
    {
        get
        {

            int _FirstIndex = 0;
            if (ViewState["_FirstIndex"] == null)
            {
                _FirstIndex = 0;
            }
            else
            {
                _FirstIndex = Convert.ToInt32(ViewState["_FirstIndex"]);
            }
            return _FirstIndex;
        }
        set { ViewState["_FirstIndex"] = value; }
    }
    private int lastIndex
    {
        get
        {

            int _LastIndex = 0;
            if (ViewState["_LastIndex"] == null)
            {
                _LastIndex = 0;
            }
            else
            {
                _LastIndex = Convert.ToInt32(ViewState["_LastIndex"]);
            }
            return _LastIndex;
        }
        set { ViewState["_LastIndex"] = value; }
    }
    #endregion
    #region > PagedDataSource <
    PagedDataSource _PageDataSource = new PagedDataSource();
    #endregion

    void BindItemsList()
    {
        //Process data here
        string code = "";
        if (!String.IsNullOrEmpty(Request.QueryString["code"]))
        {
            code = Request.QueryString["code"];
        }
        DataTable data = new DataTable();
        DiamondProcessCode _dm = new DiamondProcessCode();
        DataRow infoCategory = _dm.GetSingleCategory(null, code, true);
        if (infoCategory != null)
        {
            int idCategory = BaseView.GetIntFieldValue(infoCategory, "id");
            data = _dm.GetListPost("", idCategory, null, true);

        }
        //fill dataTable from Database

        _PageDataSource.DataSource = data.DefaultView;
        _PageDataSource.AllowPaging = true;
        _PageDataSource.PageSize = 8;


        _PageDataSource.CurrentPageIndex = CurrentPage;
        ViewState["TotalPages"] = _PageDataSource.PageCount;
        this.dataPost.DataSource = _PageDataSource;
        this.dataPost.DataBind();
        if (dataPost.Items.Count > 0)
        {
            this.doPaging();


        }
        else
        {
            //Message.Visible = true;
            //ShowMessage.Visible = true;
            //Message.Text = "Sorry,There is No Products yet !.";
        }
    }



    private void doPaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");

        fistIndex = CurrentPage - 5;


        if (CurrentPage > 5)
        {
            lastIndex = CurrentPage + 5;
        }
        else
        {
            lastIndex = 10;
        }
        if (lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        {
            lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
            fistIndex = lastIndex - 10;
        }

        if (fistIndex < 0)
        {
            fistIndex = 0;
        }

        for (int i = fistIndex; i < lastIndex; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }

        this.dlPaging.DataSource = dt;
        this.dlPaging.DataBind();
    }



    protected void dlPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("Paging"))
        {
            CurrentPage = Convert.ToInt16(e.CommandArgument.ToString());
            this.BindItemsList();
            //Fill the DATALIST AGAIN
        }


    }
    protected void dlPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        LinkButton lnkbtnPage = (LinkButton)e.Item.FindControl("lnkbtnPaging");
        if (lnkbtnPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            lnkbtnPage.Enabled = false;
            lnkbtnPage.Style.Add("fone-size", "14px");
            lnkbtnPage.Font.Bold = true;

        }

    }
    protected void listData2_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Image img = (Image)e.Item.FindControl("Image1");
        string hinh = img.CssClass;
        if (hinh.IndexOf("http") == -1 && hinh.Trim() != "")
        {
            hinh = "~/Upload/" + hinh;
        }
        else if (hinh.Trim() == "")
        {
            hinh = "~/Upload/noimg.jpg";
        }
        if (BaseView.KiemTraImages(hinh) == false)
        {
            hinh = "~/Upload/noimg.jpg";
        }
        img.ImageUrl = hinh;
    }
}
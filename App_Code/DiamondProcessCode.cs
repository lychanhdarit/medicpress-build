using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DiamondProcessCode
/// </summary>
public class DiamondProcessCode
{
    public DiamondProcessCode()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private DBClass _db = new DBClass();
    public DataRow GetSinglePost(int? id, string url, bool? PrPost, bool? isActived)
    {
        string SqlCommand = "SELECT * from News where 1 = 1 ";

        if (id != null)
        {
            SqlCommand += " and id = " + id;
        }
        if (!String.IsNullOrEmpty(url))
        {
            SqlCommand += " and id_tt = '" + url + "'";
        }
        if (isActived != null)
        {
            SqlCommand += " and isActived = '" + isActived + "'";
        }

        return _db.sqlGetDataRow(SqlCommand);
    }
    //SELECT Top(@top) * from News where keywords like @code
    public DataTable GetTopPost(int Top,string keywordTags, bool? isActived)
    {
        string SqlCommand = "SELECT Top("+Top+") * from News where 1 = 1";
        if (isActived != null)
        {
            SqlCommand += " and isActived = '" + isActived + "'";
        }
        if (!String.IsNullOrEmpty(keywordTags))
        {
            SqlCommand += " and keywords like N'%" + keywordTags + "%'";
        }
        SqlCommand +=  " order by id desc";
        return _db.sqlGetData(SqlCommand);
    }
    public DataTable GetListPost(string keySearch, int? idCategory, bool? PrPost, bool? isActived)
    {
        string SqlCommand = "SELECT * from News where 1 = 1 ", SqlCurrentUserCatergory = "";


        if (!String.IsNullOrEmpty(keySearch))
        {
            SqlCommand += " and tieude like N'%" + keySearch + "%'";
        }
        if (isActived != null)
        {
            SqlCommand += " and isActived = '" + isActived + "'";
        }
        if (idCategory != null)
        {
            SqlCurrentUserCatergory = " and (maloai = " + idCategory + " or maloai in  (select l.Id from LoaiTin l where isPatient =  " + idCategory + ") )";
        }
        else
        {
            if (CheckCurrentAdmin() == false)
            {
                string user = BaseView.ReadCookie("adminUserName");
                SqlCurrentUserCatergory = " and (maloai in (select CategoryID from UserRole where username = '" + user + " ') or maloai in  (select l.Id from LoaiTin l where isPatient in (select CategoryID from UserRole where username = '" + user + "') ) ) ";
               
            }
        }
       
        SqlCommand += SqlCurrentUserCatergory + " order by id desc";

        return _db.sqlGetData(SqlCommand);
    }
    public DataRow GetSingleCategory(int? id, string code, bool? isActived)
    {
        string SqlCommand = "SELECT * from LoaiTin where 1 = 1 ";
        if (isActived != null)
        {
            SqlCommand += " and isActived = '" + isActived+"'";
        }
        if (id != null)
        {
            SqlCommand += " and id = " + id;
        }
        if (!String.IsNullOrEmpty(code))
        {
            SqlCommand += " and code = '" + code + "'";
        }

        return _db.sqlGetDataRow(SqlCommand);

    }
    public DataTable GetListCategory(int? id, string keySearch, string code, bool? isActived)
    {
        string SqlCommand = "SELECT * from LoaiTin where 1 = 1 ", SqlCurrentUserCatergory = "";
        
        if (!String.IsNullOrEmpty(keySearch))
        {
            SqlCommand += " and name like N'%" + keySearch + "%'";
        }
        if (isActived != null)
        {
            SqlCommand += " and isActived = '" + isActived+"'";
        }
        if (id != null)
        {
            SqlCurrentUserCatergory = " and (id = " + id + " or isPatient in  (select l.Id from LoaiTin l where isPatient =  " + id + ") )";
        }
        if (CheckCurrentAdmin() == false)
        {
            string user = BaseView.ReadCookie("adminUserName");
            SqlCurrentUserCatergory = "and id in (select CategoryID from UserRole where username = '" + user + "')  or isPatient in (select CategoryID from UserRole where username = '" + user + "')";
        }
        SqlCommand += SqlCurrentUserCatergory + " order by id desc";
        return _db.sqlGetData(SqlCommand);
    }
    public bool CheckCurrentAdmin()
    {
        DataRow rUser = _db.get_Info_user_cms(BaseView.ReadCookie("adminUserName"));
        if (rUser != null)
        {
            return BaseView.GetBooleanFieldValue(rUser, "isAdmin");
        }
        return false;
    }
}
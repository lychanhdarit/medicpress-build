<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_rv_cmss_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        ul li {
            list-style:none;

        }
        ul li a{
            display:block;
            padding:20px;
            border:1px solid #0094ff;
            cursor:pointer;
            margin:10px;
            text-decoration:none;
            font-family:Tahoma;
            max-width:300px;
        }
         ul li a:hover{
            display:block;
            padding:20px;
            border:1px solid #f00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ul>
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/admin-us/auto-rss/getRss.aspx" Target="_blank">Update RSS News</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/admin-us/auto-rss/getWithPage.aspx" Target="_blank">Update Page News</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/admin-us/auto-rss/RaoVat.aspx" Target="_blank">Update RSS Rao Vat</asp:HyperLink>
        </li>
    </ul>
    </div>
    </form>
</body>
</html>

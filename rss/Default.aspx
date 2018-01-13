<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="rss_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="item-rss main">
        <div class="title-NEW">
                <h2>RSS</h2>
        </div>
        <asp:Label ID="lbRSS" runat="server" Text=""></asp:Label>
        <table>
            <asp:ListView ID="lvItem" runat="server" EnableTheming="True">
                <ItemTemplate>
                    <tr>
                        <td style="vertical-align: middle">
                            <asp:HyperLink ID="hp" runat="server" NavigateUrl='<%# "~/rss/index.aspx?code="+Eval("code") %>' Text='<%# "&raquo; "+ Eval("Name") %>'></asp:HyperLink>
                        </td>
                    </tr>

                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
    </form>
</body>
</html>


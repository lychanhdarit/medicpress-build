<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="check_domain_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Check domain</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtDomain" runat="server"></asp:TextBox><asp:Button ID="btnCheckDomain" runat="server" Text="Check" OnClick="btnCheckDomain_Click" />
        </div>
        -----------------------------
        <div>
            <asp:TextBox ID="ltKQ" runat="server" TextMode="MultiLine"  Width="100%" Rows="40"></asp:TextBox>
        </div>
    </form>
</body>
</html>

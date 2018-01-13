<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="admin_tk_sua_bai_default" ValidateRequest = "false"%>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sua bai</title>
    <script type="text/javascript" src='<%= ResolveUrl("~/Scripts/jquery-2.1.4.min.js") %>'></script>

    <script type="text/javascript" src='<%= ResolveUrl("~/ckeditor/ckeditor.js") %>'></script>

    <script type="text/javascript" src='<%= ResolveUrl("~/ckeditor/adapters/jquery.js") %>'></script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtContent.ClientID %>',
              { filebrowserImageUploadUrl: '../ckeditor/Upload.ashx' }); //path to “Upload.ashx”
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lbLinks" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Nội dung
            </td>
            <td>
                  <CKEditor:CKEditorControl ID="txtContent" runat="server">
                        </CKEditor:CKEditorControl>
            </td>
           
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnHuy" runat="server" Text="Hủy" /><asp:Button ID="btnCapNhat" runat="server" Text="Cập Nhật" OnClick="btnCapNhat_Click" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>

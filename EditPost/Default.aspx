<%@ Page Title="" Language="C#" MasterPageFile="~/Share/layout/_Share.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="EditPost_Default" ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src='<%= ResolveUrl("~/Scripts/jquery-2.1.4.min.js") %>'></script>

    <script type="text/javascript" src='<%= ResolveUrl("~/ckeditor/ckeditor.js") %>'></script>

    <script type="text/javascript" src='<%= ResolveUrl("~/ckeditor/adapters/jquery.js") %>'></script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtContent.ClientID %>',
              { filebrowserImageUploadUrl: '<%= BaseView.UrlServer() %>' + '/ckeditor/Upload.ashx' }); //path to “Upload.ashx”
        });
    </script>
    <style>
        .btn-blue {
            background: #4A93BD;
            border: none;
            border-bottom: 3px solid #1E6188;
            border-radius: 5px;
            color: #fff;
            padding: 5px 20px 5px 20px;
        }

            .btn-blue:hover {
                transition: background-color 0.5s ease;
                background-color: #2677a5;
            }

        .btn-orange {
            background: #F37213;
            border: none;
            border-bottom: 3px solid #ff0000;
            border-radius: 5px;
            color: #fff;
            padding: 5px 20px 5px 20px;
        }

            .btn-orange:hover {
                transition: background-color 0.5s ease;
                background-color: #9d4b10;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholder" runat="Server">
    <div style="margin-top: 30px">
        <table>
            <tr>
                <td>
                    <h1>Sửa bài:
                        <asp:Literal ID="ltTitle" runat="server"></asp:Literal></h1>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbLinks" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>

                <td>
                    <CKEditor:CKEditorControl ID="txtContent" runat="server">
                    </CKEditor:CKEditorControl>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlLoaiTin" runat="server" CssClass="form-control select2" Width="220px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>
        <table style="margin-top: 10px">
            <tr>
                <td style="width: 80px">
                    <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn-blue" />
                </td>
                <td>
                    <asp:Button ID="btnCapNhat" runat="server" Text="Cập Nhật" CssClass="btn-orange" OnClick="btnCapNhat_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


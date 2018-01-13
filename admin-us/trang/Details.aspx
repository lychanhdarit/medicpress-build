<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="admin_us_danh_muc_Details" ValidateRequest="false" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="content-header">
        <h1>Cập Nhật Danh Mục
           
            <small>Advanced form element</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Forms</a></li>
            <li class="active">Editors</li>
            <li>
                <asp:Label ID="Label1" runat="server" ForeColor="#CC0000"></asp:Label></li>

        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">

                <div class="box box-danger">
                    <div class="box-header">
                        <h3 class="box-title">Nhập dữ liệu</h3>
                    </div>
                    <div class="box-body">

                        <div class="form-group">
                            <label>Tiêu đề:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <div class="form-group">
                            <label>Tóm Tắt:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTomTat" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>

                        <!-- /.form group -->
                        <div class="form-group">
                            <label>URL :</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-link"></i>
                                </div>
                                <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->

                        <div class="form-group">
                            <label>Meta Title:<i> (Toi uu SEO)</i></label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Meta Description:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>CSS Class:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtCssClass" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Hiện Thị Trang Chủ:</label>
                            <div class="input-group">

                                <asp:CheckBox ID="chkHienThi" runat="server" Text="chọn hiện thị trang chủ" />
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Chọn ảnh đại diện:</label>
                            <div class="input-group">

                                <asp:FileUpload ID="fHinh" runat="server" />
                                <asp:Label ID="lbError" runat="server" ForeColor="#ffffff"></asp:Label><i></i>
                                <asp:Image ID="imgBS" runat="server" Height="100px" BackColor="#3399FF" ImageUrl="~/uploadFile/NoImg.png" />
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->

                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Hướng dẫn</h3>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <div class="box-body">
                                <!-- Date range -->
                                <div class="form-group">
                                    <label>Thêm mới:</label>
                                    <p>-> nhập dữ liệu -> nhấn <span style="color: red">Lưu</span> để hoàn thành</p>
                                </div>
                                <div class="form-group">
                                    <label>Sửa :</label>
                                    <p>-> thay đổi thông tin trong phần nhập dữ liệu sau đó chọn nút<span style="color: red"> Lưu</span> để hoàn thành</p>
                                </div>
                                <div class="form-group">
                                    <label>Thêm tag mới:</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-edit"></i>
                                        </div>
                                        <asp:TextBox ID="txtTag" runat="server" CssClass="form-control" placeholder="Thêm tags mới"></asp:TextBox>

                                    </div>
                                    <!-- /.input group -->
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btnThem" runat="server" Text="Thêm Tag" CausesValidation="False" OnClick="btnThem_Click" />
                                </div>
                                <div class="form-group">
                                    <table>
                                        <tr>
                                            <td>Chọn tag cho bài viết
                                            </td>
                                            <td>Các tag của bài viết hiện tại
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 250px;">
                                                <asp:ListBox ID="lstKeywords" runat="server" AutoPostBack="true" DataTextField="Keywords" DataValueField="id" OnSelectedIndexChanged="lstKeywords_SelectedIndexChanged" Height="205px" Width="264px"></asp:ListBox>
                                                <br />
                                            </td>
                                            <td style="vertical-align: top">
                                                <div class="listTag">
                                                    <asp:CheckBoxList ID="chkList" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" Width="265px">
                                                    </asp:CheckBoxList>
                                                </div>
                                                <asp:Label ID="lbkeyWord" runat="server"></asp:Label>
                                                <asp:Label ID="lbIDKey" runat="server" Visible="false"></asp:Label>
                                                <%--<asp:Button ID="btnXoaTag" runat="server" CausesValidation="False" OnClick="btnXoaTag_Click" Text="Xóa Tag" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->

                <!-- iCheck -->

            </div>
            <!-- /.col (right) -->
        </div>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Nội dung:</h3>
                        <!-- tools box -->
                        <div class="pull-right box-tools">
                            <button class="btn btn-default btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                            <button class="btn btn-default btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                        </div>
                        <!-- /. tools -->
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body pad">
                        <CKEditor:CKEditorControl ID="txtContent" runat="server">
                        </CKEditor:CKEditorControl>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="Button1" runat="server" Text="Trở về" PostBackUrl="~/admin-us/trang/" />
                        <asp:Button ID="Button2" runat="server" Text="Xuất bản" OnClick="btnPost_Click" />

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


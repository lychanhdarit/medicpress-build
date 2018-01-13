<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="admin_us_danh_muc_Details" ValidateRequest = "false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src='<%= ResolveUrl("~/Scripts/jquery-2.1.4.min.js") %>'></script>

    <script type="text/javascript" src='<%= ResolveUrl("~/ckeditor/ckeditor.js") %>'></script>

    <script type="text/javascript" src='<%= ResolveUrl("~/ckeditor/adapters/jquery.js") %>'></script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtNoiDung.ClientID %>',
              { filebrowserImageUploadUrl: '../ckeditor/Upload.ashx' }); //path to “Upload.ashx”
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Cập Nhật Danh Mục
           
            <small>Advanced form element</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Forms</a></li>
            <li class="active">Editors</li>
            <li>
                <asp:Label ID="lbE" runat="server" ForeColor="#CC0000"></asp:Label></li>

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
                            <label>ID:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtID" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <div class="form-group">
                            <label>Tên Hiện Thị:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Mô tả:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtMota" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Keywords:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtKeys" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>

                        <!-- /.form group -->
                         <div class="form-group">
                            <label>Hiện thị:</label>
                            <br />
                             <asp:CheckBox ID="chkMenu" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Chọn ảnh đại diện:</label>
                            <div class="input-group">

                                <asp:FileUpload ID="fHinh" runat="server" />
                                <asp:Label ID="lbError" runat="server" ForeColor="#ffffff"></asp:Label><i></i>
                                <asp:Image ID="imgDaiDien" runat="server" Height="100px" BackColor="#3399FF" ImageUrl="~/uploadFile/NoImg.png" />
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
                    <div class="box-body">
                        <!-- Date range -->
                        <div class="form-group">
                            <label>Thêm mới:</label>
                            <p>-> nhập dữ liệu -> nhấn <span style="color:red"> Lưu</span> để hoàn thành</p>
                         </div>
                        <div class="form-group">
                            <label>Sửa :</label>
                             <p> -> thay đổi thông tin trong phần nhập dữ liệu sau đó chọn nút<span style="color:red"> Lưu</span> để hoàn thành</p>
                         </div>
                    </div>
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

                        <CKEditor:CKEditorControl ID="txtNoiDung" runat="server">
                        </CKEditor:CKEditorControl>
                    </div>
                     <div class="form-group">
                            <asp:Button ID="btnThem" runat="server" Text="Back" OnClick="btnThem_Click" />
                            <asp:Button ID="btnCapNhat" runat="server" Text="Lưu" OnClick="btnCapNhat_Click" />
                          
                        </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


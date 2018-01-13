<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_cai_dat_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Cài đặt 
           
            <small> <asp:Label ID="lbE" runat="server" ForeColor="#CC0000"></asp:Label></small>
        </h1>
        
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
                            <label>Giới hạn số bài đăng trong ngày:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtSoBaiDang" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>Giới hạn số ngày đăng:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtNgayDang" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>Số links trong bài viết:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtLinksBaiViet" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>Tiêu đề trang:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTieuDeTrang" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>Tiêu đề trang chủ:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTieuDeTrangChu" runat="server" TextMode="MultiLine" CssClass="form-control" Height="85px"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>Description:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>Keywords:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtKeywords" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>ID Analytics:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtVideo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>ID Tawk.to:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtRaoVat" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>
                                <asp:Label ID="lbTB" runat="server" ForeColor="#CC0000"></asp:Label></label>
                            <div class="input-group">

                                <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btn-b" OnClick="btnLuu_Click" />
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Hướng dẫn & cài đặt đường dẫn</h3>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Đường dẫn:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtHttp" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <div class="input-group">
                                <asp:Button ID="btnSave" runat="server" Text="Cập Nhật" CssClass="btn-b" OnClick="btnSave_Click" />
                            </div>
                            <!-- /.input group -->
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbError" runat="server" ForeColor="#CC0000"></asp:Label>
                        </div>
                        <!-- Date range -->
                        <div class="form-group">
                            <label>Thêm mới hình:</label>
                            <p> nhập dữ liệu -> nhấn <span style="color: red">Lưu</span> để hoàn thành</p>
                        </div>
                        <div class="form-group">
                            <label>Sửa đường dẫn:</label>
                            <p>Nhập đường dẫn của website bỏ dấu "/" cuối đường dẫn (nếu có) ->  sau đó chọn nút<span style="color: red"> Lưu</span> để hoàn thành</p>
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->

                <!-- iCheck -->

            </div>
        </div>
    </section>
</asp:Content>


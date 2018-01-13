<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_user_info_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Cập nhật tài khoản
        </h1>
        <ol class="breadcrumb">
            <li><a href="../admin-us/"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Forms</a></li>
            <li class="active">Editors</li>
            <li>
                <asp:Label ID="lbE" runat="server" ForeColor="#CC0000" Font-Bold="true"></asp:Label>

            </li>

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

                            <div class="input-group">
                                <asp:Literal ID="ltTB" runat="server"></asp:Literal>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- Date dd/mm/yyyy -->
                        <div class="form-group">
                            <label>Người dùng:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtUserName" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>

                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Họ tên :</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtHoTen" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Điện Thoại:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtDienThoai" runat="server" Enabled="true" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Email:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtEmail" runat="server" Enabled="true" CssClass="form-control" TextMode="Email"></asp:TextBox>
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

                        <div class="form-group">
                            <asp:Button ID="btnLamMoi" runat="server" Text="Làm Mới" OnClick="btnLamMoi_Click" CssClass="btn-blue" />
                            <asp:Button ID="btnCapNhat" runat="server" Text="Sửa" OnClick="btnCapNhat_Click" CssClass="btn-orange" />
                            <label>Lưu ý: khi thêm mới (chọn nút Thêm Mới nhập dữ liệu -> chọn nút Lưu để hoàn tất)</label>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>



</asp:Content>


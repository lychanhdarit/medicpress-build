<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="info-acc.aspx.cs" Inherits="admin_us_quan_ly_tai_khoan_info_acc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">
        <h1>
            Thông tin tài khoản
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Forms</a></li>
            <li class="active">Editors</li>
            <li>
                <asp:Label ID="lbE" runat="server" ForeColor="#CC0000" Font-Bold="true"></asp:Label></li>

        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-danger">
                    <div class="box-header">
                        <asp:HyperLink ID="HyperLink1" runat="server" Text="<< Danh sách tài khoản"  NavigateUrl="~/admin-us/quan-ly-tai-khoan/"  CssClass="btn-back"/>
                    </div>
                    <div class="box-header">
                        <h3 class="box-title">Nhập dữ liệu</h3>
                    </div>
                    <div class="box-body">
                        <!-- Date dd/mm/yyyy -->
                         <div class="form-group">
                            <div class="input-group">
                               
                                <asp:Image ID="imgBS" runat="server" Height="100px" BackColor="#3399FF" ImageUrl="~/uploadFile/NoImg.png" />
                            </div>
                            <!-- /.input group -->
                        </div>
                        <div class="form-group">
                            <label>Người dùng:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtUserName" runat="server" Enabled="false" CssClass="form-control"  ></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                       
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Họ tên :</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtHoTen" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Điện Thoại:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtDienThoai" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Email:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtEmail" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Actived:</label>
                            <div class="input-group">

                                <asp:CheckBox ID="chkActived" runat="server" Checked="true"  Enabled="false"/>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Quyền sử dụng:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:DropDownList ID="ddlUser" runat="server"  Enabled="false" CssClass="ddlStyle" AutoPostBack="true" ></asp:DropDownList>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <!-- /.form group -->
                       
                        <!-- /.form group -->
                        <div class="form-group">
                           
                            <asp:Button ID="btnQuayVe" runat="server" Text="Danh sách tài khoản"  PostBackUrl="~/admin-us/quan-ly-tai-khoan/" CssClass="btn-blue" />
                            <asp:Button ID="btnCapNhat" runat="server" Text="Sửa"  CssClass="btn-orange"/>
                            <label>Lưu ý: khi thêm mới (chọn nút Thêm Mới nhập dữ liệu -> chọn nút Lưu để hoàn tất)</label>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>

</asp:Content>


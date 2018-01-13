<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="ChangePW.aspx.cs" Inherits="admin_us_user_info_ChangePW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">
        <h1>Đổi mật khẩu
           
            <small>Advanced form element</small>
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
                                <asp:TextBox ID="txtID" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->

                        <!-- Date mm/dd/yyyy -->

                        <!-- phone mask -->
                        <div class="form-group">
                            <label>Tên Hiện Thị:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTen" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->

                        <!-- phone mask -->
                        <div class="form-group">
                            <label>
                                Mật khẩu cũ:
                                <asp:Label ID="lbService" runat="server" Text=""></asp:Label></label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtMKCu" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="*" ControlToValidate="txtMKCu"></asp:RequiredFieldValidator>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>
                                Mật khẩu mới:
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></label>
                            <div class="input-group">
                               <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtMKMoi" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="*" ControlToValidate="txtMKMoi"></asp:RequiredFieldValidator>
                                
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                       <div class="form-group">
                            <label>
                                Nhập lại mật khẩu mới:
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></label>
                            <div class="input-group">
                               <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtMKMoi2" runat="server" CssClass="form-control"  TextMode="Password" ></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="txtMKMoi2" ControlToCompare="txtMKMoi" ></asp:CompareValidator>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <asp:Button ID="btnCapNhat" runat="server" Text="Đổi mật khẩu" OnClick="btnThayDoi_Click"  CssClass="btn-orange"/>
                            <label>Lưu ý: khi thêm mới (chọn nút Thêm Mới nhập dữ liệu -> chọn nút Lưu để hoàn tất)</label>
                        </div>
                    </div>


                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Hướng dẫn</h3>
                    </div>
                    <div class="box-body">
                        <!-- Date range -->
                       
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->

                <!-- iCheck -->

            </div>
            <!-- /.col (right) -->
        </div>
    </section>
</asp:Content>


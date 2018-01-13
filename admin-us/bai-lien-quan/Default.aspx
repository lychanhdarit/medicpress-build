<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_slider_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Cập nhật bài viết liên quan: 
           
            <small>
                <asp:Label ID="ltBaiLQ" runat="server" Text="" ForeColor="Red"></asp:Label></small>
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
                        <div class="form-group" style="display:none">
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
                            <label>Title:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" Display="Dynamic" ForeColor="Red" ControlToValidate="txtTen"></asp:RequiredFieldValidator>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Hình ảnh:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <asp:FileUpload ID="fHinh" runat="server" />
                                    <br />
                                    <asp:Image ID="imgBS" runat="server" Width="300px" />
                                </div>

                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>
                                URL:
                                <asp:Label ID="lbService" runat="server" Text=""></asp:Label></label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-link"></i>
                                </div>
                                <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                      
                        <div class="form-group">
                            <label>
                                Chức năng:
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <asp:Button ID="btnTrove" runat="server" Text="Trở về" PostBackUrl="~/admin-us/bai-viet/Default.aspx" CssClass="btn-blue"  CausesValidation="false" />
                                    <asp:Button ID="btnThem" runat="server" Text="Clear" OnClick="btnThem_Click" CssClass="btn-blue"  CausesValidation="false" />
                                    <asp:Button ID="btnCapNhat" runat="server" Text="Lưu" OnClick="btnCapNhat_Click" CssClass="btn-orange" />

                                </div>

                            </div>
                            <!-- /.input group -->
                        </div>

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
                            <label>Thêm mới hình:</label>
                            <p>bấm nút <span style="color:red">Thêm mới</span> nhập dữ liệu -> nhấn <span style="color:red"> Lưu</span> để hoàn thành</p>
                         </div>
                        <div class="form-group">
                            <label>Sửa hình:</label>
                             <p>Nhấp chọn hình trong danh sách -> thay đổi thông tin trong phần nhập dữ liệu sau đó chọn nút<span style="color:red"> Lưu</span> để hoàn thành</p>
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
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Dữ liệu</h3>
                        <br />
                        <asp:Button ID="btnXoa" runat="server" Text="Xóa mục đã chọn" OnClick="btnXoa_Click"  CssClass="btn-orange" CausesValidation="false" />
                       
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <asp:GridView ID="grvData" runat="server"
                            AutoGenerateColumns="False" EmptyDataText="No data" DataKeyNames="id"
                            ShowHeaderWhenEmpty="True" PageSize="15" CssClass="table table-bordered table-hover" AllowPaging="True" OnRowDataBound="grDataTinh_RowDataBound" OnSelectedIndexChanged="grDataTinh_SelectedIndexChanged" OnPageIndexChanged="grvTaskNew_PageIndexChanged" OnPageIndexChanging="grvTaskNew_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Chọn">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkChon" runat="server" CssClass='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                     <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" Height="40px" runat="server" ToolTip='<%# Eval("images") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="Tên">
                                    <ItemTemplate>
                                        <asp:Label ID="lbName" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Url">
                                    <ItemTemplate>
                                        <asp:Label ID="lbHinhThuc" runat="server" Text='<%# Eval("url") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="clear"></div>
            </div>
        </div>
    </section>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_tu_khoa_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Cập Nhật Từ Khóa
           
            <small><asp:Label ID="lbE" runat="server" ForeColor="#CC0000"></asp:Label></small>
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
                            <label>ID:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtID" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>Keywords:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTuKhoa" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>Tiêu đề:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>Mô tả:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">
                            <label>URL:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtLink" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
                        <div class="form-group">

                            <asp:Button ID="btnThem" runat="server" Text="Thêm mới" OnClick="btnThem_Click" CssClass="btn-b" />
                            <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" CssClass="btn-h" />
                            <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" CssClass="btn-b" />
                            <!-- /.input group -->
                        </div>
                        <!-- /. group -->
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
                            <p>bấm nút <span style="color: red">Thêm mới</span> nhập dữ liệu -> nhấn <span style="color: red">Lưu</span> để hoàn thành</p>
                        </div>
                        <div class="form-group">
                            <label>Sửa hình:</label>
                            <p>Nhấp chọn hình trong danh sách -> thay đổi thông tin trong phần nhập dữ liệu sau đó chọn nút<span style="color: red"> Lưu</span> để hoàn thành</p>
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

                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <asp:CheckBox ID="checkALL" runat="server" Text="Chọn tất cả" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" />
                        <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" CssClass="btn-y"/>
                        <asp:GridView ID="grvTaskNew" runat="server"
                            AutoGenerateColumns="False" Width="100%" EmptyDataText="No data" DataKeyNames="id"
                            ShowHeaderWhenEmpty="True" PageSize="15"
                            AllowSorting="True" AllowPaging="True" OnRowDataBound="grDataTinh_RowDataBound" CssClass="table table-bordered table-hover" OnSelectedIndexChanged="grDataTinh_SelectedIndexChanged" OnPageIndexChanging="grvTaskNew_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" Checked="false" CssClass='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tiêu Đề" SortExpression="TieuDe">
                                    <ItemTemplate>
                                        <asp:Label ID="lbKey" runat="server" Text='<%# Eval("keywords") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mô tả" SortExpression="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lbLink" runat="server" Text='<%# Eval("desc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


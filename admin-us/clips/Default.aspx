<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_clips_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Cập Nhật Clips
           
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
                            <label>Thể loại:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:DropDownList ID="ddlTheLoai" runat="server" DataTextField="name" DataValueField="id" CssClass="form-control">
                                </asp:DropDownList>

                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->
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
                        <!-- /.input form -->
                        <div class="form-group">
                            <label>Tên:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                     <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->
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
                        <!-- /.input form -->
                        <div class="form-group">
                            <label>Mã Nhúng:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                     <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtLinks" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->
                        <div class="form-group">
                            <label>Hình Ảnh:</label>
                            <div class="input-group">
                               
                                <asp:FileUpload ID="fHinh" runat="server" />
                                <asp:Label ID="lbError" runat="server" ForeColor="#CC0000"></asp:Label><i>(Chú ý kích thước hình )</i>
                                <asp:Image ID="imgBS" runat="server" Height="100px" BackColor="#3399FF" ImageUrl="~/uploadFile/noimg.jpg" />
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->
                       <div class="form-group">
                            <asp:Button ID="btnThem" runat="server" Text="Thêm mới" OnClick="btnThem_Click" CssClass="btn-b" />
                            <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" CssClass="btn-h" />
                            <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" CssClass="btn-b" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                  
                    <div class="box-body">
                        <div class="grid">
                            <asp:CheckBox ID="checkAll" runat="server" Text="Chọn tất cả" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" />
                            <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" CssClass="btn-b" />
                            <asp:GridView ID="grvTaskNew" runat="server"
                                AutoGenerateColumns="False" EmptyDataText="No data" DataKeyNames="id"
                                ShowHeaderWhenEmpty="True" PageSize="15"
                                AllowSorting="True" AllowPaging="True" OnRowDataBound="grDataTinh_RowDataBound" CssClass="table table-bordered table-hover" OnSelectedIndexChanged="grDataTinh_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Chọn">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkChon" runat="server" CssClass='<%# Eval("id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lbKey" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tên">
                                        <ItemTemplate>
                                            <asp:Label ID="lbName" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mô tả">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDesc" runat="server" Text='<%# Eval("desc_") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mã nhúng">
                                        <ItemTemplate>
                                            <asp:Label ID="lbLink" runat="server" Text='<%# Eval("links") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Loại">
                                        <ItemTemplate>
                                            <asp:Label ID="lbID_Loai" runat="server" Text='<%# Eval("id_c") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


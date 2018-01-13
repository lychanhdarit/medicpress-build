<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" EnableEventValidation="false" Inherits="admin_us_quan_ly_tai_khoan_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>
            Cập nhật tài khoản
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
                        <asp:HyperLink ID="btnQuayVe" runat="server" Text="<< Danh sách tài khoản"  NavigateUrl="~/admin-us/quan-ly-tai-khoan/"  CssClass="btn-back"/>
                    </div>
                     
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
                                <asp:TextBox ID="txtUserName" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
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
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtDienThoai" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
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
                                <asp:TextBox ID="txtEmail" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Actived:</label>
                            <div class="input-group">

                                <asp:CheckBox ID="chkActived" runat="server" Checked="true" />
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
                                <asp:DropDownList ID="ddlUser" runat="server" CssClass="form-control ddlStyle" AutoPostBack="true" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <!-- /.form group -->
                        <div class="form-group" style="display:none">
                            <label>Khu vực quản lý:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:DropDownList ID="ddlTinh" runat="server" CssClass="ddlStyle" DataTextField="Ten" DataValueField="maTinh" AutoPostBack="true" OnSelectedIndexChanged="ddlTinh_SelectedIndexChanged">
                                </asp:DropDownList>
                                <div class="chkListStyle">
                                    <asp:CheckBoxList ID="chkQuan" runat="server" CssClass="ddlStyle" DataTextField="Ten" DataValueField="maQuan" Width="300px">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                            <!-- /.input group -->
                        </div>
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
                            <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" Visible="false" />
                            <asp:Button ID="btnCapNhat" runat="server" Text="Sửa" OnClick="btnCapNhat_Click" CssClass="btn-orange"/>
                            <label>Lưu ý: khi thêm mới (chọn nút Thêm Mới nhập dữ liệu -> chọn nút Lưu để hoàn tất)</label>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>


     <div class="box-body" style="visibility:hidden">
        <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" />
        <div class="grid">
            <asp:GridView ID="grvTaskNew" runat="server"
                AutoGenerateColumns="False" Width="100%" EmptyDataText="No data" DataKeyNames="username"
                ShowHeaderWhenEmpty="True" PageSize="15"
                AllowSorting="True" AllowPaging="True" OnRowDataBound="grDataTinh_RowDataBound" CssClass="table table-bordered table-hover" OnSelectedIndexChanged="grDataTinh_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Chọn">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkChon" runat="server" CssClass='<%# Eval("username") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên Người Dùng" SortExpression="username">
                        <ItemTemplate>
                            <asp:Label ID="lbKey" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Họ Tên" SortExpression="hoten">
                        <ItemTemplate>
                            <asp:Label ID="lbLink" runat="server" Text='<%# Eval("hoten") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quyền Admin">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAdmin" runat="server" Checked='<%# Eval("isAdmin") != null? Eval("isAdmin") : null %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="grid">
            <asp:GridView ID="grvQuyen" runat="server"
                AutoGenerateColumns="False" Width="100%" EmptyDataText="No data" DataKeyNames="Iduser"
                ShowHeaderWhenEmpty="True" PageSize="15"
                AllowSorting="True" AllowPaging="True" CssClass="table table-bordered table-hover">
                <Columns>
                    <asp:TemplateField HeaderText="Chọn">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkChon" runat="server" CssClass='<%# Eval("Iduser") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên Người Dùng" SortExpression="TieuDe">
                        <ItemTemplate>
                            <asp:Label ID="lbKey" runat="server" Text='<%# Eval("Iduser") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Khu Vực" SortExpression="Code">
                        <ItemTemplate>
                            <asp:Label ID="lbKhuVuc" runat="server" Text='<%# Eval("khuvuc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tỉnh" SortExpression="Code">
                        <ItemTemplate>
                            <asp:Label ID="lbTinh" runat="server" Text='<%# Eval("tinh") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>


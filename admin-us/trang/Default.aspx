<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_pages_danh_muc_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Danh mục Loại Tin
           
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
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Dữ liệu</h3>
                        <br />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" PostBackUrl="~/admin-us/trang/details.aspx" />
                        <asp:Button ID="btnXoa" runat="server" OnClick="btnXoa_Click" Text="Xóa" />
                    </div>
                    
                    <!-- /.box-header -->
                    <div class="box-body">
                        <asp:GridView ID="grvTaskNew" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="No data" ShowHeaderWhenEmpty="True" PageSize="15" CssClass="table table-bordered table-hover" AllowSorting="True" AllowPaging="True" OnPageIndexChanging="grvTaskNew_PageIndexChanging" OnRowDataBound="grvTaskNew_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" Checked="false" CssClass='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" Height="40px" runat="server" ToolTip='<%# Eval("HinhAnh") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tiêu Đề" SortExpression="TieuDe">
                                    <ItemTemplate>
										<asp:HyperLink ID="lbTieuDe" runat="server" Height="23px" Target="_blank" NavigateUrl='<%# "~/" +Eval("url")%>' ToolTip="Click xem bai" Text='<%# Eval("TieuDe") %>'></asp:HyperLink>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày Đăng ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbHoBN" runat="server" Text='<%# Eval("NgayDang") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Tóm Tắt" SortExpression="Tomtat">
                                    <ItemTemplate>
                                        <asp:Label ID="lbTenBN" runat="server" Text='<%# Eval("Tomtat") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Người đăng" SortExpression="">
                                    <ItemTemplate>
                                        <asp:Label ID="lbNguoiDang" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chức năng">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="btnSua" runat="server" Height="23px" NavigateUrl='<%# "~/admin-us/trang/details.aspx?id=" +Eval("id")%>' ToolTip="Sửa">Sửa</asp:HyperLink>

                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>


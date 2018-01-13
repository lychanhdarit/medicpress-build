<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_pages_danh_muc_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Danh mục
           
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
                        <asp:Button ID="btnThem" runat="server" Text="Thêm mới" PostBackUrl="~/admin-us/danh-muc/Details.aspx" />
                        <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" />
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <asp:GridView ID="grvTaskNew" runat="server"
                            AutoGenerateColumns="False" Width="100%" EmptyDataText="No data" DataKeyNames="maDanhMuc"
                            ShowHeaderWhenEmpty="True" PageSize="15"
                            AllowSorting="True" AllowPaging="True" CssClass="table table-bordered table-hover" OnRowDataBound="grDataTinh_RowDataBound" OnSelectedIndexChanged="grDataTinh_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="Chọn">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkChon" runat="server" CssClass='<%# Eval("maDanhMuc") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hình Ảnh">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" Height="40px" runat="server" ToolTip='<%# Eval("HinhAnh") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Height="30px" />
                                </asp:TemplateField>
<%--                                <asp:TemplateField HeaderText="ID" SortExpression="TieuDe">
                                    <ItemTemplate>
                                        <asp:Label ID="lbKey" runat="server" Text='<%# Eval("maDanhMuc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle  />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Tên Danh Mục" SortExpression="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lbLink" runat="server" Text='<%# Eval("tenDanhMuc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                <asp:TemplateField HeaderText="Chức năng">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="btnXem" runat="server" Height="23px" Target="_blank" NavigateUrl='<%# "~/"+BaseView.repalce_UrlFriendly(BaseView.convertToUnSign2(Eval("tenDanhMuc").ToString()))+"-" +Eval("maDanhMuc")+".hxml"%>' ToolTip="Sửa">Xem trước danh mục này</asp:HyperLink>
 | 
                                        <asp:HyperLink ID="btnSua" runat="server" Height="23px" NavigateUrl='<%# "~/admin-us/danh-muc/details.aspx?id=" +Eval("maDanhMuc")%>' ToolTip="Sửa">Sửa</asp:HyperLink>

                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>


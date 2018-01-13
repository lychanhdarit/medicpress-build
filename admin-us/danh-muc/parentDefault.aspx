<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="parentDefault.aspx.cs" Inherits="admin_us_pages_danh_muc_Default" EnableEventValidation="false" %>

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
                    <div class="box-header" id="box_manager" runat="server">
                        <asp:Button ID="Button1" runat="server" OnClick="btnXoa_Click" Text="Xóa Vĩnh Viễn" CssClass="btn-orange" />
                        <asp:Button ID="btnDuyet" runat="server" Text="Active" OnClick="btnDuyet_Click" CssClass="btn-blue" />
                        <asp:Button ID="btnChuaDuyet" runat="server" Text="Xem Đã Xóa " OnClick="btnChuaDuyet_Click" CssClass="btn-blue" />
                    </div>
                    <div class="box-header">
                        <h3 class="box-title">Dữ liệu</h3>
                        <br />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn-blue" PostBackUrl="~/admin-us/danh-muc/details.aspx" />
                        <asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn-orange" OnClick="btnAn_Click" />
                        <div class="input-group" style="margin-top: 10px;">
                            <div class="input-group-addon">
                                Level 1
                                <i class="fa fa-search"></i>
                            </div>
                            <asp:DropDownList ID="ddlLevel1" runat="server" CssClass="form-control" Width="220" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlLevel1_SelectedIndexChanged"></asp:DropDownList>
                            <div class="input-group-addon">
                                Level ..
                                <i class="fa fa-search"></i>
                            </div>
                            <asp:DropDownList ID="ddlDanhMuc" runat="server" CssClass="form-control" Width="220" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddlDanhMuc_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <asp:GridView ID="grvTaskNew" runat="server"
                            AutoGenerateColumns="False" Width="100%" EmptyDataText="No data"
                            ShowHeaderWhenEmpty="True" PageSize="15"
                            AllowSorting="True" AllowPaging="True" CssClass="table table-bordered table-hover" OnPageIndexChanging="grvTaskNew_PageIndexChanging" OnRowDataBound="grvTaskNew_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" Height="40px" runat="server" ImageUrl='<%# "~/uploadFile/DanhMuc/" + Eval("Images") %>' ToolTip='<%# Eval("Images") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" Checked="false" CssClass='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Trạng thái" SortExpression="IsActived">
                                    <ItemTemplate>
                                        <%# Eval("isActived").ToString().ToLower() == "false" ? "<span class='span-tb' >Đã xóa!</span> ": "<span class='span-tb-green' >Hoạt động!</span>" %>
                                    </ItemTemplate>
                                    <ItemStyle Width="100" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tiêu Đề" SortExpression="TieuDe">
                                    <ItemTemplate>
                                        <asp:Label ID="lbTD" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Thuộc Loại">
                                    <ItemTemplate>
                                        <asp:Label ID="lbisPatient" runat="server" CssClass='<%# Eval("isPatient") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User" SortExpression="username">
                                    <ItemTemplate>
                                        <asp:Label ID="lbNguoiDang" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                                        /
                                        <asp:Label ID="lbUserEdit" runat="server" Text='<%# Eval("userEdit") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chức năng">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="btnXem" runat="server" Height="23px" Target="_blank" NavigateUrl='<%# "~/"+Eval("code").ToString()+".hxml" %>' ToolTip="Sửa">Xem trước</asp:HyperLink>
                                        |
                                        <asp:HyperLink ID="btnSua" runat="server" Height="23px" NavigateUrl='<%# "~/admin-us/danh-muc/details.aspx?id=" +Eval("id")%>' ToolTip="Sửa">Sửa</asp:HyperLink>
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


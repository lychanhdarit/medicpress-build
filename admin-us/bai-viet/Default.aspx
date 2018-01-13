<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_pages_danh_muc_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        select {
            padding: 10px;
            border: 1px solid #f3f3f3;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Bài viết
        </h1>
         <asp:Label ID="lbE" runat="server" ForeColor="#CC0000"></asp:Label>

    </section>
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">

                    <div class="box-header">
                    
                        <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" PostBackUrl="~/admin-us/bai-viet/details.aspx" CssClass="btn-blue" />
                    </div>
                    <div class="search">

                        <table>
                            <tr>
                                <td></td>
                                <td>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-search"></i>
                                        </div>
                                        <asp:DropDownList ID="ddlLoai" runat="server" CssClass="form-control" Width="220" DataTextField="Name" DataValueField="id" AutoPostBack="true" OnSelectedIndexChanged="ddlLoai_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div class="input-group">

                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Width="320px" placeholder="Nhập từ khóa:"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <asp:Button ID="btnTim" runat="server" Text="Tìm" OnClick="btnTim_Click" CssClass="btn-orange" />
                                </td>
                                <td>
                                    <asp:Button ID="btnChuaDuyet" runat="server" Text="Xem tất cả bản nháp " OnClick="btnChuaDuyet_Click" CssClass="btn-blue" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        
                        <div class="box-header" id="box_manager" runat="server">
                            <asp:CheckBox ID="chk" runat="server" Text="Chọn tất cả" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" />
                            <asp:Button ID="btnXoa" runat="server" OnClick="btnXoa_Click" Text="Xóa" CssClass="btn-orange" />
                            <asp:Button ID="btnAn" runat="server" Text="Chuyển về bản nháp" CssClass="btn-orange" OnClick="btnAn_Click" />
                            <asp:Button ID="btnDuyet" runat="server" Text="Đăng bản nháp" OnClick="btnDuyet_Click" CssClass="btn-blue" />

                        </div>
                        <asp:GridView ID="grvTaskNew" runat="server"
                            AutoGenerateColumns="False" Width="100%" EmptyDataText="No data"
                            ShowHeaderWhenEmpty="True" PageSize="15"
                            AllowSorting="True" AllowPaging="True" CssClass="table table-bordered table-hover" OnPageIndexChanging="grvTaskNew_PageIndexChanging" OnSorting="grvTaskNew_Sorting" OnRowDataBound="grvTaskNew_RowDataBound" OnRowCommand="grvTaskNew_RowCommand">
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
                                <asp:TemplateField HeaderText="Trạng_thái" SortExpression="IsActived">
                                    <ItemTemplate>
                                        <%# Eval("isActived").ToString().ToLower() == "false" ? "<span class='label label-danger'>Bản nháp</span> ": "<span class='label label-success' >Đã đăng!</span>" %>
                                    </ItemTemplate>
                                    <ItemStyle Width="50" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tiêu_Đề" SortExpression="TieuDe">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lbTieuDe" runat="server" Height="23px" Target="_blank" NavigateUrl='<%# "~/" +Eval("url")%>' ToolTip="Click xem bai" Text='<%# Eval("TieuDe") %>'></asp:HyperLink>

                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày Đăng">
                                    <ItemTemplate>
                                        <asp:Label ID="lbHoBN" runat="server" Text='<%# Eval("NgayDang") %>'></asp:Label>
                                    </ItemTemplate>
                                   <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <%--
                                <asp:TemplateField HeaderText="User" SortExpression="username">
                                    <ItemTemplate>
                                        <asp:Label ID="lbNguoiDang" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                                        /
                                        <asp:Label ID="lbUserEdit" runat="server" Text='<%# Eval("userEdit") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                --%>
                                <asp:TemplateField HeaderText="Danh mục" SortExpression="maloai">
                                    <ItemTemplate>
                                        <asp:Label ID="lbLoai" runat="server" Text='<%# Eval("maloai") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle />
                                    <ItemStyle Width="130px" />
                                </asp:TemplateField>
                             <%--   <asp:TemplateField HeaderText="B_L_Q">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hpBLQ" runat="server" Height="23px" NavigateUrl='<%# "~/admin-us/bai-lien-quan/?id=" +Eval("id")%>' ToolTip="Bài liên quan">Mở</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="btnLock" runat="server" CssClass='<%# Eval("isactived").ToString().ToLower() == "true" ? "btn-blue" : "btn-orange"  %>' Height="25px" CommandName='<%# Eval("isactived").ToString().ToLower() == "true" ? "del-actived" : "actived"  %>' CommandArgument='<%# Eval("id") %>' Text='<%# Eval("isactived").ToString().ToLower() == "true" ? "Chuyển về bản nháp" : "Đăng bản nháp"  %>' ToolTip='<%# Eval("isactived").ToString().ToLower() == "true" ? "Bấm chuyển về bản nháp" : "Đăng bản nháp"  %>' />
                                        |--%>
                                        <asp:HyperLink ID="HyperLink1" CssClass="btn-xemtruoc" runat="server" Height="23px" NavigateUrl='<%# "~/admin-us/bai-viet/previews.aspx?indexauto=" +Eval("id")%>' ToolTip="Xem trước" Target="_blank">Xem trước</asp:HyperLink>
                                        |
                                        <asp:HyperLink ID="btnSua" runat="server" CssClass="btn-sua" Height="23px" NavigateUrl='<%# "~/admin-us/bai-viet/details.aspx?id=" +Eval("id")%>' ToolTip="Sửa">Sửa</asp:HyperLink>
                                        <%-- | 
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn-orange" Height="25px" CommandName="del" CommandArgument='<%# Eval("id") %>' Text="Xóa" ToolTip="Xóa" />--%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" EnableEventValidation="false" Inherits="admin_us_quan_ly_tai_khoan_Default"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <section class="content-header">
        <h1>Danh sách tài khoản
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Forms</a></li>
            <li class="active">Editors</li>
            <li>
                <asp:Label ID="lbE" runat="server" ForeColor="#CC0000" Font-Bold="true"></asp:Label></li>

        </ol>
    </section>
    <div class="box-body">
        <asp:Button ID="btnThem" runat="server" Text="Tạo tài khoản" PostBackUrl="~/admin-us/quan-ly-tai-khoan/CreateUser.aspx" CssClass="btn-orange"/>
        <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" CssClass="btn-orange" Enabled="false" Visible="false"/>
        <div class="grid" style="margin-top:20px;">
            <asp:GridView ID="grvTaskNew" runat="server"
                AutoGenerateColumns="False" Width="100%" EmptyDataText="No data" DataKeyNames="username"
                ShowHeaderWhenEmpty="True" PageSize="15"
                AllowSorting="True" AllowPaging="True" OnRowDataBound="grDataTinh_RowDataBound" CssClass="table table-bordered table-hover" OnSelectedIndexChanged="grDataTinh_SelectedIndexChanged" OnRowCommand="grvTaskNew_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Chọn">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkChon" runat="server" CssClass='<%# Eval("username") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="50" ImageUrl='<%# Eval("URLImages").ToString() == "" ?"~/admin-us/upload/user/noimg.png" : "~/admin-us/upload/user/" + Eval("URLImages") %>' />
                            
                        </ItemTemplate>
                         <ItemStyle VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên Người Dùng" SortExpression="TieuDe">
                        <ItemTemplate>
                            <asp:Label ID="lbKey" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Họ Tên" SortExpression="Code">
                        <ItemTemplate>
                            <asp:Label ID="lbLink" runat="server" Text='<%# Eval("hoten") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quyền Admin">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAdmin" runat="server" Checked='<%# Eval("isAdmin") != null? Eval("isAdmin") : null %>' />
                        </ItemTemplate>
                         <ItemStyle VerticalAlign="Middle" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Xem">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1"  runat="server"  Height="22px" PostBackUrl='<%# "~/admin-us/quan-ly-tai-khoan/info-acc.aspx?user=" + Eval("username") %>'  ImageUrl="~/admin-us/img-action/view.png" ToolTip="Xem thông tin tài khoản"/>
                            <asp:ImageButton ID="btnHistory"  runat="server"  Height="25px" PostBackUrl='<%# "~/admin-us/quan-ly-tai-khoan/history.aspx?user=" + Eval("username") %>'  ImageUrl="~/admin-us/img-action/history.png" ToolTip="Lịch sử hoạt động"/>
                        </ItemTemplate>
                          <ItemStyle VerticalAlign="Middle" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>

                            <asp:ImageButton ID="btnResetpass"  runat="server" Height="25px" CommandName="changepass" CommandArgument='<%# Eval("username") %>' ImageUrl="~/admin-us/img-action/password-reset.png" ToolTip="Reset Mật Khẩu"/>
                            
                            <asp:ImageButton ID="btnLock"  runat="server"  Height="25px" CommandName='<%# Eval("isactived").ToString().ToLower() == "true" ? "lock" : "unlock"  %>' CommandArgument='<%# Eval("username") %>'  ImageUrl='<%# Eval("isactived").ToString().ToLower() == "true" ? "~/admin-us/img-action/unlock.png" : "~/admin-us/img-action/lock.png"  %>' ToolTip='<%# Eval("isactived").ToString().ToLower() == "true" ? "click lock account" : "click unlock account"  %>'/>
                            
                            <asp:ImageButton ID="btnEdit"  runat="server"  Height="25px" PostBackUrl='<%# "~/admin-us/quan-ly-tai-khoan/Details.aspx?user=" + Eval("username") %>'  ImageUrl="~/admin-us/img-action/edit.png" ToolTip="Sửa "/>
                        </ItemTemplate>
                          <ItemStyle VerticalAlign="Middle" />
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
                    
                    <asp:TemplateField HeaderText="Tỉnh" SortExpression="Code">
                        <ItemTemplate>
                            <asp:Label ID="lbTinh" runat="server" Text='<%# Eval("tinh") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <asp:Button ID="Button1" runat="server" Text="Tạo tài khoản" PostBackUrl="~/admin-us/quan-ly-tai-khoan/CreateUser.aspx" CssClass="btn-orange"/>
        <asp:Button ID="Button2" runat="server" Text="Xóa" OnClick="btnXoa_Click" CssClass="btn-orange" Enabled="false" Visible="false"/>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="History.aspx.cs" Inherits="admin_us_quan_ly_tai_khoan_History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>
            Lịch sử hoạt động
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
        <div class="box-header">
            <asp:HyperLink ID="btnQuayVe" runat="server" Text="<< Danh sách tài khoản" NavigateUrl="~/admin-us/quan-ly-tai-khoan/" CssClass="btn-back" />
        </div>
        <asp:Button ID="btnXEM" runat="server" Text="Xem Profile" Visible="false" />
        <div class="grid">
            <asp:GridView ID="grvTaskNew" runat="server"
                AutoGenerateColumns="False" Width="100%" EmptyDataText="No data" DataKeyNames="username"
                ShowHeaderWhenEmpty="True" PageSize="100"
                AllowSorting="True" AllowPaging="True" CssClass="table table-bordered table-hover">
                <Columns>

                    <asp:TemplateField HeaderText="Tên Người Dùng" SortExpression="username">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/admin-us/quan-ly-tai-khoan/history.aspx?user="+ Eval("username") %>' runat="server" Text='<%# Eval("username") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hoạt động" SortExpression="NameAction">
                        <ItemTemplate>
                            <asp:Label ID="lbNameAction" runat="server" Text='<%# Eval("NameAction") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thời Gian" SortExpression="ActionTime">
                        <ItemTemplate>
                            <asp:Label ID="lbActionTime" runat="server" Text='<%# Eval("ActionTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </section>
</asp:Content>


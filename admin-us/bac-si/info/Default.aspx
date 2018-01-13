<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_rv_danh_muc_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Danh Mục</h1>
    
    <div class="">
         <asp:Button ID="btnThem" runat="server" Text="Thêm mới" PostBackUrl="~/admin-us/bac-si/info/Details.aspx"/>
        <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" />
        <div class="grid">
            <asp:GridView ID="grvTaskNew" runat="server"
                AutoGenerateColumns="False" Width="100%" EmptyDataText="No data" DataKeyNames="id"
                ShowHeaderWhenEmpty="True" PageSize="15"
                AllowSorting="True" AllowPaging="True" OnRowDataBound="grDataTinh_RowDataBound" OnSelectedIndexChanged="grDataTinh_SelectedIndexChanged" OnPageIndexChanging="grvTaskNew_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Chọn">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkChon" runat="server" CssClass='<%# Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên" SortExpression="Ten">
                        <ItemTemplate>
                            <asp:Label ID="lbKey" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" SortExpression="Code">
                        <ItemTemplate>
                            <asp:Label ID="lbLink" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chuyen Khoa" SortExpression="Code">
                        <ItemTemplate>
                            <asp:Label ID="lbChuyenKhoa" runat="server" Text='<%# Eval("idChuyenKhoa") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Chức năng">
                        <ItemTemplate>
                            <asp:HyperLink ID="btnSua" runat="server" Height="23px" NavigateUrl='<%# "~/admin-us/bac-si/info/details.aspx?id=" +Eval("id")%>' ToolTip="Sửa">Sửa</asp:HyperLink>
                             <asp:HyperLink ID="HyperLink1" runat="server" Height="23px" NavigateUrl='<%# "~/admin-us/bac-si/lich/default.aspx?id=" +Eval("id")%>' ToolTip="Sửa">Xem Lịch</asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>


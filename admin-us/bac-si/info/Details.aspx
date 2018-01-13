<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="admin_tk_danh_muc_Details" ValidateRequest = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Cập Nhật Danh Mục</h1>
    <div class="admin">
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbE" runat="server" ForeColor="#CC0000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>ID
                </td>

                <td>
                    <asp:TextBox ID="txtID" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Họ Tên
                </td>

                <td>
                    <asp:TextBox ID="txtTen" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>Username 
                </td>

                <td>
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Mật khẩu
                </td>

                <td>
                    <asp:TextBox ID="txtMatkhau" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>Email
                </td>

                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Điện Thoại
                </td>

                <td>
                    <asp:TextBox ID="txtDienThoai" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>Địa chỉ
                </td>

                <td>
                    <asp:TextBox ID="txtDiaChi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Chuyên khoa:
                </td>

                <td>
                    <asp:DropDownList ID="ddlChuyenKhoa" DataTextField="name" DataValueField="Id" runat="server">
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" Text="Trở về" OnClick="btnThem_Click" />
                    <asp:Button ID="btnCapNhat" runat="server" Text="Lưu" OnClick="btnCapNhat_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


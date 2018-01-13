<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Register.ascx.cs" Inherits="Share_layout_Register" %>
<link rel="stylesheet" href="http://code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">

<%--<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>--%>
<script>
    $(function () {
        $("#txtNgayHen").datepicker();
    });
</script>
<div class="grid-row">
    <div class="grid-col grid-col-6 window">
        <!-- widget Story -->
        <div class="widget widget-story">
            <div class="widget-title">
                <h3>Đăng ký thông tin tư vấn & đặt hẹn.</h3>
            </div>
            <div class="row dat-item">
                <h3>Đặt hẹn vì quyền lợi của bạn</h3>
                <ul>
                    <li>1. Không mất thời gian chờ đợi.
                    </li>
                    <li>2. Quy trình & thủ tục được tiến hành nhanh chóng.
                    </li>
                    <li>3. Được Bác sĩ tư vấn và thăm khám chuyên sâu.
                    </li>
                    <li>4. Tiết kiệm: <b>THỜI GIAN - CÔNG SỨC - TIỀN BẠC</b>
                    </li>
                    <li>
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/listDoctor/" runat="server">Xem lịch Bác sĩ</asp:HyperLink>
                    </li>
                </ul>
            </div>
        </div>
        <!-- widget Story -->
    </div>
    <div class="grid-col grid-col-6">
        <!-- appointment -->
        <section class="widget widget-appointment">
            <div class="widget-title">Đặt lịch hẹn</div>
            <form action="#">
                <div class="row">
                    <asp:TextBox ID="txtHoTen" runat="server" Height="50px" Width="100%" placeholder="Họ tên"></asp:TextBox>
                    <i class="fa fa-user"></i>
                </div>
                <div class="row">
                    <asp:TextBox ID="txtSoDienThoai" runat="server" Height="50px" Width="100%" placeholder="Số điện thoại"></asp:TextBox>
                    <i class="fa fa-phone"></i>
                </div>
                <div class="row">
                    <asp:TextBox ID="txtEmail" runat="server" Height="50px" Width="100%" placeholder="Địa chỉ email"></asp:TextBox>
                    <i class="fa fa-envelope"></i>
                </div>
                <div class="row">
                    <asp:TextBox ID="txtNgayHen" ClientIDMode="Static" runat="server" Height="50px" Width="100%" placeholder="Ngày hẹn"></asp:TextBox>
                    <i class="fa fa-calendar"></i>
                </div>
                <div class="row">
                    <asp:TextBox ID="txtLoiNhan" runat="server" Height="50px" Width="100%" placeholder="Lời nhắn (Ví dụ: tôi đặt hẹn lúc 9h30, ...)" cols="30" Rows="5" CssClass="textarea"></asp:TextBox>
                    <i class="fa fa-align-left"></i>
                </div>
                <asp:Button ID="btnDatLich" runat="server" Text="Đặt lịch" OnClick="btnDatLich_Click" class="button button-primary" />
            </form>
        </section>
        <!--/ appointment -->
    </div>
</div>

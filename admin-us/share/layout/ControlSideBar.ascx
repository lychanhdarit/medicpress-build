<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlSideBar.ascx.cs" Inherits="admin_us_share_layout_ControlSideBar" %>
<aside class="control-sidebar control-sidebar-dark">
    <!-- Create the tabs -->
    <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
        <li><a href="#control-sidebar-home-tab" data-toggle="tab"><i class="fa fa-home"></i></a></li>
        <li><a href="#control-sidebar-settings-tab" data-toggle="tab"><i class="fa fa-gears"></i></a></li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <!-- Home tab content -->
        <!-- Settings tab content -->
        <div class="tab-pane" id="control-sidebar-settings-tab">
            <form method="post">
                <h3 class="control-sidebar-heading">General Settings</h3>
                <div class="form-group">
                    <label class="control-sidebar-subheading">
                        <asp:HyperLink ID="hpOut" runat="server" NavigateUrl="~/admin-us/account/login.aspx">Đăng xuất</asp:HyperLink>
                    </label>
                    <p>
                        Đăng nhập lại hoặc thoát khỏi hệ thống.
                    </p>
                </div>
                <!-- /.form-group -->

                <div class="form-group">
                    <label class="control-sidebar-subheading">

                        <asp:HyperLink ID="hpDoiMK" runat="server" NavigateUrl="~/admin-us/quan-ly-tai-khoan/doi-mat-khau.aspx">Đổi mật khẩu</asp:HyperLink>
                    </label>
                    <p>
                        Thay đổi mật khẩu mới cho tài khoản này.
                    </p>
                </div>
                <!-- /.form-group -->

                <div class="form-group">
                    <label class="control-sidebar-subheading">

                        <asp:HyperLink ID="hpAdmin" runat="server" NavigateUrl="~/admin-us/quan-ly-tai-khoan/">Quản lý các tài khoản</asp:HyperLink>
                    </label>
                    <p>
                        <asp:Literal ID="ltAdmin" runat="server" Text=" Quản lý các tài khoản trong hệ thống"></asp:Literal>

                    </p>
                </div>
                <!-- /.form-group -->

               
                <!-- /.form-group -->
            </form>
        </div>
        <!-- /.tab-pane -->
    </div>
</aside>

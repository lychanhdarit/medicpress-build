<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Read.aspx.cs" Inherits="admin_us_tu_van_Read" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Read Mail
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Mailbox</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-md-3">
                <a href="compose.html" class="btn btn-primary btn-block margin-bottom">Compose</a>
                <div class="box box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">Folders</h3>
                        <div class="box-tools">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <div class="box-body no-padding">
                        <ul class="nav nav-pills nav-stacked">
                            <li class="active"><a href="~/admin-us/tu-van/" runat="server" id="a_tuvan"><i class="fa fa-inbox"></i>Inbox <span class="label label-primary pull-right">12</span></a></li>
                            <li><a href="#"><i class="fa fa-envelope-o"></i>Sent</a></li>
                            <li><a href="#"><i class="fa fa-file-text-o"></i>Drafts</a></li>
                            <li><a href="#"><i class="fa fa-filter"></i>Junk <span class="label label-warning pull-right">65</span></a></li>
                            <li>
                                <asp:LinkButton ID="lkTrash" runat="server" PostBackUrl="~/admin-us/tu-van/default.aspx?idcmt=trash"><i class="fa fa-trash-o"></i>Trash</asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /. box -->
                <div class="box box-solid">
                    <div class="box-header with-border">
                        <h3 class="box-title">Trạng thái</h3>
                        <div class="box-tools">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <div class="box-body no-padding">
                        <ul class="nav nav-pills nav-stacked">
                           
                            <li>
                                <asp:LinkButton ID="lbDangCho" runat="server" PostBackUrl="~/admin-us/tu-van/?idStatus=1"><i class="fa fa-circle-o text-yellow"></i>Đang chờ ...</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lbDangXL" runat="server" PostBackUrl="~/admin-us/tu-van/?idStatus=2"><i class="fa fa-circle-o text-light-blue"></i>Đang xử lý ...</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lbKhachDY" runat="server" PostBackUrl="~/admin-us/tu-van/?idStatus=3"><i class="fa fa-circle-o text-green"></i>Khách đồng ý</asp:LinkButton>
                            </li>
                             <li>
                                <asp:LinkButton ID="lbKhachHuy" runat="server" PostBackUrl="~/admin-us/tu-van/?idStatus=4"><i class="fa fa-circle-o text-red"></i>Khách hủy</asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
            <div class="col-md-9">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Read Mail</h3>
                        <div class="box-tools pull-right">
                            <a href="#" class="btn btn-box-tool" data-toggle="tooltip" title="Previous"><i class="fa fa-chevron-left"></i></a>
                            <a href="#" class="btn btn-box-tool" data-toggle="tooltip" title="Next"><i class="fa fa-chevron-right"></i></a>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <div class="mailbox-read-info">
                            <h3>
                                <asp:Label ID="txtSkype" runat="server" Text=""></asp:Label></h3>
                            <h5>From:
                                <asp:Label ID="txtEmail" runat="server" Text=""></asp:Label>
                                <span class="mailbox-read-time pull-right">
                                    <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label></span></h5>
                            <h5>
                               Điện thoại: <asp:Label ID="txtDienThoai" runat="server" Text="Label"></asp:Label></h5>
                            <h5>
                              Địa chỉ:  <asp:Label ID="txtDiaChi" runat="server" Text=""></asp:Label></h5>
                        </div>
                        <!-- /.mailbox-read-info -->
                        <div class="mailbox-controls with-border text-center">
                            <div class="btn-group">
                                <button class="btn btn-default btn-sm" data-toggle="tooltip" title="Delete"><i class="fa fa-trash-o"></i></button>
                                <button class="btn btn-default btn-sm" data-toggle="tooltip" title="Reply"><i class="fa fa-reply"></i></button>
                                <button class="btn btn-default btn-sm" data-toggle="tooltip" title="Forward"><i class="fa fa-share"></i></button>
                            </div>
                            <!-- /.btn-group -->
                            <button class="btn btn-default btn-sm" data-toggle="tooltip" title="Print"><i class="fa fa-print"></i></button>
                        </div>
                        <!-- /.mailbox-controls -->
                        <div class="mailbox-read-message" style="padding: 10px;border-radius: 10px;background: #F1EFA7; width: 95%;margin:10px;" >
                            <asp:Label ID="txtNoiDung" runat="server" Text=""></asp:Label>
                        </div>
                        <!-- /.mailbox-read-message -->
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer">
                        <asp:LinkButton ID="lbChot" CssClass="btn-orange" runat="server" OnClick="lbChot_Click"><i class="fa fa-reply"></i> Chốt khách</asp:LinkButton>
                        <asp:LinkButton ID="lbKOChot" CssClass="btn-blue" runat="server" OnClick="lbKOChot_Click"><i class="fa fa-share"></i> Khách không chốt</asp:LinkButton>

                    </div>
                    <!-- /.box-footer -->
                    <div class="box-footer">
                        <div class="pull-right">
                            <button class="btn btn-default"><i class="fa fa-reply"></i>Reply</button>
                            <button class="btn btn-default"><i class="fa fa-share"></i>Forward</button>
                        </div>
                        <button class="btn btn-default"><i class="fa fa-trash-o"></i>Delete</button>
                        <button class="btn btn-default"><i class="fa fa-print"></i>Print</button>
                    </div>
                    <!-- /.box-footer -->
                </div>
                <!-- /. box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_tu_van_Default"  EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        table td {
            border:none
        }
         table  {
            border:none
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Mailbox
            <small>13 new messages</small>
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
                                <asp:LinkButton ID="lbDangCho" runat="server" PostBackUrl="~/admin-us/tu-van/?idStatus=1"><i class="fa fa-circle-o text-yellow"></i>Đang chờ.</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lbDangXL" runat="server" PostBackUrl="~/admin-us/tu-van/?idStatus=2"><i class="fa fa-circle-o text-light-blue"></i>Đang xử lý.</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lbKhachDY" runat="server" PostBackUrl="~/admin-us/tu-van/?idStatus=3"><i class="fa fa-circle-o text-green"></i>Khách Đồng Ý</asp:LinkButton>
                            </li>
                             <li>
                                <asp:LinkButton ID="lbKhachHuy" runat="server" PostBackUrl="~/admin-us/tu-van/?idStatus=4"><i class="fa fa-circle-o text-red"></i>Khách Hủy</asp:LinkButton>
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
                        <h3 class="box-title">Inbox</h3>
                        <div class="box-tools pull-right">
                            <div class="has-feedback">
                                <input type="text" class="form-control input-sm" placeholder="Search Mail">
                                <span class="glyphicon glyphicon-search form-control-feedback"></span>
                            </div>
                        </div>
                        <!-- /.box-tools -->
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body no-padding">
                        <div class="mailbox-controls">
                            <!-- Check all button -->
                            <button class="btn btn-default btn-sm checkbox-toggle"><i class="fa fa-square-o"></i></button>
                            <div class="btn-group">
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnXoa_Click" ><i class="fa fa-trash-o"></i></asp:LinkButton>
                                <button class="btn btn-default btn-sm"><i class="fa fa-reply"></i></button>
                                <button class="btn btn-default btn-sm"><i class="fa fa-share"></i></button>
                            </div>
                            <!-- /.btn-group -->
                            <button class="btn btn-default btn-sm"><i class="fa fa-refresh"></i></button>
                            <div class="pull-right">
                                1-50/200
                     
                                <div class="btn-group">
                                    <button class="btn btn-default btn-sm"><i class="fa fa-chevron-left"></i></button>
                                    <button class="btn btn-default btn-sm"><i class="fa fa-chevron-right"></i></button>
                                </div>
                                <!-- /.btn-group -->
                            </div>
                            <!-- /.pull-right -->
                        </div>
                        <div class="table-responsive mailbox-messages">
                            <asp:GridView ID="grvTaskNew" runat="server" CssClass="table table-hover table-striped"
                                AutoGenerateColumns="False" Width="100%"  EmptyDataText="No data" DataKeyNames="id"
                                ShowHeaderWhenEmpty="True" PageSize="15"
                                AllowSorting="True" AllowPaging="True" ShowHeader="false" OnRowDataBound="grDataTinh_RowDataBound" OnSelectedIndexChanged="grDataTinh_SelectedIndexChanged" OnPageIndexChanging="grvTaskNew_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" Checked="false" CssClass='<%# Eval("id") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <a href="#"><i class="fa fa-star text-yellow"></i></a>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" CssClass="mailbox-star" />
                                        <HeaderStyle CssClass="mailbox-star" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Label ID="ltStatus" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Họ tên">
                                        <ItemTemplate>
                                            <asp:Label ID="lbKey" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle CssClass="mailbox-name"  />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nội dung">
                                        <ItemTemplate>
                                            <asp:HyperLink NavigateUrl='<%# "~/admin-us/tu-van/read.aspx?id=" + Eval("id") %>' ID="lbNOIDUNG" runat="server" Text='<%# Eval("noidung").ToString().Length > 50? Eval("noidung").ToString().Substring(0,50)+"...": Eval("noidung").ToString() %>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="mailbox-subject" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Thời Gian">
                                        <ItemTemplate>
                                            <asp:Label ID="lbTime" runat="server" Text='<%# Eval("time") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="mailbox-date" />
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Điện Thoại" SortExpression="Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lbLink" runat="server" Text='<%# Eval("dienthoai") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="mailbox-attachment" />
                                    </asp:TemplateField>
                                  
                                </Columns>
                            </asp:GridView>
                           
                            <!-- /.table -->
                        </div>
                        <!-- /.mail-box-messages -->
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer no-padding">
                        <div class="mailbox-controls">
                            <!-- Check all button -->
                            <button class="btn btn-default btn-sm checkbox-toggle"><i class="fa fa-square-o"></i></button>
                            <div class="btn-group">
                                <button class="btn btn-default btn-sm"><i class="fa fa-trash-o"></i></button>
                                <button class="btn btn-default btn-sm"><i class="fa fa-reply"></i></button>
                                <button class="btn btn-default btn-sm"><i class="fa fa-share"></i></button>
                            </div>
                            <!-- /.btn-group -->
                            <button class="btn btn-default btn-sm"><i class="fa fa-refresh"></i></button>
                            <div class="pull-right">
                                1-50/200
                     
                                <div class="btn-group">
                                    <button class="btn btn-default btn-sm"><i class="fa fa-chevron-left"></i></button>
                                    <button class="btn btn-default btn-sm"><i class="fa fa-chevron-right"></i></button>
                                </div>
                                <!-- /.btn-group -->
                            </div>
                            <!-- /.pull-right -->
                        </div>
                    </div>
                </div>
                <!-- /. box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->
</asp:Content>


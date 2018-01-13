<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_menu_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Cập Nhật Menu
           
            <small>Advanced form element</small>
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
        <div class="row">
            <div class="col-md-6">
                <div class="box box-danger">
                    <div class="box-header">
                        <h3 class="box-title">Nhập dữ liệu</h3>
                    </div>
                    <div class="box-body">
                        <!-- Date dd/mm/yyyy -->
                        <div class="form-group">
                            <label>ID:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-lock"></i>
                                </div>
                                <asp:TextBox ID="txtID" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->

                        <!-- Date mm/dd/yyyy -->

                        <!-- phone mask -->
                        <div class="form-group">
                            <label>Tên Hiện Thị:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->

                        <!-- phone mask -->
                        <div class="form-group">
                            <label>
                                Đường dẫn:
                                <asp:Label ID="lbService" runat="server" Text=""></asp:Label></label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-link"></i>
                                </div>
                                <asp:TextBox ID="txtURL" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>
                                Vị trí:
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></label>
                            <div class="input-group">

                                <asp:TextBox ID="txtIndex" runat="server" CssClass="form-control" TextMode="Number">0</asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                        <div class="form-group">
                            <label>Thuộc menu:</label>

                            <asp:DropDownList ID="ddlparent" runat="server" CssClass="form-control select2" Width="100%" DataValueField="ID" DataTextField="Name" OnSelectedIndexChanged="ddlparent_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Kiểu hiện thị:</label>

                            <asp:DropDownList ID="ddlKieu" runat="server" CssClass="form-control select2" Width="100%" Visible="true"></asp:DropDownList>
                        </div>
                        <!-- /.form-group -->
                        <!-- IP mask -->
                        <div class="form-group">
                            <label>Hiện thị:</label>
                            <br />
                            <label>
                                <asp:RadioButton ID="rdhienthi" runat="server" CssClass="minimal" GroupName="hienthi" Checked="true" Text="On" />
                            </label>
                            <label>
                                <asp:RadioButton ID="rdkhonghienthi" runat="server" CssClass="minimal" GroupName="hienthi" Text="Off" />
                            </label>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnThem" runat="server" Text="Thêm mới" OnClick="btnThem_Click" CssClass="btn-b" />
                            <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" CssClass="btn-h" />
                            <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" CssClass="btn-b" />
                        </div>
                    </div>


                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Chọn dữ liệu từ danh mục</h3>
                    </div>
                    <div class="box-body">
                        <!-- Date range -->
                        <div class="form-group" style="display: none">
                            <label>Mục 0:</label>

                            <asp:DropDownList ID="ddlDanhMuc" runat="server" DataTextField="tenDanhMuc" DataValueField="maDanhMuc" CssClass="form-control select2" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlDanhMuc_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Mục 1:</label>

                            <asp:DropDownList ID="ddlMuc1" runat="server" DataTextField="name" DataValueField="id" CssClass="form-control select2" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlMuc1_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Mục con:</label>

                            <asp:DropDownList ID="ddlMucCon" runat="server" DataTextField="name" DataValueField="id" CssClass="form-control select2" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnChon" runat="server" Text="Chọn" OnClick="btnChon_Click" CssClass="btn-y" />
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->

                <!-- iCheck -->

            </div>
            <!-- /.col (right) -->
        </div>
    </section>
    <div class="admin-c-r">

        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">

                        <div class="box-body">
                            <!-- /.box-header -->
                            <div class="form-group">
                                <label>Chọn mục:</label>

                                <asp:DropDownList ID="ddlmenu" runat="server" DataTextField="name" DataValueField="id" CssClass="form-control select2" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlmenu_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="input-group" style="margin-top: 10px;">
                                <div class="input-group-addon">
                                    <i class="fa fa-search"></i>
                                </div>
                                <asp:TextBox ID="txtSearch" CssClass="form-control" Width="220" runat="server" placeholder="nhập từ khóa có dấu"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-blue" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <div class="box-body">
                            <asp:CheckBox ID="checkAll" runat="server" Text="Chọn tất cả" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" />
                            <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" CssClass="btn-b" />
                            <asp:GridView ID="grvTaskNew" runat="server"
                                AutoGenerateColumns="False" EmptyDataText="No data" DataKeyNames="id"
                                ShowHeaderWhenEmpty="True" PageSize="15"
                                AllowSorting="True" AllowPaging="True" OnPageIndexChanging="grvTaskNew_PageIndexChanging" CssClass="table table-bordered table-hover" OnRowCommand="grvTaskNew_RowCommand" OnRowDataBound="grDataTinh_RowDataBound" OnSelectedIndexChanged="grDataTinh_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Chọn">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkChon" runat="server" CssClass='<%# Eval("id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lbKey" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tên">
                                        <ItemTemplate>
                                            <asp:Label ID="lbName" runat="server" Text='<%# Eval("isParent").ToString() !="0"?"--- "+Eval("name"):Eval("name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="URL">
                                        <ItemTemplate>
                                            <asp:Label ID="lbLink" runat="server" Text='<%# Eval("url") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hiện Thị">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lbisActived" runat="server" Checked='<%# Eval("isActived").ToString().ToLower() == "true"?true:false %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Menu Parent">
                                        <ItemTemplate>
                                            <asp:Label ID="lbisParent" runat="server" Text='<%# Eval("isParent") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dạng">
                                        <ItemTemplate>
                                            <asp:Label ID="lbstyleShow" runat="server" Text='<%# Eval("styleShow") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vị trí">
                                        <ItemTemplate>
                                            <asp:Label ID="lbnumberSort" runat="server" Text='<%# Eval("numberSort") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Di chuyển">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnUp" runat="server" Height="15px" CommandName="Up" CommandArgument='<%# Eval("ID").ToString() +"-"+ Eval("numberSort").ToString() +"-"+ Container.DataItemIndex %>' ImageUrl="~/admin-us/up.png" />
                                            <asp:ImageButton ID="btnDown" runat="server" Height="15px" CommandName="Down" CommandArgument='<%# Eval("ID").ToString() +"-"+ Eval("numberSort").ToString()+"-"+ Container.DataItemIndex %>' ImageUrl="~/admin-us/down.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div class="clear"></div>
</asp:Content>


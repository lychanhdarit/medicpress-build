<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_clips_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>RSS Groups
        </h1>

    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-danger">
                    <div class="box-body">

                        <!-- /.input form -->
                        <div class="form-group">
                            <label>ID:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-key" aria-hidden="true"></i>
                                </div>
                                <asp:TextBox ID="txtID" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>

                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->
                        <div class="form-group">
                            <label>Tên :</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-edit"></i>
                                </div>
                                <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->
                        <div class="form-group">
                            <label>Thẻ Title :</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                   <i class="fa fa-code" aria-hidden="true"></i>
                                </div>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->
                        <div class="form-group">
                            <label>Thẻ Desc :</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                   <i class="fa fa-code" aria-hidden="true"></i>
                                </div>
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->
                        <div class="form-group">
                            <label>Thẻ Nội dung :</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-code" aria-hidden="true"></i>
                                </div>
                                <asp:TextBox ID="txtContent" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->

                        <!-- /.input form -->
                        <div class="form-group">
                            <div class="input-group">
                                <asp:Button ID="btnThem" runat="server" Text="Thêm mới" OnClick="btnThem_Click" CssClass="btn-b" />
                                <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" CssClass="btn-h" />
                                <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" CssClass="btn-b" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Dữ liệu</h3>
                        <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" CssClass="btn-y" />
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="grid">
                            <asp:GridView ID="grvTaskNew" runat="server"
                                AutoGenerateColumns="False" EmptyDataText="No data" DataKeyNames="id"
                                ShowHeaderWhenEmpty="True" PageSize="15"
                                AllowSorting="True" AllowPaging="True" OnRowDataBound="grDataTinh_RowDataBound" CssClass="table table-bordered table-hover" OnSelectedIndexChanged="grDataTinh_SelectedIndexChanged">
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
                                            <asp:Label ID="lbName" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Title">
                                        <ItemTemplate>
                                            <asp:Label ID="lbTitle" runat="server" Text='<%# Eval("tagTitle") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Desc">
                                        <ItemTemplate>
                                            <asp:Label ID="lbDesc" runat="server" Text='<%# Eval("tagDesc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Content">
                                        <ItemTemplate>
                                            <asp:Label ID="lbContent" runat="server" Text='<%# Eval("tagContent") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


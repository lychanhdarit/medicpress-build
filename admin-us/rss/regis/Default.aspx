<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_clips_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1> RSS Feeds
        </h1>
       
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-danger">
                    <div class="box-body">
                         <div class="form-group">
                            <label>Đăng ký RSS cho: <span style="display:block;padding:5px 30px;border-radius:5px;border:1px dashed #ff6a00;background:#f3f3f3;text-transform:uppercase;margin-top:10px"><asp:Literal ID="ltName" runat="server"></asp:Literal></span> </label>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->
                        <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>
                        <div class="form-group">
                            <label>Group RSS:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-object-ungroup" aria-hidden="true"></i>
                                </div>
                                <asp:DropDownList ID="ddlGroup" runat="server" DataTextField="name" DataValueField="id" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->
                        <div class="form-group">
                            <label>Chọn RSS Feed:</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                   <i class="fa fa-key" aria-hidden="true"></i>
                                </div>
                                <asp:DropDownList ID="ddRSSFeeds" runat="server" DataTextField="name" DataValueField="id" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.input form -->
                      
                        <!-- /.input form -->
                        <div class="form-group">
                            <div class="input-group">
                                <asp:Button ID="btnThem" runat="server" Text="Thêm mới" OnClick="btnThem_Click" CssClass="btn-b" />
                                <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" CssClass="btn-h"/>
                                <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" CssClass="btn-b"/>
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
                        <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click"  CssClass="btn-y"/>
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
                                    <asp:TemplateField HeaderText="Danh mục">
                                        <ItemTemplate>
                                            <asp:Label ID="lbidloai" runat="server" Text='<%# Eval("idloai") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RSS Đã đăng ký">
                                        <ItemTemplate>
                                            <asp:Label ID="lbidRss" runat="server" Text='<%# Eval("idRss") %>'></asp:Label>
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


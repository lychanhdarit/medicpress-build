<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="loai.aspx.cs" Inherits="admin_us_clips_loai" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Chủ đề 
           
            <small>
                <asp:Label ID="lbE" runat="server" ForeColor="#CC0000"></asp:Label></small>
        </h1>

    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-danger">

                    <div class="box-body">
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
                        <!-- /.input form -->
                        <div class="form-group">
                            <label>Tên:</label>
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
                            <asp:Button ID="btnThem" runat="server" Text="Thêm mới" OnClick="btnThem_Click" CssClass="btn-b" />
                            <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" CssClass="btn-h" />
                            <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" CssClass="btn-b" />
                        </div>
                        <!-- /.input form -->
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">

                    <div class="box-body">
                        <div class="grid">
                            <asp:CheckBox ID="checkAll" runat="server" Text="Chọn tất cả" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" />
                            <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" CssClass="btn-b" />
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

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>


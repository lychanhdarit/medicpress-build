<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_comments_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
        <h1>Danh mục Comments
           
            <small>Advanced form element</small>

        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Forms</a></li>
            <li class="active">Editors</li>
            <li>
                <asp:Label ID="lbE" runat="server" ForeColor="#CC0000"></asp:Label></li>

        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="search">
                        <table>
                            <tr>
                                <td></td>
                                <td>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <i class="fa fa-search"></i>
                                        </div>
                                        <asp:DropDownList ID="ddlLoai" runat="server" CssClass="form-control" Width="220" DataTextField="Name" DataValueField="id" AutoPostBack="true" OnSelectedIndexChanged="ddlLoai_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div class="input-group">

                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Width="320px" placeholder="Nhập từ khóa:"></asp:TextBox>

                                    </div>
                                </td>
                                <td>
                                    <asp:Button ID="btnTim" runat="server" Text="Tìm" CssClass="btn-y " OnClick="btnTim_Click" />

                                    <asp:Button ID="btnViewAll" runat="server" Text="Xem Tất cả" OnClick="btnViewAll_Click" CssClass="btn-h" />
                                    <asp:Button ID="btnChuaDuyet" runat="server" Text="Xem Chưa Duyệt " OnClick="btnChuaDuyet_Click" CssClass="btn-b" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="box-header">
                            <asp:CheckBox ID="checkALL" runat="server" Text="Chọn tất cả" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" />
                            <asp:Button ID="btnDuyet" runat="server" Text="Duyệt" OnClick="btnDuyet_Click" CssClass="btn-blue" />
                            <asp:Button ID="btnAn" runat="server" Text="Không duyệt" CssClass="btn-orange" OnClick="btnAn_Click" />
                            <asp:Button ID="btnXoa" runat="server" OnClick="btnXoa_Click" Text="Xóa" CssClass="btn-orange" />
                        </div>
                        <asp:GridView ID="grvTaskNew" runat="server"
                            AutoGenerateColumns="False" Width="100%" EmptyDataText="No data"
                            ShowHeaderWhenEmpty="True" PageSize="15"
                            AllowSorting="True" AllowPaging="True" CssClass="table table-bordered table-hover" OnPageIndexChanging="grvTaskNew_PageIndexChanging" OnSorting="grvTaskNew_Sorting" OnRowDataBound="grvTaskNew_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" Checked="false" CssClass='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label ID="lbname" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="IsActived">
                                    <ItemTemplate>
                                        <%# Eval("isActived").ToString().ToLower() == "false" ? "<span class='label label-danger'>Chưa duyệt</span> ": "<span class='label label-success' >Đã duyệt!</span>" %>
                                    </ItemTemplate>
                                    <ItemStyle Width="50" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tin nhắn">
                                    <ItemTemplate>
                                        <asp:Label ID="lbPostmessage" runat="server" Text='<%# Eval("message") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bài viết" SortExpression="idPost">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lbPost" runat="server" Height="23px" Target="_blank" ToolTip="Click xem bai" Text='<%# Eval("idPost") %>'></asp:HyperLink>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thời gian">
                                    <ItemTemplate>
                                        <asp:Label ID="lbNgaygui" runat="server" Text='<%# Eval("Ngaygui") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>


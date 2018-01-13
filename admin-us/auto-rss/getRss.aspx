<%@ Page Language="C#" AutoEventWireup="true" CodeFile="getRss.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="refresh" content="86450"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
        <div>
            <asp:Label ID="cell" runat="server" Text=""></asp:Label>
            <%--<asp:Xml ID="cell" runat="server"></asp:Xml>--%>
            <asp:GridView ID="gvd" runat="server"></asp:GridView>
        </div>
        <div class="content-admin">
            <asp:Label ID="lbT" runat="server" Text=""></asp:Label>
          
            <%--<asp:DropDownList ID="ddlLoai" runat="server" CssClass="Control-dll" DataTextField="Name" DataValueField="id" AutoPostBack="true" OnSelectedIndexChanged="ddlLoai_SelectedIndexChanged"></asp:DropDownList>--%>
            <div class="grid">
                <asp:GridView ID="grvTaskNew" runat="server"
                    AutoGenerateColumns="False" Width="100%" EmptyDataText="No data"
                    ShowHeaderWhenEmpty="True" PageSize="15"
                    AllowSorting="True" AllowPaging="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Tiêu Đề" SortExpression="TieuDe">
                            <ItemTemplate>
                                <asp:Label ID="lbMaBN" runat="server" Text='<%# Eval("TieuDe") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày Đăng ">
                            <ItemTemplate>
                                <asp:Label ID="lbHoBN" runat="server" Text='<%# Eval("NgayDang") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Tóm Tắt" SortExpression="Tomtat">
                            <ItemTemplate>
                                <asp:Label ID="lbTenBN" runat="server" Text='<%# Eval("Tomtat") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemTemplate>
                                <asp:HyperLink ID="btnSua" runat="server" Height="23px" NavigateUrl='<%# "~/admin-us/tin-tuc/tin-tuc.aspx?id=" +Eval("id")%>' ToolTip="Sửa">Sửa</asp:HyperLink>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

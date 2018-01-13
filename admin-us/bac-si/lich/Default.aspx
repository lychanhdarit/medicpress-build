<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_rv_danh_muc_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Lịch Bác Sĩ</h1>
    
    <div class="">
        <asp:Button ID="btnThem" runat="server" Text="Tạo mới" OnClick="btnThem_Click"/>
        
        <div class="grid">
            <asp:GridView ID="grvTaskNew" runat="server"
                AutoGenerateColumns="False" Width="100%" EmptyDataText="No data" DataKeyNames="id"
                ShowHeaderWhenEmpty="True" PageSize="15"
                AllowSorting="True" AllowPaging="True" OnRowDataBound="grDataTinh_RowDataBound" OnSelectedIndexChanged="grDataTinh_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkChon" runat="server" CssClass='<%# Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Thứ" SortExpression="Code">
                        <ItemTemplate>
                            <asp:Label ID="lbThu" runat="server" Text='<%# Eval("Thu") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Sáng" SortExpression="Code">
                        <ItemTemplate>
                            <asp:TextBox ID="txtSang" runat="server" Text='<%# Eval("Sang") %>'></asp:TextBox>
                            
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Chiều " SortExpression="Code">
                        <ItemTemplate>
                            <asp:TextBox ID="txtChieu" runat="server" Text='<%# Eval("Chieu") %>'></asp:TextBox>
                           
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Tối " SortExpression="Code">
                        <ItemTemplate>
                            <asp:TextBox ID="txtToi" runat="server" Text='<%# Eval("Toi") %>'></asp:TextBox>
                            
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     
                </Columns>
            </asp:GridView>
        </div>

        <asp:Button ID="btnUpdate" runat="server" Text="Cập Nhật" OnClick="btnUpdate_Click" />
        <asp:Button ID="btn" PostBackUrl="~/admin-us/bac-si/info/Default.aspx" runat="server" Text="Trở Lại" />
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="admin_us_danh_muc_Details" ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src='<%= ResolveUrl("~/Scripts/jquery-2.1.4.min.js") %>'></script>

    <script type="text/javascript" src='<%= ResolveUrl("~/ckeditor/ckeditor.js") %>'></script>

    <script type="text/javascript" src='<%= ResolveUrl("~/ckeditor/adapters/jquery.js") %>'></script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="content-header">
        <h1>
            Cập nhật css
        </h1>
       
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-12">

                <div class="box box-danger">
                    <div class="box-header">
                        <h3 class="box-title"></h3>
                    </div>
                    <div class="form-group">
                      
                        <asp:Button ID="btnLuuStyle" runat="server" Text="Cập nhật" OnClick="btnLuuStyle_Click" CssClass="btn-blue" />
                        <asp:Label ID="lbThongBao" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="ltError" runat="server" ForeColor="#CC0000"></asp:Label>
                    </div>
                    <div class="box-body">
                        
                      
                        <!-- /.box-header -->
                        <div class="box-body pad">
                            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="100%" Rows="50" placeholder="Chỉnh sửa, thêm style css..."></asp:TextBox>
                        </div>


                    </div>
                </div>
            </div>

            
        </div>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box">
                </div>
            </div>
        </div>
    </section>
</asp:Content>


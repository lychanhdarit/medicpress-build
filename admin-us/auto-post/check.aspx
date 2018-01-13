<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="check.aspx.cs" Inherits="admin_us_auto_post_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-danger">
                    <div class="box-header">
                        <h3 class="box-title">Auto Post</h3>
                    </div>
                    <div class="box-body">
                        <!-- Date dd/mm/yyyy -->
                        
                         <div class="form-group">
                          
                                <asp:TextBox ID="txtURL" runat="server" CssClass="form-control" placeholder="Nhập Url RSS " Width="100%"></asp:TextBox>
                            
                            <!-- /.input group -->
                        </div>
                         <div class="form-group">
                            <div class="input-group">
                                <asp:DropDownList ID="ddlCT" runat="server" CssClass="form-control" DataTextField="name" DataValueField="id"></asp:DropDownList>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:Button ID="btnAdd" runat="server" Text="Check " OnClick="btnAdd_Click" CssClass="btn-b" />
                               
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                         <asp:Literal ID="ltHome" runat="server"></asp:Literal>
                            <asp:Literal ID="ltThongSo" runat="server"></asp:Literal>
                          <asp:Literal ID="lthtml" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
     
      
    </section>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/admin-us/share/admin-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_us_sitemap_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-danger">
                    <div class="box-header">
                        <h3 class="box-title">Sitemap</h3>
                    </div>
                    <div class="box-body">
                        <!-- Date dd/mm/yyyy -->
                        <div class="form-group">
                            <label>Cập nhật sitemap.xml:</label>
                            <div class="input-group">

                                <asp:Button ID="btnAdd" runat="server" Text="Cập nhật" OnClick="btnAdd_Click" CssClass="btn-b" />
                                <asp:Label ID="lbAdd" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <br />
                                <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl="~/sitemap.xml">open sitemap</asp:HyperLink>
                            </div>
                            <!-- /.input group -->
                        </div>
                        <!-- /.form group -->
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>


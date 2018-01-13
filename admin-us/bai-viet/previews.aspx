<%@ Page Title="" Language="C#" MasterPageFile="~/Share/medical/_layoutRightBar.master" AutoEventWireup="true" CodeFile="previews.aspx.cs" Inherits="admin_us_bai_viet_previews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ptTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentLeft" Runat="Server">
     <div class="posts">

        <div class="desc-content">

            <i class="fa fa-quote-left b-left b-blockquote__icon f-blockquote__icon"></i>
            <h2>
                <asp:Literal ID="ltDescPost" runat="server" Text=""></asp:Literal>

            </h2>
        </div>
        <div class="content-post">
            <asp:Literal ID="ltContent" runat="server" Text=""></asp:Literal>
        </div>
        <div>
            <asp:Literal ID="lbTags" runat="server"></asp:Literal>
        </div>
    </div>
    <div style="position:fixed;left:0;top:0">
        <img src="../../Share/images/previews.jpg" style="width:150px;"/>
    </div>
</asp:Content>


<%@ Page Title="Không tìm thấy nội dung " Language="C#" MasterPageFile="~/themes/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_404_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cthead" runat="Server">
    <style>
        .post-inner-content table {
            text-align: center;
            border: none;
        }

            .post-inner-content table td {
                border: 0px solid #e2e2e2;
            }

        .main-sections {
            margin: 25px auto;
        }
    </style>
    <div class="breadcrumbs">
        <div class="crumbs">
            <a href="/"><i class="fa fa-home"></i>Home</a><span class="crumbs-span">&raquo;</span><span class="current"></span><asp:Literal ID="ltCat" runat="server"></asp:Literal>
            <span class="crumbs-span">&raquo;</span><span class="current"></span>
            <asp:Literal ID="ltTitle2" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPage" runat="Server">

    <div class="container">

        <span style="display: block; padding: 25px; color: #48b24b; border: 1px solid #48b24b; border-radius: 10px; background: #f3f3f3; font-weight: bold; font-size: 2em;">Không tìm thấy nội dung này.</span>
    </div>

</asp:Content>


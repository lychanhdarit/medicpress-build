<%@ Page Title="Cảm ơn quý khách đã gửi thông tin, chúng tôi sẽ phản hồi thông tin sớm nhât!" Language="C#" MasterPageFile="~/themes/thammydiamond/left-main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="register_success_Default" %>

<asp:Content ID="Content4" ContentPlaceHolderID="headHeader" runat="Server">
    <asp:Literal ID="ltImg" runat="server"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentDetailTab" runat="Server">
    <h2 class="f-primary-l c-default">
        <asp:Literal ID="ltCat2" runat="server"></asp:Literal></h2>
    <div class="f-primary-l f-inner-page-header_title-add c-senary"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentSideLink" runat="Server">
    <ul>
        <li itemscope='' itemtype='http://data-vocabulary.org/Breadcrumb'>
            <a itemprop='url' href="/"><i class="fa fa-home"></i>Home</a>
        </li>
        <li itemscope='' itemtype='http://data-vocabulary.org/Breadcrumb'>
            <i class="fa fa-angle-right"></i>
          Đặt hẹn thành công
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPost" runat="Server">
   
    <span style="    display: block;
    padding: 25px;
    color: #48b24b;
    border: 1px solid #48b24b;
    border-radius: 10px;
    background: #f3f3f3;
    font-weight: bold;
    font-size: 2em;"> Cảm ơn quý khách đã gửi thông tin, chúng tôi sẽ phản hồi thông tin sớm nhât!</span>

</asp:Content>


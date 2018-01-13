<%@ Page Title='<%: Page.Title %>' Language="C#" MasterPageFile="~/Share/medical/_layout.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Categorys_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentWrapper" runat="Server">
    <div class="main-content-top">
        <div class="main-wrapper">
            <div class="row">
                <div class="large-8 columns">
                    <h1 itemprop='title' class='title'>
                        <asp:Literal ID="LbTieuDeChinh" runat="server" Text=""></asp:Literal></h1>
                </div>
                <div class="large-4 columns">
                    <ul class="nav-tags">
                        <li itemscope='' itemtype='http://data-vocabulary.org/Breadcrumb'>
                            <a itemprop='url' href="/"><i class="icon-home"></i>Home</a>
                        </li>
                        <li itemscope='' itemtype='http://data-vocabulary.org/Breadcrumb'>
                            <i class="icon-hand-right"></i>
                            <asp:Literal ID="ltCat" runat="server"></asp:Literal>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="border-top: 1px solid rgb(236, 190, 62);margin-top:20px;">
        <asp:Image ID="imgDanhMuc" runat="server" Width="100%" Visible="false" />
        <img src="../Share/images/shadow-foot.png" style="width: 100%; height: 15px" />
    </div>
    <div class="main-wrapper">
        <div class="content_wrapper">
            <div class="row">
                <div class="large-12 columns">
                    <ul class="splitter portfolio-main filter portmenu">
                        <li class="segment-0 selected-1 active"><a href="#" class="all">All</a></li>
                        <asp:Literal ID="ltTabs" runat="server"></asp:Literal>
                    </ul>
                </div>
                <div class="large-12 columns">
                    <ul class="portfolio-content large-block-grid-4">
                        <asp:Literal ID="ltContentTabs" runat="server"></asp:Literal>

                    </ul>

                </div>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title='<%: Page.Title %>' Language="C#" MasterPageFile="~/Share/san-khoa/Right_layout.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Categorys_Default" %>

<%@ Register Src="~/Share/san-khoa/Qui-trinh.ascx" TagPrefix="uc1" TagName="Quitrinh" %>


<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="Server">
    <asp:Literal ID="ltImg" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contentbanner" runat="Server">

    <div class="container">
        <div class="main-wrapper">
            <div class="row">

                <div class="large-4 columns">
                    <ul class="nav-tags">
                        <li itemscope='' itemtype='http://data-vocabulary.org/Breadcrumb'>
                            <a itemprop='url' href="/"><i class="fa fa-home"></i>Home</a>
                        </li>
                        <li itemscope='' itemtype='http://data-vocabulary.org/Breadcrumb'>
                            <i class="fa fa-hand-o-right"></i>
                            <asp:Literal ID="ltCat" runat="server"></asp:Literal>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="main-wrapper" style="display: none">
        <div class="content_wrapper">
            <div class="row" style="border-top: 1px solid rgb(236, 190, 62);">
                <asp:Image ID="imgDanhMuc" runat="server" Width="100%" Visible="false" />
                <img src="../Share/images/shadow-foot.png" style="width: 100%; height: 15px" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPost" runat="Server">
    <div class="post">
        <h1 class="bordered light" style="font-weight: bold">
            <asp:Literal ID="LbTieuDeChinh" runat="server" Text=""></asp:Literal></h1>

        <article class="blog-item blog-full-width blog-detail">

            <div class="blog-thumbnail">
                <asp:Image ID="Image1" runat="server" Width="100%" Visible="false" />
            </div>
            <div class="desc-content">

                <asp:Literal ID="ltDescPost" runat="server" Text=""></asp:Literal>

            </div>
            <div class="blog-content">
                <asp:Literal ID="ltContent" runat="server" Text=""></asp:Literal>
            </div>
            <div class="bai-viet">
                <asp:Repeater ID="rpLQ" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 col-news ">
                            <article class="col-2 post-s">
                                <div class="post_img">
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/" + Eval("url") %>' AlternateText='<%# Eval("Title") %>' ImageUrl='<%# "~/UploadFile/ThumbLQ/"+Eval("Images") %>'> <%# Eval("Title") %></asp:HyperLink>

                                </div>
                                <div style="margin-top: 10px; width: 220px; overflow: hidden" class='fb-like' data-href='<%# "~/" + Eval("url")  %>' data-layout='standard' data-action='like' data-show-faces='true' data-share='true'></div>
                                <h3>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/" + Eval("url")  %>'> <%# Eval("Title") %></asp:HyperLink></h3>
                                <img src="Share/san-khoa/images/shadow-foot.png" style="width: 100%; border-top: 0px solid #3d91a5; bottom: 0px;">
                            </article>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear">
                </div>
            </div>
            <div class="blog-tags">
                <asp:Literal ID="lbTags" runat="server" Text=""></asp:Literal>
            </div>



        </article>
    </div>

    <uc1:Quitrinh runat="server" ID="Quitrinh" />
    <div class="addthis_native_toolbox" style="margin-left: 15px;"></div>
    <div class="line"></div>
    <div style="margin-top: 20px;">
        <asp:Button ID="btnSua" runat="server" Text="Edit" Visible="false" CssClass="button" />
    </div>
    <div class="clear"></div>
    <div class="bai-viet">
        <h3 class="bv-cm">Bài viết cùng chuyên mục</h3>
        <asp:Repeater ID="rpData" runat="server">
            <ItemTemplate>
                <div class="col-md-4 col-news ">
                    <article class="col-2 post-s">
                        <div class="post_img">
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt") %>' AlternateText='<%# Eval("Title") %>' ImageUrl='<%# "~/UploadFile/postImages/"+Eval("HinhAnh") %>'> <%# Eval("Title") %></asp:HyperLink>

                        </div>
                        <div style="margin-top: 10px; width: 220px; overflow: hidden" class='fb-like' data-href='<%# "~/" + Eval("id_tt")  %>' data-layout='standard' data-action='like' data-show-faces='true' data-share='true'></div>
                        <h3>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt")  %>'> <%# Eval("Title") %></asp:HyperLink></h3>
                        <img src="Share/san-khoa/images/shadow-foot.png" style="width: 100%; border-top: 0px solid #3d91a5; bottom: 0px;">
                    </article>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clear">
        </div>
    </div>

      <div class="row">
        <div class="col-md-3">
            Trang hiện tại: <span class="btnActive"><asp:Literal ID="ltPage" runat="server" Text="1"></asp:Literal></span> / 
        </div>
        <div class="col-md-9">
            <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand" OnItemDataBound="rptPaging_ItemDataBound">
                <ItemTemplate>
                    <asp:LinkButton ID="btnPage" CssClass="btnPager"
                        CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %>
                    </asp:LinkButton> 
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear"></div>
        </div>


    </div>
</asp:Content>


<%@ Page Title='<%: Page.Title %>' MetaDescription='<%: Page.MetaDescription  %>' MetaKeywords='<%: Page.MetaKeywords  %>' Language="C#" MasterPageFile="~/themes/thammydiamond/left-main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Categorys_Default" %>

<asp:Content ID="Content4" ContentPlaceHolderID="headHeader" runat="Server">
    <asp:Literal ID="ltImg" runat="server"></asp:Literal>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentDetailTab" runat="Server">
    <h2 class="f-primary-l c-default">
        <asp:Literal ID="ltCat2" runat="server"></asp:Literal></h2>
    <div class="f-primary-l f-inner-page-header_title-add c-senary"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentSideLink" runat="Server">
    <ul>
        <li itemscope='' itemtype='http://data-vocabulary.org/Breadcrumb'>

            <a itemprop='url' href="/"><i class="fa fa-home"></i>Home</a>
        </li>
        <li itemscope='' itemtype='http://data-vocabulary.org/Breadcrumb'>
            <i class="fa fa-hand-o-right"></i>
            <asp:Literal ID="ltCat" runat="server"></asp:Literal>
        </li>
    </ul>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPost" runat="Server">

    <!-- Sub Page Content
			============================================= -->
	<style>
		.blog-content h3{
			text-transform:none;
		}
	</style>
    <div class="post">
        <h1 class="bordered light" style="font-weight:500">
            <asp:Literal ID="LbTieuDeChinh" runat="server" Text=""></asp:Literal></h1>

        <article class="blog-item blog-full-width blog-detail ">
            <div class="desc-content row " style="display: none">

                <asp:Literal ID="ltDescPost" runat="server" Text=""></asp:Literal>

            </div>
            <div class="blog-content row short">
                <asp:Literal ID="ltContent" runat="server" Text=""></asp:Literal>
            </div>
            
        </article>

    </div>
    <div class="bai-viet">

        <asp:Repeater ID="rpDM" runat="server">
            <ItemTemplate>
                <div class="col-md-4 col-news ">
                    <article class="col-2 post-s">
                        <div class="post_img">
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/" + Eval("code").ToString().ToLower() +".hxml" %>' AlternateText='<%# Eval("name") %>' ImageUrl='<%# Eval("urlct").ToString().Trim() == ""?  "~/UploadFile/DanhMuc/noimg.jpg" : "~/UploadFile/DanhMuc/"+Eval("urlct") %>'> <%# Eval("name") %></asp:HyperLink>

                        </div>

                        <h3>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/" + Eval("code").ToString().ToLower() +".hxml"   %>'> <%# Eval("name") %></asp:HyperLink></h3>

                        <img src="Share/san-khoa/images/shadow-foot.png" style="width: 100%; border-top: 0px solid #3d91a5;">
                    </article>
                </div>
            </ItemTemplate>
        </asp:Repeater>
		
        <div class="clear">
        </div>
    </div>


    <div class="addthis_native_toolbox" style="margin-left: 15px;"></div>

    <div class="line"></div>
    <div class="bai-viet post-item-box">
        <h3 class="bv-cm">Bài viết cùng chuyên mục</h3>
        <div class="row">
            <asp:Repeater ID="rpData" runat="server">
                <ItemTemplate>
                    <div class="col-md-3 item">
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt") %>' AlternateText='<%# Eval("Title") %>' ImageUrl='<%# "~/UploadFile/postImages/"+Eval("HinhAnh") %>'> <%# Eval("Title") %></asp:HyperLink>

                        <h6>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt")  %>'> <%# Eval("Title") %></asp:HyperLink></h6>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
            <div class="clear">
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
            Trang hiện tại: <span class="btnActive">
                <asp:Literal ID="ltPage" runat="server" Text="1"></asp:Literal></span> / 
        </div>
        <div class="col-md-10">
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


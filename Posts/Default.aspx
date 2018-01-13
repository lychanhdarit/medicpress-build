<%@ Page Title='<%: Page.Title %>' Language="C#" MasterPageFile="~/themes/thammydiamond/left-main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Posts_Default" %>

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
            <asp:Literal ID="ltCat" runat="server"></asp:Literal>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPost" runat="Server">
	<style>
		.blog-content h3{
			text-transform:none;
		}
	</style>
    <div class="b-article-box">
        <div class="f-article_title f-primary-l b-title-b-hr">
            <h1 style="font-size: 1.2em; line-height: 1; margin: 0px; text-transform: none;font-weight:500">
                <asp:Literal ID="LbTieuDeChinh" runat="server" Text=""></asp:Literal></h1>
        </div>

        <div class="b-article__description">

            <blockquote class="b-blockquote--primary b-diagonal-line-bg-light f-blockquote--primary f-primary-it">
                <i class="fa fa-quote-left b-left b-blockquote__icon f-blockquote__icon"></i>
                <div class="b-remaining">
                    <asp:Literal ID="ltDescPost" runat="server" Text=""></asp:Literal>
                </div>
            </blockquote>
            <div class="blog-content">
                <asp:Literal ID="ltContent" runat="server" Text=""></asp:Literal>
            </div>
        </div>
        <div class="b-article__social-info" >
            <ul>
                <li>
                    <div class="b-article__tag">
                        <span class="b-article__social-info-name f-article__social-info-name"><i class="fa fa-tags"></i>Tags:</span>
                       <asp:Label ID="lbTags" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                
            </ul>
        </div>
    </div>
    <div class="post-item-box">
        <h3 class="f-primary-b b-title-description f-title-description">Bài viết liên quan
        </h3>
        <div class="row ">
            <asp:Repeater ID="rpData" runat="server">
                <ItemTemplate>
                    <div class="col-md-3 item">
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt") %>' AlternateText='<%# Eval("Title") %>' ImageUrl='<%# "~/UploadFile/postImages/"+Eval("HinhAnh") %>'> <%# Eval("Title") %></asp:HyperLink>

                        <h6>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt")  %>'> <%# Eval("Title") %></asp:HyperLink></h6>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="row">
                <div class="col-md-3">
                    Trang hiện tại: <span class="btnActive">
                        <asp:Literal ID="ltPage" runat="server" Text="1"></asp:Literal></span> / 
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
        </div>
    </div>
   

</asp:Content>


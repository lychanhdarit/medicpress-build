<%@ Page Title='<%: Page.Title %>' MetaDescription='<%: Page.MetaDescription  %>' MetaKeywords='<%: Page.MetaKeywords  %>' Language="C#" MasterPageFile="~/themes/thammydiamond/left-main.master" AutoEventWireup="true" CodeFile="tags.aspx.cs" Inherits="Categorys_tags" %>
<asp:Content ID="Content3" ContentPlaceHolderID="headHeader" runat="Server">
    <asp:Literal ID="ltImg" runat="server"></asp:Literal>
	<style>
		.ip img{
			height:150px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contentDetailTab" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPost" runat="Server">
     <div class="bai-viet">
        <asp:Repeater ID="rpData" runat="server">
            <ItemTemplate>
                 <div class="col-md-4 col-news ">
                    <article class="post col-2">
                        <div class="ip">
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt") %>' AlternateText='<%# Eval("Title") %>' ImageUrl='<%# "~/UploadFile/postImages/"+Eval("HinhAnh") %>'> <%# Eval("Title") %></asp:HyperLink>
                            
                        </div>
                        <h3>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt")  %>'> <%# Eval("Title") %></asp:HyperLink></h3>
                      
                    </article>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clear"></div>
    </div>
    <div>
        Trang hiện tại:
        <asp:Literal ID="ltPage" runat="server" Text="1"></asp:Literal>
        <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand" >
            <ItemTemplate>
                <asp:LinkButton ID="btnPage" CssClass="btnPager"
                    CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"><%# Container.DataItem %>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>


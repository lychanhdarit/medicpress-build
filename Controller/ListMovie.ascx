<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListMovie.ascx.cs" Inherits="Controller_ListPostWithCategory" %>
<asp:DataList ID="dataPost" runat="server" RepeatColumns="4" OnItemDataBound="listData2_ItemDataBound">
    <ItemTemplate>
        <div style="" class="item-content2">
            <div style="" class="img">
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%# "~/mv/" + BaseView.convertStringLinks(Eval("name").ToString()) + "/" + Eval("id") %>'>
                    <asp:Image data-retina="" ID="Image1" runat="server" CssClass='<%#  Eval("images") %>' AlternateText='<%#  Eval("name") %>' ImageUrl='<%#  "~/upload/" + Eval("images") %>' />
                </asp:HyperLink>
            </div>
            <div class="">
                <h3 style="font-size: 1.1em;">
                    <asp:HyperLink ID="HyperLink2" runat="server" ToolTip='<%#  Eval("name") %>' NavigateUrl='<%# "~/mv/" + BaseView.convertStringLinks(Eval("name").ToString()) + "/" + Eval("id") %>' Text='<%# Eval("name") %>' CssClass="f-primary-l f-title-big f-blog__title"></asp:HyperLink>

                </h3>
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>
<asp:DataList ID="dlPaging" runat="server" RepeatDirection="Horizontal" OnItemCommand="dlPaging_ItemCommand"
    OnItemDataBound="dlPaging_ItemDataBound">
    <ItemTemplate>
        <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
            CommandName="Paging" Text='<%# Eval("PageText") %>'></asp:LinkButton>&nbsp;
    </ItemTemplate>
</asp:DataList>
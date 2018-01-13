<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListPostWithTags.ascx.cs" Inherits="Controller_ListPostWithCategory" %>
<asp:DataList ID="dataPost" runat="server" RepeatColumns="4" OnItemDataBound="listData2_ItemDataBound">
    <ItemTemplate>
        <div style="" class="item-content2">
            <div style="" class="img">
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%# "~/"+Eval("id_tt") %>'>
                    <asp:Image data-retina="" ID="Image1" runat="server" CssClass='<%#  Eval("HinhAnh") %>' AlternateText='<%#  Eval("TieuDe") %>' />
                </asp:HyperLink>
            </div>
            <div class="">
                <h3 style="font-size: 1.1em;">
                    <asp:HyperLink ID="HyperLink2" runat="server" ToolTip='<%#  Eval("TieuDe") %>' NavigateUrl='<%# "~/"+Eval("id_tt") %>' Text='<%# Eval("tieude") %>' CssClass="f-primary-l f-title-big f-blog__title"></asp:HyperLink>

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
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListPostLastest.ascx.cs" Inherits="Controller_ListPostLastest" %>
<ul>
    <asp:Repeater ID="rpLastestPost" runat="server">
        <ItemTemplate>
            <li>
                <div style="" class="item-content">
                    <div style="" class="img">
                        <asp:HyperLink ID="hp" runat="server" NavigateUrl='<%# "~/"+Eval("id_tt") %>'>
                            <asp:Image data-retina="" ID="Image1" runat="server" CssClass='<%#  Eval("HinhAnh") %>' AlternateText='<%#  Eval("TieuDe") %>' />
                        </asp:HyperLink>
                    </div>
                    <div class="">
                        <h3 style="font-size: 1.1em;">
                            <asp:HyperLink ID="hpLink" runat="server" ToolTip='<%#  Eval("TieuDe") %>' NavigateUrl='<%# "~/"+Eval("id_tt") %>' Text='<%# Eval("tieude") %>' CssClass="f-primary-l f-title-big f-blog__title"></asp:HyperLink>
                        </h3>
                    </div>
                </div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>

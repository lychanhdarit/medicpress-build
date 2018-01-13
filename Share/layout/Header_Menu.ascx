<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header_Menu.ascx.cs" Inherits="Share_layout_Header_Menu" %>
<div class="page-header main-page">
    <div style="">
        <div id="logo" class="logo">
            <div>
                <a href="/">
                    <asp:Image ID="Image1" runat="server" Height="70" ImageUrl="~/Share/images/logo-ykhoa.png" AlternateText="Trung tam Y Khoa Chat luong cao Diamond, phong kham diamond" />
                </a>
            </div>
        </div>
        <!--/ logo -->
        <div class="main-nav">
            <ul id="navigation">
                <asp:Literal ID="lbMenu" runat="server" Text=""></asp:Literal>
                <li style="width: 50px">
                    <div style="position: absolute; right: 0px; top: 0px;">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="btnSearch"></asp:TextBox>
                        <div style="display: none">
                            <%-- <asp:Button ID="btnSearch" runat="server" Text="S" OnClick="btnSearch_Click" />--%>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
        <div class="m-menu mobile">

            <div class="m-khuyenmai" style="float: left; width: 40%; padding-top: 10px; text-align: center">
                <img src="../Share/Images/Icon/khuyen-mai-bottom.jpg" alt="Khuyen mai" style="float: left; height: 30px;" />
                <a href="#" style='text-transform: uppercase !important; font-weight: bold; font-size: 1.1em; float: left'>Khuyến mãi </a>
                <span style="background-color: #DC1629; color: #fff; position: absolute; top: 1px; left: 15px; border-radius: 50%; width: 20px; height: 20px; text-align: center">2</span>
            </div>
            <div id="mobile-main-nav" class="mobile-main-nav" style="float: left; width: 19% !important; margin-top: 5px;">
                <i class="fa fa-bars"></i>

                <ul style="position: fixed; bottom: 50px; width: 100%; left: 0; background: #268783; z-index: 9999">
                    <asp:Literal ID="lbMenu2" runat="server" Text=""></asp:Literal>
                </ul>
            </div>
            <div class="m-phone" style="float: right; width: 40%; padding-top: 10px; text-align: center">
                <a href="tel://+84904720672" style='font-weight: bold; font-size: 1.3em'>0904.72.06.72 </a>
            </div>
            <div class="clear"></div>
        </div>
        <!-- main nav -->
    </div>
</div>

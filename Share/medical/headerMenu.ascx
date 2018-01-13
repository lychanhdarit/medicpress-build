<%@ Control Language="C#" AutoEventWireup="true" CodeFile="headerMenu.ascx.cs" Inherits="Share_medical_headerMenu" %>

<!-- Begin Main Wrapper -->
<div class="h-header">
    <div class="main-wrapper">
        <div class="large-8 columns">
            <div class="lich-h">
                <span class="icon-map-marker"></span>Số 9, Trần Quốc Thảo, P.6, Q3, TP HCM
            </div>

        </div>
        <div class="large-4 columns">
            <a href="/" class="hot-line"><span class="icon-phone"></span><span style="color: #ffd800">0904 72 06 72</span> - 0938 228 768</a>
        </div>
    </div>
</div>
<div style="height: 34px;">
</div>
<div class="b-head">
    <div class="main-wrapper ">
        <!-- Main Navigation -->

        <header class="row main-navigation">

            <div class="large-3 columns">
                <a href="/" id="logo">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Share/images/logo-ykhoa-diamond.png" AlternateText="Y Khoa Diamond Logo" />
                </a>

            </div>
            <div class="large-9 columns">
                <nav class="top-bar">
                    <ul class="title-area">
                        <!-- Title Area -->
                        <li class="name"></li>
                        <!-- Remove the class "menu-icon" to get rid of menu icon. Take out "Menu" to just have icon alone -->
                        <li class="toggle-topbar menu-icon"><a href="#"><span>Danh Mục</span></a></li>
                    </ul>

                    <section class="top-bar-section">
                        <!-- Left Nav Section -->
                        <ul class="right window">
                            <asp:Literal ID="lbMenu" runat="server"></asp:Literal>
                        </ul>
                        <!-- End Left Nav Section -->
                        <div class="mobile">
                            <asp:Literal ID="lbTagCategories" runat="server" Text=""></asp:Literal>
                        </div>
                        
                    </section>
                </nav>
            </div>
        </header>
        <!-- Start Main Slider -->
    </div>
</div>
 
		<%--<script>
		    jQuery(document).ready(function ($) {
		        jQuery('#dl-menu').dlmenu({
		            animationClasses: { classin: 'dl-animate-in-5', classout: 'dl-animate-out-5' }
		        });
		    });
		</script>
<script src='<%= ResolveUrl("~/js/jquery.dlmenu.js") %>'></script>--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuController.ascx.cs" Inherits="peter_hung_MenuController" %>

    <div style="background: #FFF">
        <div class="fixed-top">
            <div class="topbar">
                <div class="container" style="background: #fff">
                    <div class="col-lg-4 mb-4">
                        <img src="../peter-hung/images/logo.png" />
                    </div>
                    <div class="col-lg-8 mb-8">
                    </div>
                </div>
            </div>

            <!-- Navigation -->
            <nav class="navbar  navbar-expand-lg navbar-dark bg-yel">

                <div class="container">

                    <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarResponsive">
                        <ul class="navbar-nav">
                            <li class="nav-item active">
                                <a class="nav-link" href="/"><i class="fa fa-home" ></i> Trang chủ</a>
                            </li>
                            <asp:Literal ID="ltMenu" runat="server"></asp:Literal>
                            
                        </ul>
                    </div>
                </div>
            </nav>

        </div>
    </div>

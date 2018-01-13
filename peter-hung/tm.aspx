<%@ Page Title="" Language="C#" MasterPageFile="~/peter-hung/main.master" AutoEventWireup="true" CodeFile="tm.aspx.cs" Inherits="peter_hung_Default" %>

<%@ Register Src="~/peter-hung/SliderController.ascx" TagPrefix="uc1" TagName="SliderController" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPage" Runat="Server">

    <uc1:SliderController runat="server" ID="SliderController" />
   
    <section class="bg-silver">
        <div class="container">

            <%--        <h1 class="my-4">Welcome to Modern Business</h1>--%>

            <!-- Marketing Icons Section -->
            <div class="row three-item-home wow bounceInUp" data-wow-duration="2s" <%--data-wow-iteration="100"--%>>
                <div class="col-lg-4 mb-4">
                    <div class="item">
                        <img src="images/b1.jpg" style="width: 100%" />
                        <div class="btn-box">
                            <a href="#">Về Thẩm Mỹ Diamond</a>
                            <span>
                                <i class="fa fa-angle-right" aria-hidden="true"></i>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-4">
                    <div class=" item">
                        <img src="images/b2.jpg" style="width: 100%" />
                        <div class="btn-box">
                            <a href="#">Đội ngũ Bác Sĩ & KTV</a>
                            <span>
                                <i class="fa fa-angle-right" aria-hidden="true"></i>
                            </span>
                        </div>
                    </div>

                     
                </div>
                <div class="col-lg-4 mb-4">
                    <div class="item">
                        <img src="images/b3.jpg" style="width: 100%" />
                        <div class="btn-box">
                            <a href="#">Cơ sở vật chất</a>
                            <span>
                                <i class="fa fa-angle-right" aria-hidden="true"></i>
                            </span>
                        </div>

                      
                    </div>
                </div>
            </div>
            <!-- /.row -->
            <!-- Marketing Icons Section -->
            <div class="box-title">
                <h2 class="center-title">DỊCH VỤ NỔI BẬT </h2>
                <div class="dich-vu-tabs">
                    <ul>
                        <li>
                            <a href="/" class="current">TẤT CẢ</a>
                        </li>
                        <li>
                            <a href="/">DỊCH VỤ</a>
                        </li>
                        <li>
                            <a href="/">VIDEOS</a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="row two-item-home">
                <div class="col-lg-6 mb-6 ">
                    <div class=" h-100">
                        <img src="images/i2-1.jpg" style="width: 100%" />
                    </div>
                </div>
                <div class="col-lg-6 mb-6">
                    <div class=" item-4">
                        <div class=" h-100">
                            <img src="images/i2-2.jpg" style="width: 100%" />
                        </div>
                    </div>
                    <div class=" item-4">
                        <div class=" h-100">
                            <img src="images/i2-3.jpg" style="width: 100%" />
                        </div>
                    </div>
                    <div class=" item-4">
                        <div class=" h-100 m-35">
                            <img src="images/i2-4.jpg" style="width: 100%" />
                        </div>
                    </div>
                    <div class=" item-4">
                        <div class=" h-100 m-35">
                            <img src="images/i2-5.jpg" style="width: 100%" />
                        </div>
                    </div>

                </div>

            </div>
            <!-- /.row -->
        </div>
    </section>
    <section class="bg-yellow">
        <div class="container">
            <div style="text-align: center">
                <h2 class="center-title" style="color: #fff">HOẠT ĐỘNG THẨM MỸ DIAMOND </h2>

            </div>

            <div class="row">
            </div>
        </div>
    </section>
    <section class="bg">
        <div class="container">
            <div class="box-title">
                <h2 class="center-title">HÌNH ẢNH TRƯỚC SAU</h2>

            </div>

            <div class="col-md-12">
                <iframe width="100%" height="440px" allowtransparency="true" scrolling="no" src="../peter-hung/media/" style="border: none"></iframe>
            </div>
        </div>
    </section>
    <!-- /.container -->
</asp:Content>


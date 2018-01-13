<%@ Page Title='<%: Page.Title %>' MetaDescription='<%: Page.MetaDescription  %>' MetaKeywords='<%: Page.MetaKeywords  %>' Language="C#" MasterPageFile="~/peter-hung/main-details.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ab" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ctHead" runat="Server">
    <asp:Literal ID="ltImgHeader" runat="server"></asp:Literal>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ctContentHead" runat="Server">


    <div class="container text-center">

        <h1>
            <asp:Literal ID="ltTitle" runat="server" Text="">Không tìm thấy<span>Trang này</span></asp:Literal></h1>
        <div class="bread-crumb" style="text-align:left">
            <a href="/" itemprop='url'><i class="fa fa-home"></i> Home</a> <i class="fa fa-angle-right"></i>
            <asp:Literal ID="ltLinkStrema" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ctContent" runat="Server">
    <section class="blog-container blog-detail">
        <!--Blog Post-->
        <div class="featured-blog-post wow fadeInLeft" data-wow-delay="0ms" data-wow-duration="1500ms">
            <article class="inner-box">
                
                <div class="post-lower">
                    <div class="post-header">
                        <div class="date sec-padding2"><span class="day icon flaticon-relaxing-massage"></span></div>
                        <h3 class="title fs-24"><a href="#">
                            <asp:Literal ID="ltTitle2" runat="server"></asp:Literal></a></h3>
                       
                    </div>
                    <div class="post-desc">
                        <asp:Literal ID="ltDescPost" runat="server"></asp:Literal>

                    </div>
                    <div class="blog-content">
                        <asp:Literal ID="ltContent" runat="server"></asp:Literal>
                    </div>
                    <div style="clear: both" >
                        <ul class="tags">
                            <asp:Literal ID="lbTags" runat="server"></asp:Literal>
                            <li class=" clearfix"></li>
                        </ul>
                    </div>
                </div>
            </article>

            <section class="sec-padding86">
                <div class="">
                    <div class="row">
                        <div class="col-md-12 sec-title">
                            <h1 class="title">
                                <asp:Literal ID="ltDM" runat="server"></asp:Literal></h1>
                            <p class="p-text">Trung tâm chống lão hóa & Thẩm mỹ Công nghệ cao Diamond</p>
                            <div class="separator small-separator"></div>
                        </div>
                    </div>
                    <div class="row">

                        <asp:Repeater ID="rpData" runat="server">
                            <ItemTemplate>
                                <div class="col-sm-6 col-md-4">
                                    <div class="practise-area">
                                        <div class="thumb">
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/" + Eval("url") %>' AlternateText='<%# Eval("Title") %>' ImageUrl='<%# Eval("HinhAnh").ToString().IndexOf("http") == -1? "~/UploadFile/postImages/"+Eval("HinhAnh") : Eval("HinhAnh").ToString()  %>'> <%# Eval("tieude") %></asp:HyperLink>

                                        </div>
                                        <div class="practise-details">
                                            <i class="icon flaticon-bath-2"></i>
                                            <h4 class="title">...</h4>
                                            <p class="details">
                                                <%# Eval("tieude") %>
                                            </p>

                                            <asp:HyperLink ID="HyperLink5" CssClass="btn-thm btn-xs" runat="server" NavigateUrl='<%# "~/" + Eval("url")  %>'>Xem thêm <i class="fa fa-arrow-circle-right"></i></asp:HyperLink>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </section>
            <div class="clearfix"></div>
            <div class="f-center b-remaining">
                <div class="row">
                    <div class="col-md-2">
                        Trang hiện tại: <span class="btnActive">
                            <asp:Literal ID="ltPage" runat="server" Text="1"></asp:Literal></span> / 
                    </div>
                    <div class="col-md-10" style="text-align: left">
                        <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
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

            <div class="row clearfix">
                <div class="col-md-6 col-sm-12 col-xs-12">
                    <!-- Recent Posts -->
                    <div class="widget recent-posts wow fadeInUp" data-wow-delay="0ms" data-wow-duration="1500ms">

                        <div class="sec-title">
                            <h4 class="text-left title-bottom sec-padding15">Có thể<strong style="color: #d9a141;"> bạn quan tâm</strong></h4>
                        </div>
                        <asp:Repeater ID="rpBaiSEO" runat="server">
                            <ItemTemplate>
                                <div class="post">

                                    <div class="post-thumb">
                                        <a href='<%# "../"+Eval("url") %>' title='<%# Eval("tieude") %>'>
                                            <img alt='<%# Eval("tieude") %>' width='94' height='73' src='<%# Eval("hinhanh").ToString().IndexOf("http")==-1? "../uploadfile/postimages/" +Eval("hinhanh").ToString() : Eval("hinhanh").ToString() %>'>
                                        </a>
                                    </div>
                                    <h4>
                                        <asp:HyperLink ID="HyperLink1" CssClass="title" runat="server" NavigateUrl='<%# "~/" + Eval("url")  %>'> <%# Eval("Title") %></asp:HyperLink></h4>
                                    <div class="post-info text-right"><%# BaseView.getThang(ToSQL.SQLToDateTime(Eval("ngaydang")))  +" " +ToSQL.SQLToDateTime(Eval("ngaydang")).Day +" ,"+ ToSQL.SQLToDateTime(Eval("ngaydang")).Year %> </div>
                                </div>


                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>

                <div class="col-md-6 col-sm-12 col-xs-12">
                    <!-- Recent Posts -->
                    <div class="widget recent-posts wow fadeInUp" data-wow-delay="0ms" data-wow-duration="1500ms">

                        <div class="sec-title">
                            <h4 class="text-left title-bottom sec-padding15">Tin <strong style="color: #d9a141;">khuyến mãi</strong></h4>
                        </div>
                        <asp:Repeater ID="rpKM" runat="server">
                            <ItemTemplate>
                                <div class="post">

                                    <div class="post-thumb">
                                        <a href='<%# "../"+Eval("url") %>' title='<%# Eval("tieude") %>'>
                                            <img alt='<%# Eval("tieude") %>' width='94' height='73' src='<%# Eval("hinhanh").ToString().IndexOf("http")==-1? "../uploadfile/postimages/" +Eval("hinhanh").ToString() : Eval("hinhanh").ToString() %>'>
                                        </a>
                                    </div>
                                    <h4>
                                        <asp:HyperLink ID="HyperLink1" CssClass="title" runat="server" NavigateUrl='<%# "~/" + Eval("url")  %>'> <%# Eval("Title") %></asp:HyperLink></h4>
                                    <div class="post-info text-right"><%# BaseView.getThang(ToSQL.SQLToDateTime(Eval("ngaydang")))  +" " +ToSQL.SQLToDateTime(Eval("ngaydang")).Day +" ,"+ ToSQL.SQLToDateTime(Eval("ngaydang")).Year %> </div>
                                </div>


                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>

            </div>

            <!-- Comment Form -->
            <div class="comment-form wow fadeInUp" data-wow-delay="200ms" data-wow-duration="1500ms">

                <div class="sec-title">
                    <h4 class="text-left title-bottom sec-padding15">Gửi thông tin <strong style="color: #d9a141;">Đặt hẹn & tư vấn</strong></h4>
                </div>

                <!--Comment Form-->
                <div class="contact-section">
                    <div class="row clearfix">
                        <div class="form-group col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group-inner">
                               
                                <div class="field-outer">
                                    <asp:TextBox ID="txtYourName" runat="server" placeholder="Họ tên" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtYourName"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group-inner">
                               
                                <div class="field-outer">
                                    <asp:TextBox ID="txtPhone" runat="server" placeholder="Số điện thoại" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPhone" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-12 col-sm-12 col-xs-12">
                            <div class="form-group-inner">
                                <asp:TextBox ID="txtMessage" runat="server" placeholder="Nội dung tin nhắn" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <i style="padding-left: 20px;">
                            <asp:Label ID="Label1" runat="server" Text="Nhập mã xác nhận: thammydiamond.net" ForeColor="Red"></asp:Label>
                        </i>

                        <div class="form-group col-md-12 col-sm-12 col-xs-12">
                            <div class="form-group-inner">
                                <asp:TextBox ID="txtMXN" runat="server" placeholder="Mã xác nhận" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-12 col-sm-12 col-xs-12 text-right">

                            <asp:Button ID="btnSubmit" CssClass="btn btn-warning" runat="server" Text="Gửi" OnClick="btnSubmit_Click" />
                            <asp:Label ID="ltError" runat="server" Text="" ForeColor="Red"></asp:Label>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>

</asp:Content>


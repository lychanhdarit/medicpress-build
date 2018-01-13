<%@ Page Title="Liên Hệ" MetaDescription="Liên Hệ Ngay!" Language="C#"  MasterPageFile="~/peter-hung/main-details.master"  AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lien_he_Default" %>

<%@ Register Src="~/lien-he/thong-tin.ascx" TagPrefix="uc1" TagName="thongtin" %>



<asp:Content ID="Content4" ContentPlaceHolderID="ctHead" runat="Server">
    <script src="../Scripts/jquery-1.7.1.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ctContentHead" runat="Server">
    <div class="container text-center">

        <h1>Liên hệ</h1>
        <div class="bread-crumb">
            <a href="/" itemprop='url'>Home</a> <i class="fa fa-angle-right"></i> Liên hệ ngay.

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ctContent" runat="Server">

    <!--Contact Us Section-->
    <div class="sidebar-page">
        <div class="auto-container">

            <div class="row clearfix">

                <div class="col-md-12 col-sm-6 col-xs-12">
                    <section class="contact-section">

                        <div class="form">
                            <!--Comment Form-->
                            <div class="contact-section">
                                <div class="row clearfix">
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <div class="form-group-inner">
                                            <div class="icon-box">
                                                <label for="your-name"><span class="icon fa fa-user"></span></label>
                                            </div>
                                            <div class="field-outer">
                                                <asp:TextBox ID="txtYourName" runat="server" placeholder="Họ tên"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtYourName"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <div class="form-group-inner">
                                            <div class="icon-box">
                                                <label for="your-email"><span class="icon fa fa-phone"></span></label>
                                            </div>
                                            <div class="field-outer">
                                                <asp:TextBox ID="txtPhone" runat="server" placeholder="Số điện thoại"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPhone" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group-inner">
                                            <asp:TextBox ID="txtMessage" runat="server" placeholder="Nội dung tin nhắn" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <i style="padding-left: 20px;">
                                        <asp:Label ID="Label1" runat="server" Text="Nhập mã xác nhận: thammydiamond.net" ForeColor="Red"></asp:Label>
                                    </i>

                                    <div class="form-group col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group-inner">
                                            <asp:TextBox ID="txtMXN" runat="server" placeholder="Mã xác nhận"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group col-md-12 col-sm-12 col-xs-12 text-right">

                                        <asp:Button ID="btnSubmit" CssClass="button hvr-bounce-to-right" runat="server" Text="Gửi" OnClick="btnSubmit_Click" />
                                        <asp:Label ID="ltError" runat="server" Text="" ForeColor="Red"></asp:Label>

                                    </div>
                                </div>
                            </div>

                        </div>

                    </section>
                </div>

                <!--Sidebar-->
                <div class="col-lg-12 col-md-12">
                    <uc1:thongtin runat="server" ID="thongtin" />
                </div>
                <!--Sidebar-->

            </div>
        </div>
    </div>




</asp:Content>


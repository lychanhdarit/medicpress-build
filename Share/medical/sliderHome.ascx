<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sliderHome.ascx.cs" Inherits="Share_medical_sliderHome" %>
 <div class="slider-wrapper theme-default">
            <div id="slider" class="nivoSlider">
                <asp:Literal ID="lbSlider" runat="server"></asp:Literal>
            </div>
            <%--<div id="caption1" class="nivo-html-caption">
                <p class="nivotitle v1">Medicine definition</p>
                <p class="nivotitle v2">Applied science or practice of the diagnosis, treatment, and prevention of disease</p>
                <p class="nivotitle v3">Built on foundation 4</p>
            </div>
            <div id="caption2" class="nivo-html-caption">
                <p class="nivotitle v1">Dynamic contact form</p>
                <p class="nivotitle v2">Documentation</p>
                <p class="nivotitle v3">Easy to use and abuse</p>
            </div>
            <div id="caption3" class="nivo-html-caption">
                <p class="nivotitle v1">Fully responsive</p>
                <p class="nivotitle v2">Lots of shortcodes</p>
                <p class="nivotitle v3">Built on foundation 4</p>
            </div>--%>

     <div class="dat-hen-home">
         <img src="../share/images/f-silde.jpg" style="width:100%; height: 5px;margin-top: -10px" />
            <div class="main-wrapper app-wrapper">

                <div class="appointment-block">
                    <div class="row">
                        <div class="large-3 columns red">
                            <p><i class="icon-calendar" ></i>Đặt Lịch Hẹn!</p>
                            &nbsp;<!-- Put appointemnt label here -->
                        </div>
                        <div class="large-9 columns">
                            <div id="appointment-contact-form">
                                <div class="row">
                                    <div class="large-3 columns">
                                        <asp:TextBox ID="txtFullname" runat="server" placeholder="Họ & tên"></asp:TextBox>
                                        <asp:TextBox ID="txtSDT" runat="server" placeholder="Số điện thoại"></asp:TextBox>
                                    </div>
                                    <div class="large-3 columns">
                                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Địa chỉ email"></asp:TextBox>
                                        <asp:TextBox ID="txtNgay" runat="server" class="datepicker" placeholder="Chọn ngày đặt hẹn"></asp:TextBox>
                                       
                                    </div>
                                    <div class="large-3 columns">
                                        <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Rows="15" Columns="10" placeholder="Nội dung tin nhắn"></asp:TextBox>
                                    </div>
                                    <div class="large-3 columns">
                                        <asp:LinkButton ID="btnDH" runat="server" CssClass="blue button radius btnS" OnClick="btnDH_Click"> <i class="icon-envelope"></i> GỬI </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
         
     </div>
        </div>
        <!-- End Main Slider -->
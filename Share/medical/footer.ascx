<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="Share_medical_footer" %>
<div style="position:relative;bottom:-35px;z-index:0">
    <img src="../share/images/footer_img.png" style="width:100%;position:relative;" />
</div>
<footer class="footer_wrapper">
    <div class="row footer-part">
        <div id="back-to-top"><a href="#top"></a></div>
        <div class="large-12 columns">
            <div class="row">
                <div class="large-3 columns">
                    <h4 class="footer-title">Về Diamond</h4>
                    <div class="divdott"></div>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Share/images/logo-ykhoa-diamond-trang.png" CssClass="botlogo" AlternateText="Y Khoa Diamond Logo"/>
                    <div class="footer_part_content">
                        <p>Chăm sóc khách hàng như người thân của mình” chính là phương châm gắn kết, đồng hành và chia sẻ giữa chúng tôi với khách hàng nhằm san sẻ và giải quyết nỗi lo về sức khỏe vì một cuộc sống trọn vẹn.</p>
                    </div>
                </div>
                <div class="large-3 columns">
                    <h4 class="footer-title">Mới Nhất</h4>
                    <div class="divdott"></div>
                    <div class="footer_part_content">
                        <ul class="latest-posts">
                            <asp:Repeater ID="rpLast" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt")  %>'> <%# Eval("Title") %></asp:HyperLink>
                                        <div class="divline"><span></span></div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>


                <div class="large-3 columns">
                    <h4 class="footer-title">Liên hệ</h4>
                    <div class="divdott"></div>
                    <div class="footer_part_content">
                        <h3 style="font-size:1em;">TRUNG TÂM Y KHOA CHẤT LƯỢNG CAO DIAMOND </h3>
                        <ul class="about-info">
                            <li><i class="icon-home"></i><span>Số 9, Trần Quốc Thảo, P.6, Q3.</span></li>
                            <li><i class="icon-phone"></i><span>(08) 3930 75 75 -  0904 72 06 72</span></li>
                            <li><i class="icon-envelope"></i>ykhoadiamond.com</li>
                        </ul>
                        <ul class="social-icons">
                            <li><a href="#"><i class="icon-pinterest"></i></a></li>
                            <li><a href="#"><i class="icon-twitter"></i></a></li>
                            <li><a href="#"><i class="icon-facebook"></i></a></li>
                        </ul>
                    </div>
                </div>

                <div class="large-3 columns">
                    <h4 class="footer-title">Liên hệ nhanh</h4>
                    <div class="divdott"></div>
                    <div id="footer-contact-form">
                        <div class="footer_part_content">
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtFullname" runat="server" placeholder="Họ & tên"></asp:TextBox>
                                      
                                </div>
                                <div class="large-6 columns">
                                      <asp:TextBox ID="txtSDT" runat="server" placeholder="Số điện thoại"></asp:TextBox>
                                </div>
                                <div class="large-12 columns">
                                    <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Rows="15" Columns="10" placeholder="Nội dung tin nhắn"></asp:TextBox>
                                </div>
                                <div class="large-12 columns text-right">
                                    <asp:Button ID="btnDH" runat="server" CssClass="button" Text="Gửi" OnClick="btnDH_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
             <div class="row" style="border-top:1px solid #007793">
                <div class="large-10 columns copyright">
                    <p>&copy; <%= DateTime.Now.Year %> Y khoa Diamond, All Rights Reserved.</p>
                </div>
                <div class="large-2 columns">
                    
                </div>
            </div>
        </div>
    </div>

    <%--<div class="privacy footer_bottom">
        <div class="footer-part">
            <div class="row">
                <div class="large-10 columns copyright">
                    <p>&copy; <%= DateTime.Now.Year %> Y khoa Diamond, All Rights Reserved.</p>
                </div>
                <div class="large-2 columns">
                    
                </div>
            </div>
        </div>
    </div>--%>
</footer>

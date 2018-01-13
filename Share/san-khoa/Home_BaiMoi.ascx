<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Home_BaiMoi.ascx.cs" Inherits="Share_san_khoa_Home_BaiMoi" %>

<div class="container">

    <div class="row">

        <div class="col-md-7">

            <div class="latest-news2">

                <h2 class="light bordered"><span>Bài</span> Mới</h2>

                <ul id="latest-news-carousel" class="jcarousel-skin-tango blog-style2 list-unstyled">
                    <asp:Repeater ID="rpData" runat="server">
                        <ItemTemplate>
                            <li>
                                <i class="post-icon img-circle fa fa-medkit"></i>
                                <article class="blog2-item">
                                    <div class="blog2-thumbnail">

                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt") %>' AlternateText='<%# Eval("Title") %>'> 
                                                <img src='<%# "../UploadFile/postImages/"+Eval("HinhAnh") %>' alt='<%# Eval("Title") %>' />
                                        </asp:HyperLink>
                                    </div>
                                    <div class="blog2-content">
                                        <span class="arrow-right"></span>
                                        <h4 class="blog2-title"><a href='<%# "../" + Eval("id_tt")  %>'><%# Eval("tieude") %></a></h4>
                                        <p class="post-date">10 December, 2013 - 18:33:04</p>
                                        <p><%# Eval("Desc").ToString().Length > 75? Eval("Desc").ToString().Substring(0,75) : Eval("Desc") %> ...<a class="#." href='<%# "../" + Eval("id_tt")  %>'>Xem thêm</a></p>

                                    </div>
                                </article>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>



                </ul>

            </div>

        </div>

        <div class="col-md-5">

            <h2 class="light bordered"> <span style="font-size:14px">Tại Sao Chọn</span> Y Khoa Diamond</h2>

            <div class="panel-group accordian-style2" id="accordion2">

                <div class="panel panel-default">
                    <div class="panel-heading" style="background: #007793">
                        <h4 class="panel-title active">
                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapseOne" style="color:#fff !important">
                                <i class="fa fa-medkit" style="color:#fff !important"></i>Sứ mệnh<i class="fa pull-right fa-angle-up"></i>
                            </a>
                        </h4>
                    </div>

                    <div id="collapseOne" class="panel-collapse collapse in">
                        <div class="panel-body">
                            - Chăm sóc sức khỏe một cách toàn diện cho bà mẹ và bé.<br />

                            - Cung cấp những dịch vụ khám & chữa bệnh uy tín – chất lượng giúp chị em triệt tiêu những lo âu về sức khỏe, đặc biệt là những căn bệnh phụ khoa.<br />

                            - Đóng góp cho cộng đồng những giá trị thiết thực thông qua các hoạt động mang tính xã hội.<br />

                            - Dịch vụ nhanh chóng – chi phí hợp lý – chăm sóc tận tâm.<br />
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading" style="background:#007793">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapseTwo" style="color:#fff !important">
                                <i class="fa fa-heart" style="color:#fff !important"></i>Tại sao chọn chúng tôi.<i class="fa fa-angle-down pull-right"></i>
                            </a>
                        </h4>
                    </div>
                    <div id="collapseTwo" class="panel-collapse collapse">
                        <div class="panel-body">


                            <p>- Đội ngũ y bác sĩ giàu kinh nghiệm đến từ các bệnh viện lớn như: bệnh viện Từ Dũ, bệnh viện Đại học Y dược, bệnh viện 115… </p>

                            <p>- Trang thiết bị, cơ sở vật chất được đầu tư chuẩn mực nhằm mang đến những tiện ích tốt nhất cho khách hàng trong quá trình khám và điều trị tại Phòng khám Sản phụ khoa Diamond. </p>

                            <p>- Đồng hành cùng khách hàng trong suốt quá trình khám – điều trị - chăm sóc sau điều trị với mong muốn mang đến sự yên tâm cũng như cam kết một kết quả điều trị tốt nhất. </p>

                            <p>- Khi khách hàng lựa chọn Phòng khám Sản phụ khoa Diamond trong việc chăm sóc sức khỏe đồng nghĩa với việc khách hàng đã “bảo hiểm” niềm tin của chính mình đến trọn đời. </p>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading" style="background: #007793">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapseThree" style="color:#fff !important">
                                <i class="fa fa-user" style="color:#fff !important"></i>Cam kết<i class="fa fa-angle-down pull-right"></i>
                            </a>
                        </h4>
                    </div>
                    <div id="collapseThree" class="panel-collapse collapse">
                        <div class="panel-body">
                            - Đội ngũ y tá, điều dưỡng và nhân viên luôn thân thiện và nhiệt tình với khách hàng.<br />

                            - Thủ tục được tiến hành nhanh gọn giúp bệnh nhân tiết kiệm được thời gian và tạo tâm lý thoải mái khi đi khám.<br />

                            - Chi phí điều trị luôn được cập nhật và công bố rõ ràng đến khách hàng.<br />

                            - Phục vụ khách hàng bận rộn với linh hoạt khung giờ khám linh hoạt tất cả các ngày trong tuần, kể cả thứ 7, chủ nhật.
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading" style="background: #007793">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion2" href="#collapseFour" style="color:#fff !important">
                                <i class="fa fa-eye" style="color:#fff !important"></i>Tầm nhìn<i class="fa fa-angle-down pull-right"></i>
                            </a>
                        </h4>
                    </div>
                    <div id="collapseFour" class="panel-collapse collapse">
                        <div class="panel-body">
                            - Trở thành trung tâm y khoa với chất lượng dịch vụ y tế hàng đầu trong việc khám, chữa bệnh cho bà mẹ - trẻ em và chăm sóc sức khỏe cho phụ nữ.
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>

</div>

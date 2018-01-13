<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HotlineFooterController.ascx.cs" Inherits="peter_hung_HotlineFooterController" %>

<section class="bg-2-dark">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="info-f">
                    <h3>Hotline tư vấn</h3>
                    <h6>Gọi để được chuyên gia tư vấn về dịch vụ:</h6>
                    <p style="border-bottom: 1px solid #808080">
                        <span style="font-weight: 900; font-size: 2.5em; color: #94610a">0909 45 06 45</span> (gọi để tư vấn và đặt hẹn)
                    </p>
                    <p>
                        <b>Giờ làm việc từ 8h30 - 20h00/ Làm việc cả ngày lễ & chủ nhật.</b>
                    </p>
                </div>
            </div>
            <div class="col-md-6" style="background: #d1d3d4">
                <div class="info-f">
                    <h3>Đặt hẹn</h3>
                    <h6>Đội ngũ Bác sĩ hàng đầu các bệnh viện lớn:</h6>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:TextBox ID="txtText" runat="server" CssClass="form-control" placeholder="tên của bạn..."></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtSDT" runat="server" CssClass="form-control" placeholder="số điện thoại..."></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-10">
                            <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" placeholder="lời nhắn của bạn..."></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnGui" runat="server" Text="Gửi" CssClass="btn btn-warning" ForeColor="White" Font-Bold="true" OnClick="btnGui_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

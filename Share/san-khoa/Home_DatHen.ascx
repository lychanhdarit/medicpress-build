<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Home_DatHen.ascx.cs" Inherits="Share_san_khoa_Home_DatHen" %>

<section class="appointment-sec text-center bg-gray">

    <div class="container">

        <h2 style="font-size: 3em; color: #007793; font-weight: bold">Đặt hẹn ngay</h2>
        <p class="lead">Vì quyền lợi của bạn đặt hẹn ngay tại đây để được hỗ trợ tốt nhất từ chúng tôi.</p>

        <div class="row">

            <div class="col-md-6">
                <figure>
                    <img src="Share/san-khoa/images/appointment-img2.png" alt="image" title="Appointment image" class="img-responsive lady1" />
                </figure>
            </div>

            <div class="col-md-6" style="border-radius: 20px;box-shadow: 5px 5px 5px #dad6d6;border: 1px solid #d0cfcf;">
                <div class="appointment-form clearfix">
                    
                        <asp:Literal ID="ltError" runat="server"></asp:Literal>

                    <div id="appoint_form">

                        <asp:TextBox ID="txtFullname" runat="server" placeholder="Họ & tên"></asp:TextBox>
                        <asp:TextBox ID="txtSDT" runat="server" placeholder="Số điện thoại"></asp:TextBox>
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Địa chỉ email"></asp:TextBox>
                        <asp:TextBox ID="txtNgay" runat="server" class="datepicker" placeholder="Chọn ngày đặt hẹn"></asp:TextBox>
                        <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Rows="15" Columns="10" placeholder="Nội dung tin nhắn"></asp:TextBox>
                        <asp:Button ID="btnDH" runat="server" CssClass="btn btn-default btn-rounded" Text="Gửi đặt hẹn" OnClick="btnDH_Click" />

                    </div>
                </div>
            </div>

        </div>

    </div>

</section>

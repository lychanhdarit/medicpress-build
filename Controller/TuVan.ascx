<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TuVan.ascx.cs" Inherits="Controller_TuVan" %>
<div class="b-blog-form-box">
    <h3 class="f-primary-b b-title-description f-title-description">Gửi tin nhắn
    </h3>
    <div style="padding-bottom: 10px; border-bottom: 1px dashed #808080">Bạn hãy gửi tin nhắn, đặt hẹn hoặc đăng ký tham gia các chương trình hội thảo của chúng tôi.<br />
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="b-form-row">
                <label class="b-form-vertical__label" for="create_account_email">Email</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtEmail" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                <div class="b-form-vertical__input">

                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>

                </div>
            </div>
            <div class="b-form-row">
                <label class="b-form-vertical__label" for="create_account_password">Địa chỉ:</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="(*)" ControlToValidate="txtDiaChi" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                <div class="b-form-vertical__input">
                    <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
            </div>
            <div class="b-form-row">
                <label class="b-form-vertical__label" for="create_account_confirm">Điện thoại:</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="(*)" ControlToValidate="txtDienThoai" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                <div class="b-form-vertical__input">
                    <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
            </div>
            <div class="b-form-row">
                <label class="b-form-vertical__label" for="create_account_phone">Họ Tên: </label>
                <div class="b-form-vertical__input">

                    <asp:TextBox ID="txtxSkype" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-8">
            <div class="b-form-row b-form--contact-size">
                <label class="b-form-vertical__label" for="create_account_phone">Nội dung</label>
                <asp:TextBox ID="txtNoiDung" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="b-form-row">
                <div class="b-form-row b-form--contact-size">
                    <label class="b-form-vertical__label" for="create_account_phone">Mã xác nhận: vui lòng gõ (<i>thammydiamond.com</i>) vào ô bên dưới</label>
                    <asp:TextBox ID="txtCatpcha" runat="server" class="form-control"></asp:TextBox>
                    <asp:Label ID="lbError" runat="server" Text="" ForeColor="#ff0000"></asp:Label>
                </div>
            </div>
            <div class="b-form-row">

                <asp:LinkButton ID="LinkButton1" CssClass="b-btn f-btn b-btn-md b-btn-default f-primary-b b-btn__w100" runat="server" OnClick="LinkButton1_Click">Gửi tin nhắn</asp:LinkButton>
            </div>
        </div>
    </div>
</div>

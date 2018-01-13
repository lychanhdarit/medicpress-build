<%@ Page Title="Đặt hẹn tư vấn" Language="C#" MasterPageFile="~/themes/thammydiamond/left-main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="dat_hen_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentDetailTab" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentSideLink" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentPost" runat="Server">
    <div class="b-blog-form-box">
        <h3 class="f-primary-b b-title-description f-title-description">Đặt lịch hẹn
        </h3>
        <div class="row">
            <div class="col-md-4">
                <div class="b-form-row">
                    <label class="b-form-vertical__label" for="create_account_email">Họ tên</label>
                    <div class="b-form-vertical__input">
                        <asp:TextBox ID="txtHoTen" runat="server" Height="50px" Width="100%" placeholder="Họ tên" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="b-form-row">
                    <label class="b-form-vertical__label" for="create_account_email">Số điện thoại</label>
                    <div class="b-form-vertical__input">
                          <asp:TextBox ID="txtSoDienThoai" runat="server" Height="50px" Width="100%" placeholder="Số điện thoại" class="form-control"></asp:TextBox>
                    </div>
                </div>
                 <div class="b-form-row">
                    <label class="b-form-vertical__label" for="create_account_email">Email</label>
                    <div class="b-form-vertical__input">
                          <asp:TextBox ID="txtEmail" runat="server" Height="50px" Width="100%" placeholder="Email" class="form-control"></asp:TextBox>
                    </div>
                </div>
               
               
            </div>
            <div class="col-md-8">
                <div class="b-form-row b-form--contact-size">
                    <label class="b-form-vertical__label" for="create_account_phone">Nội dung</label>
                  
                     <asp:TextBox ID="txtLoiNhan" runat="server" Height="50px" Width="100%" placeholder="Họ tên" class="form-control" Rows="10" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="b-form-row">
                  
                     <asp:Button ID="btnDatLich" runat="server" Text="Đặt lịch" OnClick="btnDatLich_Click" class="b-btn f-btn b-btn-md b-btn-default f-primary-b b-btn__w100" />
                </div>
            </div>
        </div>

    </div>
 
</asp:Content>


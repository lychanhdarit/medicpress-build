<%@ Control Language="C#" AutoEventWireup="true" CodeFile="latestNewsHome.ascx.cs" Inherits="Share_medical_latestNewsHome" %>
<div class="large-12 columns">
    
    <div class="large-12 columns">
                        <h2 class="h2-title">Bài viết mới</h2>
                    </div>
                    <div class="large-12 columns" style="text-align: center">
                        <img src="Share/images/line.png" style="max-width: 320px; margin: auto; margin-bottom: 30px" />
                    </div>
    <div class="row">
        <asp:Repeater ID="rplastNews" runat="server">
            <ItemTemplate>
                <div class="large-3 columns ">
                    <article class="post col-2 post-home">
                        <div class="post_img">
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt") %>' AlternateText='<%# Eval("Title") %>' > 
                              
                                <img src='<%# "../UploadFile/postImages/"+Eval("HinhAnh") %>' alt='<%# Eval("Title") %>' />
                            </asp:HyperLink>

                        </div>
						<div style="width: 115px;overflow:hidden">
							<div style="margin-top: 10px;" class='fb-like' data-href='<%# "~/" + Eval("id_tt")  %>' data-layout='standard' data-action='like' data-show-faces='true' data-share='true'></div>
						</div>
                        <h3>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/" + Eval("id_tt")  %>'> <%# Eval("tieude") %></asp:HyperLink></h3>
                        <p class="post_text"><%# Eval("Desc").ToString().Length > 75? Eval("Desc").ToString().Substring(0,75) : Eval("Desc") %> ...</p>
                        <a href='<%# "~/" + Eval("id_tt") %>' class="button">Xem thêm</a>

                    </article>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:Literal ID="ltCatNews" runat="server"></asp:Literal>
    
</div>

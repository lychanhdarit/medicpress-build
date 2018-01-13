<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FacebookManager.ascx.cs" Inherits="Share_layout_FacebookManager" %>
<div id="fb-root"></div>
<script>(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.7&appId=969083176533492";
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
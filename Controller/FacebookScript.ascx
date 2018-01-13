<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FacebookScript.ascx.cs" Inherits="Controller_FacebookScript" %>
<div id="fb-root"></div>
<script>(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = 'https://connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.11&appId=1255517557901711';
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>


<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_Style.ascx.cs" Inherits="admin_us_share_layout_Style" %>
<link rel="stylesheet" href='<%= ResolveUrl("~/admin-us/share/themes/bootstrap/css/bootstrap.min.css") %>' />
<!-- Font Awesome -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
<!-- Ionicons -->
<link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
<!-- jvectormap -->
<link rel="stylesheet" href='<%= ResolveUrl("~/admin-us/share/themes/plugins/jvectormap/jquery-jvectormap-1.2.2.css") %>' />
<!-- Theme style -->
<link rel="stylesheet" href='<%= ResolveUrl("~/admin-us/share/themes/dist/css/AdminLTE.min.css") %>' />
<!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
<link rel="stylesheet" href='<%= ResolveUrl("~/admin-us/share/themes/dist/css/skins/_all-skins.min.css") %>' />

<link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
<link rel="stylesheet" href='<%= ResolveUrl("~/admin-us/share/themes/plugins/fullcalendar/fullcalendar.min.css") %>' />
<link rel="stylesheet" href='<%= ResolveUrl("~/admin-us/share/themes/plugins/fullcalendar/fullcalendar.print.css") %>' media="print" />

<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
<style>
     .span-tb {
            color: red;
            padding: 5px;
            border: 1px solid #f00;
            border-radius: 5px;
            display: block;
        }

        .span-tb-green {
            color: #00ff21;
            padding: 5px;
            border: 1px solid #00ff21;
            border-radius: 5px;
            display: block;
        }
    .btn-blue {
        background:#4A93BD;
        border:none;
        border-bottom:3px solid #1E6188;
        border-radius:5px;
        color:#fff;
        padding:5px 20px 5px 20px
    }
    .btn-blue:hover {
        transition: background-color 0.5s ease;
        background-color: #2677a5;
    }

    .btn-orange {
        background:#F37213;
        border:none;
        border-bottom:3px solid #ff0000;
        border-radius:5px;
        color:#fff;
        padding:5px 20px 5px 20px
    }
    .btn-orange:hover {
        transition: background-color 0.5s ease;
        background-color: #9d4b10;
    }

    .btn-add-orange {
        background:#ff6a00;
        border:none;
        border-bottom:3px solid #ff0000;
        border-radius:5px;
        color:#fff;
        padding:5px 20px 5px 20px
    }
    .btn-add-orange:hover {
        transition: background-color 0.5s ease;
        background-color: #9d4b10;
    }
    .btn-add-blue {
        background:#4A93BD;
        border:none;
        border-bottom:3px solid #1E6188;
        border-radius:5px;
        color:#fff;
        padding:5px 20px 5px 20px
    }
    .btn-add-blue:hover {
        transition: background-color 0.5s ease;
        background-color: #2677a5;
    }
    .btn-xemtruoc {
        background:#e0dada;
        border:none;
        border-bottom:3px solid #8c8282;
        border-radius:5px;
        color:#ff6a00;
        padding:5px 20px 5px 20px
    }
    .btn-xemtruoc:hover {
        transition: background-color 0.5s ease;
        background-color: #9d4b10;
    }
    .btn-sua {
        background:#00a65a;
        border:none;
        border-bottom:3px solid #075a34;
        border-radius:5px;
        color:#fff;
        padding:5px 20px 5px 20px
    }
</style>

<script src='<%= ResolveUrl("~/admin-us/share/themes/plugins/jQuery/jQuery-2.1.4.min.js") %>'></script>
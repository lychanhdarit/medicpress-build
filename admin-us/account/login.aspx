<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_post_account_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- start: Meta -->
    <meta charset="utf-8" />
    <title>Đăng Nhập Hệ Thống</title>
    <meta name="description" content="Bootstrap Metro Dashboard" />
    <meta name="author" content="Dennis Ji" />
    <meta name="keyword" content="Metro, Metro UI, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina" />
    <!-- end: Meta -->

    <!-- start: Mobile Specific -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- end: Mobile Specific -->

    <!-- start: CSS -->
    <link  href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link  href="../css/style.css" rel="stylesheet" />
    <link  href="../css/style-responsive.css" rel="stylesheet" />
    <link href="../css/bootstrap-responsive.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800&subset=latin,cyrillic-ext,latin-ext' rel='stylesheet' type='text/css' />
    <!-- end: CSS -->


    <!-- The HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
	  	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
		<link  href="css/ie.css" rel="stylesheet">
	<![endif]-->

    <!--[if IE 9]>
		<link  href="css/ie9.css" rel="stylesheet">
	<![endif]-->

    <!-- start: Favicon -->
    <link rel="shortcut icon" href="img/favicon.ico" />
    <!-- end: Favicon -->

    <style type="text/css">
        body {
            background: url(../img/bg-login.jpg) !important;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid-full">
            <div class="row-fluid">

                <div class="row-fluid">
                    <div class="login-box">
                        <div class="icons">
                            <a href="index.html"><i class="halflings-icon home"></i></a>
                            <a href="#"><i class="halflings-icon cog"></i></a>
                        </div>
                        <h2>Đăng Nhập Hệ Thống</h2>
                        IP: <asp:Literal ID="ltIp" runat="server"></asp:Literal>
                        <fieldset>
                            <div class="input-prepend" title="Username">
                                <span class="add-on"><i class="halflings-icon user"></i></span>
                                <%--<input class="input-large span10" name="username" id="username" type="text" />--%>
                                <asp:TextBox ID="txtTen" CssClass="input-large span10" runat="server" placeholder="Nhập tên tài khoản"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>

                            <div class="input-prepend" title="Password">
                                <span class="add-on"><i class="halflings-icon lock"></i></span>
                                <asp:TextBox ID="txtMk" CssClass="input-large span10" runat="server" TextMode="Password" placeholder="Nhập mật khẩu" ></asp:TextBox>
                                <%--<input class="input-large span10" name="password" id="password" type="password" />--%>
                            </div>
                            <div class="clearfix"></div>

                            <label class="remember" for="remember">
                                <input type="checkbox" id="remember" />Ghi nhớ mật khẩu</label>

                            <div class="button-login">
                                <%--<button type="submit" >Login</button>--%>
                                <asp:Button ID="btnDangNhap" CssClass="btn btn-primary" runat="server" Text="Đăng Nhập" OnClick="btnDangNhap_Click" />
                            </div>
                            <div class="clearfix"></div>

                            <hr/>
                            <h3>Quên mật khẩu?</h3>
                            <p>
                                Không vấn đề, <a href="#">nhấp vào đây</a> để lấy mật khẩu.
				
                            </p>
                    </div>
                    <!--/span-->
                </div>
                <!--/row-->


            </div>
            <!--/.fluid-container-->

        </div>
        <!--/fluid-row-->

        <!-- start: JavaScript-->

        <script src="js/jquery-1.9.1.min.js"></script>
        <script src="js/jquery-migrate-1.0.0.min.js"></script>

        <script src="js/jquery-ui-1.10.0.custom.min.js"></script>

        <script src="js/jquery.ui.touch-punch.js"></script>

        <script src="js/modernizr.js"></script>

        <script src="js/bootstrap.min.js"></script>

        <script src="js/jquery.cookie.js"></script>

        <script src='js/fullcalendar.min.js'></script>

        <script src='js/jquery.dataTables.min.js'></script>

        <script src="js/excanvas.js"></script>
        <script src="js/jquery.flot.js"></script>
        <script src="js/jquery.flot.pie.js"></script>
        <script src="js/jquery.flot.stack.js"></script>
        <script src="js/jquery.flot.resize.min.js"></script>

        <script src="js/jquery.chosen.min.js"></script>

        <script src="js/jquery.uniform.min.js"></script>

        <script src="js/jquery.cleditor.min.js"></script>

        <script src="js/jquery.noty.js"></script>

        <script src="js/jquery.elfinder.min.js"></script>

        <script src="js/jquery.raty.min.js"></script>

        <script src="js/jquery.iphone.toggle.js"></script>

        <script src="js/jquery.uploadify-3.1.min.js"></script>

        <script src="js/jquery.gritter.min.js"></script>

        <script src="js/jquery.imagesloaded.js"></script>

        <script src="js/jquery.masonry.min.js"></script>

        <script src="js/jquery.knob.modified.js"></script>

        <script src="js/jquery.sparkline.min.js"></script>

        <script src="js/counter.js"></script>

        <script src="js/retina.js"></script>

        <script src="js/custom.js"></script>
        <!-- end: JavaScript-->

        
    </form>
</body>
</html>

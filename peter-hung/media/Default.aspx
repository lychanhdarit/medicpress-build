<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="peter_hung_media_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=yes">
    <link rel="stylesheet" type="text/css" href="slider_files/carousel.css">
    <!-- OWL CAROUSEL -->
    <link rel="stylesheet" type="text/css" href="slider_files/owl.css">
    <!-- JSCROLL BAR -->
    <link rel="stylesheet" type="text/css" href="slider_files/jquery.css">

    <!-- CSS BY ME -->
    <link rel="stylesheet" href="slider_files/style.css" type="text/css">
    <link rel="stylesheet" href="slider_files/custom.css" type="text/css">
    <!-- CSS NORMAL FOR RESPONSIVE -->
    <link rel="stylesheet" href="slider_files/style_normal.css" type="text/css">
    <!-- JQUERY -->
    <script async="" src="slider_files/www-widgetapi.js" id="www-widgetapi-script" type="text/javascript"></script>
  
    <script src="slider_files/jquery-1.js" type="text/javascript"></script>

    <style>
        * {
            box-sizing: border-box;
            -moz-box-sizing: border-box;
        }
    </style>
</head>
<body>

    <div id="intro-body" class="introapp">
        <div class="container">

            <!--    Slider    -->
            <div class="carousel intro-carousel" id="intro-pc">

                <div class="slides">
                    <div position="1" class="slideItem">
                        <a href="#">
                            <img src="img/ba-catmi-nangmui.png" alt="" /></a>
                    </div>
                    <div position="2" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui.png" alt="" /></a>
                    </div>
                    <div position="3" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui-bam-mi.png" alt="" /></a>
                    </div>
                    <div position="4" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui-cau-truc-1.png" alt="" /></a>
                    </div>
                    <div position="5" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui-cau-truc-2.png" alt="" /></a>
                    </div>
                    <div position="6" class="slideItem">
                        <a href="#">
                            <img src="img/ba-catmi-nangmui.png" alt="" /></a>
                    </div>
                    <div position="7" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui.png" alt="" /></a>
                    </div>
                    <div position="8" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui-bam-mi.png" alt="" /></a>
                    </div>
                    <div position="9" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui-cau-truc-1.png" alt="" /></a>
                    </div>
                    <div position="10" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui-cau-truc-2.png" alt="" /></a>
                    </div>
                </div>

                <div class="nextButton"></div>
                <div class="prevButton"></div>
                <div style="width: 234px; height: 26px;" class="buttonNav">
                    <div style="text-align: center;" class="bullet bulletActive"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet bulletActive"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                </div>
                <div class="nextButton"></div>
                <div class="prevButton"></div>
                <div style="width: 234px; height: 26px;" class="buttonNav">
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                </div>
            </div>
            <!--/    end Slider    -->

            <!--    Slider    -->
            <div class="carousel intro-carousel" id="intro-mobile">

                <div style="width: 250px; height: 250px;" class="slides">
                    <div position="8" style="width: 250px; height: 250px; top: 0px; right: 0px; opacity: 1; z-index: 8; display: block;" class="slideItem">
                        <a href="#">
                            <img src="img/ba-catmi-nangmui.png" /></a>
                    </div>
                    <div position="7" style="width: 200px; height: 200px; top: 25px; right: -130px; opacity: 1; z-index: 7; display: block;" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui.png" /></a>
                    </div>
                    <div position="6" style="width: 160px; height: 160px; top: 45px; right: -234px; opacity: 1; z-index: 6;" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui-bam-mi.png" /></a>
                    </div>
                    <div position="5" style="width: 128px; height: 128px; top: 61px; right: -317.2px; opacity: 0; z-index: 5; display: none;" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui-cau-truc-1.png" /></a>
                    </div>
                    <div position="4" style="width: 102.4px; height: 102.4px; top: 73.8px; right: -383.76px; opacity: 0; z-index: 4; display: none;" class="slideItem">
                        <a href="#">
                            <img src="img/ba-nang-mui-cau-truc-2.png" /></a>
                    </div>

                </div>

                <div class="nextButton"></div>
                <div class="prevButton"></div>
                <div style="width: 234px; height: 26px;" class="buttonNav">
                    <div style="text-align: center;" class="bullet bulletActive"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet bulletActive"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                </div>
                <div class="nextButton"></div>
                <div class="prevButton"></div>
                <div style="width: 234px; height: 26px;" class="buttonNav">
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                    <div style="text-align: center;" class="bullet"></div>
                </div>
            </div>
            <!--/    end Slider    -->



        </div>

    </div>
    <!-- FOOTER -->
    <script type="text/javascript" src="slider_files/easeljs-0.js"></script>
    <!--  Carousel on Intro page js  -->
    <script type="text/javascript" src="slider_files/jquery_006.js"></script>
    <!-- JS BY ME -->
    <script src="slider_files/TweenMax.js" type="text/javascript"></script>
    <script src="slider_files/main.js" type="text/javascript"></script>


</body>
</html>

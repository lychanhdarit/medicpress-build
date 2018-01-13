<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PluginFooter.ascx.cs" Inherits="Share_medical_PluginFooter" %>




<script src='<%= ResolveUrl("~/Share/js/foundation.min.js") %>'></script>
<script src='<%= ResolveUrl("~/Share/plugins/prettyphoto/jquery.prettyPhoto.js") %>'></script>
<script src='<%= ResolveUrl("~/Share/js/jquery.quicksand.js") %>'></script>

<script type="text/javascript">
    jQuery(document).ready(function($){
    
        //$("a[rel^='prettyPhoto']").click(function() {alert ('gag') });
        $('a[rel^="prettyPhoto"]').prettyPhoto({ theme: "dark_square" });

        var $filterType = $('.portfolio-main li.active a').attr('class');
        var $holder = $('ul.portfolio-content');
        var $data = $holder.clone();
        jQuery('.portfolio-main li a').click(function (e) {

            $('.portfolio-main li').removeClass('active');
            var $filterType = $(this).attr('class');
            $(this).parent().addClass('active');

            if ($filterType == 'all') {
                var $filteredData = $data.find('li');
            }
            else {
                var $filteredData = $data.find('li[data-type=' + $filterType + ']');
            }
            $holder.quicksand($filteredData,
                { duration: 800, easing: 'easeInOutQuad' },
                function () {
                    $("a[rel^='prettyPhoto']").prettyPhoto({ theme: 'dark_square' });

                }
            );
            return false;
        });
    });
</script>
<!-- Scripts Initialize -->
<script type="text/javascript" src='<%= ResolveUrl("~/Share/js/app-head-calls.js") %>'></script>
<script type="text/javascript" src='<%= ResolveUrl("~/Share/js/jquery.nivo.slider.pack.js") %>'></script>
<script type="text/javascript" src='<%= ResolveUrl("~/Share/js/datepicker.js") %>'></script>
<script>$(document).foundation();</script>

<!-- carouFredSel plugin -->
<script src='<%= ResolveUrl("~/Share/plugins/carouFredSel/jquery.carouFredSel-6.2.0-packed.js") %>'></script>
<script src='<%= ResolveUrl("~/Share/plugins/carouFredSel/helper-plugins/jquery.touchSwipe.min.js") %>'></script>

<!-- Smallipop JS - Tooltips -->
<!-- Smallipop JS - Tooltips -->
<script type="text/javascript" src='<%= ResolveUrl("~/Share/plugins/smallipop/lib/contrib/prettify.js") %>'></script>
<script type="text/javascript" src='<%= ResolveUrl("~/Share/plugins/smallipop/lib/jquery.smallipop.js") %>'></script> 
<script type="text/javascript" src='<%= ResolveUrl("~/Share/plugins/smallipop/lib/smallipop.calls.js") %>'></script>

<script>
    /*jshint jquery:true */
    jQuery.noConflict();

    jQuery(window).load(function () {
        "use strict";
        jQuery('#slider').nivoSlider({ controlNav: false });
    });
    jQuery(document).ready(function () {
        "use strict";
        jQuery('input.datepicker').Zebra_DatePicker();
        // Carousel
        jQuery("#carousel-type1").carouFredSel({
            responsive: true,
            width: '100%',
            auto: false,
            circular: false,
            infinite: false,
            items: {
                visible: { min: 1, max: 4 },
            },
            scroll: {
                items: 1,
                pauseOnHover: true
            },
            prev: {
                button: "#prev2",
                key: "left"
            },
            next: {
                button: "#next2",
                key: "right"
            },
            swipe: true
        });
        jQuery("#logo_slide").carouFredSel({
            responsive: true,
            width: '100%',
            circular: false,
            infinite: true,
            auto: false,
            scroll: { items: 1 },
            items: { visible: { min: 5 } },
            prev: { button: "#slide_prev2", key: "left" },
            next: { button: "#slide_next2", key: "right" }
        });
        jQuery(".work_slide ul").carouFredSel({
            circular: false,
            infinite: true,
            auto: false,
            scroll: { items: 1 },
            items: { visible: { min: 3, max: 3 } },
            prev: { button: "#slide_prev", key: "left" },
            next: { button: "#slide_next", key: "right" }
        });
        jQuery("#testimonial_slide").carouFredSel({
            circular: false,
            infinite: true,
            auto: false,
            scroll: { items: 1 },
            prev: { button: "#slide_prev1", key: "left" },
            next: { button: "#slide_next1", key: "right" }
        });


    });

    
</script>



<!-- Initialize JS Plugins -->
<script src='<%= ResolveUrl("~/Share/js/app-bottom-calls.js") %>'></script>

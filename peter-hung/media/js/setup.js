var now = new Date();
var day = ("0" + (now.getDate()+1)).slice(-2);
var month = ("0" + (now.getMonth() + 1)).slice(-2);
var tomorrow =  now.getFullYear() + "/"+ (month) +  "/" + (day) ;

$("#started")
.countdown("2017/05/01 09:00", function(event) {
  $(this).text(
    event.strftime('%D %H %M %S')
  );
});

$(document).ready(function(){
  $('.iframe').click(function(){
    jQuery(this).append('<div class="embed-responsive embed-responsive-16by9"> <iframe width="100%" height="100%" src="'+jQuery(this).attr('src')+'?autoplay=1" /></div>')
  })
  $(".menu li a,.dktop li a").click(function(){
       $("#navbar-header").removeClass("show");
  });

  // Add smooth scrolling to all links in navbar + footer link
  $(document).on("scroll", onScroll);
  $(".navbar a,.boxregist a, .regist a, footer a[href='#landingPage']").on('click', function(event) {
    // Make sure this.hash has a value before overriding default behavior
    if (this.hash !== "") {
      // Prevent default anchor click behavior
      event.preventDefault();

      // Store hash
      var hash = this.hash;

      // Using jQuery's animate() method to add smooth page scroll
      // The optional number (900) specifies the number of milliseconds it takes to scroll to the specified area
      $('html, body').animate({
        scrollTop: $(hash).offset().top-50
      }, 900);
      return false;
        var target = this.hash,
            menu = target;
        $target = $(target);
        $('html, body').stop().animate({
            'scrollTop': $(target).offset().top-50}, 70, 'swing', function () {
            window.location.hash = target;
            $(document).on("scroll", onScroll);
        });
    } // End if
  });

  function onScroll(event){
    var scrollPos = $(document).scrollTop();
    $('.menu  a').each(function () {
        var currLink = $(this);
        var refElement = $(currLink.attr("href"));
        if (refElement.position().top-70 <= scrollPos && refElement.position().top-50 + refElement.height() > scrollPos) {
           $('.menu  a').removeClass("active");
            currLink.addClass("active");
        }
        else{
            currLink.removeClass("active");
        }
    });
  }

  $(window).scroll(function() {
    $(".slideanim").each(function(){
      var pos = $(this).offset().top;

      var winTop = $(window).scrollTop();
        if (pos < winTop + 600) {
          $(this).addClass("slide");
        }
    });
  });
  setTimeout(function(){
    $(".header").css("opacity","1")
  },300);
});

$("#carousel-example-generic").carousel();
$("#carousel-example-generic2").carousel();
$("#carousel-example-generic").carousel({
  swipe: 30 // percent-per-second, default is 50. Pass false to disable swipe
});

//modal pupup onload
$(document).ready(function () {
  // $('#myModal').modal('show')
});

//carousel thumbnails
jQuery(document).ready(function($) {
  $('#myCarousel').carousel({
          interval: 5000
  });

  $('#carousel-text').html($('#slide-content-0').html());

  //Handles the carousel thumbnails
 $('[id^=carousel-selector-]').click( function(){
      var id = this.id.substr(this.id.lastIndexOf("-") + 1);
      var id = parseInt(id);
      $('#myCarousel').carousel(id);
  });

  // When the carousel slides, auto update the text
  $('#myCarousel').on('slid.bs.carousel', function (e) {
    var id = $('.carousel-item.active').data('slide-number');
    $('#carousel-text').html($('#slide-content-'+id).html());
  });
});
//fancybox
$(document).ready(function() {
  $(".fancybox").fancybox({
    openEffect  : 'none',
    closeEffect : 'none'
  });
  $(".various").fancybox({
    maxWidth  : 800,
    maxHeight : 300,
    fitToView : false,
    width   : '70%',
    height    : '70%',
    autoSize  : false,
    closeClick  : false,
    openEffect  : 'none',
    closeEffect : 'none'
  });
  $('.fancybox-media').fancybox({
    openEffect  : 'none',
    closeEffect : 'none',
    helpers : {
      media : {}
    }
  });

});
function layoutHandler() {
  if (window.innerWidth>480) {
    $('#slip2').carousel({
      interval: false
    });
  }
}
layoutHandler();
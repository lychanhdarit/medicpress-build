var windowWidth = $(window).width();
var v_player1,v_player2;
var fancyboxHeight, fancyboxWidth;
var arr = [], dem=0, rd_bee = true;

// CANVAS
var canvas = document.getElementById("demoCanvas");
var stage = new createjs.Stage(canvas);
var container_wrap = new createjs.Container();
var update = true;
var path_bg, img_bg;
var avatar, logo;
var step_1_bg;

function Page() {
	var self= this;

	this.init= function() {
		self.jquery();
		self.click_me();
		self.carousel();
		self.comic_carousel();
		self.pd_footer();
		self.linhtinh();
		// self.create_canvas();

		$(window).load(function(){
			self.aniHome();
			self.responsive();
		});

		$(window).resize(function(){
			self.responsive();
		});
	};

	this.jquery = function(){
		// call icon arrow button home
		loop();

		// call init carousel
		init_carousel();

		if($('.check').length>0){
			$('.check input').uniform();
		}

		// RADIO BUTTON STEP 4 TRANG UPLOAD
		if ($('.choose-gift ul li').length > 0){
			$(".choose-gift ul li input[type=radio]").uniform({
				radioClass: 'radio'
			});
		}

		// click open mobile menu
		$('.mb-menu-button .click-me').click(function() {
			var $this = $(this);
			if ($this.hasClass('on')) {
				$('.head-nav-mb').fadeIn('fast');    
			} else {
				$('.head-nav-mb').fadeOut('fast');  
			}
			mb_menu_on_off($this);
		});

		self.wd_resize();
		$(window).resize(function(){
			self.wd_resize()
			self.pd_footer();
		})

		// fancybox
		$('.fcb-btn').fancybox({
			padding: 0,
			fitToView: false,
			closeBtn: false,
			autoResize: true,
			beforeShow: function(){
				$('.fancybox-wrap').addClass('user-popup');
			}
		})

		// fancybox
		$('.cl-btnfcb').click(function(){
			$.fancybox.close();
		})

		// loadYoutube video
		loadYouTube();
		// scroll page (menu header, number index, bubble index)
		scroll_menu();
	}

	// CREATE CANVAS
	this.create_canvas = function() {
		canvas.width = 548;
		canvas.height = 548;

		// enable touch interactions if supported on the current device:
		createjs.Touch.enable(stage);
		// enabled mouse over / out events
		stage.enableMouseOver(10);
		stage.mouseMoveOutside = true; // keep tracking the mouse even when it leaves the canvas

		// CREATE AVATAR
		avatar = new Image();
		avatar.src = "../assets/images/img/goku.jpg";
		
		var bitmap_ava = new createjs.Bitmap(avatar);
		bitmap_ava.scaleX = bitmap_ava.scaleY = 0.5;
		container_wrap.addChildAt(bitmap_ava, 0);
		createjs.Ticker.addEventListener("tick", tick);

		bitmap_ava.on("dblclick", function(evt) {
			alert("Click avatar");
		});

		bitmap_ava.on("mousedown", function (evt) {
			this.parent.addChild(this);
			this.offset = {x: this.x - evt.stageX, y: this.y - evt.stageY};
		});

		// the pressmove event is dispatched when the mouse moves after a mousedown on the target until the mouse is released.
		bitmap_ava.on("pressmove", function (evt) {
			this.x = evt.stageX + this.offset.x;
			this.y = evt.stageY + this.offset.y;
			// indicate that the stage should be updated on the next tick:
			update = true;
		});

		bitmap_ava.on("pressup", function (evt) {
			container_wrap.setChildIndex(bitmap_ava, 0);
			update = true;
		});
		

		// CREATE BACKGROUND FROM
		step_1_bg = new Image();
		step_1_bg.src = '../assets/images/img/bg-blue.png';

		var bitmap = new createjs.Bitmap(step_1_bg);
		bitmap.scaleX = bitmap.scaleY = 0.3287342531493701;
		container_wrap.addChildAt(bitmap, 1);
		createjs.Ticker.addEventListener("tick", tick);

		// CREATE LOGO
		logo = new Image();
		logo.src = "../assets/images/img/logo-canvas.png";
		
		var bitmap_logo = new createjs.Bitmap(logo);
		bitmap_logo.x = 400;
		bitmap_logo.y = 480;
		bitmap_logo.scaleX = bitmap_logo.scaleY = 0.5;
		container_wrap.addChildAt(bitmap_logo, 2);
		createjs.Ticker.addEventListener("tick", tick);

		
		chooseBackground();
		// CONTAINER ADD CHILD (BACK GROUND)
		container_wrap.addChild(img_bg);
		// STAGE ADD CONTAINER
		stage.addChild(container_wrap);
		stage.update();
	}

	this.linhtinh = function() {
		// canh man hinh cho popup trang chu
			var w_height = $(window).height();
			var popup_home_height = $('.po-view-img').height();
			var w_top = (w_height - 563)/2;

			$('.po-view-img').css({'top': w_top});

		// GOI HAM RANDOM CHO TRANG INDEX
		bubble_ani();
	}

	this.wd_resize = function(){
		windowWidth = $(window).width();
		if(windowWidth > 1140){
			$('.header .head-nav-mb').hide();
		}
	}

	this.click_me = function() {
		// CALL POPUP TRANG CHU
		// home index - call popup
		$('.square-img').on("click",".item", function(){
			$('.base-popup').fadeIn(300);
		});
		// home index - close popup
		$('.po-view-img .po-close').click(function(){
			$('.base-popup').fadeOut(300);
		});
		$('.base-popup').click(function(){
			$('.base-popup').fadeOut(300);
		});
		$('.base-popup .wr-page').click(function(event){
			event.stopPropagation();
		});

		// CLICK NUT SCROLL TRANG CHU
		$('.discovery a').click(function(event){
			$('html, body').animate({
				scrollTop: $('.content').offset().top - 45}, 500);	
		});
	}

	this.carousel = function() {
		// HOME - POPUP CAROUSEL
		var home_owl = $("#home-po-carousel");
		home_owl.owlCarousel({
			navigation : false, // Show next and prev buttons
			slideSpeed : 300,
			paginationSpeed : 400,
			singleItem: true,
			autoPlay: 5000
		});
		// Custom Navigation Events
		$(".home-po-next").click(function(){
			home_owl.trigger('owl.next');
		})
		$(".home-po-prev").click(function(){
			home_owl.trigger('owl.prev');
		})
	}

	this.pd_footer = function() {
		if ($(window).width() <= 980) {
			var h = $('.footer').height() + 15;
			$('.wrapper').css({'padding-bottom': h});
		} else {
			$('.wrapper').css({'padding-bottom': 0});
		}
	}

	//	carousel comic
	this.comic_carousel = function() {

		// HOME - POPUP CAROUSEL
		var home_owl = $("#comic-carousel");
		home_owl.owlCarousel({
		navigation : false, // Show next and prev buttons
		slideSpeed : 300,
		paginationSpeed : 400,
		singleItem: true
		});
		// Custom Navigation Events
		$(".comic-next").click(function(){
			home_owl.trigger('owl.next');
		})
		$(".comic-prev").click(function(){
			home_owl.trigger('owl.prev');
		})
	}

	// Trang gallery
	this.gallery= function(){

		$('.date-filter, .week-filter').uniform({
			selectAutoWidth : false
		});

		var gs; 

		if($(window).width() > 1040){
			gs = ($('.grid').width() / 4) - 8.25;
		}
		if($(window).width() <= 1040){
			gs = ($('.grid').width() / 3) - 8.25;
		}
		if($(window).width() <= 850){
			gs = ($('.grid').width() / 2) - 8.25;
		}

		function gridSize(){
			if($(window).width() > 1040){
				gs = ($('.grid').width() / 4) - 8.25;
			}
			if($(window).width() <= 1040){
				gs = ($('.grid').width() / 3) - 8.25;
			}
			if($(window).width() <= 850){
				gs = ($('.grid').width() / 2) - 8.25;
			}

			$('.grid-item').css({
				'height': gs
			})
		}

		gridSize();

		$('.grid').masonry({
			itemSelector: '.grid-item',
			percentPosition: true,
			columnWidth: '.grid-sizer',
			gutter: 10
		});

		$(window).resize(function(){
			gridSize();
			$('.grid').masonry('layout');
		})
	};
	// End trang gallery

	this.responsive = function(){
		$(".thongbao").css({
			height: $(window).height() - $(".header").height() - $(".footer").height() - 15
		});
	};

	this.aniHome = function(){
		if ($(window).width() >= 1024) {
			TweenMax.to($(".banner-pc .tt"), 0.8, {opacity: 1, ease:Linear.easeNone});
			TweenMax.to($(".banner-pc .tt-1 img"), 1, {delay: 0.5, opacity: 1, top: 0, ease: Back.easeOut.config(0)});
			TweenMax.to($(".banner-pc .tt-2 img"), 1, {delay: 0.8, opacity: 1, top: 0, ease: Back.easeOut.config(0)});
			TweenMax.to($(".present"), 0.8, {delay: 1.5, opacity: 1, ease: Back.easeOut.config(0)});
		}
	};
}

Page = new Page();
$(document).ready(function(){
	Page.init();
});

// CANVAS SELECT BACKGROUND
function chooseBackground() {
	$('.choose').on({
		click: function(){
			container_wrap.removeChild(img_bg);

			path_bg = $(this).data('img')
			img_bg = new createjs.Bitmap(path_bg);
			img_bg.scaleX= img_bg.scaleY = 0.3287342531493701;

			stage.update();
		}
	}, 'img');
}

// CANVAS UPDATE
function tick(event) {
	// this set makes it so the stage only re-renders when an event handler indicates a change has happened.
	if (update) {
		// update = false; // only update once
		stage.update(event);
	}
}

// scroll menu khi scroll mouse
function scroll_menu() {
	$(document).ready(function(){
		$(window).scroll(function(){
			if ($(window).scrollTop() > 1) {
				$('.header').addClass('fixed');
			} else {
				$('.header').removeClass('fixed');
			}
			
			// số trang chủ animate when scroll
			if ($(window).scrollTop() > 130) {
				if (!($('#home-num-inc').hasClass('ola'))) {
					var num_des = $('#home-num-inc').data('num');
					$({someValue: 0}).animate({someValue: num_des}, {
						duration: 2000,
						easing:'swing', // can be anything
						step: function() { // called on every step
							// Update the element's text with rounded-up value:
							// $('#home-num-inc').text(commaSeparateNumber(Math.round(this.someValue)));
							$('#home-num-inc').text(Math.round(this.someValue));
						}
					});
					function commaSeparateNumber(val){
						while (/(\d+)(\d{3})/.test(val.toString())){
							val = val.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
						}
						return val;
					}
					$('#home-num-inc').addClass('ola');
				}
			} 

			if ($(window).scrollTop() > 150) {
				if (!($('.content .grid.ind').hasClass('done'))) {
					// console.log(1)
					bubble_ani_run();
					$('.content .grid').addClass('done');
				}
			}
		})
	})
}

function bubble_ani() {
	for (i = 0; i <= 10; i++) {
		arr.push(i);
	}
	arr = $.shuffle(arr);
}

function bubble_ani_run() {

	// TweenMax.to($(".grid-item.ola").staggerFrom, 0.3, {opacity: 1, scale: 1, ease:Linear.easeNone});

	var tl = new TimelineLite();
	tl.staggerTo(".grid-item.ola", 0.2, {opacity: 1, scale: 1, ease:Linear.easeNone}, 0.1);
	// dem++;
	// tl.from(head, 0.5, {left:100, opacity:0});
	// tl.staggerFrom(icons, 0.2, {scale:0, autoAlpha:0}, 0.1, "stagger");

	// setTimeout(function(){
	// 	bubble_ani_run();
	// }, 200)
}

// call icon arrow button home
function loop() {
	if( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) {
		$('.arr-scroll')
		.animate({bottom: 1}, 500)
		.animate({bottom:-3}, 400, loop);
	} else {
		$('.arr-scroll')
		.animate({bottom: 0}, 500)
		.animate({bottom:-5}, 400, loop);
	}
}

// [intro page] Carousel
function init_carousel(){
	// if(windowWidth < 1080 && windowWidth > 850){
	// 	$('#intro-carousel').carousel({
	// 		directionNav: true,
	// 		slidesPerScroll: 3,
	// 		frontWidth: 394,
	// 		frontHeight: 394,
	// 		carouselWidth: 327,
	// 		carouselHeight: 327,
	// 		hMargin : 0.65,
	// 		vMargin : 0.3,
	// 		autoplay: false,
	// 		shadow: false,
	// 		after : function (carousel) {
	// 		//console.log(carousel);
	// 		}
	// 	});
	// } else if(windowWidth < 850){
	// 	$('#intro-carousel').carousel({
	// 		directionNav: true,
	// 		slidesPerScroll: 1,
	// 		frontWidth: 250,
	// 		frontHeight: 250,
	// 		carouselWidth: 250,
	// 		carouselHeight: 250,
	// 		hMargin : 0,
	// 		vMargin : 0,
	// 		autoplay: false,
	// 		shadow: false,
	// 		after : function (carousel) {
	// 			//console.log(carousel);
	// 		}
	// 	});
	// } else {
	// 	$('#intro-carousel').carousel({
	// 		directionNav: true,
	// 		slidesPerScroll: 5,
	// 		frontWidth: 394,
	// 		frontHeight: 394,
	// 		carouselWidth: 327,
	// 		carouselHeight: 327,
	// 		hMargin : 0.65,
	// 		vMargin : 0.3,
	// 		autoplay: false,
	// 		shadow: false,
	// 		after : function (carousel) {
	// 			//console.log(carousel);
	// 		}
	// 	});
	// }

	$('#intro-carousel').carousel({
		directionNav: true,
		slidesPerScroll: 5,
		frontWidth: 350,
		frontHeight: 430,
		carouselWidth: 327,
		carouselHeight: 327,
		hMargin : 0.65,
		vMargin : 0.3,
		autoplay: false,
		shadow: false,
		after : function (carousel) {
			//console.log(carousel);
		}
	});

	$('#intro-pc').carousel({
		directionNav: true,
		slidesPerScroll: 5,
		frontWidth: 350,
		frontHeight: 430,
		carouselWidth: 327,
		carouselHeight: 327,
		hMargin : 0.65,
		vMargin : 0.3,
		autoplay: false,
		shadow: false,
		after : function (carousel) {
			//console.log(carousel);
		}
	});

	$('#intro-mobile').carousel({
		directionNav: true,
		slidesPerScroll: 5,
		frontWidth: 250,
		frontHeight: 250,
		carouselWidth: 250,
		carouselHeight: 250,
		hMargin : 0.65,
		vMargin : 0.3,
		autoplay: false,
		shadow: false,
		after : function (carousel) {
			//console.log(carousel);
		}
	});

	// resize carosel
	$(window).on('resize', function(){
		// if(windowWidth < 1080){
		// 	$('.carousel').carousel({
		// 		directionNav: true,
		// 		slidesPerScroll: 3,
		// 		frontWidth: 394,
		// 		frontHeight: 394,
		// 		carouselWidth: 327,
		// 		carouselHeight: 327,
		// 		hMargin : 0.65,
		// 		vMargin : 0.3,
		// 		autoplay: false,
		// 		shadow: false,
		// 		after : function (carousel) {
		// 			//console.log(carousel);
		// 		}
		// 	});
		// }
	})

	// if($("#intro-carousel").length > 0){
	// 	if(windowWidth < 1080 && windowWidth > 850){
	// 		$('#intro-carousel').carousel({
	// 			directionNav: true,
	// 			slidesPerScroll: 3,
	// 			frontWidth: 394,
	// 			frontHeight: 394,
	// 			carouselWidth: 327,
	// 			carouselHeight: 327,
	// 			hMargin : 0.65,
	// 			vMargin : 0.3,
	// 			autoplay: false,
	// 			shadow: false,
	// 			after : function (carousel) {
	// 				//console.log(carousel);
	// 			}
	// 		});
	// 	} else if(windowWidth < 850){
	// 		$('#intro-carousel').carousel({
	// 			directionNav: true,
	// 			slidesPerScroll: 1,
	// 			frontWidth: 250,
	// 			frontHeight: 250,
	// 			carouselWidth: 250,
	// 			carouselHeight: 250,
	// 			hMargin : 0,
	// 			vMargin : 0,
	// 			autoplay: false,
	// 			shadow: false,
	// 			after : function (carousel) {
	// 				//console.log(carousel);
	// 			}
	// 		});
	// 	} else {
	// 		$('#intro-carousel').carousel({
	// 			directionNav: true,
	// 			slidesPerScroll: 5,
	// 			frontWidth: 394,
	// 			frontHeight: 394,
	// 			carouselWidth: 327,
	// 			carouselHeight: 327,
	// 			hMargin : 0.65,
	// 			vMargin : 0.3,
	// 			autoplay: false,
	// 			shadow: false,
	// 			after : function (carousel) {
	// 				//console.log(carousel);
	// 			}
	// 		});
	// 	}
	// }
}

// [intro page] Load youtube khi click mở fancybox
function loadYouTube(){
	if (windowWidth > 640) {
		fancyboxWidth = 640;
		fancyboxHeight = 390;
	} else {
		fancyboxWidth = 320;
		fancyboxHeight = 195;
	}
	if($('#play-video-1').length > 0 && $('#play-video-2').length > 0){
		$('#play-video-1').fancybox({
			'titlePosition'     : 'inside',
			'transitionIn'      : 'none',
			'transitionOut'     : 'none',
			"padding": 32,
			afterLoad : function() {
				setTimeout(function(){
					v_player1.playVideo();
				}, 1000)
			},
			afterClose : function(){
				v_player1.stopVideo();
			}
		});
		$('#play-video-2').fancybox({
			'titlePosition'     : 'inside',
			'transitionIn'      : 'none',
			'transitionOut'     : 'none',
			"padding": 32,
			afterLoad : function() {
				setTimeout(function(){
					v_player2.playVideo();
				}, 1000)
			},
			afterClose : function(){
				v_player2.stopVideo();
			}
		});
	}
}

function onPlayerReady(event) {
	//v_player1.addEventListener('onStateChange', function(e) {
	//    console.log('State is:', e.data);
	//});
}

// click open mobile menu  
function mb_menu_on_off($this_click) {
	if ($this_click.hasClass('on')) {
		$this_click.removeClass('on');
		$this_click.addClass('off');
	} else {
		$this_click.removeClass('off');
		$this_click.addClass('on');
	}
}

// Load youtube video, không biết sao phải để ở ngoài nó mới ăn :(
var tag = document.createElement('script');

tag.src = "https://www.youtube.com/iframe_api";
var firstScriptTag = document.getElementsByTagName('script')[0];
firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);
function onYouTubeIframeAPIReady() {
	v_player1 = new YT.Player('player1', {
		height: fancyboxHeight,
		width: fancyboxWidth,
		rel : 0,
		videoId: 'ldANY6Q3aHA',
		events: {
			'onReady': onPlayerReady,
			'onStateChange': onPlayerStateChange
		}
	});
	v_player2 = new YT.Player('player2', {
		height: fancyboxHeight,
		width: fancyboxWidth,
		videoId: 'gEgKuoU67Gk',
		rel : 0,
		events: {
			'onReady': onPlayerReady,
			'onStateChange': onPlayerStateChange
		}
	});
}

// [intro page] Đóng fancybox khi youtube chạy xong
function onPlayerStateChange(event) {
	if(event.data === 0){

		parent.$.fancybox.close();
	}
}
//  end load youtube video

// SHUFFLE
(function($){

    $.fn.shuffle = function() {
        return this.each(function(){
            var items = $(this).children().clone(true);
            return (items.length) ? $(this).html($.shuffle(items)) : this;
        });
    }
    
    $.shuffle = function(arr) {
        for(var j, x, i = arr.length; i; j = parseInt(Math.random() * i), x = arr[--i], arr[i] = arr[j], arr[j] = x);
        return arr;
    }
})(jQuery);
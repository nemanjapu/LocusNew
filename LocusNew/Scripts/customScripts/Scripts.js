$(window).scroll(function (e) {
	if ($(window).scrollTop() >= 10) {
		$('.menu-cont').addClass('sticky-menu');
		$('.top-bar').addClass('sticky-top-bar');
	}
	else {
		$('.menu-cont').removeClass('sticky-menu');
		$('.top-bar').removeClass('sticky-top-bar');
	}
});
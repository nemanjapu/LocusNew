$(".side-image > img").height($(window).height());
$(window).on("resize", function () {
    $(".side-image > img").height($(window).height());
});
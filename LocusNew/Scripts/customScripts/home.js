$(document).ready(function () {
    var height = $(window).height();
    $('.banner-img').css('height', height);
    window.onresize = function () {
        var height = $(window).height();
        $('.banner-img').css('height', height);
    };
    $("#cityPart").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/search/citiesautocomplete',
                datatype: "json",
                data: {
                    term: request.term
                },
                success: function (data) {
                    response($.map(data, function (val, item) {
                        return {
                            label: val.Name,
                            value: val.Name,
                            Id: val.Id
                        };
                    }));
                }
            });
        },
        select: function (event, ui) {
            $("#cityPartId").val(ui.item.Id);
        }
    });
    $(".listings-carousel").owlCarousel({
        items: 1,
        loop: true,
        nav: false,
        dots: true,
        autoplay: true
    });

    $('#form0').submit(function () {
        if ($('#form0').valid()) {
            $(this).find(':submit').attr('disabled', 'disabled');
            $('#ShowingSubmitBtn').html('<i class="fa fa-spinner fa-spin"></i>');
        }
    });
});
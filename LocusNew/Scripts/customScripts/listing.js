var todaysDate = "";
function GetTodaysDate(date) {
    todaysDate = date;
}
$(document).ready(function () {
    $(".listing-preview-images-carousel").owlCarousel({
        items: 5,
        loop: false,
        nav: false,
        dots: false,
        autoplay: false,
        margin: 5
    });
    lightbox.option({
        'resizeDuration': 200,
        'wrapAround': true,
        'showImageNumberLabel': false
    });
    $('#form0').submit(function () {
        if ($("#form0").valid()) {
            $(this).find(':submit').attr('disabled', 'disabled');
            $('#ShowingSubmitBtn').html('<i class="fa fa-spinner fa-spin"></i>');
        }
    });
    $(function () {
        $("#BookAShowing_DateForShowing").datepicker({
            dateFormat: 'dd.mm.yy',
            minDate: todaysDate
        });
    });
});

var defaultBounds;
function GetDefaultBounds(lat, lon) {
    var latitude = parseFloat(lat);
    var longitude = parseFloat(lon);
    defaultBounds = new google.maps.LatLng(latitude, longitude);
}

function initialize() {
    var markers = [];
    var map = new google.maps.Map(document.getElementById("listing-map"), {
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });
    var image = {
        url: "/Content/images/pin.png",
        scaledSize: new google.maps.Size(50, 50)
    };
    var markerForPlace = new google.maps.Marker({
        map: map,
        icon: image,
        position: defaultBounds,
        animation: google.maps.Animation.DROP,
    });
    markerForPlace.setMap(map);

    map.setCenter(defaultBounds);
    map.setZoom(17);
}
google.maps.event.addDomListener(window, "load", initialize);
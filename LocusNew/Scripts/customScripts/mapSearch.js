//MAP HEIGHT
$('#map-canvas').height($(window).outerHeight() - ($('.main-footer').outerHeight() + $('.top-bar').outerHeight() + $('.menu-cont').outerHeight()));
//MAP HEIGHT

var locations = [];
var mcOptions = {
    styles: [{
        url: "/Content/images/map-cluster2.png",
        height: 80,
        width: 80,
        textColor: 'white'
    }]
};

var map;
var geocoder = new google.maps.Geocoder();

function initialize() {
    $.ajax({
        type: 'POST',
        url: '/mapsearch/getlistings',
        dataType: 'json',
        data: {},
        success: function (data) {
            $.each(data, function (i, item) {
                if (item.Latitude !== null || item.Longitude !== null) {
                    var tempLat = parseFloat(item.Latitude);
                    var tempLon = parseFloat(item.Longitude);
                    var loc = { lat: tempLat, lng: tempLon };
                    locations.push(loc);
                }
            });
            map = new google.maps.Map(document.getElementById('map-canvas'), {
                zoom: 10,
                center: { lat: 43.863490, lng: 18.391193 }
            });

            var image = {
                url: "/Content/images/homes-location.png",
                scaledSize: new google.maps.Size(50, 50)
            };

            // Add some markers to the map.
            // Note: The code uses the JavaScript Array.prototype.map() method to
            // create an array of markers based on a given "locations" array.
            // The map() method here has nothing to do with the Google Maps API.
            var markers = locations.map(function (location) {
                return new google.maps.Marker({
                    position: location,
                    icon: image
                });
            });

            // Add a marker clusterer to manage the markers.
            var markerCluster = new MarkerClusterer(map, markers, mcOptions);
        },
        error: function (ex) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
        }
    });
}

document.getElementById('submit').addEventListener('click', function () {
    geocodeAddress(geocoder, map);
});

function geocodeAddress(geocoder, resultsMap) {
    var address = document.getElementById('address').value  + ", Sarajevo";
    if (address !== "") {
        geocoder.geocode({ 'address': address }, function (results, status) {
            if (status === 'OK') {
                resultsMap.setCenter(results[0].geometry.location);
                resultsMap.setZoom(17);
            } else {
                alert('Geocode was not successful for the following reason: ' + status);
            }
        });
    }
}

$(document).ready(function () {
    $("#address").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/mapsearch/mapsearchautocomplete',
                datatype: "json",
                data: {
                    term: request.term
                },
                success: function (data) {
                    response($.map(data, function (val, item) {
                        return {
                            label: val.Name,
                            value: val.Name
                        };
                    }));
                }
            });
        },
        select: function (event, ui) {
            $("#cityPartId").val(ui.item.Id);
        }
    });
})

google.maps.event.addDomListener(window, "load", initialize);
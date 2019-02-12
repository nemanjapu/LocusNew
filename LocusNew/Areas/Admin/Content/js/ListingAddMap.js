var existingMarker = "";

function GetLatLonOnEditListing(lat, lon) {
    existingMarker = new google.maps.LatLng(lat, lon);
}

function initialize() {
    var markers = [];
    var markers2 = [];
    var map = new google.maps.Map(document.getElementById("map-canvas"), {
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        zoom: 20,
        draggableCursor: 'pointer'
    });

    var image = {
        url: "/Content/images/pin.png",
        scaledSize: new google.maps.Size(50, 50)
    };

    if (existingMarker !== "") {
        var markerForPlace = new google.maps.Marker({
            map: map,
            icon: image,
            position: existingMarker,
            animation: google.maps.Animation.DROP
        });
        for (var i = 0; i < markers2.length; i++) {
            markers2[i].setMap(null);
            markers2 = [];
        }
        markers2.push(markerForPlace);
        for (var i = 0; i < markers2.length; i++) {
            markers2[i].setMap(map);
        }

        map.setCenter(existingMarker);
    }
    else {
        var defaultBounds = new google.maps.LatLngBounds(
            new google.maps.LatLng(43.847945, 18.360603),
            new google.maps.LatLng(43.858166, 18.439339),
        );
        map.fitBounds(defaultBounds);
    }

    // Create the search box and link it to the UI element.
    var input = (document.getElementById("pac-input"));

    var options = {
        componentRestrictions: { country: 'ba' }
    };
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    var searchBox = new google.maps.places.Autocomplete(
	/** @type {HTMLInputElement} */(input), options);

    // [START region_getplaces]
    // Listen for the event fired when the user selects an item from the
    // pick list. Retrieve the matching places for that item.
    google.maps.event.addListener(searchBox, "place_changed", function () {
        var places = searchBox.getPlace();

        if (places.geometry.viewport) {
            map.fitBounds(places.geometry.viewport);
        } else {
            map.setCenter(places.geometry.location);
            map.setZoom(17);
        }
    });
    // [END region_getplaces]

    // Bias the SearchBox results towards places that are within the bounds of the
    // current map's viewport.
    google.maps.event.addListener(map, "bound_changed", function () {
        var bounds = map.getBound();
        searchBox.setCenter(bounds);
    });
    
    google.maps.event.addListener(map, 'click', function (event) {
        //alert("Latitude: " + event.latLng.lat() + " " + ", longitude: " + event.latLng.lng());
        $("#Latidute").val(event.latLng.lat());
        $("#Longitude").val(event.latLng.lng());

        var myLatlng = new google.maps.LatLng(event.latLng.lat(), event.latLng.lng());

        var markerForPlace = new google.maps.Marker({
            map: map,
            icon: image,
            position: myLatlng,
            animation: google.maps.Animation.DROP
        });
        for (var i = 0; i < markers2.length; i++) {
            markers2[i].setMap(null);
            markers2 = [];
        }
        markers2.push(markerForPlace);
        for (var i = 0; i < markers2.length; i++) {
            markers2[i].setMap(map);
        }
        //markerForPlace.setMap(map);
    });
}

google.maps.event.addDomListener(window, "load", initialize);
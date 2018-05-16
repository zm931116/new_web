var markers = [];
var infoWindow;
var infowindowM;
var markerCluster;
var map;
var myLocation;

function initMap() {
    var mainCenter = {
        lat: -37.80453,
        lng: 144.9799
    };






    

    //init map
    map = new google.maps.Map(document.getElementById('laundry_map'), {
        zoom: 12,
        center: mainCenter
    });





    // Infowindow for location setting

    infoWindow = new google.maps.InfoWindow;

    //Infowindow for Marker
    infowindowM = new google.maps.InfoWindow({
        maxWidth: 200
    });






   






    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            myLocation = pos;
            infoWindow.setPosition(pos);
            infoWindow.setContent('Your Location!');
            infoWindow.open(map);
            map.setCenter(pos);
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());

    }

    markerCluster = new MarkerClusterer(map, markers,
        { imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m' });




    document.getElementById("locating_bt").onclick = function () {
        goToMyLocation(map, myLocation, infoWindow);
    };



}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
    infoWindow.open(map);
}

//Removes the markers from the map, but keeps them in the array.

function clearMarkers(markers) {
    setMapOnAll(null, markers);
}

// Sets the map on all markers in the array.
function setMapOnAll(map, markers) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

function addmarkers(listName, map, infowindowM, markers) {
    var marker, i;

    markers = listName.map(function (location, i) {
        var marker = new google.maps.Marker({
            position: location,
            map: map

        });
        markers.push(marker);
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                var name = location.info + "\n";
                var go_google = "Get directions";
                var link_name = go_google.link("https://www.google.com/maps/search/?api=1&query=" + marker.position);
                infowindowM.setContent('<h4 >' + location.info + '</h4>' +
                    '<h4 >Requirement:</h4>' + location.condition + '<br>' + '<h4 >Available Time:</h4>' + location.available_time + '<br>' + link_name);
                infowindowM.open(map, marker);
            };
        })(marker, i));
        return marker;
    });


}
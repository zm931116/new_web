function initMap() {
    var mainCenter = {
        lat: -34.397,
        lng: 150.644
    };
    

    //init map
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: mainCenter
    });

    //add markers for accomadation

    // Infowindow for location setting
   
    var infoWindow = new google.maps.InfoWindow;

     //Infowindow for Marker
    var infowindowM = new google.maps.InfoWindow();
   
    

    var marker, i;

    var markers = ac_location.map(function (location, i) {
        var marker = new google.maps.Marker({
            position: location,
            map: map
        });
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infowindowM.setContent(location.info);
                infowindowM.open(map, marker);
            }
        })(marker, i));
        return marker;
        
       
        
    });

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            infoWindow.setPosition(pos);
            infoWindow.setContent('Location found.');
            infoWindow.open(map);
            map.setCenter(pos);
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
    infoWindow.open(map);
}



    









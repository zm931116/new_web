var markers = [];

function initMap() {
    var mainCenter = {
        lat: -34.397,
        lng: 150.644
    };

    
    
    var myLocation;   

    //init map
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 12,
        center: mainCenter
    });

    

    //add markers for accomadation

    // Infowindow for location setting
   
    var infoWindow = new google.maps.InfoWindow;

     //Infowindow for Marker
    var infowindowM = new google.maps.InfoWindow({
        maxWidth:200
    });
    

    var markerCluster;
       
    addmarkers(fd_locations, map, infowindowM, markers);
    addmarkers(ac_locations, map, infowindowM, markers);
    

    document.getElementById("type_selector").onchange = function () {
        console.log(this.value);
        
        markers=[]
        
        if (this.value == 1) {
            
            addmarkers(fd_locations, map, infowindowM, markers);
            
            
        }

        else if (this.value == 2) {
            
            addmarkers(ac_locations, map, infowindowM, markers);
            
            
        }

        else {
            addmarkers(ac_locations, map, infowindowM, markers);           
            addmarkers(fd_locations, map, infowindowM, markers);
        }
        console.log(markers.length);
        //clear markers in the cluster
        markerCluster.clearMarkers();
        //add new markers and redraw the clusters and markers
        markerCluster.addMarkers(markers, true)
            
    }

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            myLocation = pos;
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

     markerCluster = new MarkerClusterer(map, markers,
        { imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m' });

    


    document.getElementById("locating_bt").onclick = function()
    {
        goToMyLocation(map,myLocation,infoWindow);
    }
    
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
    setMapOnAll(null,markers);
}

// Sets the map on all markers in the array.
function setMapOnAll(map,markers) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}
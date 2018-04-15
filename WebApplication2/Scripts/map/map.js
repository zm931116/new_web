function initMap() {
    var mainCenter = {
        lat: -34.397,
        lng: 150.644
    };
    

    //init map
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 4,
        center: mainCenter
    });

    //add markers for accomadation

    // Infowindow for location setting
   
    var infoWindow = new google.maps.InfoWindow;

     //Infowindow for Marker
    var infowindowM = new google.maps.InfoWindow();
   
    console.log(ac_location);

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
        console.log(location);
       
        
    });
    
}








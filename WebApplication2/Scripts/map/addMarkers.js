﻿function addmarkers(listName,map,infowindowM,markers) {
    var marker, i;

    var markers = listName.map(function (location, i) {
        var marker = new google.maps.Marker({
            position: location,
            map: map
        });
        markers.push(marker);
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                var name = location.info +"\n";
                var go_google = "view on google map";
                var link_name = go_google.link("https://www.google.com/maps/search/?api=1&query=" + marker.position)
                infowindowM.setContent(name+link_name);
                infowindowM.open(map, marker);
            }
        })(marker, i));
        return marker;
    });
    
   
}
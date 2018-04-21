function addmarkers(listName,map,infowindowM,markers) {
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
                var go_google = "View this place on google map";
                var link_name = go_google.link("https://www.google.com/maps/search/?api=1&query=" + marker.position);
                infowindowM.setContent('<h4 >' + location.info + '</h4>' +
                    '<h4 >Requirement:</h4>' + location.condition + '<br>' + '<h4 >Available Time:</h4>' + location.available_time+'<br>'+link_name);
                infowindowM.open(map, marker);
            };
        })(marker, i));
        return marker;
    });
    
   
}
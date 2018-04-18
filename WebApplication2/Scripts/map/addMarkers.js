function addmarkers(listName,map,infowindowM) {
    var marker, i;

    var markers = listName.map(function (location, i) {
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
}
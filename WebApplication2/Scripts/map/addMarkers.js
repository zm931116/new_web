var iconBase = '../../images/';
var icons = {
    Accommodation: {
        icon: iconBase + 'rangerstation.png'
    },
    Food: {
        icon: iconBase + 'restaurant.png'
    },
    cl: {
        icon: iconBase + 'homegardenbusiness.png'
    }
    

}
var laundry_icon = {
    url:"../../images/laundry_marker.png"
}

function addmarkers(listName, map, infowindowM, markers) {
    var marker, i;
    
    markers = listName.map(function (location, i) {
        var marker = new google.maps.Marker({
            position: location,
            map: map,
            animation: google.maps.Animation.DROP,
            icon: icons[location['type']].icon
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

function add_toilets(listName, map, infowindowM, markers) {
    var marker, i;

    markers = listName.map(function (location, i) {
        var marker = new google.maps.Marker({
            position: location,
            //icon: iconBase + 'toilets.png',
            animation: google.maps.Animation.DROP,
            map: map
            

        });
        markers.push(marker);
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                var name = location.info + "\n";
                var go_google = "Get directions";
                var link_name = go_google.link("https://www.google.com/maps/search/?api=1&query=" + marker.position);
                infowindowM.setContent('<h4 >' + location.info + '</h4>' +
                    '<h4 >Male:</h4>' + location.male  + '<h4 >Female:</h4>' + location.female + '<br>'
                    + '<h4>Wheelchair</h4>' + location.wheelchair + '<br> ' + '<h4>Operator</h4>' + location.operator+'<br>'
                    + '<h4>baby facilities</h4>'+location.baby_facility + '<br>'+ link_name);
                infowindowM.open(map, marker);
            };
        })(marker, i));
        return marker;
    });


}

function add_fountains(listName, map, infowindowM, markers) {
    var marker, i;

    markers = listName.map(function (location, i) {
        var marker = new google.maps.Marker({
            position: location,
            map: map,
            animation: google.maps.Animation.DROP,

            icon: iconBase +'drinking_water.png'

        });
        markers.push(marker);
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                var name = location.info + "\n";
                var go_google = "Get directions";
                var link_name = go_google.link("https://www.google.com/maps/search/?api=1&query=" + marker.position);
                infowindowM.setContent('<h4 >' + location.info +'</h4> '+'<br>' + link_name);
                infowindowM.open(map, marker);
            };
        })(marker, i));
        return marker;
    });
}

function add_cityLinks(listName, map, infowindowM, markers) {
    var marker, i;

    markers = listName.map(function (location, i) {
        var marker = new google.maps.Marker({
            position: location,
            map: map,
            animation: google.maps.Animation.DROP,
            icon: icons['cl'].icon

        });
        markers.push(marker);
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                var name = location.info + "\n";
                var go_google = "Get directions";
                var link_name = go_google.link("https://www.google.com/maps/search/?api=1&query=" + marker.position);
                infowindowM.setContent('<h4 >' + location.info + '</h4> ' + '<br>'
                    + '<h4 >Address:</h4>' + location.Address + '<br>' + '<h4 >Opening Days:</h4>' + location.Opening_Days 
                    + '<h4>Opening Hours:</h4>' + location.Opening_Hours + '<br> '
                    + link_name);
                infowindowM.open(map, marker);
            };
        })(marker, i));
        return marker;
    });
}

function add_laundries(listName, map, infowindowM, markers) {
    var marker, i;

    markers = listName.map(function (location, i) {
        var marker = new google.maps.Marker({
            position: location,
            map: map,
            animation: google.maps.Animation.DROP,
            icon: icons['Accommodation'].icon

        });
        markers.push(marker);
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                var name = location.info + "\n";
                var go_google = "Get directions";
                var link_name = go_google.link("https://www.google.com/maps/search/?api=1&query=" + marker.position);
                infowindowM.setContent('<h4 >' + location.info + '</h4> ' + '<br>'
                    + '<h4 >Address:</h4>' + location.address + '<br>' + '<h4 >Opening Days:</h4>' + location.avai_days
                    + '<h4>Opening Hours:</h4>' + location.timings + '<br> '
                    + link_name);
                infowindowM.open(map, marker);
            };
        })(marker, i));
        return marker;
    });
}
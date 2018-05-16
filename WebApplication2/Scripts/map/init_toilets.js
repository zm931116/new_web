function convertPtObjects(location) {
    var newLocation = {
        lat: location.lat, lng: location.lon, info: location.name,
        male: location.male, female: location.female, wheelchair: location.wheelchair,
        operator: location.operator, baby_facility: location.baby_facil
    };
    return newLocation;
}
function get_toilets(list) {
    var k;
    var n_location;
    var newList = [];
    for (k = 0; k < list.length; k++) {
        n_location = convertPtObjects(list[k]);
        newList.push(n_location);
    }
    return newList;
}

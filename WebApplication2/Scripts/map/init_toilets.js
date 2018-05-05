function convertPtObjects(location) {
    var newLocation = {
        lat: location.lat, lng: location.lon, info: location.name,
        male: location.male, female: location.female, wheelchair: location.wheelchair,
        operator: location.operator, baby_facility: location.baby_facil
    };
    return newLocation;
}
function init_toilets() {
    var k;
    var n_location;
    for (k = 0; k < Ptlist.length; k++) {
        n_location = convertPtObjects(Ptlist[k]);
        pt_locations.push(n_location);
    }
}

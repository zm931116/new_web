
var ac_locations = [], fd_locations = [];


function convertObjects(location) {
    var newLocation = { lat: location.latitude, lng: location.longitude, info: location.org_name };
    return newLocation;
}


function init_orgList() {
    var i,j;
    var n_location;
    for (i = 0; i < Aclist.length; i++) {
        n_location = convertObjects(Aclist[i]);
        ac_locations.push(n_location);
    }
    for (j = 0; j < Fdlist.length; j++) {
        n_location = convertObjects(Fdlist[j]);
        fd_locations.push(n_location);
    }

}
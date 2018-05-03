function convertObjects(location) {
    var newLocation = {
        lat: location.latitude, lng: location.longitude, info: location.org_name,
        condition: location.org_condition, available_time: location.available_time
    };
    return newLocation;
}

function convertPtObjects(location) {
    var newLocation = {
        lat: location.lat, lng: location.lon, info: location.name,
        male: location.male, female: location.female, wheelchair: location.wheelchair,
        operator: location.operator, baby_facility: location.baby_facil
    };
    return newLocation;
}

function convertDfOjects(location) {
    var newLocation = {
        lat: location.latitude, lng: location.longitude,
        info: location.Description
    };
    return newLocation;
}

function convertClObjects(location) {
    var newLocation = {
        lat: location.Latitude, lng: location.Longitude, info: location.Centerlink_Location,
        address: location.Address, op_days: location.Opening_Days, op_hours: location.Opening_Hours
    };
    return newLocation;
}


function init_orgList() {
    var i,j,k,l;
    var n_location;
    for (i = 0; i < Aclist.length; i++) {
        n_location = convertObjects(Aclist[i]);
        ac_locations.push(n_location);
    }
    for (j = 0; j < Fdlist.length; j++) {
        n_location = convertObjects(Fdlist[j]);
        fd_locations.push(n_location);
    }

    for (k = 0; k < Ptlist.length; k++) {
        n_location = convertPtObjects(Ptlist[k]);
        pt_locations.push(n_location);
    }
    for (i = 0; i < Dflist.length; i++) {
        n_location = convertDfOjects(Dflist[i]);
        df_locations.push(n_location);
    }

    for (i = 0; i < Cllist.length; i++) {
        n_locaiton = convertClObjects(Cllist[i]);
        cl_locations.push(n_location);
    }

   

}
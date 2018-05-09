
//food and accomodation
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
    //console.log(location);
    var newLocation = {
        lat: location.Latitude, lng: location.Longitude,
        info: location.Centrelink_Location, Address: location.Address,
        Opening_Days: location.Opening_Days, Opening_Hours: location.Opening_Hours
    };
    //console.log(newLocation);
    
    return newLocation;
}

function convertLdObjects(location) {
    var newLocation = {
        lat: location.Latitude, lng: location.Longitude,
        info: location.Name, address: location.Address,
        avai_days: location.Avai_days, timings: location.Timings
    };
    return newLocation;
}

function init_laundryList() {
    var i;
    var n_location;
    for (i = 0; i < LaundryList.length; i++) {
        n_location = convertLdObjects(LaundryList[i]);
        ld_locations.push(n_location);
    }
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

    
    

}

function init_cllist() {
    var i;
    

    for (i = 0; i < Cllist.length; i++) {
        console.log(Cllist[i]);
        n_location = convertClObjects(Cllist[i]);
        console.log(n_location);
        cl_locations.push(n_location);


    }
}

function init_dfList() {
    var i;
    var n_location

    for (i = 0; i < Dflist.length; i++) {
        n_location = convertDfOjects(Dflist[i]);
        df_locations.push(n_location);
    }

}
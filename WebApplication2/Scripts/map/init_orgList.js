
//food and accomodation
function convertObjects(location) {
    var newLocation = {
        lat: location.latitude, lng: location.longitude, info: location.org_name,
        condition: location.org_condition, available_time: location.available_time,
        type : location.Type
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

function get_laundryList(list) {
    var i;
    var n_location,new_list = [];
    for (i = 0; i < list.length; i++) {
        n_location = convertLdObjects(list[i]);
        new_list.push(n_location);
    }
    return new_list;
}


function get_orgList(list) {
    var i;
    var n_location;
    var new_list = [];
    for (i = 0; i < list.length; i++) {
        n_location = convertObjects(list[i]);
        new_list.push(n_location);
    }
    return new_list;
}

function get_cllist(list) {
    var i,n_location,new_list =[]; 

    for (i = 0; i < list.length; i++) {
        console.log(list[i]);
        n_location = convertClObjects(list[i]);
        console.log(n_location);
        new_list.push(n_location);
    }
    return new_list;
}

function init_dfList() {
    var i;
    var n_location

    for (i = 0; i < Dflist.length; i++) {
        n_location = convertDfOjects(Dflist[i]);
        df_locations.push(n_location);
    }

}
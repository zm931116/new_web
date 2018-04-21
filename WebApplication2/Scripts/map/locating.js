function goToMyLocation(map,myLocation,infoWindow) {
    
    infoWindow.setPosition(myLocation);
    infoWindow.setContent('You are here');
    infoWindow.open(map);
    map.setCenter(myLocation);
    map.setZoom(12);
}


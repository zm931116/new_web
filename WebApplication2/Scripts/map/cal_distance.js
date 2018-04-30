/*
 Haversine formula:	a = sin²(Δφ/2) + cos φ1 ⋅ cos φ2 ⋅ sin²(Δλ/2)
c = 2 ⋅ atan2( √a, √(1−a) )
d = R ⋅ c
where	φ is latitude, λ is longitude, R is earth’s radius (mean radius = 6,371km);
note that angles need to be in radians to pass to trig functions!
 
 
 */

function cal_distance(lat1, lat2, lon1, lon2) {
    var R = 6371;//metres
    var a1 = lat1.toRadians();
    var a2 = lat2.toRadians();
    var b1 = (lat1 - lat2).toRadians();
    var b2 = (ln2 - lon1).toRadians();
    var a = Math.sin(b1 / 2) * Math.sin(b1 / 2) +
        Math.cos(a1) * Math.cos(a2) * Math.sin(b2 / 2) * Math.sin(b2 / 2);
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    return R * c;
}
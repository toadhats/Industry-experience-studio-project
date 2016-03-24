<html>
<head>
<script
src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDY0kkJiTPVd2U7aTOAwhc9ySH6oHxOIYM&sensor=false">
</script>

<script>
    var myCenter = new google.maps.LatLng(-37.817045, 144.961591);
    var Caulfield = new google.maps.LatLng(-37.882945, 145.022667);
    var Carnegie = new google.maps.LatLng(-37.884940, 145.058729);
    var GlenHuntly = new google.maps.LatLng(-37.889039, 145.042567);
function initialize()
{
var mapProp = {
  center: myCenter,
  zoom:10,
  mapTypeId: google.maps.MapTypeId.ROADMAP
  };

var map = new google.maps.Map(document.getElementById("googleMap"),mapProp);

var Caulfieldmarker = new google.maps.Marker({
    position: Caulfield,
  title:'Click to zoom'
});

var GlenHuntlymarker = new google.maps.Marker({
    position: GlenHuntly,
    title: 'Click to zoom'
});
  
var Carnegiemarker = new google.maps.Marker({
    position: Carnegie,
    title: 'Click to zoom'
});

var Caulfieldinfo = new google.maps.InfoWindow({
    content: "Welcome to caulfield"
});

var Carnegieinfo = new google.maps.InfoWindow({
    content: "Welcome to Carnegie"
});

var GlenHuntlyinfo = new google.maps.InfoWindow({
    content: "Welcome to Glen Huntly"
});
Carnegiemarker.setMap(map);
Caulfieldmarker.setMap(map);
GlenHuntlymarker.setMap(map);


// Zoom to 9 when clicking on marker
google.maps.event.addListener(Caulfieldmarker, 'click', function () {
  map.setZoom(13);
  map.setCenter(Caulfieldmarker.getPosition());
  Caulfieldinfo.open(map, Caulfieldmarker);
});

google.maps.event.addListener(Carnegiemarker, 'click', function () {
    map.setZoom(13);
    map.setCenter(Carnegiemarker.getPosition());
    Carnegieinfo.open(map, Carnegiemarker);
});

google.maps.event.addListener(GlenHuntlymarker, 'click', function () {
    map.setZoom(13);
    map.setCenter(GlenHuntlymarker.getPosition());
    GlenHuntlyinfo.open(map, GlenHuntlymarker);
});



     

}
google.maps.event.addDomListener(window, 'load', initialize);
</script>
<style>
#header {
    background-color:#222222;
    color:white;
    text-align:center;
    padding:5px;
}
#nav {
    line-height:30px;
    background-color:#0288F0;
    height:600px;
    width:100px;
    float:left;
    padding:5px;	      
}
#section {
    width:350px;
    float:left;
    padding:10px;	 	 
}
#footer {
    background-color:black;
    color:white;
    clear:both;
    text-align:center;
   padding:5px;	 	 
}
</style>
</head>
    <div id="header">
 <h1 aria-setsize="20" aria-sort="ascending">
     Where2Next Map Demo</h1>
<br />
        </div>
 <div id="nav">
     <br>
     <br>
Home<br>     <br>
Quiz<br>     <br>
Profiles     <br>
</div>

<body>
<div id="googleMap" style="width:1393px;height:580px;"></div>

</body>
</html>

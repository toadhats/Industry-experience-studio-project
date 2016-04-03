<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="Where2Next.Map" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script
src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDY0kkJiTPVd2U7aTOAwhc9ySH6oHxOIYM&sensor=false">
</script>

<script>
 var list = [{ suburb: "clayton", Loc: -37.930, Long: 145.120 }, { suburb: "caulfield", Loc: -37.880, Long: 145.030 }, { suburb: "St Kilda", Loc: -37.870, Long: 144.980 }];
    //this is list which need to change and fetch data from azure

var myCenter=new google.maps.LatLng(list[0].Loc,list[0].Long);
    // set cetner location in the map


function initialize()
{

var mapProp = {
  center:myCenter,     
  zoom:13,
  mapTypeId:google.maps.MapTypeId.ROADMAP
  };

var map=new google.maps.Map(document.getElementById("googleMap"),mapProp);

	
  for (x in list)                    //for loop to fetch each data and put into the map
{
var suburb=new google.maps.LatLng(list[x].Loc,list[x].Long);
var marker=new google.maps.Marker({
    position: suburb,
    animation: google.maps.Animation.BOUNCE
  });
marker.setMap(map);

var Suburbinfo= new google.maps.InfoWindow({   //create suburbinformation window
    content: list[x].suburb

});
    Suburbinfo.open(map, marker);
}
	
}

google.maps.event.addDomListener(window, 'load', initialize);
</script>


        <br>
        <br>
        <div id="googleMap" style="width: 1200px; height: 600px;"></div>

    </asp:Content>

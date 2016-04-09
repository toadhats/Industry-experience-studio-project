<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mapfunction.aspx.cs" Inherits="Where2Next.Mapfunction" %>


<!DOCTYPE html>
    <script
src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDY0kkJiTPVd2U7aTOAwhc9ySH6oHxOIYM&sensor=false">
</script>
<script type="text/javascript">

    function currentPosition() {
        successLocation.style.display = 'none';
        failLocation.style.display = 'none';
        success.style.display = 'none';
        fail.style.display = 'none';
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var latitude = position.coords.latitude;
                var longitude = position.coords.longitude;
                var myLocation = new google.maps.LatLng(latitude, longitude);
                var mapOptions = {
                    zoom: 15,
                    center: myLocation,
                    mapTypeControl: true,
                    animation: google.maps.Animation.BOUNCE
                };
                map = new google.maps.Map(
                    document.getElementById("map_canvas"), mapOptions
                    );
                var marker = new google.maps.Marker({
                    position: myLocation,
                    map: map
                });
            });
            successLocation.style.display = "";
        } else {
            alert("Location function cannot support your browser.");
            failLocation.style.display = "";
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Where2Next Map Page </title>
   <link href="http://libs.baidu.com/bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet">
   <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js"></script>
   <script src="http://libs.baidu.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
</head><body style="background-color:#F3F9FE">
  <form id="form1" runat="server" >
         <br />
   <div id="success" class="alert alert-success" runat="server" style="display:none">
   <a href="#" class="close" data-dismiss="alert">&times;</a>
   <strong>Sucess！ </strong> The suburb can find in the map.
</div>
      <div id="fail" class="alert alert-warning" runat="server" style="display:none">
   <a href="#" class="close" data-dismiss="alert">&times;</a>
   <strong>fail! </strong>We cannot find your suburb in victoria.</div>
         <div id="successLocation" class="alert alert-success" runat="server" style="display:none">
   <a href="#" class="close" data-dismiss="alert">&times;</a>
   <strong>Sucess！ </strong> You are here!
</div>
      <div id="failLocation" class="alert alert-warning" runat="server" style="display:none">
   <a href="#" class="close" data-dismiss="alert">&times;</a>
   <strong>fail! </strong>We cannot find your location.</div>
       <asp:Panel ID="Panel1" runat="server">
           <asp:Literal ID="js" runat="server"></asp:Literal>
           <div id="map_canvas" style="width: 100%; height: 728px; 
		margin-bottom: 2px;">
           </div>
       </asp:Panel> 
       <div style="text-align:center"><h3>You can enter the suburb name or postcode to find your suburb&#39;s Location</h3><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
       <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Search Now" OnClick="Button1_Click" />
        <asp:Button class="btn btn-default" ID="Button2" runat="server" Text="Where am I now?" OnClick="Button2_Click" />
          </div>
     
</form>
</body> 
</html> 

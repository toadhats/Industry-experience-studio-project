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
   <strong>Success！ </strong> The suburb is found!
</div>
      <div id="fail" class="alert alert-warning" runat="server" style="display:none">
   <a href="#" class="close" data-dismiss="alert">&times;</a>
   <strong>Sorry! </strong>We cannot find your suburb in victoria.</div>
         <div id="successLocation" class="alert alert-success" runat="server" style="display:none">
   <a href="#" class="close" data-dismiss="alert">&times;</a>
   <strong>Success！ </strong> You are here!
</div>
      <div id="failLocation" class="alert alert-warning" runat="server" style="display:none">
   <a href="#" class="close" data-dismiss="alert">&times;</a>
   <strong>fail! </strong>We cannot find your location.</div>

      <div id="menu" style="height:700px;width:230px;float:left;">

 <div style="text-align:center"><h3>Find your suburb</h3><br />
     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br /><br />
     <div id="demo" class="collapse"><br />

         <div style="float:left;" ><asp:CheckBox ID="SchoolCheckBox" runat="server" type="checkbox"/></div><label>School</label><br />
         <div style="float:left;"><asp:CheckBox ID="CenterLinkBox" runat="server" type="checkbox"/></div><label>CenterLink</label><br />
         <div style="float:left;"><asp:CheckBox ID="LibraryBox" runat="server" type="checkbox"/></div><label>Library</label><br />
         <div style="float:left;"><asp:CheckBox ID="IceskatingBox" runat="server" type="checkbox"/></div><label>Iceskating</label><br />
         <div style="float:left;"><asp:CheckBox ID="DisabilityBox" runat="server" type="checkbox"/></div><label>Disability</label><br />
         <div style="float:left;"><asp:CheckBox ID="ArtspaceBox" runat="server" type="checkbox"/></div><label>Artspace</label><br />
         <div style="float:left;"><asp:CheckBox ID="CheckBox1" runat="server" type="checkbox"/></div><label>xxxxxx</label><br />
         <div style="float:left;"><asp:CheckBox ID="CheckBox2" runat="server" type="checkbox"/></div><label>xxxxxx</label><br />
         <div style="float:left;"><asp:CheckBox ID="CheckBox3" runat="server" type="checkbox"/></div><label>xxxxx</label><br />
         <div style="float:left;"><asp:CheckBox ID="CheckBox4" runat="server" type="checkbox"/></div><label>xxxxxx</label><br />
         <div style="float:left;"><asp:CheckBox ID="MedicareBox" runat="server" type="checkbox"/></div><label>Medicare</label><br /><br />
</div>
       <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Search Now" OnClick="Button1_Click" />
        <asp:Button class="btn btn-default" ID="Button2" runat="server" Text="My location" OnClick="Button2_Click" /><br /><br />


     <button type="button" class="btn btn-primary" data-toggle="collapse" 
   data-target="#demo">
 Advance search
</button></div>
          </div>
       <asp:Panel ID="Panel1" runat="server">
           <asp:Literal ID="js" runat="server"></asp:Literal>
           <div id="map_canvas" style="background-color:#EEEEEE;height:700px;width:900px;float:left;">
           </div>
       </asp:Panel> 
      
     
</form>
</body> 
</html> 

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
        failservice.style.display = 'none';
        successservice.style.display = 'none';

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
               <div id="successservice" class="alert alert-success" runat="server" style="display:none">
   <a href="#" class="close" data-dismiss="alert">&times;</a>
   <strong>Success！ </strong> There are some services in your suburb!
</div>
      <div id="failservice" class="alert alert-warning" runat="server" style="display:none">
   <a href="#" class="close" data-dismiss="alert">&times;</a>
   <strong>fail! </strong>We cannot find any service in your suburb.</div>

      <div id="menu" style="height:700px;width:230px;float:left;">

 <div style="text-align:center"><h3>Find your suburb</h3><br />
     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br /><br />
            <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Search Now" OnClick="Button1_Click" />
        <asp:Button class="btn btn-default" ID="Button2" runat="server" Text="My location" OnClick="Button2_Click" /><br /><br />
     <div id="demo" class="collapse"><br />
         
<table class="table table-hover">
   <thead>
      <tr>
         <th>service name</th>
  
      </tr>
   </thead>
   <tbody>
      <tr>
         <td> <div style="float:left;" ><asp:CheckBox ID="schooltest"  runat="server" type="checkbox"/></div><label>School</label><br /></td>
 
      </tr>
      <tr>
         <td><div style="float:left;"><asp:CheckBox ID="centrelink"  runat="server" type="checkbox"/></div><label>CenterLink</label><br /></td>
      </tr>

       <tr>
        <td> <div style="float:left;"><asp:CheckBox ID="library"   runat="server" type="checkbox"/></div><label>Library</label><br /></td>
       </tr>

              <tr>
        <td><div style="float:left;"><asp:CheckBox ID="iceskating"  runat="server" type="checkbox"/></div><label>Ice skating</label><br /></td>
       </tr>

              <tr>
        <td><div style="float:left;"><asp:CheckBox ID="disabilityactivity" enabled="false" runat="server" type="checkbox"/></div><label>Disability</label><br /></td>
       </tr>

              <tr>
        <td><div style="float:left;"><asp:CheckBox ID="artsspaces"   runat="server" type="checkbox"/></div><label>Artspace</label><br /></td>
       </tr>

              <tr>
        <td><div style="float:left;"><asp:CheckBox ID="gpsuper" runat="server" type="checkbox"/></div><label>GP Super Clinic</label><br /></td>
       </tr>

              <tr>
        <td><div style="float:left;"><asp:CheckBox ID="medicare" runat="server" type="checkbox"/></div><label>medicare</label><br /></td>
       </tr>

              <tr>
        <td><div style="float:left;"><asp:CheckBox ID="publicinternet" enabled="false" runat="server" type="checkbox"/></div><label>Public Internet</label><br /></td>
       </tr>

              <tr>
        <td><div style="float:left;"><asp:CheckBox ID="recreation"   runat="server" type="checkbox"/></div><label>recreation</label><br /></td>
       </tr>

                     <tr>
        <td><div style="float:left;"><asp:CheckBox ID="rollerskating" runat="server" type="checkbox"/></div><label>Rollerskating</label><br /></td>
       </tr>
                     <tr>
        <td><div style="float:left;"><asp:CheckBox ID="skateparks"  runat="server" type="checkbox"/></div><label>Skate parks</label><br /></td>
       </tr>
                     <tr>
        <td><div style="float:left;"><asp:CheckBox ID="sportingclubsorgs" enabled="false"  runat="server" type="checkbox"/></div><label>Sport Club</label><br /></td>
       </tr>
                     <tr>
        <td><div style="float:left;"><asp:CheckBox ID="swimmingpools"  runat="server" type="checkbox"/></div><label>Swimming Pools</label><br /></td>
       </tr>

 
   </tbody>
</table>
        
          <asp:Button class="btn btn-default" ID="Button4" runat="server" OnClick="Button3_Click" Text="Search by your favor" />
</div>

     <br /><button type="button" class="btn btn-primary" data-toggle="collapse" 
   data-target="#demo">
 Advance search
</button><br />
          </div>
          </div>
       <asp:Panel ID="Panel1" runat="server">
           <asp:Literal ID="js" runat="server"></asp:Literal>
           <div id="map_canvas" style="background-color:#EEEEEE;height:900px;width:900px;float:left;">
           </div>
       </asp:Panel> 
      
     
</form>
</body> 
</html> 

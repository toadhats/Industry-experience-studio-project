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
                    icon: 'Images/Icon/here.png',
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
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" media="all" />
    <link href="Content/css/style.css" rel="stylesheet" type="text/css" />
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js"></script>
    <script src="http://libs.baidu.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
</head>
<body style="background-color: white">
    <form id="form1" runat="server">
        <br />
        <div id="success" class="alert alert-success" runat="server" style="display: none">
            <a href="#" class="close" data-dismiss="alert">&times;</a>
            <strong>Success！ </strong>The suburb is found!
        </div>
        <div id="fail" class="alert alert-warning" runat="server" style="display: none">
            <a href="#" class="close" data-dismiss="alert">&times;</a>
            <strong>Sorry! </strong>We cannot find your suburb in victoria.
        </div>
        <div id="successLocation" class="alert alert-success" runat="server" style="display: none">
            <a href="#" class="close" data-dismiss="alert">&times;</a>
            <strong>Success！ </strong>You are here!
        </div>
        <div id="failLocation" class="alert alert-warning" runat="server" style="display: none">
            <a href="#" class="close" data-dismiss="alert">&times;</a>
            <strong>fail! </strong>We cannot find your location.
        </div>
        <div id="successservice" class="alert alert-success" runat="server" style="display: none">
            <a href="#" class="close" data-dismiss="alert">&times;</a>
            <strong>Success！ </strong>There are some services in your suburb!
        </div>
        <div id="failservice" class="alert alert-warning" runat="server" style="display: none">
            <a href="#" class="close" data-dismiss="alert">&times;</a>
            <strong>fail! </strong>We cannot find any service in your suburb.
        </div>

        <div id="menu" style="height: 700px; width: 230px; float: left;">

            <div style="text-align: center">
                <h3>Find your suburb</h3>
                <br />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
                <br />
                <asp:Button CssClass="btn btn-default" ID="Button1" runat="server" Text="Search Now" OnClick="Button1_Click" Font-Names="sans-serif" />
                <asp:Button CssClass="btn btn-default" ID="Button2" runat="server" Text="My location" OnClick="Button2_Click" Font-Names="sans-serif" /><br />
                <br />
                <div id="demo" class="collapse">
                    <br />

                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>Service Name</th>

                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="schooltest" Text="School" runat="server" /></div>
                                    <br />
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="centrelink" Text="CenterLink" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="library" Text="Library" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="iceskating" Text="Ice Skating" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="disabilityactivity" Text="Disability" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="artsspaces" Text="Art Space" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="gpsuper" Text="GP Super Clinic" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="medicare" Text="Medicare" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="publicinternet" Text="Public Internet" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="recreation" Text="Recreation" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="rollerskating" Text="Rollerskating" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="skateparks" Text="Skate Parks" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="sportingclubsorgs" Text="Sport Club" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="float: left;">
                                        <asp:CheckBox CssClass="checkbox" ID="swimmingpools" Text="Swimming Pools" runat="server" /></div>
                                    <br />
                                </td>
                            </tr>


                        </tbody>
                    </table>

                    <asp:Button CssClass="btn btn-primary" ID="Button4" runat="server" OnClick="Button3_Click" Text="Search Now" Width="180" Height="50" BackColor="#2699f2" />
                </div>
                <br />
                <div style="text-align: center">
                    <h4>Click to find services</h4>
                </div>
                <button type="button" class="btn btn-default" data-toggle="collapse" data-target="#demo">Filter</button>
                <br />
            </div>
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Literal ID="js" runat="server"></asp:Literal>
            <div id="map_canvas" style="background-color: #EEEEEE; height: 1000px; width: 900px; float: left;">
            </div>

        </asp:Panel>


    </form>
</body>
</html>

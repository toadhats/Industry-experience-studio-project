using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using DataDigester;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace Where2Next
{
    public partial class Mapfunction : System.Web.UI.Page
    {
       


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                js.Text = @"<script type='text/javascript'>
                  var myCenter = new google.maps.LatLng(-37.930, 145.120);function initialize(){var mapProp = {center:myCenter,zoom:8,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + "" + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                success.Attributes["style"] = "display:none";
                fail.Attributes["style"] = "display:none";
                successLocation.Attributes["style"] = "display:none";
                failLocation.Attributes["style"] = "display:none";
                String connectionStr = @"Data Source=au-cdbr-azure-southeast-a.cloudapp.net; Database=Where2Next; User ID=bcb3c5458db67d; password='2821061a'";

                using (MySqlConnection cn = new MySqlConnection(connectionStr))
                {
                    cn.Open();
                    string s;
                    String Locations = "";
                    string Latitude = "";
                    string Longitude = "";
                    string Suburb = "";
                    if (System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text.Trim(), "^\\d+$"))
                    {
                        s = "select * from suburb where postcode = " + TextBox1.Text;
                    }
                    else
                    {
                        s = "select * from suburb where suburb = '" + TextBox1.Text + "'";
                    }
                    MySqlCommand mcd = new MySqlCommand(s, cn);
                    MySqlDataReader mdr = mcd.ExecuteReader();
                    if (mdr.HasRows)
                    {
                        while (mdr.Read())
                        {
                            success.Attributes["style"] = "display";
                            Latitude = mdr.GetString(4);
                            Longitude = mdr.GetString(5);
                            Suburb = mdr.GetString(2);
                            Locations += Environment.NewLine + " var suburb = new google.maps.LatLng(" + Latitude + ", " + Longitude + ");var marker = new google.maps.Marker({position: suburb,animation: google.maps.Animation.BOUNCE});marker.setMap(map);var infowindow = new google.maps.InfoWindow({content:' Welcome to " + Suburb + "'});infowindow.open(map,marker);google.maps.event.addListener(marker, 'click', function () {map.setZoom(16);map.setCenter(marker.getPosition());infowindow.open(map, marker);});";
                            js.Text = "<script type='text/javascript'>" +
                 "var myCenter = new google.maps.LatLng(" + Latitude + "," + Longitude + "); function initialize(){var mapProp = {center:myCenter,zoom:13,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + Locations + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";

                        }
                        mdr.Close();
                        cn.Close();
                    }
                    else
                    {
                        fail.Attributes["style"] = "display";
                        js.Text = @"<script type='text/javascript'>
                  var myCenter = new google.maps.LatLng(-37.930, 145.120);function initialize(){var mapProp = {center:myCenter,zoom:9,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + "" + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Location", " <script>currentPosition(); </script> ");
            }
        }
    }
}
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
         </script> ";//open the google map when click on the map botton
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                failconnection.Attributes["style"] = "display:none";
                success.Attributes["style"] = "display:none";
                fail.Attributes["style"] = "display:none";
                successLocation.Attributes["style"] = "display:none";
                failLocation.Attributes["style"] = "display:none";
                successservice.Attributes["style"] = "display:none";
                failservice.Attributes["style"] = "display:none";   //display all of the label for the map
                String connectionStr = @"Data Source=bitnami-mysql-3526.cloudapp.net; Database=Where2Next; User ID=where2next; password='nakdYzWd'";

                using (MySqlConnection connection = new MySqlConnection(connectionStr))//connection to database
                {
                    string query;
                    String Locations = "";
                    string Latitude = "";
                    string Longitude = "";
                    string Suburb = "";
                    string marker = "";
                    if (System.Text.RegularExpressions.Regex.IsMatch(SuburbBox.Text.Trim(), "^\\d+$"))   //To check if the check the textbox is number
                    {
                        query = "select suburb,Latitude,Longitude,replace(CONCAT(suburb,postcode),' ','') as marker from suburb_gnaf where postcode = " + SuburbBox.Text;
                    }
                    else
                    {
                        query = "select suburb,Latitude,Longitude,replace(CONCAT(suburb,postcode),' ','') as marker from suburb_gnaf where suburb = '" + SuburbBox.Text + "'";
                    }
                    try
                    {
                        connection.Open();//open the database
                        MySqlCommand command = new MySqlCommand(query, connection);//make a query
                        MySqlDataReader reader = command.ExecuteReader();  //create a reader

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                success.Attributes["style"] = "display";
                                Latitude = reader.GetString(1);   //Laititude
                                Longitude = reader.GetString(2);//Longitude
                                Suburb = reader.GetString(0); //Suburb name
                                marker = reader.GetString(3);
                                Locations += Environment.NewLine + " var suburb = new google.maps.LatLng(" + Latitude + ", " + Longitude + ");var " + marker + " = new google.maps.Marker({position: suburb,icon: 'Images/ICon/pins.png'});" + marker + ".setMap(map);var infowindow = new google.maps.InfoWindow({content:'Welcome to " + Suburb + "'});infowindow.open(map," + marker + "); google.maps.event.addListener(" + marker + ", 'click', function () {map.setZoom(16);map.setCenter(" + marker + ".getPosition());});";
                                js.Text = "<script type='text/javascript'>" +
                     "var myCenter = new google.maps.LatLng(" + Latitude + "," + Longitude + "); function initialize(){var mapProp = {center:myCenter,zoom:13,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + Locations + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";

                            }
                        }
                        else
                        {
                            fail.Attributes["style"] = "display";
                            js.Text = @"<script type='text/javascript'>
                  var myCenter = new google.maps.LatLng(-37.930, 145.120);function initialize(){var mapProp = {center:myCenter,zoom:9,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + "" + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
                        }
                        reader.Close();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        if (connection != null)
                        {
                            connection.Close();
                        }
                        failconnection.Attributes["style"] = "display";
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                failconnection.Attributes["style"] = "display:none";
                success.Attributes["style"] = "display:none";
                fail.Attributes["style"] = "display:none";
                successLocation.Attributes["style"] = "display:none";
                failLocation.Attributes["style"] = "display:none";
                successservice.Attributes["style"] = "display:none";
                failservice.Attributes["style"] = "display:none";//hide all of the alert
                string query = "";
                String connectionStr = @"Data Source=bitnami-mysql-3526.cloudapp.net; Database=Where2Next; User ID=where2next; password='nakdYzWd'";
                if (SuburbBox.Text == "")
                {
                    fail.Attributes["style"] = "display";
                    js.Text = @"<script type='text/javascript'>
                  var myCenter = new google.maps.LatLng(-37.930, 145.120);function initialize(){var mapProp = {center:myCenter,zoom:9,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + "" + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
                }
                else
                {
                    foreach (Control c in form1.Controls)               //this method is a loop that to collect all of the Controls.
                    {
                        if (c.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox")) //check whether the controls are the check box
                        {
                            CheckBox box = c as CheckBox;  //if the controls is checkbox, then collect it 

                            if (box.Checked)
                            {
                                if (System.Text.RegularExpressions.Regex.IsMatch(SuburbBox.Text.Trim(), "^\\d+$"))//to check whether textbox is number.
                                {
                                    query = query + "select NAME,LATITUDE,LONGITUDE,address,icon,replace(CONCAT(suburb,id),' ','') as marker from " + box.ID + " where postcode='" + SuburbBox.Text + "' and LATITUDE !=0 and LATITUDE is not null union ";

                                }
                                else if (System.Text.RegularExpressions.Regex.IsMatch(SuburbBox.Text.Trim(), "^\\w+$"))//to check whether textbox is not number.
                                {
                                    query = query + "select NAME,LATITUDE,LONGITUDE,address,icon,replace(CONCAT(suburb,id),' ','') as marker from " + box.ID + " where suburb='" + SuburbBox.Text + "' and LATITUDE !=0 and LATITUDE is not null union ";
                                }
                                else
                                {
                                    query = query + "select NAME,LATITUDE,LONGITUDE,address,icon,replace(CONCAT(suburb,id),' ','') as marker from " + box.ID + " and LATITUDE !=0 and LATITUDE is not null union ";
                                }

                            }
                        }
                    }
                    query = query.Remove(query.Length - 7, 7);//Because when use above query, it will automic generate the 'union at last', therefore we need to use the method to delete the 'union'
                                                              //Response.Write(query);//just for test.
                    using (MySqlConnection connection = new MySqlConnection(connectionStr))
                    {

                            string Latitude = "";
                            string Longitude = "";
                            string NAME = "";
                            string Locations = "";
                            string icon = "";
                            string marker = "";
                        try
                        {
                            connection.Open();
                            MySqlCommand command = new MySqlCommand(query, connection);//make a connection
                            MySqlDataReader reader = command.ExecuteReader();//create a reader
                            if (reader.HasRows)
                            {


                                while (reader.Read())
                                {
                                    successservice.Attributes["style"] = "display";   
                                    Latitude = reader.GetString(1);
                                    Longitude = reader.GetString(2);
                                    NAME = reader.GetString(0);
                                    icon = reader.GetString(4);
                                    marker = reader.GetString(5);
                                    Locations += Environment.NewLine + " var suburb = new google.maps.LatLng(" + Latitude + ", " + Longitude + ");var " + marker + " = new google.maps.Marker({position: suburb,icon: '" + icon + "'});" + marker + ".setMap(map);var infowindow = new google.maps.InfoWindow({content:'" + NAME + "'});infowindow.open(map," + marker + "); google.maps.event.addListener(" + marker + ", 'click', function () {map.setZoom(18);map.setCenter(" + marker + ".getPosition());});";


                                }
                                js.Text = "<script type='text/javascript'>" +
"var myCenter = new google.maps.LatLng(" + Latitude + "," + Longitude + "); function initialize(){var mapProp = {center:myCenter,zoom:14,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + Locations + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";


                            }
                            else
                            {
                                failservice.Attributes["style"] = "display";
                                js.Text = @"<script type='text/javascript'>
                  var myCenter = new google.maps.LatLng(-37.930, 145.120);function initialize(){var mapProp = {center:myCenter,zoom:9,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + "" + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
                            }
                            reader.Close();
                            connection.Close();
                        }

                        catch (Exception ex)
                        {
                            if (connection != null)   //if conncection is error,then check wheather the connection is closed 
                            {
                                connection.Close();
                            }
                            failconnection.Attributes["style"] = "display";
                            js.Text = @"<script type='text/javascript'>
                  var myCenter = new google.maps.LatLng(-37.930, 145.120);function initialize(){var mapProp = {center:myCenter,zoom:9,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + "" + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";

                        }
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            List<Tuple<string, double, double, string>> suburbList;
            if (IsPostBack)
            {
                failconnection.Attributes["style"] = "display:none";
                success.Attributes["style"] = "display:none";
                fail.Attributes["style"] = "display:none";
                successLocation.Attributes["style"] = "display:none";
                failLocation.Attributes["style"] = "display:none";
                successservice.Attributes["style"] = "display:none";
                failservice.Attributes["style"] = "display:none";   //display all of the label for the map


                using (DBConnect db = new DBConnect())
                {

                    String Locations = "";
                    double Latitude;
                    double Longitude;
                    string Suburb = SuburbBox.Text;
                    string marker = "";
                    suburbList = db.getSuburbLocation(Suburb);
                    if (suburbList.Count > 0)
                    {
                        success.Attributes["style"] = "display";
                        foreach (Tuple<string, double, double, string> suburb in suburbList)
                        {
                            Suburb = suburb.Item1;
                            Latitude = suburb.Item2;   //Laititude
                            Longitude = suburb.Item3;//Longitude
                            marker = suburb.Item4;
                            Locations += Environment.NewLine + " var suburb = new google.maps.LatLng(" + Latitude + ", " + Longitude + ");var " + marker + " = new google.maps.Marker({position: suburb,icon: 'Images/ICon/pins.png'});" + marker + ".setMap(map);var infowindow = new google.maps.InfoWindow({content:'Welcome to " + Suburb + "'});infowindow.open(map," + marker + "); google.maps.event.addListener(" + marker + ", 'click', function () {map.setZoom(16);map.setCenter(" + marker + ".getPosition());});";
                            js.Text = "<script type='text/javascript'>" +
                 "var myCenter = new google.maps.LatLng(" + Latitude + "," + Longitude + "); function initialize(){var mapProp = {center:myCenter,zoom:13,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + Locations + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
                        }
                    }
                    else
                    {
                        failLocation.Attributes["style"] = "display";
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
                String connectionStr = "Server=tcp:where2next.database.windows.net,1433;Database=Where2NextMS;User ID=where2next@where2next;Password='d8wV>?skM59j';Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
                                    query = query + "select NAME,LATITUDE,LONGITUDE,address,icon,replace(CONCAT(suburb,id),' ','') as marker from where2next." + box.ID + " where postcode='" + SuburbBox.Text + "' and LATITUDE !=0 and LATITUDE is not null union ";
                                }
                                else if (System.Text.RegularExpressions.Regex.IsMatch(SuburbBox.Text.Trim(), "^\\w+$"))//to check whether textbox is not number.
                                {
                                    query = query + "select NAME,LATITUDE,LONGITUDE,address,icon,replace(CONCAT(suburb,id),' ','') as marker from where2next." + box.ID + " where suburb='" + SuburbBox.Text + "' and LATITUDE !=0 and LATITUDE is not null union ";
                                }
                                else
                                {
                                    query = query + "select NAME,LATITUDE,LONGITUDE,address,icon,replace(CONCAT(suburb,id),' ','') as marker from where2next." + box.ID + " and LATITUDE !=0 and LATITUDE is not null union ";
                                }
                            }
                        }
                    }
                    query = query.Remove(query.Length - 7, 7);//Because when use above query, it will automic generate the 'union at last', therefore we need to use the method to delete the 'union'
                                                              //Response.Write(query);//just for test.
                    using (SqlConnection connection = new SqlConnection(connectionStr))
                    {
                        double Latitude ;
                        double Longitude ;
                        string NAME = "";
                        string Locations = "";
                        string icon = "";
                        string marker = "";
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(query, connection);//make a connection
                            SqlDataReader reader = command.ExecuteReader();//create a reader
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    successservice.Attributes["style"] = "display";
                                    Latitude = reader.GetDouble(1);
                                    Longitude = reader.GetDouble(2);
                                    NAME = reader.GetString(0);
                                    icon = reader.GetString(4);
                                    marker = reader.GetString(5);
                                    Locations += Environment.NewLine + " var suburb = new google.maps.LatLng(" + Latitude + ", " + Longitude + ");var " + marker + " = new google.maps.Marker({position: suburb,icon: '" + icon + "'});" + marker + ".setMap(map);var infowindow = new google.maps.InfoWindow({content:'" + NAME + "'});infowindow.open(map," + marker + "); google.maps.event.addListener(" + marker + ", 'click', function () {map.setZoom(18);map.setCenter(" + marker + ".getPosition());});";
                                    js.Text = "<script type='text/javascript'>" +
"var myCenter = new google.maps.LatLng(" + Latitude + "," + Longitude + "); function initialize(){var mapProp = {center:myCenter,zoom:14,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + Locations + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
                                }


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

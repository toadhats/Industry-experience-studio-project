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
                success.Attributes["style"] = "display:none";
                fail.Attributes["style"] = "display:none";
                successLocation.Attributes["style"] = "display:none";
                failLocation.Attributes["style"] = "display:none";
                successservice.Attributes["style"] = "display:none";
                failservice.Attributes["style"] = "display:none";   //display all of the label for the map
                String connectionStr = @"Data Source=bitnami-mysql-3526.cloudapp.net; Database=Where2Next; User ID=where2next; password='nakdYzWd'";

                using (MySqlConnection cn = new MySqlConnection(connectionStr))//connection to database
                {
                    cn.Open();//op the database
                    string s;
                    String Locations = "";
                    string Latitude = "";
                    string Longitude = "";
                    string Suburb = "";
                    string marker = "";
                    if (System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text.Trim(), "^\\d+$"))   //To check if the check the textbox is number
                    {
                        s = "select suburb,Latitude,Longitude,replace(CONCAT(suburb,postcode),' ','') as marker from suburb_gnaf where postcode = " + TextBox1.Text;
                    }
                    else
                    {
                        s = "select suburb,Latitude,Longitude,replace(CONCAT(suburb,postcode),' ','') as marker from suburb_gnaf where suburb = '" + TextBox1.Text + "'";
                    }
                    try {
                        MySqlCommand mcd = new MySqlCommand(s, cn);
                        MySqlDataReader mdr = mcd.ExecuteReader();  //create a reader

                        if (mdr.HasRows)
                        {
                            while (mdr.Read())
                            {
                                success.Attributes["style"] = "display";
                                Latitude = mdr.GetString(1);   //Laititude
                                Longitude = mdr.GetString(2);//Longitude
                                Suburb = mdr.GetString(0); //Suburb name
                                marker = mdr.GetString(3);
                                Locations += Environment.NewLine + " var suburb = new google.maps.LatLng(" + Latitude + ", " + Longitude + ");var " + marker + " = new google.maps.Marker({position: suburb,icon: 'Images/ICon/pins.png'});" + marker + ".setMap(map);var infowindow = new google.maps.InfoWindow({content:'Welcome to " + Suburb + "'});infowindow.open(map," + marker + "); google.maps.event.addListener(" + marker + ", 'click', function () {map.setZoom(16);map.setCenter(" + marker + ".getPosition());});";
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

                    catch (Exception ex)
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                success.Attributes["style"] = "display:none";
                fail.Attributes["style"] = "display:none";
                successLocation.Attributes["style"] = "display:none";
                failLocation.Attributes["style"] = "display:none";
                successservice.Attributes["style"] = "display:none";
                failservice.Attributes["style"] = "display:none";
                string query = "";
                String connectionStr = @"Data Source=bitnami-mysql-3526.cloudapp.net; Database=Where2Next; User ID=where2next; password='nakdYzWd'";
                if (TextBox1.Text == "")
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
                            CheckBox box = c as CheckBox;  //if the controls is the test box, then collect it 

                            if (box.Checked)
                            {
                                if (System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text.Trim(), "^\\d+$"))//to check whether textbox is number.
                                {
                                    query = query + "select NAME,LATITUDE,LONGITUDE,address,icon,replace(CONCAT(suburb,id),' ','') as marker from " + box.ID + " where postcode='" + TextBox1.Text + "' and LATITUDE !=0 and LATITUDE is not null union ";

                                }
                                else if (System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text.Trim(), "^\\w+$"))//to check whether textbox is not number.
                                {
                                    query = query + "select NAME,LATITUDE,LONGITUDE,address,icon,replace(CONCAT(suburb,id),' ','') as marker from " + box.ID + " where suburb='" + TextBox1.Text + "' and LATITUDE !=0 and LATITUDE is not null union ";
                                }
                                else
                                {
                                    query = query + "select NAME,LATITUDE,LONGITUDE,address,icon,replace(CONCAT(suburb,id),' ','') as marker from " + box.ID + " and LATITUDE !=0 and LATITUDE is not null union ";
                                }

                            }
                        }
                    }
                    try
                    {
                        query = query.Remove(query.Length - 7, 7);//Because when use above query, it will automic generate the 'union at last', therefore we need to use the method to delete the 'union'
                        //Response.Write(query);//just for test.
                        using (MySqlConnection cn = new MySqlConnection(connectionStr))
                        {
                            string Latitude = "";
                            string Longitude = "";
                            string NAME = "";
                            string Locations = "";
                            string icon = "";
                            string marker = "";

                            cn.Open();
                            MySqlCommand mcd = new MySqlCommand(query, cn);
                            MySqlDataReader mdr = mcd.ExecuteReader();
                            if (mdr.HasRows)
                            {


                                while (mdr.Read())
                                {
                                    successservice.Attributes["style"] = "display";
                                    Latitude = mdr.GetString(1);
                                    Longitude = mdr.GetString(2);
                                    NAME = mdr.GetString(0);
                                    icon = mdr.GetString(4);
                                    marker = mdr.GetString(5);
                                    Locations += Environment.NewLine + " var suburb = new google.maps.LatLng(" + Latitude + ", " + Longitude + ");var " + marker + " = new google.maps.Marker({position: suburb,icon: '" + icon + "'});" + marker + ".setMap(map);var infowindow = new google.maps.InfoWindow({content:'" + NAME + "'});infowindow.open(map," + marker + "); google.maps.event.addListener(" + marker + ", 'click', function () {map.setZoom(18);map.setCenter(" + marker + ".getPosition());});";
                                   

                                }
                                js.Text = "<script type='text/javascript'>" +
"var myCenter = new google.maps.LatLng(" + Latitude + "," + Longitude + "); function initialize(){var mapProp = {center:myCenter,zoom:14,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + Locations + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
                                mdr.Close();
                                cn.Close();

                            }
                            else
                            {
                                failservice.Attributes["style"] = "display";
                                js.Text = @"<script type='text/javascript'>
                  var myCenter = new google.maps.LatLng(-37.930, 145.120);function initialize(){var mapProp = {center:myCenter,zoom:9,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + "" + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
                            }
                        }
                    }
                    catch (Exception ERROR)
                    {

                        failservice.Attributes["style"] = "display";
                        js.Text = @"<script type='text/javascript'>
                  var myCenter = new google.maps.LatLng(-37.930, 145.120);function initialize(){var mapProp = {center:myCenter,zoom:9,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + "" + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";

                    }
                }
            }
        }
    }
}
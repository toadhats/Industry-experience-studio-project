using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    private string conStr = WebConfigurationManager.ConnectionStrings["suburbConnectionString1"].ConnectionString;
    String Locations = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("select * from SuburbMaster", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                adp.Fill(ds, "Suburb");
                foreach (DataRow r in ds.Tables["Suburb"].Rows)
                {
                    if (r["LocLa"].ToString().Trim().Length == 0)
                        continue;

                    string Latitude = r["LocLa"].ToString();
                    string Longitude = r["LocLong"].ToString();
                    string Suburb = r["Suburb"].ToString();
                    string newMarker = Suburb + "Marker";
                    // create a line of JavaScript for marker on map for this record 
                    Locations += Environment.NewLine + " var suburb = new google.maps.LatLng(" + Latitude + ", " + Longitude + ");var marker = new google.maps.Marker({position: suburb,animation: google.maps.Animation.BOUNCE});marker.setMap(map);var infowindow = new google.maps.InfoWindow({content:'"+ Suburb + "'});infowindow.open(map,marker);";
            }
                js.Text = @"<script type='text/javascript'>
                  var myCenter = new google.maps.LatLng(-37.930, 145.120);function initialize(){var mapProp = {center:myCenter,zoom:13,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + Locations + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
            }
            catch (Exception er)
            {
                Response.Write("<script>alert('error')</script>");
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("select * from SuburbMaster where Suburb='" + TextBox1.Text+"'" , con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                adp.Fill(ds, "Suburb");
                foreach (DataRow r in ds.Tables["Suburb"].Rows)
                {
                    if (r["LocLa"].ToString().Trim().Length == 0)
                        continue;

                    string Latitude = r["LocLa"].ToString();
                    string Longitude = r["LocLong"].ToString();
                    string Suburb = r["Suburb"].ToString();
                    string newMarker = Suburb + "Marker";
                    // create a line of JavaScript for marker on map for this record 
                    Locations += Environment.NewLine + "function clearMarkers() {setMapOnAll(null);} var suburb = new google.maps.LatLng(" + Latitude + ", " + Longitude + ");var marker = new google.maps.Marker({position: suburb,animation: google.maps.Animation.BOUNCE});marker.setMap(map);var infowindow = new google.maps.InfoWindow({content:'" + Suburb + "'});infowindow.open(map,marker);";
                    Label2.Text = Locations;
                }
                js.Text = @"<script type='text/javascript'>
                  var myCenter = new google.maps.LatLng(-37.930, 145.120);function initialize(){var mapProp = {center:myCenter,zoom:13,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + Locations + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
            }
            catch (Exception er)
            {
                Response.Write("<script>alert('error')</script>");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
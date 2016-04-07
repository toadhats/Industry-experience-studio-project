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

public partial class test : System.Web.UI.Page
{

  public List<DataDigester.Service> getData()
  {
    var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]); // get account
    var tableClient = storageAccount.CreateCloudTableClient(); // get client referring to account
    var table = tableClient.GetTableReference("Services"); // get table out of account
    var query = new Microsoft.WindowsAzure.Storage.Table.TableQuery<DataDigester.Service>().Where(Microsoft.WindowsAzure.Storage.Table.TableQuery.GenerateFilterCondition("PartitionKey", Microsoft.WindowsAzure.Storage.Table.QueryComparisons.Equal, "centrelink")); // query to get all centrelink data. It cannot work this way in the next version but I will submit for now, since it sort of works.
    var data = table.ExecuteQuery(query).ToList<DataDigester.Service>(); // execute the query and store the result in a variable
    return data;
  }

  String Locations = "";
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!this.IsPostBack)
    {

      var data = getData();
      try
      {
        //con.Open();
        //adp.Fill(ds, "Suburb");
        foreach (Service service in data)
        {
          if (service.latitude.ToString().Trim().Length == 0)
          continue;

          string Latitude = service.latitude.ToString();
          string Longitude = service.longitude.ToString();
          string Suburb = service.suburb.ToString();
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
        //con.Close();
      }
    }
  }

  protected void Button1_Click(object sender, EventArgs e)
  {
    if (this.IsPostBack)
    {
      var data = getData();
      try
      {
        //con.Open();
        //adp.Fill(ds, "Suburb");
        foreach (Service service in data)
        {
                if (service.latitude.ToString().Trim().Length == 0)
                        continue;

          string Latitude = service.latitude.ToString();
          string Longitude = service.longitude.ToString();
          string Suburb = service.suburb.ToString();
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

      }
    }
  }
}

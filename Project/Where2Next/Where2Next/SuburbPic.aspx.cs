using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Where2Next
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connetionString = "";
            SqlConnection connection;
            connetionString = "Server=tcp:where2next.database.windows.net,1433;Database=Where2NextMS;User ID=where2next@where2next;Password='d8wV>?skM59j';Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                Response.Write("suceed");
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("fail to connect");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string PageUrl = "";
            string Suburb = txtUrl.Text.ToLower();

            string[] sArray = Regex.Split(Suburb, " ", RegexOptions.IgnoreCase);
            if (sArray.Length != 1)
            {
                sArray[0] = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(sArray[0]);
                sArray[1] = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(sArray[1]);
                PageUrl = "https://en.wikipedia.org/wiki/" + sArray[0] + "_" + sArray[1] + ",_Victoria";
            }
            else
            {
                sArray[0] = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(sArray[0]);
                PageUrl = "https://en.wikipedia.org/wiki/" + sArray[0] + ",_Victoria";
            }
            try
            {
                WebClient wc = new WebClient();
                wc.Credentials = CredentialCache.DefaultCredentials;
                Encoding enc = Encoding.GetEncoding("GB2312");
                Byte[] pageData = wc.DownloadData(PageUrl);

                const string pattern = "<img [^~]*?>";
                const string pattern1 = "srcs*=\\s*((\"|\')?)(?<url>\\S+)(\"|\')?[^>]*";
                Match match = Regex.Match(enc.GetString(pageData), pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    string img = match.Value;
                    string imgsrc = Regex.Match(img, pattern1, RegexOptions.IgnoreCase).Result("${url}");
                    imgsrc = Regex.Replace(imgsrc, "\"|\'|\\>", "", RegexOptions.IgnoreCase);
                    imgsrc = "http:" + imgsrc;
                    if (Path.GetExtension(imgsrc).ToLower().Equals(".jpg"))
                    {
                        js.Text = "<img src = '" + imgsrc + "'/>";
                    }
                    else
                    {
                        js.Text = "cannot found a suburb picture in wikipedia,we can use picture to instead of that";
                    }
                }
            }
            catch (Exception ex)
            {
                js.Text = "Cannot found the suburb in victoria";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String connectionStr = @"Data Source=bitnami-mysql-3526.cloudapp.net; Database=Where2Next; User ID=where2next; password='nakdYzWd'";
            using (SqlConnection cn = new SqlConnection(connectionStr))
            {
                try
                {
                    cn.Open();
                    Response.Write("can link to mysql");
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("cannot link to mysql");
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String connectionStr = @"Data Source=au-cdbr-azure-southeast-a.cloudapp.net; Database=Where2Next; User ID=bcb3c5458db67d; password='2821061a'";
            using (SqlConnection cn = new SqlConnection(connectionStr))
            {
                try
                {
                    cn.Open();
                    Response.Write("can link to mysql");
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("cannot link to mysql");
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            String Locations = "";
            double Latitude;
            double Longitude;
            string Suburb = "";
            string marker = "";
            string query = "";
            if (System.Text.RegularExpressions.Regex.IsMatch(txtUrl.Text.Trim(), "^\\d+$"))   //To check if the check the textbox is number
            {
                query = "select suburb,Latitude,Longitude,replace(CONCAT(suburb,postcode),' ','') as marker from where2next.suburb_gnaf where postcode = " + txtUrl.Text;
            }
            else
            {
                query = "select suburb,Latitude,Longitude,replace(CONCAT(suburb,postcode),' ','') as marker from where2next.suburb_gnaf where suburb = '" + txtUrl.Text + "'";
            }
            SqlConnection connection;
            connetionString = "Server=tcp:where2next.database.windows.net,1433;Database=Where2NextMS;User ID=where2next@where2next;Password='d8wV>?skM59j';Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Latitude = reader.GetDouble(1);
                        Longitude = reader.GetDouble(2);
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
                    js.Text = @"<script type='text/javascript'>
                  var myCenter = new google.maps.LatLng(-37.930, 145.120);function initialize(){var mapProp = {center:myCenter,zoom:9,mapTypeId:google.maps.MapTypeId.ROADMAP};var map=new google.maps.Map(document.getElementById('map_canvas'),mapProp);" + "" + @" }google.maps.event.addDomListener(window, 'load', initialize);
         </script> ";
                    Response.Write("Can not found the suburb in victoria ");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Can not open connection! ");
            }
        }
    }
}

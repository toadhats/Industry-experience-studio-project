using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using MySql.Data.MySqlClient;



namespace Where2Next
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
   

        protected void Button1_Click(object sender, EventArgs e)
        {

            string PageUrl ="";
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
            try {
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
                        js.Text ="cannot found a suburb picture in wikipedia,we can use picture to instead of that";

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
            using (MySqlConnection cn = new MySqlConnection(connectionStr))
            {
                cn.Open();
                Response.Write("can link to mysql");
                cn.Close();
            }


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String connectionStr = @"Data Source=au-cdbr-azure-southeast-a.cloudapp.net; Database=Where2Next; User ID=bcb3c5458db67d; password='2821061a'";
            using (MySqlConnection cn = new MySqlConnection(connectionStr))
            {
                cn.Open();
                Response.Write("can link to mysql");
                cn.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String connectionStr = @"Data Source=13.73.117.189; Database=Where2Next; User ID=where2next; password='nakdYzWd'";
            using (MySqlConnection cn = new MySqlConnection(connectionStr))
            {
                cn.Open();
                Response.Write("can link to mysql");
                cn.Close();
            }
        }
    }
    }

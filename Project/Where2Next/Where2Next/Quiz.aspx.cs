using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Where2Next
{
    public partial class quizTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                String connectionStr = @"Data Source=au-cdbr-azure-southeast-a.cloudapp.net; Database=Where2Next; User ID=bcb3c5458db67d; password='2821061a'";
                string s = "";
                string suburb = "";
                string postcode = "";
                string total = "";
                using (MySqlConnection cn = new MySqlConnection(connectionStr))
                {
                    cn.Open();
                    if (centrelinkList.Items[0].Selected == true)
                    {
                        s = "select suburb,postcode from socialservices WHERE type = 'centrelink'";
                    }
                    else
                    {
                        s = "select suburb,postcode from socialservices WHERE type = 'Medicare'";
                    }
                    MySqlCommand mcd = new MySqlCommand(s, cn);
                    MySqlDataReader mdr = mcd.ExecuteReader();
                    if (mdr.HasRows)
                    {
                        while (mdr.Read())
                        {
                            suburb = mdr.GetString(0);
                            postcode = mdr.GetString(1);
                            total += Environment.NewLine + "<tr><td>" + suburb + "</t><td>" + postcode + "</td></tr>";
                        }
                        this.question.Style.Add("display", "none");
                        result.Text = "<table class='table table-hover'><caption><h2>Wow, there are lots of suburb are suitable for you</h2></caption><thead><tr><th>Suburb Name</th><th>Postcode</th></tr></thead><tbody>" + total + "<thead></tbody></table>";
                    }
                    else
                    {

                    }
                    mdr.Close();
                    cn.Close();

                }
            }
        }
    }
}
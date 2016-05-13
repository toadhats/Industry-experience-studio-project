using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Where2Next
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connetionString = "";
            SqlConnection connection;
            Random rand = new Random();
            int num = rand.Next(0, 1000 + 1);
            connetionString = "Server=tcp:where2next.database.windows.net,1433;Database=Where2NextMS;User ID=where2next@where2next;Password='d8wV>?skM59j';Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("update guest.CONNECTION set number = number +1 where type ='SUCCESS'; ", connection);
                command.ExecuteNonQuery();
                Response.Write("suceed " + num);
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("fail to connect");
                String connectionfail = @"Data Source=au-cdbr-azure-southeast-a.cloudapp.net; Database=Where2Next; User ID=bcb3c5458db67d; password='2821061a'";
                using (SqlConnection cn = new SqlConnection(connectionfail))
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand("update CONNECTION set number = number +1 where type ='fail';", cn);
                    command.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }
    }
}

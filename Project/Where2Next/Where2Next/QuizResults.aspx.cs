using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Web;

namespace Where2Next
{
    public partial class QuizResults : System.Web.UI.Page
    {
        private string connectionString = @"Data Source=bitnami-mysql-3526.cloudapp.net; Database=where2next; User ID=where2next; password='nakdYzWd'";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["query"] == null)
            {
                // We probably got here from somewhere other than a completed quiz page, e.g a
                // user/crawler tried entering a URL manually
                Trace.Write("Reached quiz result page without a valid query parameter");
            }
            else
            {
                // Console.WriteLine("Arrived at page with encoded query {0}", Request["query"]);
                var query = Base64ForUrlDecode(Request["query"]);
                Trace.Write("Attempting connection to SQL db");

                try
                {
                    MySqlDataReader dataReader = sendQuery(query);

                    if (dataReader.HasRows)
                    {
                        StringBuilder resultsTableBuilder = new StringBuilder();
                        resultsTableBuilder.Append("<div class=\"table\">" // Start of whole container
                                                 + "<div class=\"tableHeading\"><h2> The following suburbs meet your requirements: </h2></div>" // Heading cell
                                                 + "<div class=\"cardContainer\">"); // Inner container to fill with result cards

                        while (dataReader.Read())
                        {
                            string suburb = dataReader.GetString(0); // These are basically magic numbers ew
                            string postcode = dataReader.GetString(1); // I don't like how I need to look in another file to see what I'm doing here
                            string img = dataReader.GetString(2);
                            string imgCode = "";
                            if (img.Length > 0)
                            {
                                imgCode += String.Format("<img src={0} alt={1}>", img, suburb);
                            }
                            resultsTableBuilder.AppendFormat("<div class=\"resultCard\"> <h3>{0}</h3> <p>{1}</p> <hr> {2} </div> ", suburb, postcode, imgCode);
                        }
                        resultsTableBuilder.Append("</div> </div>"); // close our containers
                        resultsTable.Text = resultsTableBuilder.ToString();
                    }
                    else
                    {
                        resultsTable.Text = "<div class=\"sorryCard\" > <h2> We're still looking for your ideal suburb </h2> <a href=\"/quiz.aspx\"> <strong> Search again? </strong> </a> </div>";
                    }
                    dataReader.Close();
                }
                catch (MySqlException)
                {
                    resultsTable.Text = "<div class=\"sorryCard\" > <h2> Whoops, something went wrong. </h2> <a href=\"/quiz.aspx\"> <strong> Search again? </strong> </a> </div>";
                }
            }
        }

        public MySqlDataReader sendQuery(string query)
        {
            MySqlConnection connection = new MySqlConnection();

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection); // This should close the connection for us when the reader is closed

                return dataReader;
            }
            catch (Exception e)
            {
                Trace.Warn(e.Message);
                Trace.Warn(e.Source);
                Trace.Warn(e.StackTrace);
                Trace.Warn(e.HelpLink);
                throw e;
            }
        }

        // Decodes the query that was encoded in URL-safe base64 before passing in
        public static string Base64ForUrlDecode(string encodedQuery)
        {
            byte[] buffer = HttpServerUtility.UrlTokenDecode(encodedQuery);
            return Encoding.UTF8.GetString(buffer);
        }
    }
}

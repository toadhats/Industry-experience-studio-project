using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                // We probably got here from somewhere other than a completed quiz page, e.g the user typed the url themselves
                System.Diagnostics.Debug.WriteLine("Reached quiz result page without a valid query parameter");
            }
            else
            {
                Console.WriteLine("Arrived at page with encoded query {0}", Request["query"]);
                var query = Base64ForUrlDecode(Request["query"]);
                Console.WriteLine("Decoded query: {0}", query);
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    string resultsTableHTML = "";
                    if (dataReader.HasRows)
                    {
                        resultsTableHTML += "<div class=\"table\">" // Start of whole container
                            + "<div class=\"tableHeading\"><h2> The following suburbs meet your requirements: </h2></div>" // Heading cell
                            + "<div class=\"cardContainer\">"; // Inner container to fill with result cards

                        while (dataReader.Read())
                        {
                            string suburb = dataReader.GetString(0); // These are basically magic numbers ew
                            string postcode = dataReader.GetString(1); // I don't like how I need to look in another file to see what I'm doing here
                            List<string> serviceNames = new List<string>();
                            System.Diagnostics.Debug.WriteLine("Services in {0}:", suburb);
                            for (int i = 2; i < dataReader.FieldCount - 1; i++) // Need to stop before the state column that I inserted as a bad hack
                            {
                                var col = dataReader.GetString(i);
                                System.Diagnostics.Debug.WriteLine(col);
                                serviceNames.Add(col);
                            }

                            resultsTableHTML += String.Format("<div class=\"resultCard\"> <h3>{0}</h3> \n{1} <ul> <hr>", suburb, postcode);
                            foreach (string serviceName in serviceNames)
                            {
                                resultsTableHTML += String.Format("<li class=\"requestedService\">{0}</li> ", serviceName);
                            }
                            resultsTableHTML += "</ul></div>"; // end of result card
                        }
                        resultsTableHTML += "</div>" // Card container ends
                            + "</div>"; // Whole container ends
                        resultsTable.Text = resultsTableHTML;
                        dataReader.Close();
                        connection.Close();
                    }
                }
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
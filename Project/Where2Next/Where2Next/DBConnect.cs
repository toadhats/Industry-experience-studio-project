using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace Where2Next
{
    public class DBConnect : IDisposable
    {
        private SqlConnection connection;

        private string server;

        private string database;
        private string uid;
        private string password;

        // Constructor
        public DBConnect()
        {
            Initialise();
        }

        // I kind of like this pattern of having a seperate Initialise() method
        private void Initialise()
        {
            server = ""; // maybe go back to using this approach
            database = ""; // or maybe don't
            uid = "";
            password = "";
            string connectionString;
            connectionString = "Server=tcp:where2next.database.windows.net,1433;Database=Where2NextMS;User ID=where2next@where2next;Password='d8wV>?skM59j';Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            connection = new SqlConnection(connectionString);
        }

        // Opens the connection to the database while handling any resulting exceptions and helping
        // us ensure we're connected before trying anything
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                // Exception handling based on error codes, mainly to help with debugging:
                // 0: Cannot connect to server.
                // 1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.Error.WriteLine("Can't connect to server.");
                        break;

                    case 1045:
                        Console.Error.WriteLine("Invalid username/password set");
                        break;
                }
                return false;
            }
        }

        //Close connection. This isn't vital as we don't need to stress about number of connections, but it might help prevent weirdness.
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public List<Tuple<string, string>> getCategoryNames()
        {
            if (connection.State == ConnectionState.Closed)
            {
                OpenConnection();
            }
            List<Tuple<string, string>> categories = new List<Tuple<string, string>>();

            string query = "SELECT DISTINCT category, category_displayname FROM where2next.categories";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;

            var dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // This should close the connection for us when the reader is closed

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    categories.Add(Tuple.Create(dataReader.GetString(0), dataReader.GetString(1)));
                }
            }
            else
            {
                Trace.Write("Failed to get list of categories");
            }
            dataReader.Close();

            return categories;
        }

        public List<Tuple<string, string>> getServicesInCategories(List<string> categories)
        {
            if (connection.State == ConnectionState.Closed)
            {
                OpenConnection();
            }
            List<Tuple<string, string>> services = new List<Tuple<string, string>>();
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT DISTINCT c.tablename, c.table_displayName FROM where2next.categories c WHERE c.category IN (");
            foreach (var cat in categories)
            {
                queryBuilder.Append(string.Format("'{0}', ", cat));
            }
            queryBuilder.Append("'none');"); // Partly a hack to deal with the trailing comma, partly in case I really do end up with a "none" category at any point

            string query = queryBuilder.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;

            var dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // This should close the connection for us when the reader is closed

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    services.Add(Tuple.Create(dataReader.GetString(0), dataReader.GetString(1)));
                }
            }
            else
            {
                Trace.Write("Failed to get list of categories");
            }
            dataReader.Close();
            return services;
        }

        public Suburb getSuburb(string suburbName)
        {
            if (connection.State == ConnectionState.Closed)
            {
                OpenConnection();
            }
            // Using a prepared statement now to mitigate the gaping security hole that is sending
            // user input to the database
            SqlCommand cmd = new SqlCommand("SELECT s.suburb, s.postcode, s.latitude, s.longitude, s.wikiURL, s.picURL FROM where2next.suburb_gnaf s WHERE s.suburb = @suburbname", connection); // much better to do this in a single line
            SqlParameter snameParam = new SqlParameter("@suburbname", SqlDbType.VarChar, 40); // Limit to 40 chars because we don't need more, excessive capabilities tend to present risks
            snameParam.IsNullable = false;
            snameParam.Value = suburbName;
            cmd.Parameters.Add(snameParam);
            cmd.Prepare();

            var dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // This should close the connection for us when the reader is closed

            if (dataReader.HasRows)
            {
                dataReader.Read();
                var name = dataReader.GetString(0);
                var postcode = dataReader.GetInt32(1).ToString();
                var latitude = dataReader.GetDouble(2).ToString();
                var longitude = dataReader.GetDouble(3).ToString();
                var wikiUrl = dataReader.GetString(4);
                var picUrl = dataReader.GetString(5);
                Suburb suburb = new Suburb(name, postcode, latitude, longitude, wikiUrl, picUrl);
                return suburb;
            }
            else
            {
                return new Suburb();
            }
        }

        public List<Service> getServiceList(string suburbName)
        {
            if (connection.State == ConnectionState.Closed)
            {
                OpenConnection();
            }

            // Get the full list of tables to check
            string getTablesQuery = "SELECT tablename from where2next.categories";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = getTablesQuery;
            cmd.Connection = connection;
            var dataReader = cmd.ExecuteReader(); // We're NOT closing the connection here because we'll need to use it like a lot... though we might want different behaviour entirely if I go async

            List<string> tableNames = new List<string>();
            while (dataReader.Read())
            {
                tableNames.Add(dataReader.GetString(0));
            }
            dataReader.Close(); // Didn't set the property, so this DOESN'T close the connection, just the reader that we're done with

            // Iterate over all the tables getting all the relevant services This is terrible and
            // needs to be deleted And replaced with something less disgustingly inefficient and
            // preferably async
            List<Service> services = new List<Service>();
            foreach (string tableName in tableNames)
            {
                SqlCommand getServiceCmd = new SqlCommand(string.Format("SELECT s.name, s.address, s.latitude, s.longitude, s.telephone, s.type, s.postcode from where2next.{0} s where s.suburb = @suburbname", tableName), connection);
                SqlParameter snameParam = new SqlParameter("@suburbname", SqlDbType.VarChar, 40);
                snameParam.IsNullable = false;
                snameParam.Value = suburbName;
                getServiceCmd.Parameters.Add(snameParam);
                getServiceCmd.Prepare();

                var dr = getServiceCmd.ExecuteReader(); // We're NOT setting up to close the connection here because we'll need to use it bunch of times\
                // Hopefully we're getting rows from a given table now...
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {// Discovered the nil coalescing operator.
                        var stype = dr["type"] as string ?? "—"; // Moved this here so we can use it to generate a service name if we get a null
                        var sname = dr["name"] as string ?? string.Format("{0} {1}", suburbName, stype); // If the name field of the service is empty, then invent a name based on suburb name and service type.
                        var saddress = dr["address"] as string ?? "—";
                        var slatitude = string.Format("{0}", dr["latitude"] as double? ?? default(double)); // Not sure this is the most elegant way of doing this
                        var slongitude = string.Format("{0}", dr["longitude"] as double? ?? default(double));
                        var stelephone = dr["telephone"] as string ?? "0";

                        var spostcode = string.Format("{0}", dr["postcode"] as Int32? ?? 0); // I keep wanting to use |> to do this but I can't...
                        Service s = new Service(stype, sname, saddress, suburbName, "VIC", spostcode, slatitude, slongitude, stelephone);
                        services.Add(s);
                    }
                }
                dr.Close(); // Double checking I closed this...
            }
            return services;
        }
    }
}

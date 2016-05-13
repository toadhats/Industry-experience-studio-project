using Geocoder;
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
using Where2Next;

namespace Geocoder
{
    public class DBConnect : IDisposable
    {
        private SqlConnection connection;

        //private string server;

        //private string database;
        //private string uid;
        //private string password;

        // Constructor
        public DBConnect()
        {
            Initialise();
        }

        // I kind of like this pattern of having a seperate Initialise() method
        private void Initialise()
        {
            //server = ""; // maybe go back to using this approach
            //database = ""; // or maybe don't
            //uid = "";
            //password = "";
            string connectionString;
            connectionString = "Server=tcp:where2next.database.windows.net,1433;Database=Where2NextMS;User ID=where2next@where2next;Password='d8wV>?skM59j';Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            connection = new SqlConnection(connectionString);
        }

        // Opens the connection to the database while handling any resulting exceptions and helping
        // us ensure we're connected before trying anything
        private bool OpenConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                return true;
            }
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
            if (connection.State == ConnectionState.Closed)
            {
                return true;
            }
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

        public SqlDataReader sendQuery(string query)
        {
            if (connection.State == ConnectionState.Closed)
            {
                OpenConnection();
            }
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandTimeout = 60; // Ugly hack to check if timeouts are causing the problem, be careful with this
            SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection); // This should close the connection for us when the reader is closed

            return dataReader;
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

        public List<string> getAllServiceTableNames()
        {
            if (connection.State == ConnectionState.Closed)
            {
                OpenConnection();
            }
            var tableNames = new List<string>();
            SqlCommand cmd = new SqlCommand("Select tablename from where2next.categories", connection);
            using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    tableNames.Add(dr.GetString(0));
                }

                return tableNames;
            }
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

            using (var dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) // This should close the connection for us when the reader is closed
            {
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
        }

        public List<Tuple<Tuple<string, string>, List<Service>>> getServiceList(string suburbName)
        {
            if (connection.State == ConnectionState.Closed)
            {
                OpenConnection();
            }

            // Get the full list of tables to check
            string getTablesQuery = "SELECT tablename, table_displayname from where2next.categories order by category";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = getTablesQuery;
            cmd.Connection = connection;
            var dataReader = cmd.ExecuteReader(); // We're NOT closing the connection here because we'll need to use it like a lot... though we might want different behaviour entirely if I go async

            var tableNames = new List<Tuple<string, string>>();
            while (dataReader.Read())
            {
                tableNames.Add(new Tuple<string, string>(dataReader.GetString(0), dataReader.GetString(1)));
            }
            dataReader.Close(); // Didn't set the property, so this DOESN'T close the connection, just the reader that we're done with

            List<Tuple<Tuple<string, string>, List<Service>>> services = new List<Tuple<Tuple<string, string>, List<Service>>>(); // Ok maybe this is getting out of hand now...
            // Iterate over all the tables getting all the relevant services. This is terrible and
            // should be async.
            foreach (Tuple<string, string> tableName in tableNames)
            {
                var subList = new Tuple<Tuple<string, string>, List<Service>>(tableName, new List<Service>());
                // One weird trick discovered by an idiot for parameterising a table name. Only
                // safe-ish because it's not user input.
                SqlCommand getServiceCmd = new SqlCommand(string.Format("SELECT s.name, s.address, s.latitude, s.longitude, s.telephone, s.type, s.postcode from where2next.{0} s where s.suburb = @suburbname", tableName.Item1), connection);
                SqlParameter snameParam = new SqlParameter("@suburbname", SqlDbType.VarChar, 40);
                snameParam.IsNullable = false;
                snameParam.Value = suburbName;
                getServiceCmd.Parameters.Add(snameParam);
                getServiceCmd.Prepare();

                var dr = getServiceCmd.ExecuteReader(); // We're NOT setting up to close the connection here because we'll need to use it bunch of times
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
                        subList.Item2.Add(s);
                    }
                }
                dr.Close();
                services.Add(subList);
            }
            CloseConnection(); // Have to close it manually because I kept it open throughout the loops
            return services;
        }

        public List<Tuple<string, double, double, string>> getSuburbLocation(string suburbName)
        {
            if (connection.State == ConnectionState.Closed)
            {
                OpenConnection();
            }
            List<Tuple<string, double, double, string>> suburb = new List<Tuple<string, double, double, string>>();
            string query;
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;
            if (System.Text.RegularExpressions.Regex.IsMatch(suburbName.Trim(), "^\\d+$"))
            {
                query = "select suburb,Latitude,Longitude,replace(CONCAT(suburb,postcode),' ','') as marker from where2next.suburb_gnaf where postcode = @suburbpostcode";
                SqlParameter snameParam = new SqlParameter("@suburbpostcode", SqlDbType.Int, 40);
                snameParam.IsNullable = false;
                snameParam.Value = Convert.ToInt32(suburbName);
                cmd.Parameters.Add(snameParam);
            }
            else
            {
                query = "select suburb,Latitude,Longitude,replace(CONCAT(suburb,postcode),' ','') as marker from where2next.suburb_gnaf where suburb = @suburbname";
                SqlParameter snameParam = new SqlParameter("@suburbname", SqlDbType.VarChar, 40);
                snameParam.IsNullable = false;
                snameParam.Value = suburbName;
                cmd.Parameters.Add(snameParam);
            }
            cmd.CommandText = query;
            cmd.Prepare();
            var dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // This should close the connection for us when the reader is closed

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    suburb.Add(Tuple.Create(dataReader.GetString(0), dataReader.GetDouble(1), dataReader.GetDouble(2), dataReader.GetString(3)));
                }
            }
            else
            {
                Trace.Write("Failed to find the suburb");
            }

            dataReader.Close();

            return suburb;
        }

        public SuburbPriceData getHousePriceOfSuburb(string suburbName)
        {
            if (connection.State == ConnectionState.Closed)
            {
                OpenConnection();
            }
            var priceQuery = "select ranking, suburb, price1, price2, price3, price4, price5 from where2next.suburbPrice2 where suburb = @suburbname";
            SqlCommand cmd = new SqlCommand(priceQuery, connection);
            SqlParameter snameParam = new SqlParameter("@suburbname", SqlDbType.VarChar, 40);
            snameParam.IsNullable = false;
            snameParam.Value = suburbName;
            cmd.Parameters.Add(snameParam);
            cmd.Prepare();

            using (var dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                if (dataReader.HasRows && dataReader.Read()) // this relies on the (shaky) assumption that if the first condition evaluates to false, the program will stop checking...
                {
                    var rank = dataReader.GetInt64(0) as long? ?? 0;
                    var name = (string)dataReader["suburb"] as string ?? "null";
                    var price1 = (int)dataReader["price1"] as int? ?? 0;
                    var price2 = (int)dataReader["price2"] as int? ?? 0;
                    var price3 = (int)dataReader["price3"] as int? ?? 0;
                    var price4 = (int)dataReader["price4"] as int? ?? 0;
                    var price5 = (int)dataReader["price5"] as int? ?? 0;

                    var priceData = new SuburbPriceData(rank, name, price1, price2, price3, price4, price5);
                    return priceData;
                }
                else return new SuburbPriceData(); // The 'nullish' version of our data object
            }
        }

        //Connection wrapper around the method to update latitude and longitude of a service
        public void UpdateLatLongWithConnection(string table, int id, double latitude, double longitude)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                UpdateLatLong(table, id, latitude, longitude);
            }
            this.CloseConnection();
        }

        //Update latitude and longitude of a service. Does NOT control or check the connection status, use this to prevent mindless connecting and disconnecting in loops mainly, otherwise use the connection wrapper.
        public void UpdateLatLong(string table, int id, double latitude, double longitude)
        {
            string query = "UPDATE where2next." + table + " SET latitude = " + latitude + ", longitude = " + longitude + " WHERE id = " + id;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;

            //This uses method "ExecuteNonQuery" because it does not return any results
            if (cmd.ExecuteNonQuery() == 0)
            {
                Console.WriteLine("Didn't update anything?");
            }
            else
            {
                Console.WriteLine("Updated row {0}", id);
            }
        }

        // Finds rows that are missing latitude or longitude, or which have already been mistakenly
        // filled with values from the wrong hemisphere lol
        public List<Tuple<int, string, string>> GetRowsWithoutCoords(string table)
        {
            var ids = new List<Tuple<int, string, string>>();
            string query = "SELECT * FROM where2next." + table + " WHERE (address IS NOT NULL) AND (id IS NOT NULL) AND (suburb IS NOT NULL) AND ((latitude IS NULL or latitude > 0) OR (longitude IS NULL or longitude < 0))";

            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                // We need a data reader obejct to handle the results
                SqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    var details = Tuple.Create(Convert.ToInt32(dataReader["ID"]), (string)dataReader["Address"], (string)dataReader["Suburb"]);
                    ids.Add(details);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
            else
            {
                Console.Error.WriteLine("Could not get a database connection while trying to fetch row ids");
            }

            return ids;
        }

        // This needs to be rate limited to comply with the restrictions on the google geocoding api

        public void FixMissingCoords(string table)
        {
            var idsToFix = GetRowsWithoutCoords(table);
            if (idsToFix.Count > 0)
            {
                Console.WriteLine("{0} rows in {1} need fixing.", idsToFix.Count, table);
                GoogleConnect ApiConnection = new GoogleConnect();
                this.OpenConnection();
                var bucket = new TokenBucket();
                foreach (var entity in idsToFix)
                {
                    bucket.waitForToken(); // This will sleep the thread if it doesn't get a token. Not ideal but w/e

                    var id = entity.Item1;
                    var address = String.Format("{0}, {1}, Victoria, Australia", entity.Item2, entity.Item3);
                    var coords = ApiConnection.GetLatLong(address);
                    //Console.WriteLine("Got coordinates {0}, {1} for address {2}", coords.Item1, coords.Item2, address);
                    UpdateLatLong(table, id, coords.Item1, coords.Item2);
                }
                this.CloseConnection();
            }
            else
            {
                Console.WriteLine("No services in this table are missing coordinates");
            }
        }
    }
}

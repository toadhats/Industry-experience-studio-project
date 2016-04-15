using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Geocoder
{
    // This class wraps up all the database boilerplate, for readibility and separation of concerns.
    internal class DBConnect
    {
        // We could just have one of these in the main class, but it's much better to keep it here
        private MySqlConnection connection;

        // Connection variables. These should be in a seperate config file, not here.
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
            server = "bitnami-mysql-3526.cloudapp.net";
            database = "where2next";
            uid = "where2next";
            password = "nakdYzWd";
            string connectionString;
            // TODO: refactor this to use a formatted string
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        // Opens the connection to the database while handling any resulting exceptions and helping us ensure we're connected before trying anything
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
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
            catch (MySqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }

        //Connection wrapper around the method to update latitude and longitude of a service
        public void UpdateLatLongWithConnection(string table, int id, double latitude, double longitude)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                updateLatLong(table, id, latitude, longitude);
            }
            this.CloseConnection();
        }

        //Update latitude and longitude of a service. Does NOT control or check the connection status, use this to prevent mindless connecting and disconnecting in loops mainly, otherwise use the connection wrapper.
        public void updateLatLong(string table, int id, double latitude, double longitude)
        {
            string query = "UPDATE " + table + " SET latitude = " + latitude + ", longitude = " + longitude + " WHERE id = " + id;
            MySqlCommand cmd = new MySqlCommand();
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

        public List<Tuple<int, string>> GetRowsWithoutCoords(string table)
        {
            var ids = new List<Tuple<int, string>>();
            string query = "SELECT * FROM " + table;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // We need a data reader obejct to handle the results
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    var details = Tuple.Create(Convert.ToInt32(dataReader["ID"]), (string)dataReader["Address"]);
                    ids.Add(details);
                }
                Console.WriteLine("There are {0} rows in table {1} missing coordinates", ids.Count, table);

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
                int lastRequest = Environment.TickCount;
                var bucket = new TokenBucket();
                foreach (var entity in idsToFix)
                {
                    bucket.waitForToken(); // This will sleep the thread if it doesn't get a token. Not ideal but w/e
                    int elapsedTime = Environment.TickCount - lastRequest;
                    var id = entity.Item1;
                    var address = entity.Item2;
                    var coords = ApiConnection.GetLatLong(address);
                    Console.WriteLine("Got coordinates {0}, {1} for address {2}", coords.Item1, coords.Item2, address);
                    UpdateLatLongWithConnection(table, id, coords.Item1, coords.Item2);
                }
            }
            else
            {
                Console.WriteLine("No services in this table are missing coordinates");
            }
        }
    }
}
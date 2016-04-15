using MySql.Data.MySqlClient;
using System;

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

        //Update latitude and longitude of a service
        public void UpdateLatLong(string table, int id, string latitude, string longitude)
        {
            string query = "UPDATE " + table + "SET latitude=" + latitude + ", longitude= " + longitude + " WHERE id=" + id;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command, set its query and connection properties from our variables
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                //This uses method "ExecuteNonQuery" because it does not return any results
                cmd.ExecuteNonQuery();

                //close connection when we're done. 
                // It might be better to keep the connection open if we can get a batch of updates to behave properly. Maybe a different method, later.
                this.CloseConnection();
            }
        }

    }
}
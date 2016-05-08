using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace Where2Next
{
    public class DBConnect : IDisposable
    {
        private MySqlConnection connection;

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
            database + ";" + "User ID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
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
            MySqlCommand cmd = new MySqlCommand();
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
    }
}

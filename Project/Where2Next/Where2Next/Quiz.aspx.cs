using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Where2Next
{
    public partial class quizTest : System.Web.UI.Page
    {
        // Variables for this page instance
        public List<string> selectedServices;
        public string queryToSend = "";
        // we should NOT keep this connection string in the source but I don't want to confuse everyone by using the config files again
        private string connectionString = @"Data Source=bitnami-mysql-3526.cloudapp.net; Database=where2next; User ID=where2next; password='nakdYzWd'";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["selectedServices"] == null)
            {
                ViewState["selectedServices"] = new List<String>();
            }
            
            selectedServices = new List<String>(); //  Not sure if I should even make this a class level variable anymore
        }

        protected void SelectService(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string selection = button.CommandArgument.ToString();

            switch (selection)
            {
                case "artspaces":
                case "centrelink":
                case "disabilityactivity":
                case "gpsuper":
                case "iceskating":
                case "library":
                case "medicare":
                case "publicinternet":
                case "recreation":
                case "rollerskating":
                case "school":
                case "skateparks":
                case "sportingclubs":
                case "swimmingpools":
                case "tafe":
                    if (selectedServices.Any(s => s == selection)) // checks if item is in list, read https://msdn.microsoft.com/en-AU/library/bb397687.aspx for more info about lambda expressions
                    {
                        selectedServices = (List<string>)ViewState["selectedServices"]; // Take list out of view state
                        selectedServices.Remove(selection); // If it's already in the list we want to remove it, this creates toggle behavior and prevents duplicates.
                        ViewState["selectedServices"] = selectedServices; // Put updated list back into view state
                        // Toggling needs to be represented to the user as well
                    }
                    else
                    {
                        selectedServices = (List<string>)ViewState["selectedServices"]; // Take list out of view state
                        selectedServices.Add(selection); // As long as the value is valid we can just pass it straight in, because it doesn't come from the user.
                        ViewState["selectedServices"] = selectedServices; // Put updated list back into view state
                    }
                    break;
                default: // If we get to here, you passed in a bad parameter.
                    Console.Error.WriteLine("Invalid argument {0} passed to SelectService button handler. Argument must be a valid table name.", selection);
                    return;
            }


        }

        protected void SubmitButton(object sender, EventArgs e)
        {
            selectedServices = (List<string>)ViewState["selectedServices"]; // Get the persistant list out of the view state
            if (selectedServices.Count == 0)
            {
                Console.Error.WriteLine("Attempting to create a query, but user has not selected antyhing"); // An error should be displayed to the user in this case
                ClientError("Please select at least one service.");
                return;
            }

            // construct query and send to DB
            queryToSend = "SELECT DISTINCT SUBURB.SUBURB, SUBURB.POSTCODE FROM SUBURB ";

            foreach (var service in selectedServices)
            {
                queryToSend += "INNER JOIN " + service + " ON SUBURB.SUBURB = " + service + ".SUBURB ";
            }

            ClientError("Query that will be sent: " + queryToSend); // For debug purposes delete once confirmed working
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(queryToSend, connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                string total = ""; // Copying old method for now until we know how we are going to present results
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        string suburb = dataReader.GetString(0);
                        string postcode = dataReader.GetString(1);
                        total += Environment.NewLine + "<tr><td>" + suburb + "</t><td>" + postcode + "</td></tr>";
                    }

                    result.Text = "  <div class='item'><img src='/images/success.jpg' style='height: auto; width: 100%'></div><table class='table table-hover'  style='width: 750px;margin:0px auto' ><caption><h2> The following suburbs meet your requirements: </h2></caption><thead><tr><th>Suburb Name</th><th>Postcode</th></tr></thead><tbody>" + total + "<thead></tbody></table>";
                    dataReader.Close();
                    connection.Close();
                }

            }

        }

        // Should allow me to create an error box for the client from in here.
        private void ClientError(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Text;

namespace Where2Next
{
    public partial class quizTest : System.Web.UI.Page
    {
        // Variables for this page instance
        public List<string> selectedServices;  //  Not sure if I should even make this a class level variable anymore
        public string queryToSend = "";
        // delete this once results page is working
        private string connectionString = @"Data Source=bitnami-mysql-3526.cloudapp.net; Database=where2next; User ID=where2next; password='nakdYzWd'";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["selectedServices"] == null)
            {
                ViewState["selectedServices"] = new List<String>();
                selectedServices = new List<String>();
            }
            
            
        }

        protected void SelectService(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string selection = button.CommandArgument.ToString();
            var buttonCssClass = sender.GetType().GetProperty("CssClass");
            selectedServices = (List<string>)ViewState["selectedServices"]; // Read list out of view state

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
                case "sportingclubsorgs":
                case "swimmingpools":
                case "tafe":
                    if (selectedServices.Any(s => s == selection)) // checks if item is in list, read https://msdn.microsoft.com/en-AU/library/bb397687.aspx for more info about lambda expressions
                    {
                        
                        selectedServices.Remove(selection); // If it's already in the list we want to remove it, this creates toggle behavior and prevents duplicates.
                        ViewState["selectedServices"] = selectedServices; // Put updated list back into view state
                        // Toggling needs to be represented to the user as well
                        buttonCssClass.SetValue(sender, "buttonDeselected");
                    }
                    else
                    {
                        selectedServices = (List<string>)ViewState["selectedServices"]; // Take list out of view state
                        selectedServices.Add(selection); // As long as the value is valid we can just pass it straight in, because it doesn't come from the user.
                        ViewState["selectedServices"] = selectedServices; // Put updated list back into view state
                        buttonCssClass.SetValue(sender, "buttonSelected");
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
                Console.Error.WriteLine("Attempting to create a query, but user has not selected anything"); // An error should be displayed to the user in this case
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
            var encodedQuery = Base64ForUrlEncode(queryToSend);
            Response.Redirect("quizResults.aspx?query=" + encodedQuery);
        

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

        // For encoding the completed query to pass to the results page in the URL
        public static string Base64ForUrlEncode(string query)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(query);
            return HttpServerUtility.UrlTokenEncode(buffer);
        }
    }
}
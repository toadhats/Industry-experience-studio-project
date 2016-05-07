using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Where2Next
{
    public partial class quizTest : System.Web.UI.Page
    {
        // Variables for this page instance
        public List<string> selectedServices;

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
                    // Console.Error.WriteLine("Invalid argument {0} passed to SelectService button
                    // handler. Argument must be a valid table name.", selection);
                    return;
            }
        }

        protected void SubmitButton(object sender, EventArgs e)
        {
            selectedServices = (List<string>)ViewState["selectedServices"]; // Get the persistant list out of the view state
            if (selectedServices.Count == 0)
            {
                // Console.Error.WriteLine("Attempting to create a query, but user has not selected
                // anything"); // An error should be displayed to the user in this case
                ClientError("Please select at least one service.");
                return;
            }

            StringBuilder queryBuilder = new StringBuilder();

            // construct query and send to DB
            queryBuilder.Append("SELECT DISTINCT s.SUBURB, GROUP_CONCAT(DISTINCT s.POSTCODE ORDER BY s.POSTCODE SEPARATOR ', ') FROM SUBURB_GNAF s");
            foreach (var service in selectedServices)
            {
                queryBuilder.Append(" INNER JOIN " + service + " ON s.SUBURB = " + service + ".SUBURB");
            }
            queryBuilder.Append(" GROUP BY s.SUBURB ASC;"); // Grouping by suburb name to concatenate the postcodes

            var encodedQuery = Base64ForUrlEncode(queryBuilder.ToString());
            var tempDecodedQuery = Encoding.UTF8.GetString(HttpServerUtility.UrlTokenDecode(encodedQuery));
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

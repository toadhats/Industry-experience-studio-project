using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Where2Next
{
    public partial class QuizServices : System.Web.UI.Page
    {
        // For holding the list of services in the categories selected by the user. We need the
        // system name and the user-friendly name
        public List<Tuple<string, string>> serviceList;

        // Works more or less the same as the categories/old quiz.
        private List<string> serviceButtons = new List<string>();

        public List<string> selectedServices;

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            serviceButtons = (List<string>)ViewState["serviceButtons"];

            populateServiceList();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["selectedServices"] == null)
            {
                ViewState["selectedServices"] = new List<String>();
                selectedServices = new List<String>();
            }
            if (!IsPostBack)
            {
                serviceButtons = new List<string>();
                ViewState["serviceButtons"] = serviceButtons;
                populateServiceList();
            }
        }

        public void populateServiceList()
        {
            var categoryListString = Request["query"];
            var categoryList = categoryListString.Split(',').ToList();

            using (DBConnect db = new DBConnect())
            {
                serviceList = db.getServicesInCategories(categoryList);

                foreach (Tuple<string, string> service in serviceList)
                {
                    var image = "Images/quizServices/" + service.Item1 + ".jpg"; // Todo: Handle .png as well, or just use .png probably
                    if (!File.Exists(Server.MapPath(image)))
                    {
                        image = "Images/quizServices/placeholder.jpg"; // Todo: Placeholder image that isn't a pile of random footballs
                    }

                    System.Web.UI.HtmlControls.HtmlButton cat = new System.Web.UI.HtmlControls.HtmlButton();
                    cat.ID = service.Item1; // set the ID of this element to the category name to keep things sane
                    cat.Attributes.Add("runat", "server"); // Not sure if we need this, since the placeholder is already runat server
                    cat.Attributes.Add("CommandArgument", service.Item1); // We don't really need to keep using this, we could just use the id, but it feels right
                    cat.Attributes.Add("class", "categoryCard"); // the default state (not selected)
                    cat.InnerHtml = String.Format("<h4>{1}</h4> <hr/> <img src =\"{2}\" alt=\"{1}\" />", service.Item1, service.Item2, image); // Putting our custom interface content into the element
                    cat.ServerClick += new EventHandler(SelectService); // SEEMS to work like the OnClick did on an <asp:Button>. Took me like 4 hours to work out.

                    displayServices.Controls.Add(cat); // Add it to the placeholder, apparently asp.net handles the rest...
                }
            }
        }

        protected void SelectService(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlButton button = (System.Web.UI.HtmlControls.HtmlButton)sender;
            string selection = button.ID; var buttonCssClass = sender.GetType().GetProperty("CssClass");
            selectedServices = (List<string>)ViewState["selectedServices"]; // Read list out of view state

            if (selectedServices.Any(s => s == selection))
            {
                selectedServices.Remove(selection); // If it's already in the list we want to remove it, this creates toggle behavior and prevents duplicates.
                ViewState["selectedServices"] = selectedServices; // Put updated list back into view state
                                                                  // Toggling needs to be represented
                                                                  // to the user as well
                button.Attributes.Add("class", "categoryCard"); // Remove the class that highlights the card
            }
            else
            {
                selectedServices = (List<string>)ViewState["selectedServices"]; // Take list out of view state
                selectedServices.Add(selection); // As long as the value is valid we can just pass it straight in, because it doesn't come from the user.
                ViewState["selectedServices"] = selectedServices; // Put updated list back into view state
                button.Attributes.Add("class", "categoryCard categorySelected"); // Remove the class that highlights the card
            }
        }

        protected void SubmitButton(object sender, EventArgs e)
        {
            selectedServices = (List<string>)ViewState["selectedServices"]; // Get the persistant list out of the view state
            if (selectedServices.Count == 0)
            {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Where2Next
{
    public partial class SuburbProfile : System.Web.UI.Page
    {
        private Suburb suburb;
        private string suburbName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request["query"] != null)
            {
                suburbName = Request["query"];
                Search(suburbName);
            }
        }

        // Method invoked by the search button, or automatically if we reach this site from a quiz
        // result. Handles all the side-effect-y UI garbage. Returns false if the input is invalid or
        // the suburb is not found, so a "not found" page can be displayed. This could probably be
        // broken up into smaller methods
        public bool Search(string suburbName)
        {
            if (!suburbName.All(x => Char.IsLetter(x) || Char.IsWhiteSpace(x) || x.Equals('-'))) return false; // keeps any garbage away from the rest of the method. Suburb names don't have numbers or symbols

            Page.Title = String.Format("Where2Next Profile: {0}", suburbName);

            suburb = getSuburb(suburbName);

            profileCard.Controls.Clear();

            // Create title of card
            profileCard.Controls.Add(new LiteralControl(String.Format("<h1>{0}</h1><h3>{1}</h3><hr/>", suburb.Name, suburb.Postcode)));

            // Try adding a picture
            if (suburb.PicUrl.Length > 0)
            {
                Image suburbPic = new Image();
                suburbPic.AlternateText = suburb.Name;
                suburbPic.ImageUrl = suburb.PicUrl;
                suburbPic.CssClass = "suburbPic";
                suburbPic.ImageAlign = ImageAlign.AbsMiddle;
                profileCard.Controls.Add(suburbPic);
            }

            // Get list of services
            var services = getServices().OrderBy(x => x.Item1);

            var sb = new StringBuilder();
            sb.Append("<table class=\"serviceTable\"><thead><tr><th><h3>Services</h3></th></tr></thead><tbody>");
            foreach (var subList in services)
            {
                if (subList.Item2.Count >= 1)
                {
                    sb.AppendFormat("<tr><th>{0}</th></tr>", subList.Item1.Item2);
                    foreach (var service in subList.Item2.OrderBy(x => x.serviceName))
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td></tr>", service.serviceName, service.address);
                    }
                }
            }
            sb.Append("</tbody></table>");
            profileCard.Controls.Add(new LiteralControl(sb.ToString()));

            // Get house price data if we can
            var priceData = getSuburbPriceData();
            if (priceData.exists)
            {
                var priceDataBuilder = new StringBuilder();
                priceDataBuilder.AppendFormat("<div class=\"priceCard\"><p>The average house price in {0} is <strong>{1:C0}</strong><br> &nbsp; <em>#{2} in Victoria</em>", priceData.suburbName, priceData.price5, priceData.ranking); // This would be a LOT better if I wrote something to handle ordinals (e.g. 1st, 2nd, 3rd). Maybe later.
                profileCard.Controls.Add(new LiteralControl(priceDataBuilder.ToString()));
            }

            return true;
        }

        public void SearchButton(object sender, EventArgs e)
        {
            // Grab the contents of the text box.
            var input = suburbSearchText.Value; // I was trying to avoid a postback, but I realised I can't. Should have used JQuery or something
            suburbName = input; // Should probably just stop using the global var
            Search(input);
        }

        public Suburb getSuburb(string suburbName)
        {
            using (DBConnect db = new DBConnect())
            {
                suburb = db.getSuburb(suburbName); // get the suburb details out of the database packed into an instance of Suburb for convenience/my sanity
                if (!suburb.Name.Equals("empty")) // This is an extremely shameful hack I will fix it after I sleep
                {
                    return suburb;
                }
                else
                {
                    throw new Exception("Didn't get a suburb from the database"); // TODO: Handle this exception
                }
            }
        }

        public SuburbPriceData getSuburbPriceData()
        {
            using (DBConnect db = new DBConnect())
            {
                var priceData = db.getHousePriceOfSuburb(suburbName);
                return priceData;
            }
        }

        public List<Tuple<Tuple<string, string>, List<Service>>> getServices()
        {
            using (DBConnect db = new DBConnect())
            {
                var services = db.getServiceList(suburbName);
                return services;
            }
        }
    }
}

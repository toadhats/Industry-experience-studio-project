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
            if (Request["query"] != null)
            {
                suburbName = Request["query"];
            }
            if (suburbName.Length > 0)
            {
                Page.Title = String.Format("Where2Next Profile: {0}", suburbName);

                // This probably needs to be wrapped in a try/catch
                suburb = getSuburb(suburbName);

                // Create title of card
                profileCard.Controls.Add(new LiteralControl(String.Format("<h1>{0}</h1><h3>{1}</h3><hr/>", suburb.Name, suburb.Postcode)));

                // Try adding a picture
                if (suburb.PicUrl.Length > 0)
                {
                    Image suburbPic = new Image();
                    suburbPic.AlternateText = suburb.Name;
                    suburbPic.ImageUrl = suburb.PicUrl;
                    suburbPic.ImageAlign = ImageAlign.TextTop;
                    suburbPic.Width = 600;
                    profileCard.Controls.Add(suburbPic);
                }

                // Get list of services
                var services = getServices().OrderBy(x => x.Item1);

                //var services = getServices().OrderBy(x => x.serviceType).ThenBy(x => x.serviceType);
                var sb = new StringBuilder();
                sb.Append("<table class=\"serviceTable\"><tr><thead><h3>Services<h3></thead></tr>");
                // TODO: Insert section headings between each subset of results belonging to a type
                //       of service? Alternatively, just make sure all the type fields are meaningful
                // to the user.
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
                sb.Append("</table>");
                profileCard.Controls.Add(new LiteralControl(sb.ToString()));
            }
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
                    throw new Exception("Didn't get a suburb from the database"); // BUG: A nonexistent or malformed suburb name that returns no results throws an exception here
                }
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

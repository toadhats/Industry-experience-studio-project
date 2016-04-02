using System;
using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Where2Next
{
    public partial class Map : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GLatLng mainLocation = new GLatLng(-38.030, 145.310);
                GMap1.setCenter(mainLocation, 10);
                XPinLetter xpinLetter = new XPinLetter(PinShapes.pin_star, "H", Color.Blue, Color.White, Color.Chocolate);
                GMap1.Add(new GMarker(mainLocation, new GMarkerOptions(new GIcon(xpinLetter.ToString(), xpinLetter.Shadow()))));

                List<SuburbMaster> suburbs = new List<SuburbMaster>();
                using (suburbEntities dc = new suburbEntities())
                {
                    suburbs = dc.SuburbMaster.Where(a => a.State.Equals("VIC")).ToList();

                }

                PinIcon p;
                GMarker gm;
                foreach (var i in suburbs)
                {
                    p = new PinIcon(PinIcons.home, Color.Cyan);
                    gm = new GMarker(new GLatLng(Convert.ToDouble(i.LocLa), Convert.ToDouble(i.LocLong)),
                        new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));
                }
            }
        }
    }
}
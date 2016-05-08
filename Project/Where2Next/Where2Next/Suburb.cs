using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Where2Next
{
    public class Suburb
    {
        private string name;
        private string postcode;
        private string latitude;
        private string longitude;

        // In case I can get these working
        private string wikiUrl;

        private string picUrl;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Postcode
        {
            get
            {
                return postcode;
            }

            set
            {
                postcode = value;
            }
        }

        public string Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }

        public string Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
            }
        }

        public string WikiUrl
        {
            get
            {
                return wikiUrl;
            }

            set
            {
                wikiUrl = value;
            }
        }

        public string PicUrl
        {
            get
            {
                return picUrl;
            }

            set
            {
                picUrl = value;
            }
        }

        public Suburb()
        {
            Name = "empty";
            Postcode = "empty";
            Latitude = "empty";
            Longitude = "empty";
            WikiUrl = "empty";
            PicUrl = "empty";
        }

        public Suburb(string name, string postcode, string latitude, string longitude, string wikiUrl, string picUrl)
        {
            this.Name = name;
            this.Postcode = postcode;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.WikiUrl = wikiUrl;
            this.PicUrl = picUrl;
        }
    }
}

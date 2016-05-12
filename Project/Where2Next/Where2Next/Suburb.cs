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

    public class SuburbPriceData
    {
        public readonly long ranking;
        public readonly string suburbName;
        public readonly int price1, price2, price3, price4, price5;
        public readonly bool exists; // Attempted home-brew optional?

        public SuburbPriceData(long ranking, string suburbName, int price1, int price2, int price3, int price4, int price5)
        {
            this.ranking = ranking;
            this.suburbName = suburbName;
            this.price1 = price1;
            this.price2 = price2;
            this.price3 = price3;
            this.price4 = price4;
            this.price5 = price5;
            exists = true;
        }

        // The empty constructor returns an invalid object which is flagged accordingly. I'm just
        // playing games here, this is a pattern I'm experimenting with (diy optionals?)
        public SuburbPriceData()
        {
            exists = false;
            this.ranking = default(long);
            this.suburbName = default(string);
            this.price1 = default(int);
            this.price2 = default(int);
            this.price3 = default(int);
            this.price4 = default(int);
            this.price5 = default(int);
        }
    }
}

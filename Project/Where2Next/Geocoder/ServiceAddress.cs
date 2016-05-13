using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocoder
{
    // We could pass data around in instances of this class, instead of in anonymous objects/tuples,
    // if we want to be more "java style" like monash teach lol.
    internal class ServiceAddress
    {
        private int postcode;
        private string address;
        private string suburb;
        private double latitude;
        private double longitude;

        public int Postcode
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

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Suburb
        {
            get
            {
                return suburb;
            }

            set
            {
                suburb = value;
            }
        }

        public double Latitude
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

        public double Longitude
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
    }
}

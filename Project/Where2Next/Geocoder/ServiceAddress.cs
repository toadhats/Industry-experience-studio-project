using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocoder
{
    // We could pass data around in instances of this class, instead of in anonymous objects/tuples, if we want to be more "java style" like monash teach lol.
    class ServiceAddress
    {
        public int postcode;
        public string address;
        public string suburb;
        public double latitude;
        public double longitude;

    }
}

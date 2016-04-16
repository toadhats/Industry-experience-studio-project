using Geocoding; // https://github.com/chadly/Geocoding.net
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Geocoder
{
    internal class GoogleConnect
    {
        private IGeocoder googleGeocoder;

        // Using the Initialise() pattern again
        public GoogleConnect()
        {
            Initialise();
        }

        private void Initialise()
        {
            // TODO: Really shouldn't be keeping this API key in the source
            googleGeocoder = new GoogleGeocoder() { ApiKey = "AIzaSyDW5PyYptD8Xgc4fvrPkeMjq9URClh4ITU" };
        }

        // Returns a tuple containing a latitude and longitude pair
        // Get things out of tuples using tuple.item1, tuple.item2, et cetera.
        public Tuple<double, double> GetLatLong(string address)
        {
            // This library calls the result class "Address" but it also contains the coordinates
            // Not sure why it returns a collection of them but I guess we'll find out
            IEnumerable<Address> results = googleGeocoder.Geocode(address);
            double latitude = 0.0;
            double longitude = 0.0;

            // Converting to double can (and will) throw formatting exceptions we need to handle
            try
            {
                latitude = Convert.ToDouble(results.First().Coordinates.Latitude);
                longitude = Convert.ToDouble(results.First().Coordinates.Longitude);
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Could not convert coordinates {0}, {1} to doubles", latitude, longitude);
                // If something goes wrong, coordinates will be zeroes
            }
            catch (InvalidOperationException e)
            {
                Console.Error.WriteLine(e.Message);
            }

            var coords = Tuple.Create(latitude, longitude);
            Console.WriteLine("Parsed coordinates {0}, {1}", coords.Item1, coords.Item2);
   
            return coords;
        }

        
    }
}
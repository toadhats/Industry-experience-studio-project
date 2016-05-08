using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Where2Next
{
    public class Service
    {
        public Service()
        {
        }

        public Service(string serviceType, string serviceName, string address, string suburb, string state, string postcode, string latitude, string longitude, string phone)
        {
            this.serviceType = serviceType;
            this.serviceName = serviceName;
            this.address = address;
            this.suburb = suburb;
            this.state = state;
            this.postcode = postcode;
            this.latitude = latitude;
            this.longitude = longitude;
            this.phone = phone;
        }

        public string serviceType { get; set; }
        public string serviceName { get; set; }
        public string address { get; set; }
        public string suburb { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string phone { get; set; }
    }
}

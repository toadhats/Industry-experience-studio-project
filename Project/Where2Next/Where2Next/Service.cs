using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace DataDigester
{
    public class Service : TableEntity
    {
        public Service() { }
        public string serviceType { get; set; }
        public string serviceName { get; set; }
        public string address { get; set; }
        public string suburb { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}

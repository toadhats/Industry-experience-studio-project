using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Azure;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DataDigester
{
    public class Functions
    {
        [NoAutomaticTrigger]
        public static async void UpdateData()
        {
            Console.WriteLine("UpdateData is running");
            // Job code goes here
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("Services");
            table.CreateIfNotExists();
            var serviceList = await getCentrelink();
            Console.WriteLine("Got {0} services", serviceList.ToList().Count);
            TableBatchOperation batchOperation = new TableBatchOperation();
            foreach (var result in serviceList)
            {
                result.PartitionKey = result.serviceType;
                result.RowKey = result.address;
                batchOperation.Insert(result); 
            }
            table.ExecuteBatch(batchOperation);


        }

        static async Task<IEnumerable<Service>> getCentrelink()
        {
            using (var client = new HttpClient())
            {
                // Set up the client to access our data
                client.BaseAddress = new Uri("http://data.gov.au/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Make the actual request. Returns an HTTP response
                Console.WriteLine("Attempting to send request for data");
                HttpResponseMessage response = await client.GetAsync("api/action/datastore_search?resource_id=5a45d7b2-8579-425b-bb46-53a0e0bfa053&limit=1000");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Recieved successful response.");
                    // turn response content into a JSON entity we can work with
                    JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());

                    // Extract just the actual results from the API response
                    IList<JToken> records = json["result"]["records"].Children().ToList();
                    Console.WriteLine("Extracted {0} records from API response", records.Count);

                    // Create an empty list that we're going to populate with our own "Clink" objects
                    IList<Service> offices = new List<Service>();
                    foreach (JToken record in records)
                    {
                        // deserialise the JSON into our object and add it to the list
                        Service serviceEntry = JsonConvert.DeserializeObject<Service>(record.ToString());
                        Console.WriteLine("{0}\t-\t{1}", serviceEntry.address, serviceEntry.suburb, serviceEntry.postcode);
                        offices.Add(serviceEntry);
                    }
                    //Console.WriteLine("VICTORIA:\n-------------------------------");
                    // Select all the offices in victoria and order by postcode - we make an anonymous object or w/e here
                    var inVic = (from office in offices
                                 where office.state == "VIC"
                                 orderby office.postcode ascending
                                 select office);
                    foreach (var vicOffice in inVic)
                    {
                        Console.WriteLine("{0}\t-\t{1}", vicOffice.postcode, vicOffice.suburb);
                    }
                    Console.WriteLine("{0} offices found in Victoria", inVic.Count());
                    return inVic.ToList<Service>();

                } else
                {
                    Console.WriteLine("Did not get a valid response.");
                    return new List<Service>();
                }
            }

        }
    }
}

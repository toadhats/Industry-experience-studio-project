﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace DataDigester
{
    public class Functions
    {
        [NoAutomaticTrigger]
        public static void UpdateData([Table("Services")] IQueryable<Service> tableBinding)
        {
            // Job code goes here
            


        }
    }
}

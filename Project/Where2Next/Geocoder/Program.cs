using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Geocoder
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Must specify a table for this utility to fix.");
                return 1;
            }
            DBConnect connection = new DBConnect();
            foreach (string tableName in args)
            {
                Console.Write("Checking table {0}", tableName);
                connection.FixMissingCoords(tableName);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return 0;
        }
    }
}

using System;

namespace Geocoder
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Must specify a table for this utility to fix.");
                return 1;
            }
            DBConnect connection = new DBConnect();
            foreach (string tableName in args)
            {
                Console.WriteLine("Checking table {0}", tableName);
                connection.FixMissingCoords(tableName);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return 0;
        }
    }
}
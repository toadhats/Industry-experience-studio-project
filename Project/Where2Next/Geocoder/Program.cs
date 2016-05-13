using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Geocoder
{
    internal class Program
    {
        private static DBConnect db = new DBConnect();
        static private List<string> tableList = db.getAllServiceTableNames();

        private static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Must specify a table for this utility to fix.");
                return 1;
            }

            if (args[0].Equals("-t"))
            {
                if (args.Length == 1)
                {
                    Console.Error.WriteLine("Must specify at least one table to test.");
                    return 2;
                }

                //var db = new DBConnect();
                foreach (string tablename in new List<string>(args).Skip(1))
                {
                    if (tableExists(tablename))
                    {
                        Console.WriteLine(String.Format("Checking table {0} for nulls", tablename));
                        var nulls = db.GetRowsWithoutCoords(tablename).Count;
                        Console.WriteLine(String.Format("{0} rows in {1} are missing coordinates.", nulls, tablename));
                    }
                    else
                    {
                        Console.Error.WriteLine("Table {0} does not exist in datbase", tablename);
                    }
                }
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return 0;
            }

            //DBConnect connection = new DBConnect();
            foreach (string tableName in args)
            {
                if (tableExists(tableName))
                {
                    Console.WriteLine("Checking table {0}", tableName);
                    db.FixMissingCoords(tableName);
                }
                else
                {
                    Console.Error.WriteLine("Table {0} does not exist in datbase", tableName);
                }
            }
            // TODO: Add address fixing feature as well
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return 0;
        }

        private static bool tableExists(string tablename)
        {
            if (tableList.Contains(tablename))
            {
                return true;
            }
            return false;
        }
    }
}

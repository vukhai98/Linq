using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkWithCvsFile
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> strCsv = File.ReadAllLines("Content\\Sample.csv"); // xem lại cách dẫn file
            var result = from str in strCsv
                         let tmp = str.Split(",").Skip(1).Select(s => Convert.ToInt32(s))
                         select new
                         {
                             Max = tmp.Max(),
                             Min = tmp.Min(),
                             Total = tmp.Sum(),
                             Agv = tmp.Average()

                         };
            var query = result.ToList();
            foreach (var item in query)
            {
                Console.WriteLine(
                    string.Format($"Maxxium: {item.Max} Minxium: {item.Min} Total: {item.Total} Average: {item.Agv}"));
            }
            Console.Read();
                      
        }
    }
}
 
using System;
using System.Collections.Generic;
using System.Linq;

namespace PartitioningOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> strList = new List<string>() { "Three", "One", "Two",  "Four", "Five","Six"};
            // Skip
            //var result = strList.Skip(2);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //// SkipWhile
            //var skipResult = strList.SkipWhile(s => s.Length < 4);
            //foreach (var str in skipResult)
            //{
            //    Console.WriteLine(str);
            //}
            // Take lấy ra 2 phần tử dầu tiên của danh sách
            //var result = strList.Take(2);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            // TakeWhile 
            //var result1 = strList.TakeWhile(s => s.Length > 4);
            //foreach (string str in result1)
            //{
            //    Console.WriteLine(str);
            //}
            // Thuật toán phân trang với skip và take 
            int page = 3;
            int pageSize = 2;
            var pageList = strList.Skip((page - 1) * pageSize).Take(pageSize);
            foreach (string str in pageList)
            {
                Console.WriteLine(str);
            }
            Console.ReadLine();
        }
    }
}

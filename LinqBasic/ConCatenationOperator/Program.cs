using System;
using System.Collections.Generic;
using System.Linq;

namespace ConCatenationOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> collection1 = new List<string>() { "One", "Two", "Three" };
            IList<string> collection2 = new List<string>() { "Four", "Five", "Six" };
            // Concat() dùng để nối 2 chuỗi cùng kiểu dữ liệu như phép sum lấy ra tất cả các phần tử trong danh sách
            var collection3 = collection1.Concat(collection2);
            foreach (string str in collection3)
            {
                Console.WriteLine(str);
            }
            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace GenerationOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> emtyList = new List<string>();
            var newList1 = emtyList.DefaultIfEmpty();
            var newList2 = emtyList.DefaultIfEmpty("None");
            Console.WriteLine("Cont: {0}",newList1.Count());
            Console.WriteLine("Value:{0}",newList1.ElementAt(0));

            Console.WriteLine("Cont: {0}", newList2.Count());
            Console.WriteLine("Value:{0}", newList2.ElementAt(0));
           
            // tạo ra 1 danh sách rỗng khi đếm số phần tử trả về 0 chứ không phải mặc định .
            var emtyCollection1 = Enumerable.Empty<string>();
            Console.WriteLine("Count: {0}", emtyCollection1.Count());
            // tạo ra 1 dãy số bắt đầu từ 10 và có 10 phần tử
            var intCollection = Enumerable.Range(10, 10);
            for (int i = 0; i < intCollection.Count(); i++)
            {
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));
            }
            // tạo ra 1 danh sách lặp lại 1 phần tử n lần 
            var intCollection2 = Enumerable.Repeat<string>("Hungry",2);
            for (int i = 0; i < intCollection2.Count(); i++)
            {
                Console.WriteLine("Value at index {0} : {1}", i, intCollection2.ElementAt(i));
            }
            Console.ReadKey();
            
        }
    }
}

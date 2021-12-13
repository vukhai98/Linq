using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };

            IList<string> strList = new List<string>() { "One", "Two", "Three", null, "Four", "Five" };
            // ElementAt chọn ra 1 phần tử ở vị trí index trong tập hợp không có sẽ báo lỗi
            Console.WriteLine(" 1st Element in intList: {0}", intList.ElementAt(0));
            Console.WriteLine(" 1st Element in stringList: {0}",strList.ElementAt(0));

            // ElementAtDefault chọn ra 1 phần tử ở vị trí index trong tập hợp không có sẽ trả về giá trị mặc định của kiểu dữ liệu.
            Console.WriteLine(" 1st Element in intList: {0} - default in value",intList.ElementAtOrDefault(9));
            Console.WriteLine(" 1st Element in strList: {0} - default in value",strList.ElementAtOrDefault(9));

            // Firt và kết hợp nhiều điều kiện
            Console.WriteLine(" 1st Element in intList: {0} ", intList.OrderByDescending(s=>s).First(i=>i % 2== 0));
            Console.WriteLine(" 1st Element in intList: {0} ", intList.OrderBy(s=>s).First(i=>i % 2== 0));
            // Last và LastOrDefault
            Console.WriteLine(" 1st Element in intList: {0} ", intList.OrderBy(s => s).LastOrDefault(i => i > 100)) ;
            // Single 
            IList<int>  oneElementList = new List<int>() { 7 };
            Console.WriteLine(" The only Element in onElementList: {0}", oneElementList.Single());
            Console.WriteLine(" The only Element intList: {0}", intList.Single(s => s > 50));


            Console.ReadLine();
        }
    }
}

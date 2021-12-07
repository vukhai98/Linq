using ExtensionMethods.Extensoins;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "43.35";
            //double data = text.ToDouble();
            //Console.WriteLine(data);
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee() {id = 1, name = "Vu Minh Khai"},
                new Employee() { id = 1, name = "Vu Minh Khai"},

            };
            //var enumerator = developers.GetEnumerator();
            //int count = 0;
            //while (enumerator.MoveNext())
            //{
            //    count++;

            //}
            Console.WriteLine(developers.Count());
            Console.ReadKey();
        }
    }
}

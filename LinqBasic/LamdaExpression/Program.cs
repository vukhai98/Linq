using System;
using System.Collections.Generic;
using System.Linq;

namespace LamdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee() {id = 1, name = "Vu Minh Khai"},
                new Employee() { id = 2, name = "Doan Minh Man"},

            };
            foreach (var employee in developers.Where(employee => employee.name.StartsWith("V")))
            {
                Console.WriteLine(employee.name);

            }
            Console.ReadLine();

        }
        public static bool NameStartWithV(Employee employee)
        {
            return employee.name.StartsWith("V"); 
        }
    }
}

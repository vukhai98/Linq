using System;
using System.Linq;
using System.Xml.Linq;

namespace WorkingWithXmlFile
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement XElement = XElement.Load("Content\\Employee.xml");
            var employess = from x in XElement.Elements("Employee")
                            let city = x.Element("Address")?.Element("City")
                            where (string)city== "Alta" 
                            orderby city descending
                            select x;
            foreach (var employee in employess)
            {
                Console.WriteLine(employee.Element("EmpId")?.Value);
                Console.WriteLine(employee.Element("Name")?.Value);
            }
            Console.ReadLine(); 
        }
    }
}

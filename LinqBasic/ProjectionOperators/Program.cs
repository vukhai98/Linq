using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectionOperators
{
    class Student
    {
        public int studentId { get; set; }
        public string studentName { get; set; }
        public int age { get; set; }
        public bool gender { get; set; }
    }
    public class Employee
    {
       public  string name;

        public int iD { get; set; }
        public List<Department> Departments { get; set; }
    }
    public class Department
    {
        public string name { get; set;  }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() {studentId= 1, studentName = "John",  age = 18, gender =true},
                new Student() {studentId= 2, studentName = "Steve", age = 21,gender =true},
                new Student() {studentId= 3, studentName = "Bill",  age = 18,gender =false},
                new Student() {studentId= 4, studentName = "Ram",   age = 20,gender =false},
                new Student() {studentId= 5, studentName = "Ron" ,  age = 21,gender =true}
            };
            // select of LINQ
            //var selectedResult = from s in studentList
            //                     select new
            //                     {
            //                         Name = (s.gender == true ? "Mr." : "Ms.") + s.studentName,
            //                         Age = s.age
            //                     };
            //var selectedResult = studentList.Select(s => new
            //{
            //    Name = (s.gender == true ? "Mr." : "Ms.") + s.studentName,
            //    Age = s.age

            //});
            //foreach (var item in selectedResult)
            //{
            //    Console.WriteLine("Student Name: {0}, Age: {1}", item.Name, item.Age);

            //}
            List<Employee> employees = new List<Employee>();
            employees.Add( new Employee
            {
                iD = 1,
                name = "Kapil",
                Departments = new List<Department>()
                {
                    new Department {name= "Advertisement"},
                    new Department {name= "Production"}
                }
            });
            employees.Add(new Employee
            {
                iD = 2,
                name = "Raj",
                Departments = new List<Department>()
                {
                    new Department {name= "Production"},
                    new Department {name= "Sales"}
                }
            });
            employees.Add(new Employee
            {
                iD = 3,
                name = "Ramesh",
                Departments = new List<Department>()
                {
                    new Department {name= "Production"},
                    new Department {name= "Sales"}
                }
            });
            var result = employees.SelectMany(s => s.Departments);
            foreach (var dept in result)
            {
                Console.WriteLine(dept.name);
            }
            Console.ReadLine();
        }
    }
}

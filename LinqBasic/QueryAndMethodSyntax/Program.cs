using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryAndMethodSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            // string collection
            IList<string> stringList = new List<string>()
            {
                "C# Tutorials",
                "VB.NET Tutorials",
                "Learn C++",
                "MVC Tutorials",
                "Java "
            };
            //LINQ syntax
            //var result = from s in stringList
            //             where s.Contains(value:"Tutorials")
            //             select s;
            // MethodSyntax 
            var result = stringList.Where(s => s.Contains("Tutorials"));
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
            IList<Student> studentList = new List<Student>()
            {
                new Student() {studentId= 1, studentName= "Vu Minh Khai",age = 13},
                new Student() {studentId= 2, studentName= "Nguyen Van A",age = 21},
                new Student() {studentId= 3, studentName= "Vu Van C",age = 18},
                new Student() {studentId= 4, studentName= "Masount Mount",age = 20},
                new Student() {studentId= 5, studentName= "Fank Lampard",age = 15}
            };
            // Method Syntax
            //var teenAgerStudent = studentList.Where(s => s.age > 12 && s.age < 20).ToList();
            // LINQ Syntax
            var teenAgerStudent = from s in studentList
                                  where s.age > 12 && s.age < 20
                                  select s;
            foreach (var s in teenAgerStudent)
            {
                Console.WriteLine(s.studentName);
            }
            Console.ReadKey();
            

        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace SortingOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() {studentId= 1, studentName = "John",  age = 13},
                new Student() {studentId= 2, studentName = "Steve", age = 21},
                new Student() {studentId= 3, studentName = "Bill",  age = 18},
                new Student() {studentId= 4, studentName = "Ram",   age = 20},
                new Student() {studentId= 5, studentName = "Ron" ,  age = 15}
            };
            // Query
            var oderByResult = from s in studentList
                               orderby s.studentName, s.age descending
                               select s;
            var oderByResult1 = studentList.OrderBy(s => s.studentName).ThenByDescending(s=>s.age);
            foreach (var s in oderByResult1)
            {
                Console.WriteLine(s.studentName);
            }
            Console.ReadLine();

        }
    }
}

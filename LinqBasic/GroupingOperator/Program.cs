using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupingOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() {studentId= 1, studentName = "John",  age = 18},
                new Student() {studentId= 2, studentName = "Steve", age = 21},
                new Student() {studentId= 3, studentName = "Bill",  age = 18},
                new Student() {studentId= 4, studentName = "Ram",   age = 20},
                new Student() {studentId= 5, studentName = "Ron" ,  age = 21}
            };
            // Query 
            //var groupResult = from s in studentList
            //                  group s by s.age;
            // Methods
            //var groupResult = studentList.GroupBy(s => s.age);
            var groupResult = studentList.ToLookup(s => s.age);
            foreach (var ageGroup in groupResult)
            {
                Console.WriteLine("Age: {0}", ageGroup.Key);
                foreach (var s in ageGroup)
                {
                    Console.WriteLine("StudentName: {0}", s.studentName);
                }
               
            }
            Console.ReadKey();
        }
    }
}

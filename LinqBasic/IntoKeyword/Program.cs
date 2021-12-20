using System;
using System.Collections.Generic;
using System.Linq;

namespace IntoKeyWord
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>() {
        new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
        new Student() { StudentID = 2, StudentName = "Steve",   Age = 15 } ,
        new Student() { StudentID = 3, StudentName = "Bill",   Age = 18 } ,
        new Student() { StudentID = 4, StudentName = "Ram" ,  Age = 12 } ,
        new Student() { StudentID = 5, StudentName = "Ron" ,  Age = 21 }
        };
            var teenAgerStudents = from s in studentList
                                   where s.Age > 12 && s.Age < 20
                                   select s
                                  into teenStudent
                                   where teenStudent.StudentName.StartsWith("B")
                                   select teenStudent;
            foreach (var student in teenAgerStudents)
            {
                Console.WriteLine("Name: {0} - Age:{1} ", student.StudentName, student.Age);

            }
            Console.ReadLine();
        }
    }
}

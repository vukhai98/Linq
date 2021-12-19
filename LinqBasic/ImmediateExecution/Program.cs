using System;
using System.Collections.Generic;
using System.Linq;

namespace ImmediateExecution
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
            IList<Student> teenAgerStudents = studentList.Where(s => s.Age > 12 && s.Age < 20).ToList();
            foreach (Student std in teenAgerStudents)
            {
                Console.WriteLine(std.StudentName);
            }
            Console.ReadLine();
        }

    }
}

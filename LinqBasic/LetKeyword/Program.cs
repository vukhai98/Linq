using System;
using System.Collections.Generic;
using System.Linq;

namespace LetKeyword
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
            var lowercaseStudentNames = from s in studentList
                                        let lowercaseStudentName = s.StudentName.ToLower()
                                        where lowercaseStudentName.StartsWith("r")
                                        select lowercaseStudentName;
            foreach (var item in lowercaseStudentNames)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();



        }
    }
}

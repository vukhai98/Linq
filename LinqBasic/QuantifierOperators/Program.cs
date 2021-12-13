using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantifierOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() {studentId= 1, studentName= "Vu Minh Khai",age = 13},
                new Student() {studentId= 2, studentName= "Nguyen Van A",age = 21},
                new Student() {studentId= 3, studentName= "Vu Van C",age = 18},
                new Student() {studentId= 4, studentName= "Masount Mount",age = 20},
                new Student() {studentId= 5, studentName= "Fank Lampard",age = 15}
            };
            Student std = new Student() { studentId = 3, studentName = "Vu Van C" };
            bool areAllStudentsTeenAger = studentList.All(s => s.age > 12 && s.age < 20);
            bool areAnyStudentsTeenAger = studentList.Any(s => s.age > 12 && s.age < 20);
            bool result = studentList.Contains(std,new StudentComparer());
            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}

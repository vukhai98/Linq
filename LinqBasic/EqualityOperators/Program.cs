using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EqualityOperators
{
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.studentId == y.studentId && x.studentName.ToLower()==y.studentName.ToLower())
            {
                return true;
            }
            return false;
        }

        public int GetHashCode( Student obj)
        {
            return obj.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            bool isEqual = strList1.SequenceEqual(strList2);// returns true
            Console.WriteLine(isEqual);
            Student std = new Student() { studentId = 1, studentName = "Bill" };
            IList<Student> studentList1 = new List<Student>() { std };
            IList<Student> studentList2 = new List<Student>() { std };
            bool studentEqual = studentList1.SequenceEqual(studentList2);// return true
            Student std1 = new Student() { studentId = 1, studentName = "Bill" };
            Student std2 = new Student() { studentId = 1, studentName = "Bill" };
            IList<Student> studentList3 = new List<Student>() { std1 };
            IList<Student> studentList4 = new List<Student>() { std2 };
            isEqual = studentList3.SequenceEqual(studentList4, new StudentComparer()); // return false
            IList<Student> studentList = new List<Student>()
            {
                new Student() {studentId= 1, studentName = "John",  age = 18},
                new Student() {studentId= 2, studentName = "Steve", age = 21},
                new Student() {studentId= 3, studentName = "Bill",  age = 18},
                new Student() {studentId= 4, studentName = "Ram",   age = 20},
                new Student() {studentId= 5, studentName = "Ron" ,  age = 21}
            };
            IList<Student> studentListB = new List<Student>()
            {
                new Student() {studentId= 1, studentName = "John",  age = 18},
                new Student() {studentId= 2, studentName = "Steve", age = 21},
                new Student() {studentId= 3, studentName = "Bill",  age = 18},
                new Student() {studentId= 4, studentName = "Ram",   age = 20},
                new Student() {studentId= 5, studentName = "Ron" ,  age = 21}
            };
            bool studentEquals = studentList.SequenceEqual(studentListB, new StudentComparer());
            Console.WriteLine(studentEquals);
            Console.ReadLine(); 




        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AggregationOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<String> strList = new List<String>() { "One", "Two", "Three", "For", "Five" };
            var commaSeparatedString = strList.Aggregate((s1, s2) => s1 + "-" + s2);
            Console.WriteLine(commaSeparatedString);
            //Console.ReadLine();

            IList<Student> studentList = new List<Student>()
            {
                new Student() {studentId= 1, studentName = "John",  age = 13},
                new Student() {studentId= 2, studentName = "Steve", age = 21},
                new Student() {studentId= 3, studentName = "Bill",  age = 18},
                new Student() {studentId= 4, studentName = "Ram",   age = 20},
                new Student() {studentId= 5, studentName = "Ron" ,  age = 15}
            };
            var commaSeparatedStudentName = studentList.Aggregate<Student, string>("Name: ", (str, s) => str += s.studentName + ",");
            Console.WriteLine(commaSeparatedStudentName);
            IList<int> intList = new List<int>() { 10, 20, 30 };
            var average = intList.Average();
            var sum = intList.Sum();
            var max = intList.Max();
            var min = intList.Min();
            Console.WriteLine("Average: {0}, Sum: {1}, Max: {2}, Min: {3}", average, sum, max, min);
            var averageAgeOfStudentResult = studentList.Average(s => s.age);
            Console.WriteLine(" Average Age Of Student : {0}", averageAgeOfStudentResult);
            var count = studentList.Count();
            Console.WriteLine(count);

            Console.ReadKey();

        }
    }
}

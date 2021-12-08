using FilteringOperator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FilteringOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() {studentId= 1, studentName = "Vu Minh Khai", age = 13},
                new Student() {studentId= 2, studentName = "Nguyen Van A", age = 21},
                new Student() {studentId= 3, studentName = "Vu Van C",     age = 18},
                new Student() {studentId= 4, studentName = "Masount Mount",age = 20},
                new Student() {studentId= 5, studentName = "Fank Lampard" ,age = 15}
            };
            //var result = studentList.Where(s => s.age > 12 ).Where(s=> s.age<20);
            IEnumerable<Student> teenAgerStudent = from s in studentList
                                                   where s.age > 12
                                                   where s.age < 20
                                                   select s;
            foreach (var i in teenAgerStudent)
            {
                Console.WriteLine(i.studentName);
            }
            // Oftype
            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { studentId = 1, studentName = "bill" });
            var stringResult = from s in mixedList.OfType<string>()
                               select s;
            foreach (var s in stringResult)
            {
                Console.WriteLine(s);
            }

            var intResult = from i in mixedList.OfType<int>()
                            select i;
            foreach (var i in intResult)
            {
                Console.WriteLine(i);
            }
            var studentResult = from a in mixedList.OfType<Student>()
                                select a;
            foreach (var a in studentResult)
            {
                Console.WriteLine(a.studentId + " " + a.studentName);
            }

            Console.ReadKey();



        }
    }
}

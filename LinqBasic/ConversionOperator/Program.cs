using System;
using System.Collections.Generic;

namespace ConversionOperator
{
    class Program
    {
        static void ReportTypeProperties<T>(T obj)
        {
            Console.WriteLine("Compile-time:{0}", typeof(T).Name);
            Console.WriteLine("Actual type:{0}", obj.GetType().Name);
        }    
        static void Main(string[] args)
        {
            Student[] studentArray = 
            {
                new Student() {studentId= 1, studentName = "John",  age = 18},
                new Student() {studentId= 2, studentName = "Steve", age = 21},
                new Student() {studentId= 3, studentName = "Bill",  age = 18},
                new Student() {studentId= 4, studentName = "Ram",   age = 20},
                new Student() {studentId= 5, studentName = "Ron" ,  age = 21}
            };
            ReportTypeProperties(studentArray);
            Console.ReadKey();
        }
    }
}

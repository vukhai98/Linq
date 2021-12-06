using System;
using System.Linq;
namespace LinqBasic
{
    class Student
    {
        public int studentId { get; set; }
        public string studenName { get; set; }
        public int age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Student[] studentArray =
            {
                new Student() {studentId = 1,studenName= "Jhon",age=18},
                new Student() {studentId = 2,studenName= "Steve",age=21},
                new Student() {studentId = 3,studenName= "Peter",age=25},
                new Student() {studentId = 4,studenName= "Mount",age=20},
                new Student() {studentId = 5,studenName= "Jame",age=31},
                new Student() {studentId = 6,studenName= "Thomas",age=19},
                new Student() {studentId = 7,studenName= "Ben",age=17},
            };
            //Student[] students = new Student[7];
            //int i = 0;
            //foreach (var student in studentArray)
            //{
            //    if (student.age > 12 && student.age<20)
            //    {
            //        students[i] = student;
            //        i++;

            //    }
            //}
            Student[] students = studentArray.Where(s => s.age > 12 && s.age < 20).ToArray(); 
            Console.WriteLine(" Total student have age from 12 to 20: " + students.Length);

            Console.ReadKey();
        }
    }
    
}

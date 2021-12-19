using System;
using System.Linq.Expressions;

namespace Expression
{
    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Func<Student, bool> isTeenAger = s => s.Age > 12 && s.Age < 20;
            Expression<Func<Student, bool>> isTeenAgerExpression = s => isTeenAger(s);
            Func<Student, bool> isTeenAgerComplied = isTeenAgerExpression.Compile();
            //Invoke
            bool result = isTeenAgerComplied(new Student(){ StudentId = 1, StudentName = "John", Age = 13 });
            Expression<Action<Student>> printStudentName = s => Console.WriteLine(s.StudentName);
        }
    }
}

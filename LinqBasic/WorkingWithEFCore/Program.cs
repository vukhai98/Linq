using System;
using System.Collections.Generic;
using WorkingWithEFCore.Models;
using System.Linq;

namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                //context.Courses.AddRange(new List<Course>()
                //{
                //    new Course() {CourseName = "Math"},
                //    new Course() {CourseName = "History"},

                //});
                //context.Students.AddRange(new List<Student>()
                //{
                //    new Student(){ CourseId= 1, StudentName="Bill"},
                //    new Student(){ CourseId= 2, StudentName="Peter"}
                //});
                //context.SaveChanges();
                //var students = from s in context.Students
                //              select s;
                //var query = context.Students.Where(x => x.CourseId == 1);
                //var students = from s in context.Students
                //               join c in context.Courses
                //               on s.CourseId equals c.CourseId
                //               select new
                //               {
                //                   StudentName = s.StudentName,
                //                   CourseName = c.CourseName,
                //               };
                var students = context.Students.
                    Join(context.Courses,
                    s => s.CourseId,
                    c => c.CourseId,
                    (s, c)=> new
                    {
                        StudentName = s.StudentName,
                        CourseName = c.CourseName,

                    });
                   
                foreach (var s in students)
                {
                    Console.WriteLine($"Student Name:{s.StudentName} CourseName: {s.CourseName}");
                }
                Console.ReadLine();
            }


        }
    }
}

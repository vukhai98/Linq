using EFCore_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new StudentDbContext())
            {
                dbContext.AddRange(new List<Course>()
                {
                    new Course(){CourseName= "SQL Basic"},
                    new Course(){CourseName= "CSharp Basic"}

                });
                dbContext.AddRange(new List<Student>() { 
                    new Student() {StudentName= "Bin",Age= 20,CourseId= 1},
                    new Student() {StudentName= "Bo",Age= 26,CourseId= 2},
                    new Student() {StudentName= "Pew",Age= 19,CourseId= 1},
                });

                dbContext.SaveChanges();
                var result = dbContext.Students
                                                .Join(dbContext.Courses,
                                                s => s.CourseId,
                                                c => c.CourseId,
                                                (s, c) => new {
                                                    Name = s.StudentName,
                                                    Courses = c.CourseName,
                                                });
                foreach (var item in result)
                {
                    Console.WriteLine($"Sudent name : {item.Name}  - Course name: {item.Courses} ");
                }
                Console.ReadLine();

            };

                
        }
    }
}

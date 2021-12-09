using System;
using System.Collections.Generic;
using System.Linq;

namespace JoiningOperator
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StandardID { get; set; }
    }

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region Example1
            //IList<string> strList1 = new List<string>()
            //{
            //        "One",
            //        "Two",
            //        "Three",
            //        "Four"
            //};

            //IList<string> strList2 = new List<string>()
            //{
            //        "One",
            //        "Two",
            //        "Five",
            //        "Six"
            //};
            //var joinResult = from str1 in strList1
            //                 join str2 in strList2 on str1 equals str2
            //                 select str1;
            //foreach (var s in joinResult)
            //{
            //    Console.WriteLine(s);
            //}
            //Console.ReadLine();
            #endregion
            // Student collection
            IList<Student> studentList = new List<Student>()
            {
            new Student() { StudentID = 1, StudentName = "John",  StandardID = 1 } ,
            new Student() { StudentID = 2, StudentName = "Steve",   StandardID = 1 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  StandardID = 2 } ,
            new Student() { StudentID = 4, StudentName = "Ram" ,  StandardID = 2 } ,
            new Student() { StudentID = 5, StudentName = "Ron"  }
            };

            IList<Standard> standardList = new List<Standard>()
            {
            new Standard(){ StandardID = 1, StandardName="Standard 1"},
            new Standard(){ StandardID = 2, StandardName="Standard 2"},
            new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };
            //var inerJoin = studentList.
            //    Join(standardList,
            //    student => student.StandardID,
            //    standar => standar.StandardID,
            //    (student, standar) => new
            //    {
            //        StudentName = student.StudentName,
            //        StandarName = standar.StandardName
            //    });
            #region Join Query
            //var inerJoin = from student in studentList
            //               join standar in standardList
            //               on student.StandardID equals standar.StandardID
            //               select new
            //               {
            //                   StudentName = student.StudentName,
            //                   StandarName = standar.StandardName
            //               };

            //foreach (var studet in inerJoin)
            //{
            //    Console.WriteLine("Student: {0} in class: {1}", studet.StudentName, studet.StandarName);
            //}
            //Console.ReadKey();
            #endregion
            #region Group join
            var groupJion = from std in standardList join s in studentList
                            on std.StandardID equals s.StandardID
                            into studentGroup
                            select new
                            {
                                Students = studentGroup,
                                StandarFullName = std.StandardName

                            };
            foreach (var item in groupJion)
            {
                Console.WriteLine(item.StandarFullName);
                foreach (var i in item.Students)
                {
                    Console.WriteLine(i.StudentName);

                }
            }
            Console.ReadKey();

            #endregion



        }
    }
}

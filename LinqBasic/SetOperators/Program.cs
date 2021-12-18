using System;
using System.Collections.Generic;
using System.Linq;

namespace SetOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Distinct 
            //IList<string> strList = new List<string>() { "One", "Two", "Three", "Two", "Three" };
            //var strListDistinct = strList.Distinct();
            //foreach (var item in strListDistinct)
            //{
            //    Console.WriteLine(item);

            //}
            //IList<Student> studentList = new List<Student>()
            //{
            //    new Student() {StudentId= 1, StudentName = "John",  Age = 18},
            //    new Student() {StudentId= 2, StudentName = "Steve", Age = 21},
            //    new Student() {StudentId= 3, StudentName = "Bill",  Age = 18},
            //    new Student() {StudentId= 3, StudentName = "Bill",  Age = 18},
            //    new Student() {StudentId= 3, StudentName = "Bill",  Age = 18},
            //    new Student() {StudentId= 4, StudentName = "Ram",   Age = 20},
            //    new Student() {StudentId= 5, StudentName = "Ron" ,  Age = 21}
            //};
            //var studentDictinct = studentList.Distinct(new StudentComparer());
            ////var studentDictinct = studentList.DistinctBy(x => x.studentId);
            //foreach (Student std in studentDictinct)
            //{
            //    Console.WriteLine(std.StudentName);
            //}
            #endregion 
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() {  "Four", "Five" , "Six","Seven","Eight"};
            // Except Lấy ra 1 cái trong strList1 mà không có trong strList 2
            //var result = strList1.Except(strList2);
            //foreach (string str in result)
            //{
            //    Console.WriteLine(str);
            //}
            // Intersect lấy ra phân tử chung của 2 danh sách
            //var resultIntersect = strList2.Intersect(strList1);
            //foreach (var item in resultIntersect)
            //{
            //    Console.WriteLine(item);
            //}
            // Union nối 2 bảng với nhau  có phần tử giống nhau sẽ lấy 1 cái chung
            var result = strList1.Union(strList2);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }


    }

    public static class LinqHelper
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
    (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}

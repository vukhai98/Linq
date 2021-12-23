using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_3.Models
{
   public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
       
        public int  Age { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}

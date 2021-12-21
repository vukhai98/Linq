using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFCore.Models
{
    public partial class Students
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string StudentName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeesListEFDbFisrt.Models
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }

        [Display(Name = "Type of Skill")]
        public string Title { get; set; }
    }
}


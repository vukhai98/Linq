using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesListEFDbFisrt.Models
{
    class EmloyeeContext: DbContext
    {
        public EmloyeeContext(DbContextOptions<EmloyeeContext> options) : base(options)
        {

        }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

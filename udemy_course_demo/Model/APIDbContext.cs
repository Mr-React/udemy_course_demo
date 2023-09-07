using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_course_demo.Model
{
    public class APIDbContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PersonDetail> PersonDetails { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=NewAPIDB;Integrated Security=True");
        }
    }
}

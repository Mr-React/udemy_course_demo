﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_course_demo.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [ForeignKey("Position")]
        public int PositionId { get; set; }

        public Position Position { get; set; }

        [ForeignKey("Salary")]
        public int SalaryId { get; set; }

        public Salary Salary { get; set; }

       public virtual PersonDetail PersonDetail { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_course_demo.Model
{
    public class Department
    {
        public Department()
        {
            Positions = new HashSet<Position>();
        }
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}

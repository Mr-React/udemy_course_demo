using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_course_demo.Model
{
    public class PersonDetail
    {
        [Key]
        public int Id { get; set; }
        public string PersonCity { get; set; }

        public DateTime Birthday { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}

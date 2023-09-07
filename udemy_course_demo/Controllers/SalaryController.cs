using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using udemy_course_demo.Model;

namespace udemy_course_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var db = new APIDbContext();
            var list = db.Salaries.ToList();
            return Ok(list);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteSalary(int Id)
        {
            var db = new APIDbContext();
            Salary sal = db.Salaries.Find(Id);
            if (sal == null)
                return NotFound();
            else
            {
                db.Salaries.Remove(sal);
                db.SaveChanges();
                return NoContent();
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetSalary(int Id)
        {
            var db = new APIDbContext();
            var sal = db.Salaries.Find(Id);

            if (sal == null)
                return NotFound();
            else
                return Ok(sal);
        }

        [HttpPost]
        public IActionResult AddSalary(Salary sal)
        {
            if (ModelState.IsValid)
            {
                var db = new APIDbContext();
                db.Salaries.Add(sal);
                db.SaveChanges();
                return Created("New Salary is Added", sal);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateSalary(Salary sal)
        {
            if (ModelState.IsValid)
            {
                var db = new APIDbContext();
                Salary salary = db.Salaries.Find(sal.SalaryId);
                salary.Amount = sal.Amount;
                db.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }

    }
}

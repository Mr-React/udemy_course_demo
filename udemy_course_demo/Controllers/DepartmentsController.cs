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
    public class DepartmentsController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetDepartments()
        {
            var db = new APIDbContext();
            var list = db.Departments.ToList();
            return Ok(list);
        }

        [HttpGet("{Id}")]
        public IActionResult GetDepartment(int Id)
        {
            var db = new APIDbContext();
            var dept = db.Departments.Find(Id);

            if (dept == null)
                return NotFound();
            else
                return Ok(dept);
        }

        [HttpPost]
        public IActionResult AddDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                var db = new APIDbContext();
                db.Departments.Add(dept);
                db.SaveChanges();
                return Created("New Department is created",dept);
            }
            return BadRequest();   
        }

        [HttpPut]
        public IActionResult UpdateDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                var db = new APIDbContext();
                Department UpdateDepartment = db.Departments.Find(dept.DepartmentId);
                UpdateDepartment.DepartmentName = dept.DepartmentName;
                db.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }

    }
}

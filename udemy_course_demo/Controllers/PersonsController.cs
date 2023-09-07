using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using udemy_course_demo.Model;

namespace udemy_course_demo.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPersons()
        {
            var db = new APIDbContext();
            //var list = db.Persons.Include(x => x.Salary).Include(x => x.Position).ToList();
            //var list = db.Persons.ToList();
            var list = db.Persons.Include(x => x.Salary).Include(x => x.Position)
                    .ThenInclude(x => x.Department)
                    .Select(x => new PersonALL()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        PositionName = x.Position.Name,
                        Salary = x.Salary.Amount,
                        DepartmentName = x.Position.Department.DepartmentName,
                        PersonCity = x.PersonDetail.PersonCity
                    }).ToList();
            return Ok(list);
        }

        [HttpGet("{Id}")]

        public IActionResult GetPerson(int id)
        {
            var db = new APIDbContext();
            var person = db.Persons.FirstOrDefault(x => x.Id == id);

            if (person == null)
                return NotFound();
            else
                return Ok(person);
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                var db = new APIDbContext();
                db.Persons.Add(person);
                db.SaveChanges();
                return Created("New User is created",person);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdatePerson(Person per)
        {
            if (ModelState.IsValid)
            {
                var db = new APIDbContext();
                Person person = db.Persons.Find(per.Id);
                person.Address = per.Address;
                person.Age = per.Age;
                person.Email = per.Email;
                person.Name = per.Name;
                person.Password = per.Password;
                person.PositionId = per.PositionId;
                person.SalaryId = per.SalaryId;
                person.Surname = per.Surname;
                db.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            string filename = Guid.NewGuid().ToString() + file.FileName;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + filename);
            FileStream stream = new FileStream(filepath, FileMode.Create);
            await file.CopyToAsync(stream);
            return Created("", null);
        }

    }
}

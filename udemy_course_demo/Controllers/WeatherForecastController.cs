using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using udemy_course_demo.Model;

namespace udemy_course_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            using (APIDbContext db = new APIDbContext())
            {
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
                Person person = db.Persons.Find(1);

                //Update Department Name
                //Department dept = db.Departments.Find(1);
                //dept.DepartmentName = "Department1Update";
                //db.SaveChanges();

                //Delete cell from salary table
                //Salary sal = db.Salaries.Find(4);
                //db.Salaries.Remove(sal);
                //db.SaveChanges();

                //var list = db.Persons.Include(x => x.Salary).Include(x=>x.Position).ToList();

                //var list = db.Persons.ToList();
                //Person person = db.Persons.Find(1);

                //Create/Add data in Department table
                //Department dept = new Department();
                //dept.DepartmentName = "Department2";
                //db.Departments.Add(dept);
                //db.SaveChanges();
            }
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

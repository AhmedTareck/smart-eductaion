using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("Api/Web/Students")]
    public class StudentsController : Controller
    {
        private readonly SmartEducationContext db;
        private Helper help;
        public StudentsController(SmartEducationContext context)
        {
            this.db = context;
            help = new Helper();
        }

        
        [HttpGet("GetStudents")]
        public IActionResult GetStudents()
        {
            try
            {
                var userId = help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return BadRequest(" You need to login to access this page");
                }

                IQueryable<Students> StudentsQuery;
                StudentsQuery = from p in db.Students
                                where p.Status == 1
                                select p;

                var StudentList = (from p in StudentsQuery
                                   orderby p.CreatedOn descending
                                   select new
                                   {
                                       Name = p.FirstName,
                                       FatherName = p.FatherName,
                                       GrandFatherName = p.GrandFatherName,
                                       SurName = p.SurName,
                                       FullName = p.FirstName+" "+p.FatherName+" "+p.GrandFatherName+" "+p.SurName,
                                       StudentId = p.Id
                                       
                                   }).ToList();

                return Ok(new { Students = StudentList });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }





    }
}
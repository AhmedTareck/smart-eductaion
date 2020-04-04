using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/web/StudentProfile")]
    public class StudentProfileController : Controller
    {
        private readonly SmartEducationContext db;
        private Helper help;
        public StudentProfileController(SmartEducationContext context)
        {
            this.db = context;
            help = new Helper();
        }

        [HttpGet("GetStudentProfile")]
        public IActionResult GetStudent()
        {
            try
            {
                var userId = help.GetCurrentUser(HttpContext);
                Console.WriteLine(userId);
                if (userId <= 0)
                {
                    return BadRequest(" You need to login to access this page");
                }

                var Student = (from p in db.Students
                                   where p.Id == userId
                                   select p).ToList();
                
                return Ok(new { student = Student});
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }   
        }
    }
}
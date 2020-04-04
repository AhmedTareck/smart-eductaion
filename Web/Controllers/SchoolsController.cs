using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("Api/Web/Schools")]
    public class SchoolsController : Controller
    {
        private readonly SmartEducationContext db;
        private Helper help;
        public SchoolsController(SmartEducationContext context)
        {
            this.db = context;
            help = new Helper();
        }


        [AllowAnonymous]
        [HttpGet("GetAllSchools")]
        public IActionResult GetAllSchools()
        {
            try
            {
                IQueryable<Schools> SchoolsQuery;
                SchoolsQuery = from p in db.Schools
                               where p.Status == 1
                               select p;

                var SchoolsList = (from p in SchoolsQuery
                                   orderby p.CreatedOn descending
                                   select new Schools
                                   {
                                       Name = p.Name,
                                       Id = p.Id,
                                   }).ToList();

                return Ok(new { Schools = SchoolsList });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


    }
}
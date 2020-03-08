using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managegment.Controllers;
using Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    [Produces("application/json")]
    [Route("api/MobileQueries")]
    public class MobileQueriesController : Controller
    {

        private readonly StudentTrackerContext db;
        private Helper help;
        public MobileQueriesController(StudentTrackerContext context)
        {
            this.db = context;
            help = new Helper();
        }

        [HttpGet("GetStudent")]
        public IActionResult GetStudent()
        {
            try
            {

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



    }
}
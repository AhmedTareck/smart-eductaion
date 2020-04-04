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
    [Route("Api/Web/AcadimacYears")]
    public class AcadimacYearsController : Controller
    {
        private readonly SmartEducationContext db;
        private Helper help;
        public AcadimacYearsController(SmartEducationContext context)
        {
            this.db = context;
            help = new Helper();
        }

        [AllowAnonymous]
        [HttpGet("GetAllAcadimacYears")]
        public IActionResult GetAllAcadimacYears()
        {
            try
            {
                IQueryable<AcadimacYears> AcadimacYearsQuery;
                AcadimacYearsQuery = from p in db.AcadimacYears
                               where p.Status == 1
                               select p;

                var AcadimacYearsList = (from p in AcadimacYearsQuery
                                         orderby p.CreatedOn descending
                                   select new Schools
                                   {
                                       Name = p.Name,
                                       Id = p.Id,
                                   }).ToList();

                return Ok(new { AcadimacYears = AcadimacYearsList });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



    }
}
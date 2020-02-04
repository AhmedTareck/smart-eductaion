using Managegment.objects;
using Management.Models;
using Management.objects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managegment.Controllers
{
    [Produces("application/json")]
    [Route("Api/Admin/HomeWorck")]   
    public class HomeWorckController : Controller
    {
        private Helper help;

        private readonly StudentTrackerContext db;

        public HomeWorckController(StudentTrackerContext context)
        {
            this.db = context;
            help = new Helper();
        }

        [HttpGet("GetHomeWorck")]
        public IActionResult GetHomeWorck(int pageNo, int pageSize, long YearId,long eventId)
        {
            try
            {
                var HomeWorcks = from p in db.HomeWorcks
                                  where p.Status != 9
                                  select p;

                if (YearId != 0)
                {
                    HomeWorcks = from p in HomeWorcks where p.Event.YearId == YearId select p;
                }

                if(eventId !=0)
                {
                    HomeWorcks = from p in HomeWorcks where p.EventId == eventId select p;
                }

                var Count = (from p in HomeWorcks select p).Count();

                var HomeWorcksList = (from p in HomeWorcks
                                    orderby p.CreatedOn descending
                                    select new
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        Disctiption = p.Disctiption,
                                        LastDayDilavary=p.LastDayDilavary,
                                        CreatedOn=p.CreatedBy,
                                    }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { presness = HomeWorcksList, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult AddHomeWorck([FromBody] HomeWorckObject selectedHomeWorck)
        {
            try
            {

                if (selectedHomeWorck == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var HomeWorck = new HomeWorcks();

                HomeWorck.EventId = selectedHomeWorck.eventId;
                HomeWorck.Name = selectedHomeWorck.name;
                HomeWorck.Disctiption = selectedHomeWorck.disctiption;
                HomeWorck.LastDayDilavary = selectedHomeWorck.lastDayDilavary;
                HomeWorck.CreatedBy = userId;
                HomeWorck.CreatedOn = DateTime.Now;
                HomeWorck.Status = 1;
                db.HomeWorcks.Add(HomeWorck);
                db.SaveChanges();

                return Ok("لقد قمت بتسـجيل بيانات الواجب الدراسي  بنــجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Edit")]
        public IActionResult EditHomeWorck([FromBody] HomeWorckObject selectedHomeWorck)
        {
            try
            {

                if (selectedHomeWorck == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var HomeWorck = (from p in db.HomeWorcks where p.Id == selectedHomeWorck.id select p).SingleOrDefault();

                if(HomeWorck==null)
                {
                    return StatusCode(401, "لم يتم العتور علي الواجب الدراسي الرجاء التأكد من البيانات");
                }

                HomeWorck.Name = selectedHomeWorck.name;
                HomeWorck.Disctiption = selectedHomeWorck.disctiption;
                HomeWorck.LastDayDilavary = selectedHomeWorck.lastDayDilavary;
                db.SaveChanges();

                return Ok("لقد قمت بتعديل بيانات الواجب الدراسي  بنــجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{id}/delteHomeWorck")]
        public IActionResult delteHomeWorck(long id)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var HomwWorck = (from p in db.HomeWorcks where p.Id == id select p).SingleOrDefault();

                if (HomwWorck == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
                }

                HomwWorck.Status = 9;

                db.SaveChanges();

                return Ok("تم حدف الواجب لدراسي بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}

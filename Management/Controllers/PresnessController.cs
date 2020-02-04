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
    [Route("Api/Admin/Presness")]   
    public class PresnessController : Controller
    {
        private Helper help;

        private readonly StudentTrackerContext db;

        public PresnessController(StudentTrackerContext context)
        {
            this.db = context;
            help = new Helper();
        }

        [HttpGet("GetPresness")]
        public IActionResult GetPresness(int pageNo, int pageSize, int EventId)
        {
            try
            {
                var GetPresness = from p in db.Presness
                                  where p.Status != 9
                                  select p;

                if (EventId != 0)
                {
                    GetPresness = from p in db.Presness where p.EventId == EventId select p;
                }


                //1 active 
                // 2 not
                var Count = (from p in GetPresness select p).Count();

                var PresnessList = (from p in GetPresness
                                   orderby p.CreatedOn descending
                                    select new
                                   {
                                       id=p.Id,
                                       year=p.Event.Year.Name,
                                       EventGroup = p.Event.EventGroup,
                                       studentCount = (from q in db.StudentEvents where q.EventId == p.EventId && p.Status != 9 select p).Count(),
                                       activeStudent = (from q in db.PresnessInfo where q.PresnessId==p.Id && p.Status==1 select p).Count(),
                                       notActiveStudent = (from q in db.PresnessInfo where q.PresnessId==p.Id && p.Status==2 select p).Count(),
                                       LectureDate = p.LectureDate,
                                       note=p.Note,
                                       createdon=p.CreatedOn,
                                   }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { presness = PresnessList, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult addPresness([FromBody] PresnessObject presness)
        {
            try
            {

                if (presness == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء التأكد من إدخال جميع البيانات ");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var Presness = (from p in db.Presness where p.EventId == presness.EventSelectd && p.LectureDate == presness.LectureDate && p.Status!=9 select p).SingleOrDefault();
                
                if(Presness!=null)
                {
                    return StatusCode(401, "تم تسجيل الحضور لهذا اليوم مسبقا الرجاء التأكد من الإدخال");
                }

                Presness = new Presness();
                Presness.LectureDate = presness.LectureDate;
                Presness.Note = presness.LectureDate.ToString();
                Presness.CreatedBy = userId;
                Presness.CreatedOn = DateTime.Now;
                Presness.Status = 1;
                Presness.EventId = presness.EventSelectd;
                db.Presness.Add(Presness);


                foreach (Students item in presness.Students)
                {
                    PresnessInfo presnessInfo = new PresnessInfo();
                    presnessInfo.PresnessId = Presness.Id;
                    presnessInfo.StudentId = item.StudentId;
                    if(item.FirstName=="true")
                    {
                        presnessInfo.Status = 1;
                    }
                    else
                    {
                        presnessInfo.Status = 0;
                    }
                    db.PresnessInfo.Add(presnessInfo);
                }

                db.SaveChanges();

                return Ok("تمت عملية تسجيل الحضور والإنصراف بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{id}/deltePresness")]
        public IActionResult deltePresness(long id)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var presness = (from p in db.Presness where p.Id == id select p).SingleOrDefault();

                if (presness ==null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
                }

                presness.Status = 9;

                var presnessInfo = (from p in db.PresnessInfo where p.PresnessId == id select p).ToList();

                foreach(PresnessInfo item in presnessInfo)
                {
                    item.Status = 9;
                }

                db.SaveChanges();

                return Ok("تم حدف السجل بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetPresnessInfo")]
        public IActionResult GetPresnessInfo(long id)
        {
            try
            {
                var GetPresnessInfo = from p in db.PresnessInfo
                                  where p.PresnessId==id && p.Status != 9 
                                  select p;

                //1 active 
                // 0 not
                var PresnessList = (from p in GetPresnessInfo
                                    orderby p.Status descending
                                    select new
                                    {
                                        id = p.PresnessInfoId,
                                        year = p.Presness.Event.Year.Name,
                                        EventGroup = p.Presness.Event.EventGroup,
                                        Name=p.Student.FirstName+' '+p.Student.FatherName+' '+p.Student.GrandFatherName+' '+p.Student.SurName,
                                        status=p.Status,
                                        editStatus=p.Status==1 ? true : false
                                    }).ToList();

                return Ok(new { student = PresnessList});
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("editPresness")]
        public IActionResult editPresness([FromBody] PresnessObject presness)
        {
            try
            {

                if (presness == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var Presness = (from p in db.Presness where p.Id == presness.presnessId select p).SingleOrDefault();

                if (Presness == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل الرجاء إعادة المحاولة");
                }


                Presness.LectureDate = presness.LectureDate;

                foreach (EditpresnessObject item in presness.edit)
                {
                    var presnessinfo = (from p in db.PresnessInfo where p.PresnessInfoId == item.id select p).SingleOrDefault();
                    if(presnessinfo!=null)
                    {
                        if(item.editStatus)
                        {
                            presnessinfo.Status = 1;
                        }
                        else
                        {
                            presnessinfo.Status = 0;
                        }
                    }
                    db.PresnessInfo.Update(presnessinfo);
                }

                db.SaveChanges();

                return Ok("تمت عملية تعديل بيانات الحضور والإنصراف بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

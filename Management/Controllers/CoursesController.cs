using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managegment.Controllers;
using Management.Models;
using Management.objects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.Controllers
{
    [Produces("application/json")]
    [Route("Api/Admin/Courses")]
    public class CoursesController : Controller
    {

        private readonly StudentTrackerContext db;
        private Helper help;
        public CoursesController(StudentTrackerContext context)
        {
            this.db = context;
            help = new Helper();
        }

        [HttpGet("Get")]
        public IActionResult Get(int pageNo, int pageSize)
        {
            try
            {
                var GetYears = from p in db.AcadimacYears
                                 where p.Status != 9
                                 select p;

                var Count = (from p in GetYears select p).Count();

                
                return Ok(new { Years = GetYears, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetEvents")]
        public IActionResult GetEvents(int yearId)
        {
            try
            {
                var GetEvents = from p in db.Events
                               where p.Status != 9 && p.AcadimecYearId==yearId
                               select p;

                return Ok(new { Events = GetEvents});
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getSubject")]
        public IActionResult getSubject(int yearId)
        {
            try
            {
                var subject = from p in db.Subjects
                                where p.Status != 9 && p.AcadimecYearId == yearId
                                select p;

                return Ok(new { Subject = subject });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getSubjectExama")]
        public IActionResult getSubjectExama(int id)
        {
            try
            {
                var exams = from p in db.Exams
                              where p.Status != 9 && p.SubjectId == id
                              select p;

                return Ok(new { Exams = exams });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("AddSkedjule")]
        public IActionResult AddSkedjule([FromBody] SkedjuleObj skedjule)
        {
            try
            {

                if (skedjule == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var SkedjuleExist = (from p in db.Skedjule where p.EventId == skedjule.EventSelectd select p).ToList();

                if (SkedjuleExist.Count!=0)
                {
                    return StatusCode(401, "تم إضافة الجدول الدراسي لهدا الفصل");
                }

                for (int i = 1; i <= 6; i++)
                {
                    switch (i)
                    {
                        case 1:
                            {
                                for (int j = 1; j <= 7; j++)
                                {
                                    
                                    switch (j)
                                    {
                                        case 1:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.SubjectId = skedjule.satrdayOne;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedBy = userId;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 2:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.satrdaytwo;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 3:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.satrdayTree;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 4:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.satrdayFour;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 5:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.satrdayFive;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 6:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.satrdaySex;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 7:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.satrdaySeven;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        default:
                                            break;
                                    }
                                    
                                }
                                
                                break;
                            };
                        case 2:
                            {
                                for (int j = 1; j <= 7; j++)
                                {
                                    switch (j)
                                    {
                                        case 1:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.sunOne;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 2:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.suntwo;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 3:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.sunTree;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 4:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.sunFour;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 5:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.sunFive;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 6:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.sunSex;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 7:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.sunSeven;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        default:
                                            break;
                                    }

                                }

                                break;
                            };
                        case 3:
                            {
                                for (int j = 1; j <= 7; j++)
                                {
                                    switch (j)
                                    {
                                        case 1:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.mOne;
                                                db.Skedjule.Add(Skedjule);

                                                break;
                                            }
                                        case 2:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.mtwo;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 3:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.mTree;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 4:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.mFour;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 5:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.mFive;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 6:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.mSex;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 7:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.mSeven;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        default:
                                            break;
                                    }

                                }

                                break;
                            };
                        case 4:
                            {
                                for (int j = 1; j <= 7; j++)
                                {
                                    switch (j)
                                    {
                                        case 1:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.TuOne;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 2:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.Tutwo;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 3:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.TuTree;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 4:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.TuFour;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 5:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.TuFive;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 6:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.TuSex;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 7:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.TuSeven;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        default:
                                            break;
                                    }

                                }

                                break;
                            };
                        case 5:
                            {
                                for (int j = 1; j <= 7; j++)
                                {
                                    switch (j)
                                    {
                                        case 1:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.ThOne;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 2:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.Thtwo;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 3:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.ThTree;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 4:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.ThFour;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 5:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.ThFive;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 6:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.ThSex;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 7:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.ThSeven;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        default:
                                            break;
                                    }

                                }

                                break;
                            };
                        case 6:
                            {
                                for (int j = 1; j <= 7; j++)
                                {
                                    switch (j)
                                    {
                                        case 1:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.wOne;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 2:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.wtwo;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 3:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.wTree;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 4:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.wFour;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 5:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.wFive;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 6:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.wSex;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        case 7:
                                            {
                                                var Skedjule = new Skedjule();
                                                Skedjule.Day = short.Parse(i.ToString());
                                                Skedjule.EventId = skedjule.EventSelectd;
                                                Skedjule.LectureNumber = short.Parse(j.ToString());
                                                Skedjule.CreatedOn = DateTime.Now;
                                                Skedjule.SubjectId = skedjule.wSeven;
                                                db.Skedjule.Add(Skedjule);
                                                break;
                                            }
                                        default:
                                            break;
                                    }

                                }

                                break;
                            };

                        default:
                            break;
                    }

                    db.SaveChanges();
                    
                }


                return Ok("لقد قمت بتسـجيل بيانات الجدول  بنــجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("GetSkedjules")]
        public IActionResult GetSkedjules(int pageNo, int pageSize, int EventId)
        {
            try
            {
                //var GetSkedjule = from p in db.Skedjule
                //                  where p.Status != 9
                //                  select p;
                var GetSkedjule = from p in db.Skedjule group p by p.EventId into g select new { code = g.Key, count = g.Count() };

                if (EventId != 0)
                {
                    GetSkedjule = from p in db.Skedjule where p.EventId==EventId group p by p.EventId into g select new { code = g.Key, count = g.Count() };
                }


                //1 active 
                // 2 not
                var Count = (from p in GetSkedjule select p).Count();

                var SkedjuleList = (from p in GetSkedjule
                                    
                                    select new
                                    {
                                        id = p.code,
                                        Group=(from q in db.Events where p.code==q.EventId select q.EventGroup).SingleOrDefault(),
                                        year =(from q in db.Events where p.code == q.EventId select q.AcadimecYear.Name).SingleOrDefault(),

                                    }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { Skedjules = SkedjuleList, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetSkedjuleInfo")]
        public IActionResult GetSkedjuleInfo(long EventId)
        {
            try
            {
                
                var GetSkedjule = (from p in db.Skedjule where p.EventId == EventId select p).ToList();


                var SkedjuleList = (from p in GetSkedjule

                                    select new
                                    {
                                        Subject=(from q in db.Subjects where q.SubjectId==p.SubjectId select q.Name).SingleOrDefault(),
                                        Day= p.Day,
                                        LectureNumber = p.LectureNumber,

                                    }).ToList();


                return Ok(new { Skedjules = SkedjuleList});
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{id}/delteSkedjule")]
        public IActionResult delteSkedjule(long id)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var Skedjule = (from p in db.Skedjule where p.EventId == id select p).ToList();

                if (Skedjule == null)
                {
                    return StatusCode(401, "لم يتم العتور علي الجدول ربما تم مسحه مسبقا");
                }

                db.Skedjule.RemoveRange(Skedjule);

                db.SaveChanges();

                return Ok("تم حدف الجدول بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetYearsInfo")]
        public IActionResult GetYearsInfo(int pageNo, int pageSize)
        {
            try
            {
                var YearInof = from p in db.Years where p.Status!=9 select p;

                var Count = (from p in YearInof select p).Count();

                var YearInfo = (from p in YearInof

                                    select new
                                    {
                                        id=p.YearId,
                                        name=p.Name,
                                        createdOn=p.CreatedBy,
                                        createdBy=p.CreatedOn
                                    }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { years = YearInfo, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{id}/deleteYears")]
        public IActionResult delteHomeWorck(long id)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var Year = (from p in db.Years where p.YearId == id select p).SingleOrDefault();

                if (Year == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
                }

                Year.Status = 9;

                db.SaveChanges();

                return Ok("تم حدف السنة الدراسية بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}

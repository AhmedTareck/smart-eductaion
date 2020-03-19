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

        private readonly Tranim_LearningContext db;
        private Helper help;
        public CoursesController(Tranim_LearningContext context)
        {
            this.db = context;
            help = new Helper();
        }

        [HttpPost("addyearName")]
        public IActionResult addyearName([FromBody] YearsObject form)
        {
            try
            {

                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var Years = (from p in db.AcadimacYears where p.Name == form.name select p).SingleOrDefault();

                if (Years != null)
                {
                    return StatusCode(401, "الاسم موجود مسبقا");
                }

                AcadimacYears year = new AcadimacYears();
                year.Name = form.name;
                year.Status = 1;
                year.CreatedBy = userId;
                year.CreatedOn = DateTime.Now;
                db.AcadimacYears.Add(year);
                db.SaveChanges();

                return Ok("تمت عملية الاضافة بنجاح");
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
                var YearInof = from p in db.AcadimacYears where p.Status != 9 select p;

                var Count = (from p in YearInof select p).Count();

                var YearInfo = (from p in YearInof
                                orderby p.CreatedOn descending
                                select new
                                {
                                    id = p.Id,
                                    name = p.Name,
                                    createdOn = p.CreatedBy,
                                    createdBy = p.CreatedOn
                                }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { years = YearInfo, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("edityearName")]
        public IActionResult edityearName([FromBody] YearsObject form)
        {
            try
            {

                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var Years = (from p in db.AcadimacYears where p.Id == form.id select p).SingleOrDefault();

                if (Years == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل الرجاء التأكد من البيانات");
                }

                Years.Name = form.name;
                db.SaveChanges();

                return Ok("لقد قمت بتعديل بيانات السنة الدراسية  بنــجاح");
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

                var Year = (from p in db.AcadimacYears where p.Id == id select p).SingleOrDefault();

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

        [HttpGet("getyearName")]
        public IActionResult getyearName()
        {
            try
            {
                var YearInof = from p in db.AcadimacYears where p.Status != 9 select p;

                var YearInfo = (from p in YearInof
                                orderby p.CreatedOn descending
                                select new
                                {
                                    id = p.Id,
                                    name = p.Name,
                                }).ToList();

                return Ok(new { years = YearInfo });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("GetSubjectInfo")]
        public IActionResult GetSubjectInfo(int pageNo, int pageSize, int id)
        {
            try
            {
                var subjects = from p in db.Subjects where p.Status != 9 select p;

                if (id != 0)
                {
                    subjects = from p in subjects where p.AcadimecYearId == id select p;
                }

                var Count = (from p in subjects select p).Count();

                var subjectInfo = (from p in subjects
                                   orderby p.CreatedOn descending
                                   select new
                                   {
                                       id = p.Id,
                                       name = p.Name,
                                       yearName = p.AcadimecYear.Name,
                                       createdOn = p.CreatedOn
                                   }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { Subjects = subjectInfo, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{id}/deleteSubject")]
        public IActionResult deleteSubject(long id)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var subject = (from p in db.Subjects where p.Id == id select p).SingleOrDefault();

                if (subject == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
                }

                subject.Status = 9;

                db.SaveChanges();

                return Ok("تم حدف السنة الدراسية بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("addSubject")]
        public IActionResult addSubject([FromBody] YearsObject form)
        {
            try
            {

                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var subjectCheck = (from p in db.AcadimacYears where p.Name == form.name select p).SingleOrDefault();

                if (subjectCheck != null)
                {
                    return StatusCode(401, "الاسم موجود مسبقا");
                }

                Subjects subject = new Subjects();
                subject.Name = form.name;
                subject.AcadimecYearId = int.Parse(form.id.ToString());
                subject.Status = 1;
                subject.CreatedBy = userId;
                subject.CreatedOn = DateTime.Now;
                db.Subjects.Add(subject);
                db.SaveChanges();

                return Ok("تمت عملية الاضافة بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("editsubjectname")]
        public IActionResult editsubjectname([FromBody] YearsObject form)
        {
            try
            {

                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var subject = (from p in db.Subjects where p.Id == form.id select p).SingleOrDefault();

                if (subject == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل الرجاء التأكد من البيانات");
                }

                subject.Name = form.name;
                db.SaveChanges();

                return Ok("لقد قمت بتعديل بيانات المادة الدراسية  بنــجاح");
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

        [HttpPost("addShapter")]
        public IActionResult addShapter([FromBody] YearsObject form)
        {
            try
            {

                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var subjectCheck = (from p in db.Shapters where p.Name == form.name && p.SubjectId == form.SubjectId select p).SingleOrDefault();

                if (subjectCheck != null)
                {
                    return StatusCode(401, "الاسم موجود مسبقا");
                }

                Shapters Shapter = new Shapters();
                Shapter.Name = form.name;
                Shapter.SubjectId = form.SubjectId;
                Shapter.Number = form.ShapterNumber;
                Shapter.Status = 1;
                Shapter.CreatedBy = userId;
                Shapter.CreatedOn = DateTime.Now;
                db.Shapters.Add(Shapter);
                db.SaveChanges();

                return Ok("تمت عملية الاضافة بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getShpater")]
        public IActionResult getShpater(int pageNo, int pageSize, long subjectId)
        {
            try
            {
                var Shapters = from p in db.Shapters where p.Status != 9 select p;

                if (subjectId != 0)
                {
                    Shapters = from p in Shapters where p.SubjectId == subjectId select p;
                }

                var Count = (from p in Shapters select p).Count();

                var ShpaterInfo = (from p in Shapters
                                   orderby p.CreatedOn descending
                                   select new
                                   {
                                       id = p.Id,
                                       name = p.Name,
                                       SubjectId = p.SubjectId,
                                       Number = p.Number,
                                       createdOn = p.CreatedOn
                                   }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { shapter = ShpaterInfo, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("editShpter")]
        public IActionResult editShpter([FromBody] YearsObject form)
        {
            try
            {

                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var Shpagter = (from p in db.Shapters where p.Id == form.id select p).SingleOrDefault();

                if (Shpagter == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل الرجاء التأكد من البيانات");
                }

                Shpagter.Name = form.name;
                db.SaveChanges();

                return Ok("تمت عملية التعديل بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{id}/delteShpter")]
        public IActionResult delteShpter(long id)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var subject = (from p in db.Shapters where p.Id == id select p).SingleOrDefault();

                if (subject == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
                }

                subject.Status = 9;

                db.SaveChanges();

                return Ok("تت عملية الحدف بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("addPost")]
        public IActionResult addPost([FromBody] postObject post)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                if (post == null)
                {
                    return StatusCode(401, "حدتت مشكلة في ارسال البيانات");
                }

                Ads ads = new Ads();
                ads.Image = Convert.FromBase64String(post.Photo.Substring(post.Photo.IndexOf(",") + 1));
                ads.Subject = post.subject;
                ads.Post = post.post;
                ads.CreatedOn = DateTime.Now;
                ads.CreatedBy = userId;
                ads.Status = post.status;
                db.Ads.Add(ads);

                db.SaveChanges();
                return Ok("تمت عملية الإضافة بنجاح ");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("GetAds")]
        public IActionResult GetAds(int pageNo, int pageSize)
        {
            try
            {
                var adds = from p in db.Ads where p.Status != 9 select p;


                var Count = (from p in adds select p).Count();

                var AdsInfo = (from p in adds
                                   orderby p.CreatedOn descending
                                   select new
                                   {
                                       id = p.Id,
                                       Subject = p.Subject,
                                       Post = p.Post,
                                       Status = p.Status,
                                       createdOn = p.CreatedOn
                                   }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { adss = AdsInfo, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}/image")]
        public IActionResult GetdegreageImage(long id)
        {
            try
            {
                var ads = (from p in db.Ads
                               where p.Id == id
                               select p.Image).SingleOrDefault();

                if (ads == null)
                {
                    return NotFound("الصورة غير موجــود");
                }

                return File(ads, "image/jpeg");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{id}/deleteAds")]
        public IActionResult deleteAds(long id)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var ads = (from p in db.Ads where p.Id == id select p).SingleOrDefault();

                if (ads == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
                }

                ads.Status = 9;

                db.SaveChanges();

                return Ok("تمت عملية الحدف بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getDetals")]
        public IActionResult getDetals()
        {
            try
            {

                var StudentCount = (from p in db.Users where p.Status ==3 select p).Count();
                var LectureCount = (from p in db.Lectures where p.Status != 9 select p).Count();
                // var homeWorckCount = (from p in db where p.Status != 9 select p).Count();
                var AdsCount = (from p in db.Ads where p.Status != 9 select p).Count();
                var LastSudent = (from p in db.Users where p.Status==3 select p).OrderByDescending(p => p.UserId).Select(x => new { x.Name , x.Phone, x.LoginName, x.Gender,x.Email }).Take(5).ToList();
                //var LastSubScribtions = (from p in db.ShoortNumber select p).OrderByDescending(p => p.Id).Select(x => new { x.Code, x.Service, x.Amount, x.Smscount, x.UsageSms }).Take(5).ToList();

                var Detalss = new
                {
                    StudentCount = StudentCount,
                    LectureCount = LectureCount,
                    AdsCount = AdsCount,
                    LastSudent = LastSudent
                };


                return Ok(new { Detals = Detalss });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}

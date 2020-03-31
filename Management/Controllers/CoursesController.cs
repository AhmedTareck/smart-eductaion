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

        private readonly SmartEducationContext db;
        private Helper help;
        public CoursesController(SmartEducationContext context)
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

                var shaptersheck = (from p in db.Shapters where p.Name == form.name && p.EventId== form.EventId select p).SingleOrDefault();

                if (shaptersheck != null)
                {
                    return StatusCode(401, "الشابتر موجود مسبقا");
                }

                Shapters Shapter = new Shapters();
                Shapter.Name = form.name;
                Shapter.EventId = form.SubjectId;
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
        public IActionResult getShpater(int pageNo, int pageSize)
        {
            try
            {
                var Shapters = from p in db.Shapters where p.Status != 9 select p;


                var Count = (from p in Shapters select p).Count();

                var ShpaterInfo = (from p in Shapters
                                   orderby p.CreatedOn descending
                                   select new
                                   {
                                       id = p.Id,
                                       name = p.Name,
                                       EventName = p.Event.Name,
                                       Number = p.Number,
                                       subject=p.Event.Subject.Name,
                                       subjectId=p.Event.SubjectId,
                                       year=p.Event.Subject.AcadimecYear.Name,
                                       yeaIdr=p.Event.Subject.AcadimecYearId,
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
                Shpagter.Number = form.ShapterNumber;
                Shpagter.EventId = form.EventId;
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

                var shapter = (from p in db.Shapters where p.Id == id select p).SingleOrDefault();

                if (shapter == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
                }

                shapter.Status = 9;

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

        [HttpGet("getTeatcherName")]
        public IActionResult getTeatcherName()
        {
            try
            {
                var teatsher = from p in db.Users where p.State ==5 select p;

                var tetshers = (from p in teatsher
                                orderby p.CreatedOn descending
                                select new
                                {
                                    id = p.Id,
                                    name = p.Name,
                                }).ToList();

                return Ok(new { teacher = tetshers });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        public class EventObj
        {
            public long? Id { get; set; }
            public long TeacherId { get; set; }
            public long SubjectId { get; set; }
            public string Name { get; set; }
            public string Discreptions { get; set; }
        }

        [HttpPost("addEvent")]
        public IActionResult addEvent([FromBody] EventObj form)
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

                var EventCheck = (from p in db.Events where p.Name == form.Name select p).SingleOrDefault();

                if (EventCheck != null)
                {
                    return StatusCode(401, "الاسم موجود مسبقا");
                }

                Events Event = new Events();
                Event.Name = form.Name;
                Event.TeacherId = form.TeacherId;
                Event.SubjectId = form.SubjectId;
                Event.Discreptions = form.Discreptions;
                Event.Status = 1;
                Event.CreatedBy = userId;
                Event.CreatedOn = DateTime.Now;
                db.Events.Add(Event);
                db.SaveChanges();

                return Ok("تمت عملية الاضافة بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getEventInfo")]
        public IActionResult getEventInfo(int pageNo, int pageSize)
        {
            try
            {
                var Events = from p in db.Events where p.Status != 9 select p;


                var Count = (from p in Events select p).Count();

                var EventInfo = (from p in Events
                               orderby p.CreatedOn descending
                               select new
                               {
                                   id = p.Id,
                                   Name = p.Name,
                                   Subject = p.Subject.Name,
                                   SubjectId = p.SubjectId,
                                   TeacherId = p.TeacherId,
                                   Teacher = p.Teacher.Name,
                                   yearId=p.Subject.AcadimecYearId,
                                   Discreptions = p.Discreptions,
                                   createdOn = p.CreatedOn
                               }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { eventinfo = EventInfo, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("editEvent")]
        public IActionResult editEvent([FromBody] EventObj form)
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

                Events Event = (from p in db.Events where p.Id == form.Id select p).SingleOrDefault();

                if (Event == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
                }

                Event.Name = form.Name;
                Event.TeacherId = form.TeacherId;
                Event.SubjectId = form.SubjectId;
                Event.Discreptions = form.Discreptions;
                Event.ModifiedBy = userId;
                Event.ModifiedOn = DateTime.Now;
                db.SaveChanges();

                return Ok("تمت عملية التعديل بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{id}/delteEvent")]
        public IActionResult delteEvent(long id)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var item = (from p in db.Events where p.Id == id select p).SingleOrDefault();

                if (item == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
                }

                item.Status = 9;

                db.SaveChanges();

                return Ok("تمت عملية الحدف بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getEventName")]
        public IActionResult getEventName(long id)
        {
            try
            {
                var Events = from p in db.Events where p.SubjectId==id select p;



                var EventInfo = (from p in Events
                                 orderby p.CreatedOn descending
                                 select new
                                 {
                                     id = p.Id,
                                     Name = p.Name,
                                 }).ToList();

                return Ok(new { eventinfo = EventInfo});
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //[HttpGet("getDetals")]
        //public IActionResult getDetals()
        //{
        //    try
        //    {

        //        var StudentCount = (from p in db.Users where p.Status == 3 select p).Count();
        //        var LectureCount = (from p in db.Lectures where p.Status != 9 select p).Count();
        //        // var homeWorckCount = (from p in db where p.Status != 9 select p).Count();
        //        var AdsCount = (from p in db.Ads where p.Status != 9 select p).Count();
        //        var LastSudent = (from p in db.Users where p.Status == 3 select p).OrderByDescending(p => p.UserId).Select(x => new { x.Name, x.Phone, x.LoginName, x.Gender, x.Email }).Take(5).ToList();
        //        //var LastSubScribtions = (from p in db.ShoortNumber select p).OrderByDescending(p => p.Id).Select(x => new { x.Code, x.Service, x.Amount, x.Smscount, x.UsageSms }).Take(5).ToList();

        //        var Detalss = new
        //        {
        //            StudentCount = StudentCount,
        //            LectureCount = LectureCount,
        //            AdsCount = AdsCount,
        //            LastSudent = LastSudent
        //        };


        //        return Ok(new { Detals = Detalss });
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        [HttpGet("getShapterName")]
        public IActionResult getShapterName(long id)
        {
            try
            {
                var shpter = from p in db.Shapters where p.Status != 9 && p.EventId==id select p;

                var shpterInfo = (from p in shpter
                                  orderby p.CreatedOn descending
                                  select new
                                  {
                                      id = p.Id,
                                      name = p.Name,
                                  }).ToList();

                return Ok(new { shapterNames = shpterInfo });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //[HttpPost("addExam")]
        //public IActionResult addExam([FromBody] ExamObj obj)
        //{
        //    try
        //    {
        //        if (obj == null)
        //        {
        //            return StatusCode(401, "حدتت مشكلة في ارسال البيانات");
        //        }

        //        var userId = this.help.GetCurrentUser(HttpContext);

        //        if (userId <= 0)
        //        {
        //            return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
        //        }


        //        var examExist = (from p in db.Exams where p.Name == obj.Name select p).SingleOrDefault();

        //        if (examExist != null)
        //        {
        //            return StatusCode(401, "إسم الإختبار موجود مسبقا");
        //        }

        //        if (obj.QuestionsObj.Count == 0)
        //        {
        //            return StatusCode(401, "حدتت مشكلة في ارسال البيانات");
        //        }

        //        int marck = 0;

        //        foreach (var item in obj.QuestionsObj)
        //        {
        //            marck += item.Points;
        //        }

        //        if (marck != obj.FullMarck)
        //        {
        //            return StatusCode(401, "مجموع الدرجات لا يساوي الدرجة النهائية الرجاء التأكد من البيانات");
        //        }

        //        Exams exams = new Exams();
        //        exams.Name = obj.Name;
        //        exams.Number = obj.Number;
        //        exams.Lenght = obj.Lenght;
        //        exams.FullMarck = obj.FullMarck;
        //        exams.CreatedBy = userId;
        //        exams.CreatedOn = DateTime.Now;
        //        exams.Status = 1;
        //        db.Exams.Add(exams);

        //        var questionsList = new List<Questions>();

        //        foreach (QuestionsObj item in obj.QuestionsObj)
        //        {
        //            questionsList.Add(new Questions
        //            {
        //                Number = item.Number,
        //                Points = item.Points,
        //                Question = item.Question,
        //                Answer = item.Answer,
        //                A1 = item.A1,
        //                A2 = item.A2,
        //                A3 = item.A3,
        //                A4 = item.A4,
        //                Status = 1,
        //            });

        //        }

        //        exams.Questions = questionsList;

        //        db.SaveChanges();
        //        return Ok("تمت عملية الإضافة بنجاح ");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }

        //}

        //[HttpGet("GetExamingInfo")]
        //public IActionResult GetExamingInfo(int pageNo, int pageSize)
        //{
        //    try
        //    {
        //        var Examing = from p in db.Exams where p.Status != 9 select p;


        //        var Count = (from p in Examing select p).Count();

        //        var examingInfo = (from p in Examing
        //                           orderby p.CreatedOn descending
        //                           select new
        //                           {
        //                               id = p.Id,
        //                               Name = p.Name,
        //                               Number = p.Number,
        //                               FullMarck = p.FullMarck,
        //                               Lenght = p.Lenght,
        //                               CreatedOn = p.CreatedOn
        //                           }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

        //        return Ok(new { exams = examingInfo, count = Count });
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        //[HttpPost("{id}/DeleteExaming")]
        //public IActionResult DeleteExaming(long id)
        //{
        //    try
        //    {
        //        var userId = this.help.GetCurrentUser(HttpContext);

        //        if (userId <= 0)
        //        {
        //            return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
        //        }

        //        var Exam = (from p in db.Exams where p.Id == id select p).SingleOrDefault();

        //        if (Exam == null)
        //        {
        //            return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
        //        }

        //        Exam.Status = 9;

        //        db.SaveChanges();

        //        return Ok("تمت عملية الحدف بنجاح");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        [HttpGet("getLectures")]
        public IActionResult getLectures(int pageNo, int pageSize, long id)
        {
            try
            {
                var LecturesInfo = from p in db.Lectures where p.Status != 9 select p;

                if (id != 0)
                {
                    LecturesInfo = from p in LecturesInfo where p.ShaptersId == id select p;
                }

                var Count = (from p in LecturesInfo select p).Count();

                var LectureInfo = (from p in LecturesInfo
                                   orderby p.CreatedOn descending
                                   select new
                                   {
                                       id = p.Id,
                                       Name = p.Name,
                                       Number = p.Number,
                                       Description = p.Description,
                                       CreatedOn = p.CreatedOn
                                   }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { lectures = LectureInfo, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{id}/deletelecture")]
        public IActionResult deletelecture(long id)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var lecture = (from p in db.Lectures where p.Id == id select p).SingleOrDefault();

                if (lecture == null)
                {
                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
                }

                lecture.Status = 9;

                db.SaveChanges();

                return Ok("تمت عملية الحدف بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost("addLecture")]
        public IActionResult addLecture([FromBody] LectureObject form)
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

                Lectures lectures = new Lectures();
                lectures.ShaptersId = form.shapterSelected;
                lectures.Name = form.Name;
                lectures.Number = form.Number;
                lectures.Description = form.decreption;
                lectures.VideoPath = form.Video;
                lectures.CreatedOn = DateTime.Now;
                lectures.CreatedBy = userId;
                lectures.Status = 1;

                List<LectureFiles> lectureFiles = new List<LectureFiles>();


                foreach (var item in form.Photo)
                {
                    LectureFiles lectureImage = new LectureFiles();
                    lectureImage.AttashmentFile = Convert.FromBase64String(item.FileBase64.Substring(item.FileBase64.IndexOf(",") + 1));
                    lectureImage.Status = 1;
                    lectureFiles.Add(lectureImage);
                }

                foreach (var item in form.attashFile)
                {
                    LectureFiles lectureImage = new LectureFiles();
                    lectureImage.LectureId = lectures.Id;
                    lectureImage.AttashmentFile = Convert.FromBase64String(item.FileBase64.Substring(item.FileBase64.IndexOf(",") + 1));
                    lectureImage.Status = 2;
                    lectureFiles.Add(lectureImage);
                }

                foreach (var item in form.sound)
                {
                    LectureFiles lectureImage = new LectureFiles();
                    lectureImage.LectureId = lectures.Id;
                    lectureImage.AttashmentFile = Convert.FromBase64String(item.FileBase64.Substring(item.FileBase64.IndexOf(",") + 1));
                    lectureImage.Status = 3;
                    lectureFiles.Add(lectureImage);
                }

                lectures.LectureFiles = lectureFiles;
                db.Lectures.Add(lectures);
                db.SaveChanges();



                return Ok("تمت عملية الاضافة بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Years_Add", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }

                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
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
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Years_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
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
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Years_Edit", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
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
                var perm = this.help.getPermissin("Years_Delete", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
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
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Years_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
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
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Subjects_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                } 
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
                var perm = this.help.getPermissin("Subjects_Delete", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
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
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Subjects_Add", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
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
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Subjects_Edit", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
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
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Subjects_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
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

        //[HttpPost("addShapter")]
        //public IActionResult addShapter([FromBody] YearsObject form)
        //{
        //    try
        //    {

        //        if (form == null)
        //        {
        //            return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
        //        }

        //        var userId = this.help.GetCurrentUser(HttpContext);

        //        if (userId <= 0)
        //        {
        //            return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
        //        }

        //        var subjectCheck = (from p in db.Shapters where p.Name == form.name && p.SubjectId == form.SubjectId select p).SingleOrDefault();

        //        if (subjectCheck != null)
        //        {
        //            return StatusCode(401, "الاسم موجود مسبقا");
        //        }

        //        Shapters Shapter = new Shapters();
        //        Shapter.Name = form.name;
        //        Shapter.SubjectId = form.SubjectId;
        //        Shapter.Number = form.ShapterNumber;
        //        Shapter.Status = 1;
        //        Shapter.CreatedBy = userId;
        //        Shapter.CreatedOn = DateTime.Now;
        //        db.Shapters.Add(Shapter);
        //        db.SaveChanges();

        //        return Ok("تمت عملية الاضافة بنجاح");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        //[HttpGet("getShpater")]
        //public IActionResult getShpater(int pageNo, int pageSize, long subjectId)
        //{
        //    try
        //    {
        //        var Shapters = from p in db.Shapters where p.Status != 9 select p;

        //        if (subjectId != 0)
        //        {
        //            Shapters = from p in Shapters where p.SubjectId == subjectId select p;
        //        }

        //        var Count = (from p in Shapters select p).Count();

        //        var ShpaterInfo = (from p in Shapters
        //                           orderby p.CreatedOn descending
        //                           select new
        //                           {
        //                               id = p.Id,
        //                               name = p.Name,
        //                               SubjectId = p.SubjectId,
        //                               Number = p.Number,
        //                               createdOn = p.CreatedOn
        //                           }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

        //        return Ok(new { shapter = ShpaterInfo, count = Count });
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        //[HttpPost("editShpter")]
        //public IActionResult editShpter([FromBody] YearsObject form)
        //{
        //    try
        //    {

        //        if (form == null)
        //        {
        //            return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
        //        }

        //        var userId = this.help.GetCurrentUser(HttpContext);

        //        if (userId <= 0)
        //        {
        //            return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
        //        }

        //        var Shpagter = (from p in db.Shapters where p.Id == form.id select p).SingleOrDefault();

        //        if (Shpagter == null)
        //        {
        //            return StatusCode(401, "لم يتم العتور علي السجل الرجاء التأكد من البيانات");
        //        }

        //        Shpagter.Name = form.name;
        //        db.SaveChanges();

        //        return Ok("تمت عملية التعديل بنجاح");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        //[HttpPost("{id}/delteShpter")]
        //public IActionResult delteShpter(long id)
        //{
        //    try
        //    {
        //        var userId = this.help.GetCurrentUser(HttpContext);

        //        if (userId <= 0)
        //        {
        //            return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
        //        }

        //        var subject = (from p in db.Shapters where p.Id == id select p).SingleOrDefault();

        //        if (subject == null)
        //        {
        //            return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
        //        }

        //        subject.Status = 9;

        //        db.SaveChanges();

        //        return Ok("تت عملية الحدف بنجاح");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

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
                var perm = this.help.getPermissin("Ads_Add", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
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
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Ads_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }

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
            {var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Ads_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }

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
                var perm = this.help.getPermissin("Ads_Delete", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
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

        //[HttpGet("getShapterName")]
        //public IActionResult getShapterName(long id)
        //{
        //    try
        //    {
        //        var shpter = from p in db.Shapters where p.Status != 9 && p.SubjectId == id select p;

        //        var shpterInfo = (from p in shpter
        //                          orderby p.CreatedOn descending
        //                          select new
        //                          {
        //                              id = p.Id,
        //                              name = p.Name,
        //                          }).ToList();

        //        return Ok(new { shapterNames = shpterInfo });
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        [HttpPost("addExam")]
        public IActionResult addExam([FromBody] Exams exam)
        {
            try
            {
                
                    var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Exams_Add", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
                if (exam == null)
                {
                    return StatusCode(401, "حدتت مشكلة في ارسال البيانات");
                }

                

                if (string.IsNullOrEmpty(exam.Name))
                {
                    return StatusCode(401, "يجب إدخال إسم الإمتحان");
                }

                if (string.IsNullOrWhiteSpace(exam.Name))
                {
                    return StatusCode(401, "يجب إدخال إسم الإمتحان");
                }

                //var eventExist = (from p in db.Exams where p.EventId == exam.EventId select p.Name).SingleOrDefault();
                //if (eventExist != null){
                //    var examExist = (from p in db.Exams where p.Name == exam.Name select p).SingleOrDefault();
                //    if (examExist != null)
                //    {
                //        return StatusCode(401, "إسم الإختبار موجود مسبقا");
                //    }
                //}
               

               

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                if (exam.Status == 1)
                {
                    if (exam.SubjectId <= 0)
                    {
                        return StatusCode(401, "الرجاء إختيار المادة الدراسية");
                    }
                }
                else if (exam.Status == 2)
                {
                    if (exam.EventId <= 0)
                    {
                        return StatusCode(401, "الرجاء إختيار الكورس");
                    }

                }

                if (exam.Number < 0)
                {
                    return StatusCode(401, "الرجاء إختيار رقم الإختبار");
                }

                int marck = 0;

                foreach (var item in exam.Questions)
                {
                    marck += (int)item.Points;
                }

                if (marck != exam.FullMarck)
                {
                    return StatusCode(401, "مجموع الدرجات لا يساوي الدرجة النهائية الرجاء التأكد من البيانات");
                }

                Exams exams = new Exams
                {
                    Name = exam.Name,
                    Number = exam.Number,
                    SubjectId = exam.SubjectId,
                    EventId = exam.EventId,
                    Length = exam.Length,
                    FullMarck = exam.FullMarck,
                    CreatedBy = userId,
                    CreatedOn = DateTime.Now,
                    Status = exam.Status
                };
               db.Exams.Add(exams);

                var questionsList = new List<Questions>();

                foreach (Questions item in exam.Questions)
                {
                    var question = new Questions
                    {

                        ExamId = exam.Id,
                        Question = item.Question,
                        Number = item.Number,
                        Points = item.Points,
                        CreatedBy = userId,
                        CreatedOn = DateTime.Now,

                        Status = item.Status,
                    };
                  

                    var answersList = new List<Answers>();
                    foreach (Answers answers in item.Answers)
                       
                        answersList.Add(new Answers
                        {
                            ExamAnswers = answers.ExamAnswers,
                            CreatedBy = userId,
                            CreatedOn = DateTime.Now
                        });
                    question.Answers = answersList;

                    questionsList.Add(question);
                }

                exams.Questions = questionsList;
              

                db.SaveChanges();
                return Ok("تمت عملية الإضافة بنجاح ");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.InnerException.Message);
            }

        }

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

        //[HttpGet("getLectures")]
        //public IActionResult getLectures(int pageNo, int pageSize, long id)
        //{
        //    try
        //    {
        //        var LecturesInfo = from p in db.Lectures where p.Status != 9 select p;

        //        if (id != 0)
        //        {
        //            LecturesInfo = from p in LecturesInfo where p.ShaptersId == id select p;
        //        }

        //        var Count = (from p in LecturesInfo select p).Count();

        //        var LectureInfo = (from p in LecturesInfo
        //                           orderby p.CreatedOn descending
        //                           select new
        //                           {
        //                               id = p.Id,
        //                               Name = p.Name,
        //                               Number = p.Number,
        //                               Description = p.Description,
        //                               CreatedOn = p.CreatedOn
        //                           }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

        //        return Ok(new { lectures = LectureInfo, count = Count });
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        //[HttpPost("{id}/deletelecture")]
        //public IActionResult deletelecture(long id)
        //{
        //    try
        //    {
        //        var userId = this.help.GetCurrentUser(HttpContext);

        //        if (userId <= 0)
        //        {
        //            return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
        //        }

        //        var lecture = (from p in db.Lectures where p.Id == id select p).SingleOrDefault();

        //        if (lecture == null)
        //        {
        //            return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
        //        }

        //        lecture.Status = 9;

        //        db.SaveChanges();

        //        return Ok("تمت عملية الحدف بنجاح");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}


        //[HttpPost("addLecture")]
        //public IActionResult addLecture([FromBody] LectureObject form)
        //{
        //    try
        //    {

        //        if (form == null)
        //        {
        //            return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
        //        }

        //        var userId = this.help.GetCurrentUser(HttpContext);

        //        if (userId <= 0)
        //        {
        //            return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
        //        }

        //        Lectures lectures = new Lectures();
        //        lectures.ShaptersId = form.shapterSelected;
        //        lectures.Name = form.Name;
        //        lectures.Number = form.Number;
        //        lectures.Description = form.decreption;
        //        lectures.VideoFile = form.Video;
        //        lectures.CreatedOn = DateTime.Now;
        //        lectures.CreatedBy = userId;
        //        lectures.Status = 1;

        //        List<LectureFiles> lectureFiles = new List<LectureFiles>();


        //        foreach (var item in form.Photo)
        //        {
        //            LectureFiles lectureImage = new LectureFiles();
        //            lectureImage.AttashmentFile = item.FileBase64;
        //            lectureImage.Type = 1;
        //            lectureFiles.Add(lectureImage);
        //        }

        //        foreach (var item in form.attashFile)
        //        {
        //            LectureFiles lectureImage = new LectureFiles();
        //            lectureImage.LectureId = lectures.Id;
        //            lectureImage.AttashmentFile = item.FileBase64;
        //            lectureImage.Type = 2;
        //            lectureFiles.Add(lectureImage);
        //        }

        //        foreach (var item in form.sound)
        //        {
        //            LectureFiles lectureImage = new LectureFiles();
        //            lectureImage.LectureId = lectures.Id;
        //            lectureImage.AttashmentFile = item.FileBase64;
        //            lectureImage.Type = 3;
        //            lectureFiles.Add(lectureImage);
        //        }
        //        lectures.LectureFiles = lectureFiles;
        //        db.Lectures.Add(lectures);
        //        db.SaveChanges();



        //        return Ok("تمت عملية الاضافة بنجاح");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}


        [HttpGet("getEvents")]
        public IActionResult getEvents()
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Events_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
                var selectedEvents = (from e in db.Events
                                      select new { e.Id, e.Name }).ToList();
                if (selectedEvents == null || selectedEvents.Count <= 0)
                {

                    return StatusCode(401, "لا يوجد أي كورس مسجلة");
                }



                return Ok(selectedEvents);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getAcadmeicYears")]
        public IActionResult getAcadmeicYears()
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Years_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }

                var selectedAcadmeicYears = (from ay in db.AcadimacYears
                                             select new { ay.Id, ay.Name}).ToList();


                if (selectedAcadmeicYears.Count == 0 || selectedAcadmeicYears == null)
                {
                    return StatusCode(401, "لا يوجد أي سنة دراسية مسجلة");
                }


                return Ok(selectedAcadmeicYears);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getSubjects")]
        public IActionResult getSubjectsBasedOnAcadmeicYearId([FromQuery] int academicYearId)
        {
            try
            {

                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Subjects_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
                var selectedSubjects = (from s in db.Subjects where s.AcadimecYearId == academicYearId
                                        select new { s.Id, s.Name }).ToList();


                if (selectedSubjects.Count == 0 || selectedSubjects == null)
                {
                    return StatusCode(401, "لا يوجد أي مادة مسجلة تحت هذه السنة");
                }


                return Ok(selectedSubjects);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("fetchCourses")]
        public IActionResult getLectures([FromQuery] int eventId)
        {
            // var selectedEvent =  (from e in db.Events join s in db.Shapters on e.Id equals s.EventId  where e.Id == eventId  select e.Shapters ).ToList();

            try
            {
                var selectedEvent = (from e in db.Events join s in db.Shapters on e.Id equals s.EventId into eventShapter where e.Id == eventId select new { id = e.Id, course = e.Name, chapters = eventShapter.Select(es => new { title = es.Name, lectures = es.Lectures.Select(sl => new { id = sl.Id, title = sl.Name, videoUrl = sl.VideoPath, fileUrl = sl.LectureFiles.Select(lf => new { id = lf.Id, lf.AttashmentFile, lf.Status }) }) }) }).ToList();

                if (selectedEvent == null || selectedEvent.Count == 0)
                    return StatusCode(401, "هذا الكورس مسجل");

                return Ok(selectedEvent);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.InnerException.Message);
            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Managegment.Controllers;
//using Management.Models;
//using Management.objects;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace CMS.Controllers
//{
//    [Produces("application/json")]
//    [Route("Api/Admin/Notifi")]
//    public class NotificationController : Controller
//    {

//        private readonly Tranim_LearningContext db;
//        private Helper help;
//        public NotificationController(Tranim_LearningContext context)
//        {
//            this.db = context;
//            help = new Helper();
//        }

//        public class Notifi
//        {
//            public short type { get; set; }
//            public string notifecation { get; set; }
//            public long? userId { get; set; }
//        }

//        [HttpPost("AddNotifi")]
//        public IActionResult AddNotifi([FromBody] Notifi notifi)
//        {
//            try
//            {

//                if (notifi == null)
//                {
//                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
//                }

//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                Notifications notifications = new Notifications();
//                notifications.Status = notifi.type;
//                notifications.Notification = notifi.notifecation;
//                notifications.CreatedBy = userId;
//                notifications.CreatedOn = DateTime.Now;
//                db.Notifications.Add(notifications);

//                var notificationDelivarys = new List<NotificationDelivary>();

//                var userList = (from p in db.Users where p.State != 9 select p).ToList();
//                foreach (Users item in userList)
//                {
//                    notificationDelivarys.Add(new NotificationDelivary
//                    {
//                        Status = 1,
//                        UserId = item.UserId

//                    });

//                }
//                notifications.NotificationDelivary = notificationDelivarys;

//                db.SaveChanges();


//                return Ok("لقد قمت بإرسال الإشعار  بنــجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }


//        [HttpGet("GetNotifi")]
//        public IActionResult GetSkedjules(int pageNo, int pageSize)
//        {
//            try
//            {
//                var GetNotifi = (from p in db.Notifications where p.Status != 9 select p).ToList();


//                var Count = (from p in GetNotifi select p).Count();

//                var Notificatios = (from p in GetNotifi
//                                    orderby p.CreatedOn descending
//                                    select new
//                                    {
//                                        Id = p.Id,
//                                        Notification = p.Notification,
//                                        TypeNotification = (
//                                            p.Status == 1 ? "واجب دراسي" :
//                                            p.Status == 2 ? "إختبار" :
//                                            p.Status == 3 ? "رسالة " :
//                                            p.Status == 4 ? "تنبيه " : "تعميم"),
//                                        CreatedOn = p.CreatedOn,
//                                        CreatedBy = (from q in db.Users where q.UserId == p.CreatedBy select q.Name)


//                                    }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

//                return Ok(new { notif = Notificatios, count = Count });
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpPost("AddUserNotifi")]
//        public IActionResult AddUserNotifi([FromBody] Notifi notifi)
//        {
//            try
//            {

//                if (notifi == null)
//                {
//                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
//                }

//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                Notifications notifications = new Notifications();
//                notifications.Status = notifi.type;
//                notifications.Notification = notifi.notifecation;
//                notifications.CreatedBy = userId;
//                notifications.CreatedOn = DateTime.Now;
//                db.Notifications.Add(notifications);

//                NotificationDelivary notificationDelivary = new NotificationDelivary();
//                notificationDelivary.Status = 1;
//                notificationDelivary.UserId = notifi.userId;
//                db.NotificationDelivary.Add(notificationDelivary);

//                db.SaveChanges();


//                return Ok("لقد قمت بإرسال الإشعار  بنــجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }





//        [HttpGet("GetSkedjuleInfo")]
//        public IActionResult GetSkedjuleInfo(long EventId)
//        {
//            try
//            {

//                var GetSkedjule = (from p in db.Skedjule where p.EventId == EventId select p).ToList();


//                var SkedjuleList = (from p in GetSkedjule

//                                    select new
//                                    {
//                                        Subject = (from q in db.Subjects where q.SubjectId == p.SubjectId select q.Name).SingleOrDefault(),
//                                        Day = p.Day,
//                                        LectureNumber = p.LectureNumber,

//                                    }).ToList();


//                return Ok(new { Skedjules = SkedjuleList });
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpPost("{id}/delteSkedjule")]
//        public IActionResult delteSkedjule(long id)
//        {
//            try
//            {
//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                var Skedjule = (from p in db.Skedjule where p.EventId == id select p).ToList();

//                if (Skedjule == null)
//                {
//                    return StatusCode(401, "لم يتم العتور علي الجدول ربما تم مسحه مسبقا");
//                }

//                db.Skedjule.RemoveRange(Skedjule);

//                db.SaveChanges();

//                return Ok("تم حدف الجدول بنجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpGet("GetYearsInfo")]
//        public IActionResult GetYearsInfo(int pageNo, int pageSize)
//        {
//            try
//            {
//                var YearInof = from p in db.Years where p.Status != 9 select p;

//                var Count = (from p in YearInof select p).Count();

//                var YearInfo = (from p in YearInof
//                                orderby p.CreatedOn descending
//                                select new
//                                {
//                                    id = p.YearId,
//                                    name = p.Name,
//                                    createdOn = p.CreatedBy,
//                                    createdBy = p.CreatedOn
//                                }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

//                return Ok(new { years = YearInfo, count = Count });
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpPost("{id}/deleteYears")]
//        public IActionResult delteHomeWorck(long id)
//        {
//            try
//            {
//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                var Year = (from p in db.Years where p.YearId == id select p).SingleOrDefault();

//                if (Year == null)
//                {
//                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
//                }

//                Year.Status = 9;

//                db.SaveChanges();

//                return Ok("تم حدف السنة الدراسية بنجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }
//        [HttpPost("edityearName")]
//        public IActionResult edityearName([FromBody] YearsObject form)
//        {
//            try
//            {

//                if (form == null)
//                {
//                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
//                }

//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                var Years = (from p in db.Years where p.YearId == form.id select p).SingleOrDefault();

//                if (Years == null)
//                {
//                    return StatusCode(401, "لم يتم العتور علي السجل الرجاء التأكد من البيانات");
//                }

//                Years.Name = form.name;
//                db.SaveChanges();

//                return Ok("لقد قمت بتعديل بيانات السنة الدراسية  بنــجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpPost("addyearName")]
//        public IActionResult addyearName([FromBody] YearsObject form)
//        {
//            try
//            {

//                if (form == null)
//                {
//                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
//                }

//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                var Years = (from p in db.Years where p.Name == form.name select p).SingleOrDefault();

//                if (Years != null)
//                {
//                    return StatusCode(401, "الاسم موجود مسبقا");
//                }

//                Years year = new Years();
//                year.Name = form.name;
//                year.Status = 1;
//                year.CreatedBy = userId;
//                year.CreatedOn = DateTime.Now;
//                db.Years.Add(year);
//                db.SaveChanges();

//                return Ok("تمت عملية الاضافة بنجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpGet("getyearName")]
//        public IActionResult getyearName()
//        {
//            try
//            {
//                var YearInof = from p in db.AcadimacYears where p.Status != 9 select p;

//                var YearInfo = (from p in YearInof
//                                orderby p.CreatedOn descending
//                                select new
//                                {
//                                    id = p.AcadimecYearId,
//                                    name = p.Name,
//                                }).ToList();

//                return Ok(new { years = YearInfo });
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpGet("GetSubjectInfo")]
//        public IActionResult GetSubjectInfo(int pageNo, int pageSize, int id)
//        {
//            try
//            {
//                var subjects = from p in db.Subjects where p.Status != 9 select p;

//                if (id != 0)
//                {
//                    subjects = from p in subjects where p.AcadimecYearId == id select p;
//                }

//                var Count = (from p in subjects select p).Count();

//                var subjectInfo = (from p in subjects
//                                   orderby p.CreatedOn descending
//                                   select new
//                                   {
//                                       id = p.SubjectId,
//                                       name = p.Name,
//                                       yearName = p.AcadimecYear.Name,
//                                       createdOn = p.CreatedOn
//                                   }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

//                return Ok(new { Subjects = subjectInfo, count = Count });
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpPost("editsubjectname")]
//        public IActionResult editsubjectname([FromBody] YearsObject form)
//        {
//            try
//            {

//                if (form == null)
//                {
//                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
//                }

//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                var subject = (from p in db.Subjects where p.SubjectId == form.id select p).SingleOrDefault();

//                if (subject == null)
//                {
//                    return StatusCode(401, "لم يتم العتور علي السجل الرجاء التأكد من البيانات");
//                }

//                subject.Name = form.name;
//                db.SaveChanges();

//                return Ok("لقد قمت بتعديل بيانات المادة الدراسية  بنــجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpPost("{id}/deleteSubject")]
//        public IActionResult deleteSubject(long id)
//        {
//            try
//            {
//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                var subject = (from p in db.Subjects where p.SubjectId == id select p).SingleOrDefault();

//                if (subject == null)
//                {
//                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
//                }

//                subject.Status = 9;

//                db.SaveChanges();

//                return Ok("تم حدف السنة الدراسية بنجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpPost("addSubject")]
//        public IActionResult addSubject([FromBody] YearsObject form)
//        {
//            try
//            {

//                if (form == null)
//                {
//                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
//                }

//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                var subjectCheck = (from p in db.Years where p.Name == form.name select p).SingleOrDefault();

//                if (subjectCheck != null)
//                {
//                    return StatusCode(401, "الاسم موجود مسبقا");
//                }

//                Subjects subject = new Subjects();
//                subject.Name = form.name;
//                subject.AcadimecYearId = int.Parse(form.id.ToString());
//                subject.Status = 1;
//                subject.CreatedBy = userId;
//                subject.CreatedOn = DateTime.Now;
//                db.Subjects.Add(subject);
//                db.SaveChanges();

//                return Ok("تمت عملية الاضافة بنجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }



//    }
//}

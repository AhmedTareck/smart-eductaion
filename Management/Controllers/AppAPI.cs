using Managegment.Controllers;
using Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Controllers
{
    [Produces("application/json")]
    [Route("Api/Admin/AppApi")]
    public class AppAPI : Controller
    {
        private Helper help;

        private readonly StudentTrackerContext db;

        public AppAPI(StudentTrackerContext context)
        {
            this.db = context;
            help = new Helper();
        }

        //get UserId return StudentInof
        //StatusCode(400, "المستخدم غير موجود");
        [HttpGet("GetStudentByParent")]
        public IActionResult GetStudentByParent(long UserId)
        {
            try
            {
                var students = (from p in db.StudentEvents
                                where p.Student.ParentId == UserId where p.Student.Status != 9 select new
                {
                    studentId=p.StudentId,
                    firstName=p.Student.FirstName,
                    fatherName=p.Student.FirstName,
                    grandFatherName=p.Student.GrandFatherName,
                    surName=p.Student.SurName,
                    adrress=p.Student.Adrress,
                    phoneNumber=p.Student.PhoneNumber,
                    sex=p.Student.Sex,
                    matherName=p.Student.MatherName,
                    Class=p.Event.EventGroup,
                    year = p.Event.AcadimecYear.Name,
                    eventId=p.EventId

                }).ToList();
                
                return Ok(new { students = students });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("GetStudentExam")]
        public IActionResult GetStudentExam(long StudentId,long eventId)
        {
            try
            {
                var Exams = (from p in db.Exams
                              where p.EventId == eventId /*&& p.Event.Year.YearId==1*/
                              where p.Status != 9
                              select new
                              {
                                  ExamName = p.Name,
                                  FullMarck = p.FullMarck,
                                  ExamDate = p.ExamDate,
                                  SubjectName=p.Subject.Name,
                                  Discreptons=p.Discreptons,
                                  Grid= p.Grids.Any(a=>a.StudentId==StudentId)? p.Grids.SingleOrDefault(s => s.StudentId == StudentId).Grid:-1
                              }).ToList();

                return Ok(new { Exams = Exams });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetPresness")]
        public IActionResult GetPresness(long StudentId)
        {
            try
            {
                var Presness = (from p in db.PresnessInfo
                              where p.StudentId == StudentId /*&& p.Event.Year.YearId==1*/
                              where p.Presness.Status != 9
                              select new
                              {
                                  Stute=p.Status,
                                  LectureDate = p.Presness.LectureDate,
                              }).ToList();

                return Ok(new { Presness = Presness });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetHomeWorcks")]
        public IActionResult GetHomeWorcks(long eventId)
        {
            try
            {
                var HomeWorcks = (from p in db.HomeWorcks
                                where p.EventId == eventId /*&& p.Event.Year.YearId==1*/
                                where p.Status != 9
                                select new
                                {
                                    Name = p.Name,
                                    Disctiption = p.Disctiption,
                                    LastDayDilavary = p.LastDayDilavary,
                                    CreatedOn = p.CreatedOn,
                                    SubjectName = p.Subject.Name,

                                }).ToList();

                return Ok(new { HomeWorcks = HomeWorcks });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetSkedjule")]
        public IActionResult GetSkedjule(long eventId)
        {
            try
            {

                var Skedjule = db.Skedjule.Where(w => w.EventId == eventId).Include(i=>i.Subject).ToList();

                var Sa = Skedjule.Where(sa => sa.Day == 1).Select(s => new
                {
                    SubjectName=s.Subject.Name,
                    LectureNumber=s.LectureNumber
                }).ToList();

                var Su = Skedjule.Where(sa => sa.Day == 2).Select(s => new
                {
                    SubjectName = s.Subject.Name,
                    LectureNumber = s.LectureNumber
                }).ToList();

                var mo = Skedjule.Where(sa => sa.Day == 3).Select(s => new
                {
                    SubjectName = s.Subject.Name,
                    LectureNumber = s.LectureNumber
                }).ToList();

                var tu = Skedjule.Where(sa => sa.Day == 4).Select(s => new
                {
                    SubjectName = s.Subject.Name,
                    LectureNumber = s.LectureNumber
                }).ToList();

                var we = Skedjule.Where(sa => sa.Day == 5).Select(s => new
                {
                    SubjectName = s.Subject.Name,
                    LectureNumber = s.LectureNumber
                }).ToList();

                var th = Skedjule.Where(sa => sa.Day == 6).Select(s => new
                {
                    SubjectName = s.Subject.Name,
                    LectureNumber = s.LectureNumber
                }).ToList();

                var result = new
                {
                    sa = Sa,
                    su = Su,
                    mo = mo,
                    tu = tu,
                    we = we,
                    th = th,
                };
                return Ok(new { result = result });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("getNotifications")]
        public IActionResult getNotifications()
        {
            try
            {
                var userId = help.GetCurrentUser(HttpContext);

                var notifications = db.NotificationDelivary.Where(w => w.Notification.Status != 9 && w.UserId == userId).Select(select => new
                {
                    IdNotification = select.Id,
                    Notification = select.Notification.Notification,
                    CreatedOn = select.Notification.CreatedOn,
                    Read=select.Status,
                    TypeNotification=(
                    select.Notification.Status==1? "واجب دراسي":
                    select.Notification.Status == 2 ? "إختبار" :
                    select.Notification.Status == 3 ? "رسالة ":
                    select.Notification.Status == 4 ? "تنبيه " : "تعميم")

                }).OrderByDescending(o=>o.CreatedOn).ToList();

                var notificationCount = notifications.Where(w => w.Read == 1).Count();

                return Ok(new { notifications = notifications, notificationCount= notificationCount });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPut("ReadNotification")]
        public IActionResult ReadNotification(long notificationId)
        {
            try
            {

                var notification = db.NotificationDelivary.SingleOrDefault(s => s.Id == notificationId);

                notification.Status = 2;

                db.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        //[HttpGet("GetStudentPresence")]
        //public IActionResult GetStudentPresence(long StudentEventId)
        //{
        //    try
        //    {
        //        var Presence = (from p in db.Presness
        //                        where p.StudentEventId == StudentEventId
        //                        where p.Status != 9
        //                        select p).ToList();

        //        return Ok(new { Presence = Presence });
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        //[HttpGet("GetStudetnSkedjule")]
        //public IActionResult GetStudetnSkedjule(long StudentEventId)
        //{
        //    try
        //    {
        //        var Presence = (from p in db.Presness
        //                        where p.StudentEventId == StudentEventId
        //                        where p.Status != 9
        //                        select p).ToList();

        //        return Ok(new { Presence = Presence });
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}


    }
}

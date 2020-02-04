using Managegment.Controllers;
using Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                var students = (from p in db.Students where p.ParentId == UserId where p.Status != 9 select new
                {
                    studentId=p.StudentId,
                    firstName=p.FirstName,
                    fatherName=p.FirstName,
                    grandFatherName=p.GrandFatherName,
                    surName=p.SurName,
                    adrress=p.Adrress,
                    phoneNumber=p.PhoneNumber,
                    sex=p.Sex,
                    matherName=p.MatherName,
                }).ToList();
                
                return Ok(new { students = students });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetEventStudent")]
        public IActionResult GetEventStudent(long StudentId)
        {
            try
            {
                var Events = (from p in db.StudentEvents
                                where p.StudentId == StudentId /*&& p.Event.Year.YearId==1*/
                                where p.Status != 9
                                select new
                                {
                                    Class=p.Event.EventGroup,
                                    year=p.Event.AcadimecYear.Name,
                                }).ToList();

                return Ok(new { Events = Events });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetGridInfo")]
        public IActionResult GetGridInfo(long StudentId)
        {
            try
            {
                var Events = (from p in db.Grids
                              where p.StudentId == StudentId /*&& p.Event.Year.YearId==1*/
                              where p.Status != 9
                              select new
                              {
                                  ExamName=p.Exam.Name,
                                  FullMarck=p.Exam.FullMarck,
                                  Grid=p.Grid,
                                  ExamDate = p.Exam.ExamDate,
                              }).ToList();

                return Ok(new { Events = Events });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetStudentExam")]
        public IActionResult GetStudentExam(long StudentId)
        {
            try
            {
                var Events = (from p in db.Grids
                              where p.StudentId == StudentId /*&& p.Event.Year.YearId==1*/
                              where p.Status != 9
                              select new
                              {
                                  ExamName = p.Exam.Name,
                                  FullMarck = p.Exam.FullMarck,
                                  Grid = p.Grid,
                                  ExamDate = p.Exam.ExamDate,
                              }).ToList();

                return Ok(new { Events = Events });
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

//using Managegment.objects;
//using Management.Models;
//using Management.objects;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Managegment.Controllers
//{
//    [Produces("application/json")]
//    [Route("Api/Admin/Exam")]
//    public class ExamController : Controller
//    {
//        private Helper help;

//        private readonly Tranim_LearningContext db;

//        public ExamController(Tranim_LearningContext context)
//        {
//            this.db = context;
//            help = new Helper();
//        }

//        [HttpGet("GetExams")]
//        public IActionResult GetExams(int pageNo, int pageSize, long YearId, long eventId)
//        {
//            try
//            {
//                var Exam = from p in db.Exams
//                           where p.Status != 9
//                           select p;

//                if (YearId != 0)
//                {
//                    Exam = from p in Exam where p.Event.YearId == YearId select p;
//                }

//                if (eventId != 0)
//                {
//                    Exam = from p in Exam where p.EventId == eventId select p;
//                }

//                var Count = (from p in Exam select p).Count();

//                var ExamList = (from p in Exam
//                                orderby p.CreatedOn descending
//                                select new
//                                {
//                                    Id = p.ExamId,
//                                    Name = p.Name,
//                                    FullMarck = p.FullMarck,
//                                    Disctiption = p.Discreptons,
//                                    ExamDate = p.ExamDate,
//                                    CreatedOn = p.CreatedOn,
//                                    subject = p.Subject.Name,
//                                }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

//                return Ok(new { Exam = ExamList, count = Count });
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpPost("Add")]
//        public IActionResult AddExam([FromBody] ExamObject selectedExams)
//        {
//            try
//            {

//                if (selectedExams == null)
//                {
//                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
//                }

//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                var Exam = new Exams();

//                Exam.EventId = selectedExams.eventId;
//                Exam.Name = selectedExams.name;
//                Exam.Discreptons = selectedExams.disctiption;
//                Exam.ExamDate = selectedExams.examDate;
//                Exam.FullMarck = selectedExams.fullMarck;
//                Exam.SubjectId = selectedExams.SubjectSelected;
//                Exam.CreatedBy = userId;
//                Exam.CreatedOn = DateTime.Now;
//                Exam.Status = 1;
//                db.Exams.Add(Exam);
//                db.SaveChanges();

//                return Ok("لقد قمت بتسـجيل بيانات الإختبار  بنــجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpPost("Edit")]
//        public IActionResult EditHomeWorck([FromBody] ExamObject selectedExam)
//        {
//            try
//            {

//                if (selectedExam == null)
//                {
//                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
//                }

//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                var Exam = (from p in db.Exams where p.ExamId == selectedExam.id select p).SingleOrDefault();

//                if (Exam == null)
//                {
//                    return StatusCode(401, "لم يتم العتور علي الواجب الدراسي الرجاء التأكد من البيانات");
//                }

//                Exam.Name = selectedExam.name;
//                Exam.Discreptons = selectedExam.disctiption;
//                Exam.ExamDate = selectedExam.examDate;
//                Exam.FullMarck = selectedExam.fullMarck;
//                db.SaveChanges();

//                return Ok("لقد قمت بتعديل بيانات الإختبار الدراسي  بنــجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpPost("{id}/delteExams")]
//        public IActionResult delteHomeWorck(long id)
//        {
//            try
//            {
//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                var Exam = (from p in db.Exams where p.ExamId == id select p).SingleOrDefault();

//                if (Exam == null)
//                {
//                    return StatusCode(401, "لم يتم العتور علي السجل ربما تم مسحه مسبقا");
//                }

//                Exam.Status = 9;

//                db.SaveChanges();

//                return Ok("تم حدف الإختبار بنجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpPost("addGrids")]
//        public IActionResult addGrids([FromBody] GridsObject presness)
//        {
//            try
//            {

//                if (presness == null)
//                {
//                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء التأكد من إدخال جميع البيانات ");
//                }

//                var userId = this.help.GetCurrentUser(HttpContext);

//                if (userId <= 0)
//                {
//                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
//                }

//                var Grids = (from p in db.Grids where p.ExamId == presness.ExamSelected && p.Status != 9 select p).SingleOrDefault();

//                if (Grids != null)
//                {
//                    return StatusCode(401, "تم رصد الدرجات لهذا الإختبار مسبقا الرجاء التأكد من الإدخال");
//                }


//                foreach (Students item in presness.Students)
//                {
//                    Grids = new Grids();
//                    Grids.ExamId = presness.ExamSelected;
//                    Grids.CreatedBy = userId;
//                    Grids.CreatedOn = DateTime.Now;
//                    Grids.Status = 1;
//                    Grids.StudentId = item.StudentId;
//                    Grids.Grid = int.Parse(item.FirstName);
//                    db.Grids.Add(Grids);
//                }

//                db.SaveChanges();

//                return Ok("تمت عمليةرصد الدرجات  بنجاح");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//        [HttpGet("getGridsInfo")]
//        public IActionResult getGridsInfo(int pageNo, int pageSize, long id)
//        {
//            try
//            {
//                var GridInfo = from p in db.Grids
//                               where p.Status != 9 && p.ExamId == id
//                               select p;

//                var Count = (from p in GridInfo select p).Count();

//                var GridInfoList = (from p in GridInfo
//                                    orderby p.Grid descending
//                                    select new
//                                    {
//                                        Id = p.GridId,
//                                        StudentName = p.Student.FirstName + ' ' + p.Student.FatherName + ' ' + p.Student.GrandFatherName + ' ' + p.Student.SurName,
//                                        Marck = p.Grid,
//                                        CreatedBy = p.CreatedBy,
//                                        CreatedOn = p.CreatedOn,
//                                    }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

//                return Ok(new { Exam = GridInfoList, count = Count });
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500, e.Message);
//            }
//        }

//    }
//}
